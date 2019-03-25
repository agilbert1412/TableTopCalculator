using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TableTopCalculator.Hanabi
{
    public class HanabiPotentialCard
    {
        public List<HanabiCard> Possibilities { get; set; }

        public HanabiPotentialCard(List<HanabiCard> currentDeck)
        {
            Possibilities = currentDeck.Select(x => x.Clone()).ToList();
        }

        public void RemovePossibilities(List<HanabiCard> impossibleOptions)
        {
            foreach(HanabiCard option in impossibleOptions)
            {
                RemovePossibility(option);
            }
        }

        public void RemovePossibility(HanabiCard card)
        {
            Possibilities = Possibilities.Where(x => !x.Equals(card)).ToList();
        }

        public void AddClue(int num, bool isPositive)
        {
            Possibilities = Possibilities.Where(x => x.Number.Equals(num) == isPositive).ToList();
        }

        public void AddClue(Color col, bool isPositive)
        {
            Possibilities = Possibilities.Where(x => x.Color.Equals(col) == isPositive).ToList();
        }
    }
}
