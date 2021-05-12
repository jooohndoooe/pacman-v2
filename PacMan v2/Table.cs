using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Table
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool[,] u { get; set; }
        public bool[,] r { get; set; }
        public bool[,] l { get; set; }
        public bool[,] d { get; set; }

        public Table(int a, int b)
        {
            this.x = a;
            this.y = b;
            u = new bool[a, b];
            r = new bool[a, b];
            d = new bool[a, b];
            l = new bool[a, b];
            for (int i = 0; i < a; i++) {
                for (int j = 0; j < b; j++) {
                    u[i, j] = true;
                    r[i, j] = true;
                    d[i, j] = true;
                    l[i, j] = true;
                }
            }

            while(isValid()==false)
            {
            again:
                Random z = new Random();
                int p = z.Next() % a;
                int q = z.Next() % b;
                int k = 0;
                int[] arr = new int[4];

                if (u[p, q] == true && p != 0)
                {
                    arr[k] = 1;
                    k++;
                }

                if (r[p, q] == true && q != b - 1)
                {
                    arr[k] = 2;
                    k++;
                }

                if (d[p, q] == true && p != a - 1)
                {
                    arr[k] = 3;
                    k++;
                }

                if (l[p, q] == true && q != 0)
                {
                    arr[k] = 4;
                    k++;
                }
                if (k == 0) { goto again; }

                k = z.Next() % k;
                k = arr[k];

                if (k == 1) { u[p, q] = false; d[p - 1, q] = false; }
                if (k == 2) { r[p, q] = false; l[p, q + 1] = false; }
                if (k == 3) { d[p, q] = false; u[p + 1, q] = false; }
                if (k == 4) { l[p, q] = false; r[p, q - 1] = false; }
            }

        }

        public bool isValid()
        {
            bool[,] arr = new bool[x, y];
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    arr[i, j] = false;
                }
            }
            arr[0, 0] = true;

            for (int k = 0; k < x * y; k++) 
            {
                for (int i = 0; i < x; i++) {
                    for (int j = 0; j < y; j++) {
                        if (i != 0)
                        {
                            if (u[i, j] == false && arr[i - 1, j] == true) { arr[i, j] = true; }
                        }
                        if (i != x - 1)
                        {
                            if (d[i, j] == false && arr[i + 1, j] == true) { arr[i, j] = true; }
                        }
                        if (j != y - 1)
                        {
                            if (r[i, j] == false && arr[i, j + 1] == true) { arr[i, j] = true; }
                        }
                        if (j != 0)
                        {
                            if (l[i, j] == false && arr[i, j - 1] == true) { arr[i, j] = true; }
                        }
                    }
                }
            }

            bool ans = true;

            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    if (arr[i, j] == false) { ans = false; }
                }
            }

            return ans;
        }
    }
}
