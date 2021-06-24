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
            this.max = L.UpgradeCount;
            this.current = this.max;
            this.field = new Upgrade[L.sizeX, L.sizeY];
            this.sizeX = L.sizeX;
            this.sizeY = L.sizeY;

            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    this.field[i, j] = new Upgrade(i, j, false, 'U');
                }
            }

            for (int i = 0; i < max + L.sizeX / 10; i++)
            {
                Random r = new Random();
                int RandomX = r.Next() % (L.sizeX - 3) + 1;
                int z = -1;
                List<int> PossibleY = new List<int>();
                for (int j = 0; j < sizeY; j++) { if (L.field[RandomX, j].lvl < 5) { PossibleY.Add(j); } }
                int RandomY = PossibleY[r.Next() % PossibleY.Count];
                if ((RandomX == 1 && RandomY == 1) || (RandomX == sizeX - 2 && RandomY == sizeY - 2)) 
                {
                    i--; 
                    continue;
                }
                if (r.Next() % 2 == 0)
                {
                    D.Delete(RandomX, RandomY);
                }
                if (i < max)
                {
                    this.field[RandomX, RandomY] = new Upgrade(RandomX, RandomY, true, 'U');
                }
                else
                {
                    this.field[RandomX, RandomY] = new Upgrade(RandomX, RandomY, true, 'H');
                }
            }
        }


        public void Take(int x, int y, Player P1)
        {
            if (field[x, y].type == 'U')
            {
                if (field[x, y].status == true) { field[x, y].Take(); this.current--; P1.lvl++; }
            }
            if (field[x, y].type == 'H')
            {
                if (field[x, y].status == true) { field[x, y].Take(); this.current--; P1.lives++; }
            }
        }
    }
}
