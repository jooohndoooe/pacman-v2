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
        public int max { get; set; }
        public int current { get; set; }
        public DotField(Level L) {
            max = 0;
            field = new Dot[L.sizeX, L.sizeY];
            this.sizeX = L.sizeX;
            this.sizeY = L.sizeY;
            for (int i = 0; i < L.sizeX; i++) {
                for (int j = 0; j < L.sizeY; j++) {
                    if (L.field[i, j].ch == ' ')
                    {
                        field[i, j] = new Dot(i, j, true); this.max++;
                    }
                    else 
                    { 
                        field[i, j] = new Dot(i, j, false); 
                    }
                }
            }
            this.current = this.max;
        }

        public void Load()  
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (field[i, j].status == true)
                    {
                        field[i, j].Draw();
                    }
                }
            }
        }

        public int Take(int a,int b)
        {
            if (field[a, b].status == true) { field[a, b].Take(); this.current--; return 1; } else { return 0; }
        }

        public void Delete(int a, int b)
        {
            if (field[a, b].status == true) { field[a, b].Take(); this.current--; this.max--; }
        }
    }
}
