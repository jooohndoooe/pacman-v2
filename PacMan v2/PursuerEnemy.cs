using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    class PursuerEnemy:Enemy
    {
        public PursuerEnemy(int x, int y, char ch, char direction, int level, char role) : base(x, y, ch, direction, level, role) { }
        public PursuerEnemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction, role) { }
        public PursuerEnemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl, role) { }
        public PursuerEnemy(int x, int y, char ch, char role) : base(x, y, ch, role) { }
        public override void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2)
        {
            this.slownessCounter++;
            if (this.slownessCounter % slowness == 0)
            {
                if (distance(P1.x, P1.y, L) < distance(P2.x, P2.y, L))
                {
                    GoToDestination(P1.x, P1.y, L, D, U);
                }
                else
                {
                    GoToDestination(P2.x, P2.y, L, D, U);
                }
            }
        }
    }
}
