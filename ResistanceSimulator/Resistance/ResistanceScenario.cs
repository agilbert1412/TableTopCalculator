using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator.Resistance
{
    public class ResistanceScenario : Scenario
    {
        public Dictionary<Player, ResistanceRole> Roles { get; set; }

        public ResistanceScenario(List<Player> players)
        {
            Roles = new Dictionary<Player, ResistanceRole>();
            foreach(var p in players)
            {
                Roles.Add(p, ResistanceRole.Blue);
            }
        }

        public override int NbReds()
        {
            return Roles.Count(x => x.Value == ResistanceRole.Red);
        }

        public override bool IsCredible(Player player)
        {
            if (Roles.ContainsKey(player))
                return Roles[player] == ResistanceRole.Blue;
            return true;
        }

        public override bool IsPossible(Information info)
        {
            return info.IsPossible(this);
        }

        public override bool IsPossible(List<Information> allInfos)
        {
            return allInfos.All(x => IsPossible(x));
        }

        public override object GetRedsString()
        {
            var str = "";
            foreach(var r in Roles)
            {
                if (r.Value == ResistanceRole.Red)
                    str += r.Key.Name + " ";
            }
            return str.Trim();
        }
    }
}
