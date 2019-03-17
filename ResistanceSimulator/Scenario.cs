using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator
{
    public abstract class Scenario
    {

        public abstract int NbReds();

        public abstract bool IsCredible(Player player);

        public abstract bool IsPossible(Information info);

        public abstract bool IsPossible(List<Information> allInfos);

        public abstract object GetRedsString();
    }
}
