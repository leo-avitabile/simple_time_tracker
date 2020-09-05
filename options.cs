using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using time_tracker_forms.Properties;

namespace time_tracker_forms
{
    public partial class options : Form
    {
        public options()
        {
            InitializeComponent();
        }

        private void options_Load(object sender, EventArgs e)
        {
            txtWorkRecordPath.Text = Settings.Default.WorkRecordPath;
            txtQuickInsertPath.Text = Settings.Default.QuickInsertPath;
            txtAliasesPath.Text = Settings.Default.AliasPath;
        }

        private void btnChooseWorkRecordFilePath_Click(object sender, EventArgs e)
        {
            var res = workRecordOpenFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = workRecordOpenFileDialog.FileName;
                Settings.Default.WorkRecordPath = path;
                Settings.Default.Save();
                txtWorkRecordPath.Text = path;
            }
        }

        private void btnChooseQuickInsertFilePath_Click(object sender, EventArgs e)
        {
            var res = quickInsertOpenFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = quickInsertOpenFileDialog.FileName;
                Settings.Default.QuickInsertPath = path;
                Settings.Default.Save();
                txtQuickInsertPath.Text = path;
            }
        }

        private void btnChooseAliasesFilePath_Click(object sender, EventArgs e)
        {
            var res = aliasesOpenFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = aliasesOpenFileDialog.FileName;
                Settings.Default.AliasPath = path;
                Settings.Default.Save();
                txtAliasesPath.Text = path;
            }
        }

        private void options_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
