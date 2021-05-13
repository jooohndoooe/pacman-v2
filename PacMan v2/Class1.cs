using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    class Class1
    {
        public int x { get; set; }
        public int y { set; get; }
        public char[,] field { get; set; }
        public Table T { get; set; }
        public Class1() 
        {
            Random r = new Random();
            int a = r.Next() % 10 + 5;
            int b = r.Next() % 10 + 5;
            a = 37;
            b = 10;
            Table T = new Table(b,a);
            char[,] level = new char[3 * a, 3 * b];

            for (int i = 0; i < a; i++) {
                for (int j = 0; j < b; j++) {
                    level[3 * i, 3 * j] = '#'; level[3 * i + 1, 3 * j] = ' '; level[3 * i + 2, 3 * j] = '#';
                    level[3 * i, 3 * j + 1] = '#'; level[3 * i + 1, 3 * j + 1] = ' '; level[3 * i + 2, 3 * j + 1] = '#';
                    level[3 * i, 3 * j + 2] = '#'; level[3 * i + 1, 3 * j + 2] = '#'; level[3 * i + 2, 3 * j + 2] = '#';

                    if (T.u[j, i] == false) { level[3 * i + 1, 3 * j] = '|'; level[3 * i + 1, 3 * j + 1] = '|'; }
                    if (T.d[j, i] == false) { level[3 * i + 1, 3 * j + 2] = '|'; }
                    if (T.l[j, i] == false) { level[3 * i, 3 * j] = ' '; level[3 * i, 3 * j + 1] = ' '; }
                    if (T.r[j, i] == false) { level[3 * i + 2, 3 * j] = ' '; level[3 * i + 2, 3 * j + 1] = ' '; }
                }
            }
            field = new char[3 * a, 3 * b];
            this.x = 3 * a;
            this.y = 3 * b;
            this.field = level;
            this.T = T;
        }
    }
}
