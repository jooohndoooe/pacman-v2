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
    class ConsoleMethods
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        public void MaximizeConsole()
        {
            ShowWindow(ThisConsole, MAXIMIZE);
            System.Console.CursorVisible = false;
        }

        public void MainMenu(int level, int difficulty, string mode, bool MusicStatus)
        {
            MaximizeConsole();
            System.Console.SetCursorPosition(0, 0);

            int MenuLine = 10;
            bool LevelLineActiveStatus = false;
            bool DifficultyLineActiveStatus = false;
            int MenuColumn = 1;



            System.Console.Clear();
            WaveStream waveStream = new Mp3FileReader(@"..\..\..\Music\Menu.mp3");
            var waveOut = new WaveOut();
            waveOut.Init(waveStream);
            if (MusicStatus == true)
            {
                waveOut.Play();
            }
            else
            {
                waveOut.Stop();
            }

            System.Console.WriteLine("                                                                                   #######     ##     #######      ##    ##        ##     ###    ##");
            System.Console.WriteLine("                                                                                   ##   ##    ####    ##          ####  ####      ####    ###    ##");
            System.Console.WriteLine("                                                                                   ##   ##   ##  ##   ##          ####  ####     ##  ##   ## #   ##");
            System.Console.WriteLine("                                                                                   #######  ########  ##         ##  ####  ##   ########  ##  #  ##");
            System.Console.WriteLine("                                                                                   ##       ##    ##  ##         ##  ####  ##   ##    ##  ##   # ##");
            System.Console.WriteLine("                                                                                   ##      ##      ## ##        ##    ##    ## ##      ## ##    ###");
            System.Console.WriteLine("                                                                                   ##      ##      ## #######   ##    ##    ## ##      ## ##    ###");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                     * Main Menu: *     ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       Choose Level     ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       Choose Difficulty    ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       Mode: " + mode + "    ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       Settings    ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       Exit    ");
            System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            bool ActiveStatus = true;

            GameField G = new GameField();

            while (ActiveStatus == true)
            {
                if (System.Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = System.Console.ReadKey();
                    if (LevelLineActiveStatus == false && DifficultyLineActiveStatus == false)
                    {
                        if (key.Key == ConsoleKey.DownArrow) { MenuLine += 2; }
                        if (key.Key == ConsoleKey.UpArrow) { MenuLine -= 2; }
                        if (key.Key == ConsoleKey.Escape) { System.Console.Clear(); System.Environment.Exit(1); }



                        if (MenuLine < 10) { MenuLine = 10; }
                        if (MenuLine > 22) { MenuLine = 22; }
                        if (MenuLine == 10)
                        {
                            System.Console.SetCursorPosition(0, 9);
                            System.Console.Write("                                                                                                     * Main Menu: *         ");
                            System.Console.SetCursorPosition(0, 11);
                            System.Console.Write("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
                        }
                        if (MenuLine == 12)
                        {
                            System.Console.SetCursorPosition(0, 9);
                            System.Console.Write("                                                                                                       Main Menu:         ");
                            System.Console.SetCursorPosition(0, 11);
                            System.Console.Write("                                                                                                     * START   Level: " + level + " Difficulty: " + difficulty + " *    ");
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                       Choose Level                                                                  ");
                        }
                        if (MenuLine == 14)
                        {
                            System.Console.SetCursorPosition(0, 11);
                            System.Console.Write("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                     * Choose Level *                                                                         ");
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                       Choose Difficulty    ");
                        }
                        if (MenuLine == 16)
                        {
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                       Choose Level                                                               ");
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                     * Choose Difficulty *  ");
                            System.Console.SetCursorPosition(0, 17);
                            System.Console.Write("                                                                                                       Mode: " + mode + "       ");
                        }
                        if (MenuLine == 18)
                        {
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                       Choose Difficulty    ");
                            System.Console.SetCursorPosition(0, 17);
                            System.Console.Write("                                                                                                     * Mode: " + mode + " *     ");
                            System.Console.SetCursorPosition(0, 19);
                            System.Console.Write("                                                                                                       Settings             ");
                        }
                        if (MenuLine == 20)
                        {
                            System.Console.SetCursorPosition(0, 17);
                            System.Console.Write("                                                                                                       Mode: " + mode + "      ");
                            System.Console.SetCursorPosition(0, 19);
                            System.Console.Write("                                                                                                     * Settings *          ");
                            System.Console.SetCursorPosition(0, 21);
                            System.Console.Write("                                                                                                       Exit                ");
                        }
                        if (MenuLine == 22)
                        {
                            System.Console.SetCursorPosition(0, 19);
                            System.Console.Write("                                                                                                       Settings            ");
                            System.Console.SetCursorPosition(0, 21);
                            System.Console.Write("                                                                                                     * Exit *              ");
                        }

                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            if (MenuLine == 12)
                            {
                                waveOut.Stop();
                                G.GameStart(level, difficulty, mode, MusicStatus);
                            }
                            if (MenuLine == 14)
                            {
                                System.Console.SetCursorPosition(0, 13);
                                System.Console.Write("                                                                                                       Choose Level: * 1 *   2     Custom     Random     ");
                                LevelLineActiveStatus = true;
                                DifficultyLineActiveStatus = false;
                            }
                            if (MenuLine == 16)
                            {
                                System.Console.SetCursorPosition(0, 15);
                                System.Console.Write("                                                                                                       Choose Difficulty: * 1 *   2     3     4     5    ");
                                LevelLineActiveStatus = false;
                                DifficultyLineActiveStatus = true;
                            }
                            if (MenuLine == 18)
                            {
                                if (mode == "SinglePlayer") { mode = "MultyPlayer"; } else { mode = "SinglePlayer"; }
                                System.Console.SetCursorPosition(0, 17);
                                System.Console.Write("                                                                                                     * Mode: " + mode + " *     ");
                            }
                            if (MenuLine == 20)
                            {
                                waveOut.Stop();
                                Settings(level, difficulty, mode, MusicStatus);
                            }
                            if (MenuLine == 22)
                            {
                                System.Console.Clear();
                                System.Environment.Exit(1);
                            }
                        }
                    }

                    if (LevelLineActiveStatus == true)
                    {

                        if (key.Key == ConsoleKey.RightArrow) { MenuColumn++; }
                        if (key.Key == ConsoleKey.LeftArrow) { MenuColumn--; }

                        if (MenuColumn < 1) { MenuColumn = 1; }
                        if (MenuColumn > 4) { MenuColumn = 4; }

                        if (MenuColumn == 1)
                        {
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                       Choose Level: * 1 *   2     Custom     Random   ");
                        }
                        if (MenuColumn == 2)
                        {
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                       Choose Level:   1   * 2 *   Custom     Random   ");
                        }
                        if (MenuColumn == 3)
                        {
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                       Choose Level:   1     2   * Custom *   Random   ");
                        }
                        if (MenuColumn == 4)
                        {
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                       Choose Level:   1     2     Custom   * Random * ");
                        }

                        if (key.Key == ConsoleKey.Enter)
                        {
                            level = MenuColumn;
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                     * Choose Level *                                     ");
                            LevelLineActiveStatus = false;
                            MenuColumn = 1;
                            System.Console.SetCursorPosition(0, 11);
                            System.Console.Write("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
                        }
                        if (key.Key == ConsoleKey.Escape)
                        {
                            System.Console.SetCursorPosition(0, 13);
                            System.Console.Write("                                                                                                     * Choose Level *                            ");
                            LevelLineActiveStatus = false;
                            MenuColumn = 1;
                        }
                    }

                    if (DifficultyLineActiveStatus == true)
                    {

                        if (key.Key == ConsoleKey.RightArrow) { MenuColumn++; }
                        if (key.Key == ConsoleKey.LeftArrow) { MenuColumn--; }

                        if (MenuColumn < 1) { MenuColumn = 1; }
                        if (MenuColumn > 5) { MenuColumn = 5; }

                        if (MenuColumn == 1)
                        {
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                       Choose Difficulty: * 1 *   2     3     4     5   ");
                        }
                        if (MenuColumn == 2)
                        {
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                       Choose Difficulty:   1   * 2 *   3     4     5   ");
                        }
                        if (MenuColumn == 3)
                        {
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                       Choose Difficulty:   1     2   * 3 *   4     5   ");
                        }
                        if (MenuColumn == 4)
                        {
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                       Choose Difficulty:   1     2     3   * 4 *   5   ");
                        }
                        if (MenuColumn == 5)
                        {
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                       Choose Difficulty:   1     2     3     4   * 5 * ");
                        }


                        if (key.Key == ConsoleKey.Enter)
                        {
                            difficulty = MenuColumn;
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                     * Choose Difficulty *                                ");
                            DifficultyLineActiveStatus = false;
                            MenuColumn = 1;
                            System.Console.SetCursorPosition(0, 11);
                            System.Console.Write("                                                                                                       START   Level: " + level + " Difficulty: " + difficulty + "     ");
                        }
                        if (key.Key == ConsoleKey.Escape)
                        {
                            System.Console.SetCursorPosition(0, 15);
                            System.Console.Write("                                                                                                     * Choose Difficulty *                            ");
                            DifficultyLineActiveStatus = false;
                            MenuColumn = 1;
                        }
                    }
                }
            }
        }

        public void Settings(int level, int difficulty, string mode, bool MusicStatus)
        {
            int SettingsLine = 10;
            System.Console.Clear();
            System.Console.WriteLine("                                                                                   #######     ##     #######      ##    ##        ##     ###    ##");
            System.Console.WriteLine("                                                                                   ##   ##    ####    ##          ####  ####      ####    ###    ##");
            System.Console.WriteLine("                                                                                   ##   ##   ##  ##   ##          ####  ####     ##  ##   ## #   ##");
            System.Console.WriteLine("                                                                                   #######  ########  ##         ##  ####  ##   ########  ##  #  ##");
            System.Console.WriteLine("                                                                                   ##       ##    ##  ##         ##  ####  ##   ##    ##  ##   # ##");
            System.Console.WriteLine("                                                                                   ##      ##      ## ##        ##    ##    ## ##      ## ##    ###");
            System.Console.WriteLine("                                                                                   ##      ##      ## #######   ##    ##    ## ##      ## ##    ###");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                     * Settings: *               ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       Music: " + MusicStatus + "    ");
            System.Console.WriteLine();
            System.Console.WriteLine("                                                                                                       Back                      ");
            System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");


            while (true)
            {
                if (System.Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = System.Console.ReadKey();
                    if (key.Key == ConsoleKey.DownArrow) { SettingsLine += 2; }
                    if (key.Key == ConsoleKey.UpArrow) { SettingsLine -= 2; }
                    if (key.Key == ConsoleKey.Escape) { MainMenu(level, difficulty, mode, MusicStatus); }

                    if (SettingsLine < 10) { SettingsLine = 10; }
                    if (SettingsLine > 14) { SettingsLine = 14; }
                    if (SettingsLine == 10)
                    {
                        System.Console.SetCursorPosition(0, 9);
                        System.Console.Write("                                                                                                     * Settings: *              ");
                        System.Console.SetCursorPosition(0, 11);
                        System.Console.Write("                                                                                                       Music: " + MusicStatus + "   ");
                    }
                    if (SettingsLine == 12)
                    {
                        System.Console.SetCursorPosition(0, 9);
                        System.Console.Write("                                                                                                       Settings:                 ");
                        System.Console.SetCursorPosition(0, 11);
                        System.Console.Write("                                                                                                     * Music: " + MusicStatus + " *  ");
                        System.Console.SetCursorPosition(0, 13);
                        System.Console.Write("                                                                                                       Back                      ");
                    }
                    if (SettingsLine == 14)
                    {
                        System.Console.SetCursorPosition(0, 11);
                        System.Console.Write("                                                                                                       Music: " + MusicStatus + "     ");
                        System.Console.SetCursorPosition(0, 13);
                        System.Console.Write("                                                                                                     * Back *                    ");
                    }

                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        if (SettingsLine == 12)
                        {
                            if (MusicStatus == true) { MusicStatus = false; } else { MusicStatus = true; }
                            System.Console.SetCursorPosition(0, 11);
                            System.Console.Write("                                                                                                     * Music: " + MusicStatus + " *    ");
                        }
                        if (SettingsLine == 14)
                        {
                            MainMenu(level, difficulty, mode, MusicStatus);
                        }
                    }

                }
            }
        }


    }
}
