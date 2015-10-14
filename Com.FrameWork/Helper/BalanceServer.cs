using Com.FrameWork.Helper.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.FrameWork.Helper
{
    public sealed class BalanceServer
    {
        /// <summary>
        /// 契约名
        /// </summary>
        public static string contactAddress = "";
        /// <summary>
        /// 初始化心跳和判断是否启用负载均衡
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool InitBalance(string contract)
        {
            //首先判断是否启用负载均衡
            bool isloadbalance = WcfCacheData.IsLoadBalance(contract);
            return isloadbalance;
        }
        public static void InitHost()
        {
            WcfServer server = WcfServer.GetInstance();
            server.Start();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void BalanceStart<T>()
        {
            string contract = typeof(T).FullName;

            //契约名
            contactAddress = contract;
            InitBalance(contract);
            InitHost();
        }
    }
}
