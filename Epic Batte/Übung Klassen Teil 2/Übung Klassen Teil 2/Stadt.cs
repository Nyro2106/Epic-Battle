using EpicBattleSimulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epic_Battle_Simulator
{
    public partial class Stadt : Form
    {
        private Form1 call;

        public Stadt(Form1 caller)
        {
            call = caller;
            InitializeComponent();
        }

        private void Stadt_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdFightOn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
