using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    class Player:Entity
    {
        public int score { get; set; }

        public Player(int a, int b, int c) : base(a, b, 'O', 'r', 1) { this.score = 0; if (c == 2) { this.ch = '@'; } }
        public void Plus() { this.score++; }
    }
}
