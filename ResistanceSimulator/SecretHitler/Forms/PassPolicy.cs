using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TableTopCalculator.SecretHitler.Forms
{
    public partial class PassPolicy : Form
    {
        public KeyValuePair<Player, List<SecretHitlerRole>> President { get; set; }
        public KeyValuePair<Player, List<SecretHitlerRole>> Chancellor { get; set; }
        public SecretHitlerRole Result { get; set; }

        public PassPolicy(Player president, Player chancellor)
        {
            InitializeComponent();

            President = new KeyValuePair<Player, List<SecretHitlerRole>>(president, new List<SecretHitlerRole>());
            Chancellor = new KeyValuePair<Player, List<SecretHitlerRole>>(chancellor, new List<SecretHitlerRole>());

            foreach (var cbo in Controls.OfType<ComboBox>())
            {
                cbo.Items.Add("Blue");
                cbo.Items.Add("Red");
                cbo.SelectedIndex = 1;
            }

            cboResult.Enabled = false;
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
            President.Value.Add((SecretHitlerRole)cboPres1.SelectedIndex);
            President.Value.Add((SecretHitlerRole)cboPres2.SelectedIndex);
            President.Value.Add((SecretHitlerRole)cboPres3.SelectedIndex);

            Chancellor.Value.Add((SecretHitlerRole)cboChanc1.SelectedIndex);
            Chancellor.Value.Add((SecretHitlerRole)cboChanc2.SelectedIndex);

            Result = (SecretHitlerRole)cboResult.SelectedIndex;

            DialogResult = DialogResult.OK;
        }

        private void cboPres2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboChanc1.SelectedIndex = cboPres2.SelectedIndex;
        }

        private void cboPres3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboChanc2.SelectedIndex = cboPres3.SelectedIndex;
        }

        private void cboChancellor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboResult.SelectedIndex = cboChanc2.SelectedIndex;
        }
    }
}
