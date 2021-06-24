using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Player:Entity
    {
        public int score { get; set; }
        public int lives { get; set; }
        public int health { get; set; }

        public Player(int x, int y, int PlayerNumber) : base(x, y, 'O', 'r', 1) { 
            this.score = 0;
            this.health = 100;
            this.lives = 3;
            if (PlayerNumber == 2) { 
                this.ch = '@'; 
            } 
        }
        public void Plus() { this.score++; }

        public void Teleport(Level L) 
        {
            Random r = new Random();
            int ran = r.Next();
            if (ran % 2 == 1)
            {
                int p = L.sizeX;
                int q = L.sizeY;
                q = r.Next() % (q - 2) + 1;
                p = r.Next() % (p - 2) + 1;
                if (L.field[p, q].lvl < this.lvl) { this.x = p; this.y = q; } else { Teleport(L); }
            }
        }

        public int GravityMove(Level L, DotField D, UpgradeField U, GravityField G)
        {
            char startingDirection = this.direction;
            int fallDamage=0;
            if (G.ActiveStatus)
            {
                if (G.force > 0)
                {
                    this.direction = 'd';
                    for (int i = 0; i < G.force; i++)
                    {
                        Go(L, D, U);
                        fallDamage++;
                    }
                }
                else
                {
                    this.direction = 'u';
                    for (int i = 0; i < -1 * G.force; i++)
                    {
                        Go(L, D, U);
                        fallDamage++;
                    }
                }
            }
            this.direction = startingDirection;
            return fallDamage;

        }

        public void GravityGo(Level L, DotField D, UpgradeField U, GravityField G)
        {
            int StartingY = this.y;
            int fallDamage = GravityMove(L, D, U, G);
            if (this.y != StartingY) { this.health -= fallDamage; }
            if (this.health < 1) { this.health=100; this.lives--; }            
            Go(L, D, U);
        }

        public int ClosestUpgradeX(Level L, UpgradeField U)
        {
            int minDistance = 1000;
            int minDistanceX = -1;
            int minDistanceY = -1;

            for (int i=0; i < L.sizeX; i++) 
            {
                for (int j = 0; j < L.sizeY; j++) 
                {
                    if (U.field[i, j].status == true && distance(i, j, L) < minDistance) 
                    {
                        minDistance = distance(i, j, L);
                        minDistanceX = i;
                        minDistanceY = j;
                    }
                }
            }

            return minDistanceX;
        }

        public int ClosestUpgradeY(Level L, UpgradeField U)
        {
            int minDistance = 1000;
            int minDistanceX = -1;
            int minDistanceY = -1;

            for (int i = 0; i < L.sizeX; i++)
            {
                for (int j = 0; j < L.sizeY; j++)
                {
                    if (U.field[i, j].status == true && distance(i, j, L) < minDistance)
                    {
                        minDistance = distance(i, j, L);
                        minDistanceX = i;
                        minDistanceY = j;
                    }
                }
            }

            return minDistanceY;
        }

        public int DistanceAvoidingEnemies(int destinationX, int destinationY, Level L, int carefullness)  
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

            if (EnemyInViscinity(L, carefullness)) { return 10000; }

            while (distanceArray[destinationX, destinationY] == 0)
            {

                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (L.field[i, j].lvl == 0 && distanceArray[i, j] == 0)
                        {
                            int minDistance = 10000;
                            if (distanceArrayBackup[i + 1, j] != 0 && distanceArrayBackup[i + 1, j] < minDistance && L.field[i + 1, j].lvl < this.lvl) { minDistance = distanceArrayBackup[i + 1, j]; }
                            if (distanceArrayBackup[i - 1, j] != 0 && distanceArrayBackup[i - 1, j] < minDistance && L.field[i - 1, j].lvl < this.lvl) { minDistance = distanceArrayBackup[i - 1, j]; }
                            if (distanceArrayBackup[i, j + 1] != 0 && distanceArrayBackup[i, j + 1] < minDistance && L.field[i, j + 1].lvl < this.lvl) { minDistance = distanceArrayBackup[i, j + 1]; }
                            if (distanceArrayBackup[i, j - 1] != 0 && distanceArrayBackup[i, j - 1] < minDistance && L.field[i, j - 1].lvl < this.lvl) { minDistance = distanceArrayBackup[i, j - 1]; }
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

        public bool EnemyInViscinity(Level L, int carefullness) 
        {
            //return false;
            carefullness = 5;
            for(int i = 0; i < L.EnemyCount; i++) 
            {
                if (L.enemies[i].lvl >= this.lvl)
                {
                    if (distance(L.enemies[i].x, L.enemies[i].y, L) < carefullness) { return true; }
                }
            }
            return false;
        }

        public void SetPoint(int x, int y, int previousX, int previousY, bool[,] visited, int[,] distance, int[,] distanceA, Level L) 
        {
            if (x >= 0 && x < L.sizeX && y >= 0 && y < L.sizeY && !visited[x, y] && L.field[x, y].lvl < this.lvl)
            {
                //visited[x, y] = true;
                distance[x, y] = distance[previousX, previousY] + 1;
                distanceA[x, y] = distance[x, y] + Math.Abs(this.x - x) + Math.Abs(this.y - y);
            }
        }

        public char FindPathAvoidingEnemies(int destinationX, int destinationY, Level L, int carefullness)
        {
            if (destinationX == this.x && destinationY == this.y) { return 'r'; }
            if (destinationX == this.x + 1 && destinationY == this.y) { return 'r'; }
            if (destinationX == this.x - 1 && destinationY == this.y) { return 'l'; }
            if (destinationY == this.y - 1 && destinationX == this.x) { return 'u'; }
            if (destinationY == this.y + 1 && destinationX == this.x) { return 'd'; }

            bool[,] visited = new bool[L.sizeX,L.sizeY];
            int[,] distance = new int[L.sizeX, L.sizeY];
            int[,] distanceA = new int[L.sizeX, L.sizeY];
            for (int i = 0; i < L.sizeX; i++) 
            {
                for (int j = 0; j < L.sizeY; j++) 
                {
                    visited[i, j] = false;
                    distance[i, j] = 1000000;
                    distanceA[i, j] = 1000000;
                }
            }
            visited[destinationX, destinationY] = true;
            distance[destinationX, destinationY] = 0;
            distanceA[destinationX, destinationY] = 0;

            int currentX = destinationX;
            int currentY = destinationY;

            while (!visited[this.x, this.y]) 
            {
                visited[currentX, currentY] = true;
                SetPoint(currentX - 1, currentY, currentX, currentY, visited, distance, distanceA, L);
                SetPoint(currentX + 1, currentY, currentX, currentY, visited, distance, distanceA, L);
                SetPoint(currentX, currentY - 1, currentX, currentY, visited, distance, distanceA, L);
                SetPoint(currentX, currentY + 1, currentX, currentY, visited, distance, distanceA, L);

                int min = 1000000;
                int minX = -1;
                int minY = -1;
                for (int i = 0; i < L.sizeX; i++) 
                {
                    for (int j = 0; j < L.sizeY; j++) 
                    {
                        if (!visited[i, j] && distanceA[i, j] < min) 
                        {
                            minX = i;
                            minY = j;
                            min = distanceA[i, j];
                        }
                    }
                }

                currentX = minX;
                currentY = minY;
            }

            if (visited[this.x + 1, this.y]) { return 'r'; }
            if (visited[this.x - 1, this.y]) { return 'l'; }
            if (visited[this.x, this.y - 1]) { return 'u'; }
            if (visited[this.x, this.y + 1]) { return 'd'; }
            return ' ';
            /*if (destinationX == this.x && destinationY == this.y) { return 'r'; }
            if (destinationX == this.x + 1 && destinationY == this.y) { return 'r'; }
            if (destinationX == this.x - 1 && destinationY == this.y) { return 'l'; }
            if (destinationY == this.y - 1 && destinationX == this.x) { return 'u'; }
            if (destinationY == this.y + 1 && destinationX == this.x) { return 'd'; }
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

            if (EnemyInViscinity(L, carefullness)) { return 'r'; }

            while (distanceArray[destinationX, destinationY] == 0)
            {

                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (L.field[i, j].lvl == 0 && distanceArray[i, j] == 0)
                        {
                            int min = 10000;
                            if (i < L.sizeX - 1)
                            {
                                if (distanceArrayBackup[i + 1, j] != 0 && distanceArrayBackup[i + 1, j] < min && L.field[i + 1, j].lvl < this.lvl) { min = distanceArrayBackup[i + 1, j]; }
                            }
                            if (i > 0)
                            {
                                if (distanceArrayBackup[i - 1, j] != 0 && distanceArrayBackup[i - 1, j] < min && L.field[i - 1, j].lvl < this.lvl) { min = distanceArrayBackup[i - 1, j]; }
                            }
                            if (j < L.sizeY - 1)
                            {
                                if (distanceArrayBackup[i, j + 1] != 0 && distanceArrayBackup[i, j + 1] < min && L.field[i, j + 1].lvl < this.lvl) { min = distanceArrayBackup[i, j + 1]; }
                            }
                            if (j > 0)
                            {
                                if (distanceArrayBackup[i, j - 1] != 0 && distanceArrayBackup[i, j - 1] < min && L.field[i, j - 1].lvl < this.lvl) { min = distanceArrayBackup[i, j - 1]; }
                            }
                            min++;
                            if (min < 10000)
                            {
                                distanceArray[i, j] = min;
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

            int distance = distanceArray[destinationX, destinationY];

            if (distance > 500) { return 'f'; }

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

            
            return ' ';*/
        }
    }
}
