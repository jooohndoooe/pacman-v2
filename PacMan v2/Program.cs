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
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        static void Main(string[] args)
        {
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.CursorVisible = false;

            int level = 1;
            int difficulty = 1;
            bool MusicStatus = true;
        MainMenu:
            int line = 10;
            bool LevelLine = false;
            bool DifficultyLine = false;
            string mode = "SinglePlayer";
            int column = 1;
            
            
            
            Console.Clear();
            WaveStream waveStream = new Mp3FileReader(@"..\..\..\Music\Menu.mp3");
            var waveOut = new WaveOut();
            waveOut.Init(waveStream);
            if (MusicStatus == true)
            {
                waveOut.Play();
            }

            Console.WriteLine("                                                                                   #######     ##     #######      ##    ##        ##     ###    ##");
            Console.WriteLine("                                                                                   ##   ##    ####    ##          ####  ####      ####    ###    ##");
            Console.WriteLine("                                                                                   ##   ##   ##  ##   ##          ####  ####     ##  ##   ## #   ##");
            Console.WriteLine("                                                                                   #######  ########  ##         ##  ####  ##   ########  ##  #  ##");
            Console.WriteLine("                                                                                   ##       ##    ##  ##         ##  ####  ##   ##    ##  ##   # ##");
            Console.WriteLine("                                                                                   ##      ##      ## ##        ##    ##    ## ##      ## ##    ###");
            Console.WriteLine("                                                                                   ##      ##      ## #######   ##    ##    ## ##      ## ##    ###");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                                                                     * Main Menu: *     ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       Choose Level     ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       Choose Difficulty    ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       Mode: "+mode+"    ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       Settings    ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       Exit    ");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            bool ActiveStatus = true;

            

            while (ActiveStatus==true) {
                if (Console.KeyAvailable) 
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (LevelLine == false && DifficultyLine == false)
                    {
                        if (key.Key == ConsoleKey.DownArrow) { line += 2; }
                        if (key.Key == ConsoleKey.UpArrow) { line -= 2; }
                        if (key.Key == ConsoleKey.Escape) { Console.Clear(); System.Environment.Exit(1); }



                        if (line < 10) { line = 10; }
                        if (line > 22) { line = 22; }
                        if (line == 10) 
                        {
                            Console.SetCursorPosition(0, 9);
                            Console.Write("                                                                                                     * Main Menu: *         ");
                            Console.SetCursorPosition(0, 11);
                            Console.Write("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
                        }
                        if (line == 12)
                        {
                            Console.SetCursorPosition(0, 9);
                            Console.Write("                                                                                                       Main Menu:         ");
                            Console.SetCursorPosition(0, 11);
                            Console.Write("                                                                                                     * START   Level: " + level + " Difficulty: " + difficulty + " *    ");
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                       Choose Level         ");
                        }
                        if (line == 14)
                        {
                            Console.SetCursorPosition(0, 11);
                            Console.Write("                                                                                                       START   Level: "+level+" Difficulty: "+difficulty+"     ");
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                     * Choose Level *       ");
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                       Choose Difficulty    ");
                        }
                        if (line == 16)
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                       Choose Level         ");
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                     * Choose Difficulty *  ");
                            Console.SetCursorPosition(0, 17);
                            Console.Write("                                                                                                       Mode: "+mode+"       ");
                        }
                        if (line == 18)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                       Choose Difficulty    ");
                            Console.SetCursorPosition(0, 17);
                            Console.Write("                                                                                                     * Mode: "+mode+" *     ");
                            Console.SetCursorPosition(0, 19);
                            Console.Write("                                                                                                       Settings             ");
                        }
                        if (line == 20)
                        {
                            Console.SetCursorPosition(0, 17);
                            Console.Write("                                                                                                       Mode: "+mode+"      ");
                            Console.SetCursorPosition(0, 19);
                            Console.Write("                                                                                                     * Settings *          ");
                            Console.SetCursorPosition(0, 21);
                            Console.Write("                                                                                                       Exit                ");
                        }
                        if (line == 22)
                        {
                            Console.SetCursorPosition(0, 19);
                            Console.Write("                                                                                                       Settings            ");
                            Console.SetCursorPosition(0, 21);
                            Console.Write("                                                                                                     * Exit *              ");
                        }

                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            if (line == 12) 
                            {
                                goto Game;
                            }
                            if (line == 14)
                            {
                                Console.SetCursorPosition(0, 13);
                                Console.Write("                                                                                                       Choose Level: * 1 *   2     3     Random  ");
                                LevelLine = true;
                                DifficultyLine = false;
                            }
                            if (line == 16)
                            {
                                Console.SetCursorPosition(0, 15);
                                Console.Write("                                                                                                       Choose Difficulty: * 1 *   2     3     4     5    ");
                                LevelLine = false;
                                DifficultyLine = true;
                            }
                            if (line == 18) 
                            {
                                if (mode == "SinglePlayer") { mode = "MultyPlayer"; } else { mode = "SinglePlayer"; }
                                Console.SetCursorPosition(0, 17);
                                Console.Write("                                                                                                     * Mode: "+mode+" *     ");
                            }
                            if (line == 20) 
                            {
                                goto Settings;
                            }
                            if (line == 22) 
                            {
                                Console.Clear(); 
                                System.Environment.Exit(1);
                            }
                        }
                    }

                    if (LevelLine == true) 
                    {
                        
                        if (key.Key == ConsoleKey.RightArrow) { column++; }
                        if (key.Key == ConsoleKey.LeftArrow) { column--; }
                        
                        if (column < 1) { column = 1; }
                        if (column > 4) { column = 4; }

                        if (column == 1) 
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                       Choose Level: * 1 *   2     3     Random  ");
                        }
                        if (column == 2)
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                       Choose Level:   1   * 2 *   3     Random  ");
                        }
                        if (column == 3)
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                       Choose Level:   1     2   * 3 *   Random  ");
                        }
                        if (column == 4)
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                       Choose Level:   1     2     3   * Random *");
                        }

                        if (key.Key == ConsoleKey.Enter)
                        {
                            level = column;
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                     * Choose Level *                            ");
                            LevelLine = false;
                            column = 1;
                            Console.SetCursorPosition(0, 11);
                            Console.Write("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
                        }
                        if (key.Key == ConsoleKey.Escape)
                        {
                            Console.SetCursorPosition(0, 13);
                            Console.Write("                                                                                                     * Choose Level *                            ");
                            LevelLine = false;
                            column = 1;
                        }
                    }

                    if (DifficultyLine == true)
                    {

                        if (key.Key == ConsoleKey.RightArrow) { column++; }
                        if (key.Key == ConsoleKey.LeftArrow) { column--; }

                        if (column < 1) { column = 1; }
                        if (column > 5) { column = 5; }

                        if (column == 1)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                       Choose Difficulty: * 1 *   2     3     4     5  ");
                        }
                        if (column == 2)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                       Choose Difficulty:   1   * 2 *   3     4     5  ");
                        }
                        if (column == 3)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                       Choose Difficulty:   1     2   * 3 *   4     5  ");
                        }
                        if (column == 4)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                       Choose Difficulty:   1     2     3   * 4 *   5  ");
                        }
                        if (column == 5)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                       Choose Difficulty:   1     2     3     4   * 5 *");
                        }


                        if (key.Key == ConsoleKey.Enter)
                        {
                            difficulty = column;
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                     * Choose Difficulty *                            ");
                            DifficultyLine = false;
                            column = 1;
                            Console.SetCursorPosition(0, 11);
                            Console.Write("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
                        }
                        if (key.Key == ConsoleKey.Escape)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("                                                                                                     * Choose Difficulty *                            ");
                            DifficultyLine = false;
                            column = 1;
                        }
                    }
                }
            }

        Settings:
            int sline = 10;
            Console.Clear();
            Console.WriteLine("                                                                                   #######     ##     #######      ##    ##        ##     ###    ##");
            Console.WriteLine("                                                                                   ##   ##    ####    ##          ####  ####      ####    ###    ##");
            Console.WriteLine("                                                                                   ##   ##   ##  ##   ##          ####  ####     ##  ##   ## #   ##");
            Console.WriteLine("                                                                                   #######  ########  ##         ##  ####  ##   ########  ##  #  ##");
            Console.WriteLine("                                                                                   ##       ##    ##  ##         ##  ####  ##   ##    ##  ##   # ##");
            Console.WriteLine("                                                                                   ##      ##      ## ##        ##    ##    ## ##      ## ##    ###");
            Console.WriteLine("                                                                                   ##      ##      ## #######   ##    ##    ## ##      ## ##    ###");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                                                                     * Settings: *               ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       Music: "+MusicStatus+"    ");
            Console.WriteLine();
            Console.WriteLine("                                                                                                       Back                      ");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            
            while (ActiveStatus == true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.DownArrow) { sline += 2; }
                    if (key.Key == ConsoleKey.UpArrow) { sline -= 2; }
                    if (key.Key == ConsoleKey.Escape) { goto MainMenu; }

                    if (sline < 10) { sline = 10; }
                    if (sline > 14) { sline = 14; }
                    if (sline == 10)
                    {
                        Console.SetCursorPosition(0, 9);
                        Console.Write("                                                                                                     * Settings: *              ");
                        Console.SetCursorPosition(0, 11);
                        Console.Write("                                                                                                       Music: "+MusicStatus+"   ");
                    }
                    if (sline == 12)
                    {
                        Console.SetCursorPosition(0, 9);
                        Console.Write("                                                                                                       Settings:                 ");
                        Console.SetCursorPosition(0, 11);
                        Console.Write("                                                                                                     * Music: "+MusicStatus+" *  ");
                        Console.SetCursorPosition(0, 13);
                        Console.Write("                                                                                                       Back                      ");
                    }
                    if (sline == 14)
                    {
                        Console.SetCursorPosition(0, 11);
                        Console.Write("                                                                                                       Music: "+MusicStatus+"     ");
                        Console.SetCursorPosition(0, 13);
                        Console.Write("                                                                                                     * Back *                    ");
                    }

                    if (key.Key == ConsoleKey.Spacebar) 
                    {
                        if (sline == 12) 
                        {
                            if (MusicStatus == true) { MusicStatus = false;  waveOut.Stop(); } else { MusicStatus = true; }
                            Console.SetCursorPosition(0, 11);
                            Console.Write("                                                                                                     * Music: " + MusicStatus + " *    ");
                        }
                        if (sline == 14) 
                        {
                            goto MainMenu;
                        }
                    }

                }
            }

        Game:
            bool GameActiveStatus = true;
            Console.Clear();
            string[] treks = { @"..\..\..\Music\V.mp3", @"..\..\..\Music\Valentinos.mp3", @"..\..\..\Music\The Rebel Path.mp3", @"..\..\..\Music\Maelstrom.mp3", @"..\..\..\Music\The Rebel Path (Cello Version).mp3" };
            Random r = new Random();
            int x = r.Next() % (5);
            waveOut.Stop();
            waveStream = new Mp3FileReader(treks[x]);
            waveOut = new WaveOut();
            waveOut.Init(waveStream);
            
            if (MusicStatus == true)
            {
                waveOut.Play();
            }
            Game G = new Game();
            Level L = new Level(G.TableSizeX(1), G.TableSizeY(1), 1, 1, G.LoadTable(1), difficulty);
            if (level != 4)
            {
                L = new Level(G.TableSizeX(level), G.TableSizeY(level), 1, 1, G.LoadTable(level), difficulty);
            }
            else 
            {
                Random rr = new Random();
                int xr = rr.Next() % 5 + 4;
                int yr = rr.Next() % 5 + 4;
                Table T = new Table(xr, yr);
                MapElementTable MET = new MapElementTable(T);
                MET.field[1, 1] = ' ';
                MET.field[1, 2] = ' ';
                MET.field[2, 1] = ' ';
                MET.field[2, 2] = ' ';
                L = new Level(MET.sizeX*5, MET.sizeY*5, MET.sizeX, MET.sizeX, MET.field, difficulty);
            }
            L.Load();
            DotField D = new DotField(L);
            D.Load();
            UpgradeField U = new UpgradeField(L, D);
            U.Load();
            Player P1 = new Player(1, 1, 1); P1.Load();
            Player P2 = new Player(1, 0, 0);

            for (int i = 0; i < L.NumberOfEnemies; i++) { L.enemies[i].Load(); }
            if (mode == "SinglePlayer")
            {
                G.LoadInfo1(L, D, P1);
            }
            else
            {
                P2 = new Player(L.sizeX - 2, L.sizeY - 2, 2);
                G.LoadInfo2(L, D, P1, P2);
                P2.Load();
            }
            for (int i = 0; i < L.NumberOfEnemies; i++) { L.enemies[i].Load(); }
            while (GameActiveStatus == true)
            {
                DateTime T1 = DateTime.Now;
                while ((DateTime.Now - T1).TotalMilliseconds < 200) { }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape) { waveOut.Stop(); goto MainMenu; }
                    if (mode == "SinglePlayer")
                    {
                        if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S) { P1.ChangeDirection('d'); }
                        if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W) { P1.ChangeDirection('u'); }
                        if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) { P1.ChangeDirection('l'); }
                        if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) { P1.ChangeDirection('r'); }
                    }
                    else 
                    {
                        if (key.Key == ConsoleKey.S) { P1.ChangeDirection('d'); }
                        if (key.Key == ConsoleKey.W) { P1.ChangeDirection('u'); }
                        if (key.Key == ConsoleKey.A) { P1.ChangeDirection('l'); }
                        if (key.Key == ConsoleKey.D) { P1.ChangeDirection('r'); }
                        if (key.Key == ConsoleKey.DownArrow) { P2.ChangeDirection('d'); }
                        if (key.Key == ConsoleKey.UpArrow) { P2.ChangeDirection('u'); }
                        if (key.Key == ConsoleKey.LeftArrow) { P2.ChangeDirection('l'); }
                        if (key.Key == ConsoleKey.RightArrow) { P2.ChangeDirection('r'); }
                    }
                }

                for (int i = 0; i < L.NumberOfEnemies; i++) { 
                    if (mode == "SinglePlayer") 
                    {
                        L.enemies[i].Go(L, D, U, P1, P1);
                        if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y) { if (L.enemies[i].lvl < P1.lvl) { L.enemies[i] = new Enemy(0, 0, '#', 's'); } else { goto Death; } }
                    }
                    else
                    {
                        L.enemies[i].Go(L, D, U, P1, P2);
                        if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y) { if (L.enemies[i].lvl < P1.lvl) { L.enemies[i] = new Enemy(0, 0, '#', 's'); } else { goto P1Died; } }
                        if (P2.x == L.enemies[i].x && P2.y == L.enemies[i].y) { if (L.enemies[i].lvl < P2.lvl) { L.enemies[i] = new Enemy(0, 0, '#', 's'); } else { goto P2Died; } }
                    }
                }

                P1.Go(L, D, U);
                P1.score += D.Take(P1.x, P1.y);
                P1.lvl += U.Take(P1.x, P1.y);
                P1.Load();
                if (P1.x == P2.x && P1.y == P2.y) 
                {
                    if (P1.lvl > P2.lvl) { goto P1killedP2; }
                    if (P1.lvl < P2.lvl) { goto P2killedP1; }

                    if (P1.score < P2.score) { goto P2score; }
                    if (P1.score > P2.score) { goto P1score; }

                    goto Draw;
                }
                if (mode == "SinglePlayer")
                {
                    G.LoadInfo1(L, D, P1);
                    for (int i = 0; i < L.NumberOfEnemies; i++)
                    {
                        if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y) { if (L.enemies[i].lvl < P1.lvl) { L.enemies[i] = new Enemy(0, 0, '#', 's'); } else { goto Death; } }
                    }
                    if (D.current == 0) { goto Victory; }
                }
                else
                {
                    P2.Go(L, D, U);
                    for (int i = 0; i < L.NumberOfEnemies; i++)
                    {
                        if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y) { if (L.enemies[i].lvl < P1.lvl) { L.enemies[i] = new Enemy(0, 0, '#', 's'); } else { goto P1Died; } }
                        if (P2.x == L.enemies[i].x && P2.y == L.enemies[i].y) { if (L.enemies[i].lvl < P2.lvl) { L.enemies[i] = new Enemy(0, 0, '#', 's'); } else { goto P2Died; } }
                    }
                    P2.score += D.Take(P2.x, P2.y);
                    P2.lvl += U.Take(P2.x, P2.y);
                    P2.Load();
                    if (P1.x == P2.x && P1.y == P2.y)
                    {
                        if (P1.lvl > P2.lvl) { goto P1killedP2; }
                        if (P1.lvl < P2.lvl) { goto P2killedP1; }

                        if (P1.score < P2.score) { goto P2score; }
                        if (P1.score > P2.score) { goto P1score; }

                        goto Draw;
                    }
                    if (D.current == 0)
                    {
                        if (P1.score < P2.score) { goto P2score; }
                        if (P1.score > P2.score) { goto P1score; }

                        goto Draw;
                    }
                    G.LoadInfo2(L, D, P1, P2);
                }

                


            }

        P1killedP2:
            Console.Clear();
            Console.WriteLine("P1 Won!");
            Console.WriteLine("P1 killed P2");
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        P2killedP1:
            Console.Clear();
            Console.WriteLine("P2 Won!");
            Console.WriteLine("P2 killed P1");
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        P1Died:
            Console.Clear();
            Console.WriteLine("P2 Won!");
            Console.WriteLine("P1 died to a bot...");
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        P2Died:
            Console.Clear();
            Console.WriteLine("P1 Won!");
            Console.WriteLine("P2 died to a bot...");
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        P1score:
            Console.Clear();
            Console.WriteLine("P1 Won!");
            Console.WriteLine("P1 score: " + P1.score);
            Console.WriteLine("P2 score: " + P2.score);
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        P2score:
            Console.Clear();
            Console.WriteLine("P2 Won!");
            Console.WriteLine("P1 score: " + P1.score);
            Console.WriteLine("P2 score: " + P2.score);
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        Draw:
            Console.Clear();
            Console.WriteLine("Draw.... seriously?");
            Console.WriteLine("P1 score: " + P1.score);
            Console.WriteLine("P2 score: " + P2.score);
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        Victory:
            Console.Clear();
            Console.WriteLine("You Won!");
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }
        Death:
            Console.Clear();
            Console.WriteLine("You lost...");
            Console.WriteLine();
            Console.WriteLine("Press Space to continue");
            while (0 == 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) { waveOut.Stop(); goto MainMenu; }
                }
            }


        }
    }
}
