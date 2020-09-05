namespace time_tracker_forms
{
    partial class aboutForm
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
            this.llFFF = new System.Windows.Forms.LinkLabel();
            this.llDitto = new System.Windows.Forms.LinkLabel();
            this.llGithub = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // llFFF
            // 
            this.llFFF.AutoSize = true;
            this.llFFF.LinkArea = new System.Windows.Forms.LinkArea(15, 9);
            this.llFFF.Location = new System.Drawing.Point(12, 43);
            this.llFFF.Name = "llFFF";
            this.llFFF.Size = new System.Drawing.Size(146, 17);
            this.llFFF.TabIndex = 1;
            this.llFFF.TabStop = true;
            this.llFFF.Text = "All icons from FamFamFam.";
            this.llFFF.UseCompatibleTextRendering = true;
            this.llFFF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFFF_LinkClicked);
            // 
            // llDitto
            // 
            this.llDitto.AutoSize = true;
            this.llDitto.LinkArea = new System.Windows.Forms.LinkArea(94, 99);
            this.llDitto.Location = new System.Drawing.Point(12, 9);
            this.llDitto.Name = "llDitto";
            this.llDitto.Size = new System.Drawing.Size(489, 17);
            this.llDitto.TabIndex = 1;
            this.llDitto.TabStop = true;
            this.llDitto.Text = "A simple time tracking tool with a minimal interface that borrows heavily from th" +
    "e UI cues of Ditto.";
            this.llDitto.UseCompatibleTextRendering = true;
            this.llDitto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDitto_LinkClicked);
            // 
            // llGithub
            // 
            this.llGithub.AutoSize = true;
            this.llGithub.LinkArea = new System.Windows.Forms.LinkArea(58, 6);
            this.llGithub.Location = new System.Drawing.Point(12, 26);
            this.llGithub.Name = "llGithub";
            this.llGithub.Size = new System.Drawing.Size(374, 17);
            this.llGithub.TabIndex = 1;
            this.llGithub.TabStop = true;
            this.llGithub.Text = "Documentation, code and bugs can be found on the projects Github page.";
            this.llGithub.UseCompatibleTextRendering = true;
            this.llGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGithub_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lazily hacked into existance by Leo Avitabile.";
            // 
            // aboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 87);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llDitto);
            this.Controls.Add(this.llGithub);
            this.Controls.Add(this.llFFF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "aboutForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel llFFF;
        private System.Windows.Forms.LinkLabel llDitto;
        private System.Windows.Forms.LinkLabel llGithub;
        private System.Windows.Forms.Label label1;
    }
}