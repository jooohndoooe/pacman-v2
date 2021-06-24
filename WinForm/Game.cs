using PacMan_v2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using NAudio.Wave;

namespace WinForm
{ 
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
        }

        public int level { get; set; }
        public int difficulty { get; set; }
        public string mode { get; set; }

        public bool GameActiveStatus { get; set; }

        public Level InterfaceFieldPrevious { get; set; } 
        public Logic logic { get; set; }

        public Logic logicBackup { get; set; }

        public event EventHandler OnMainMenu;


        public event EventHandler<EndEventArgs> OnEnd;




        protected override void OnPaint(PaintEventArgs e)
        {
            //Level.OnDraw += PointDraw.Draw;

            var L = logic.InterfaceField;
            if (L == null) { return; }
            var cellHeight = (Height - 150) / L.sizeY;
            var cellWidth = Width / L.sizeX;

            if (cellHeight > cellWidth) { cellHeight = cellWidth; } else { cellWidth = cellHeight; }

            for (int row = 0; row < L.sizeY; row++)
            {
                for (int col = 0; col < L.sizeX; col++)
                {
                    PointDraw.graphics = e.Graphics;
                    if (L.field[col, row].ch == 'O')
                    {
                        PointDraw.Draw(null, new DrawEventArgs(L.field[col, row].ch, new Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight), logic.P1.direction));
                    }
                    else
                    {
                        if (L.field[col, row].ch == '@')
                        {
                            PointDraw.Draw(null, new DrawEventArgs(L.field[col, row].ch, new Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight), logic.P2.direction));
                        }
                        else
                        {
                            PointDraw.Draw(null, new DrawEventArgs(L.field[col, row].ch, new Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight), ' '));
                        }
                    }
                    //L.field[col, row].DrawWF();
                }
            }
            L.Load();
            InterfaceFieldPrevious = logic.InterfaceField;

        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            
            if (e.KeyData == Keys.Escape)
            {
                OnMainMenu?.Invoke(this, EventArgs.Empty);
            }
            if (e.KeyData == Keys.R)
            {
                GameField G = new GameField();
                logic = new Logic(logic.level, logic.difficulty, logic.mode, logic.MusicStatus, false);                
                level = logic.level;
                difficulty = logic.difficulty;
                mode = logic.mode;
                InterfaceFieldPrevious = logic.InterfaceField;
            }
            if (e.KeyData == Keys.T && (DateTime.Now - logic.TeleportTime1).TotalSeconds >= 2 && logic.NumberOfSteps1 - logic.TeleportNumberOfSteps1 >= 5)
            {
                logic.TeleportTime1 = DateTime.Now;
                logic.TeleportNumberOfSteps1 = logic.NumberOfSteps1;

                logic.P1.Teleport(logic.L);
            }
            if (e.KeyData == Keys.G) { logic.G.Turn(); }
            if (e.KeyData == Keys.I) { logic.G.Invert(); }


            if (mode == "SinglePlayer")
            {
                if (e.KeyData == Keys.Down || e.KeyData == Keys.S) { logic.P1.ChangeDirection('d'); }
                if (e.KeyData == Keys.Up || e.KeyData == Keys.W) { logic.P1.ChangeDirection('u'); }
                if (e.KeyData == Keys.Left || e.KeyData == Keys.A) { logic.P1.ChangeDirection('l'); }
                if (e.KeyData == Keys.Right || e.KeyData == Keys.D) { logic.P1.ChangeDirection('r'); }
                if (e.KeyData == Keys.H) 
                {
                    if (Hint.Visible == false)
                    {
                        Hint.Visible = true;
                        HintValue.Visible = true;
                    }
                    else
                    {
                        Hint.Visible = false;
                        HintValue.Visible = false;
                    }
                }
                if (e.KeyData == Keys.E) 
                {
                    if (!logic.emulation)
                    {
                        logic.emulation = true;
                        logicBackup = logic;
                    }
                    else
                    {
                        //GameField G = new GameField();

                        logic = logicBackup;
                        logic.emulation = false;
                        level = logic.level;
                        difficulty = logic.difficulty;
                        mode = logic.mode;
                        InterfaceFieldPrevious = logic.InterfaceField;
                    }
                }
                if (logic.LevelEditorMode)
                {
                    if (e.KeyData == Keys.Space)
                    {
                        if (logic.CustomLevel[logic.P1.x, logic.P1.y] == '#')
                        {
                            logic.CustomLevel[logic.P1.x, logic.P1.y] = ' ';
                        }
                        else
                        {
                            logic.CustomLevel[logic.P1.x, logic.P1.y] = '#';
                        }
                        logic.L = new Level(10, 10, 0, 0, logic.CustomLevel, difficulty);
                        logic.InterfaceField = logic.L;
                        InterfaceFieldPrevious = logic.L;
                    }
                    else
                    {
                        logic.MovePlayers();
                    }

                    if (e.KeyData == Keys.Enter) 
                    {
                        char[,] backupCustomLevel=logic.CustomLevel;
                        logic = new Logic(3, logic.difficulty, logic.mode, logic.MusicStatus, true);
                        logic.L= new Level(10, 10, 1, 1, backupCustomLevel, difficulty);
                        logic.L.SetFinishOutLine(logic.FinishPoint);
                        logic. D = new DotField(logic.L);
                        logic.U = new UpgradeField(logic.L, logic.D);
                        logic.G = new GravityField(logic.L, 1, false);
                        level = logic.level;
                        difficulty = logic.difficulty;
                        mode = logic.mode;
                        InterfaceFieldPrevious = logic.InterfaceField;
                    }
                }

            }
            else
            {
                if (e.KeyData == Keys.S) { logic.P1.ChangeDirection('d'); }
                if (e.KeyData == Keys.W) { logic.P1.ChangeDirection('u'); }
                if (e.KeyData == Keys.A) { logic.P1.ChangeDirection('l'); }
                if (e.KeyData == Keys.D) { logic.P1.ChangeDirection('r'); }
                if (e.KeyData == Keys.Down) { logic.P2.ChangeDirection('d'); }
                if (e.KeyData == Keys.Up) { logic.P2.ChangeDirection('u'); }
                if (e.KeyData == Keys.Left) { logic.P2.ChangeDirection('l'); }
                if (e.KeyData == Keys.Right) { logic.P2.ChangeDirection('r'); }
                if (e.KeyData == Keys.L && (DateTime.Now - logic.TeleportTime2).TotalSeconds >= 2 && logic.NumberOfSteps2 - logic.TeleportNumberOfSteps2 >= 5)
                {
                    logic.TeleportTime2 = DateTime.Now;
                    logic.TeleportNumberOfSteps2 = logic.NumberOfSteps2;

                    logic.P2.Teleport(logic.L);
                }

            }
            
            base.OnPreviewKeyDown(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (logic == null || !GameActiveStatus) { return; }
            InterfaceFieldPrevious = logic.InterfaceField;
            
            if (logic != null)
            {
                  


                string result = logic.MoveEnemies();
                    

                    
                if (result == "P1Died")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P1 died to a bot!"));
                    //OnP1Died?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2Died")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P2 died to a bot!"));

                    //OnP2Died?.Invoke(this, EventArgs.Empty);
                }



                if (!logic.LevelEditorMode)
                {
                    result = logic.MovePlayers();
                }
                 
                

                if (result == "P1Died")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P1 died to a bot!"));
                    //OnP1Died?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2Died")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P2 died to a bot!"));
                    //OnP2Died?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P1killedP2")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P1 killed P2"));
                    //OnP1killedP2?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2killedP1")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P2 killed P1"));
                    //OnP2killedP1?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P1Score")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P1 Won!"));
                    //OnP1Score?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2Score")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("P2 Won!"));
                    //OnP2Score?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Death")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("You Died!"));
                    //OnDeath?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Victory")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("You Won!"));
                    //OnVictory?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Time")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("Time has ended"));
                    ///OnTime?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Finish")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("You have reached the finish line"));
                    //OnFinish?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Draw")
                {
                    GameActiveStatus = false;
                    OnEnd?.Invoke(this, new EndEventArgs("Draw!"));
                    //OnDraw?.Invoke(this, EventArgs.Empty);
                }

                if (mode == "SinglePlayer")
                {
                    P2ScoreLabel.Visible = false;
                    P2ScoreAmount.Visible = false;
                    P2x.Visible = false;
                    P2xAmount.Visible = false;
                    P2y.Visible = false;
                    P2yAmount.Visible = false;
                    P2Health.Visible = false;
                    P2HealthAmount.Visible = false;
                    P2Lives.Visible = false;
                    P2LivesAmount.Visible = false;
                }
                else
                {
                    P2ScoreLabel.Visible = true;
                    P2ScoreAmount.Visible = true;
                    P2x.Visible = true;
                    P2xAmount.Visible = true;
                    P2y.Visible = true;
                    P2yAmount.Visible = true;
                    P2Health.Visible = true;
                    P2HealthAmount.Visible = true;
                    P2Lives.Visible = true;
                    P2LivesAmount.Visible = true;
                }

                string hint="";
                char hintCh;
                if (logic.P1.CanPass(logic.FinishPoint.x, logic.FinishPoint.y, logic.L))
                {
                    hintCh = logic.P1.FindPathAvoidingEnemies(logic.FinishPoint.x, logic.FinishPoint.y, logic.L, 2);
                }
                else
                {
                    hintCh = logic.P1.FindPathAvoidingEnemies(logic.P1.ClosestUpgradeX(logic.L, logic.U), logic.P1.ClosestUpgradeY(logic.L, logic.U), logic.L, 2);
                }

                if (hintCh == 'r') { hint = "Right"; }
                if (hintCh == 'l') { hint = "Left"; }
                if (hintCh == 'u') { hint = "Up"; }
                if (hintCh == 'd') { hint = "Down"; }

                HintValue.Text = $"{hint}";
                P1ScoreAmount.Text = $"{logic.P1.score}";
                P2ScoreAmount.Text = $"{logic.P2.score}";
                P1xAmount.Text = $"{logic.P1.x}";
                P2xAmount.Text = $"{logic.P2.x}";
                P1yAmount.Text = $"{logic.P1.y}";
                P2yAmount.Text = $"{logic.P2.y}";
                P1HealthAmount.Text = $"{logic.P1.health}";
                P2HealthAmount.Text = $"{logic.P2.health}";
                P1LivesAmount.Text = $"{logic.P1.lives}";
                P2LivesAmount.Text = $"{logic.P2.lives}";
                TimeAmount.Text = $"{(600 - (int)(DateTime.Now - logic.Start).TotalSeconds) / 60 + ":" + (600 - (int)(DateTime.Now - logic.Start).TotalSeconds) % 60}";

            }
            
            Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Hint_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
    public class EndEventArgs : EventArgs
    {
        public string messadge { get; set; }
        public EndEventArgs(string messadge)
        {
            this.messadge = messadge;
        }
    }
}
