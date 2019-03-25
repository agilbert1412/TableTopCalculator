using System.Collections.Generic;
using System.Linq;

namespace TableTopCalculator.Resistance
{
    public class ResistanceScenario : Scenario
    {
        public Dictionary<Player, ResistanceRole> Roles { get; set; }

        public ResistanceScenario(IEnumerable<Player> players)
        {
            Roles = new Dictionary<Player, ResistanceRole>();
            foreach(var p in players)
            {
                Roles.Add(p, ResistanceRole.Blue);
            }
        }

        public int NbReds()
        {
            return Roles.Count(x => x.Value == ResistanceRole.Red);
        }

        /*public bool IsCredible(Player player)
        {
            if (Roles.ContainsKey(player))
                return Roles[player] == ResistanceRole.Blue;
            return true;
        }*/

        public override bool IsPossible(Information info)
        {
            return info.IsPossible(this);
        }

        public override bool IsPossible(List<Information> allInfos)
        {
            return allInfos.All(IsPossible);
        }

        /*public object GetRedsString()
        {
            var str = "";
            foreach(var r in Roles)
            {
                if (r.Value == ResistanceRole.Red)
                    str += r.Key.Name + " ";
            }
            return str.Trim();
        }*/
    }
}
