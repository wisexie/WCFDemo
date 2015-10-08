using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Interface;
using Com.FrameWork;
using Demo.Model;
using Demo.Dal;
using System.ServiceModel;

namespace Demo.Dao.Imp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ContactsBll : CommonWcfBll, IContactsBll
    {
        public IList<Contacts> FindAll()
        {
            IList<Contacts> list =null;
            ContactsInfoDal contactsInfo = new ContactsInfoDal();
            list=contactsInfo.ContactList();
            return list;
        }
    }
}
