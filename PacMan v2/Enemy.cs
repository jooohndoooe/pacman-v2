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
            this.role = role;
            this.slowness = 1;
            this.slownessCounter = 0;
            if (role == 'p') { this.slowness = 2; }
            if (role == 'i') { this.slowness = 3; } 
        }
        public Enemy(int x, int y, char ch, char direction, char role) : base(x, y, ch, direction) { 
            this.role = role;
            this.slowness = 1;
            this.slownessCounter = 0;
            if (role == 'p') { this.slowness = 2; }
            if (role == 'i') { this.slowness = 3; }
        }
        public Enemy(int x, int y, char ch, int lvl, char role) : base(x, y, ch, lvl) {
            this.role = role;
            this.slowness = 1;
            this.slownessCounter = 0;
            if (role == 'p') { this.slowness = 2; }
            if (role == 'i') { this.slowness = 3; }
        }
        public Enemy(int x, int y, char ch, char role) : base(x, y, ch) { 
            this.role = role;
            this.slowness = 1;
            this.slownessCounter = 0;
            if (role == 'p') { this.slowness = 2; }
            if (role == 'i') { this.slowness = 3; }
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
                if (direction == 'r') { GoInDirectionAndBounce(1, 0, L, D, U); }
                if (direction == 'l') { GoInDirectionAndBounce(-1, 0, L, D, U); }
                if (direction == 'u') { GoInDirectionAndBounce(0, -1, L, D, U); }
                if (direction == 'd') { GoInDirectionAndBounce(0, 1, L, D, U); }
            }
            if (role == 'r')
            {
                if (direction == 'r') { GoInDirectionAndBounceRandomly(1, 0, L, D, U); }
                if (direction == 'l') { GoInDirectionAndBounceRandomly(-1, 0, L, D, U); }
                if (direction == 'u') { GoInDirectionAndBounceRandomly(0, -1, L, D, U); }
                if (direction == 'd') { GoInDirectionAndBounceRandomly(0, 1, L, D, U); }
            }
            if (slownessCounter % slowness == 0)
            {
                if (role == 'p')
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
                if (role == 'i')
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
            this.slownessCounter++;

            if (role == 'g')
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

           //Load();
        }

        public void GravityGo(Level L, DotField D, UpgradeField U, Player P1, Player P2, GravityField G)
        {
            GravityMove(L, D, U, G);
            Go(L, D, U, P1, P2);
        }

        public void GoToDestination(int destinationX, int destinationY, Level L, DotField D, UpgradeField U) 
        {
            if (FindPath(destinationX, destinationY, L) == 'r') { GoInDirection(1, 0, L, D, U); }
            if (FindPath(destinationX, destinationY, L) == 'l') { GoInDirection(-1, 0, L, D, U); }
            if (FindPath(destinationX, destinationY, L) == 'u') { GoInDirection(0, -1, L, D, U); }
            if (FindPath(destinationX, destinationY, L) == 'd') { GoInDirection(0, 1, L, D, U); }
        }

        public char FindPath(int destinationX, int destinationY, Level L) 
        {
            int[,] distanceArray = new int[L.sizeX, L.sizeY];
            int[,] distanceArrayBackup = new int[L.sizeX, L.sizeY];
            for (int i = 0; i < L.sizeX; i++) {
                for (int j = 0; j < L.sizeY; j++) {
                    distanceArray[i, j] = 0;
                    distanceArrayBackup[i, j] = 0;
                }
            }

            distanceArray[x, y] = 1;
            distanceArrayBackup[x, y] = 1;
            
            while (distanceArray[destinationX, destinationY] == 0) {
                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (L.field[i, j].lvl == 0 && distanceArray[i,j]==0)
                        {
                            int min = 10000;
                            if (distanceArrayBackup[i + 1, j] != 0 && distanceArrayBackup[i + 1, j] < min && L.field[i + 1, j].lvl == 0) { min = distanceArrayBackup[i + 1, j]; }
                            if (distanceArrayBackup[i - 1, j] != 0 && distanceArrayBackup[i - 1, j] < min && L.field[i - 1, j].lvl == 0) { min = distanceArrayBackup[i - 1, j]; }
                            if (distanceArrayBackup[i, j + 1] != 0 && distanceArrayBackup[i, j + 1] < min && L.field[i, j + 1].lvl == 0) { min = distanceArrayBackup[i, j + 1]; }
                            if (distanceArrayBackup[i, j - 1] != 0 && distanceArrayBackup[i, j - 1] < min && L.field[i, j - 1].lvl == 0) { min = distanceArrayBackup[i, j - 1]; }
                            min++;
                            if (min < 10000)
                            {
                                distanceArray[i, j] = min;
                            }
                        }
                    }
                }

                for (int i = 0; i < L.sizeX; i++) {
                    for (int j = 0; j < L.sizeY; j++) {
                        distanceArrayBackup[i, j] = distanceArray[i, j];
                    }
                }
            }

            int distance = distanceArray[destinationX,destinationY];
            
            int xDirection = destinationX;
            int yDirection = destinationY;
            while (distance > 2)
            {
                if (distanceArray[xDirection + 1, yDirection] == distance - 1) { xDirection++; }
                else
                {
                    if (distanceArray[xDirection - 1, yDirection] == distance - 1) { xDirection--; }
                    else
                    {
                        if (distanceArray[xDirection, yDirection + 1] == distance - 1) { yDirection++; }
                        else
                        {
                            if (distanceArray[xDirection, yDirection - 1] == distance - 1) { yDirection--; }
                        }
                    }
                }
                distance--;
            }

            if (xDirection == x + 1) { return 'r'; }
            if (xDirection == x - 1) { return 'l'; }
            if (yDirection == y + 1) { return 'd'; }
            if (yDirection == y - 1) { return 'u'; }
            return ' ';
        }

        public int distance(int destinationX, int destinationY, Level L) 
        {
            int[,] distanceArray = new int[L.sizeX, L.sizeY];
            int[,] distanceArrayBackup = new int[L.sizeX, L.sizeY];
            for (int i = 0; i < L.sizeX; i++)
            {
                for (int j = 0; j < L.sizeY; j++)
                {
                    distanceArray[i, j] = 0;
                    distanceArrayBackup[i, j] = 0;
                }
            }

            distanceArray[x, y] = 1;
            distanceArrayBackup[x, y] = 1;

            while (distanceArray[destinationX, destinationY] == 0)
            {
                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (L.field[i, j].lvl == 0 && distanceArray[i, j] == 0)
                        {
                            int minDistance = 10000;
                            if (distanceArrayBackup[i + 1, j] != 0 && distanceArrayBackup[i + 1, j] < minDistance && L.field[i + 1, j].lvl == 0) { minDistance = distanceArrayBackup[i + 1, j]; }
                            if (distanceArrayBackup[i - 1, j] != 0 && distanceArrayBackup[i - 1, j] < minDistance && L.field[i - 1, j].lvl == 0) { minDistance = distanceArrayBackup[i - 1, j]; }
                            if (distanceArrayBackup[i, j + 1] != 0 && distanceArrayBackup[i, j + 1] < minDistance && L.field[i, j + 1].lvl == 0) { minDistance = distanceArrayBackup[i, j + 1]; }
                            if (distanceArrayBackup[i, j - 1] != 0 && distanceArrayBackup[i, j - 1] < minDistance && L.field[i, j - 1].lvl == 0) { minDistance = distanceArrayBackup[i, j - 1]; }
                            minDistance++;
                            if (minDistance < 10000)
                            {
                                distanceArray[i, j] = minDistance;
                            }
                        }
                    }
                }

                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        distanceArrayBackup[i, j] = distanceArray[i, j];
                    }
                }
            }

            return distanceArray[destinationX, destinationY];
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
