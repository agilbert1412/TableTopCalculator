using System.Collections.Generic;

namespace TableTopCalculator
{
    public abstract class Calculator
    {
        public abstract Dictionary<Player, double> GetChancesOfRole(int role, List<Scenario> scenarios);

        public abstract List<Scenario> GenerateAllScenarios(List<Player> players, int nbRed);
        internal abstract Information GetTemporaryInformation(Player player);
    }
}
