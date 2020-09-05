using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_tracker_forms
{
    public partial class export : Form
    {
        public export()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;

            // Fixed: Auto populate export to show todays work
            showToday();

            // property binding playing silly bugger so just set the values instead
            //rbNoExportGrouping.Checked = Properties.Settings.Default.NoExportGrouping;
            rbWorkNameExportGrouping.Checked = Properties.Settings.Default.WorkNameExportGrouping;
            rbAliasExportGrouping.Checked = Properties.Settings.Default.AliasExportGrouping;
        }

        private void showToday()
        {
            DateTime dt = DateTime.Now.Date;
            fromDateTimePicker.Value = dt;
            toDateTimePicker.Value = dt;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            showToday();
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now.Date;
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            fromDateTimePicker.Value = dt.AddDays(-1 * diff).Date;
            toDateTimePicker.Value = dt;
        } 

        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            updateExport();
        }

        private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            updateExport();
        }

        private void updateExport()
        {
            Dictionary<DateTime, workedTimeRecord[]> valuePairs = new Dictionary<DateTime, workedTimeRecord[]>();

            // freeze date values
            DateTime from = fromDateTimePicker.Value.Date;
            DateTime to = toDateTimePicker.Value.AddDays(1).Date;


            bool GroupByWorkName = rbWorkNameExportGrouping.Checked;

            // Filter records over time range and grab aliases
            var Records = mainForm.record.Where(rec =>
                rec.workStarted >= from && rec.workStarted <= to).
                Select(rec => new
                {
                    Date = rec.workStarted.Date,
                    WorkName = rec.workName,
                    Alias = mainForm.aliases.ContainsKey(rec.workName) ? mainForm.aliases[rec.workName] : "",
                    Duration = rec.workedHoursTicks
                });

            // create a new record with the GroupName field set to whether the user wants to group by Work Name or Alias
            var RecordsWithKey = Records.Select(rec2 => new
                {
                    Date = rec2.Date,
                    WorkName = rec2.WorkName,
                    Alias = rec2.Alias,
                    GroupName = GroupByWorkName ? rec2.WorkName : rec2.Alias,
                    OtherName = GroupByWorkName ? rec2.Alias : rec2.WorkName,
                    Duration = rec2.Duration
                });


            // see
            // https://entityframework.net/knowledge-base/40755567/group-by-multiple-column-in-linq-in-csharp
            var DictSum = RecordsWithKey.GroupBy(grp => new { grp.Date, grp.GroupName });

            // finally select out the info to display
            var res = DictSum.Select(kvp => new
            {
                Date = kvp.Key.Date,
                WorkName = kvp.ToList()[0].WorkName,
                Alias = kvp.ToList()[0].Alias,
                Entries = kvp.Count(),
                Time = TimeSpan.FromTicks(kvp.Sum(r => r.Duration))
            });

            // bind result to datagridview
            var source = new BindingSource();
            source.DataSource = res;
            dataGridView1.DataSource = source;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/18182029/how-to-export-datagridview-data-instantly-to-excel-on-button-click
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void export_Load(object sender, EventArgs e)
        {

        }

        private void export_FormClosed(object sender, FormClosedEventArgs e)
        {
            // property binding playing silly bugger so just set the values instead
            //Properties.Settings.Default.NoExportGrouping = rbNoExportGrouping.Checked;
            Properties.Settings.Default.WorkNameExportGrouping = rbWorkNameExportGrouping.Checked;
            Properties.Settings.Default.AliasExportGrouping = rbAliasExportGrouping.Checked;
            Properties.Settings.Default.Save();
        }

        private void rbAliasExportGrouping_CheckedChanged(object sender, EventArgs e)
        {
            updateExport();
        }

        private void rbWorkNameExportGrouping_CheckedChanged(object sender, EventArgs e)
        {
            updateExport();
        }
    }
}
