namespace TableTopCalculator.SecretHitler
{
    partial class SecretHitlerSimulator
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnElectionPassed = new System.Windows.Forms.Button();
            this.btnAllegianceReveal = new System.Windows.Forms.Button();
            this.btnNotHitler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(80, 350);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(100, 50);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start Game";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnElectionPassed
            // 
            this.btnElectionPassed.Location = new System.Drawing.Point(260, 350);
            this.btnElectionPassed.Name = "btnElectionPassed";
            this.btnElectionPassed.Size = new System.Drawing.Size(100, 50);
            this.btnElectionPassed.TabIndex = 1;
            this.btnElectionPassed.Text = "Election";
            this.btnElectionPassed.UseVisualStyleBackColor = true;
            this.btnElectionPassed.Click += new System.EventHandler(this.btnPlayMission_Click);
            // 
            // btnAllegianceReveal
            // 
            this.btnAllegianceReveal.Location = new System.Drawing.Point(440, 350);
            this.btnAllegianceReveal.Name = "btnAllegianceReveal";
            this.btnAllegianceReveal.Size = new System.Drawing.Size(100, 50);
            this.btnAllegianceReveal.TabIndex = 2;
            this.btnAllegianceReveal.Text = "Allegiance Reveal";
            this.btnAllegianceReveal.UseVisualStyleBackColor = true;
            this.btnAllegianceReveal.Click += new System.EventHandler(this.btnRoleReveal_Click);
            // 
            // btnNotHitler
            // 
            this.btnNotHitler.Location = new System.Drawing.Point(620, 350);
            this.btnNotHitler.Name = "btnNotHitler";
            this.btnNotHitler.Size = new System.Drawing.Size(100, 50);
            this.btnNotHitler.TabIndex = 3;
            this.btnNotHitler.Text = "Not Hitler";
            this.btnNotHitler.UseVisualStyleBackColor = true;
            this.btnNotHitler.Click += new System.EventHandler(this.btnNotHitler_Click);
            // 
            // SecretHitlerSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnNotHitler);
            this.Controls.Add(this.btnAllegianceReveal);
            this.Controls.Add(this.btnElectionPassed);
            this.Controls.Add(this.btnStartStop);
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "SecretHitlerSimulator";
            this.Text = "SecretHitler Simulator";
            this.Load += new System.EventHandler(this.SecretHitlerSimulator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SecretHitlerSimulator_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SecretHitlerSimulator_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnElectionPassed;
        private System.Windows.Forms.Button btnAllegianceReveal;
        private System.Windows.Forms.Button btnNotHitler;
    }
}

