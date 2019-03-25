using System;
using System.Windows.Forms;

namespace TableTopCalculator.Resistance.Forms
{
    public partial class PlayMission : Form
    {
        public int NbRedPlayed { get; set; }
        public int NbRedToFail { get; set; }

        public PlayMission()
        {
            InitializeComponent();
        }

        private void PlayMission_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            NbRedPlayed = (int)Math.Round(numRedPlayed.Value);
            NbRedToFail = (int)Math.Round(numRedRequired.Value);
            DialogResult = DialogResult.OK;
        }
    }
}
