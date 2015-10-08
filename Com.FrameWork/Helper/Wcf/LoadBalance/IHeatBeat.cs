using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Com.FrameWork.Helper.Wcf.LoadBalance
{
    /// <summary>
    /// 心跳
    /// </summary>
    [ServiceContract]
    public interface IHeatBeat
    {
        /// <summary>
        /// 心跳回调
        /// </summary>
        [OperationContract]
        void CallBack(bool flag);
    }
}
