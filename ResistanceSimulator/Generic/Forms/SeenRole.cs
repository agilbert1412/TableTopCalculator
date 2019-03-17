using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTopCalculator.Resistance;
using TableTopCalculator.SecretHitler;

namespace TableTopCalculator.Generic
{
    public class SeenRole : Information
    {
        public Player Watcher { get; set; }
        public Player Target { get; set; }
        public ResistanceRole Claim { get; set; }

        public SeenRole(Player watcher, Player target, ResistanceRole claim)
        {
            Watcher = watcher;
            Target = target;
            Claim = claim;
        }

        public override bool IsPossible(Scenario scenario)
        {
            if (scenario is ResistanceScenario resScen)
            {
                if (!resScen.Roles.ContainsKey(Watcher) || !resScen.Roles.ContainsKey(Target))
                    return false;

                if (Claim == ResistanceRole.Red)
                {
                    if (resScen.Roles[Watcher] == ResistanceRole.Blue && resScen.Roles[Target] == ResistanceRole.Blue)
                    {
                        return false;
                    }
                }
                else if (Claim == ResistanceRole.Blue)
                {
                    if (resScen.Roles[Watcher] == ResistanceRole.Blue && resScen.Roles[Target] == ResistanceRole.Red)
                    {
                        return false;
                    }
                }
            }
            else if (scenario is SecretHitlerScenario secScen)
            {
                if (!secScen.Roles.ContainsKey(Watcher) || !secScen.Roles.ContainsKey(Target))
                    return false;

                if (Claim == ResistanceRole.Red)
                {
                    if (secScen.Roles[Watcher] == SecretHitlerRole.Blue && secScen.Roles[Target] == SecretHitlerRole.Blue)
                    {
                        return false;
                    }
                }
                else if (Claim == ResistanceRole.Blue)
                {
                    if (secScen.Roles[Watcher] == SecretHitlerRole.Blue && (secScen.Roles[Target] == SecretHitlerRole.Red || secScen.Roles[Target] == SecretHitlerRole.Hitler))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override void DrawInfo(Graphics gfx)
        {
            var color = Color.Blue;
            if (Claim == ResistanceRole.Red)
            {
                color = Color.Red;
            }
            else
            {

            }

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
