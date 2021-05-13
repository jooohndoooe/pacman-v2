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

        public Enemy(int a, int b, char _ch, char d, int l, char r) : base(a, b, _ch, d, l) { this.role = r; }
        public Enemy(int a, int b, char _ch, char d, char r) : base(a, b, _ch, d) { this.role = r; }
        public Enemy(int a, int b, char _ch, int l, char r) : base(a, b, _ch, l) { this.role = r; }
        public Enemy(int a, int b, char _ch, char r) : base(a, b, _ch) { this.role = r; }

        public void AssignRole(char _ch) 
        {
            this.role = _ch;
        }

        public void Go(Level L, DotField D, UpgradeField U, Player P1, Player P2) 
        {
            if (role == 's') 
            { 
            //Yup, he's stationary
            }
            if (role == 'l')
            {
                if (direction == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } else { direction = 'l'; } }
                if (direction == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } else { direction = 'r'; } }
                if (direction == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } else { direction = 'd'; } }
                if (direction == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } else { direction = 'u'; } }
            }
            if (role == 'r')
            {
                if (direction == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } else { Random r = new Random(); int q = r.Next() % 2; if (q == 0) { direction = 'u'; } else { direction = 'd'; } } }
                if (direction == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } else { Random r = new Random(); int q = r.Next() % 2; if (q == 0) { direction = 'u'; } else { direction = 'd'; } } }
                if (direction == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } else { Random r = new Random(); int q = r.Next() % 2; if (q == 0) { direction = 'l'; } else { direction = 'r'; } } }
                if (direction == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } else { Random r = new Random(); int q = r.Next() % 2; if (q == 0) { direction = 'l'; } else { direction = 'r'; } } }
            }
            if (role == 'i') 
            {
                if (distance(P1.x, P1.y, L) < distance(P2.x, P2.y, L))
                {
                    if (FindPath(P1.x, P1.y, L) == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } }
                    if (FindPath(P1.x, P1.y, L) == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } }
                    if (FindPath(P1.x, P1.y, L) == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } }
                    if (FindPath(P1.x, P1.y, L) == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } }
                }
                else 
                {
                    if (FindPath(P2.x, P2.y, L) == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } }
                    if (FindPath(P2.x, P2.y, L) == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } }
                    if (FindPath(P2.x, P2.y, L) == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } }
                    if (FindPath(P2.x, P2.y, L) == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } }
                }
            }
            if (role == 'p')
            {
                Console.SetCursorPosition(50, 50);
                int px = PredictedX(L, P1);
                int py = PredictedY(L, P1);
                int px1 = PredictedX(L, P2);
                int py1 = PredictedY(L, P2);
                if (distance(P1.x, P1.y, L) <= distance(P2.x, P2.y, L))
                {
                    
                    if (FindPath(px, py, L) == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } }
                    if (FindPath(px, py, L) == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } }
                    if (FindPath(px, py, L) == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } }
                    if (FindPath(px, py, L) == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } }
                }
                else
                {
                    if (FindPath(px1, py1, L) == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } }
                    if (FindPath(px1, py1, L) == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } }
                    if (FindPath(px1, py1, L) == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } }
                    if (FindPath(px1, py1, L) == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } }
                }
            }

            Load();
        }

        public char FindPath(int a, int b, Level L) 
        {
            int[,] arr = new int[L.sizeX, L.sizeY];
            int[,] brr = new int[L.sizeX, L.sizeY];
            for (int i = 0; i < L.sizeX; i++) {
                for (int j = 0; j < L.sizeY; j++) {
                    arr[i, j] = 0;
                    brr[i, j] = 0;
                }
            }

            arr[x, y] = 1;
            brr[x, y] = 1;
            
            while (arr[a, b] == 0) {
                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (L.field[i, j].lvl == 0 && arr[i,j]==0)
                        {
                            int min = 10000;
                            if (brr[i + 1, j] != 0 && brr[i + 1, j] < min && L.field[i + 1, j].lvl == 0) { min = brr[i + 1, j]; }
                            if (brr[i - 1, j] != 0 && brr[i - 1, j] < min && L.field[i - 1, j].lvl == 0) { min = brr[i - 1, j]; }
                            if (brr[i, j + 1] != 0 && brr[i, j + 1] < min && L.field[i, j + 1].lvl == 0) { min = brr[i, j + 1]; }
                            if (brr[i, j - 1] != 0 && brr[i, j - 1] < min && L.field[i, j - 1].lvl == 0) { min = brr[i, j - 1]; }
                            min++;
                            if (min < 10000)
                            {
                                arr[i, j] = min;
                            }
                        }
                    }
                }

                for (int i = 0; i < L.sizeX; i++) {
                    for (int j = 0; j < L.sizeY; j++) {
                        brr[i, j] = arr[i, j];
                    }
                }
            }

            int c = arr[a,b];
            
            int p = a;
            int q = b;
            while (c > 2)
            {
                if (arr[p + 1, q] == c - 1) { p++; }
                else
                {
                    if (arr[p - 1, q] == c - 1) { p--; }
                    else
                    {
                        if (arr[p, q + 1] == c - 1) { q++; }
                        else
                        {
                            if (arr[p, q - 1] == c - 1) { q--; }
                        }
                    }
                }
                c--;
            }

            if (p == x + 1) { return 'r'; }
            if (p == x - 1) { return 'l'; }
            if (q == y + 1) { return 'd'; }
            if (q == y - 1) { return 'u'; }
            return ' ';
        }

        public int distance(int a, int b, Level L) 
        {
            int[,] arr = new int[L.sizeX, L.sizeY];
            int[,] brr = new int[L.sizeX, L.sizeY];
            for (int i = 0; i < L.sizeX; i++)
            {
                for (int j = 0; j < L.sizeY; j++)
                {
                    arr[i, j] = 0;
                    brr[i, j] = 0;
                }
            }

            arr[x, y] = 1;
            brr[x, y] = 1;

            while (arr[a, b] == 0)
            {
                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        if (L.field[i, j].lvl == 0 && arr[i, j] == 0)
                        {
                            int min = 10000;
                            if (brr[i + 1, j] != 0 && brr[i + 1, j] < min && L.field[i + 1, j].lvl == 0) { min = brr[i + 1, j]; }
                            if (brr[i - 1, j] != 0 && brr[i - 1, j] < min && L.field[i - 1, j].lvl == 0) { min = brr[i - 1, j]; }
                            if (brr[i, j + 1] != 0 && brr[i, j + 1] < min && L.field[i, j + 1].lvl == 0) { min = brr[i, j + 1]; }
                            if (brr[i, j - 1] != 0 && brr[i, j - 1] < min && L.field[i, j - 1].lvl == 0) { min = brr[i, j - 1]; }
                            min++;
                            if (min < 10000)
                            {
                                arr[i, j] = min;
                            }
                        }
                    }
                }

                for (int i = 0; i < L.sizeX; i++)
                {
                    for (int j = 0; j < L.sizeY; j++)
                    {
                        brr[i, j] = arr[i, j];
                    }
                }
            }

            return arr[a, b];
        }

        public int PredictedY(Level L, Player P) 
        {
            if (P.direction == 'l' || P.direction == 'r') { return P.x; }
            int t = P.x;
            while (L.field[t, P.y].lvl == 0) { if (P.direction == 'u') { t--; } if (P.direction == 'd') { t++; } }
            return t;
        }

        public int PredictedX(Level L, Player P)
        {
            if (P.direction == 'u' || P.direction == 'd') { return P.x; }
            int t = P.y;
            while (L.field[P.x, t].lvl == 0) { if (P.direction == 'l') { t--; } if (P.direction == 'r') { t++; } }
            return t;
        }
    }
}
