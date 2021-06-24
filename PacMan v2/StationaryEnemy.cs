using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    class StationaryEnemy:Enemy
    {
        public StationaryEnemy(int x, int y, char ch, char direction, int level, char role) : base(x, y, ch, direction, level, role) { }
        public StationaryEnemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction, role) { }
        public StationaryEnemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl, role) { }
        public StationaryEnemy(int x, int y, char ch, char role) : base(x, y, ch, role) { }
        public override void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2)
        {

        }
    }
}
