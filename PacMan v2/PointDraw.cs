using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public static class PointDraw
    {
        public static void Draw(object sender, DrawEventArgs e) 
        {
            System.Console.SetCursorPosition(e.x, e.y);
            System.Console.Write(e.DrawingChar);
        }
    }

    public class DrawEventArgs : EventArgs 
    { 
        public char DrawingChar { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public DrawEventArgs(int x, int y, char dChar)
        {
            this.DrawingChar = dChar;
            this.x = x;
            this.y = y;
        }
    }
}
