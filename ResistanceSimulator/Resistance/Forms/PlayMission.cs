using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableTopCalculator.Resistance
{
    public partial class PlayMission : Form
    {
        public int NbRedPlayed { get; set; }
        public int NbRedToFail { get; set; }

        public PlayMission(List<Player> players)
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
