using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Player:Entity
    {
        public int score { get; set; }
        public int lives { get; set; }
        public int health { get; set; }

        public Player(int x, int y, int PlayerNumber) : base(x, y, 'O', 'r', 1) { 
            this.score = 0;
            this.health = 100;
            this.lives = 3;
            if (PlayerNumber == 2) { 
                this.ch = '@'; 
            } 
        }
        public void Plus() { this.score++; }

        public void Teleport(Level L) 
        {
            Random r = new Random();
            int ran = r.Next();
            if (ran % 2 == 1)
            {
                int p = L.sizeX;
                int q = L.sizeY;
                q = r.Next() % (q - 2) + 1;
                p = r.Next() % (p - 2) + 1;
                if (L.field[p, q].lvl < this.lvl) { this.x = p; this.y = q; } else { Teleport(L); }
            }
        }

        public int GravityMove(Level L, DotField D, UpgradeField U, GravityField G)
        {
            char startingDirection = this.direction;
            int fallDamage=0;
            if (G.ActiveStatus)
            {
                if (G.force > 0)
                {
                    this.direction = 'd';
                    for (int i = 0; i < G.force; i++)
                    {
                        Go(L, D, U);
                        fallDamage++;
                    }
                }
                else
                {
                    this.direction = 'u';
                    for (int i = 0; i < -1 * G.force; i++)
                    {
                        Go(L, D, U);
                        fallDamage++;
                    }
                }
            }
            this.direction = startingDirection;
            return fallDamage;

        }

        public void GravityGo(Level L, DotField D, UpgradeField U, GravityField G)
        {
            int StartingY = this.y;
            int fallDamage = GravityMove(L, D, U, G);
            if (this.y != StartingY) { this.health -= fallDamage; }
            if (this.health < 1) { this.health=100; this.lives--; }
            Go(L, D, U);
        }
    }
}
