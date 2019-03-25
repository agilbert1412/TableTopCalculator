using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TableTopCalculator.Generic.Forms;
using TableTopCalculator.Properties;
using TableTopCalculator.Resistance.Info;

namespace TableTopCalculator.Resistance.Forms
{
    public partial class ResistanceSimulator : Form
    {
        private Game _currentGame;

        private readonly Player[] _currentPlayers = new Player[10];

        private readonly List<int> _selectedPlayers = new List<int>();

        private readonly Brush _brushColorClosed = Brushes.DimGray;
        private readonly Brush _brushColorOpen = Brushes.Silver;

        private readonly Color _colorRed = Color.FromArgb(255, 255, 0, 0);
        private readonly Color _colorBlue = Color.FromArgb(255, 0, 128, 255);

        private int _hoveredPlayer = -1;

        public ResistanceSimulator()
        {
            InitializeComponent();
        }

        private void ResistanceSimulator_Load(object sender, EventArgs e)
        {
            _currentGame = null;
            for (var i = 0; i < 9; i++)
            {
                _currentPlayers[i] = null;
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
                    var chanceOfRed = _currentGame.GetChanceOfRole(_currentPlayers[playerIndex], (int)ResistanceRole.Red);

                    if (MouseButtons == MouseButtons.Right && _hoveredPlayer > -1 && _currentPlayers[_hoveredPlayer] != null)
                    {
                        chanceOfRed = _currentGame.GetChanceOfRole(_currentPlayers[playerIndex], (int)ResistanceRole.Red, _currentPlayers[_hoveredPlayer]);
                    }

                    var color = GetPlayerColor(chanceOfRed);
                    gfx.FillRectangle(new SolidBrush(color), square);
                    gfx.DrawString(Math.Round(chanceOfRed * 100) + "%", font, Brushes.Black, locationPercent);
                }
                else
                {
                    gfx.FillRectangle(new SolidBrush(GetPlayerColor(0)), square);
                }
                gfx.DrawString(_currentPlayers[playerIndex].Name, font, Brushes.Black, locationName);
                if (_selectedPlayers.Contains(playerIndex))
                {
                    gfx.DrawRectangle(new Pen(Color.LightGreen, 4), square);
                }
            }
            else
            {
                if (_currentGame != null)
                {
                    gfx.FillRectangle(_brushColorClosed, square);
                    gfx.DrawString("Closed", font, Brushes.Black, locationName);
                }
                else
                {

                    gfx.FillRectangle(_brushColorOpen, square);
                    gfx.DrawString("Open", font, Brushes.Black, locationName);
                }
            }
        }

        internal static Rectangle GetPlayerSquare(int index)
        {
            const int length = 100;

            var xOffset = ((index % 5) * 150) + 50;
            var yOffset = ((index / 5) * 150) + 50;

            return new Rectangle(xOffset, yOffset, length, length);
        }

        private void ResistanceSimulator_MouseClick(object sender, MouseEventArgs e)
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
                if (e.Button == MouseButtons.Left)
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
                            else
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
                btnPlayMission.Enabled = false;
                btnMissionCardReveal.Enabled = false;
                btnRoleReveal.Enabled = false;
            }
            else
            {
                _currentGame = new Game(_currentPlayers.ToList(), GameType.Resistance);
                _currentGame.StartGame();

                btnStartStop.Text = Resources.Stop_Game;
                btnPlayMission.Enabled = true;
                btnMissionCardReveal.Enabled = true;
                btnRoleReveal.Enabled = true;
            }
            Refresh();
        }

        private void btnPlayMission_Click(object sender, EventArgs e)
        {
            var playersInMission = new List<Player>();
            foreach (var selected in _selectedPlayers)
            {
                if (_currentPlayers[selected] != null)
                {
                    playersInMission.Add(_currentPlayers[selected]);
                }
            }

            var frmMission = new PlayMission();

            if (frmMission.ShowDialog() != DialogResult.OK)
                return;

            var result = new List<ResistanceRole>();
            for (var i = 0; i < frmMission.NbRedPlayed; i++)
            {
                result.Add(ResistanceRole.Red);
            }
            while (result.Count < playersInMission.Count)
            {
                result.Add(ResistanceRole.Blue);
            }
            var missionInfo = new Mission(_currentGame.AllInformation.Count(x => x is Mission), playersInMission, result, frmMission.NbRedToFail);
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

        private void btnMissionCardReveal_Click(object sender, EventArgs e)
        {
            var playersInGame = new List<Player>();
            playersInGame.AddRange(_currentPlayers.Where(x => x != null));
            var missionsPlayed = _currentGame.AllInformation.OfType<Mission>().ToList();

            //var lastInfo = currentGame.AllInformation.Last();
            //currentGame.AllInformation.RemoveAt(currentGame.AllInformation.Count - 1);
            //currentGame.NewInformation(lastInfo);

            var frmSeenCard = new MissionCardReveal(playersInGame, missionsPlayed);

            if (frmSeenCard.ShowDialog() != DialogResult.OK)
                return;

            if (frmSeenCard.WatcherIndex == -1)
            {
                var missionInfo = new ShownMissionCard(playersInGame[frmSeenCard.VictimIndex], frmSeenCard.Claim);
                _currentGame.NewInformation(missionInfo);
            }
            else
            {
                var missionInfo = new SeenMissionCard(playersInGame[frmSeenCard.WatcherIndex], playersInGame[frmSeenCard.VictimIndex], frmSeenCard.Claim, missionsPlayed[frmSeenCard.MissionIndex]);
                _currentGame.NewInformation(missionInfo);
            }

            _selectedPlayers.Clear();
            Refresh();
        }

        private Color GetPlayerColor(double chanceRed)
        {
            var chanceBlue = 1 - chanceRed;

            var a = (int)((_colorRed.A * chanceRed) + (_colorBlue.A * chanceBlue));
            var r = (int)((_colorRed.R * chanceRed) + (_colorBlue.R * chanceBlue));
            var g = (int)((_colorRed.G * chanceRed) + (_colorBlue.G * chanceBlue));
            var b = (int)((_colorRed.B * chanceRed) + (_colorBlue.B * chanceBlue));

            return Color.FromArgb(a, r, g, b);
        }

        private void ResistanceSimulator_MouseMove(object sender, MouseEventArgs e)
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

        private void ResistanceSimulator_MouseUp(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        private void ResistanceSimulator_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh();
        }
    }
}
