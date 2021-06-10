﻿using System;
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
    public partial class Draw : UserControl
    {
        public Draw()
        {
            InitializeComponent();
        }
        public event EventHandler OnBack;
        private void Back_Click(object sender, EventArgs e)
        {
            OnBack?.Invoke(this, EventArgs.Empty);
        }
    }
}