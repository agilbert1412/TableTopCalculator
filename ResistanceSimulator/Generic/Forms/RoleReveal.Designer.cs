namespace TableTopCalculator.Generic
{
    partial class RoleReveal
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboWatcher = new System.Windows.Forms.ComboBox();
            this.lblWatcher = new System.Windows.Forms.Label();
            this.lblVictim = new System.Windows.Forms.Label();
            this.lblClaim = new System.Windows.Forms.Label();
            this.cboVictim = new System.Windows.Forms.ComboBox();
            this.cboClaim = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 180);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 50);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(30, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboWatcher
            // 
            this.cboWatcher.FormattingEnabled = true;
            this.cboWatcher.Location = new System.Drawing.Point(139, 39);
            this.cboWatcher.Name = "cboWatcher";
            this.cboWatcher.Size = new System.Drawing.Size(121, 21);
            this.cboWatcher.TabIndex = 4;
            // 
            // lblWatcher
            // 
            this.lblWatcher.AutoSize = true;
            this.lblWatcher.Location = new System.Drawing.Point(27, 42);
            this.lblWatcher.Name = "lblWatcher";
            this.lblWatcher.Size = new System.Drawing.Size(54, 13);
            this.lblWatcher.TabIndex = 5;
            this.lblWatcher.Text = "Watcher: ";
            // 
            // lblVictim
            // 
            this.lblVictim.AutoSize = true;
            this.lblVictim.Location = new System.Drawing.Point(27, 80);
            this.lblVictim.Name = "lblVictim";
            this.lblVictim.Size = new System.Drawing.Size(41, 13);
            this.lblVictim.TabIndex = 6;
            this.lblVictim.Text = "Victim: ";
            // 
            // lblClaim
            // 
            this.lblClaim.AutoSize = true;
            this.lblClaim.Location = new System.Drawing.Point(27, 118);
            this.lblClaim.Name = "lblClaim";
            this.lblClaim.Size = new System.Drawing.Size(38, 13);
            this.lblClaim.TabIndex = 7;
            this.lblClaim.Text = "Claim: ";
            // 
            // cboVictim
            // 
            this.cboVictim.FormattingEnabled = true;
            this.cboVictim.Location = new System.Drawing.Point(139, 77);
            this.cboVictim.Name = "cboVictim";
            this.cboVictim.Size = new System.Drawing.Size(121, 21);
            this.cboVictim.TabIndex = 8;
            // 
            // cboClaim
            // 
            this.cboClaim.FormattingEnabled = true;
            this.cboClaim.Location = new System.Drawing.Point(139, 115);
            this.cboClaim.Name = "cboClaim";
            this.cboClaim.Size = new System.Drawing.Size(121, 21);
            this.cboClaim.TabIndex = 9;
            // 
            // RoleReveal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 242);
            this.Controls.Add(this.cboClaim);
            this.Controls.Add(this.cboVictim);
            this.Controls.Add(this.lblClaim);
            this.Controls.Add(this.lblVictim);
            this.Controls.Add(this.lblWatcher);
            this.Controls.Add(this.cboWatcher);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "RoleReveal";
            this.Text = "RoleReveal";
            this.Load += new System.EventHandler(this.RoleReveal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboWatcher;
        private System.Windows.Forms.Label lblWatcher;
        private System.Windows.Forms.Label lblVictim;
        private System.Windows.Forms.Label lblClaim;
        private System.Windows.Forms.ComboBox cboVictim;
        private System.Windows.Forms.ComboBox cboClaim;
    }
}