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
        public static int PacManStatus2 { get; set; } = 0;

        private readonly static Bitmap PacManRightTexture = Resources.PacMan,
            PacMan2Texture = Resources.PacMan2,
            GhostTexture = Resources.Ghost1,
            PacManLeftTexture = Resources.PacManLeft,
            PacManDownTexture = Resources.PacManDown,
            PacManUpTexture = Resources.PacManUp,
            WallTexture = Resources.Wall,
            DotTexture = Resources.Wall1,
            UpgradeTexture = Resources.Upgrade,
            FinishTexture = Resources.Finish,
            PacManRightTexture2 = Resources._2PacMan,
            PacMan2Texture2 = Resources._2PacMan2,
            PacManLeftTexture2 = Resources._2PacManLeft,
            PacManDownTexture2 = Resources._2PacManDown,
            PacManUpTexture2 = Resources._2PacManUp,
            CrackedWallTexture = Resources.CrackedWall,
            HealthTexture = Resources.Health,
            BigDotTexture = Resources.BigDot,
            DotInAWallTexture = Resources.DotInAWall,
            BigDotInAWallTexture = Resources.BigDotInAWall,
            UpgradeInAWallTexture = Resources.UpgradeInAWall,
            HealthInAWallTexture = Resources.HealthInAWall,
            DotInAnUpgradeTexture = Resources.DotInAnUpgrade,
            DotInHealthTexture = Resources.DotInHealth,
            BigDotInAnUpgradeTexture = Resources.BigDotInAnUpgrade,
            BigDotinHealthTexture = Resources.BigDotInHealth,
            DotInAnUpgradeInAWallTexture = Resources.DotInAnUpgradeInAWall,
            BigDotInAnUpgradeInAWallTexture = Resources.BigDotInAnUpgrade,
            DotInHealthInAWallTexture = Resources.DotInHealthInAWall,
            BigDotInHealthInAWallTexture = Resources.BigDotInAnUpgradeInAWall;



        public static void Draw(object sender, DrawEventArgs e)
        {
            if (e.ch == 'O')
            {
                PacManStatus++;

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
                return;
            }
            if (e.ch == '@')
            {
                PacManStatus2++;

                if (PacManStatus2 % 2 == 0)
                {
                    if (e.direction == 'r')
                    {
                        graphics.DrawImage(PacManRightTexture2, e.cellRect);
                    }
                    if (e.direction == 'l')
                    {
                        graphics.DrawImage(PacManLeftTexture2, e.cellRect);
                    }
                    if (e.direction == 'u')
                    {
                        graphics.DrawImage(PacManUpTexture2, e.cellRect);
                    }
                    if (e.direction == 'd')
                    {
                        graphics.DrawImage(PacManDownTexture2, e.cellRect);
                    }
                }
                else
                {
                    graphics.DrawImage(PacMan2Texture2, e.cellRect);
                }
                return;
            }

            Dictionary<char, Bitmap> ImageList = new Dictionary<char, Bitmap>();
            ImageList.Add('#', WallTexture);
            ImageList.Add('C', CrackedWallTexture);
            ImageList.Add('.', DotTexture);
            ImageList.Add('F', FinishTexture); 
            ImageList.Add('&', UpgradeTexture);
            ImageList.Add('<', GhostTexture);
            ImageList.Add('>', GhostTexture);
            ImageList.Add('A', GhostTexture);
            ImageList.Add('V', GhostTexture);
            for (int i = 0; i < 10; i++) 
            {
                ImageList.Add(i.ToString()[0], GhostTexture);
            }
            ImageList.Add('$', HealthTexture);
            ImageList.Add('*', BigDotTexture);
            ImageList.Add(',', DotInAWallTexture);
            ImageList.Add('`', BigDotInAWallTexture);
            ImageList.Add('U', UpgradeInAWallTexture);
            ImageList.Add('H', HealthInAWallTexture);
            ImageList.Add('D', DotInAnUpgradeTexture);
            ImageList.Add('d', DotInHealthTexture);
            ImageList.Add('P', BigDotInAnUpgradeTexture);
            ImageList.Add('p', BigDotinHealthTexture);
            ImageList.Add('T', DotInAnUpgradeInAWallTexture);
            ImageList.Add('X', BigDotInAnUpgradeInAWallTexture);
            ImageList.Add('t', DotInHealthInAWallTexture);
            ImageList.Add('x', BigDotInHealthInAWallTexture);

            if (e.ch == ' ')
            {
                using var brush = new SolidBrush(Color.Transparent);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }

            graphics.DrawImage(ImageList[e.ch], e.cellRect);




            
            
            
            /*if (e.ch == 'B')
            {
                using var brush = new SolidBrush(Color.DarkGray);
                graphics.FillRectangle(brush, e.cellRect);
                return;
            }*/
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
