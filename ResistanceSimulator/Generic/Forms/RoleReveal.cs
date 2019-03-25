using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TableTopCalculator.Generic.Forms
{
    public partial class RoleReveal : Form
    {
        public int WatcherIndex { get; set; }
        public int VictimIndex { get; set; }
        public ResistanceRole Claim { get; set; }

        public RoleReveal(IReadOnlyList<Player> players)
        {
            InitializeComponent();

            cboWatcher.Items.Clear();
            cboVictim.Items.Clear();
            cboClaim.Items.Clear();

            for (var i = 0; i < players.Count; i++)
            {
                cboWatcher.Items.Add("[" + i + "]" + players[i].Name);
                cboVictim.Items.Add("[" + i + "]" + players[i].Name);
            }

            cboClaim.Items.Add("Blue");
            cboClaim.Items.Add("Red");

            cboWatcher.SelectedIndex = 0;
            cboVictim.SelectedIndex = 1;
            cboClaim.SelectedIndex = 0;
        }

        private void RoleReveal_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WatcherIndex = cboWatcher.SelectedIndex;
            VictimIndex = cboVictim.SelectedIndex;
            Claim = (ResistanceRole)cboClaim.SelectedIndex;

            if (WatcherIndex != VictimIndex)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
