using System.Drawing;

namespace TableTopCalculator.Resistance.Info
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

            return resistanceScenario.Roles[Self] == ResistanceRole.Blue;
        }

        public override void DrawInfo(Graphics gfx)
        {

        }
    }
}
