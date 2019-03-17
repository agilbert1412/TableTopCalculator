using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator
{
    public abstract class Calculator
    {
        public abstract Dictionary<Player, double> GetChancesOfRole(int role, List<Scenario> scenarios);

        public abstract List<Scenario> GenerateAllScenarios(List<Player> players, int nbRed);
    }
}
