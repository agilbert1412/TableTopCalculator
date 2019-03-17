using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TableTopCalculator.SecretHitler
{
    public class Election : Information
    {
        public int NbElection { get; set; }
        public KeyValuePair<Player, List<SecretHitlerRole>> President { get; set; }
        public KeyValuePair<Player, List<SecretHitlerRole>> Chancellor { get; set; }
        public SecretHitlerRole Result { get; set; }
        public bool IsRedWinOnHitlerChancellor { get; set; }

        public Election(
            int number,
            KeyValuePair<Player, List<SecretHitlerRole>> president,
            KeyValuePair<Player, List<SecretHitlerRole>> chancellor,
            SecretHitlerRole result,
            bool isRedWinOnHitlerChancellor)
        {
            NbElection = number;
            President = president;
            Chancellor = chancellor;
            Result = result;
            IsRedWinOnHitlerChancellor = isRedWinOnHitlerChancellor;
        }

        public override bool IsPossible(Scenario scenario)
        {
            var hitlerScenario = (SecretHitlerScenario)scenario;

            if (IsRedWinOnHitlerChancellor)
            {
                if (hitlerScenario.Roles[Chancellor.Key] == SecretHitlerRole.Hitler)
                {
                    return false;
                }
            }

            var cardsMission = hitlerScenario.CardColorsOrder.GetRange(NbElection * 3, 3);
            var nbBlueScen = cardsMission.Count(x => x == SecretHitlerRole.Blue);
            var nbRedScen = cardsMission.Count(x => x == SecretHitlerRole.Red);

            if (Result == SecretHitlerRole.Blue && nbBlueScen < 1)
                return false;
            if (Result == SecretHitlerRole.Red && nbRedScen < 1)
                return false;

            if (hitlerScenario.Roles[President.Key] == SecretHitlerRole.Blue)
            {
                var nbBlueSeen = President.Value.Count(x => x == SecretHitlerRole.Blue);
                var nbRedSeen = President.Value.Count(x => x == SecretHitlerRole.Red);

                if (nbBlueScen != nbBlueSeen || nbRedScen != nbRedSeen)
                    return false;

                nbBlueScen -= President.Value.First() == SecretHitlerRole.Blue ? 1 : 0;
                nbRedScen -= President.Value.First() == SecretHitlerRole.Red ? 1 : 0;
            }

            if (hitlerScenario.Roles[Chancellor.Key] == SecretHitlerRole.Blue)
            {
                var nbBlueSeen = Chancellor.Value.Count(x => x == SecretHitlerRole.Blue);
                var nbRedSeen = Chancellor.Value.Count(x => x == SecretHitlerRole.Red);

                if (hitlerScenario.Roles[President.Key] == SecretHitlerRole.Blue)
                {
                    if (nbBlueScen != nbBlueSeen || nbRedScen != nbRedSeen)
                    {
                        return false;
                    }
                }

                if (nbBlueSeen > nbBlueScen || nbRedSeen > nbRedScen)
                    return false;

                if (nbBlueSeen > 0 && Result != SecretHitlerRole.Blue)
                    return false;
            }

            return true;
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
