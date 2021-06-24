using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    class CalculatorEnemy:Enemy
    {
        public CalculatorEnemy(int x, int y, char ch, char direction, int level, char role) : base(x, y, ch, direction, level, role) { }
        public CalculatorEnemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction, role) { }
        public CalculatorEnemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl, role) { }
        public CalculatorEnemy(int x, int y, char ch, char role) : base(x, y, ch, role) { }
        public override void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2)
        {
            this.slownessCounter++;
            if (this.slownessCounter % slowness == 0)
            {
                int[,] priority1 = new int[L.sizeX, L.sizeY];
                int[,] priority2 = new int[L.sizeX, L.sizeY];

                int maxPriority = 0;
                int maxX = -1;
                int maxY = -1;

                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (D.field[i, j].status && L.field[i, j].ch == ' ')
                        {
                            priority1[i, j] = L.sizeX * L.sizeY - P1.distance(i, j, L);
                            priority2[i, j] = L.sizeX * L.sizeY - P2.distance(i, j, L);

                        }
                        if (U.field[i, j].status && L.field[i, j].ch == ' ')
                        {
                            priority1[i, j] = L.sizeX * L.sizeY - P1.distance(i, j, L) * 20;
                            priority2[i, j] = L.sizeX * L.sizeY - P2.distance(i, j, L) * 20;
                        }
                    }
                }

                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (priority1[i, j] > maxPriority) { maxPriority = priority1[i, j]; maxX = i; maxY = j; }
                        if (priority2[i, j] > maxPriority) { maxPriority = priority2[i, j]; maxX = i; maxY = j; }

                    }
                }



                if (distance(P1.x, P1.y, L) <= distance(P2.x, P2.y, L))
                {
                    if (IsInSight(L, P1) == false)
                    {
                        GoToDestination(maxX, maxY, L, D, U);
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
                        GoToDestination(maxX, maxY, L, D, U);
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
