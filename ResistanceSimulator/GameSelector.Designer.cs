namespace TableTopCalculator
{
    partial class GameSelector
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
            this.btnResistance = new System.Windows.Forms.Button();
            this.btnSecretHitler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResistance
            // 
            this.btnResistance.Location = new System.Drawing.Point(49, 37);
            this.btnResistance.Name = "btnResistance";
            this.btnResistance.Size = new System.Drawing.Size(100, 50);
            this.btnResistance.TabIndex = 0;
            this.btnResistance.Text = "The Resistance";
            this.btnResistance.UseVisualStyleBackColor = true;
            this.btnResistance.Click += new System.EventHandler(this.btnResistance_Click);
            // 
            // btnSecretHitler
            // 
            this.btnSecretHitler.Location = new System.Drawing.Point(49, 108);
            this.btnSecretHitler.Name = "btnSecretHitler";
            this.btnSecretHitler.Size = new System.Drawing.Size(100, 50);
            this.btnSecretHitler.TabIndex = 1;
            this.btnSecretHitler.Text = "Secret Hitler";
            this.btnSecretHitler.UseVisualStyleBackColor = true;
            this.btnSecretHitler.Click += new System.EventHandler(this.btnSecretHitler_Click);
            // 
            // GameSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 201);
            this.Controls.Add(this.btnSecretHitler);
            this.Controls.Add(this.btnResistance);
            this.Name = "GameSelector";
            this.Text = "GameSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResistance;
        private System.Windows.Forms.Button btnSecretHitler;
    }
}