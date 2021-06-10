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
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.lvl = lvl;
        }

        public Point(int x, int y, char ch) 
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.lvl = 0;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.ch = ' ';
            this.lvl = 0;
        }

        public void DrawWF(Graphics graphics, Rectangle cellRect)
        {
            if (this.ch == '#')
            {
                using var brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch == ' ')
            {
                using var brush = new SolidBrush(Color.Transparent);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch == '.')
            {
                using var brush = new SolidBrush(Color.LightGray);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch == 'F')
            {
                using var brush = new SolidBrush(Color.Brown);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch == '&')
            {
                using var brush = new SolidBrush(Color.Orange);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch == 'O') {
                using var brush = new SolidBrush(Color.Purple);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch == '@') {
                using var brush = new SolidBrush(Color.Pink);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch == '<' || this.ch == '>' || this.ch == 'V' || this.ch == 'A') {
                using var brush = new SolidBrush(Color.Cyan);
                graphics.FillRectangle(brush, cellRect);
                return;
            }
            if (this.ch >= 1 && this.ch <= 9) { 
                using var brush = new SolidBrush(Color.DarkBlue);
                graphics.FillRectangle(brush, cellRect);
                return;
            }


        }

        public void Draw() 
        {
            DrawPoint(ch);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char ch) 
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(ch);
        }
    }
}
