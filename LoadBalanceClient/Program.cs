using Com.FrameWork.Helper;
using Com.FrameWork.Helper.Wcf.LoadBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalanceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BalanceServer.BalanceStart<IHeatBeat>();
        }
    }
}
