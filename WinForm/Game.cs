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

        public event EventHandler OnMainMenu;
       


        public event EventHandler OnP1killedP2;
        public event EventHandler OnP2killedP1;
        public event EventHandler OnP1Score;
        public event EventHandler OnP2Score;
        public event EventHandler OnP1Died;
        public event EventHandler OnP2Died;
        public event EventHandler OnDraw;
        public event EventHandler OnVictory;
        public event EventHandler OnDeath;
        public event EventHandler OnTime;
        public event EventHandler OnFinish;


        protected override void OnPaint(PaintEventArgs e)
        {
            var L = logic.InterfaceField;
            if (L == null) { return; }
            var cellHeight = (Height - 150) / L.sizeY;
            var cellWidth = Width / L.sizeX;
            for (int row = 0; row < L.sizeY; row++)
            {
                for (int col = 0; col < L.sizeX; col++)
                {
                    L.field[col,row].DrawWF(e.Graphics, new Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight));
                }
            }
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
                    OnP1Died?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2Died")
                {
                    GameActiveStatus = false;
                    OnP2Died?.Invoke(this, EventArgs.Empty);
                }



                if (!logic.LevelEditorMode)
                {
                    result = logic.MovePlayers();
                }
                 
                

                if (result == "P1Died")
                {
                    GameActiveStatus = false;
                    OnP1Died?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2Died")
                {
                    GameActiveStatus = false;
                    OnP2Died?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P1killedP2")
                {
                    GameActiveStatus = false;
                    OnP1killedP2?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2killedP1")
                {
                    GameActiveStatus = false;
                    OnP2killedP1?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P1Score")
                {
                    GameActiveStatus = false;
                    OnP1Score?.Invoke(this, EventArgs.Empty);
                }
                if (result == "P2Score")
                {
                    GameActiveStatus = false;
                    OnP2Score?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Death")
                {
                    GameActiveStatus = false;
                    OnDeath?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Victory")
                {
                    GameActiveStatus = false;
                    OnVictory?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Time")
                {
                    GameActiveStatus = false;
                    OnTime?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Finish")
                {
                    GameActiveStatus = false;
                    OnFinish?.Invoke(this, EventArgs.Empty);
                }
                if (result == "Draw")
                {
                    GameActiveStatus = false;
                    OnDraw?.Invoke(this, EventArgs.Empty);
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
    }
}
