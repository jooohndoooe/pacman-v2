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
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        public event EventHandler OnExit;
        public event EventHandler<LoadLevelEventArgs> OnLoadLevel;
        public event EventHandler OnSettings;
        int x = 1;
        int y = 1;
        string z = "SinglePlayer";
        bool musicStatus=true;

        private void Exit_Click(object sender, EventArgs e)
        {
            OnExit?.Invoke(this, EventArgs.Empty);
        }
        private void Level_1_Click(object sender, EventArgs e)
        {
            x = 1;
        }

        private void Level_2_Click(object sender, EventArgs e)
        {
            x = 2;
        }

        private void Level_Custom_Click(object sender, EventArgs e)
        {
            x = 3;
        }

        private void Level_Random_Click(object sender, EventArgs e)
        {
            x = 4;
        }
        

        private void Start_Click(object sender, EventArgs e)
        {
            OnLoadLevel?.Invoke(this, new LoadLevelEventArgs(x,y,z, musicStatus));
        }

        private void Difficulty_1_Click(object sender, EventArgs e)
        {
            y = 1;
        }

        private void Difficulty_2_Click(object sender, EventArgs e)
        {
            y = 2;
        }

        private void Difficulty_3_Click(object sender, EventArgs e)
        {
            y = 3;
        }

        private void Difficulty_4_Click(object sender, EventArgs e)
        {
            y = 4;
        }

        private void Difficulty_5_Click(object sender, EventArgs e)
        {
            y = 5;
        }

        private void SinglePlayer_Click(object sender, EventArgs e)
        {
            z = "SinglePlayer";
        }
        private void MulyPlayer_Click(object sender, EventArgs e)
        {
            z = "MultyPlayer";
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            OnSettings?.Invoke(this, EventArgs.Empty);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
    public class LoadLevelEventArgs : EventArgs
    {
        public int level { get; private set; }
        public int difficulty { get; private set; }
        public string mode { get; private set; }
        public bool musicStatus { get; private set; }

        public LoadLevelEventArgs(int LevelName, int DifficultyName, string ModeName, bool MusicStatus)
        {
            level = LevelName;
            difficulty = DifficultyName;
            mode = ModeName;
            musicStatus = MusicStatus;
        }
    }
}
