using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using System.Diagnostics;
using ESBasic;
using OMCS.Passive;
using ESBasic.Threading.Timers;
using ESBasic.Loggers;

namespace OMCS.Boost.Forms
{
    /// <summary>
    /// 视频聊天窗口。
    /// </summary>
    public partial class VideoChatForm : CCSkinMain
    {
        /// <summary>
        /// 普通视频采集分辨率。（长宽之和）
        /// </summary>
        public readonly static int CommonQualityVideo = 700;

        /// <summary>
        /// 高清视频采集分辨率。（长宽之和）
        /// </summary>
        public readonly static int HighQualityVideo = 1000;

        private HungUpCauseType hungUpCauseType = HungUpCauseType.ActiveHungUp;
        private bool activeHungUp = true;
        private IMultimediaManager multimediaManager;       
        private bool isWaitingAnswer ;
        private CallbackTimer<Size> switchCameraSzieCallbackTimer = new CallbackTimer<Size>();
        private IAgileLogger agileLogger;

        /// <summary>
        /// 当自己挂断视频或与对方设备的连接中断时，触发此事件。
        /// </summary>
        public event CbGeneric<HungUpCauseType> HungUpVideo;

        private string currentUserID;
        private string friendID;
        public VideoChatForm(string currentID, string _friendID, string friendName, bool waitingAnswer, IAgileLogger logger)
        {
            InitializeComponent();           

            this.skinLabel_tip.Location = new Point(this.skinPanel1.Location.X + 3, this.skinPanel1.Location.Y + this.skinPanel1.Height + 20);
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制            

            this.skinComboBox_quality.SelectedIndex = 1;
            this.CanResize = true;            

            this.agileLogger = logger;
            this.currentUserID = currentID;
            this.friendID = _friendID;
            this.isWaitingAnswer = waitingAnswer ;
            this.Text = string.Format("正在和{0}视频会话" ,friendName);
            if (!this.isWaitingAnswer)
            {
                this.skinLabel_tip.Text = "正在连接 . . .";
            }
        }       

        public void Initialize(IMultimediaManager mgr)
        {           
            this.multimediaManager = mgr;
            this.multimediaManager.CameraEncodeQuality = 6;
            this.multimediaManager.AudioCaptured += new CbGeneric<byte[]>(multimediaManager_AudioCaptured);
            this.microphoneConnector1.AudioDataReceived += new CbGeneric<byte[]>(microphoneConnector1_AudioDataReceived);
            this.microphoneConnector1.Disconnected += new CbGeneric<ConnectorDisconnectedType>(microphoneConnector1_Disconnected);
            this.cameraConnector1.Disconnected += new CbGeneric<ConnectorDisconnectedType>(cameraConnector1_Disconnected);
            this.skinCheckBox_camera.Checked = this.multimediaManager.OutputVideo;//如果是ConnectOnlyWhenNeed，则每次都会重新创建multimediaManager
            this.skinCheckBox_mic.Checked = this.multimediaManager.OutputAudio; //如果是ConnectOnlyWhenNeed，则每次都会重新创建multimediaManager
            if (!this.isWaitingAnswer) //同意视频，开始连接
            {
                this.OnAgree();
            }

            this.channelQualityDisplayer1.Initialize(this.friendID);
            this.switchCameraSzieCallbackTimer.DetectSpanInSecs = 1;
            this.switchCameraSzieCallbackTimer.Start();
        }

        void cameraConnector1_Disconnected(ConnectorDisconnectedType type)
        {
            if (type == ConnectorDisconnectedType.GuestActiveDisconnect)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectorDisconnectedType>(this.cameraConnector1_Disconnected), type);
            }
            else
            {
                this.CheckConnectorState();
            }
        }

        void microphoneConnector1_Disconnected(ConnectorDisconnectedType type)
        {
            if (type == ConnectorDisconnectedType.GuestActiveDisconnect)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectorDisconnectedType>(this.microphoneConnector1_Disconnected), type);
            }
            else
            {
                this.decibelDisplayer_speaker.Error = true;
                this.CheckConnectorState();
            }
        }

        private void CheckConnectorState()
        {
            if((!this.dynamicCameraConnector1.Connected ) && (!this.microphoneConnector1.Connected))
            {
                this.hungUpCauseType = HungUpCauseType.ConnectorDisconnected;
                this.Close();
            }
        }       

        void microphoneConnector1_AudioDataReceived(byte[] data)
        {
            this.decibelDisplayer_speaker.DisplayAudioData(data);
        }

        void multimediaManager_AudioCaptured(byte[] obj)
        {
            this.decibelDisplayer_mic.DisplayAudioData(obj);
        }       

        private void FocusCurrent(object sender, EventArgs e)
        {
            this.Focus();
        }

        /// <summary>
        /// 对方同意视频会话
        /// </summary>
        public void OnAgree()
        {
            try
            {
                this.skinLabel_tip.Text = "正在连接 . . .";                
                this.dynamicCameraConnector1.SetViewer(this.skinPanel1);
                this.cameraConnector1.BeginConnect(this.currentUserID);
                this.dynamicCameraConnector1.BeginConnect(this.friendID);
                this.microphoneConnector1.BeginConnect(this.friendID);                
                this.decibelDisplayer_mic.Working = true;
                this.decibelDisplayer_speaker.Working = true;
            }
            catch (Exception ee)
            {
            }
        }

        /// <summary>
        /// 对方挂断视频
        /// </summary>
        public void OnHungUpVideo()
        {
            //在网络差时，摄像头设备还未感受到对方的断开，导致摄像头仍然在工作
            this.multimediaManager.DisconnectGuest(this.friendID, OMCS.MultimediaDeviceType.Camera, false);
            this.multimediaManager.DisconnectGuest(this.friendID, OMCS.MultimediaDeviceType.Microphone, false);

            this.Visible = false;
            this.activeHungUp = false;
            this.Close();
        }
      

        private void VideoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.multimediaManager == null)
                {
                    return;
                }

                this.decibelDisplayer_mic.Working = false;
                this.decibelDisplayer_speaker.Working = false;
                this.switchCameraSzieCallbackTimer.Stop();
                this.cameraConnector1.Disconnect();
                this.dynamicCameraConnector1.Disconnect();
                this.microphoneConnector1.Disconnect();
                this.timerLabel1.Stop();

                if (this.activeHungUp)
                {
                    if (this.HungUpVideo != null)
                    {
                        this.HungUpVideo(this.hungUpCauseType);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void dynamicCameraConnector1_ConnectEnded(ConnectResult res)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectResult>(this.dynamicCameraConnector1_ConnectEnded), res);
            }
            else
            {
                try
                {
                    this.skinPanel_tool.Visible = true;
                    this.skinLabel_tip.Visible = false;
                    this.timerLabel1.Start();

                    if (res == ConnectResult.Succeed)
                    {
                        this.skinCheckBox_HighR.Visible = true;                       

                        int sum = this.dynamicCameraConnector1.VideoSize.Width + this.dynamicCameraConnector1.VideoSize.Height;
                        int delt1 = Math.Abs(sum - VideoChatForm.CommonQualityVideo);
                        int delt2 = Math.Abs(sum - VideoChatForm.HighQualityVideo);

                        this.skinCheckBox_HighR.CheckState = delt2 < delt1 ? CheckState.Checked : CheckState.Unchecked;
                    }
                    else
                    {
                        this.skinCheckBox_HighR.Visible = false;
                        this.skinLabel_cameraError.Text = res.ToString();
                        this.skinLabel_cameraError.Visible = true;
                    }
                }
                catch (Exception ee)
                {
                    this.agileLogger.Log(ee, "dynamicCameraConnector1_ConnectEnded", ESBasic.Loggers.ErrorLevel.Standard);
                    MessageBox.Show(ee.Message + " - " + ee.StackTrace);
                }
            }
        }

        private string microphoneConnectorConnectError = null;
        private void microphoneConnector1_ConnectEnded(ConnectResult res)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectResult>(this.microphoneConnector1_ConnectEnded), res);
            }
            else
            {
                this.microphoneConnectorConnectError = null;
                if (res != ConnectResult.Succeed)
                {
                    this.microphoneConnectorConnectError = OMCS.Boost.EnumDescriptor.GetDescription(res);                       
                    this.decibelDisplayer_speaker.Working = false;
                    this.decibelDisplayer_speaker.Error = true;                      
                }

                bool p2p = this.multimediaManager.IsP2PChannelExist(this.friendID);
                this.label_P2P.Visible = p2p;
            }
        }  

        private void skinCheckBox_camera_CheckedChanged(object sender, EventArgs e)
        {            
            this.multimediaManager.OutputVideo = this.skinCheckBox_camera.Checked;
        }

        private void skinCheckBox_mic_CheckedChanged(object sender, EventArgs e)
        {         
            this.multimediaManager.OutputAudio = this.skinCheckBox_mic.Checked;
            this.decibelDisplayer_mic.Working = this.skinCheckBox_mic.Checked;
        }

        private void skinCheckBox_speaker_CheckedChanged(object sender, EventArgs e)
        {           
            this.microphoneConnector1.Mute = !this.skinCheckBox_speaker.Checked;
            //this.decibelDisplayer_speaker.Working = this.skinCheckBox_speaker.Checked;
        }

        private void skinCheckBox_my_CheckedChanged(object sender, EventArgs e)
        {          
            this.skinPanel_Myself.Visible = this.skinCheckBox_my.Checked;
        }

        private void skinButton_State_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dynamicCameraConnector1_OwnerOutputChanged()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.dynamicCameraConnector1_OwnerOutputChanged));
            }
            else
            {
                this.pictureBox_disCamera.Visible = !this.dynamicCameraConnector1.OwnerOutput;               
            }
        }

        private void microphoneConnector1_OwnerOutputChanged()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.microphoneConnector1_OwnerOutputChanged));
            }
            else
            {
                this.pictureBox_disMic.Visible = !this.microphoneConnector1.OwnerOutput;
            }
        }

        
        private void skinCheckBox_HighR_CheckedChanged(object sender, EventArgs e)
        {
            this.switchCameraSzieCallbackTimer.AddCallback(10, new CbGeneric<Size>(this.dynamicCameraConnector1_OwnerCameraVideoSizeChanged), new Size(0, 0));
            this.Cursor = Cursors.WaitCursor;
            int videoSizeSum = this.skinCheckBox_HighR.Checked ? VideoChatForm.HighQualityVideo : VideoChatForm.CommonQualityVideo;
            this.dynamicCameraConnector1.ChangeOwnerCameraVideoSize(videoSizeSum);                   
        }

        private void dynamicCameraConnector1_OwnerCameraVideoSizeChanged(Size obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<Size>(this.dynamicCameraConnector1_OwnerCameraVideoSizeChanged), obj);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void skinCheckBox_autoAdjustQulity_CheckedChanged(object sender, EventArgs e)
        {
            this.dynamicCameraConnector1.ChangeOwnerAutoAdjustCameraEncodeQuality(this.skinCheckBox_autoAdjustQulity.Checked);

            if (!this.skinCheckBox_autoAdjustQulity.Checked)
            {
                int quality = this.dynamicCameraConnector1.GetVideoQuality();
                int index = (quality - 2) / 5;
                if (index < 0)
                {
                    index = 0;
                }
                if (index > 3)
                {
                    index = 3;
                }
                this.skinComboBox_quality.SelectedIndex = index;
            }

            this.skinComboBox_quality.Visible = !this.skinCheckBox_autoAdjustQulity.Checked;
        }

        private void skinComboBox_quality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.skinCheckBox_autoAdjustQulity.Checked)
            {
                int quality = this.skinComboBox_quality.SelectedIndex * 5 + 2;
                this.dynamicCameraConnector1.ChangeOwnerCameraEncodeQuality(quality);
            }
        }

        private void decibelDisplayer_speaker_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.microphoneConnectorConnectError != null)
            {
                MessageBox.Show(this.microphoneConnectorConnectError);
            }
        }                  
    }

   
}
