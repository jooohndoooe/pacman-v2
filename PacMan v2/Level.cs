using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Level
    {
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        //public int MaxScore { get; set; }
        public int NumberOfEnemies { get; set; }
        public Enemy[] enemies { set; get; }
        public int NumberOfUpgrades { set; get; }
        public Point[,] field { set; get; }
        public int difficulty { set; get; }

        public Level(int a,int b, int ne, int nu, Point[,] points,int d)
        {
            enemies = new Enemy[ne];
            field = new Point[a, b];
            this.sizeX = a;
            this.sizeY = b;
            this.NumberOfEnemies = ne;

            for (int i = 0; i < ne; i++)
            {
                Random r = new Random();
                int x = r.Next() % sizeX;
                int z = 0;
                for (int j = 0; j < sizeY; j++) { if (points[x, j].lvl == 0) { z++; } }
                while (z == 0) 
                {
                    x = r.Next() % sizeX;
                    for (int j = 0; j < sizeY; j++) { if (points[x, j].lvl == 0) { z++; } }
                }
                int[] arr = new int[sizeY];
                z = -1;
                for (int j = 0; j < sizeY;j++) { if (points[x, j].lvl == 0) { z++; arr[z] = j; } }
                z++;
                int y = r.Next() % z;
                y = arr[y];
                int temp = nu;

                if (d == 1)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 's');
                }
                if (d == 2)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'l');
                }
                if (d == 3)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'r');
                }
                if (d == 4)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                }
                temp = nu;
                if (d == 5)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2)
                    {
                        z = r.Next() % 2;
                        if (z == 0) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                        if (z == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'g'); if (temp >= 2) { temp--; } }
                    }
                }
            }            

            this.NumberOfUpgrades = nu;
            this.field = points;
            this.difficulty = d;
        }

        public Level(int a, int b, int ne, int nu, char[,] points, int d)
        {
            enemies = new Enemy[ne];
            field = new Point[a, b];
            this.sizeX = a;
            this.sizeY = b;
            this.NumberOfEnemies = ne;

            for (int i = 0; i < ne; i++)
            {
                int temp = nu;
                Random r = new Random();
                again:
                int x = r.Next() % (sizeX-2); x++;
                int z = 0;
                int[] arr = new int[sizeY];
                z = -1;
                for (int j = 0; j < sizeY; j++) { if (points[x,j] == ' ') { z++; arr[z] = j; } }
                z++;
                if (z == 0) { goto again; }
                int y = r.Next() % z;
                y = arr[y];

                if (d == 1)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 's');
                }
                if (d == 2)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'l');
                }
                if (d == 3)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'r');
                }
                if (d == 4)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                }
                temp = nu;
                if (d == 5)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2)
                    {
                        z = r.Next() % 2;
                        if (z == 0) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                        if (z == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'g'); if (temp >= 2) { temp--; } }
                    }
                }
            }

            this.NumberOfUpgrades = nu;
            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    int f=0;
                    if (points[i,j] == '#') { f = 10; }
                    if (points[i,j] == '/') { f = 11; }
                    this.field[i,j] = new Point(i, j, points[i,j], f);
                }
            }
            this.difficulty = d;
        }

        public Level(int a, int b, int ne,int[,] arr, int nu, Point[,] points, int d)
        {
            enemies = new Enemy[ne];
            field = new Point[a, b];
            this.sizeX = a;
            this.sizeY = b;
            this.NumberOfEnemies = ne;

            for (int i = 0; i < ne; i++)
            {
                int x = arr[i, 0];
                int y = arr[i, 1];
                int temp = nu;

                if (d == 1)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 's');
                }
                if (d == 2)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'l');
                }
                if (d == 3)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'r');
                }
                if (d == 4)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                }
                temp = nu;
                if (d == 5)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2)
                    {
                        Random r = new Random();
                        int z = r.Next() % 2;
                        if (z == 0) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                        if (z == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'g'); if (temp >= 2) { temp--; } }
                    }
                }
            }

            this.NumberOfUpgrades = nu;
            this.field = points;
            this.difficulty = d;
        }

        public Level(int a, int b, int ne, int[,] arr, int nu, char[,] points, int d)
        {
            enemies = new Enemy[ne];
            field = new Point[a, b];
            this.sizeX = a;
            this.sizeY = b;
            this.NumberOfEnemies = ne;

            for (int i = 0; i < ne; i++)
            {
                int x = arr[i, 0];
                int y = arr[i, 1];
                int temp = nu;

                if (d == 1)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 's');
                }
                if (d == 2)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'l');
                }
                if (d == 3)
                {
                    this.enemies[i] = new Enemy(x, y, 'A', 1, 'r');
                }
                if (d == 4)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                }
                temp = nu;
                if (d == 5)
                {
                    if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(nu + 48), nu, 'p'); if (temp >= 2) { temp--; } }
                    if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                    if (i >= 2)
                    {
                        Random r = new Random();
                        int z = r.Next() % 2;
                        if (z == 0) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                        if (z == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'g'); if (temp >= 2) { temp--; } }
                    }
                }
            }

            this.NumberOfUpgrades = nu;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    int f = 0;
                    if (points[i, j] == '#') { f = 10; }
                    if (points[i, j] == '/') { f = 11; }
                    this.field[i, j] = new Point(i, j, points[i, j], f);
                }
            }
            this.difficulty = d;
        }

        public void Load()
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    field[i, j].Draw();
                }
            }
        }

        public char GetChar(int a, int b) 
        {
            return field[a, b].ch;
        }

        public int GetLvl(int a, int b) 
        {
            return field[a, b].lvl;
        }


    }
}
