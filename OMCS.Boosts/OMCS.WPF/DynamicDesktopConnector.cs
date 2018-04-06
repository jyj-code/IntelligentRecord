using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESBasic;
using OMCS.Passive;
using System.Windows.Controls;
using System.Drawing;

namespace OMCS.WPF
{
    /// <summary>
    /// 动态远程桌面连接器。可以动态修改绘制的面板。
    /// </summary>
    public class DynamicDesktopConnector
    {
        private OMCS.Passive.RemoteDesktop.DynamicDesktopConnector dynamicDesktopConnector = null;
        private System.Windows.Forms.Integration.WindowsFormsHost host = null;
        private System.Windows.Forms.Panel showPanel = null;

        /// <summary>
        /// 当检测到Owner的屏幕分辨率发生变化时，触发此事件。参数为新的分辨率。
        /// </summary>
        public event CbGeneric<Size> OwnerDesktopSizeChanged;

        /// <summary>
        /// 当Owner桌面图像输出控制改变时，触发此事件。【对应于Owner端的多媒体管理器的OutputDesktop属性的修改】
        /// </summary>
        public event CbGeneric OwnerOutputChanged;

        #region OwnerOutput
        /// <summary>
        /// Owner是否输出了桌面图像。【对应于Owner端的多媒体管理器的OutputDesktop属性】
        /// </summary>
        public bool OwnerOutput
        {
            get { return this.dynamicDesktopConnector.OwnerOutput; }
        }
        #endregion

        #region DesktopSize
        /// <summary>
        /// 远程桌面的尺寸。
        /// </summary>
        public Size DesktopSize
        {
            get
            {
                return this.dynamicDesktopConnector.DesktopSize;
            }
        }
        #endregion

        #region Ctor
        public DynamicDesktopConnector()
        {
            this.dynamicDesktopConnector = new OMCS.Passive.RemoteDesktop.DynamicDesktopConnector();
            this.dynamicDesktopConnector.ConnectEnded += new ESBasic.CbGeneric<Passive.ConnectResult>(camera_ConnectEnded);
            this.dynamicDesktopConnector.Disconnected += new ESBasic.CbGeneric<Passive.ConnectorDisconnectedType>(camera_Disconnected);
            this.dynamicDesktopConnector.OwnerDesktopSizeChanged += new CbGeneric<System.Drawing.Size>(dynamicDesktopConnector1_OwnerDesktopSizeChanged);
            this.dynamicDesktopConnector.OwnerOutputChanged += new CbGeneric(dynamicDesktopConnector1_OwnerOutputChanged);

            this.host = new System.Windows.Forms.Integration.WindowsFormsHost();
            this.showPanel = new System.Windows.Forms.Panel();
            this.host.Child = showPanel;
        }

        void dynamicDesktopConnector1_OwnerOutputChanged()
        {
            if (this.OwnerOutputChanged != null)
            {
                this.OwnerOutputChanged();
            }
        }

        void dynamicDesktopConnector1_OwnerDesktopSizeChanged(Size obj)
        {
            if (this.OwnerDesktopSizeChanged != null)
            {
                this.OwnerDesktopSizeChanged(obj);
            }
        }

        void camera_Disconnected(Passive.ConnectorDisconnectedType obj)
        {
            if (this.Disconnected != null)
            {
                this.Disconnected(obj);
            }
        }

        void camera_ConnectEnded(Passive.ConnectResult obj)
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
            this.dynamicDesktopConnector.BeginConnect(destUserID);
        }
        #endregion

        #region Disconnect
        /// <summary>
        /// 与目标用户的多媒体设备断开连接，并释放通道。
        /// </summary>
        public void Disconnect()
        {
            this.dynamicDesktopConnector.Disconnect();
        }
        #endregion        

        #region Connected
        /// <summary>
        /// 与目标设备是否已连接？
        /// </summary>
        public bool Connected
        {
            get { return this.dynamicDesktopConnector.Connected; }
        }
        #endregion

        #region MultimediaDeviceType
        /// <summary>
        /// 目标多媒体设备的类型。
        /// </summary>
        public OMCS.MultimediaDeviceType MultimediaDeviceType
        {
            get { return this.dynamicDesktopConnector.MultimediaDeviceType; }
        }
        #endregion

        #region OwnerID
        /// <summary>
        /// 设备主人的UserID。
        /// </summary
        public string OwnerID
        {
            get { return this.dynamicDesktopConnector.OwnerID; }
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
                return this.dynamicDesktopConnector.WaitOwnerOnlineSpanInSecs;
            }
            set
            {
                this.dynamicDesktopConnector.WaitOwnerOnlineSpanInSecs = value;
            }
        }
        #endregion 
        #endregion          

        #region SetViewer
        /// <summary>
        /// 设置要显示视频的控件。必须要在UI线程中调用该方法。
        /// </summary>
        /// <param name="panel">要绘制视频的控件。可以为null。</param>
        public void SetViewer(DockPanel panel)
        {
            panel.Children.Add(this.host);
            this.dynamicDesktopConnector.SetViewer(this.showPanel);
        }
        #endregion

        #region GetCurrentImage
        /// <summary>
        /// 获取当前正在绘制的图像。
        /// </summary>      
        public Bitmap GetCurrentImage()
        {
            return this.dynamicDesktopConnector.GetCurrentImage();
        }
        #endregion       

        #region WatchingOnly        
        /// <summary>
        /// 是否仅仅允许查看远程桌面，但是不能进行操作。默认值为true。
        /// </summary>
        public bool WatchingOnly
        {
            get { return this.dynamicDesktopConnector.WatchingOnly; }
            set
            {
                this.dynamicDesktopConnector.WatchingOnly = value;                
            }
        }
        #endregion

        #region GetVideoQuality
        /// <summary>
        /// 获取当前视频的编码质量。0~31，数值越小越清晰。
        /// </summary>       
        public int GetVideoQuality()
        {
            return this.dynamicDesktopConnector.GetVideoQuality();
        }
        #endregion

        #region ChangeOwnerOutput
        /// <summary>
        /// 修改Owner的桌面输出控制。如果Owner方修改成功，将会触发本地的OwnerOutputChanged事件。
        /// </summary>
        /// <param name="output">是否输出桌面</param>
        public void ChangeOwnerOutput(bool output)
        {
            this.dynamicDesktopConnector.ChangeOwnerOutput(output);
        }
        #endregion

        #region ChangeOwnerDesktopEncodeQuality
        /// <summary>
        /// 修改Owner的桌面编码质量。
        /// </summary>
        /// <param name="quality">编码质量。取值0~31，值越小，越清晰。</param>
        public void ChangeOwnerDesktopEncodeQuality(int quality)
        {
            this.dynamicDesktopConnector.ChangeOwnerDesktopEncodeQuality(quality);
        }
        #endregion
    }
}
