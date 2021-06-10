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
            this.sizeX = T.height;
            this.sizeY = T.width;
            this.elements = new MapElement[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    this.elements[i, j] = new MapElement(T.LockedUp[i,j], T.LockedRight[i, j], T.LockedDown[i, j], T.LockedLeft[i, j]);
                }
            }
            this.field = new char[sizeX * 4 + 1, sizeY * 4 + 1];
            for (int i = sizeX-1; i >= 0; i--)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    
                    
                    for (int p = 0; p < 5; p++) {
                        for (int q = 0; q < 5; q++) {
                            field[4 * i + p, 4 * j + q] = elements[i, j].element[q, 4 - p];
                        }
                    }
                }
            }
            this.sizeX = 4 * T.height + 1;
            this.sizeY = 4 * T.width + 1;
            field[1, 1] = ' ';
            field[1, 2] = ' ';
            field[2, 1] = ' ';
            field[sizeX - 2, sizeY - 2] = ' ';
            field[sizeX - 2, sizeY - 3] = ' ';
            field[sizeX - 3, sizeY - 2] = ' ';
        }
    }
}
