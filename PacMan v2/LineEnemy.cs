using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    class LineEnemy:Enemy
    {
        public LineEnemy(int x, int y, char ch, char direction, int level, char role) : base(x, y, ch, direction, level, role){}
        public LineEnemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction, role){}
        public LineEnemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl, role){}
        public LineEnemy(int x, int y, char ch, char role) : base(x, y, ch, role){}

        public override void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2)
        {
            if (direction == 'r') { GoInDirectionAndBounce(1, 0, L, D, U); }
            if (direction == 'l') { GoInDirectionAndBounce(-1, 0, L, D, U); }
            if (direction == 'u') { GoInDirectionAndBounce(0, -1, L, D, U); }
            if (direction == 'd') { GoInDirectionAndBounce(0, 1, L, D, U); }
        }
    }
}
