using System.Drawing;

namespace TableTopCalculator.SecretHitler.Info
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

            return hitlerScenario.Roles[Self] == SecretHitlerRole.Blue;
        }

        public override void DrawInfo(Graphics gfx)
        {

        }
    }
}
