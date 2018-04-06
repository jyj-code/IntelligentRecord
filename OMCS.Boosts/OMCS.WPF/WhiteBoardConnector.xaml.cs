using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OMCS.Passive;
using ESBasic;
using System.Drawing;

namespace OMCS.WPF
{
    /// <summary>
    /// 电子白板连接器。
    /// (1)Owner必须在线上，才可以连接成功；但是Owner掉线并不影响白板的正常使用。
    /// (2)支持掉线自动重连。  
    /// </summary>
    public partial class WhiteBoardConnector : System.Windows.Controls.UserControl, IMultimediaConnector
    {
        private OMCS.Passive.WhiteBoard.WhiteBoardConnector whiteBoardConnector = null;

        #region Ctor
        public WhiteBoardConnector()
        {
            InitializeComponent();

            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            this.whiteBoardConnector = new Passive.WhiteBoard.WhiteBoardConnector();
            this.whiteBoardConnector.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(whiteBoard_ConnectEnded);
            this.whiteBoardConnector.Disconnected += new ESBasic.CbGeneric<ConnectorDisconnectedType>(whiteBoard_Disconnected);
            host.Child = this.whiteBoardConnector;
            this.grid1.Children.Add(host);
        }

        void whiteBoard_Disconnected(ConnectorDisconnectedType obj)
        {
            if (this.Disconnected != null)
            {
                this.Disconnected(obj);
            }
        }

        void whiteBoard_ConnectEnded(ConnectResult obj)
        {
            if (this.ConnectEnded != null)
            {
                this.ConnectEnded(obj);
            }
        }      
        #endregion   

        #region IMultimediaConnector 成员

        /// <summary>
        /// 当连接目标多媒体设备的尝试（由BeginConnect发起）结束时，触发此事件。事件参数说明了连接的结果。
        /// </summary>
        public event CbGeneric<ConnectResult> ConnectEnded;

        /// <summary>
        /// 当与目标多媒体设备的连接断开时，触发该事件。
        /// </summary>
        public event CbGeneric<ConnectorDisconnectedType> Disconnected;

        #region BeginConnect
        /// <summary>
        /// 尝试连接目标多媒体设备。如果多媒体设备未被授权、或多媒体管理器未成功初始化、或当前连接器正在工作、或目标多媒体设备已经被连接、或上次的连接尝试还未结束，则将抛出相应的异常。
        /// </summary>       
        /// <param name="destUserID">目标用户的UserID</param>
        public void BeginConnect(string destUserID)
        {
            this.whiteBoardConnector.BeginConnect(destUserID);
        }
        #endregion

        #region Disconnect
        /// <summary>
        /// 与目标用户的多媒体设备断开连接，并释放通道。
        /// </summary>
        public void Disconnect()
        {
            this.whiteBoardConnector.Disconnect();
        }
        #endregion

        #region Connected
        /// <summary>
        /// 与目标设备是否已连接？
        /// </summary>
        public bool Connected
        {
            get { return this.whiteBoardConnector.Connected; }
        }
        #endregion

        #region MultimediaDeviceType
        /// <summary>
        /// 目标多媒体设备的类型。
        /// </summary>
        public OMCS.MultimediaDeviceType MultimediaDeviceType
        {
            get { return this.whiteBoardConnector.MultimediaDeviceType; }
        }
        #endregion

        #region OwnerID
        /// <summary>
        /// 设备主人的UserID。
        /// </summary
        public string OwnerID
        {
            get { return this.whiteBoardConnector.OwnerID; }
        }
        #endregion

        #region WaitOwnerOnlineSpanInSecs
        /// <summary>
        /// 当调用BeginConnect连接Owner的设备时，如果Owner不在线，则等待对方上线的最长时间。如果超过这个时间，owner还没连接上来，则BeginConnect的结果仍然为TargetUserOffline。 
        /// 单位：秒。默认值0。
        /// </summary>
        public int WaitOwnerOnlineSpanInSecs
        {
            get
            {
                return this.whiteBoardConnector.WaitOwnerOnlineSpanInSecs;
            }
            set
            {
                this.whiteBoardConnector.WaitOwnerOnlineSpanInSecs = value;
            }
        }
        #endregion
        #endregion

        #region AutoReconnect
        /// <summary>
        /// 是否开启自动重连的功能。默认值为true。
        /// </summary>
        public bool AutoReconnect
        {
            get { return this.whiteBoardConnector.AutoReconnect; }
            set { this.whiteBoardConnector.AutoReconnect = value; }
        }
        #endregion

        #region WatchingOnly
        /// <summary>
        /// 仅仅允许查看白板，但是不能进行操作。默认值为false。
        /// </summary>
        public bool WatchingOnly
        {
            get { return this.whiteBoardConnector.WatchingOnly; }
            set { this.whiteBoardConnector.WatchingOnly = value; }
        }
        #endregion      

        #region IsManager
        /// <summary>
        /// 是否为管理员身份。管理员的特殊权限：上传课件、打开课件、删除课件、翻页等。
        /// </summary>      
        public bool IsManager
        {
            get { return this.whiteBoardConnector.IsManager; }
            set
            {
                this.whiteBoardConnector.IsManager = value;
            }
        }
        #endregion

        #region BackImageOfPage
        /// <summary>
        /// 白板页的背景图片（比如，可以将课件转换成图片后，设置到该属性上）。
        /// </summary>       
        public Image BackImageOfPage
        {
            get
            {
                return this.whiteBoardConnector.BackImageOfPage;
            }
            set
            {
                this.whiteBoardConnector.BackImageOfPage = value;                
            }
        }
        #endregion

        #region ContextMenuEnglish
        /// <summary>
        /// 右键菜单文字是否使用英语。
        /// </summary>       
        public bool ContextMenuEnglish
        {
            get
            {
                return this.whiteBoardConnector.ContextMenuEnglish;
            }
            set
            {
                this.whiteBoardConnector.ContextMenuEnglish = value;
            }
        }
        #endregion

        #region FocusOnNewViewByOther
        /// <summary>
        /// 如果他人新建了一个view，则自动选中该view，并调节滚动条使其在可视区域内。
        /// </summary>       
        public bool FocusOnNewViewByOther
        {
            get
            {
                return this.whiteBoardConnector.FocusOnNewViewByOther;
            }
            set
            {
                this.whiteBoardConnector.FocusOnNewViewByOther = value;
            }
        }
        #endregion

        #region DisplayPageBorder
        /// <summary>
        /// 是否显示白板页的边框。默认值：false。
        /// </summary>       
        public bool DisplayPageBorder
        {
            get
            {
                return this.whiteBoardConnector.DisplayPageBorder;
            }
            set
            {
                this.whiteBoardConnector.DisplayPageBorder = value;
            }
        }
        #endregion

        public bool IsDisposed
        {
            get { return this.whiteBoardConnector.IsDisposed; }
        }

        public void Dispose()
        {
            this.whiteBoardConnector.Dispose();
        }
    }
}
