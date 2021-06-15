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

        

        private void game1_OnEnd(object sender, EndEventArgs e)
        {
            game1.Visible = false;
            victory1.Visible = true;
            victory1.result = e.messadge;
        }

        private void settings1_OnBack(object sender, EventArgs e)
        {
            settings1.Visible = false;
            mainMenu1.Visible = true;
        }
    }
}
