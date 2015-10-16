using Com.FrameWork.Helper;
using Demo.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo.Model;
using Com.FrameWork.Helper.Wcf.Monitor;

namespace WinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            PJSBLOG pjsblog = new PJSBLOG()
            {
                ACCNO = this.txt_ACCNO.Text,
                ZHDM = Convert.ToInt32((this.txt_ZHDM.Text==""?"0":this.txt_ZHDM.Text))
            };
            IPJSBLOGBll bll = WcfClient.GetProxy<IPJSBLOGBll>();
            IList<PJSBLOG> list = bll.PJSBLOGInfo(pjsblog);
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = list;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();  
        }
    }
}
