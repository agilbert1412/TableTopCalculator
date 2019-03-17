﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TableTopCalculator.Resistance
{
    public class Mission : Information
    {
        public int NbMission { get; set; }
        public List<Player> Players { get; set; }
        public List<ResistanceRole> Result { get; set; }
        public int MinRedToFail { get; set; }

        public Mission(int number, List<Player> players, List<ResistanceRole> result, int minRedToFail)
        {
            NbMission = number;
            Players = players;
            Result = result;
            MinRedToFail = minRedToFail;
        }

        public override bool IsPossible(Scenario scenario)
        {
            var resistanceScenario = (ResistanceScenario)scenario;
            if (Players.Any(x => !resistanceScenario.Roles.ContainsKey(x)))
                return false;

            var nbPlayersRed = resistanceScenario.Roles.Count(x => Players.Contains(x.Key) && x.Value == ResistanceRole.Red);
            var nbPlayersBlue = Players.Count() - nbPlayersRed;

            var nbCardsRed = Result.Count(x => x == ResistanceRole.Red);
            var nbCardsBlue = Result.Count(x => x == ResistanceRole.Blue);

            if (nbCardsRed > nbPlayersRed)
            {
                return false;
            }
            if (nbPlayersRed == MinRedToFail && nbCardsRed < MinRedToFail)
            {
                return false;
            }
            return true;
        }

        public override void DrawInfo(Graphics gfx)
        {
            var nbCardsRed = Result.Count(x => x == ResistanceRole.Red);

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
            }
        }
    }
}
