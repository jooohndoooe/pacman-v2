using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public abstract class Entity
    {
        public int x { get; set; }
        public int y { get; set; }
        public int lvl { get; set; }
        public char ch { get; set; }
        public char direction { get; set; }
        
        public Entity(int x,int y,char ch, char direction, int lvl)
        {
            SetBase(x, y, ch, direction, lvl);
        }
        public Entity(int x,int y,char ch,char direction)
        {
            SetBase(x, y, ch, direction, 0);
        }
        public Entity(int x, int y, char ch)
        {
            SetBase(x, y, ch, 'r', 0);
        }
        public Entity(int x, int y, char ch, int lvl)
        {
            SetBase(x, y, ch, 'r', lvl);
        }

        public void SetBase(int x, int y, char ch, char direction, int lvl) 
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.direction = direction;
            this.lvl = lvl;
        }

        public void ChangeDirection(char direction) 
        {
            if (direction == 'r' || direction == 'l' || direction == 'd' || direction == 'u') 
            {
                this.direction = direction;
            }
        }
        public void Go(Level L,DotField D,UpgradeField U) 
        {
            if (this.ch != ' ')
            {
                
                if (direction == 'r') { GoInDirection(1, 0, L, D, U); }
                if (direction == 'l') { GoInDirection(-1, 0, L, D, U); }
                if (direction == 'u') { GoInDirection(0, -1, L, D, U); }
                if (direction == 'd') { GoInDirection(0, 1, L, D, U); }
            }
        }

        public void Go(Level L)
        {
            if (this.ch != ' ')
            {
                if (direction == 'r') { GoInDirection(1, 0, L); }
                if (direction == 'l') { GoInDirection(-1, 0, L); }
                if (direction == 'u') { GoInDirection(0, -1, L); }
                if (direction == 'd') { GoInDirection(0, 1, L); }
            }
        }

        public void GoInDirection(int deltaX, int deltaY, Level L, DotField D, UpgradeField U)
        {
            if (L.field[(x + deltaX + L.sizeX) % L.sizeX, (y + deltaY + L.sizeY) % L.sizeY].lvl < lvl)
            {
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
        }

        public void GoInDirection(int deltaX, int deltaY, Level L)
        {
            if (L.field[(x + deltaX + L.sizeX) % L.sizeX, (y + deltaY + L.sizeY) % L.sizeY].lvl < lvl)
            {
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
        }

        public void GoInDirectionAndBounce(int deltaX, int deltaY, Level L, DotField D, UpgradeField U) 
        {
            if (L.field[(x + deltaX) % L.sizeX, (y + deltaY) % L.sizeY].lvl < lvl)
            {
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
            else 
            {
                if (deltaX == 1) { this.direction = 'l'; }
                if (deltaX == -1) { this.direction = 'r'; }
                if (deltaY == -1) { this.direction = 'u'; }
                if (deltaY == 1) { this.direction = 'd'; }
            }
        }

        public void GoInDirectionAndBounceRandomly(int deltaX, int deltaY, Level L, DotField D, UpgradeField U)
        {
            if (L.field[(x + deltaX) % L.sizeX, (y + deltaY) % L.sizeY].lvl < lvl)
            {
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
            else
            {
                Random r = new Random();
                int RandomDirectionSwitch = r.Next() % 2;
                if (deltaX != 0) 
                {
                    if (RandomDirectionSwitch == 0) 
                    { 
                        this.direction = 'u'; 
                    }
                    else 
                    {
                        this.direction = 'd';
                    }
                }
                if (deltaY != 0)
                {
                    if (RandomDirectionSwitch == 0)
                    {
                        this.direction = 'l';
                    }
                    else
                    {
                        this.direction = 'r';
                    }
                }
            }
        }

        public void GravityMove(Level L, DotField D, UpgradeField U, GravityField G) 
        {
            char startingDirection = this.direction;
            if (G.ActiveStatus) 
            {
                if (G.force > 0)
                {
                    this.direction = 'd';
                    for (int i = 0; i < G.force; i++) 
                    {
                        Go(L, D, U);
                    }
                }
                else
                {
                    this.direction = 'u';
                    for (int i = 0; i < -1 * G.force; i++) 
                    {
                        Go(L, D, U);
                    }
                }
            }
            this.direction = startingDirection;
        }

        public void GravityGo(Level L, DotField D, UpgradeField U, GravityField G) 
        {
            GravityMove(L, D, U, G);
            Go(L, D, U);
        }
        
        public void Load() 
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(ch);
        }

        public void Clear() 
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(' ');
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
                            int min = 10000;
                            if (distanceArrayBackup[i + 1, j] != 0 && distanceArrayBackup[i + 1, j] < min && L.field[i + 1, j].lvl < this.lvl) { min = distanceArrayBackup[i + 1, j]; }
                            if (distanceArrayBackup[i - 1, j] != 0 && distanceArrayBackup[i - 1, j] < min && L.field[i - 1, j].lvl < this.lvl) { min = distanceArrayBackup[i - 1, j]; }
                            if (distanceArrayBackup[i, j + 1] != 0 && distanceArrayBackup[i, j + 1] < min && L.field[i, j + 1].lvl < this.lvl) { min = distanceArrayBackup[i, j + 1]; }
                            if (distanceArrayBackup[i, j - 1] != 0 && distanceArrayBackup[i, j - 1] < min && L.field[i, j - 1].lvl < this.lvl) { min = distanceArrayBackup[i, j - 1]; }
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
                            if (i < L.sizeX - 1)
                            {
                                if (distanceArrayBackup[i + 1, j] != 0 && distanceArrayBackup[i + 1, j] < minDistance && L.field[i + 1, j].lvl < this.lvl) { minDistance = distanceArrayBackup[i + 1, j]; }
                            }
                            if (i > 0)
                            {
                                if (distanceArrayBackup[i - 1, j] != 0 && distanceArrayBackup[i - 1, j] < minDistance && L.field[i - 1, j].lvl < this.lvl) { minDistance = distanceArrayBackup[i - 1, j]; }
                            }
                            if (j < L.sizeY - 1)
                            {
                                if (distanceArrayBackup[i, j + 1] != 0 && distanceArrayBackup[i, j + 1] < minDistance && L.field[i, j + 1].lvl < this.lvl) { minDistance = distanceArrayBackup[i, j + 1]; }
                            }
                            if (j > 0)
                            {
                                if (distanceArrayBackup[i, j - 1] != 0 && distanceArrayBackup[i, j - 1] < minDistance && L.field[i, j - 1].lvl < this.lvl) { minDistance = distanceArrayBackup[i, j - 1]; }
                            }
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

        public bool CanPass(int x, int y, Level L) 
        {
            bool[,] visited = new bool[L.sizeX, L.sizeY];
            bool[,] AbleToPass = new bool[L.sizeX, L.sizeY];

            for (int i = 0; i < L.sizeX; i++) 
            {
                for (int j = 0; j < L.sizeY; j++) 
                {
                    visited[i, j] = false;
                    AbleToPass[i, j] = false;
                }
            }

            CanPass_rec(x, y, L, visited, AbleToPass, this.x, this.y);

            return AbleToPass[x, y];
        }

        public void CanPass_rec(int x, int y, Level L, bool[,] visited, bool[,] AbleToPass, int CurrentX, int CurrentY) 
        {
            List<int> DeltaPass = new List<int>();

            if (CurrentX < L.sizeX)
            {
                if (!visited[CurrentX + 1, CurrentY])
                {
                    visited[CurrentX + 1, CurrentY] = true;
                    if (L.field[CurrentX + 1, CurrentY].lvl < this.lvl) 
                    { 
                        AbleToPass[CurrentX + 1, CurrentY] = true;
                        DeltaPass.Add(1);
                        DeltaPass.Add(0);
                    }
                }
            }
            if (CurrentX > 0)
            {
                if (!visited[CurrentX - 1, CurrentY])
                {
                    visited[CurrentX - 1, CurrentY] = true;
                    if (L.field[CurrentX - 1, CurrentY].lvl < this.lvl) 
                    { 
                        AbleToPass[CurrentX - 1, CurrentY] = true;
                        DeltaPass.Add(-1);
                        DeltaPass.Add(0);
                    }
                }
            }
            if (CurrentY < L.sizeY)
            {
                if (!visited[CurrentX, CurrentY + 1])
                {
                    visited[CurrentX , CurrentY + 1] = true;
                    if (L.field[CurrentX, CurrentY + 1].lvl < this.lvl) 
                    { 
                        AbleToPass[CurrentX, CurrentY + 1] = true;
                        DeltaPass.Add(0);
                        DeltaPass.Add(1);
                    }
                }
            }
            if (CurrentY > 0)
            {
                if (!visited[CurrentX, CurrentY - 1])
                {
                    visited[CurrentX, CurrentY - 1] = true;
                    if (L.field[CurrentX, CurrentY - 1].lvl < this.lvl) 
                    { 
                        AbleToPass[CurrentX, CurrentY - 1] = true;
                        DeltaPass.Add(0);
                        DeltaPass.Add(-1);
                    }
                }
            }

            if (visited[x, y]) { return; }

            for (int i = 0; i < DeltaPass.Count / 2; i++) 
            {
                CanPass_rec(x, y, L, visited, AbleToPass, CurrentX + DeltaPass[2 * i], CurrentY + DeltaPass[2 * i + 1]);
            }
        }

    }
}
