using System.Drawing;

namespace TableTopCalculator.Resistance.Info
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

            if (Card != ResistanceRole.Red)
                return true;

            return resistanceScenario.Roles[Target] != ResistanceRole.Blue;
        }

        public override void DrawInfo(Graphics gfx)
        {

        }
    }
}
