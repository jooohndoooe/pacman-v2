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
    public partial class Victory : UserControl
    {
        public string result { get; set; }
        public Victory()
        {
            InitializeComponent();
        }
        public event EventHandler OnBack;

        private void Back_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke(this, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            VictoryLabel.Text= $"{result}";
        }
    }
}
