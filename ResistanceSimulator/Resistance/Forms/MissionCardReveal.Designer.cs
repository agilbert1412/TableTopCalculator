namespace TableTopCalculator.Resistance.Forms
{
    partial class MissionCardReveal
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
            this.cboClaim = new System.Windows.Forms.ComboBox();
            this.cboVictim = new System.Windows.Forms.ComboBox();
            this.lblClaim = new System.Windows.Forms.Label();
            this.lblVictim = new System.Windows.Forms.Label();
            this.lblWatcher = new System.Windows.Forms.Label();
            this.cboWatcher = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboMission = new System.Windows.Forms.ComboBox();
            this.lblMission = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboClaim
            // 
            this.cboClaim.FormattingEnabled = true;
            this.cboClaim.Location = new System.Drawing.Point(138, 139);
            this.cboClaim.Name = "cboClaim";
            this.cboClaim.Size = new System.Drawing.Size(121, 21);
            this.cboClaim.TabIndex = 17;
            // 
            // cboVictim
            // 
            this.cboVictim.FormattingEnabled = true;
            this.cboVictim.Location = new System.Drawing.Point(138, 101);
            this.cboVictim.Name = "cboVictim";
            this.cboVictim.Size = new System.Drawing.Size(121, 21);
            this.cboVictim.TabIndex = 16;
            // 
            // lblClaim
            // 
            this.lblClaim.AutoSize = true;
            this.lblClaim.Location = new System.Drawing.Point(26, 142);
            this.lblClaim.Name = "lblClaim";
            this.lblClaim.Size = new System.Drawing.Size(38, 13);
            this.lblClaim.TabIndex = 15;
            this.lblClaim.Text = "Claim: ";
            // 
            // lblVictim
            // 
            this.lblVictim.AutoSize = true;
            this.lblVictim.Location = new System.Drawing.Point(26, 104);
            this.lblVictim.Name = "lblVictim";
            this.lblVictim.Size = new System.Drawing.Size(41, 13);
            this.lblVictim.TabIndex = 14;
            this.lblVictim.Text = "Victim: ";
            // 
            // lblWatcher
            // 
            this.lblWatcher.AutoSize = true;
            this.lblWatcher.Location = new System.Drawing.Point(26, 66);
            this.lblWatcher.Name = "lblWatcher";
            this.lblWatcher.Size = new System.Drawing.Size(54, 13);
            this.lblWatcher.TabIndex = 13;
            this.lblWatcher.Text = "Watcher: ";
            // 
            // cboWatcher
            // 
            this.cboWatcher.FormattingEnabled = true;
            this.cboWatcher.Location = new System.Drawing.Point(138, 63);
            this.cboWatcher.Name = "cboWatcher";
            this.cboWatcher.Size = new System.Drawing.Size(121, 21);
            this.cboWatcher.TabIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(159, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 50);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(29, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboMission
            // 
            this.cboMission.FormattingEnabled = true;
            this.cboMission.Location = new System.Drawing.Point(138, 21);
            this.cboMission.Name = "cboMission";
            this.cboMission.Size = new System.Drawing.Size(121, 21);
            this.cboMission.TabIndex = 19;
            // 
            // lblMission
            // 
            this.lblMission.AutoSize = true;
            this.lblMission.Location = new System.Drawing.Point(26, 24);
            this.lblMission.Name = "lblMission";
            this.lblMission.Size = new System.Drawing.Size(48, 13);
            this.lblMission.TabIndex = 18;
            this.lblMission.Text = "Mission: ";
            // 
            // MissionCardReveal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 265);
            this.Controls.Add(this.cboMission);
            this.Controls.Add(this.lblMission);
            this.Controls.Add(this.cboClaim);
            this.Controls.Add(this.cboVictim);
            this.Controls.Add(this.lblClaim);
            this.Controls.Add(this.lblVictim);
            this.Controls.Add(this.lblWatcher);
            this.Controls.Add(this.cboWatcher);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "MissionCardReveal";
            this.Text = "MissionCardReveal";
            this.Load += new System.EventHandler(this.MissionCardReveal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboClaim;
        private System.Windows.Forms.ComboBox cboVictim;
        private System.Windows.Forms.Label lblClaim;
        private System.Windows.Forms.Label lblVictim;
        private System.Windows.Forms.Label lblWatcher;
        private System.Windows.Forms.ComboBox cboWatcher;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboMission;
        private System.Windows.Forms.Label lblMission;
    }
}