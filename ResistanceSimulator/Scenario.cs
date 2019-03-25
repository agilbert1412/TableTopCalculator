using System.Collections.Generic;

namespace TableTopCalculator
{
    public abstract class Scenario
    {

        public abstract bool IsPossible(Information info);

        public abstract bool IsPossible(List<Information> allInfos);

        /*public abstract int NbReds();
        public abstract bool IsCredible(Player player);
        public abstract object GetRedsString();*/
    }
}
