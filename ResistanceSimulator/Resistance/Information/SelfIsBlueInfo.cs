using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TableTopCalculator.Resistance
{
    public class SelfIsBlueInfo : Information
    {
        public Player Self { get; set; }

        public SelfIsBlueInfo(Player self)
        {
            Self = self;
        }

        public override bool IsPossible(Scenario scenario)
        {
            var resistanceScenario = (ResistanceScenario)scenario;

            if (resistanceScenario.Roles[Self] != ResistanceRole.Blue)
            {
                return false;
            }

            return true;
        }

        public override void DrawInfo(Graphics gfx)
        {

        }
    }
}
