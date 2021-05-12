using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class MapElementTable
    {
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public MapElement[,] elements { get; set; }
        public char[,] field { get; set; }

        public MapElementTable(Table T) 
        {
            this.sizeX = T.x;
            this.sizeY = T.y;
            this.elements = new MapElement[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    this.elements[i, j] = new MapElement(T.u[i,j], T.r[i, j], T.d[i, j], T.l[i, j]);
                }
            }
            this.field = new char[sizeX * 5, sizeY * 5];
            for (int i = sizeX-1; i >= 0; i--)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    
                    
                    for (int p = 0; p < 5; p++) {
                        for (int q = 0; q < 5; q++) {
                            field[5 * i + p, 5 * j + q] = elements[i, j].element[q, 4 - p];
                        }
                    }
                }
            }
        }
    }
}
