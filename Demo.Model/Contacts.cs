using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    public class Contacts
    {
        public Contacts()
        {
            m_FirstName = null;
            m_LastName = null;
            m_Id = 0;
        }

        private int m_Id;
        private string m_FirstName;
        private string m_LastName;

        ///<summary>
        ///
        ///</summary>
        public virtual int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public virtual string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public virtual string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }
      
    }
}
