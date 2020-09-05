namespace time_tracker_forms
{
    partial class options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChooseAliasesFilePath = new System.Windows.Forms.Button();
            this.txtAliasesPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseQuickInsertFilePath = new System.Windows.Forms.Button();
            this.btnChooseWorkRecordFilePath = new System.Windows.Forms.Button();
            this.txtWorkRecordPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuickInsertPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.workRecordOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.quickInsertOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.aliasesOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cbMinimiseAfterEnter = new System.Windows.Forms.CheckBox();
            this.cbPauseWhenLocked = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cbMinimiseAfterEnter);
            this.groupBox2.Controls.Add(this.cbPauseWhenLocked);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Behaviour";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnChooseAliasesFilePath);
            this.groupBox3.Controls.Add(this.txtAliasesPath);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnChooseQuickInsertFilePath);
            this.groupBox3.Controls.Add(this.btnChooseWorkRecordFilePath);
            this.groupBox3.Controls.Add(this.txtWorkRecordPath);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtQuickInsertPath);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(265, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 115);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paths";
            // 
            // btnChooseAliasesFilePath
            // 
            this.btnChooseAliasesFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseAliasesFilePath.Image = global::time_tracker_forms.Properties.Resources.folder;
            this.btnChooseAliasesFilePath.Location = new System.Drawing.Point(554, 82);
            this.btnChooseAliasesFilePath.Name = "btnChooseAliasesFilePath";
            this.btnChooseAliasesFilePath.Size = new System.Drawing.Size(33, 23);
            this.btnChooseAliasesFilePath.TabIndex = 7;
            this.btnChooseAliasesFilePath.UseVisualStyleBackColor = true;
            this.btnChooseAliasesFilePath.Click += new System.EventHandler(this.btnChooseAliasesFilePath_Click);
            // 
            // txtAliasesPath
            // 
            this.txtAliasesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAliasesPath.Enabled = false;
            this.txtAliasesPath.Location = new System.Drawing.Point(111, 84);
            this.txtAliasesPath.Name = "txtAliasesPath";
            this.txtAliasesPath.Size = new System.Drawing.Size(437, 20);
            this.txtAliasesPath.TabIndex = 6;
            this.txtAliasesPath.Text = "aliases.xml";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Aliases Path:";
            // 
            // btnChooseQuickInsertFilePath
            // 
            this.btnChooseQuickInsertFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseQuickInsertFilePath.Image = global::time_tracker_forms.Properties.Resources.folder;
            this.btnChooseQuickInsertFilePath.Location = new System.Drawing.Point(554, 49);
            this.btnChooseQuickInsertFilePath.Name = "btnChooseQuickInsertFilePath";
            this.btnChooseQuickInsertFilePath.Size = new System.Drawing.Size(33, 23);
            this.btnChooseQuickInsertFilePath.TabIndex = 4;
            this.btnChooseQuickInsertFilePath.UseVisualStyleBackColor = true;
            this.btnChooseQuickInsertFilePath.Click += new System.EventHandler(this.btnChooseQuickInsertFilePath_Click);
            // 
            // btnChooseWorkRecordFilePath
            // 
            this.btnChooseWorkRecordFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseWorkRecordFilePath.Image = global::time_tracker_forms.Properties.Resources.folder;
            this.btnChooseWorkRecordFilePath.Location = new System.Drawing.Point(554, 15);
            this.btnChooseWorkRecordFilePath.Name = "btnChooseWorkRecordFilePath";
            this.btnChooseWorkRecordFilePath.Size = new System.Drawing.Size(33, 23);
            this.btnChooseWorkRecordFilePath.TabIndex = 4;
            this.btnChooseWorkRecordFilePath.UseVisualStyleBackColor = true;
            this.btnChooseWorkRecordFilePath.Click += new System.EventHandler(this.btnChooseWorkRecordFilePath_Click);
            // 
            // txtWorkRecordPath
            // 
            this.txtWorkRecordPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkRecordPath.Enabled = false;
            this.txtWorkRecordPath.Location = new System.Drawing.Point(111, 17);
            this.txtWorkRecordPath.Name = "txtWorkRecordPath";
            this.txtWorkRecordPath.Size = new System.Drawing.Size(437, 20);
            this.txtWorkRecordPath.TabIndex = 3;
            this.txtWorkRecordPath.Text = "out.xml";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Work Record Path:";
            // 
            // txtQuickInsertPath
            // 
            this.txtQuickInsertPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuickInsertPath.Enabled = false;
            this.txtQuickInsertPath.Location = new System.Drawing.Point(111, 51);
            this.txtQuickInsertPath.Name = "txtQuickInsertPath";
            this.txtQuickInsertPath.Size = new System.Drawing.Size(437, 20);
            this.txtQuickInsertPath.TabIndex = 1;
            this.txtQuickInsertPath.Text = "quickInserts.xml";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quick Insert Path:";
            // 
            // workRecordOpenFileDialog
            // 
            this.workRecordOpenFileDialog.CheckFileExists = false;
            this.workRecordOpenFileDialog.DefaultExt = "xml";
            this.workRecordOpenFileDialog.FileName = "out.xml";
            // 
            // quickInsertOpenFileDialog
            // 
            this.quickInsertOpenFileDialog.CheckFileExists = false;
            this.quickInsertOpenFileDialog.DefaultExt = "xml";
            this.quickInsertOpenFileDialog.FileName = "quickInserts.xml";
            // 
            // aliasesOpenFileDialog
            // 
            this.aliasesOpenFileDialog.CheckFileExists = false;
            this.aliasesOpenFileDialog.DefaultExt = "xml";
            this.aliasesOpenFileDialog.FileName = "aliases.xml";
            // 
            // cbMinimiseAfterEnter
            // 
            this.cbMinimiseAfterEnter.AutoSize = true;
            this.cbMinimiseAfterEnter.Checked = global::time_tracker_forms.Properties.Settings.Default.MinimiseAfterEnter;
            this.cbMinimiseAfterEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMinimiseAfterEnter.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::time_tracker_forms.Properties.Settings.Default, "MinimiseAfterEnter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbMinimiseAfterEnter.Location = new System.Drawing.Point(6, 42);
            this.cbMinimiseAfterEnter.Name = "cbMinimiseAfterEnter";
            this.cbMinimiseAfterEnter.Size = new System.Drawing.Size(217, 17);
            this.cbMinimiseAfterEnter.TabIndex = 5;
            this.cbMinimiseAfterEnter.Text = "Minimise to Tray After Enter Key Pressed";
            this.cbMinimiseAfterEnter.UseVisualStyleBackColor = true;
            // 
            // cbPauseWhenLocked
            // 
            this.cbPauseWhenLocked.AutoSize = true;
            this.cbPauseWhenLocked.Checked = global::time_tracker_forms.Properties.Settings.Default.PauseWhenLocked;
            this.cbPauseWhenLocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPauseWhenLocked.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::time_tracker_forms.Properties.Settings.Default, "PauseWhenLocked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbPauseWhenLocked.Location = new System.Drawing.Point(6, 19);
            this.cbPauseWhenLocked.Name = "cbPauseWhenLocked";
            this.cbPauseWhenLocked.Size = new System.Drawing.Size(183, 17);
            this.cbPauseWhenLocked.TabIndex = 4;
            this.cbPauseWhenLocked.Text = "Pause Timer When PC is Locked";
            this.cbPauseWhenLocked.UseVisualStyleBackColor = true;
            // 
            // options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 135);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "options";
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.options_FormClosed);
            this.Load += new System.EventHandler(this.options_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbPauseWhenLocked;
        private System.Windows.Forms.Button btnChooseQuickInsertFilePath;
        private System.Windows.Forms.Button btnChooseWorkRecordFilePath;
        private System.Windows.Forms.TextBox txtWorkRecordPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuickInsertPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseAliasesFilePath;
        private System.Windows.Forms.TextBox txtAliasesPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog workRecordOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog quickInsertOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog aliasesOpenFileDialog;
        private System.Windows.Forms.CheckBox cbMinimiseAfterEnter;
    }
}