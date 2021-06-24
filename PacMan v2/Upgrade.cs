using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Upgrade:Point
    {
        public bool status { get; set; }
        public char type { get; set; }

        public Upgrade(int x, int y, bool status, char type) : base(x, y)
        {
            if (status == true) { this.status = true; this.ch = '&'; } else { this.status = false; this.ch = ' '; }
            this.lvl = 0;
            this.type = type;
        }
        public void Take()
        {
            this.status = false;
            this.ch = ' ';
        }

    }
}
