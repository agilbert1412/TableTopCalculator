using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableTopCalculator.Resistance;
using TableTopCalculator.SecretHitler;

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
            this.Hide();
            (new ResistanceSimulator()).ShowDialog();
            this.Close();
        }

        private void btnSecretHitler_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new SecretHitlerSimulator()).ShowDialog();
            this.Close();
        }
    }
}
