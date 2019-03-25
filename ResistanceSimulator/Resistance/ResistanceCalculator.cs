using System.Collections.Generic;
using System.Linq;
using TableTopCalculator.Resistance.Info;

namespace TableTopCalculator.Resistance
{
    public class ResistanceCalculator : Calculator
    {
        public override List<Scenario> GenerateAllScenarios(List<Player> players, int nbRed)
        {
            var scenarios = new List<ResistanceScenario>();

            // generate list of sequences containing only 1 element e.g. {1}, {2}, ...
            var oneElemSequences = players.Select(x => new[] { x }).ToList();

            scenarios.Add(new ResistanceScenario(players));
            
            // We generate, but skip sequences that are too long
            foreach (var oneElemSequence in oneElemSequences)
            {
                var length = scenarios.Count;

                for (var i = 0; i < length; i++)
                {
                    if (scenarios[i].NbReds() >= nbRed)
                        continue;

                    var newScenario = new ResistanceScenario(players);
                    foreach (var p in scenarios[i].Roles)
                    {
                        newScenario.Roles[p.Key] = p.Value;
                    }

                    newScenario.Roles[oneElemSequence.First()] = ResistanceRole.Red;

                    scenarios.Add(newScenario);
                }
            }

            return scenarios.Where(x => x.NbReds() == nbRed).Select(x => (Scenario)x).ToList();
        }

        public override Dictionary<Player, double> GetChancesOfRole(int role, List<Scenario> scenarios)
        {
            var roleToCheck = (ResistanceRole)role;

            var totalScenarios = scenarios.Count;
            var dicNbHaveRole = new Dictionary<Player, int>();
            var dicChances = new Dictionary<Player, double>();

            foreach (var scenario in scenarios.OfType<ResistanceScenario>())
            {
                foreach (var playerRole in scenario.Roles)
                {
                    var p = playerRole.Key;
                    var r = playerRole.Value;

                    if (!dicNbHaveRole.ContainsKey(p))
                    {
                        dicNbHaveRole.Add(p, 0);
                    }
                    if (r == roleToCheck)
                    {
                        dicNbHaveRole[p]++;
                    }
                }
            }

            foreach (var kvp in dicNbHaveRole)
            {
                if (totalScenarios == 0)
                {
                    dicChances.Add(kvp.Key, 0);
                }
                else
                {
                    dicChances.Add(kvp.Key, (kvp.Value / (double)totalScenarios));
                }
            }

            return dicChances;
        }

        internal override Information GetTemporaryInformation(Player player)
        {
            return new SelfIsBlueInfo(player);
        }
    }
}
