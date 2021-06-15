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
        public int EnemyCount { get; set; }
        public Enemy[] enemies { set; get; }
        public int UpgradeCount { set; get; }
        public Point[,] field { set; get; }
        public int difficulty { set; get; }

        public static event EventHandler<DrawEventArgs> OnDraw;

        public Level(int sizeX,int sizeY, int EnemyCount, int UpgradeCount, Point[,] points, int difficulty)
        {
            SetBaseRandom(sizeX, sizeY, EnemyCount, UpgradeCount, ToBool(sizeX, sizeY, points), difficulty);

            this.field = points;
        }

        public Level(int sizeX, int sizeY, int EnemyCount, int UpgradeCount, char[,] points, int difficulty)
        {
            SetBaseRandom(sizeX, sizeY, EnemyCount, UpgradeCount, ToBool(sizeX, sizeY, points), difficulty);

            SetField(sizeX, sizeY, points);
        }

        public Level(int sizeX, int sizeY, int EnemyCount, int[,] EnemyPlacementArray, int UpgradeCount, Point[,] points, int difficulty)
        {
            SetBaseFixed(sizeX, sizeY, EnemyCount, EnemyPlacementArray, UpgradeCount, difficulty);

            this.field = points;      
        }


        public Level(int sizeX, int sizeY, int EnemyCount, int[,] EnemyPlacementArray, int UpgradeCount, char[,] points, int difficulty)
        {
            SetBaseFixed(sizeX, sizeY, EnemyCount, EnemyPlacementArray, UpgradeCount, difficulty);

            SetField(sizeX, sizeY, points);
        }

        public void Load()
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    OnDraw?.Invoke(this, new DrawEventArgs(i,j,field[i,j].ch) );
                    //field[i, j].Draw();
                }
            }
        }

        public bool[,] ToBool(int sizeX, int sizeY, char[,] points)
        {
            bool[,] pointsBool = new bool[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    pointsBool[i, j] = false;
                    if (points[i, j] == ' ') { pointsBool[i, j] = true; }
                }
            }
            return pointsBool;
        }

        public bool[,] ToBool(int sizeX, int sizeY, Point[,] points)
        {
            bool[,] pointsBool = new bool[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    pointsBool[i, j] = false;
                    if (points[i, j].lvl == 0) { pointsBool[i, j] = true; }
                }
            }
            return pointsBool;
        }

        public void SetBaseRandom(int sizeX, int sizeY, int EnemyCount, int UpgradeCount, bool[,] points, int difficulty) 
        {
            SetBaseValues(sizeX, sizeY, EnemyCount, UpgradeCount, difficulty);
            Random r = new Random();
            for (int i = 0; i < EnemyCount; i++)
            {
                int x = r.Next() % (this.sizeX - 2); x++;
                int z = 0;
                int[] arr = new int[this.sizeY];
                z = -1;
                for (int j = 0; j < this.sizeY; j++) { if (points[x, j]) { z++; arr[z] = j; } }
                z++;
                if (z == 0) { i--; continue; }
                int y = r.Next() % z;
                y = arr[y];

                SetEnemy(x, y, UpgradeCount, i, difficulty);
            }
        }

        public void SetBaseFixed(int sizeX, int sizeY, int EnemyCount, int[,] EnemyPlacementArray, int UpgradeCount, int difficulty) 
        {
            SetBaseValues(sizeX, sizeY, EnemyCount, UpgradeCount, difficulty);
            Random r = new Random();
            for (int i = 0; i < this.EnemyCount; i++)
            {
                SetEnemy(EnemyPlacementArray[i, 0], EnemyPlacementArray[i, 1], this.UpgradeCount, i, this.difficulty);
            }
        }

        public void SetEnemy(int x, int y, int UpgradeCount, int i, int difficulty) 
        {
            int temp = UpgradeCount - i;
            Random r = new Random();
            if (difficulty == 1)
            {
                this.enemies[i] = new Enemy(x, y, 'A', 1, 's');
            }
            if (difficulty == 2)
            {
                this.enemies[i] = new Enemy(x, y, 'A', 1, 'l');
            }
            if (difficulty == 3)
            {
                this.enemies[i] = new Enemy(x, y, 'A', 1, 'r');
            }
            if (difficulty == 4)
            {
                if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'p'); if (temp >= 2) { temp--; } }
                if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                if (i >= 2) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
            }

            if (difficulty == 5)
            {
                if (i == 0) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'f'); if (temp >= 2) { temp--; } }
                if (i == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'i'); if (temp >= 2) { temp--; } }
                if (i >= 2)
                {
                    int z = r.Next() % 2;
                    if (z == 0) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'r'); if (temp >= 2) { temp--; } }
                    if (z == 1) { this.enemies[i] = new Enemy(x, y, (char)(temp + 48), temp, 'g'); if (temp >= 2) { temp--; } }
                }
            }
        }

        public void SetBaseValues(int sizeX, int sizeY, int EnemyCount, int UpgradeCount, int difficulty) 
        {
            enemies = new Enemy[EnemyCount];
            field = new Point[sizeX, sizeY];
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.EnemyCount = EnemyCount;
            this.UpgradeCount = UpgradeCount;
            this.difficulty = difficulty;
        }

        public void SetField(int sizeX, int sizeY, char[,] points) 
        {
            for (int i = 0; i < this.sizeX; i++)
            {
                for (int j = 0; j < this.sizeY; j++)
                {
                    int PointLvl = 0;
                    if (points[i, j] == '#') { PointLvl = 10; }
                    this.field[i, j] = new Point(i, j, points[i, j], PointLvl);
                }
            }
        }

        public Level(Level L, DotField D, UpgradeField U, Player P1, Player P2, Point P) 
        {
            SetBaseValues(L.sizeX, L.sizeY, L.EnemyCount, L.UpgradeCount, L.difficulty);
            for (int i = 0; i < L.sizeX; i++) {
                for (int j = 0; j < L.sizeY; j++) {
                    this.field[i, j] = L.field[i, j];
                    if (D.field[i, j].status) { this.field[i, j] = new Point(i,j,'.'); }
                    if (U.field[i, j].status) { this.field[i, j] = new Point(i, j, '&'); }
                    if (L.difficulty == 2)
                    {
                        if (Math.Sqrt((i - P1.x) * (i - P1.x) + (j - P1.y) * (j - P1.y)) > 3) {
                            if ((P2.x == 0 && P2.y == 0)|| Math.Sqrt((i - P2.x) * (i - P2.x) + (j - P2.y) * (j - P2.y)) > 3) { 
                                this.field[i, j] = new Point(i, j, ' '); 
                            }
                        }
                    }
                }
            }


            for (int i = 0; i < L.EnemyCount; i++) 
            {
                if (L.enemies[i].x != 0 || L.enemies[i].y != 0)
                {
                    this.field[L.enemies[i].x, L.enemies[i].y] = new Point(L.enemies[i].x, L.enemies[i].y, L.enemies[i].ch);
                }
            }

            this.field[P1.x, P1.y] = new Point(P1.x, P1.y, P1.ch);
            if (P2.x != 0 || P2.y != 0)
            {
                this.field[P2.x, P2.y] = new Point(P2.x, P2.y, P2.ch);
            }
            this.field[P.x, P.y] = P;


        }
        public Level(Level L,Player P1)
        {
            SetBaseValues(L.sizeX, L.sizeY, L.EnemyCount, L.UpgradeCount, L.difficulty);
            for (int i = 0; i < L.sizeX; i++)
            {
                for (int j = 0; j < L.sizeY; j++)
                {
                    this.field[i, j] = L.field[i, j];
                }
            }
            this.field[P1.x, P1.y] = new Point(P1.x, P1.y, P1.ch);
        }


        public void SetFinishOutLine(Point finish) 
        {
            if (finish == null) { return; }
            SetBarrier(finish.x + 1, finish.y, 1);
            SetBarrier(finish.x - 1, finish.y, 1);
            SetBarrier(finish.x, finish.y + 1, 1);
            SetBarrier(finish.x, finish.y - 1, 1);
        }

        public void SetBarrier(int x, int y, int lvl) 
        {
            if (this.field[x, y].ch == ' ')
            {
                this.field[x, y] = new Point(x, y, 'B', lvl);
            }
        }
    }
}
