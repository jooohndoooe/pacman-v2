using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class UpgradeField
    {
        public Upgrade[,] field { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public int max { get; set; }
        public int current { get; set; }
        public UpgradeField(Level L,DotField D)
        {
            this.max = L.NumberOfUpgrades;
            this.current = this.max;
            this.field = new Upgrade[L.sizeX, L.sizeY];
            this.sizeX = L.sizeX;
            this.sizeY = L.sizeY;

            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    this.field[i, j] = new Upgrade(i, j, false);
                }
            }

            for (int i = 0; i < max; i++) 
            {
                again:
                Random r = new Random();
                int x = r.Next() % (L.sizeX - 2)+1;
                int z = -1;
                int[] arr = new int[sizeY];
                for (int j = 0; j < sizeY; j++) { if (L.field[x, j].lvl == 0) { z++; arr[z] = j; } }
                z++;
                int y = r.Next() % z;
                y = arr[y];
                if ((x == 1 && y == 1) || (x == sizeX - 2 && y == sizeY - 2) || D.field[x, y].status == false) { goto again; }
                D.Delete(x, y);
                this.field[x, y] = new Upgrade(x, y, true);
            }
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

        public int Take(int a, int b)
        {
            if (field[a, b].status == true) { field[a, b].Take(); this.current--; return 1; } else { return 0; }
        }
    }
}
