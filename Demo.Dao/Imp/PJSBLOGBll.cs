using Com.FrameWork;
using Demo.Dal;
using Demo.Interface;
using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dao.Imp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PJSBLOGBll : CommonWcfBll, IPJSBLOGBll
    {
        public IList<PJSBLOG> PJSBLOGInfo(PJSBLOG pjsbLog)
        {
            IList<PJSBLOG> list = null;
            PJSBLOGDal PJSBLOGDal = new PJSBLOGDal();
            list = PJSBLOGDal.PJSBLOGInfo(pjsbLog);
            return list;
        }
    }
}
