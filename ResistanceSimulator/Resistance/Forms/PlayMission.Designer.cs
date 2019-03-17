namespace TableTopCalculator.Resistance
{
    partial class PlayMission
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
            this.numRedRequired = new System.Windows.Forms.NumericUpDown();
            this.lblNumRedToFail = new System.Windows.Forms.Label();
            this.lblNbRedPlayed = new System.Windows.Forms.Label();
            this.numRedPlayed = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numRedRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRedPlayed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(30, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(160, 172);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 50);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // numRedRequired
            // 
            this.numRedRequired.Location = new System.Drawing.Point(226, 48);
            this.numRedRequired.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numRedRequired.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRedRequired.Name = "numRedRequired";
            this.numRedRequired.Size = new System.Drawing.Size(34, 20);
            this.numRedRequired.TabIndex = 2;
            this.numRedRequired.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumRedToFail
            // 
            this.lblNumRedToFail.AutoSize = true;
            this.lblNumRedToFail.Location = new System.Drawing.Point(30, 50);
            this.lblNumRedToFail.Name = "lblNumRedToFail";
            this.lblNumRedToFail.Size = new System.Drawing.Size(151, 13);
            this.lblNumRedToFail.TabIndex = 3;
            this.lblNumRedToFail.Text = "Number of reds required to fail:";
            // 
            // lblNbRedPlayed
            // 
            this.lblNbRedPlayed.AutoSize = true;
            this.lblNbRedPlayed.Location = new System.Drawing.Point(30, 106);
            this.lblNbRedPlayed.Name = "lblNbRedPlayed";
            this.lblNbRedPlayed.Size = new System.Drawing.Size(116, 13);
            this.lblNbRedPlayed.TabIndex = 5;
            this.lblNbRedPlayed.Text = "Number of reds played:";
            // 
            // numRedPlayed
            // 
            this.numRedPlayed.Location = new System.Drawing.Point(226, 104);
            this.numRedPlayed.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRedPlayed.Name = "numRedPlayed";
            this.numRedPlayed.Size = new System.Drawing.Size(34, 20);
            this.numRedPlayed.TabIndex = 4;
            // 
            // PlayMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 242);
            this.Controls.Add(this.lblNbRedPlayed);
            this.Controls.Add(this.numRedPlayed);
            this.Controls.Add(this.lblNumRedToFail);
            this.Controls.Add(this.numRedRequired);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "PlayMission";
            this.Text = "PlayMission";
            this.Load += new System.EventHandler(this.PlayMission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRedRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRedPlayed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numRedRequired;
        private System.Windows.Forms.Label lblNumRedToFail;
        private System.Windows.Forms.Label lblNbRedPlayed;
        private System.Windows.Forms.NumericUpDown numRedPlayed;
    }
}