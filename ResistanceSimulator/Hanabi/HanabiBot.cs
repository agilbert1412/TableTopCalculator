using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator.Hanabi
{
    public class HanabiBot
    {
        private List<HanabiCard> _allCards;
        private List<HanabiPotentialCard> _currentHand;

        public void NewGame(List<HanabiCard> entireDeck)
        {
            _allCards = entireDeck.Select(x => x.Clone()).ToList();
            _currentHand = new List<HanabiPotentialCard>();
        }
    }
}
