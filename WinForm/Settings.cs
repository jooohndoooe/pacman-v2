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
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }
        public event EventHandler OnBack;

        private void MusicOn_Click(object sender, EventArgs e)
        {

        }

        private void MusicOff_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
