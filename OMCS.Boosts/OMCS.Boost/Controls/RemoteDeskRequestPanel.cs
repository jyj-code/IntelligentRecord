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
    /// 远程桌面/远程协助 请求面板。
    /// </summary>
    public partial class RemoteDeskRequestPanel : UserControl
    {
        private bool isRemoteControl = false;
        /// <summary>
        /// 回复远程协助请求
        /// </summary>
        public event CbGeneric<bool, RemoteHelpStyle ,bool> RemoteRequestAnswerd;

        public RemoteDeskRequestPanel()
        {
            InitializeComponent();
        }

        public void SetRemoteStyle(bool remoteControl)
        {
            this.isRemoteControl = remoteControl;
            if (this.isRemoteControl)
            {
                this.skinLabel1.Text = "对方请求控制您的电脑 . . .";
            }
            else
            {
                this.skinLabel1.Text = "对方向您请求远程协助 . . .";
            }
        }

        private void skinButtomReject_Click(object sender, EventArgs e)
        {
            if (this.RemoteRequestAnswerd != null)
            {
                this.RemoteRequestAnswerd(false, this.remoteDesktopStyle ,this.isRemoteControl);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.RemoteRequestAnswerd != null)
            {
                this.RemoteRequestAnswerd(true ,this.remoteDesktopStyle,this.isRemoteControl);
            }
        }

        private RemoteHelpStyle remoteDesktopStyle;
        public void SetRemoteDesktopStyle(RemoteHelpStyle style)
        {
            this.remoteDesktopStyle = style;            
        }

        
    }
}
