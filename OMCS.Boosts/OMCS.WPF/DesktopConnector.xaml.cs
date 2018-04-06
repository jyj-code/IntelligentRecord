using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
    /// 远程桌面连接器。
    /// </summary>
    public partial class DesktopConnector : UserControl, IMultimediaConnector
    {
        private OMCS.Passive.RemoteDesktop.DesktopConnector desktopConnector = null;

        /// <summary>
        /// 当检测到Owner的屏幕分辨率发生变化时，触发此事件。参数为新的分辨率。
        /// </summary>
        public event CbGeneric<System.Drawing.Size> OwnerDesktopSizeChanged;

        /// <summary>
        /// 当Owner桌面图像输出控制改变时，触发此事件。【对应于Owner端的多媒体管理器的OutputDesktop属性的修改】
        /// </summary>
        public event CbGeneric OwnerOutputChanged;

        /// <summary>
        /// 当Owner允许guest操作桌面的授权改变时，触发此事件。【对应于Owner端的多媒体管理器的AllowControl属性的修改】
        /// </summary>        
        public event CbGeneric OwnerAllowControlChanged;

        #region OwnerOutput
        /// <summary>
        /// Owner是否输出了桌面图像。【对应于Owner端的多媒体管理器的OutputDesktop属性】
        /// </summary>
        public bool OwnerOutput
        {
            get { return this.desktopConnector.OwnerOutput; }
        }
        #endregion

        #region DesktopSize
        /// <summary>
        /// 远程桌面的尺寸。
        /// </summary>
        public System.Drawing.Size DesktopSize
        {
            get
            {
                return this.desktopConnector.DesktopSize;
            }
        }
        #endregion

        #region OwnerAllowControl
        /// <summary>
        /// Owner是否允许操作桌面。【对应于Owner端的多媒体管理器的AllowControl属性】。注意其与WatchingOnly的区别：只有OwnerAllowControl为true的前提下，WatchingOnly的属性设置才有效果。
        /// </summary>       
        public bool OwnerAllowControl
        {
            get { return this.desktopConnector.OwnerAllowControl; }
        }
        #endregion     

        #region Ctor
        public DesktopConnector()
        {
            InitializeComponent();

            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            this.desktopConnector = new OMCS.Passive.RemoteDesktop.DesktopConnector();
            this.desktopConnector.ConnectEnded += new ESBasic.CbGeneric<Passive.ConnectResult>(desktopConnector_ConnectEnded);
            this.desktopConnector.Disconnected += new ESBasic.CbGeneric<Passive.ConnectorDisconnectedType>(desktopConnector_Disconnected);
            this.desktopConnector.OwnerDesktopSizeChanged += new CbGeneric<System.Drawing.Size>(dynamicDesktopConnector1_OwnerDesktopSizeChanged);
            this.desktopConnector.OwnerOutputChanged += new CbGeneric(dynamicDesktopConnector1_OwnerOutputChanged);
            this.desktopConnector.OwnerAllowControlChanged += new CbGeneric(desktopConnector_OwnerAllowControlChanged);
            host.Child = this.desktopConnector;
            this.grid1.Children.Add(host);
        }

        void desktopConnector_OwnerAllowControlChanged()
        {
            if (this.OwnerAllowControlChanged != null)
            {
                this.OwnerAllowControlChanged();
            }
        }

        void dynamicDesktopConnector1_OwnerOutputChanged()
        {
            if (this.OwnerOutputChanged != null)
            {
                this.OwnerOutputChanged();
            }
        }

        void dynamicDesktopConnector1_OwnerDesktopSizeChanged(System.Drawing.Size desktopSize)
        {
            if (this.OwnerDesktopSizeChanged != null)
            {
                this.OwnerDesktopSizeChanged(desktopSize);
            }
        }

        void desktopConnector_Disconnected(Passive.ConnectorDisconnectedType obj)
        {
            if (this.Disconnected != null)
            {
                this.Disconnected(obj);
            }
        }

        void desktopConnector_ConnectEnded(Passive.ConnectResult obj)
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
            this.desktopConnector.BeginConnect(destUserID);
        }
        #endregion

        #region Disconnect
        /// <summary>
        /// 与目标用户的多媒体设备断开连接，并释放通道。
        /// </summary>
        public void Disconnect()
        {
            this.desktopConnector.Disconnect();
        }
        #endregion

        #region Connected
        /// <summary>
        /// 与目标设备是否已连接？
        /// </summary>
        public bool Connected
        {
            get { return this.desktopConnector.Connected; }
        }
        #endregion

        #region MultimediaDeviceType
        /// <summary>
        /// 目标多媒体设备的类型。
        /// </summary>
        public OMCS.MultimediaDeviceType MultimediaDeviceType
        {
            get { return this.desktopConnector.MultimediaDeviceType; }
        }
        #endregion

        #region OwnerID
        /// <summary>
        /// 设备主人的UserID。
        /// </summary
        public string OwnerID
        {
            get { return this.desktopConnector.OwnerID; }
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
                return this.desktopConnector.WaitOwnerOnlineSpanInSecs;
            }
            set
            {
                this.desktopConnector.WaitOwnerOnlineSpanInSecs = value;
            }
        }
        #endregion 
        #endregion

        #region BackColor
        /// <summary>
        /// 当没有视频绘制时，面板显示的颜色。默认值为Black。
        /// </summary>
        public System.Drawing.Color BackColor
        {
            get { return this.desktopConnector.BackColor; }
            set { this.desktopConnector.BackColor = value; }
        }
        #endregion

        #region WatchingOnly
        /// <summary>
        /// 是否仅仅允许查看远程桌面，但是不能进行操作。默认值为true。
        /// </summary>
        public bool WatchingOnly
        {
            get { return this.desktopConnector.WatchingOnly; }
            set { this.desktopConnector.WatchingOnly = value; }
        }
        #endregion

        #region ShowMouseCursor
        /// <summary> 
        /// 是否在远程桌面上显示Owner的鼠标光标。默认值为true。
        /// </summary>
        public bool ShowMouseCursor
        {
            get
            {
                return this.desktopConnector.ShowMouseCursor;
            }
            set
            {
                this.desktopConnector.ShowMouseCursor = value;
            }
        } 
        #endregion

        #region GetCurrentImage
        /// <summary>
        /// 获取当前正在绘制的图像。
        /// </summary>      
        public Bitmap GetCurrentImage()
        {
            return this.desktopConnector.GetCurrentImage();
        }
        #endregion        

        #region GetVideoQuality
        /// <summary>
        /// 获取当前视频的编码质量。0~31，数值越小越清晰。
        /// </summary>       
        public int GetVideoQuality()
        {
            return this.desktopConnector.GetVideoQuality();
        }
        #endregion

        #region ChangeOwnerOutput
        /// <summary>
        /// 修改Owner的桌面输出控制。如果Owner方修改成功，将会触发本地的OwnerOutputChanged事件。
        /// </summary>
        /// <param name="output">是否输出桌面</param>
        public void ChangeOwnerOutput(bool output)
        {
            this.desktopConnector.ChangeOwnerOutput(output);
        }
        #endregion

        #region ChangeOwnerDesktopEncodeQuality
        /// <summary>
        /// 修改Owner的桌面编码质量。
        /// </summary>
        /// <param name="quality">编码质量。取值0~31，值越小，越清晰。</param>
        public void ChangeOwnerDesktopEncodeQuality(int quality)
        {
            this.desktopConnector.ChangeOwnerDesktopEncodeQuality(quality);
        }
        #endregion


        public bool IsDisposed
        {
            get { return this.desktopConnector.IsDisposed; }
        }

        public void Dispose()
        {
            this.desktopConnector.Dispose();
        }
    }
}
