using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ESBasic;

namespace OMCS.Boost.Controls
{
    /// <summary>
    /// 远程桌面/远程协助 主人控制面板
    /// </summary>
    public partial class RemoteDeskHandlePanel : UserControl
    {
        private bool isRemoteControl = false;

        /// <summary>
        /// 中止远程协助
        /// </summary>
        public event CbGeneric<bool> RemoteHelpTerminated;

        public RemoteDeskHandlePanel()
        {
            InitializeComponent();

            this.timerLabel1.Visible = false;
            this.skinLabel_msg.Visible = true;
        }

        public void SetRemoteStyle(bool remoteControl)
        {
            this.isRemoteControl = remoteControl;
            //if (this.isRemoteControl)
            //{
            //    this.skinLabel1.Text = "对方请求控制您的电脑 . . .";
            //}
            //else
            //{
            //    this.skinLabel1.Text = "对方向您请求远程协助 . . .";
            //}
        }

        public bool IsWorking
        {
            get
            {
                return this.timerLabel1.IsWorking;
            }
        }

        private void skinButtomReject_Click(object sender, EventArgs e)
        {
            if (this.RemoteHelpTerminated != null)
            {
                this.RemoteHelpTerminated(this.isRemoteControl);
            }

            this.OnTerminate();
        }

        public void OnAgree()
        {            
            this.timerLabel1.Visible = true;
            this.skinLabel_msg.Visible = false;            
            this.timerLabel1.Start();
            this.timerLabel1.Location = new Point(this.Width / 2 - this.timerLabel1.Width / 2, this.timerLabel1.Location.Y);
        }       
        
        public void OnTerminate()
        {             
            this.timerLabel1.Visible = false;
            this.timerLabel1.Stop();
            this.timerLabel1.Reset();
            this.skinLabel_msg.Visible = true;           
        }
    }
}
