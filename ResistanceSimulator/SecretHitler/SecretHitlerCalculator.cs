using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator.SecretHitler
{
    public class SecretHitlerCalculator : Calculator
    {
        public const int NB_FASCIST_POLICIES = 11;
        public const int NB_LIBERAL_POLICIES = 6;

        public override List<Scenario> GenerateAllScenarios(List<Player> players, int nbRed)
        {
            var scenarios = new List<SecretHitlerScenario>();

            // generate list of sequences containing only 1 element e.g. {1}, {2}, ...
            var oneElemSequences = players.Select(x => new[] { x }).ToList();

            scenarios.Add(new SecretHitlerScenario(players));

            // generate powerset, but skip sequences that are too long
            foreach (var oneElemSequence in oneElemSequences)
            {
                int length = scenarios.Count;

                for (int i = 0; i < length; i++)
                {
                    if (scenarios[i].NbReds() >= nbRed)
                        continue;

                    var newScen = new SecretHitlerScenario(players);
                    foreach (var p in scenarios[i].Roles)
                    {
                        newScen.Roles[p.Key] = p.Value;
                    }

                    newScen.Roles[oneElemSequence.First()] = SecretHitlerRole.Red;

                    scenarios.Add(newScen);
                }
            }

            var scenariosWithReds = scenarios.Where(x => x.NbReds() == nbRed).ToList();

            for (var i = scenariosWithReds.Count - 1; i >= 0; i--)
            {
                var scen = scenariosWithReds[i];

                for (var j = 0; j < nbRed; j++)
                {
                    var newScenRoles = new Dictionary<Player, SecretHitlerRole>();

                    var idx = 0;

                    foreach(var scenRole in scen.Roles)
                    {
                        var val = scenRole.Value;
                        if (val == SecretHitlerRole.Red)
                        {
                            if (idx == j)
                            {
                                val = SecretHitlerRole.Hitler;
                            }
                            idx++;
                        }
                        newScenRoles.Add(scenRole.Key, val);
                    }

                    var newScen = new SecretHitlerScenario(newScenRoles);

                    scenariosWithReds.Add(newScen);
                }

                scenariosWithReds.RemoveAt(i);

            }

            return scenariosWithReds.Where(x => x.NbReds() == nbRed && x.NbHitlers() == 1).Select(x => (Scenario)x).ToList();

            /*for (var i = scenariosWithReds.Count - 1; i >= 0; i--)
            {
                var 
            }*/
        }

        public static List<Scenario> GenerateNextCards(List<Scenario> remainingScenarios, List<Information> allInformation)
        {
            return GenerateNextCards(remainingScenarios.OfType<SecretHitlerScenario>().ToList(), allInformation);
        }

        public static List<Scenario> GenerateNextCards(List<SecretHitlerScenario> remainingScenarios, List<Information> allInformation)
        {
            var nbRed = 11;
            var nbBlue = 6;

            foreach(var info in allInformation.OfType<Election>())
            {
                if (info.Result == SecretHitlerRole.Blue)
                    nbBlue--;
                else
                    nbRed--;
            }

            int nbSets = (nbRed + nbBlue) / 3;
            int remain = (nbRed + nbBlue) % 3;

            var allCards = new List<List<SecretHitlerRole>>();

            for (int i = 0; i < nbSets; i++)
            {
                for(int j = allCards.Count; j >= 0; j--)
                {
                    var pile1 = new List<SecretHitlerRole>();
                    var pile2 = new List<SecretHitlerRole>();
                    var pile3 = new List<SecretHitlerRole>();
                    var pile4 = new List<SecretHitlerRole>();

                    if (j < allCards.Count)
                    {
                        pile1 = allCards[j].ToList();
                        pile2 = allCards[j].ToList();
                        pile3 = allCards[j].ToList();
                        pile4 = allCards[j].ToList();
                    }

                    pile1.Add(SecretHitlerRole.Blue); pile1.Add(SecretHitlerRole.Blue); pile1.Add(SecretHitlerRole.Blue);
                    pile2.Add(SecretHitlerRole.Red); pile2.Add(SecretHitlerRole.Blue); pile2.Add(SecretHitlerRole.Blue);
                    pile3.Add(SecretHitlerRole.Red); pile3.Add(SecretHitlerRole.Red); pile3.Add(SecretHitlerRole.Blue);
                    pile4.Add(SecretHitlerRole.Red); pile4.Add(SecretHitlerRole.Red); pile4.Add(SecretHitlerRole.Red);

                    allCards.Add(pile1);
                    allCards.Add(pile2);
                    allCards.Add(pile3);
                    allCards.Add(pile4);

                    if (j < allCards.Count - 4)
                    {
                        allCards.RemoveAt(j);
                    }
                }
            }

            allCards = allCards.Where(x =>
            (remain == 0 && (x.Count(y => y == SecretHitlerRole.Red) == nbRed && x.Count(y => y == SecretHitlerRole.Blue) == nbBlue))
            || (remain == 1 && (x.Count(y => y == SecretHitlerRole.Red) == nbRed && x.Count(y => y == SecretHitlerRole.Blue) == nbBlue - 1)
                || (x.Count(y => y == SecretHitlerRole.Red) == nbRed - 1 && x.Count(y => y == SecretHitlerRole.Blue) == nbBlue))
            || (remain == 2 && (x.Count(y => y == SecretHitlerRole.Red) == nbRed && x.Count(y => y == SecretHitlerRole.Blue) == nbBlue - 2)
                || (x.Count(y => y == SecretHitlerRole.Red) == nbRed - 2 && x.Count(y => y == SecretHitlerRole.Blue) == nbBlue)
                || (x.Count(y => y == SecretHitlerRole.Red) == nbRed - 1 && x.Count(y => y == SecretHitlerRole.Blue) == nbBlue - 1))
            ).ToList();

            /*var newCards = new List<SecretHitlerRole>();
            for (int i = 0; i < nbBlue + nbRed; i++)
            {
                newCards.Add(SecretHitlerRole.Blue);
            }

            var allSetsOfCards = new List<List<SecretHitlerRole>>();

            // generate list of sequences containing only 1 element e.g. {1}, {2}, ...
            var oneElemSequences = newCards.Select(x => new[] { x }).ToList();

            allSetsOfCards.Add(new List<SecretHitlerRole>(newCards));

            // generate powerset, but skip sequences that are too long
            for (var j = 0; j < oneElemSequences.Count; j++)
            {
                int length = allSetsOfCards.Count;

                for (int i = 0; i < length; i++)
                {
                    if (allSetsOfCards[i].Count(x => x == SecretHitlerRole.Red) >= nbRed)
                        continue;

                    var newSet = new List<SecretHitlerRole>(newCards);
                    for (var p = 0; p < allSetsOfCards[i].Count; p++)
                    {
                        newSet[p] = allSetsOfCards[i][p];
                    }

                    newSet[j] = SecretHitlerRole.Red;

                    allSetsOfCards.Add(newSet);
                }
            }

            allSetsOfCards = allSetsOfCards.Where(x => x.Count(y => y == SecretHitlerRole.Red) == nbRed).ToList();*/

            for (var i = remainingScenarios.Count - 1; i >= 0; i--)
            {
                foreach(var set in allCards)
                {
                    var newScen = remainingScenarios[i].Clone();

                    while (newScen.CardColorsOrder.Count % 3 != 0)
                    {
                        newScen.CardColorsOrder.RemoveAt(newScen.CardColorsOrder.Count - 1);
                    }

                    newScen.CardColorsOrder.AddRange(set);

                    remainingScenarios.Add(newScen);
                }

                remainingScenarios.RemoveAt(i);
            }

            return remainingScenarios.Select(x => (Scenario)x).ToList();
        }

        private List<SecretHitlerScenario> GenerateScenarios(Scenario originalSetup, int nbChange, SecretHitlerRole roleChange)
        {
            return null;
        }

        public override Dictionary<Player, double> GetChancesOfRole(int role, List<Scenario> scenarios)
        {
            var secretHitlerRole = (SecretHitlerRole)role;

            var totalScenarios = scenarios.Count();
            var dicNbRed = new Dictionary<Player, int>();
            var dicChances = new Dictionary<Player, double>();

            foreach (var scenario in scenarios.OfType<SecretHitlerScenario>())
            {
                foreach (var playerRole in scenario.Roles)
                {
                    var p = playerRole.Key;
                    var r = playerRole.Value;

                    if (!dicNbRed.ContainsKey(p))
                    {
                        dicNbRed.Add(p, 0);
                    }
                    if (r == secretHitlerRole || (r == SecretHitlerRole.Hitler && secretHitlerRole == SecretHitlerRole.Red))
                    {
                        dicNbRed[p]++;
                    }
                }
            }

            foreach (var kvp in dicNbRed)
            {
                if (totalScenarios == 0)
                {
                    dicChances.Add(kvp.Key, 0);
                }
                else
                {
                    dicChances.Add(kvp.Key, ((double)kvp.Value / (double)totalScenarios));
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
