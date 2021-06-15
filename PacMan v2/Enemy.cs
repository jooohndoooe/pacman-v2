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
        public int slowness { get; set; }
        public int slownessCounter { get; set; }
        public Enemy(int x, int y, char ch, char direction, int level, char role) : base(x, y, ch, direction, level) {
            SetBase(role);
        }
        public Enemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction, role) {
            SetBase(role);
        }
        public Enemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl) {
            SetBase(role);
        }
        public Enemy(int x, int y, char ch, char role) : base(x, y, ch) {
            SetBase(role);
        }

        public void SetBase(char role) 
        {
            this.role = role;
            this.slowness = 1;
            this.slownessCounter = 0;
            if (role == 'p') { this.slowness = 2; }
            if (role == 'i') { this.slowness = 3; }
            if (role == 'f') { this.slowness = 2; }
        }

        public void AssignRole(char _ch) 
        {
            this.role = _ch;
        }

        public void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
        {
            if (ch < '0' || ch > '9') 
            {
                if (direction == 'r') { this.ch = '>'; }
                if (direction == 'l') { this.ch = '<'; }
                if (direction == 'u') { this.ch = 'A'; }
                if (direction == 'd') { this.ch = 'V'; }
            }

            if (role == 's') 
            { 
            //Yup, he's stationary
            }
            if (role == 'l')
            {
                GoLine(L, D, U, P1, P2);
            }
            if (role == 'r')
            {
                GoRandom(L, D, U, P1, P2);
            }
            if (slownessCounter % slowness == 0)
            {
                if (role == 'p')
                {
                    GoPursuit(L, D, U, P1, P2);
                }
                if (role == 'i')
                {
                    GoIntersect(L, D, U, P1, P2);
                }
                if (role == 'f') 
                {
                    GoF(L, D, U, P1, P2);
                }
            }
            this.slownessCounter++;

            if (role == 'g')
            {
                GoGuard(L, D, U, P1, P2);
            }
        }

        public void GoLine(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
        {
            if (direction == 'r') { GoInDirectionAndBounce(1, 0, L, D, U); }
            if (direction == 'l') { GoInDirectionAndBounce(-1, 0, L, D, U); }
            if (direction == 'u') { GoInDirectionAndBounce(0, -1, L, D, U); }
            if (direction == 'd') { GoInDirectionAndBounce(0, 1, L, D, U); }
        }

        public void GoRandom(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
        {
            if (direction == 'r') { GoInDirectionAndBounceRandomly(1, 0, L, D, U); }
            if (direction == 'l') { GoInDirectionAndBounceRandomly(-1, 0, L, D, U); }
            if (direction == 'u') { GoInDirectionAndBounceRandomly(0, -1, L, D, U); }
            if (direction == 'd') { GoInDirectionAndBounceRandomly(0, 1, L, D, U); }
        }

        public void GoPursuit(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
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

        public void GoIntersect(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
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

        public void GoF(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
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
                    if (D.field[i, j].status) 
                    {
                        priority1[i, j] = L.sizeX * L.sizeY - P1.distance(i,j,L);
                        priority2[i, j] = L.sizeX * L.sizeY - P2.distance(i, j, L);

                    }
                    if (U.field[i, j].status) 
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
                    if (priority1[i,j] > maxPriority) { maxPriority = priority1[i, j]; maxX = i; maxY = j; }
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

        public void GoGuard(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
        {
            if (IsInSight(L, P1) == true)
            {
                if (IsInSight(L, P2) == true)
                {
                    if (distance(P1.x, P1.y, L) <= distance(P2.x, P2.y, L))
                    {
                        GoToDestination(P1.x, P1.y, L, D, U);
                    }
                    else
                    {
                        GoToDestination(P2.x, P2.y, L, D, U);
                    }
                }
            }
            else
            {
                if (IsInSight(L, P2) == true)
                {
                    GoToDestination(P2.x, P2.y, L, D, U);
                }
                else
                {
                    //Stay and wait baiting him
                }
            }
        }


        public void GravityGo(Level L, DotField D, UpgradeField U, Player P1, Player P2, GravityField G)
        {
            GravityMove(L, D, U, G);
            Go(L, D, U, P1, P2);
        }

        

        public int PredictedX(Level L, Player P) 
        {
            if (P.direction == 'd' || P.direction == 'u') { 
                return P.x; }
            int PredictedXCounter = P.x;
            while (PredictedXCounter < L.sizeX && PredictedXCounter >= 0 && L.field[PredictedXCounter, P.y].lvl == 0) { if (P.direction == 'l') { PredictedXCounter--; } if (P.direction == 'r') { PredictedXCounter++; } }
            if (P.direction == 'l') { PredictedXCounter++; }
            if (P.direction == 'r') { PredictedXCounter--; }
            return PredictedXCounter;
        }

        public int PredictedY(Level L, Player P)
        {
            if (P.direction == 'r' || P.direction == 'l') { return P.y; }
            int PredictedYCounter = P.y;
            while (PredictedYCounter < L.sizeY && PredictedYCounter >= 0 && L.field[P.x, PredictedYCounter].lvl == 0) { if (P.direction == 'u') { PredictedYCounter--; } if (P.direction == 'd') { PredictedYCounter++; } }
            if (P.direction == 'u') { PredictedYCounter++; }
            if (P.direction == 'd') { PredictedYCounter--; }
            return PredictedYCounter;
           
        }

        public bool IsInSight(Level L, Player P) {
            if (this.x != P.x && this.y != P.y) { return false; }

            if (this.x == P.x) {
                int min = P.y;
                int max = this.y;
                if (max < min) { int temp = min; min = max; max = temp; }
                for (int i = min; i < max; i++) { if (L.field[P.x, i].lvl > this.lvl) { return false; } }
            }

            if (this.y == P.y)
            {
                int min = P.x;
                int max = this.x;
                if (max < min) { int temp = min; min = max; max = temp; }
                for (int i = min; i < max; i++) { if (L.field[i, P.y].lvl > this.lvl) { return false; } }
            }

            return true;
        }
    }
}
