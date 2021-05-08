using System;
using System.Collections.Generic;
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

        public Point(int a, int b, char _ch, int c) 
        {
            this.x = a;
            this.y = b;
            this.ch = _ch;
            this.lvl = c;
        }

        public Point(int a, int b, char _ch) 
        {
            this.x = a;
            this.y = b;
            this.ch = _ch;
            this.lvl = 0;
        }
        public Point(int a, int b)
        {
            this.x = a;
            this.y = b;
            this.ch = ' ';
            this.lvl = 0;
        }

        public void Draw() 
        {
            DrawPoint(ch);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char _ch) 
        {
            Console.SetCursorPosition(x, y);
            Console.Write(_ch);
        }
    }
}
