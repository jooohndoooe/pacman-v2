using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class GravityField
    {
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public bool[,] field{ get; set; }
        public int force { get; set; }
        public bool ActiveStatus { get; set; }

        public GravityField(Level L, int force, bool ActiveStatus) 
        {
            this.field = new bool[L.sizeX, L.sizeY];
            this.sizeX = L.sizeX;
            this.sizeY = L.sizeY;
            this.force = force;
            this.ActiveStatus = ActiveStatus;
            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    this.field[i, j] = true;
                }
            }
        }

        public void Invert() 
        {
            this.force = this.force * (-1);
        }

        public void Turn() 
        {
            if (ActiveStatus) { 
                this.ActiveStatus = false; 
            }
            else
            {
                if (!ActiveStatus) { 
                    this.ActiveStatus = true; 
                }
            }
        }


    }
}
