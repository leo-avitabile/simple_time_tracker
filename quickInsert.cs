using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace time_tracker_forms
{
    public partial class quickInsert : Form
    {
        public quickInsert()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void quickInsert_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("key", "Key");
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns.Add("val", "Value");
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (KeyValuePair<string, string> valuePair in mainForm.quickInserts)
                dataGridView1.Rows.Add(valuePair.Key, valuePair.Value);
        }

        private void quickInsert_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            { d.Add(r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString()); }

            mainForm.quickInserts = d;
        }
    }
}
