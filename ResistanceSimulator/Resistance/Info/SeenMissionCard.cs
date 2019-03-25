using System.Drawing;
using System.Linq;
using TableTopCalculator.Resistance.Forms;

namespace TableTopCalculator.Resistance.Info
{
    public class SeenMissionCard : Information
    {
        public Player Watcher { get; set; }
        public Player Target { get; set; }
        public ResistanceRole Claim { get; set; }
        public Mission Mission { get; set; }

        public SeenMissionCard(Player watcher, Player target, ResistanceRole claim, Mission mission)
        {
            Watcher = watcher;
            Target = target;
            Claim = claim;
            Mission = mission;
        }

        public override bool IsPossible(Scenario scenario)
        {
            var resistanceScenario = (ResistanceScenario)scenario;
            if (!resistanceScenario.Roles.ContainsKey(Watcher)
                || !resistanceScenario.Roles.ContainsKey(Target)
                || !Mission.Players.Contains(Watcher)
                || !Mission.Players.Contains(Target)
                || !Mission.Result.Contains(Claim))
                return false;

            if (Claim == ResistanceRole.Red)
            {
                if (resistanceScenario.Roles[Watcher] == ResistanceRole.Blue && resistanceScenario.Roles[Target] == ResistanceRole.Blue)
                {
                    return false;
                }
            }
            else if (Claim == ResistanceRole.Blue)
            {
                var cntRed = Mission.Result.Count(x => x == ResistanceRole.Red);
                if (cntRed <= 0) return true;
                var cntPlayersRed = resistanceScenario.Roles.Count(x => Mission.Players.Contains(x.Key) && x.Key != Target && x.Value == ResistanceRole.Red);
                if (cntPlayersRed < cntRed)
                {
                    return false;
                }
            }
            return true;
        }

        public override void DrawInfo(Graphics gfx)
        {
            if (Claim != ResistanceRole.Red) return;

            var color = Color.Red;

            using (var pen = new Pen(color, 4))
            {
                var rectWatch = ResistanceSimulator.GetPlayerSquare(Watcher.ID);
                var rectTarget = ResistanceSimulator.GetPlayerSquare(Target.ID);

                var pWatch = new Point(rectWatch.Left + (rectWatch.Width / 2), rectWatch.Top + (rectWatch.Height / 2));
                var pTarget = new Point(rectTarget.Left + (rectTarget.Width / 2), rectTarget.Top + (rectTarget.Height / 2));

                gfx.DrawLine(pen, pWatch, pTarget);
            }
        }
    }
}
