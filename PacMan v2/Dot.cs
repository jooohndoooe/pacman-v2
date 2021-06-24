using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Dot:Point
    {
        public bool status { get; set; }
        public int value { get; set; }
        public Dot(int x, int y, bool status) : base(x, y) 
        {
            if (status == true) { this.status = true; this.ch = '.'; } else { this.status = false; this.ch = ' '; }
            this.value = 1;
            Random r = new Random();
            if (r.Next() % 20 == 0) { this.value = 10; this.ch = '*'; }
            this.lvl = 0;
        }
        public void Take() 
        {
            this.status = false;
            this.ch = ' ';
        }
    }
}
