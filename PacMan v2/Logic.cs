using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_v2
{
    public class Logic
    {
        public Level L { get; set; }
        public DotField D {get; set;}
        public UpgradeField U {get; set;}
        public GravityField G { get; set; }
        public Player P1 { get; set; }
        public Player P2 { get; set; }
        public Point FinishPoint { get; set; }

        public int level { get; set; }
        public int difficulty { get; set; }
        public string mode { get; set; }
        public bool MusicStatus { get; set; }



        public DateTime Start { get; set; }
        public DateTime TeleportTime1 { get; set; }
        public DateTime TeleportTime2 { get; set; }
        public int NumberOfSteps1 { get; set; }
        public int NumberOfSteps2 { get; set; }
        public int TeleportNumberOfSteps1 { get; set; }
        public int TeleportNumberOfSteps2 { get; set; }


        public Level InterfaceField { get; set; }

        public bool LevelEditorMode { get; set; }
        public char[,] CustomLevel { get; set; }

        public string result { get; set; }


        public bool emulation { get; set; } = false;


        public Logic(int level, int difficulty, string mode, bool MusicStatus, bool LevelEditorMode) 
        {
            this.level = level;
            this.difficulty = difficulty;
            this.mode = mode;
            this.MusicStatus = MusicStatus;
            this.LevelEditorMode = LevelEditorMode;
            GameField GF = new GameField();
            Random r = new Random();
            L = new Level(GF.TableSizeX(1), GF.TableSizeY(1), 1, 1, GF.LoadTable(1), difficulty);
            if (level < 4)
            {
                L = new Level(GF.TableSizeX(level), GF.TableSizeY(level), GF.TableSizeX(level) / 20 + 1, difficulty, GF.LoadTable(level), difficulty);
            }

            P1 = new Player(1, 1, 1);
            P2 = new Player(0, 0, 0);
            P2.ch = '#';

            if (level == 3)
            {
                LevelEditor(10, 10);
                if (!LevelEditorMode)
                {
                    L = new Level(10, 10, 0, 0, CustomLevel, difficulty);

                    this.LevelEditorMode = true;
                    P1.lvl = 20;
                }
                else
                {
                    L = new Level(10, 10, 1, 1, CustomLevel, difficulty);
                    this.LevelEditorMode = false;
                }
                
            }

            if (level == 4)
            {
                int RandomXDimention = r.Next() % 5 + 4;
                int RandomYDimention = r.Next() % 5 + 4;
                Table T = new Table(RandomXDimention, RandomYDimention);
                MapElementTable MET = new MapElementTable(T);
                L = new Level(MET.sizeX, MET.sizeY, difficulty, MET.sizeX / 4, MET.field, difficulty);
            }

            


            
            FinishPoint = new Point(L.sizeX - 2, L.sizeY - 2, 'F');

            if (mode == "MultyPlayer") { 
                FinishPoint = new Point(0, 0, '#');
                P2 = new Player(L.sizeX - 2, L.sizeY - 2, 2);
            }

            //L.SetFinishOutLine(FinishPoint);

            D = new DotField(L);
            U = new UpgradeField(L, D);
            G = new GravityField(L, 1, false);

            Start = DateTime.Now;
            TeleportTime1 = DateTime.Now;
            TeleportTime2 = DateTime.Now;
            NumberOfSteps1 = 0;
            NumberOfSteps2 = 0;
            TeleportNumberOfSteps1 = 0;
            TeleportNumberOfSteps2 = 0;


            InterfaceField = new Level(L, D, U, P1, P2, FinishPoint);

        }

        public void LevelEditor(int sizeX, int sizeY) 
        {
            CustomLevel = new char[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    CustomLevel[i, j] = ' ';
                }
            }
            for (int i = 0; i < sizeX; i++) { CustomLevel[i, 0] = '#'; CustomLevel[i, sizeY - 1] = '#'; }
            for (int i = 0; i < sizeY; i++) { CustomLevel[0, i] = '#'; CustomLevel[sizeX - 1, i] = '#'; }

        }

        public string MoveEnemies()
        {
            for (int i = 0; i < L.EnemyCount; i++)
            {
                if (mode == "SinglePlayer")
                {
                    L.enemies[i].GravityGo(L, D, U, P1, P1, G);
                    if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y)
                    {
                        if (L.enemies[i].lvl < P1.lvl)
                        {
                            L.enemies[i] = new Enemy(0, 0, '#', 's');
                        }
                        else
                        {
                            if (P1.lives <= 1)
                            {
                                return "Death";
                            }
                        }
                    }
                }
                else
                {
                    L.enemies[i].GravityGo(L, D, U, P1, P2, G);
                    if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y)
                    {
                        if (L.enemies[i].lvl < P1.lvl)
                        {
                            L.enemies[i] = new Enemy(0, 0, '#', 's');
                        }
                        else
                        {
                            if (P1.lives <= 1)
                            {
                                return "P1Died";
                            }
                        }
                    }
                    if (P2.x == L.enemies[i].x && P2.y == L.enemies[i].y)
                    {
                        if (L.enemies[i].lvl < P2.lvl)
                        {
                            L.enemies[i] = new Enemy(0, 0, '#', 's');
                        }
                        else
                        {
                            if (P2.lives <= 1)
                            {
                                return "P2Died";
                            }
                        }
                    }
                }
            }
            InterfaceField = new Level(L, D, U, P1, P2, FinishPoint);
            return "supra";
        }

        public string MovePlayers() 
        {
            if (emulation) 
            {

                if (P1.CanPass(FinishPoint.x, FinishPoint.y, L))
                {
                    P1.direction = P1.FindPathAvoidingEnemies(FinishPoint.x, FinishPoint.y, L, 0);
                }
                else 
                {
                    P1.direction = P1.FindPathAvoidingEnemies(P1.ClosestUpgradeX(L, U), P1.ClosestUpgradeY(L, U), L, 0);
                }
            }
            P1.GravityGo(L, D, U, G);
            NumberOfSteps1++;
            

            P1.score += D.Take(P1.x, P1.y);
            P1.lvl += U.Take(P1.x, P1.y);
            if (P1.x == P2.x && P1.y == P2.y)
            {
                if (P1.lvl > P2.lvl)
                {
                    if (P1.lives > 1)
                    {
                        P1.lives--;
                    }
                    else
                    {
                        return "P1killedP2";
                    }
                }
                if (P1.lvl < P2.lvl)
                {
                    if (P2.lives > 1)
                    {
                        P2.lives--;
                    }
                    else
                    {
                        return "P2killedP1";
                    }
                }

                if (P1.score < P2.score)
                {
                    if (P1.lives > 1)
                    {
                        P1.lives--;
                    }
                    else
                    {
                        return "P2Score";
                    }
                }
                if (P1.score > P2.score)
                {
                    if (P1.lives > 1)
                    {
                        P1.lives--;
                    }
                    else
                    {
                        return "P1Score";
                    }
                }
                P1.lives--;
                P2.lives--;
                if (P1.lives == 0 && P2.lives != 0)
                {
                    return "P2killedP1";
                }
                if (P1.lives != 0 && P2.lives == 0)
                {
                    return "P1killedP2";
                }
                return "Draw";
            }

            int time = (int)(DateTime.Now - Start).TotalSeconds;
            time = 600 - time;

            if (mode == "SinglePlayer")
            {
                for (int i = 0; i < L.EnemyCount; i++)
                {
                    if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y)
                    {
                        if (L.enemies[i].lvl < P1.lvl)
                        {
                            L.enemies[i] = new Enemy(0, 0, '#', 's');
                        }
                        else
                        {
                            if (P1.lives > 1)
                            {
                                P1.lives--;
                            }
                            else
                            {
                                return "Death";
                            }
                        }
                    }
                }
                if (D.CurrentLeft == 0)
                {
                    return "Victory";
                }
                if (P1.score > 10 || (DateTime.Now - Start).TotalMilliseconds > 20000)
                {
                    D.Delete(L.sizeX - 2, L.sizeY - 2);
                    if (P1.x == FinishPoint.x && P1.y == FinishPoint.y) {
                        return "Finish";
                    }
                }

                if (time <= 0) {
                    return "Time";
                }
            }
            else
            {
                P2.GravityGo(L, D, U, G);
                NumberOfSteps2++;
                for (int i = 0; i < L.EnemyCount; i++)
                {
                    if (P1.x == L.enemies[i].x && P1.y == L.enemies[i].y)
                    {
                        if (L.enemies[i].lvl < P1.lvl)
                        {
                            L.enemies[i] = new Enemy(0, 0, '#', 's');
                        }
                        else
                        {
                            if (P1.lives > 1)
                            {
                                P1.lives--;
                            }
                            else
                            {
                                return "P1Died";
                            }
                        }
                    }
                    if (P2.x == L.enemies[i].x && P2.y == L.enemies[i].y)
                    {
                        if (L.enemies[i].lvl < P2.lvl)
                        {
                            L.enemies[i] = new Enemy(0, 0, '#', 's');
                        }
                        else
                        {
                            if (P2.lives > 1)
                            {
                                P2.lives--;
                            }
                            else
                            {
                                return "P2Died";
                            }
                        }
                    }
                }
                P2.score += D.Take(P2.x, P2.y);
                P2.lvl += U.Take(P2.x, P2.y);
                if (P1.x == P2.x && P1.y == P2.y)
                {
                    if (P1.lvl > P2.lvl)
                    {
                        if (P1.lives > 1)
                        {
                            P1.lives--;
                        }
                        else
                        {
                            return "P1killedP2";
                        }
                    }
                    if (P1.lvl < P2.lvl)
                    {
                        if (P2.lives > 1)
                        {
                            P2.lives--;
                        }
                        else
                        {
                            return "P2killedP1";
                        }
                    }

                    if (P1.score < P2.score)
                    {
                        if (P1.lives > 1)
                        {
                            P1.lives--;
                        }
                        else
                        {
                            return "P2Score";
                        }
                    }
                    if (P1.score > P2.score)
                    {
                        if (P1.lives > 1)
                        {
                            P1.lives--;
                        }
                        else
                        {
                            return "P1Score";
                        }
                    }
                    P1.lives--;
                    P2.lives--;
                    if (P1.lives == 0 && P2.lives != 0)
                    {
                        return "P2killedP1";
                    }
                    if (P1.lives != 0 && P2.lives == 0)
                    {
                        return "P1killedP2";
                    }
                    return "Draw";
                }
                if (D.CurrentLeft == 0)
                {
                    if (P1.score < P2.score)
                    {
                        if (P1.lives > 1)
                        {
                            P1.lives--;
                        }
                        else
                        {
                            return "P2Score";
                        }
                    }
                    if (P1.score > P2.score)
                    {
                        if (P1.lives > 1)
                        {
                            P1.lives--;
                        }
                        else
                        {
                            return "P1Score";
                        }
                    }
                   
                    return "Draw";
                }

                if (time <= 0)
                {
                    if (P1.score < P2.score)
                    {
                        if (P1.lives > 1)
                        {
                            P1.lives--;
                        }
                        else
                        {
                            return "P2Score";
                        }
                    }
                    if (P1.score > P2.score)
                    {
                        if (P1.lives > 1)
                        {
                            P1.lives--;
                        }
                        else
                        {
                            return "P1Score";
                        }
                    }

                    return "Draw";
                }

            }
            Level InterfaceField = new Level(L, D, U, P1, P2, FinishPoint);
            return "supra";
        }

    }
}
