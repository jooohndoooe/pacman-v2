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
        
        public Entity(int a,int b,char _ch, char d, int l)
        {
            this.x = a;
            this.y = b;
            this.ch = _ch;
            this.direction = d;
            this.lvl = l;
        }
        public Entity(int a,int b,char _ch,char d)
        {
            this.x = a;
            this.y = b;
            this.ch = _ch;
            this.direction = d;
            this.lvl = 0;
        }
        public Entity(int a, int b, char _ch)
        {
            this.x = a;
            this.y = b;
            this.ch = _ch;
            this.direction = 'r';
            this.lvl = 0;
        }
        public Entity(int a, int b, char _ch, int l)
        {
            this.x = a;
            this.y = b;
            this.ch = _ch;
            this.direction = 'r';
            this.lvl = l;
        }
        public void ChangeDirection(char _ch) 
        {
            if (_ch == 'r' || _ch == 'l' || _ch == 'd' || _ch == 'u') 
            {
                this.direction = _ch;
            }
        }
        public void Go(Level L,DotField D,UpgradeField U) 
        {
            if (this.ch != ' ')
            {
                if (direction == 'r') { if (L.field[x + 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x++; } }
                if (direction == 'l') { if (L.field[x - 1, y].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.x--; } }
                if (direction == 'u') { if (L.field[x, y - 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y--; } }
                if (direction == 'd') { if (L.field[x, y + 1].lvl < lvl) { if (U.field[x, y].status == true) { U.field[x, y].Draw(); } else { D.field[x, y].Draw(); } this.y++; } }
                Load();
            }
        }
        public void Load() 
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }
    }
}
