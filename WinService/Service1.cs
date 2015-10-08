using Com.FrameWork.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinService
{
    public partial class Service1 : ServiceBase
    {
        WcfServer server = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            server = WcfServer.GetInstance();

            server.Start();
        }

        protected override void OnStop()
        {
            server.Stop();
        }
    }
}
