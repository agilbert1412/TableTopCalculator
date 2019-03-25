﻿using System.Drawing;

namespace TableTopCalculator.SecretHitler.Info
{
    public class NotHitlerInfo : Information
    {
        public Player PlayerWhoIsNotHitler { get; set; }

        public NotHitlerInfo(Player notHitler)
        {
            PlayerWhoIsNotHitler = notHitler;
        }

        public override bool IsPossible(Scenario scenario)
        {
            var hitlerScenario = (SecretHitlerScenario)scenario;

            return hitlerScenario.Roles[PlayerWhoIsNotHitler] != SecretHitlerRole.Hitler;
        }

        public override void DrawInfo(Graphics gfx)
        {
            /*var nbCardsRed = Result.Count(x => x == ResistanceRole.Red);

            var color = Color.Red;

            if (nbCardsRed < MinRedToFail)
            {
                color = Color.Blue;
            }

            using (var pen = new Pen(color, 2))
            {
                foreach (var p in Players)
                {
                    var rect = ResistanceSimulator.GetPlayerSquare(p.ID);

                    for (var i = -1; i < NbMission; i++)
                    {
                        rect.Inflate(3, 3);
                    }

                    gfx.DrawRectangle(pen, rect);
                }
            }*/
        }
    }
}
