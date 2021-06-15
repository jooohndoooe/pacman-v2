using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int lvl { get; set; }
        public char ch { get; set; }

        public Point(int x, int y, char ch, int lvl) 
        {
            SetBase(x, y, ch, lvl);
        }

        public Point(int x, int y, char ch) 
        {
            SetBase(x, y, ch, 0);
        }
        public Point(int x, int y)
        {
            SetBase(x, y, ' ', 0);
        }

        public void SetBase(int x, int y, char ch, int lvl) 
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.lvl = lvl;
        }

        

        
    }
}
