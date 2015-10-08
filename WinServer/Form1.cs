using Com.FrameWork.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinServer
{
    public partial class Form1 : Form
    {
        WcfServer server = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            server = WcfServer.GetInstance();

            server.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
        }
    }
}
