using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator.Hanabi
{
    public class HanabiCard
    {
        public int Number { get; set; }
        public Color Color { get; set; }

        public HanabiCard(int number, Color color)
        {
            Number = number;
            Color = color;
        }

        public virtual bool IsTouched(int numberClue)
        {
            return Number == numberClue;
        }

        public virtual bool IsTouched(Color colorClue)
        {
            return Color == colorClue;
        }

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
    }
}
