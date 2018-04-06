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
using System.Drawing;
using ESBasic;

namespace OMCS.WPF
{
    /// <summary>
    /// 摄像头连接器。通过该组件可以连接到对方的摄像头，播放对方摄像头捕获到的视频。
    /// </summary>
    public partial class CameraConnector : UserControl, IMultimediaConnector
    {
        private OMCS.Passive.Video.CameraConnector cameraConnector = null;

        /// <summary>
        /// 当检测到Owner的摄像头采集的视频大小发生变化时，触发此事件。参数为新的视频大小。
        /// </summary>
        public event CbGeneric<System.Drawing.Size> OwnerCameraVideoSizeChanged;

        /// <summary>
        /// 当Owner视频输出控制改变时，触发此事件。【对应于Owner端的多媒体管理器的OutputVideo属性的修改】
        /// </summary>
        public event CbGeneric OwnerOutputChanged;

        #region Ctor
        public CameraConnector()
        {
            InitializeComponent();  

            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();

            this.cameraConnector = new OMCS.Passive.Video.CameraConnector();
            this.cameraConnector.BackColor = System.Drawing.Color.Black;
            this.cameraConnector.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(camera_ConnectEnded);
            this.cameraConnector.Disconnected += new ESBasic.CbGeneric<ConnectorDisconnectedType>(camera_Disconnected);
            this.cameraConnector.OwnerCameraVideoSizeChanged += new CbGeneric<System.Drawing.Size>(dynamicCameraConnector_OwnerCameraVideoSizeChanged);
            this.cameraConnector.OwnerOutputChanged += new CbGeneric(dynamicCameraConnector_OwnerOutputChanged);

            host.Child = this.cameraConnector;
            this.grid1.Children.Add(host);
        }       

        void dynamicCameraConnector_OwnerOutputChanged()
        {
            if (this.OwnerOutputChanged != null)
            {
                this.OwnerOutputChanged();
            }
        }

        void dynamicCameraConnector_OwnerCameraVideoSizeChanged(System.Drawing.Size obj)
        {
            if (this.OwnerCameraVideoSizeChanged != null)
            {
                this.OwnerCameraVideoSizeChanged(obj);
            }
        }

        void camera_Disconnected(ConnectorDisconnectedType obj)
        {
            if (this.Disconnected != null)
            {
                this.Disconnected(obj);
            }
        }

        void camera_ConnectEnded(ConnectResult obj)
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
            this.cameraConnector.BeginConnect(destUserID);
        }
        #endregion

        #region Disconnect
        /// <summary>
        /// 与目标用户的多媒体设备断开连接，并释放通道。
        /// </summary>
        public void Disconnect()
        {
            this.cameraConnector.Disconnect();
        }
        #endregion        

        #region Connected
        /// <summary>
        /// 与目标设备是否已连接？
        /// </summary>
        public bool Connected
        {
            get { return this.cameraConnector.Connected; }
        }
        #endregion

        #region MultimediaDeviceType
        /// <summary>
        /// 目标多媒体设备的类型。
        /// </summary>
        public OMCS.MultimediaDeviceType MultimediaDeviceType
        {
            get { return this.cameraConnector.MultimediaDeviceType; }
        }
        #endregion

        #region OwnerID
        /// <summary>
        /// 设备主人的UserID。
        /// </summary
        public string OwnerID
        {
            get { return this.cameraConnector.OwnerID; }
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
                return this.cameraConnector.WaitOwnerOnlineSpanInSecs;
            }
            set
            {
                this.cameraConnector.WaitOwnerOnlineSpanInSecs = value;
            }
        }
        #endregion 
        #endregion              

        #region AutoSynchronizeVideoToAudio
        /// <summary>
        /// [从Guest的角度]如果连接了同一个Owner的摄像头和话筒，那么，CameraConnector在播放视频时是否自动与音频保持同步。默认值为true。可以在运行时动态修改。
        /// </summary>
        public bool AutoSynchronizeVideoToAudio
        {
            get { return this.cameraConnector.AutoSynchronizeVideoToAudio; }
            set { this.cameraConnector.AutoSynchronizeVideoToAudio = value; }
        } 
        #endregion

        #region OwnerOutput
        /// <summary>
        /// Owner是否输出了视频。【对应于Owner端的多媒体管理器的OutputVideo属性】
        /// </summary>
        public bool OwnerOutput
        {
            get { return this.cameraConnector.OwnerOutput; }
        }
        #endregion

        #region VideoSize
        /// <summary>
        /// 视频的尺寸。
        /// </summary>
        public System.Drawing.Size VideoSize
        {
            get
            {
                return this.cameraConnector.VideoSize;
            }
        }
        #endregion

        #region GetCurrentImage
        /// <summary>
        /// 获取当前正在绘制的图像。
        /// </summary>      
        public Bitmap GetCurrentImage()
        {
            return this.cameraConnector.GetCurrentImage();
        } 
        #endregion      
  
        #region GetVideoQuality
        /// <summary>
        /// 获取当前视频的编码质量。0~31，数值越小越清晰。
        /// </summary>       
        public int GetVideoQuality()
        {
            return this.cameraConnector.GetVideoQuality();
        }
        #endregion

        #region ChangeOwnerCameraVideoSize
        /// <summary>
        /// 修改Owner的摄像头的采集分辨率。如果其摄像头不支持该分辨率，则将切换到最接近指定值的分辨率上。如果Owner方修改成功，将会触发本地的OwnerCameraVideoSizeChanged事件。
        /// </summary>
        /// <param name="newSize">新的采集分辨率</param>
        public void ChangeOwnerCameraVideoSize(System.Drawing.Size newSize)
        {
            this.cameraConnector.ChangeOwnerCameraVideoSize(newSize);
        }

        /// <summary>
        /// 修改Owner的摄像头的采集分辨率。如果其摄像头不支持该分辨率，则将切换到最接近指定值的分辨率上。如果Owner方修改成功，将会触发本地的OwnerCameraVideoSizeChanged事件。
        /// </summary>
        /// <param name="widthAddHeight">新的采集分辨率的宽和高之和。比如分辨率为（320*240），则该参数为320+240=560</param>
        public void ChangeOwnerCameraVideoSize(int widthAddHeight)
        {
            this.cameraConnector.ChangeOwnerCameraVideoSize(widthAddHeight);
        }
        #endregion

        #region ChangeOwnerOutput
        /// <summary>
        /// 修改Owner的摄像头的输出控制。如果Owner方修改成功，将会触发本地的OwnerOutputChanged事件。
        /// </summary>
        /// <param name="output">是否输出视频</param>
        public void ChangeOwnerOutput(bool output)
        {
            this.cameraConnector.ChangeOwnerOutput(output);
        }
        #endregion

        #region ChangeOwnerAutoAdjustCameraEncodeQuality
        /// <summary>
        /// 修改Owner的是否自动调节视频编码质量的控制。
        /// </summary>
        /// <param name="autoAdjust">是否自动调节</param>
        public void ChangeOwnerAutoAdjustCameraEncodeQuality(bool autoAdjust)
        {
            this.cameraConnector.ChangeOwnerAutoAdjustCameraEncodeQuality(autoAdjust);
        }
        #endregion

        #region ChangeOwnerCameraEncodeQuality
        /// <summary>
        /// 修改Owner的视频编码质量。
        /// </summary>
        /// <param name="quality">编码质量。取值0~31，值越小，越清晰。</param>
        public void ChangeOwnerCameraEncodeQuality(int quality)
        {
            this.cameraConnector.ChangeOwnerCameraEncodeQuality(quality);
        }
        #endregion


        public bool IsDisposed
        {
            get { return this.cameraConnector.IsDisposed; }
        }

        public void Dispose()
        {
            this.cameraConnector.Dispose();
        }
    }
}
