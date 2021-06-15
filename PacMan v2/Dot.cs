﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Dot:Point
    {
        public bool status { get; set; }
        public Dot(int x, int y, bool status) : base(x, y) 
        {
            if (status == true) { this.status = true; this.ch = '.'; } else { this.status = false; this.ch = ' '; }
            this.lvl = 0;
        }
        public void Take() 
        {
            this.status = false;
            this.ch = ' ';
        }
    }
}
