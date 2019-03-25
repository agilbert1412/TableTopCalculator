using System.Drawing;

namespace TableTopCalculator.Hanabi
{
    public class HanabiCard
    {
        public int Number { get; }
        public Color Color { get; }

        public HanabiCard(int number, Color color)
        {
            Number = number;
            Color = color;
        }

        /*public virtual bool IsTouched(int numberClue)
        {
            return Number == numberClue;
        }

        public virtual bool IsTouched(Color colorClue)
        {
            return Color == colorClue;
        }*/

        public virtual HanabiCard Clone()
        {
            return new HanabiCard(Number, Color);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is HanabiCard otherCard)
            {
                return Number == otherCard.Number && Color == otherCard.Color;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 13;
                hash = (hash * 17) + Number;
                hash = (hash * 17) + Color.GetHashCode();
                return hash;
            }
        }
    }
}
