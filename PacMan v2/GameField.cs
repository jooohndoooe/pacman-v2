using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NAudio.Wave;

namespace PacMan_v2
{
    public class GameField
    {

        Level L { get; set; }

        public char[,] LoadTable(int a) 
        {
            string[] levels = { @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level1.txt", @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level2.txt", @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level1.txt" };
            string readPath = levels[a-1];
            List<string> tempReader = new List<string>();
            int LevelDimentionX = 0, LevelDimentionY = 0;
            int reader = 48;
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    while (reader != 42)
                    {
                        LevelDimentionX *= 10;
                        LevelDimentionX += reader - 48;
                        reader = sr.Read();
                    }
                    reader = 48;
                    while (reader != 42)
                    {
                        LevelDimentionY *= 10;
                        LevelDimentionY += reader - 48;
                        reader = sr.Read();
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine(e.Message); }

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
            catch (Exception e) { System.Console.WriteLine(e.Message); }
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
            string[] levels = { @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level1.txt", @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level2.txt", @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level1.txt" };
            string readPath = levels[a - 1];
            int LevelDimentionY = 0;
            int reader = 48;
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    while (reader != 42)
                    {
                        LevelDimentionY *= 10;
                        LevelDimentionY += reader - 48;
                        reader = sr.Read();
                    }
                }
            }
            catch(Exception e) { System.Console.WriteLine(e.Message); }
            return LevelDimentionY;
        }

        public int TableSizeX(int a)
        {
            string[] levels = { @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level1.txt", @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level2.txt", @"C:\Users\Ustyn\source\repos\PacMan v2\PacMan v2\Levels\Level1.txt" };
            string readPath = levels[a - 1];
            int LevelDimentiotY = 0, LevelDimentionX = 0;
            int reader = 48;
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    while (reader != 42)
                    {
                        LevelDimentiotY *= 10;
                        LevelDimentiotY += reader - 48;
                        reader = sr.Read();
                    }
                    reader = 48;
                    while (reader != 42)
                    {
                        LevelDimentionX *= 10;
                        LevelDimentionX += reader - 48;
                        reader = sr.Read();
                    }
                }
            }
            catch (Exception e) { System.Console.WriteLine(e.Message); }
            return LevelDimentionX;
        }

        public void LoadInfo1(Level L, DotField D, Player P) 
        {
            System.Console.SetCursorPosition(3, L.sizeY + 2);
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.SetCursorPosition(3, L.sizeY + 2);
            System.Console.WriteLine("Score: "+ P.score+"/"+ D.MaxScore);
            System.Console.WriteLine("   Level: " + P.lvl);
            System.Console.WriteLine("   Health: " + P.health);
            System.Console.WriteLine("   Lives: " + P.lives);
            System.Console.WriteLine("   X:" + P.x + " Y:" + P.y);
        }
        public void LoadInfo2(Level L,DotField D,Player P1,Player P2) 
        {
            System.Console.SetCursorPosition(0, L.sizeY + 2);
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.WriteLine("                                                                                                       ");
            System.Console.SetCursorPosition(0, L.sizeY + 2);
            System.Console.WriteLine("(wasd)   Player 1: " + P1.score + "   Level: " + P1.lvl + " X: " + P1.x + " Y: " + P1.y) ;
            System.Console.WriteLine("(arrows) Player 2: " + P2.score + "   Level: " + P2.lvl + " X: " + P2.x + " Y: " + P2.y);
            System.Console.WriteLine();
            System.Console.WriteLine("P1: Health: " + P1.health + " Lives: " + P1.lives);
            System.Console.WriteLine("P2: Health: " + P2.health + " Lives: " + P2.lives);

        }

        public void LoadTime(Level L, int time) 
        {
            System.Console.SetCursorPosition(0, L.sizeY + 9);
            System.Console.WriteLine("                                                                                                       ");
            System.Console.SetCursorPosition(0, L.sizeY + 9);
            System.Console.Write("   Time left: " + time / 60 + ":");
            if (time % 60 < 10) { System.Console.Write(0); }
            System.Console.WriteLine(time % 60);
        }


        public void GameStart(int level, int difficulty, string mode, bool MusicStatus) 
        {
            ConsoleMethods C = new ConsoleMethods();
            bool GameActiveStatus = true;
            System.Console.Clear();
            string[] treks = { @"..\..\..\Music\V.mp3", @"..\..\..\Music\Valentinos.mp3", @"..\..\..\Music\The Rebel Path.mp3", @"..\..\..\Music\Maelstrom.mp3", @"..\..\..\Music\The Rebel Path (Cello Version).mp3" };
            Random r = new Random();
            int RandomMusicNumber = r.Next() % (5);
            var waveOut = new WaveOut();
            waveOut.Stop();
            WaveStream waveStream = new Mp3FileReader(treks[RandomMusicNumber]);
            waveOut = new WaveOut();
            waveOut.Init(waveStream);
            waveOut.Play();



            Logic logic = new Logic(level, difficulty, mode, MusicStatus, false);
            Level.OnDraw += PointDraw.Draw;

            while (GameActiveStatus == true)
            {
                DateTime T1 = DateTime.Now;
                while ((DateTime.Now - T1).TotalMilliseconds < 200) { }

                if (System.Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = System.Console.ReadKey();
                    ConsoleKeyInput(key, logic, waveOut);
                }


                LoadTime(logic.L, 600-(int)(DateTime.Now - logic.Start).TotalSeconds);
                if (mode == "SinglePlayer")
                {
                    LoadInfo1(logic.L, logic.D, logic.P1);
                }
                else
                {
                    LoadInfo2(logic.L, logic.D, logic.P1, logic.P2);
                }


                string result = logic.MoveEnemies();
                HandleResult(result, logic);


                if (!logic.LevelEditorMode)
                {
                    result = logic.MovePlayers();
                }
                if (result != "supra") { waveOut.Stop(); }
                HandleResult(result, logic);


                this.L = logic.InterfaceField;
                L.Load();
            }
        }

        public void HandleResult(string result, Logic logic) 
        {
            if (result == "P1Died")
            {
                P1Died(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (result == "P2Died")
            {
                P2Died(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (result == "P1killedP2")
            {
                P1killedP2(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (result == "P2killedP1")
            {
                P2killedP1(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (result == "P1Score")
            {
                P1Score(logic.level, logic.difficulty, logic.mode, logic.MusicStatus, logic.P1, logic.P2);
            }
            if (result == "P2Score")
            {
                P2Score(logic.level, logic.difficulty, logic.mode, logic.MusicStatus, logic.P1, logic.P2);
            }
            if (result == "Death")
            {
                Death(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (result == "Victory")
            {
                Victory(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (result == "Time")
            {
                Time(logic.level, logic.difficulty, logic.mode, logic.MusicStatus, logic.P1);
            }
            if (result == "Finish")
            {
                Finish(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (result == "Tie")
            {
                Tie(logic.level, logic.difficulty, logic.mode, logic.MusicStatus, logic.P1, logic.P2);
            }
        }

        public void ConsoleKeyInput(ConsoleKeyInfo key,Logic logic, WaveOut waveOut) 
        {
            ConsoleMethods C = new ConsoleMethods();
            if (key.Key == ConsoleKey.Escape)
            {
                waveOut.Stop();
                C.MainMenu(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (key.Key == ConsoleKey.R)
            {
                waveOut.Stop();
                GameStart(logic.level, logic.difficulty, logic.mode, logic.MusicStatus);
            }
            if (key.Key == ConsoleKey.T && (DateTime.Now - logic.TeleportTime1).TotalSeconds >= 2 && logic.NumberOfSteps1 - logic.TeleportNumberOfSteps1 >= 5)
            {
                logic.TeleportTime1 = DateTime.Now;
                logic.TeleportNumberOfSteps1 = logic.NumberOfSteps1;

                logic.P1.Teleport(L);
            }
            if (key.Key == ConsoleKey.G) { logic.G.Turn(); }
            if (key.Key == ConsoleKey.I) { logic.G.Invert(); }

            if (logic.mode == "SinglePlayer")
            {
                if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S) { logic.P1.ChangeDirection('d'); }
                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W) { logic.P1.ChangeDirection('u'); }
                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) { logic.P1.ChangeDirection('l'); }
                if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) { logic.P1.ChangeDirection('r'); }
                if (logic.LevelEditorMode)
                {
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        if (logic.CustomLevel[logic.P1.x, logic.P1.y] == '#')
                        {
                            logic.CustomLevel[logic.P1.x, logic.P1.y] = ' ';
                        }
                        else
                        {
                            logic.CustomLevel[logic.P1.x, logic.P1.y] = '#';
                        }
                        logic.L = new Level(10, 10, 0, 0, logic.CustomLevel, logic.difficulty);
                        logic.InterfaceField = logic.L;
                    }
                    else
                    {
                        logic.MovePlayers();
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {
                        char[,] backupCustomLevel = logic.CustomLevel;
                        logic = new Logic(3, logic.difficulty, logic.mode, logic.MusicStatus, true);
                        logic.L = new Level(10, 10, 1, 1, backupCustomLevel, logic.difficulty);
                        logic.D = new DotField(logic.L);
                        logic.U = new UpgradeField(logic.L, logic.D);
                        logic.G = new GravityField(logic.L, 1, false);
                    }
                }
            }
            else
            {
                if (key.Key == ConsoleKey.S) { logic.P1.ChangeDirection('d'); }
                if (key.Key == ConsoleKey.W) { logic.P1.ChangeDirection('u'); }
                if (key.Key == ConsoleKey.A) { logic.P1.ChangeDirection('l'); }
                if (key.Key == ConsoleKey.D) { logic.P1.ChangeDirection('r'); }
                if (key.Key == ConsoleKey.DownArrow) { logic.P2.ChangeDirection('d'); }
                if (key.Key == ConsoleKey.UpArrow) { logic.P2.ChangeDirection('u'); }
                if (key.Key == ConsoleKey.LeftArrow) { logic.P2.ChangeDirection('l'); }
                if (key.Key == ConsoleKey.RightArrow) { logic.P2.ChangeDirection('r'); }
                if (key.Key == ConsoleKey.L && (DateTime.Now - logic.TeleportTime2).TotalSeconds >= 2 && logic.NumberOfSteps2 - logic.TeleportNumberOfSteps2 >= 5)
                {
                    logic.TeleportTime2 = DateTime.Now;
                    logic.TeleportNumberOfSteps2 = logic.NumberOfSteps2;

                    logic.P2.Teleport(L);
                }
            }
        
    }
       

        public void EndingLoop(int level, int difficulty, string mode, bool MusicStatus) 
        {
            ConsoleMethods C = new ConsoleMethods();
            System.Console.WriteLine();
            System.Console.WriteLine("Press Space to continue");
            while (true)
            {
                if (System.Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = System.Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { C.MainMenu(level, difficulty, mode, MusicStatus); }
                }
            }
        }

        public void P1killedP2(int level, int difficulty, string mode, bool MusicStatus) 
        {
            System.Console.Clear();
            System.Console.WriteLine("P1 Won!");
            System.Console.WriteLine("P1 killed P2");
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void P2killedP1(int level, int difficulty, string mode, bool MusicStatus)
        {
            System.Console.Clear();
            System.Console.WriteLine("P2 Won!");
            System.Console.WriteLine("P2 killed P1");
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void P1Died(int level, int difficulty, string mode, bool MusicStatus)
        {
            System.Console.Clear();
            System.Console.WriteLine("P2 Won!");
            System.Console.WriteLine("P1 died to a bot...");
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void P2Died(int level, int difficulty, string mode, bool MusicStatus)
        {
            System.Console.Clear();
            System.Console.WriteLine("P1 Won!");
            System.Console.WriteLine("P2 died to a bot...");
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void P1Score(int level, int difficulty, string mode, bool MusicStatus, Player P1, Player P2)
        {
            System.Console.Clear();
            System.Console.WriteLine("P1 Won!");
            System.Console.WriteLine("P1 score: " + P1.score);
            System.Console.WriteLine("P2 score: " + P2.score);
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void P2Score(int level, int difficulty, string mode, bool MusicStatus, Player P1, Player P2)
        {
            System.Console.Clear();
            System.Console.WriteLine("P2 Won!");
            System.Console.WriteLine("P1 score: " + P1.score);
            System.Console.WriteLine("P2 score: " + P2.score);
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void Tie(int level, int difficulty, string mode, bool MusicStatus, Player P1, Player P2)
        {
            System.Console.Clear();
            System.Console.WriteLine("Draw.... seriously?");
            System.Console.WriteLine("P1 score: " + P1.score);
            System.Console.WriteLine("P2 score: " + P2.score);
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void Victory(int level, int difficulty, string mode, bool MusicStatus)
        {
            System.Console.Clear();
            System.Console.WriteLine("You Won!");
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void Death(int level, int difficulty, string mode, bool MusicStatus)
        {
            System.Console.Clear();
            System.Console.WriteLine("You Lost!");
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void Finish(int level, int difficulty, string mode, bool MusicStatus)
        {
            System.Console.Clear();
            System.Console.WriteLine("You've reached the finish line!");
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
        public void Time(int level, int difficulty, string mode, bool MusicStatus, Player P1)
        {
            System.Console.Clear();
            System.Console.WriteLine("Time has ended");
            System.Console.WriteLine();
            System.Console.WriteLine("Score: " + P1.score);
            EndingLoop(level, difficulty, mode, MusicStatus);
        }
    }
}
