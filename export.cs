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
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now.Date;
            fromDateTimePicker.Value = dt;
            toDateTimePicker.Value = dt;
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

            // freeze values
            DateTime from = fromDateTimePicker.Value.Date;
            DateTime to = toDateTimePicker.Value.AddDays(1).Date;

            // see
            // https://entityframework.net/knowledge-base/40755567/group-by-multiple-column-in-linq-in-csharp
            var DictSum = mainForm.record.Where(kvp =>
                kvp.workStarted >= from && kvp.workStarted <= to).
                GroupBy(rec => new { rec.workStarted.Date, rec.workName });

            //var res = DictSum.ToDictionary(rec => rec.Key, rec => TimeSpan.FromTicks(rec.Sum(r => r.workedHoursTicks)));
            var res = DictSum.Select(rec => new
            {
                Date = rec.Key.Date,
                Work = rec.Key.workName,
                Alias = mainForm.aliases.ContainsKey(rec.Key.workName) ? mainForm.aliases[rec.Key.workName] : "",
                Entries = rec.Count(),
                Time = TimeSpan.FromTicks(rec.Sum(r => r.workedHoursTicks))
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
    }
}
