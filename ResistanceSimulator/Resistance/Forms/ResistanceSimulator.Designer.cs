namespace TableTopCalculator.Resistance.Forms
{
    partial class ResistanceSimulator
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
            this.btnPlayMission = new System.Windows.Forms.Button();
            this.btnRoleReveal = new System.Windows.Forms.Button();
            this.btnMissionCardReveal = new System.Windows.Forms.Button();
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
            // btnPlayMission
            // 
            this.btnPlayMission.Location = new System.Drawing.Point(260, 350);
            this.btnPlayMission.Name = "btnPlayMission";
            this.btnPlayMission.Size = new System.Drawing.Size(100, 50);
            this.btnPlayMission.TabIndex = 1;
            this.btnPlayMission.Text = "Play Mission";
            this.btnPlayMission.UseVisualStyleBackColor = true;
            this.btnPlayMission.Click += new System.EventHandler(this.btnPlayMission_Click);
            // 
            // btnRoleReveal
            // 
            this.btnRoleReveal.Location = new System.Drawing.Point(440, 350);
            this.btnRoleReveal.Name = "btnRoleReveal";
            this.btnRoleReveal.Size = new System.Drawing.Size(100, 50);
            this.btnRoleReveal.TabIndex = 2;
            this.btnRoleReveal.Text = "Role Reveal";
            this.btnRoleReveal.UseVisualStyleBackColor = true;
            this.btnRoleReveal.Click += new System.EventHandler(this.btnRoleReveal_Click);
            // 
            // btnMissionCardReveal
            // 
            this.btnMissionCardReveal.Location = new System.Drawing.Point(620, 350);
            this.btnMissionCardReveal.Name = "btnMissionCardReveal";
            this.btnMissionCardReveal.Size = new System.Drawing.Size(100, 50);
            this.btnMissionCardReveal.TabIndex = 3;
            this.btnMissionCardReveal.Text = "Mission Card Reveal";
            this.btnMissionCardReveal.UseVisualStyleBackColor = true;
            this.btnMissionCardReveal.Click += new System.EventHandler(this.btnMissionCardReveal_Click);
            // 
            // ResistanceSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnMissionCardReveal);
            this.Controls.Add(this.btnRoleReveal);
            this.Controls.Add(this.btnPlayMission);
            this.Controls.Add(this.btnStartStop);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "ResistanceSimulator";
            this.Text = "Resistance Simulator";
            this.Load += new System.EventHandler(this.ResistanceSimulator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ResistanceSimulator_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ResistanceSimulator_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResistanceSimulator_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResistanceSimulator_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResistanceSimulator_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnPlayMission;
        private System.Windows.Forms.Button btnRoleReveal;
        private System.Windows.Forms.Button btnMissionCardReveal;
    }
}

