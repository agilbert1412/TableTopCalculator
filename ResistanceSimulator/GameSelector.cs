using System;
using System.Windows.Forms;
using TableTopCalculator.Resistance.Forms;
using TableTopCalculator.SecretHitler.Forms;

namespace TableTopCalculator
{
    public partial class GameSelector : Form
    {
        public GameSelector()
        {
            InitializeComponent();
        }

        private void btnResistance_Click(object sender, EventArgs e)
        {
            Hide();
            var resistanceSimulator = new ResistanceSimulator();
            resistanceSimulator.ShowDialog();
            Close();
        }

        private void btnSecretHitler_Click(object sender, EventArgs e)
        {
            Hide();
            var secretHitlerSimulator = new SecretHitlerSimulator();
            secretHitlerSimulator.ShowDialog();
            Close();
        }
    }
}
