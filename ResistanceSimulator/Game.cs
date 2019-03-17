using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTopCalculator.Resistance;
using TableTopCalculator.SecretHitler;

namespace TableTopCalculator
{
    public enum GameType
    {
        Resistance,
        SecretHitler
    }

    public class Game
    {
        public List<Player> Players { get; set; }

        public List<Information> AllInformation { get; set; }

        public Calculator Calc { get; set; }

        public List<Scenario> remainingScenarios { get; set; }

        public Dictionary<int, Dictionary<Player, double>> ChancesOfRole { get; set; }

        public Dictionary<Tuple<int, int>, Dictionary<Player, double>> ChancesOfRoleWithTemps { get; set; }

        public readonly Dictionary<int, int> nbRedsPerNbPlayersResistance = new Dictionary<int, int>()
        {
            { 5, 2 },
            { 6, 2 },
            { 7, 3 },
            { 8, 3 },
            { 9, 3 },
            { 10, 4 }
        };

        public readonly Dictionary<int, int> nbRedsPerNbPlayersSecretHitler = new Dictionary<int, int>()
        {
            { 5, 2 },
            { 6, 2 },
            { 7, 3 },
            { 8, 3 },
            { 9, 4 },
            { 10, 4 }
        };

        public Game(List<Player> allPlayers, GameType type)
        {
            if (type == GameType.Resistance)
            {
                Calc = new ResistanceCalculator();
            }
            else if (type == GameType.SecretHitler)
            {
                Calc = new SecretHitlerCalculator();
            }
            AllInformation = new List<Information>();
            Players = allPlayers;
            remainingScenarios = new List<Scenario>();
        }

        public void StartGame()
        {
            Players = Players.Where(x => x != null).ToList();
            remainingScenarios = Calc.GenerateAllScenarios(Players, Calc is ResistanceCalculator ? nbRedsPerNbPlayersResistance[Players.Count] : nbRedsPerNbPlayersSecretHitler[Players.Count]);
            ChancesOfRole = new Dictionary<int, Dictionary<Player, double>>();
            ChancesOfRoleWithTemps = new Dictionary<Tuple<int, int>, Dictionary<Player, double>>();
        }

        public double GetChanceOfRole(Player player, int role)
        {
            if (!ChancesOfRole.ContainsKey(role))
            {
                ChancesOfRole.Add(role, Calc.GetChancesOfRole(role, remainingScenarios));
            }

            if (remainingScenarios.Count() > 0)
            {
                return ChancesOfRole[role][player];
            }
            return 0;
        }

        public double GetChanceOfRole(Player player, int role, Player temporaryInfoPlayer)
        {
            var key = new Tuple<int, int>(role, temporaryInfoPlayer.ID);

            if (!ChancesOfRoleWithTemps.ContainsKey(key))
            {
                var scenariosWithTemp = remainingScenarios.ToList();

                var temporaryInfo = Calc.GetTemporaryInformation(temporaryInfoPlayer);

                for (var i = scenariosWithTemp.Count - 1; i >= 0; i--)
                {
                    if (!scenariosWithTemp[i].IsPossible(temporaryInfo))
                    {
                        scenariosWithTemp.RemoveAt(i);
                    }
                }

                if (scenariosWithTemp.Any())
                {
                    ChancesOfRoleWithTemps.Add(key, Calc.GetChancesOfRole(role, scenariosWithTemp));
                }
            }

            if (remainingScenarios.Count() > 0 && ChancesOfRoleWithTemps.ContainsKey(key) && ChancesOfRoleWithTemps[key].ContainsKey(player))
            {
                return ChancesOfRoleWithTemps[key][player];
            }
            return 0;
        }

        public void NewInformation(Information info)
        {
            AllInformation.Add(info);
            //remainingScenarios = Calc.GenerateAllScenarios(Players, nbRedsPerNbPlayers[Players.Count]);

            for (var i = remainingScenarios.Count - 1; i >= 0; i--)
            {
                if (!remainingScenarios[i].IsPossible(AllInformation))
                {
                    remainingScenarios.RemoveAt(i);
                }
            }

            ChancesOfRole = new Dictionary<int, Dictionary<Player, double>>();
            ChancesOfRoleWithTemps = new Dictionary<Tuple<int, int>, Dictionary<Player, double>>();
        }
    }

    public enum ResistanceRole
    {
        Blue,
        Red
    }

    public enum SecretHitlerRole
    {
        Blue,
        Red,
        Hitler
    }
}
