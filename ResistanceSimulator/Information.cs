using System.Drawing;

namespace TableTopCalculator
{
    public abstract class Information
    {
        public abstract bool IsPossible(Scenario scenario);

        public abstract void DrawInfo(Graphics gfx);
    }
}
