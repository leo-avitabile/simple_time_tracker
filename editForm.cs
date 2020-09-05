using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_tracker_forms
{
    public partial class editForm : Form
    {
        readonly TimeSpan ONE_DAY_TIMESPAN = new TimeSpan(24, 0, 0);
        readonly TimeSpan ZERO_TIMESPAN = new TimeSpan(0, 0, 0);

        // https://docs.microsoft.com/en-us/dotnet/api/system.timespan.tryparseexact?redirectedfrom=MSDN&view=netcore-3.1#System_TimeSpan_TryParseExact_System_String_System_String_System_IFormatProvider_System_TimeSpan__
        readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;
        const string HH_MM_SS_SPECIFIER = "g";

        // static values to be accessed my main form
        public static string newWorkName;
        public static TimeSpan newWorkedTimespan;

        public editForm()
        {
            InitializeComponent();
        }

        private void editForm_Load(object sender, EventArgs e)
        {
            // grab current record values from main form
            txtWorkName.Text = mainForm.currentRecord.workName;
            txtDuration.Text = mainForm.currentRecord.workedHours.ToString();

            // place error indicator inside textbox
            errorProvider1.SetIconPadding(txtDuration, -20);

            // capture keypresses of controls
            this.KeyPreview = true;

            // focus on the work name - that's probably what the user wants to edit
            txtWorkName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            validateTimespan();
        }

        private void validateTimespan()
        {
            // parse typed text and check if valid
            var parseResult = TimeSpan.TryParseExact(txtDuration.Text, HH_MM_SS_SPECIFIER, cultureInfo, out newWorkedTimespan);

            // typed text is valid if:
            var timespanValid =
                parseResult &&                              // could be parsed
                newWorkedTimespan <= ONE_DAY_TIMESPAN &&    // less than 1 day
                newWorkedTimespan >= ZERO_TIMESPAN;         // greater than 0 seconds

            // report error if present, otherwise allow OK button press
            string errorMessage = timespanValid ? "" : "Duration must match time span format (hh:mm:ss) and be more than 0s.";
            errorProvider1.SetError(txtDuration, errorMessage);
            btnOK.Enabled = timespanValid;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            closeAndSave();
        }

        private void closeAndSave()
        {
            // If OK clicked then save the data for use by main form
            // Note that worked time is already saved by the TryParseExact
            newWorkName = txtWorkName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void editForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnOK.Enabled)
                    closeAndSave();
        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            validateTimespan();
        }
    }
}
