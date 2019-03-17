using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableTopCalculator.Generic;

namespace TableTopCalculator.SecretHitler
{
    public partial class SecretHitlerSimulator : Form
    {
        Game currentGame;

        Player[] CurrentPlayers = new Player[10];

        List<int> selectedPlayers = new List<int>();

        Brush COLOR_CLOSED = Brushes.DimGray;
        Brush COLOR_OPEN = Brushes.Silver;

        Color COLOR_PRESIDENT = Color.Gold;
        Color COLOR_CHANCELLOR = Color.Brown;

        Color COLOR_RED = Color.FromArgb(255, 255, 0, 0);
        Color COLOR_HITLER = Color.FromArgb(255, 0, 0, 0);
        Color COLOR_BLUE = Color.FromArgb(255, 0, 128, 255);

        int HoveredPlayer = -1;

        public SecretHitlerSimulator()
        {
            InitializeComponent();
        }

        private void SecretHitlerSimulator_Load(object sender, EventArgs e)
        {
            currentGame = null;
            for (int i = 0; i < 9; i++)
            {
                CurrentPlayers[i] = null;
            }

            btnStartStop.Enabled = false;
            btnElectionPassed.Enabled = false;
            btnAllegianceReveal.Enabled = false;


            btnNotHitler.Enabled = false;
        }

        private void SecretHitlerSimulator_Paint(object sender, PaintEventArgs e)
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
                    var chanceOfRed = currentGame.GetChanceOfRole(CurrentPlayers[playerIndex], (int)SecretHitlerRole.Red);
                    var chanceOfHitler = currentGame.GetChanceOfRole(CurrentPlayers[playerIndex], (int)SecretHitlerRole.Hitler);

                    if (MouseButtons == MouseButtons.Right && HoveredPlayer > -1 && CurrentPlayers[HoveredPlayer] != null)
                    {
                        chanceOfRed = currentGame.GetChanceOfRole(CurrentPlayers[playerIndex], (int)SecretHitlerRole.Red, CurrentPlayers[HoveredPlayer]);
                        chanceOfHitler = currentGame.GetChanceOfRole(CurrentPlayers[playerIndex], (int)SecretHitlerRole.Hitler, CurrentPlayers[HoveredPlayer]);
                    }

                    var colorRed = GetPlayerColor(chanceOfRed, COLOR_BLUE, COLOR_RED);
                    var colorHitler = GetPlayerColor(chanceOfHitler, colorRed, COLOR_HITLER);
                    gfx.FillRectangle(new SolidBrush(colorRed), square);
                    gfx.DrawPath(new Pen(colorHitler), GetHitlerLogo(square));
                    gfx.DrawString(Math.Round(chanceOfRed * 100) + "% (" + Math.Round(chanceOfHitler * 100) + "%", font, Brushes.Black, locationPercent);
                }
                else
                {
                    gfx.FillRectangle(new SolidBrush(GetPlayerColor(0, COLOR_BLUE, COLOR_RED)), square);
                }
                gfx.DrawString(CurrentPlayers[playerIndex].Name, font, Brushes.Black, locationName);
                if (selectedPlayers.Contains(playerIndex))
                {
                    gfx.DrawRectangle(new Pen((selectedPlayers[0] == playerIndex ? COLOR_PRESIDENT : COLOR_CHANCELLOR), 4), square);
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

        private static GraphicsPath GetHitlerLogo(Rectangle rect)
        {
            var path = new GraphicsPath();

            path.AddLine(GetX(50, rect), GetY(10, rect), GetX(30, rect), GetY(30, rect));
            path.AddLine(GetX(30, rect), GetY(30, rect), GetX(80, rect), GetY(80, rect));
            path.AddLine(GetX(80, rect), GetY(80, rect), GetX(50, rect), GetY(100, rect));

            return path;
        }

        private static int GetX(int x, Rectangle rect)
        {
            return (x * rect.Width / 110) + rect.X;
        }

        private static int GetY(int y, Rectangle rect)
        {
            return (y * rect.Height / 110) + rect.Y;
        }

        internal static Rectangle GetPlayerSquare(int index)
        {
            var xOffset = ((index % 5) * 150) + 50;
            var yOffset = ((index / 5) * 150) + 50;

            var length = 100;

            return new Rectangle(xOffset, yOffset, length, length);
        }

        private void SecretHitlerSimulator_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
                            else if (selectedPlayers.Count < 2)
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
                btnElectionPassed.Enabled = false;
                btnAllegianceReveal.Enabled = false;

                btnNotHitler.Enabled = false;
            }
            else
            {
                currentGame = new Game(CurrentPlayers.ToList(), GameType.SecretHitler);
                currentGame.StartGame();

                btnStartStop.Text = "Stop Game";
                btnElectionPassed.Enabled = true;
                btnAllegianceReveal.Enabled = true;

                btnNotHitler.Enabled = true;
            }
            Refresh();
        }

        private void btnPlayMission_Click(object sender, EventArgs e)
        {
            if (selectedPlayers.Count != 2)
                return;

            if (currentGame.remainingScenarios.Any(x => ((SecretHitlerScenario)(x)).CardColorsOrder.Count < (currentGame.AllInformation.Count(y => y is Election) * 3) + 3))
            {
                currentGame.remainingScenarios = SecretHitlerCalculator.GenerateNextCards(currentGame.remainingScenarios, currentGame.AllInformation);
            }

            var president = CurrentPlayers[selectedPlayers[0]];
            var chancellor = CurrentPlayers[selectedPlayers[1]];

            var frmMission = new PassPolicy(president, chancellor);
            if (frmMission.ShowDialog() == DialogResult.OK)
            {
                var missionInfo = new Election(currentGame.AllInformation.Count(x => x is Election), frmMission.President, frmMission.Chancellor,
                    frmMission.Result, currentGame.AllInformation.Count(x => x is Election elec && elec.Result == SecretHitlerRole.Red) >= 3);



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

        private void btnNotHitler_Click(object sender, EventArgs e)
        {
            if (selectedPlayers.Count != 1)
                return;


            currentGame.NewInformation(new NotHitlerInfo(CurrentPlayers[selectedPlayers[0]]));

            selectedPlayers.Clear();
            Refresh();
        }

        private Color GetPlayerColor(double chanceRed, Color colorIfNot, Color colorIfYes)
        {
            var chanceBlue = 1 - chanceRed;

            var a = (int)((colorIfYes.A * chanceRed) + (colorIfNot.A * chanceBlue));
            var r = (int)((colorIfYes.R * chanceRed) + (colorIfNot.R * chanceBlue));
            var g = (int)((colorIfYes.G * chanceRed) + (colorIfNot.G * chanceBlue));
            var b = (int)((colorIfYes.B * chanceRed) + (colorIfNot.B * chanceBlue));

            return Color.FromArgb(a, r, g, b);
        }

        private void SecretHitlerSimulator_MouseMove(object sender, MouseEventArgs e)
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

        private void SecretHitlerSimulator_MouseDown(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }

        private void SecretHitlerSimulator_MouseUp(object sender, MouseEventArgs e)
        {

            this.Refresh();
        }
    }
}
