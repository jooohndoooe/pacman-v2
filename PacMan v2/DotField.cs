using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class DotField
    {
        public Dot[,] field { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public int MaxScore { get; set; }
        public int CurrentLeft { get; set; }
        public DotField(Level L) {
            MaxScore = 0;
            field = new Dot[L.sizeX, L.sizeY];
            this.sizeX = L.sizeX;
            this.sizeY = L.sizeY;
            for (int i = 0; i < L.sizeX; i++) {
                for (int j = 0; j < L.sizeY; j++) {
                    if (L.field[i, j].ch == ' ')
                    {
                        field[i, j] = new Dot(i, j, true); this.MaxScore+=field[i,j].value;
                    }
                    else 
                    { 
                        field[i, j] = new Dot(i, j, false); 
                    }
                    if (L.field[i, j].ch == 'C')
                    {
                        Random r = new Random();
                        if (r.Next() % 2 == 0)
                        {
                            field[i, j] = new Dot(i, j, true); this.MaxScore += field[i, j].value;
                        }
                    }
                }
            }
            this.CurrentLeft = this.MaxScore;
        }

        public int Take(int x,int y)
        {
            if (field[x, y].status == true) { field[x, y].Take(); this.CurrentLeft--; return field[x,y].value; } else { return 0; }
        }

        public void Delete(int a, int b)
        {
            if (field[a, b].status == true) { field[a, b].Take(); this.CurrentLeft--; this.MaxScore--; }
        }
    }
}
