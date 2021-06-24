using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    class IntersectorEnemy:Enemy
    {
        public IntersectorEnemy(int x, int y, char ch, char direction, int level, char role) : base(x, y, ch, direction, level, role) { }
        public IntersectorEnemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction, role) { }
        public IntersectorEnemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl, role) { }
        public IntersectorEnemy(int x, int y, char ch, char role) : base(x, y, ch, role) { }
        public override void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2)
        {
            this.slownessCounter++;
            if (this.slownessCounter % slowness == 0)
            {
                int P1PredictedX = PredictedX(L, P1);
                int P1PredictedY = PredictedY(L, P1);
                int P2PredictedX = PredictedX(L, P2);
                int P2PredictedY = PredictedY(L, P2);

                if (distance(P1.x, P1.y, L) <= distance(P2.x, P2.y, L))
                {
                    if (IsInSight(L, P1) == false)
                    {
                        GoToDestination(P1PredictedX, P1PredictedY, L, D, U);
                    }
                    else
                    {
                        GoToDestination(P1.x, P1.y, L, D, U);
                    }
                }
                else
                {
                    if (IsInSight(L, P2) == false)
                    {
                        GoToDestination(P2PredictedX, P2PredictedY, L, D, U);
                    }
                    else
                    {
                        GoToDestination(P2.x, P2.y, L, D, U);
                    }
                }
            }
        }
    }
}
