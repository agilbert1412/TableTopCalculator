using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator.Resistance
{
    public class ShownMissionCard : Information
    {
        public Player Target { get; set; }
        public ResistanceRole Card { get; set; }

        public ShownMissionCard(Player target, ResistanceRole card)
        {
            Target = target;
            Card = card;
        }

        public override bool IsPossible(Scenario scenario)
        {
            var resistanceScenario = (ResistanceScenario)scenario;
            if (!resistanceScenario.Roles.ContainsKey(Target))
                return false;

            if (Card == ResistanceRole.Red)
            {
                if (resistanceScenario.Roles[Target] == ResistanceRole.Blue)
                {
                    return false;
                }
            }
            return true;
        }

        public override void DrawInfo(Graphics gfx)
        {

        }
    }
}
