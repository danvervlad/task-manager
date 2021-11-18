using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class PopUpWin : Form
    {
        public PopUpWin()
        {
            InitializeComponent();
        }

        private void PopUpWin_Shown(object sender, EventArgs e)
        {
            this.Activate();
            //this.TopMost = true;
        }
    }
}
