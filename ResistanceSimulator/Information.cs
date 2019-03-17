using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator
{
    public abstract class Information
    {
        public abstract bool IsPossible(Scenario scenario);

        public abstract void DrawInfo(Graphics gfx);
    }
}
