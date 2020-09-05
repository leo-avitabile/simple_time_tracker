using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using time_tracker_forms.Properties;

namespace time_tracker_forms
{
    public partial class mainForm : Form
    {
        const int tickRateSeconds = 1;
        const int minutesBeforeBreak = 50;
        readonly TimeSpan OneSecond = new TimeSpan(0, 0, 1);

        public static workedTimeRecord currentRecord;

        HashSet<string> workItems = new HashSet<string>();

        // see https://stackoverflow.com/questions/7008361/how-can-i-refresh-c-sharp-datagridview-after-update/7009131
        public static BindingList<workedTimeRecord> record = new BindingList<workedTimeRecord>();

        KeyboardHook.KeyboardHook hook = new KeyboardHook.KeyboardHook();

        public static Dictionary<string, string> quickInserts;

        public static Dictionary<string, string> aliases;

        string statusText = "Waiting...";

        private bool isLockedByUser = false;

        private static aliasManager aliasManager = null;
        private static quickInsert quickInsert = null;
        private static export export = null;
        private static options options = null;
        private static aboutForm aboutForm = null;

        // Fixed: Multiple sub-windows can no longer be opened
        #region Single instance of forms management
        private static void GetAliasManagerInstance()
        {
            // https://stackoverflow.com/questions/3087841/how-can-i-make-a-single-instance-form-not-application
            if (aliasManager == null)
            {
                aliasManager = new aliasManager();
                aliasManager.FormClosed += delegate { aliasManager = null; };
            }
            aliasManager.Show();
        }

        private static void GetQuickInsertInstance()
        {
            if (quickInsert == null)
            {
                quickInsert = new quickInsert();
                quickInsert.FormClosed += delegate { quickInsert = null; };
            }
            quickInsert.Show();
        }

        private static void GetExportInstance()
        {
            if (export == null)
            {
                export = new export();
                export.FormClosed += delegate { export = null; };
            }
            export.Show();
        }

        private static void GetOptionsInstance()
        {
            if (options == null)
            {
                options = new options();
                options.FormClosed += delegate { options = null; };
            }
            options.Show();
        }

        private static void GetAboutInstance()
        {
            if (aboutForm == null)
            {
                aboutForm = new aboutForm();
                aboutForm.FormClosed += delegate { aboutForm = null; };
            }
            aboutForm.Show();
        }
        #endregion

        public mainForm()
        {
            InitializeComponent();
            timer1.Interval = tickRateSeconds * 1000;

            if (File.Exists(Settings.Default.WorkRecordPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(workedTimeRecordList));
                StreamReader reader = new StreamReader(Settings.Default.WorkRecordPath);
                workedTimeRecordList recordList = (workedTimeRecordList)serializer.Deserialize(reader);

                foreach (workedTimeRecord rec in recordList.records)
                {
                    record.Add(rec);
                    workItems.Add(rec.workName);
                }
                reader.Close();
            }

            // load data from files
            quickInserts = loadQuickInsertData();
            aliases = loadAliases();

            // Set keyboard hook
            hook.RegisterHotKey(KeyboardHook.ModifierKeys.Control, Keys.OemQuestion);
            hook.KeyPressed += new EventHandler<KeyboardHook.KeyPressedEventArgs>(hook_KeyPressed);

            // capture if the user locks thier pc
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            updateAutocomplete();

            // set dgv view
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ;

            // get cursor ready for typing
            textBox1.Select();
        }

        public void updateQuickFillSuggestions()
        {
            dataGridView1.Rows.Clear();
            foreach (var kvp in quickInserts)
                dataGridView1.Rows.Add(kvp.Key, kvp.Value);
        }

        private Dictionary<string, string> loadQuickInsertData()
        {
            List<string> validKeys = new List<string> {
                "1", "2", "3", "4", "5", "6", "7", "8", "9" 
            };

            Dictionary<string, string> newDict = new Dictionary<string, string>();

            if (File.Exists(Settings.Default.QuickInsertPath))
                newDict = loadDictFromXML(Settings.Default.QuickInsertPath, "item");

            // remove entries that are not [1,9]
            var dictKeys = newDict.Keys.ToList();
            foreach (var dictKey in dictKeys)
                if (!validKeys.Contains(dictKey))
                    newDict.Remove(dictKey);

            // add a blank entry for any entry not included in the file for whatever reason 
            foreach (var validKey in validKeys)
                if (!newDict.ContainsKey(validKey))
                    newDict.Add(validKey, "");
            

            return newDict;
        }

        private Dictionary<string, string> loadAliases()
        {
            Dictionary<string, string> newDict = new Dictionary<string, string>();

            if (File.Exists(Settings.Default.AliasPath))
                newDict = loadDictFromXML(Settings.Default.AliasPath, "alias");

            return newDict;
        }

        private static Dictionary<string, string> loadDictFromXML(string path, string rootName, string keyAttrName="id", string valueAttrName = "value")
        {
            Dictionary<string, string> newDict = new Dictionary<string, string>();
            // load, but record dup keys
            HashSet<string> dupKeys = new HashSet<string>();

            XElement xElem2 = XElement.Load(path);
            foreach (var elem in xElem2.Descendants(rootName))
            {
                string id = (string)elem.Attribute(keyAttrName);
                string val = (string)elem.Attribute(valueAttrName);

                if (!newDict.ContainsKey(id))
                    newDict.Add(id, val);
                else
                    dupKeys.Add(id);
            }

            // if any dups, show
            if (dupKeys.Count > 0)
                MessageBox.Show(
                    path + " contains duplicate key:\n" + String.Join("\n", dupKeys) + "\nAll duplicates after the first entryhave been ignored.",
                    "Caption",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            return newDict;
        }

        private void hook_KeyPressed(object sender, KeyboardHook.KeyPressedEventArgs e)
        {
            showSelf();
        }

        private void showSelf()
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (Settings.Default.PauseWhenLocked)
            {
                if (e.Reason == SessionSwitchReason.SessionLock)
                    timer1.Enabled = false;
                else if (e.Reason == SessionSwitchReason.SessionUnlock)
                    if (currentRecord != null && !isLockedByUser) 
                        timer1.Enabled = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showSelf();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) 
                this.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quit();
        }

        private void quit()
        {
            Application.Exit();
        }

        // Todo: This feels like it could be split up better
        private void beginTimeRecord(string workName, bool showBallon=true)
        {
            // represents if what was typed into the text box is different to what we are already recording
            // default to true since there might not be any current work to check against, in which case it will be new work
            bool newWork = true;

            // if something has been worked on and is new then add to record
            if (currentRecord != null)
            {
                // see if the new text is different to what we are currently logging time to
                newWork = (currentRecord.workName != workName);

                // if the work item is new then save the previous one
                if (newWork)
                {
                    record.Insert(0, currentRecord);
                    workItems.Add(currentRecord.workName);
                    updateAutocomplete();
                }
            }

            timer1.Stop();

            if (newWork)
            {
                //create new record
                currentRecord = new workedTimeRecord(workName, new TimeSpan(), DateTime.Now);
                updateControlsToDisplayNewWork(workName, showBallon);
            }

            // clean up controls and form
            textBox1.Text = "";
            this.Visible = !Settings.Default.MinimiseAfterEnter;
            timer1.Start();
        }

        private void updateControlsToDisplayNewWork(string workName, bool showBalloon)
        {
            // update controls
            statusText = "Logging time to: " + workName;
            notifyIcon1.BalloonTipText = statusText;
            toolStripStatusLabel.Text = statusText;
            notifyIcon1.Text = statusText;
            if (showBalloon)
                notifyIcon1.ShowBalloonTip(1000);
        }

        private void updateAutocomplete()
        {
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            stringCollection.AddRange(workItems.ToArray());
            textBox1.AutoCompleteCustomSource = stringCollection;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentRecord.workedHours += OneSecond;

            if (currentRecord.workedHours.Minutes == minutesBeforeBreak && currentRecord.workedHours.Seconds == 0)
            {
                notifyIcon1.BalloonTipTitle = "Take a break!";
                notifyIcon1.BalloonTipText = "It's been " + minutesBeforeBreak.ToString() + " minutes, how about a 10 minute break";
                notifyIcon1.ShowBalloonTip(1000);
            }

            lblTimeDisplay.Text = currentRecord.workedHours.ToString();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            quit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool ControlPressed = (e.Modifiers & Keys.Control) == Keys.Control;
            bool APressed = e.KeyCode == Keys.A;
            if (ControlPressed)
            {
                //Todo: Can this be moved somewhere else?
                updateQuickFillSuggestions();

                dataGridView1.Visible = true;
                switch (e.KeyCode)
                {
                    case Keys.D1:
                    case Keys.D2:
                    case Keys.D3:
                    case Keys.D4:
                    case Keys.D5:
                    case Keys.D6:
                    case Keys.D7:
                    case Keys.D8:
                    case Keys.D9:
                        // Todo: Make robust
                        string keyVal = e.KeyCode.ToString();
                        keyVal = keyVal.Remove(0, 1);  // remove the "D" at the start of the string above

                        // if the box is empty, insert from previous
                        if (textBox1.Text.Length == 0)
                        {
                            textBox1.Text = quickInserts[keyVal];
                            textBox1.SelectionStart = textBox1.Text.Length;
                            textBox1.SelectionLength = 0;
                        }
                        // if it is populated
                        else
                        {
                            // if the text in the box is different to that in the quick insert list then update the quick insert list
                            if (quickInserts[keyVal] != textBox1.Text)
                            {
                                toolStripStatusLabel.Text = "Saved \"" + textBox1.Text + "\" to quick insert #" + keyVal;
                                quickInserts[keyVal] = textBox1.Text;
                                // Todo: Save quick fill
                                updateQuickFillSuggestions();
                                statusUpdateTimer.Enabled = true;
                            }
                            // otherwise begin logging
                            else
                                beginTimeRecord(textBox1.Text);                            
                        }
                        break;
                    default:
                        break;
                }
            }

            // handle typing
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z && !ControlPressed)
            {
                if (!textBox1.Focused)
                {
                    textBox1.Select();

                    // type char that was pressed
                    System.Windows.Forms.KeyEventArgs args = e as System.Windows.Forms.KeyEventArgs;
                    string typedChar = args.KeyCode.ToString();
                    if (!args.Shift) 
                        typedChar = typedChar.ToLower();
                    textBox1.Text += typedChar;

                    // put cursor at end ready for more typing
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.SelectionLength = 0;
                }
            }
            
            if (e.KeyCode == Keys.Escape) {
                this.Visible = false;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // add to record
                string typedText = textBox1.Text;
                if (e.Modifiers == Keys.Shift) 
                    typedText = typedText.ToUpper();

                beginTimeRecord(typedText);
            }
        }

        private void resumeWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRecord != null)
            { 
                isLockedByUser = false;
                timer1.Enabled = true;
                lblTimeDisplay.ForeColor = Color.Black;
              }
        }

        private void pauseWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                lblTimeDisplay.ForeColor = Color.Red;
                isLockedByUser = true;
            }

            timer1.Enabled = false;
        }

        private void iconMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            recentToolStripMenuItem.DropDownItems.Clear();
            var lastActivities = workItems.Take(10).Reverse().ToArray();
            foreach (string act in lastActivities.Reverse())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(act);
                item.Click += recentMenuItem_Click;
                recentToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void recentMenuItem_Click(object sender, EventArgs e)
        {
            string text = (sender as ToolStripMenuItem).Text;
            beginTimeRecord(text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // add a dummy entry - this will cause the current one to be saved
            beginTimeRecord("", false);

            // save time data
            XmlSerializer serializer = new XmlSerializer(typeof(workedTimeRecordList));
            workedTimeRecordList records = new workedTimeRecordList();
            records.records = record.ToArray();
            FileStream fs = new FileStream(Settings.Default.WorkRecordPath, FileMode.Create);
            serializer.Serialize(fs, records);
            fs.Close();

            // save quick insert data
            XElement xElem = new XElement(
                    "items",
                    quickInserts.Select(x => new XElement("item", new XAttribute("id", x.Key), new XAttribute("value", x.Value)))
                 );
            xElem.Save(Settings.Default.QuickInsertPath);

            // save aliases
            XElement xElem2 = new XElement(
                    "aliases",
                    aliases.Select(x => new XElement("alias", new XAttribute("id", x.Key), new XAttribute("value", x.Value)))
                 );
            xElem2.Save(Settings.Default.AliasPath);

            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void quickInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetQuickInsertInstance();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers != Keys.Control)
            {
                dataGridView1.Visible = false;
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetExportInstance();
        }

        private void aliasManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAliasManagerInstance();
        }

        private void statusUpdateTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = statusText;
            statusUpdateTimer.Enabled = false;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetOptionsInstance();
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            currentWorkToolStripMenuItem.Enabled = (currentRecord != null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAboutInstance();
        }

        private void currentWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create form, show modally and capture 
            editForm editForm = new editForm();
            editForm.ShowDialog();

            if (editForm.DialogResult == DialogResult.OK)
            {
                currentRecord.workName = editForm.newWorkName;
                currentRecord.workedHours = editForm.newWorkedTimespan;
                lblTimeDisplay.Text = currentRecord.workedHours.ToString();
                updateControlsToDisplayNewWork(currentRecord.workName, false);
            }


            editForm.Close();

        }

        private void toolsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            resumeWorkToolStripMenuItem.Enabled = isLockedByUser;
            pauseWorkToolStripMenuItem.Enabled = (currentRecord != null) && !isLockedByUser;
        }
    }

    public class workedTimeRecord
    {
        [XmlAttribute()]
        public string workName { get; set; }

        [XmlIgnore()]
        public TimeSpan workedHours { get; set; }

        [XmlAttribute()]
        public DateTime workStarted { get; set; }

        [XmlAttribute()]
        public long workedHoursTicks
        {
            get
            {
                return this.workedHours.Ticks;
            }
            set
            {
                this.workedHours = new TimeSpan(value);
            }
        }

        public workedTimeRecord(string name, TimeSpan hours, DateTime started)
        {
            workName = name;
            workedHours = hours;
            workStarted = started;
        }

        public workedTimeRecord() { }
        public workedTimeRecord(workedTimeRecord other)
        {
            this.workName = other.workName;
            this.workedHours = other.workedHours;
            this.workStarted = other.workStarted;
        }
    }

    public class workedTimeRecordList
    {
        public workedTimeRecord[] records { get; set; }

        public workedTimeRecordList() { }
    }
}
