using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PacMan_v2
{
    class Game
    {
        public char[,] LoadTable(int a) 
        {
            string[] levels = { @"..\..\..\Levels\Level1.txt", @"..\..\..\Levels\Level2.txt", @"..\..\..\Levels\Level3.txt" };
            string readPath = levels[a-1];
            List<string> tempReader = new List<string>();
            int LevelDimentionX = 0, LevelDimentionY = 0;
            int temp = 48;
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    while (temp != 42)
                    {
                        LevelDimentionX *= 10;
                        LevelDimentionX += temp - 48;
                        temp = sr.Read();
                    }
                    temp = 48;
                    while (temp != 42)
                    {
                        LevelDimentionY *= 10;
                        LevelDimentionY += temp - 48;
                        temp = sr.Read();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    string trash = sr.ReadLine();
                    for (int i = 0; i < LevelDimentionX; i++)
                    {
                        tempReader.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            char[,] level = new char[LevelDimentionY, LevelDimentionX];
            for (int i = 0; i < LevelDimentionX; i++)
            {
                string tempString = tempReader[i];
                for (int j = 0; j < tempString.Length; j++)
                {
                    level[j, i] = tempString[j];
                }
            }
            return level;
        }

        public int TableSizeY(int a) 
        {
            string[] levels = { @"..\..\..\Levels\Level1.txt", @"..\..\..\Levels\Level2.txt", @"..\..\..\Levels\Level3.txt" };
            string readPath = levels[a - 1];
            List<string> tempReader = new List<string>();
            int LevelDimentionX = 0, LevelDimentionY = 0;
            int temp = 48;
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    while (temp != 42)
                    {
                        LevelDimentionX *= 10;
                        LevelDimentionX += temp - 48;
                        temp = sr.Read();
                    }
                }
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            return LevelDimentionX;
        }

        public int TableSizeX(int a)
        {
            string[] levels = { @"..\..\..\Levels\Level1.txt", @"..\..\..\Levels\Level2.txt", @"..\..\..\Levels\Level3.txt" };
            string readPath = levels[a - 1];
            List<string> tempReader = new List<string>();
            int LevelDimentionX = 0, LevelDimentionY = 0;
            int temp = 48;
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    while (temp != 42)
                    {
                        LevelDimentionX *= 10;
                        LevelDimentionX += temp - 48;
                        temp = sr.Read();
                    }
                    temp = 48;
                    while (temp != 42)
                    {
                        LevelDimentionY *= 10;
                        LevelDimentionY += temp - 48;
                        temp = sr.Read();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return LevelDimentionY;
        }

        public void LoadInfo1(Level L, DotField D, Player P) 
        {
            Console.SetCursorPosition(3,L.sizeY+2);
            Console.WriteLine("Score: "+P.score+"/"+D.max);
            Console.WriteLine("   Level: " + P.lvl);
        }
        public void LoadInfo2(Level L,DotField D,Player P1,Player P2) 
        {
            Console.SetCursorPosition(0, L.sizeY + 2);
            Console.WriteLine("(wasd)   Player 1: " + P1.score + "   Level: " + P1.lvl);
            Console.WriteLine("(arrows) Player 2: " + P2.score + "   Level: " + P2.lvl);
        } 

    }

        
}
