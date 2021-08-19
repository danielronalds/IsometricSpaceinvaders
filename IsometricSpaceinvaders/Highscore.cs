using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometricSpaceinvaders
{
    class Highscore
    {

        public Highscore(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }

        public int Score { get; set; }

    }
}
