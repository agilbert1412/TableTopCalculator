using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TableTopCalculator.SecretHitler
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
            var hitlerScenario = (SecretHitlerScenario)scenario;

            if (hitlerScenario.Roles[Self] != SecretHitlerRole.Blue)
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
