using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface
{
     [ServiceContract]
    public interface IPJSBLOGBll
    {
         [OperationContract]
         IList<PJSBLOG> PJSBLOGInfo(PJSBLOG pjsbLog );
    }
}
