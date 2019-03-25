﻿using System.Drawing;
using TableTopCalculator.Resistance;
using TableTopCalculator.Resistance.Forms;
using TableTopCalculator.SecretHitler;

namespace TableTopCalculator.Generic.Forms
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
            if (scenario is ResistanceScenario resScenario)
            {
                if (!resScenario.Roles.ContainsKey(Watcher) || !resScenario.Roles.ContainsKey(Target))
                    return false;

                if (Claim == ResistanceRole.Red)
                {
                    if (resScenario.Roles[Watcher] == ResistanceRole.Blue && resScenario.Roles[Target] == ResistanceRole.Blue)
                    {
                        return false;
                    }
                }
                else if (Claim == ResistanceRole.Blue)
                {
                    if (resScenario.Roles[Watcher] == ResistanceRole.Blue && resScenario.Roles[Target] == ResistanceRole.Red)
                    {
                        return false;
                    }
                }
            }
            else if (scenario is SecretHitlerScenario secScenario)
            {
                if (!secScenario.Roles.ContainsKey(Watcher) || !secScenario.Roles.ContainsKey(Target))
                    return false;

                if (Claim == ResistanceRole.Red)
                {
                    if (secScenario.Roles[Watcher] == SecretHitlerRole.Blue && secScenario.Roles[Target] == SecretHitlerRole.Blue)
                    {
                        return false;
                    }
                }
                else if (Claim == ResistanceRole.Blue)
                {
                    if (secScenario.Roles[Watcher] == SecretHitlerRole.Blue && (secScenario.Roles[Target] == SecretHitlerRole.Red || secScenario.Roles[Target] == SecretHitlerRole.Hitler))
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
