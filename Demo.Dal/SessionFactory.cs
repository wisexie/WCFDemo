using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dal
{
    public class SessionFactory
    {
        private static ISessionFactory _factory;
        private static object obj = new object();

        public ISession Session
        {
            get
            {
                if (_factory == null)
                {
                    lock (obj)
                    {
                        if (_factory == null)
                        {
                            Configuration cfg = new Configuration().Configure();
                            _factory = cfg.BuildSessionFactory();
                        }
                    }
                }
                return _factory.OpenSession();
            }
        }
    }
}
