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
    public partial class aliasManager : Form
    {
        // https://stackoverflow.com/questions/577092/c-sharp-gui-control-for-editing-a-dictionary
        BindingList<kvp> pairs;

        public aliasManager()
        {
            InitializeComponent();
        }

        private void aliasManager_Load(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/1909268/convert-a-list-of-objects-from-one-type-to-another-using-lambda-expression
            pairs = new BindingList<kvp>(
                mainForm.aliases.Select(
                    x => new kvp(x.Key, x.Value)).ToList());

            // register event handler 
            pairs.AddingNew += pairs_AddingNew;

            // setup datagrid view display and binding
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = true;

            var source = new BindingSource();
            source.DataSource = pairs;
            dataGridView1.DataSource = source;
        }

        private void saveAliases()
        {
            // validate
            var allKeys = pairs.Select(x => x.Key);
            var uniqueKeyCount = allKeys.Distinct().Count();

            if (allKeys.Count() != uniqueKeyCount)
            {
                MessageBox.Show(
                    "Non-unique keys detected for aliases.\nNo changes will be saved until these duplicates are resolved", 
                    "Non-unique Keys",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // write back to dict on form1
            mainForm.aliases = pairs.
                Where(x => x.Key != null).
                ToDictionary(x => x.Key, x => x.Value);
        }

        private void pairs_AddingNew(object sender, AddingNewEventArgs e)
        {

            //e.NewObject = new kvp { parent = (sender as IList<kvp>) };
            saveAliases();
        }

        private void aliasManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveAliases();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.Text = e.ToString();
        }
    }

    public class kvp //: IDataErrorInfo
    {
        internal IList<kvp> parent { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        //private string error = "";
        //public string Error
        //{
        //    get { return error;  }
        //}

        //public string this[string columnName]
        //{
        //    get {
        //        error = "";
        //        // check all keys are unique
        //        if (columnName == "Key" && parent != null) 
        //        {
        //            // get all current key names, check they are not equal to the current one
        //            bool isDuplicate = parent.Any(x => x.Key == this.Key && !ReferenceEquals(x, this));

        //            if (isDuplicate)
        //                error = "key error";
        //        }
        //        return error;
        //    }
        //}

        public kvp() { }

        public kvp(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
}
