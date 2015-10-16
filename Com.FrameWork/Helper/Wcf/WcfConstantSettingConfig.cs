using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Com.FrameWork.Helper.Wcf
{
    internal class WcfConstantSettingConfig
    {

        private List<WcfServerBinding> mlist;

        public List<WcfServerBinding> WcfServerConstantList
        {
            get
            {
                return mlist;
            }
        }
        /// <summary>
        /// wcf服务端常量设置文件
        /// </summary>
        /// <param name="doc"></param>
        public WcfConstantSettingConfig(XmlDocument doc)
        {
            mlist=new List<WcfServerBinding>();
            try
            {
                foreach (XmlElement elems in XmlHelper.Children(doc.DocumentElement, "Servers"))
                {
                    foreach (XmlElement elem in XmlHelper.Children(elems, "Binding"))
                    {
            

                        WcfServerBinding wcfServerBind = new WcfServerBinding();

                        XmlElement xe = XmlHelper.Child(elem, "readerQuotas");
                        wcfServerBind.MaxDepth=int.Parse(xe.GetAttribute("maxDepth"));
                        wcfServerBind.MaxStringContentLength = int.Parse(xe.GetAttribute("maxStringContentLength"));
                        wcfServerBind.MaxArrayLength = int.Parse(xe.GetAttribute("maxArrayLength"));
                        wcfServerBind.MaxBytesPerRead = int.Parse(xe.GetAttribute("maxBytesPerRead"));
                        wcfServerBind.MaxNameTableCharCount = int.Parse(xe.GetAttribute("maxNameTableCharCount"));

                        XmlElement xea = XmlHelper.Child(elem, "reliableSession");
                        wcfServerBind.ReliableSessionEnabled = Boolean.Parse(xea.GetAttribute("enabled"));
                        wcfServerBind.ReliableSessionOrdered = Boolean.Parse(xea.GetAttribute("ordered"));
                        wcfServerBind.ReliableSessionInactivityTimeout = TimeSpan.Parse(xea.GetAttribute("inactivityTimeout"));

                        XmlElement xe1 = XmlHelper.Child(elem, "host");
                        wcfServerBind.BaseAddress  = new Uri(xe1.GetAttribute("baseAddress"));

                        switch (xe1.GetAttribute("binding").ToLower())
                        {
                            case "netTcpBinding":
                                wcfServerBind.Binding = new NetTcpBinding();
                                break;
                       
                        }

                        XmlElement xe2 = XmlHelper.Child(elem, "behaviors");
                        wcfServerBind.CloseTimeout = TimeSpan.Parse(xe2.GetAttribute("closeTimeout"));
                        wcfServerBind.OpenTimeout = TimeSpan.Parse(xe2.GetAttribute("openTimeout"));
                        wcfServerBind.ReceiveTimeout = TimeSpan.Parse(xe2.GetAttribute("receiveTimeout"));
                        wcfServerBind.SendTimeout = TimeSpan.Parse(xe2.GetAttribute("sendTimeout"));
                        wcfServerBind.TransactionFlow = Boolean.Parse(xe2.GetAttribute("transactionFlow"));
                        wcfServerBind.TransferMode = (TransferMode)Enum.Parse(typeof(TransferMode), xe2.GetAttribute("transferMode"));

                        switch (xe2.GetAttribute("transactionProtocol").ToLower())
                        {
                            case "oletransactions":
                                wcfServerBind.TransactionProtocol = TransactionProtocol.OleTransactions;
                                break;
                            case "wsatomictransaction11":
                                wcfServerBind.TransactionProtocol = TransactionProtocol.WSAtomicTransaction11;
                                break;
                            case "wsatomictransactionoctober2004":
                                wcfServerBind.TransactionProtocol = TransactionProtocol.WSAtomicTransactionOctober2004;
                                break;
                            default:
                                wcfServerBind.TransactionProtocol = TransactionProtocol.Default;
                                break;
                        }
          
                        wcfServerBind.HostNameComparisonMode = (HostNameComparisonMode)Enum.Parse(typeof(HostNameComparisonMode), xe2.GetAttribute("hostNameComparisonMode"));
                        wcfServerBind.ListenBacklog = int.Parse(xe2.GetAttribute("listenBacklog"));
                        wcfServerBind.MaxBufferPoolSize = int.Parse(xe2.GetAttribute("maxBufferPoolSize"));
                        wcfServerBind.MaxBufferSize = int.Parse(xe2.GetAttribute("maxBufferSize"));
                        wcfServerBind.MaxConnections = int.Parse(xe2.GetAttribute("maxConnections"));
                        wcfServerBind.MaxReceivedMessageSize = int.Parse(xe2.GetAttribute("maxReceivedMessageSize"));
                        wcfServerBind.PortSharingEnabled = bool.Parse(xe2.GetAttribute("portSharingEnabled"));
                        wcfServerBind.Securitymode = (SecurityMode)Enum.Parse(typeof(SecurityMode), xe2.GetAttribute("securitymode"));
                        wcfServerBind.ClientCredentialType = (MessageCredentialType)Enum.Parse(typeof(MessageCredentialType), xe2.GetAttribute("clientCredentialType"));
                        //_enableBinaryFormatterBehavior = bool.Parse(xe2.GetAttribute("enableBinaryFormatterBehavior"));

                        XmlElement xe3 = XmlHelper.Child(elem, "serviceDebug");
                        wcfServerBind.IncludeExceptionDetailInFaults = bool.Parse(xe3.GetAttribute("includeExceptionDetailInFaults"));

                        XmlElement xe4 = XmlHelper.Child(elem, "serviceThrottling");
                        wcfServerBind.MaxConcurrentCalls = int.Parse(xe4.GetAttribute("maxConcurrentCalls"));
                        wcfServerBind.MaxConcurrentInstances = int.Parse(xe4.GetAttribute("maxConcurrentInstances"));
                        wcfServerBind.MaxConcurrentSessions = int.Parse(xe4.GetAttribute("maxConcurrentSessions"));

                        //XmlElement xe5 = XmlHelper.Child(elem, "dataContractSerializer");
                        //int.TryParse(xe5.GetAttribute("maxItemsInObjectGraph"), out _maxItemsInObjectGraph);
                        mlist.Add(wcfServerBind);
                    }
                }
            }
            catch (Exception oe)
            {
                throw new ArgumentException(oe.Message);
            }
        }
     
    }
    internal class WcfServerBinding
    {
        #region 内部字段
        private int _maxDepth;
        private int _maxStringContentLength;
        private int _maxArrayLength;
        private int _maxBytesPerRead;
        private int _maxNameTableCharCount;

        private bool _reliableSessionEnabled;
        private bool _reliableSessionOrdered;
        private TimeSpan _reliableSessionInactivityTimeout;

        private Uri _addres;
        private Binding _binding;
        private TimeSpan _closeTimeout;
        private TimeSpan _openTimeout;
        private TimeSpan _receiveTimeout;
        private TimeSpan _sendTimeout;
        private bool _transactionFlow;
        private TransferMode _transferMode;
        private TransactionProtocol _transactionProtocol;
        private HostNameComparisonMode _hostNameComparisonMode;
        private int _listenBacklog;
        private int _maxBufferPoolSize;
        private int _maxBufferSize;
        private int _maxConnections;
        private int _maxReceivedMessageSize;
        private bool _portSharingEnabled;
        private SecurityMode _securitymode;
        private MessageCredentialType _clientCredentialType;
        private bool _enableBinaryFormatterBehavior;

        private bool _includeExceptionDetailInFaults;

        private int _maxConcurrentCalls;
        private int _maxConcurrentInstances;
        private int _maxConcurrentSessions;

        //private int _maxItemsInObjectGraph;

        #endregion

        #region readerQuotas
        public int MaxDepth
        {
            get
            {
                return _maxDepth;
            }
            set
            {
                _maxDepth = value;
            }
        }

        public int MaxStringContentLength
        {
            get
            {
                return _maxStringContentLength;
            }
            set
            {
                _maxStringContentLength = value;
            }
        }

        public int MaxArrayLength
        {
            get
            {
                return _maxArrayLength;
            }
            set
            {
                _maxArrayLength = value;
            }
        }

        public int MaxBytesPerRead
        {
            get
            {
                return _maxBytesPerRead;
            }
            set
            {
                _maxBytesPerRead = value;
            }
        }

        public int MaxNameTableCharCount
        {
            get
            {
                return _maxNameTableCharCount;
            }
            set
            {
                _maxNameTableCharCount = value;
            }
        }

        #endregion

        #region reliableSession

        public bool ReliableSessionEnabled
        {
            get
            {
                return _reliableSessionEnabled;
            }
            set
            {
                _reliableSessionEnabled = value;
            }
        }
        public bool ReliableSessionOrdered
        {
            get { return _reliableSessionOrdered; }
            set
            {
                _reliableSessionOrdered = value;
            }
        }
        public TimeSpan ReliableSessionInactivityTimeout
        {
            get { return _reliableSessionInactivityTimeout; }
            set
            {
                _reliableSessionInactivityTimeout = value;
            }
        }

        #endregion

        #region host
        public Uri BaseAddress
        {
            get
            {
                return _addres;
            }
            set
            {
                _addres = value;
            }
        }

        public Binding Binding
        {
            get
            {
                return _binding;
            }
            set
            {
                _binding = value;
            }
        }
        #endregion

        #region behaviors
        public TimeSpan CloseTimeout
        {
            get
            {
                return _closeTimeout;
            }
            set
            {
                _closeTimeout = value;
            }
        }
        public TimeSpan OpenTimeout
        {
            get
            {
                return _openTimeout;
            }
            set
            {
                _openTimeout = value;
            }
        }
        public TimeSpan ReceiveTimeout
        {
            get
            {
                return _receiveTimeout;
            }
            set
            {
                _receiveTimeout = value;
            }
        }
        public TimeSpan SendTimeout
        {
            get
            {
                return _sendTimeout;
            }
            set
            {
                _sendTimeout = value;
            }
        }

        public bool TransactionFlow
        {
            get
            {
                return _transactionFlow;
            }
            set
            {
                _transactionFlow = value;
            }
        }
        public TransferMode TransferMode
        {
            get
            {
                return _transferMode;
            }
            set
            {
                _transferMode = value;
            }
        }
        public TransactionProtocol TransactionProtocol
        {
            get
            {
                return _transactionProtocol == null ? TransactionProtocol.Default : _transactionProtocol;
                //switch (_transactionProtocol.ToLower())
                //{
                //    case "oletransactions":
                //        return TransactionProtocol.OleTransactions;
                //    case "wsatomictransaction11":
                //        return TransactionProtocol.WSAtomicTransaction11;
                //    case "wsatomictransactionoctober2004":
                //        return TransactionProtocol.WSAtomicTransactionOctober2004;
                //    default:
                //        return TransactionProtocol.Default;
                //}
            }
            set
            {
                _transactionProtocol = value;
            }
        }
        public HostNameComparisonMode HostNameComparisonMode
        {
            get
            {
                return _hostNameComparisonMode;
            }
            set
            {
                _hostNameComparisonMode = value;
            }
        }
        public int ListenBacklog
        {
            get
            {
                return _listenBacklog;
            }
            set
            {
                _listenBacklog = value;
            }
        }
        public int MaxBufferPoolSize
        {
            get
            {
                return _maxBufferPoolSize;
            }
            set
            {
                _maxBufferPoolSize = value;
            }
        }
        public int MaxBufferSize
        {
            get
            {
                return _maxBufferSize;
            }
            set
            {
                _maxBufferSize = value;
            }
        }
        public int MaxConnections
        {
            get
            {
                return _maxConnections;
            }
            set
            {
                _maxConnections = value;
            }
        }
        public int MaxReceivedMessageSize
        {
            get
            {
                return _maxReceivedMessageSize;
            }
            set
            {
                _maxReceivedMessageSize = value;
            }
        }
        public bool PortSharingEnabled
        {
            get
            {
                return _portSharingEnabled;
            }
            set
            {
                _portSharingEnabled = value;
            }
        }
        public SecurityMode Securitymode
        {
            get
            {
                return _securitymode;
            }
            set
            {
                _securitymode = value;
            }
        }
        public MessageCredentialType ClientCredentialType
        {
            get
            {
                return _clientCredentialType;
            }
            set
            {
                _clientCredentialType = value;
            }
        }
        public bool enableBinaryFormatterBehavior
        {
            get
            {
                return _enableBinaryFormatterBehavior;
            }
            set
            {
                _enableBinaryFormatterBehavior = value;
            }
        }

        #endregion

        #region serviceDebug
        public bool IncludeExceptionDetailInFaults
        {
            get
            {
                return _includeExceptionDetailInFaults;
            }
            set
            {
                _includeExceptionDetailInFaults = value;
            }
        }
        #endregion

        #region serviceThrottling
        public int MaxConcurrentCalls
        {
            get
            {
                return _maxConcurrentCalls;
            }
            set
            {
                _maxConcurrentCalls = value;
            }
        }
        public int MaxConcurrentInstances
        {
            get
            {
                return _maxConcurrentInstances;
            }
            set
            {
                _maxConcurrentInstances = value;
            }
        }
        public int MaxConcurrentSessions
        {
            get
            {
                return _maxConcurrentSessions;
            }
            set
            {
                _maxConcurrentSessions = value;
            }
        }
        #endregion

        #region dataContractSerializer
        //public int MaxItemsInObjectGraph
        //{
        //    get
        //    {
        //        return _maxItemsInObjectGraph;
        //    }
        //}
        #endregion
    }
}
