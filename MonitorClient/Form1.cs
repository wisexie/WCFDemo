using Com.FrameWork.Helper.Wcf.Monitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("192.168.31.106:30005");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetTcpBinding binging = new NetTcpBinding();
            binging.MaxBufferPoolSize = 524288;
            binging.MaxBufferSize = 2147483647;
            binging.MaxReceivedMessageSize = 2147483647;
            binging.MaxConnections = 1000;
            binging.ListenBacklog = 200;
            binging.OpenTimeout = TimeSpan.Parse("00:10:00");
            binging.ReceiveTimeout = TimeSpan.Parse("00:10:00");
            binging.TransferMode = TransferMode.Buffered;
            binging.Security.Mode = SecurityMode.None;

            binging.SendTimeout = TimeSpan.Parse("00:10:00");
            //binging.ReaderQuotas.MaxDepth = 64;
            //binging.ReaderQuotas.MaxStringContentLength = 2147483647;
            //binging.ReaderQuotas.MaxArrayLength = 16384;
            //binging.ReaderQuotas.MaxBytesPerRead = 4096;
            //binging.ReaderQuotas.MaxNameTableCharCount = 16384;
            binging.ReliableSession.Ordered = true;
            binging.ReliableSession.Enabled = false;
            binging.ReliableSession.InactivityTimeout = TimeSpan.Parse("00:10:00");

            Dictionary<string, LinkModel> modellist = new Dictionary<string, LinkModel>();
            PCData pcdata;
            double memCount;
            using (Com.FrameWork.Helper.Wcf.Monitor.MonitorClient client = Com.FrameWork.Helper.Wcf.Monitor.MonitorClient.Instance)
            {
                IMonitorControl proxy = client.getProxy(this.comboBox1.Text.ToString(), binging);
                modellist = proxy.GetMonitorInfo(out pcdata, out memCount);
               
            }
            this.dataGridView1.DataSource =modellist.ToArray();
        }
    }
}
