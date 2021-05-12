using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class MapElement
    {
        public bool u { get; set; }
        public bool d { get; set; }
        public bool l { get; set; }
        public bool r { get; set; }
        public char[,] element { get; set; }

        public MapElement(bool a, bool b, bool c, bool d)
        {
            this.u = a;
            this.r = b;
            this.d = c;
            this.l = d;

            this.element = new char[5, 5];
            this.element[0, 0] = '#'; this.element[0, 1] = '#'; this.element[0, 2] = '#'; this.element[0, 3] = '#'; this.element[0, 4] = '#';
            this.element[1, 0] = '#'; this.element[1, 1] = ' '; this.element[1, 2] = ' '; this.element[1, 3] = ' '; this.element[1, 4] = '#';
            this.element[2, 0] = '#'; this.element[2, 1] = ' '; this.element[2, 2] = ' '; this.element[2, 3] = ' '; this.element[2, 4] = '#';
            this.element[3, 0] = '#'; this.element[3, 1] = ' '; this.element[3, 2] = ' '; this.element[3, 3] = ' '; this.element[3, 4] = '#';
            this.element[4, 0] = '#'; this.element[4, 1] = '#'; this.element[4, 2] = '#'; this.element[4, 3] = '#'; this.element[4, 4] = '#';
            Random y = new Random();


            int k = 0;
            int x = 0;
            int[] arr = new int[4];
            if (b == false)
            {
                x = y.Next() % 2;
                this.element[4, 2] = ' ';
                if (x == 0)
                {
                    this.element[4, 1] = ' ';
                    this.element[4, 3] = ' ';
                }
            }
            else 
            {
                arr[k] = 1;
                k++;
            }
            if (c== false)
            {
                x = y.Next() % 2;
                this.element[2, 0] = ' ';
                if (x == 0)
                {
                    this.element[1, 0] = ' ';
                    this.element[3, 0] = ' ';
                }
            }
            else
            {
                arr[k] = 2;
                k++;
            }
            if (d == false)
            {
                x = y.Next() % 2;
                this.element[0, 2] = ' ';
                if (x == 0)
                {
                    this.element[0, 1] = ' ';
                    this.element[0, 3] = ' ';
                }
            }
            else
            {
                arr[k] = 3;
                k++;
            }
            if (a == false)
            {
                x = y.Next() % 2;
                this.element[2, 4] = ' ';
                if (x == 0)
                {
                    this.element[1, 4] = ' ';
                    this.element[3, 4] = ' ';
                }
            }
            else
            {
                arr[k] = 4;
                k++;
            }
            if (k != 0)
            {
                k = y.Next() % k;
                k = arr[k];

                if (k == 1)
                {
                    this.element[3, 2] = '#';
                    this.element[2, 2] = '#';
                }
                if (k == 2)
                {
                    this.element[2, 1] = '#';
                    this.element[2, 2] = '#';
                }
                if (k == 3)
                {
                    this.element[1, 2] = '#';
                    this.element[2, 2] = '#';
                }
                if (k == 4)
                {
                    this.element[2, 3] = '#';
                    this.element[2, 2] = '#';
                }
            }
            x = y.Next() % 2;
            if (x == 0)
            {
                this.element[2, 2] = '#';
            }
        }

    }
}
