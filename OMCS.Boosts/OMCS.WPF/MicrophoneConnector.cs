using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESBasic;
using OMCS.Passive;

namespace OMCS.WPF
{
    /// <summary>
    /// 话筒连接器。通过该组件可以连接到对方的话筒，播放对方话筒捕获到的声音。
    /// </summary>
    public class MicrophoneConnector
    {
        private OMCS.Passive.Audio.MicrophoneConnector microphoneConnector = null;       

        #region Ctor
        public MicrophoneConnector()
        {
            this.microphoneConnector = new OMCS.Passive.Audio.MicrophoneConnector();
            this.microphoneConnector.ConnectEnded += new ESBasic.CbGeneric<Passive.ConnectResult>(camera_ConnectEnded);
            this.microphoneConnector.Disconnected += new ESBasic.CbGeneric<Passive.ConnectorDisconnectedType>(camera_Disconnected);
            this.microphoneConnector.OwnerOutputChanged += new CbGeneric(microphoneConnector_OwnerOutputChanged);
        }

        void microphoneConnector_OwnerOutputChanged()
        {
            if (this.OwnerOutputChanged != null)
            {
                this.OwnerOutputChanged();
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

        /// <summary>
        /// 当Owner音频输出控制改变时，触发此事件。【对应于Owner端的多媒体管理器的OutputAudio属性的修改】
        /// </summary>
        public event CbGeneric OwnerOutputChanged;

        #region BeginConnect

        /// <summary>
        /// 尝试连接目标多媒体设备。如果多媒体设备未被授权、或多媒体管理器未成功初始化、或当前连接器正在工作、或目标多媒体设备已经被连接、或上次的连接尝试还未结束，则将抛出相应的异常。
        /// </summary>       
        /// <param name="destUserID">目标用户的UserID</param>
        public void BeginConnect(string destUserID)
        {
            this.microphoneConnector.BeginConnect(destUserID);
        }
        #endregion

        #region Disconnect
        /// <summary>
        /// 与目标用户的多媒体设备断开连接，并释放通道。
        /// </summary>
        public void Disconnect()
        {
            this.microphoneConnector.Disconnect();
        }
        #endregion        

        #region Connected
        /// <summary>
        /// 与目标设备是否已连接？
        /// </summary>
        public bool Connected
        {
            get { return this.microphoneConnector.Connected; }
        }
        #endregion

        #region MultimediaDeviceType
        /// <summary>
        /// 目标多媒体设备的类型。
        /// </summary>
        public OMCS.MultimediaDeviceType MultimediaDeviceType
        {
            get { return this.microphoneConnector.MultimediaDeviceType; }
        }
        #endregion

        #region OwnerID
        /// <summary>
        /// 设备主人的UserID。
        /// </summary
        public string OwnerID
        {
            get { return this.microphoneConnector.OwnerID; }
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
                return this.microphoneConnector.WaitOwnerOnlineSpanInSecs;
            }
            set
            {
                this.microphoneConnector.WaitOwnerOnlineSpanInSecs = value;
            }
        }
        #endregion 

        #region OwnerOutput        
        /// <summary>
        /// Owner是否输出了音频。【对应于Owner端的多媒体管理器的OutputAudio属性】
        /// </summary>
        public bool OwnerOutput
        {
            get { return this.microphoneConnector.OwnerOutput; }
        }
        #endregion

        #region Mute        
        /// <summary>
        /// 是否静音。默认值false。
        /// </summary>
        public bool Mute
        {
            get { return this.microphoneConnector.Mute; }
            set { this.microphoneConnector.Mute = value; }
        }
        #endregion


        #endregion      
 
        #region ChangeOwnerOutput
        /// <summary>
        /// 修改Owner的麦克风的输出控制。如果Owner方修改成功，将会触发本地的OwnerOutputChanged事件。
        /// </summary>
        /// <param name="output">是否输出音频</param>
        public void ChangeOwnerOutput(bool output)
        {
            this.microphoneConnector.ChangeOwnerOutput(output);
        }
        #endregion
       
    }
}
