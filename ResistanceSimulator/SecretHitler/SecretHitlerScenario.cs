using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator.SecretHitler
{
    public class SecretHitlerScenario : Scenario
    {
        public Dictionary<Player, SecretHitlerRole> Roles { get; set; }

        public List<SecretHitlerRole> CardColorsOrder { get; set; }

        public SecretHitlerScenario(List<Player> players)
        {
            Roles = new Dictionary<Player, SecretHitlerRole>();
            foreach(var p in players)
            {
                Roles.Add(p, SecretHitlerRole.Blue);
            }
            CardColorsOrder = new List<SecretHitlerRole>();
        }

        public SecretHitlerScenario(Dictionary<Player, SecretHitlerRole> roles)
        {
            Roles = new Dictionary<Player, SecretHitlerRole>();
            foreach (var p in roles)
            {
                Roles.Add(p.Key, p.Value);
            }
            CardColorsOrder = new List<SecretHitlerRole>();
        }

        public SecretHitlerScenario(Dictionary<Player, SecretHitlerRole> roles, List<SecretHitlerRole> cardColorsOrder)
        {
            Roles = new Dictionary<Player, SecretHitlerRole>();
            foreach (var p in roles)
            {
                Roles.Add(p.Key, p.Value);
            }
            CardColorsOrder = new List<SecretHitlerRole>(cardColorsOrder);
        }

        public override int NbReds()
        {
            return Roles.Count(x => x.Value == SecretHitlerRole.Red || x.Value == SecretHitlerRole.Hitler);
        }

        public int NbHitlers()
        {
            return Roles.Count(x => x.Value == SecretHitlerRole.Hitler);
        }

        public override bool IsCredible(Player player)
        {
            if (Roles.ContainsKey(player))
                return Roles[player] == SecretHitlerRole.Blue;
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
                if (r.Value == SecretHitlerRole.Red)
                    str += r.Key.Name + " ";
            }
            return str.Trim();
        }

        public SecretHitlerScenario Clone()
        {
            return new SecretHitlerScenario(Roles, CardColorsOrder);
        }
    }
}
