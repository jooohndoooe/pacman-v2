using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm.Properties;

namespace PacMan_v2
{
    public static class PointDraw
    {
        public static Graphics graphics { get; set; }
        public static int PacManStatus { get; set; } = 0;

        private readonly static Bitmap PacManRightTexture = Resources.PacMan,
            PacMan2Texture = Resources.PacMan2,
            GhostTexture = Resources.Ghost1,
            PacManLeftTexture = Resources.PacManLeft,
            PacManDownTexture = Resources.PacManDown,
            PacManUpTexture = Resources.PacManUp;
            

        public static void Draw(object sender, DrawEventArgs e)
        {
            if (e.ch == '#')
            {
                using var brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == ' ')
            {
                using var brush = new SolidBrush(Color.Transparent);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == '.')
            {
                using var brush = new SolidBrush(Color.LightGray);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == 'F')
            {
                using var brush = new SolidBrush(Color.Brown);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == '&')
            {
                using var brush = new SolidBrush(Color.Orange);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == 'O')
            {
                PacManStatus++;
                using var brush = new SolidBrush(Color.Purple);
                if (PacManStatus % 2 == 0)
                {
                    if (e.direction == 'r')
                    {
                        graphics.DrawImage(PacManRightTexture, e.cellRect);
                    }
                    if (e.direction == 'l')
                    {
                        graphics.DrawImage(PacManLeftTexture, e.cellRect);
                    }
                    if (e.direction == 'u')
                    {
                        graphics.DrawImage(PacManUpTexture, e.cellRect);
                    }
                    if (e.direction == 'd')
                    {
                        graphics.DrawImage(PacManDownTexture, e.cellRect);
                    }
                }
                else
                {
                    graphics.DrawImage(PacMan2Texture, e.cellRect);
                }
                //graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == '@')
            {
                using var brush = new SolidBrush(Color.Pink);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == '<' || e.ch == '>' || e.ch == 'V' || e.ch == 'A')
            {
                using var brush = new SolidBrush(Color.Cyan);
                graphics.DrawImage(GhostTexture, e.cellRect);

                //graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch >= '1' && e.ch <= '9')
            {
                using var brush = new SolidBrush(Color.Pink);
                graphics.DrawImage(GhostTexture, e.cellRect);

                //graphics.FillRectangle(brush, e.cellRect);
                return;
            }
            if (e.ch == 'B')
            {
                using var brush = new SolidBrush(Color.DarkGray);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }
        }
    }

    public class DrawEventArgs : EventArgs
    {
        public char ch { get; set; }
        public char direction { get; set; }
        public Rectangle cellRect { get; set; }
        public DrawEventArgs(char dChar, Rectangle cellRect, char direction)
        {
            this.ch = dChar;
            this.cellRect = cellRect;
            this.direction = direction;
        }
    }
}
