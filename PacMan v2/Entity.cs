using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public abstract class Entity
    {
        public int x { get; set; }
        public int y { get; set; }
        public int lvl { get; set; }
        public char ch { get; set; }
        public char direction { get; set; }
        
        public Entity(int x,int y,char ch, char direction, int lvl)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.direction = direction;
            this.lvl = lvl;
        }
        public Entity(int x,int y,char ch,char direction)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.direction = direction;
            this.lvl = 0;
        }
        public Entity(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.direction = 'r';
            this.lvl = 0;
        }
        public Entity(int x, int y, char ch, int lvl)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.direction = 'r';
            this.lvl = lvl;
        }
        public void ChangeDirection(char direction) 
        {
            if (direction == 'r' || direction == 'l' || direction == 'd' || direction == 'u') 
            {
                this.direction = direction;
            }
        }
        public void Go(Level L,DotField D,UpgradeField U) 
        {
            if (this.ch != ' ')
            {
                
                if (direction == 'r') { GoInDirection(1, 0, L, D, U); }
                if (direction == 'l') { GoInDirection(-1, 0, L, D, U); }
                if (direction == 'u') { GoInDirection(0, -1, L, D, U); }
                if (direction == 'd') { GoInDirection(0, 1, L, D, U); }
                //Load();
            }
        }

        public void Go(Level L)
        {
            if (this.ch != ' ')
            {
                //Clear();
                if (direction == 'r') { GoInDirection(1, 0, L); }
                if (direction == 'l') { GoInDirection(-1, 0, L); }
                if (direction == 'u') { GoInDirection(0, -1, L); }
                if (direction == 'd') { GoInDirection(0, 1, L); }
                //Load();
            }
        }

        public void GoInDirection(int deltaX, int deltaY, Level L, DotField D, UpgradeField U)
        {
            if (L.field[(x + deltaX + L.sizeX) % L.sizeX, (y + deltaY + L.sizeY) % L.sizeY].lvl < lvl)
            {
                //if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); }
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
        }

        public void GoInDirection(int deltaX, int deltaY, Level L)
        {
            if (L.field[(x + deltaX + L.sizeX) % L.sizeX, (y + deltaY + L.sizeY) % L.sizeY].lvl < lvl)
            {
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
        }

        public void GoInDirectionAndBounce(int deltaX, int deltaY, Level L, DotField D, UpgradeField U) 
        {
            if (L.field[(x + deltaX) % L.sizeX, (y + deltaY) % L.sizeY].lvl < lvl)
            {
                //if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); }
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
            else 
            {
                if (deltaX == 1) { this.direction = 'l'; }
                if (deltaX == -1) { this.direction = 'r'; }
                if (deltaY == -1) { this.direction = 'u'; }
                if (deltaY == 1) { this.direction = 'd'; }
            }
        }

        public void GoInDirectionAndBounceRandomly(int deltaX, int deltaY, Level L, DotField D, UpgradeField U)
        {
            if (L.field[(x + deltaX) % L.sizeX, (y + deltaY) % L.sizeY].lvl < lvl)
            {
                //if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); }
                this.x += deltaX + L.sizeX;
                this.x %= L.sizeX;
                this.y += deltaY + L.sizeY;
                this.y %= L.sizeY;
            }
            else
            {
                Random r = new Random();
                int RandomDirectionSwitch = r.Next() % 2;
                if (deltaX != 0) 
                {
                    if (RandomDirectionSwitch == 0) 
                    { 
                        this.direction = 'u'; 
                    }
                    else 
                    {
                        this.direction = 'd';
                    }
                }
                if (deltaY != 0)
                {
                    if (RandomDirectionSwitch == 0)
                    {
                        this.direction = 'l';
                    }
                    else
                    {
                        this.direction = 'r';
                    }
                }
            }
        }

        public void GravityMove(Level L, DotField D, UpgradeField U, GravityField G) 
        {
            char startingDirection = this.direction;
            if (G.ActiveStatus) 
            {
                if (G.force > 0)
                {
                    this.direction = 'd';
                    for (int i = 0; i < G.force; i++) 
                    {
                        Go(L, D, U);
                    }
                }
                else
                {
                    this.direction = 'u';
                    for (int i = 0; i < -1 * G.force; i++) 
                    {
                        Go(L, D, U);
                    }
                }
            }
            this.direction = startingDirection;
        }

        public void GravityGo(Level L, DotField D, UpgradeField U, GravityField G) 
        {
            GravityMove(L, D, U, G);
            Go(L, D, U);
        }
        
        public void Load() 
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(ch);
        }

        public void Clear() 
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(' ');
        }
    }
}
