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

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mainMenu1_OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainMenu1_OnSettings(object sender, EventArgs e)
        {
            mainMenu1.Visible = false;
            settings1.Visible = true;
        }

        private void mainMenu1_OnLoadLevel(object sender, LoadLevelEventArgs e)
        {
            mainMenu1.Visible = false;
         
            Random r = new Random();
            GameField G=new GameField();
            var logic = new Logic(e.level, e.difficulty, e.mode, e.musicStatus, false);

            


            game1.logic = logic;
            game1.level = logic.level;
            game1.difficulty = logic.difficulty;
            game1.mode = logic.mode;
            game1.InterfaceFieldPrevious = logic.InterfaceField;
            game1.Visible = true;
            game1.GameActiveStatus = true;
        }

        private void defeat1_OnBack(object sender, EventArgs e)
        {
            defeat1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void draw1_OnBack(object sender, EventArgs e)
        {
            draw1.Visible = false;
            mainMenu1.Visible = true;
        }
        private void finish1_OnBack(object sender, EventArgs e)
        {
            finish1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void p1Died1_OnBack(object sender, EventArgs e)
        {
            p1Died1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void p1killedP21_OnBack(object sender, EventArgs e)
        {
            p1killedP21.Visible = false;
            mainMenu1.Visible = true;
        }

        private void p1Score1_OnBack(object sender, EventArgs e)
        {
            p1Score1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void p2Died1_OnBack(object sender, EventArgs e)
        {
            p2Died1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void p2killedP11_OnBack(object sender, EventArgs e)
        {
            p2killedP11.Visible = false;
            mainMenu1.Visible = true;
        }

        private void p2Score1_OnBack(object sender, EventArgs e)
        {
            p2Score1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void settings1_OnBack(object sender, EventArgs e)
        {
            settings1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void time1_OnBack(object sender, EventArgs e)
        {
            time1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void victory1_OnBack(object sender, EventArgs e)
        {
            victory1.Visible = false;
            mainMenu1.Visible = true;
        }

        

        private void game1_OnMainMenu(object sender, EventArgs e)
        {
            game1.Visible = false;
            mainMenu1.Visible = true;
        }

        private void game1_OnDeath(object sender, EventArgs e)
        {
            game1.Visible = false;
            defeat1.Visible = true;
        }

        private void game1_OnDraw(object sender, EventArgs e)
        {
            game1.Visible = false;
            draw1.Visible = true;
        }

        private void game1_OnFinish(object sender, EventArgs e)
        {
            game1.Visible = false;
            finish1.Visible = true;
        }

        private void game1_OnP1Died(object sender, EventArgs e)
        {
            game1.Visible = false;
            p1Died1.Visible = true;
        }

        private void game1_OnP1killedP2(object sender, EventArgs e)
        {
            game1.Visible = false;
            p1killedP21.Visible = true;
        }

        private void game1_OnP1Score(object sender, EventArgs e)
        {
            game1.Visible = false;
            p1Score1.Visible = true;
        }

        private void game1_OnP2Died(object sender, EventArgs e)
        {
            game1.Visible = false;
            p2Died1.Visible = true;
        }

        private void game1_OnP2killedP1(object sender, EventArgs e)
        {
            game1.Visible = false;
            p2killedP11.Visible = true;
        }

        private void game1_OnP2Score(object sender, EventArgs e)
        {
            game1.Visible = false;
            p2Score1.Visible = true;
        }

        private void game1_OnTime(object sender, EventArgs e)
        {
            game1.Visible = false;
            time1.Visible = true;
        }

        private void game1_OnVictory(object sender, EventArgs e)
        {
            game1.Visible = false;
            victory1.Visible = true;
        }
    }
}
