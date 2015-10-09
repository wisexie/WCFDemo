using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.Model
{
    public class PJSBLOG
    {
        private int _PJSBLOGID;
        private int _ZHDM;
        private string _ACCNO;
        private string _CHEQUENO;
        private string _OPCODE;
        private string _OPDATE;
        private string _OPTIME;
        private int _OPRESULT;
        private int _PZID;
        private string _VoucherDate;
        private string _SecHydm;
        private int _OpType;
        private string _OpDetail;
        private string _VolumeNo;
        private string _SerialNo;
        private int _BackSealFlag;
        private string _Wdh;
        private int _CurrencyId;
        private int _PasswordResult;
        private string _ZjZgSqCode;
        private string _chequeseriesno;
        private string _BankId;
        private int _PJLOGID;
        private float _Credit;


        public virtual int PJSBLOGID
        {
            get { return _PJSBLOGID; }
            set { _PJSBLOGID = value; }
        }

        public virtual int ZHDM
        {
            get { return _ZHDM; }
            set { _ZHDM = value; }
        }

        public virtual string ACCNO
        {
            get { return _ACCNO; }
            set { _ACCNO = value; }
        }

        public virtual string CHEQUENO
        {
            get { return _CHEQUENO; }
            set { _CHEQUENO = value; }
        }

        public virtual string OPCODE
        {
            get { return _OPCODE; }
            set { _OPCODE = value; }
        }

        public virtual string OPDATE
        {
            get { return _OPDATE; }
            set { _OPDATE = value; }
        }

        public virtual string OPTIME
        {
            get { return _OPTIME; }
            set { _OPTIME = value; }
        }

        public virtual int OPRESULT
        {
            get { return _OPRESULT; }
            set { _OPRESULT = value; }
        }

        public virtual int PZID
        {
            get { return _PZID; }
            set { _PZID = value; }
        }
        public virtual float Credit
        {
            get { return _Credit; }
            set { _Credit = value; }
        }

        public virtual string VoucherDate
        {
            get { return _VoucherDate; }
            set { _VoucherDate = value; }
        }

        public virtual string SecHydm
        {
            get { return _SecHydm; }
            set { _SecHydm = value; }
        }

        public virtual int OpType
        {
            get { return _OpType; }
            set { _OpType = value; }
        }

        public virtual string OpDetail
        {
            get { return _OpDetail; }
            set { _OpDetail = value; }
        }

        public virtual string VolumeNo
        {
            get { return _VolumeNo; }
            set { _VolumeNo = value; }
        }

        public virtual string SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }

        public virtual int BackSealFlag
        {
            get { return _BackSealFlag; }
            set { _BackSealFlag = value; }
        }

        public virtual string Wdh
        {
            get { return _Wdh; }
            set { _Wdh = value; }
        }

        public virtual int CurrencyId
        {
            get { return _CurrencyId; }
            set { _CurrencyId = value; }
        }

        public virtual int PasswordResult
        {
            get { return _PasswordResult; }
            set { _PasswordResult = value; }
        }

        public virtual string ZjZgSqCode
        {
            get { return _ZjZgSqCode; }
            set { _ZjZgSqCode = value; }
        }

        public virtual string chequeseriesno
        {
            get { return _chequeseriesno; }
            set { _chequeseriesno = value; }
        }

        public virtual string BankId
        {
            get { return _BankId; }
            set { _BankId = value; }
        }

        public virtual int PJLOGID
        {
            get { return _PJLOGID; }
            set { _PJLOGID = value; }
        }
    }

}

