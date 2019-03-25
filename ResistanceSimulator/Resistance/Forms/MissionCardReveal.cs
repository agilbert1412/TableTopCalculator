using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TableTopCalculator.Resistance.Info;

namespace TableTopCalculator.Resistance.Forms
{
    public partial class MissionCardReveal : Form
    {
        public int MissionIndex { get; set; }
        public int WatcherIndex { get; set; }
        public int VictimIndex { get; set; }
        public ResistanceRole Claim { get; set; }

        public MissionCardReveal(IReadOnlyList<Player> players, IReadOnlyList<Mission> missions)
        {
            InitializeComponent();

            cboMission.Items.Clear();
            cboWatcher.Items.Clear();
            cboVictim.Items.Clear();
            cboClaim.Items.Clear();

            for (var i = 0; i < missions.Count; i++)
            {
                cboMission.Items.Add((i == missions.Count - 1 ? "LATEST" : (i + 1).ToString()) + "(" + (missions[i].Result.Count(x => x == ResistanceRole.Red) < missions[i].MinRedToFail ? "SUCCESS" : "FAIL") + ")");
            }

            cboWatcher.Items.Add("Everyone");
            for (var i = 0; i < players.Count; i++)
            {
                cboWatcher.Items.Add("[" + i + "]" + players[i].Name);
                cboVictim.Items.Add("[" + i + "]" + players[i].Name);
            }

            cboClaim.Items.Add("Blue");
            cboClaim.Items.Add("Red");

            cboMission.SelectedIndex = missions.Count - 1;
            cboWatcher.SelectedIndex = 0;
            cboVictim.SelectedIndex = 1;
            cboClaim.SelectedIndex = 0;
        }

        private void MissionCardReveal_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MissionIndex = cboMission.SelectedIndex;
            WatcherIndex = cboWatcher.SelectedIndex - 1;
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
