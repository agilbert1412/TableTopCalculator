namespace TableTopCalculator.SecretHitler
{
    partial class PassPolicy
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblPresidentClaim = new System.Windows.Forms.Label();
            this.lblChancellorClaim = new System.Windows.Forms.Label();
            this.cboPres2 = new System.Windows.Forms.ComboBox();
            this.cboPres1 = new System.Windows.Forms.ComboBox();
            this.cboPres3 = new System.Windows.Forms.ComboBox();
            this.cboChanc1 = new System.Windows.Forms.ComboBox();
            this.cboChanc2 = new System.Windows.Forms.ComboBox();
            this.cboResult = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(143, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(256, 172);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 50);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblPresidentClaim
            // 
            this.lblPresidentClaim.AutoSize = true;
            this.lblPresidentClaim.Location = new System.Drawing.Point(19, 50);
            this.lblPresidentClaim.Name = "lblPresidentClaim";
            this.lblPresidentClaim.Size = new System.Drawing.Size(169, 13);
            this.lblPresidentClaim.TabIndex = 3;
            this.lblPresidentClaim.Text = "President claims to have received:";
            // 
            // lblChancellorClaim
            // 
            this.lblChancellorClaim.AutoSize = true;
            this.lblChancellorClaim.Location = new System.Drawing.Point(12, 76);
            this.lblChancellorClaim.Name = "lblChancellorClaim";
            this.lblChancellorClaim.Size = new System.Drawing.Size(176, 13);
            this.lblChancellorClaim.TabIndex = 5;
            this.lblChancellorClaim.Text = "Chancellor Claims to have received:";
            // 
            // cboPres2
            // 
            this.cboPres2.FormattingEnabled = true;
            this.cboPres2.Location = new System.Drawing.Point(249, 47);
            this.cboPres2.Name = "cboPres2";
            this.cboPres2.Size = new System.Drawing.Size(49, 21);
            this.cboPres2.TabIndex = 10;
            this.cboPres2.SelectedIndexChanged += new System.EventHandler(this.cboPres2_SelectedIndexChanged);
            // 
            // cboPres1
            // 
            this.cboPres1.FormattingEnabled = true;
            this.cboPres1.Location = new System.Drawing.Point(194, 47);
            this.cboPres1.Name = "cboPres1";
            this.cboPres1.Size = new System.Drawing.Size(49, 21);
            this.cboPres1.TabIndex = 11;
            // 
            // cboPres3
            // 
            this.cboPres3.FormattingEnabled = true;
            this.cboPres3.Location = new System.Drawing.Point(304, 47);
            this.cboPres3.Name = "cboPres3";
            this.cboPres3.Size = new System.Drawing.Size(49, 21);
            this.cboPres3.TabIndex = 12;
            this.cboPres3.SelectedIndexChanged += new System.EventHandler(this.cboPres3_SelectedIndexChanged);
            // 
            // cboChanc1
            // 
            this.cboChanc1.FormattingEnabled = true;
            this.cboChanc1.Location = new System.Drawing.Point(249, 73);
            this.cboChanc1.Name = "cboChanc1";
            this.cboChanc1.Size = new System.Drawing.Size(49, 21);
            this.cboChanc1.TabIndex = 13;
            // 
            // cboChanc2
            // 
            this.cboChanc2.FormattingEnabled = true;
            this.cboChanc2.Location = new System.Drawing.Point(304, 73);
            this.cboChanc2.Name = "cboChanc2";
            this.cboChanc2.Size = new System.Drawing.Size(49, 21);
            this.cboChanc2.TabIndex = 14;
            this.cboChanc2.SelectedIndexChanged += new System.EventHandler(this.cboChanc2_SelectedIndexChanged);
            // 
            // cboResult
            // 
            this.cboResult.FormattingEnabled = true;
            this.cboResult.Location = new System.Drawing.Point(304, 100);
            this.cboResult.Name = "cboResult";
            this.cboResult.Size = new System.Drawing.Size(49, 21);
            this.cboResult.TabIndex = 15;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(123, 103);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(65, 13);
            this.lblResult.TabIndex = 16;
            this.lblResult.Text = "Final Result:";
            // 
            // PassPolicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 242);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cboResult);
            this.Controls.Add(this.cboChanc2);
            this.Controls.Add(this.cboChanc1);
            this.Controls.Add(this.cboPres3);
            this.Controls.Add(this.cboPres1);
            this.Controls.Add(this.cboPres2);
            this.Controls.Add(this.lblChancellorClaim);
            this.Controls.Add(this.lblPresidentClaim);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "PassPolicy";
            this.Text = "PlayMission";
            this.Load += new System.EventHandler(this.PlayMission_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblPresidentClaim;
        private System.Windows.Forms.Label lblChancellorClaim;
        private System.Windows.Forms.ComboBox cboPres2;
        private System.Windows.Forms.ComboBox cboPres1;
        private System.Windows.Forms.ComboBox cboPres3;
        private System.Windows.Forms.ComboBox cboChanc1;
        private System.Windows.Forms.ComboBox cboChanc2;
        private System.Windows.Forms.ComboBox cboResult;
        private System.Windows.Forms.Label lblResult;
    }
}