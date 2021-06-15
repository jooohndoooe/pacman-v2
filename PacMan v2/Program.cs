using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Globalization;
using NAudio.Wave;


namespace PacMan_v2
{
    class Program
    {
        static void Main(string[] args)
        {

            GameField GG = new GameField();
            ConsoleMethods C = new ConsoleMethods();

            C.MainMenu(1, 1, "SinglePlayer", true);
        }
    }
}
