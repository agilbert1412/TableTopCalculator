using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using TableTopCalculator.Generic.Forms;
using TableTopCalculator.Properties;
using TableTopCalculator.SecretHitler.Info;

namespace TableTopCalculator.SecretHitler.Forms
{
    public partial class SecretHitlerSimulator : Form
    {
        private Game _currentGame;

        private readonly Player[] _currentPlayers = new Player[10];

        private readonly List<int> _selectedPlayers = new List<int>();

        private readonly Brush _colorClosed = Brushes.DimGray;
        private readonly Brush _colorOpen = Brushes.Silver;

        private readonly Color _colorPresident = Color.Gold;
        private readonly Color _colorChancellor = Color.Brown;

        private readonly Color _colorRed = Color.FromArgb(255, 255, 0, 0);
        private readonly Color _colorHitler = Color.FromArgb(255, 0, 0, 0);
        private readonly Color _colorBlue = Color.FromArgb(255, 0, 128, 255);

        private int _hoveredPlayer = -1;

        public SecretHitlerSimulator()
        {
            InitializeComponent();
        }

        private void SecretHitlerSimulator_Load(object sender, EventArgs e)
        {
            _currentGame = null;
            for (var i = 0; i < 9; i++)
            {
                _currentPlayers[i] = null;
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

            if (_currentGame == null)
                return;

            foreach (var info in _currentGame.AllInformation)
            {
                info.DrawInfo(gfx);
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

            if (_currentPlayers[playerIndex] != null)
            {
                if (_currentGame != null)
                {
                    var chanceOfRed = _currentGame.GetChanceOfRole(_currentPlayers[playerIndex], (int)SecretHitlerRole.Red);
                    var chanceOfHitler = _currentGame.GetChanceOfRole(_currentPlayers[playerIndex], (int)SecretHitlerRole.Hitler);

                    if (MouseButtons == MouseButtons.Right && _hoveredPlayer > -1 && _currentPlayers[_hoveredPlayer] != null)
                    {
                        chanceOfRed = _currentGame.GetChanceOfRole(_currentPlayers[playerIndex], (int)SecretHitlerRole.Red, _currentPlayers[_hoveredPlayer]);
                        chanceOfHitler = _currentGame.GetChanceOfRole(_currentPlayers[playerIndex], (int)SecretHitlerRole.Hitler, _currentPlayers[_hoveredPlayer]);
                    }

                    var colorRed = GetPlayerColor(chanceOfRed, _colorBlue, _colorRed);
                    var colorHitler = GetPlayerColor(chanceOfHitler, colorRed, _colorHitler);
                    gfx.FillRectangle(new SolidBrush(colorRed), square);
                    gfx.DrawPath(new Pen(colorHitler), GetHitlerLogo(square));
                    gfx.DrawString(Math.Round(chanceOfRed * 100) + "% (" + Math.Round(chanceOfHitler * 100) + "%", font, Brushes.Black, locationPercent);
                }
                else
                {
                    gfx.FillRectangle(new SolidBrush(GetPlayerColor(0, _colorBlue, _colorRed)), square);
                }
                gfx.DrawString(_currentPlayers[playerIndex].Name, font, Brushes.Black, locationName);
                if (_selectedPlayers.Contains(playerIndex))
                {
                    gfx.DrawRectangle(new Pen((_selectedPlayers[0] == playerIndex ? _colorPresident : _colorChancellor), 4), square);
                }
            }
            else
            {
                if (_currentGame != null)
                {
                    gfx.FillRectangle(_colorClosed, square);
                    gfx.DrawString("Closed", font, Brushes.Black, locationName);
                }
                else
                {

                    gfx.FillRectangle(_colorOpen, square);
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
            const int length = 100;

            var xOffset = ((index % 5) * 150) + 50;
            var yOffset = ((index / 5) * 150) + 50;
            
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

                    if (!square.Contains(e.X, e.Y))
                        continue;

                    clickedPlayer = i;
                    break;
                }

                if (clickedPlayer > -1)
                {
                    if (_currentGame == null)
                    {
                        if (_currentPlayers[clickedPlayer] == null)
                        {
                            // Show New Player Form

                            var name = Interaction.InputBox("What is the name of this player?", "Name Player");

                            _currentPlayers[clickedPlayer] = new Player(clickedPlayer, name);
                        }
                        else
                        {
                            _currentPlayers[clickedPlayer] = null;
                        }
                        btnStartStop.Enabled = _currentPlayers.Count(x => x != null) > 4;
                    }
                    else
                    {
                        if (_currentPlayers[clickedPlayer] != null)
                        {
                            if (_selectedPlayers.Contains(clickedPlayer))
                            {
                                _selectedPlayers.Remove(clickedPlayer);
                            }
                            else if (_selectedPlayers.Count < 2)
                            {
                                _selectedPlayers.Add(clickedPlayer);
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
            if (_currentGame != null)
            {
                _currentGame = null;

                btnStartStop.Text = Resources.Start_Game;
                btnElectionPassed.Enabled = false;
                btnAllegianceReveal.Enabled = false;

                btnNotHitler.Enabled = false;
            }
            else
            {
                _currentGame = new Game(_currentPlayers.ToList(), GameType.SecretHitler);
                _currentGame.StartGame();

                btnStartStop.Text = Resources.Stop_Game;
                btnElectionPassed.Enabled = true;
                btnAllegianceReveal.Enabled = true;

                btnNotHitler.Enabled = true;
            }
            Refresh();
        }

        private void btnPlayMission_Click(object sender, EventArgs e)
        {
            if (_selectedPlayers.Count != 2)
                return;

            if (_currentGame.RemainingScenarios.Any(x => ((SecretHitlerScenario)(x)).CardColorsOrder.Count < (_currentGame.AllInformation.Count(y => y is Election) * 3) + 3))
            {
                _currentGame.RemainingScenarios = SecretHitlerCalculator.GenerateNextCards(_currentGame.RemainingScenarios, _currentGame.AllInformation);
            }

            var president = _currentPlayers[_selectedPlayers[0]];
            var chancellor = _currentPlayers[_selectedPlayers[1]];

            var frmMission = new PassPolicy(president, chancellor);

            if (frmMission.ShowDialog() != DialogResult.OK)
                return;

            var missionInfo = new Election(_currentGame.AllInformation.Count(x => x is Election), frmMission.President, frmMission.Chancellor,
                frmMission.Result, _currentGame.AllInformation.Count(x => x is Election election && election.Result == SecretHitlerRole.Red) >= 3);



            _currentGame.NewInformation(missionInfo);

            _selectedPlayers.Clear();
            Refresh();
        }

        private void btnRoleReveal_Click(object sender, EventArgs e)
        {
            var playersInGame = new List<Player>();
            //currentGame.AllInformation.RemoveAt(currentGame.AllInformation.Count - 1);
            playersInGame.AddRange(_currentPlayers.Where(x => x != null));

            var frmSeenRole = new RoleReveal(playersInGame);

            if (frmSeenRole.ShowDialog() != DialogResult.OK)
                return;

            var missionInfo = new SeenRole(playersInGame[frmSeenRole.WatcherIndex], playersInGame[frmSeenRole.VictimIndex], frmSeenRole.Claim);
            _currentGame.NewInformation(missionInfo);

            _selectedPlayers.Clear();
            Refresh();
        }

        private void btnNotHitler_Click(object sender, EventArgs e)
        {
            if (_selectedPlayers.Count != 1)
                return;


            _currentGame.NewInformation(new NotHitlerInfo(_currentPlayers[_selectedPlayers[0]]));

            _selectedPlayers.Clear();
            Refresh();
        }

        private static Color GetPlayerColor(double chanceRed, Color colorIfNot, Color colorIfYes)
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
            _hoveredPlayer = -1;
            for (var i = 0; i < 10; i++)
            {
                var square = GetPlayerSquare(i);

                if (!square.Contains(e.X, e.Y))
                    continue;

                _hoveredPlayer = i;
                break;
            }
            Refresh();
        }

        private void SecretHitlerSimulator_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        private void SecretHitlerSimulator_MouseUp(object sender, MouseEventArgs e)
        {

            Refresh();
        }
    }
}
