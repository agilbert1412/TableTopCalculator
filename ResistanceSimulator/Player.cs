using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTopCalculator
{
    public class Player
    {
        private static int IDGen = 0;

        public string Name { get; set; }
        public int ID { get; set; }

        public Player(int id, string name)
        {
            Name = name;
            ID = id;
            IDGen++;
        }
    }
}
