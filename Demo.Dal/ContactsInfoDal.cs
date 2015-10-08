using Demo.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dal
{
    public class ContactsInfoDal
    {
        private ISession _session;
        private SessionFactory _sessionfactory = new SessionFactory();

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="description">用户描述</param>
        /// <param name="state">状态</param>
        /// <returns>True-操作成功|False-操作失败</returns>
        public bool AddUserInfo(Contacts contactsInfo)
        {
            using (_session = _sessionfactory.Session)
            {
                _session.Save(contactsInfo);
                _session.Flush();
         
            }
            return true;
        }

        public IList<Contacts> ContactList()
        {
            IList<Contacts> contactList = null;
            string hql = "from Contacts";
            using (_session = _sessionfactory.Session)
            {

                IQuery query = _session.CreateQuery(hql);
                contactList = query.List<Contacts>();
            }
            return contactList;
        }
        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <returns>True-用户存在|False-用户不存在</returns>
        public bool ExistUserInfo(string name)
        {
            bool result = false;
            string hql = "select count(*) from Contacts where Contacts=:name";
            using (_session = _sessionfactory.Session)
            {

                IQuery query = _session.CreateQuery(hql);
                query.SetString("name", name);
                result = (int.Parse(query.UniqueResult().ToString()) == 0) ? false : true;
            }
            return result;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="description">用户描述</param>
        /// <param name="state">状态</param>
        /// <returns>True-操作成功|False-操作失败</returns>
        public bool UpdateUserInfo(Contacts contactsInfo)
        {
            bool result = false;
            if (ExistUserInfo(contactsInfo.FirstName))
            {
                string hql = "update Contacts set FirstName=:FirstName where LastName=:LastName";
                using (_session = _sessionfactory.Session)
                {
                    IQuery query = _session.CreateQuery(hql);
                    query.SetString("FirstName", contactsInfo.FirstName);
                    query.SetString("LastName", contactsInfo.LastName);
                    result = (query.ExecuteUpdate() > 0) ? true : false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
