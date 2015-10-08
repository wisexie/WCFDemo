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

            IContactsBll bll = WcfClient.GetProxy<IContactsBll>();
            IList<Contacts> list = bll.FindAll();
            PCData pcdata;
            double memCount;
            IMonitorControl blls = WcfClient.GetProxy<IMonitorControl>(); ;
            blls.GetMonitorInfo(out pcdata, out memCount);
            this.dataGridView1.DataSource = list;
        }
    }
}
