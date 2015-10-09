using Demo.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dal
{
    public class PJSBLOGDal
    {
        private ISession _session;
        private SessionFactory _sessionfactory = new SessionFactory();
        /// <summary>
        /// 查询票据识别表
        /// </summary>
        /// <param PJSBLOG="PJSBLOG">票据识别实体类</param>
        /// <returns>PJSBLOG 集合</returns>
        public IList<PJSBLOG> PJSBLOGInfo(PJSBLOG PJSBLOGInfo)
        {
            IList<PJSBLOG> result = null;
            string hql = "from PJSBLOG where 1=1 ";
            if (!string.IsNullOrEmpty(PJSBLOGInfo.ZHDM.ToString()))
            {
                hql += " and ZHDM = :ZHDM";
            }
            if (!string.IsNullOrEmpty(PJSBLOGInfo.ACCNO))
            {
                hql += " and ACCNO like :ACCNO";
            }
            using (_session = _sessionfactory.Session)
            {

                IQuery query = _session.CreateQuery(hql);
                query.SetInt32("ZHDM", PJSBLOGInfo.ZHDM);
                query.SetString("ACCNO", PJSBLOGInfo.ACCNO);
                result = query.List<PJSBLOG>();
            }
            return result;
        }
    }
}
