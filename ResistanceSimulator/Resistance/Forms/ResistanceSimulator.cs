using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableTopCalculator.Generic;

namespace TableTopCalculator.Resistance
{
    public partial class ResistanceSimulator : Form
    {
        Game currentGame;

        Player[] CurrentPlayers = new Player[10];

        List<int> selectedPlayers = new List<int>();

        Brush COLOR_CLOSED = Brushes.DimGray;
        Brush COLOR_OPEN = Brushes.Silver;

        Color COLOR_RED = Color.FromArgb(255, 255, 0, 0);
        Color COLOR_BLUE = Color.FromArgb(255, 0, 128, 255);

        int HoveredPlayer = -1;

        public ResistanceSimulator()
        {
            InitializeComponent();
        }

        private void ResistanceSimulator_Load(object sender, EventArgs e)
        {
            currentGame = null;
            for (int i = 0; i < 9; i++)
            {
                CurrentPlayers[i] = null;
            }

            btnStartStop.Enabled = false;
            btnPlayMission.Enabled = false;
            btnMissionCardReveal.Enabled = false;
            btnRoleReveal.Enabled = false;
        }

        private void ResistanceSimulator_Paint(object sender, PaintEventArgs e)
        {
            var gfx = e.Graphics;
            for (var i = 0; i < 10; i++)
            {
                DrawPlayer(gfx, i);
            }
            if (currentGame != null)
            {
                for (var i = 0; i < currentGame.AllInformation.Count; i++)
                {
                    var info = currentGame.AllInformation[i];
                    info.DrawInfo(gfx);
                }
            }
        }

        private void DrawPlayer(Graphics gfx, int playerIndex)
        {
            if (playerIndex < 0 || playerIndex > 9)
                return;

            var square = GetPlayerSquare(playerIndex);

            var locationName = new Point(square.X + 10, square.Y + 70);
            var locationPercent = new Point(square.X + 10, square.Y + 10);
            var font = new Font(DefaultFont.FontFamily, 10, FontStyle.Bold);

            if (CurrentPlayers[playerIndex] != null)
            {
                if (currentGame != null)
                {
                    var chanceOfRed = currentGame.GetChanceOfRole(CurrentPlayers[playerIndex], (int)ResistanceRole.Red);

                    if (MouseButtons == MouseButtons.Right && HoveredPlayer > -1 && CurrentPlayers[HoveredPlayer] != null)
                    {
                        chanceOfRed = currentGame.GetChanceOfRole(CurrentPlayers[playerIndex], (int)ResistanceRole.Red, CurrentPlayers[HoveredPlayer]);
                    }

                    var color = GetPlayerColor(chanceOfRed);
                    gfx.FillRectangle(new SolidBrush(color), square);
                    gfx.DrawString(Math.Round(chanceOfRed * 100) + "%", font, Brushes.Black, locationPercent);
                }
                else
                {
                    gfx.FillRectangle(new SolidBrush(GetPlayerColor(0)), square);
                }
                gfx.DrawString(CurrentPlayers[playerIndex].Name, font, Brushes.Black, locationName);
                if (selectedPlayers.Contains(playerIndex))
                {
                    gfx.DrawRectangle(new Pen(Color.LightGreen, 4), square);
                }
            }
            else
            {
                if (currentGame != null)
                {
                    gfx.FillRectangle(COLOR_CLOSED, square);
                    gfx.DrawString("Closed", font, Brushes.Black, locationName);
                }
                else
                {

                    gfx.FillRectangle(COLOR_OPEN, square);
                    gfx.DrawString("Open", font, Brushes.Black, locationName);
                }
            }
        }

        internal static Rectangle GetPlayerSquare(int index)
        {
            var xOffset = ((index % 5) * 150) + 50;
            var yOffset = ((index / 5) * 150) + 50;

            var length = 100;

            return new Rectangle(xOffset, yOffset, length, length);
        }

        private void ResistanceSimulator_MouseClick(object sender, MouseEventArgs e)
        {
            var clickedPlayer = -1;
            for (var i = 0; i < 10; i++)
            {
                var square = GetPlayerSquare(i);
                if (square.Contains(e.X, e.Y))
                {
                    clickedPlayer = i;
                    break;
                }
            }

            if (clickedPlayer > -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (currentGame == null)
                    {
                        if (CurrentPlayers[clickedPlayer] == null)
                        {
                            // Show New Player Form

                            var name = Interaction.InputBox("What is the name of this player?", "Name Player", "");

                            CurrentPlayers[clickedPlayer] = new Player(clickedPlayer, name);
                        }
                        else
                        {
                            CurrentPlayers[clickedPlayer] = null;
                        }
                        btnStartStop.Enabled = CurrentPlayers.Count(x => x != null) > 4;
                    }
                    else
                    {
                        if (CurrentPlayers[clickedPlayer] != null)
                        {
                            if (selectedPlayers.Contains(clickedPlayer))
                            {
                                selectedPlayers.Remove(clickedPlayer);
                            }
                            else
                            {
                                selectedPlayers.Add(clickedPlayer);
                            }
                        }
                        btnStartStop.Enabled = true;
                    }
                }
            }
            Refresh();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (currentGame != null)
            {
                currentGame = null;

                btnStartStop.Text = "Start Game";
                btnPlayMission.Enabled = false;
                btnMissionCardReveal.Enabled = false;
                btnRoleReveal.Enabled = false;
            }
            else
            {
                currentGame = new Game(CurrentPlayers.ToList(), GameType.Resistance);
                currentGame.StartGame();

                btnStartStop.Text = "Stop Game";
                btnPlayMission.Enabled = true;
                btnMissionCardReveal.Enabled = true;
                btnRoleReveal.Enabled = true;
            }
            Refresh();
        }

        private void btnPlayMission_Click(object sender, EventArgs e)
        {
            var playersInMission = new List<Player>();
            foreach (var selected in selectedPlayers)
            {
                if (CurrentPlayers[selected] != null)
                {
                    playersInMission.Add(CurrentPlayers[selected]);
                }
            }

            var frmMission = new PlayMission(playersInMission);
            if (frmMission.ShowDialog() == DialogResult.OK)
            {
                var result = new List<ResistanceRole>();
                for (var i = 0; i < frmMission.NbRedPlayed; i++)
                {
                    result.Add(ResistanceRole.Red);
                }
                while (result.Count < playersInMission.Count)
                {
                    result.Add(ResistanceRole.Blue);
                }
                var missionInfo = new Mission(currentGame.AllInformation.Count(x => x is Mission), playersInMission, result, frmMission.NbRedToFail);
                currentGame.NewInformation(missionInfo);

                selectedPlayers.Clear();
                Refresh();
            }
        }

        private void btnRoleReveal_Click(object sender, EventArgs e)
        {
            var playersInGame = new List<Player>();
            //currentGame.AllInformation.RemoveAt(currentGame.AllInformation.Count - 1);
            playersInGame.AddRange(CurrentPlayers.Where(x => x != null));

            var frmSeenRole = new RoleReveal(playersInGame);
            if (frmSeenRole.ShowDialog() == DialogResult.OK)
            {
                var missionInfo = new SeenRole(playersInGame[frmSeenRole.WatcherIndex], playersInGame[frmSeenRole.VictimIndex], frmSeenRole.Claim);
                currentGame.NewInformation(missionInfo);

                selectedPlayers.Clear();
                Refresh();
            }
        }

        private void btnMissionCardReveal_Click(object sender, EventArgs e)
        {
            var playersInGame = new List<Player>();
            playersInGame.AddRange(CurrentPlayers.Where(x => x != null));
            var missionsPlayed = currentGame.AllInformation.OfType<Mission>().ToList();

            //var lastInfo = currentGame.AllInformation.Last();
            //currentGame.AllInformation.RemoveAt(currentGame.AllInformation.Count - 1);
            //currentGame.NewInformation(lastInfo);

            var frmSeenCard = new MissionCardReveal(playersInGame, missionsPlayed);
            if (frmSeenCard.ShowDialog() == DialogResult.OK)
            {
                if (frmSeenCard.WatcherIndex == -1)
                {
                    var missionInfo = new ShownMissionCard(playersInGame[frmSeenCard.VictimIndex], frmSeenCard.Claim);
                    currentGame.NewInformation(missionInfo);
                }
                else
                {
                    var missionInfo = new SeenMissionCard(playersInGame[frmSeenCard.WatcherIndex], playersInGame[frmSeenCard.VictimIndex], frmSeenCard.Claim, missionsPlayed[frmSeenCard.MissionIndex]);
                    currentGame.NewInformation(missionInfo);
                }

                selectedPlayers.Clear();
                Refresh();
            }
        }

        private Color GetPlayerColor(double chanceRed)
        {
            var chanceBlue = 1 - chanceRed;

            var a = (int)((COLOR_RED.A * chanceRed) + (COLOR_BLUE.A * chanceBlue));
            var r = (int)((COLOR_RED.R * chanceRed) + (COLOR_BLUE.R * chanceBlue));
            var g = (int)((COLOR_RED.G * chanceRed) + (COLOR_BLUE.G * chanceBlue));
            var b = (int)((COLOR_RED.B * chanceRed) + (COLOR_BLUE.B * chanceBlue));

            return Color.FromArgb(a, r, g, b);
        }

        private void ResistanceSimulator_MouseMove(object sender, MouseEventArgs e)
        {
            HoveredPlayer = -1;
            for (var i = 0; i < 10; i++)
            {
                var square = GetPlayerSquare(i);
                if (square.Contains(e.X, e.Y))
                {
                    HoveredPlayer = i;
                    break;
                }
            }
            this.Refresh();
        }

        private void ResistanceSimulator_MouseUp(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }

        private void ResistanceSimulator_MouseDown(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }
    }
}
