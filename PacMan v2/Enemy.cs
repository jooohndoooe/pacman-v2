using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Enemy:Entity
    {
        public char role { get; set; }

        public Enemy(int a, int b, char _ch, char d, int l, char r) : base(a, b, _ch, d, l) { this.role = r; }
        public Enemy(int a, int b, char _ch, char d, char r) : base(a, b, _ch, d) { this.role = r; }
        public Enemy(int a, int b, char _ch, int l, char r) : base(a, b, _ch, l) { this.role = r; }
        public Enemy(int a, int b, char _ch, char r) : base(a, b, _ch) { this.role = r; }

        public void AssignRole(char _ch) 
        {
            this.role = _ch;
        }

        public void Go(Level L, DotField D, UpgradeField U) 
        {
            if (role == 's') 
            { 
            //Yup, he's stationary
            }
            if (role == 'l')
            {
                if (direction == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } else { direction = 'l'; } }
                if (direction == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } else { direction = 'r'; } }
                if (direction == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } else { direction = 'd'; } }
                if (direction == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } else { direction = 'u'; } }
            }

            Load();
        }
    }
}
