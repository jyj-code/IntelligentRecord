using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESBasic;
using OMCS.Server;

namespace OMCS.Boost.Forms
{
    /// <summary>
    /// OMCS 服务端主窗体。
    /// </summary>
    public partial class OmcsServerForm : Form
    {
        private IMultimediaServer multimediaServer;
        private System.Threading.Timer timer;

        public OmcsServerForm(IMultimediaServer server)
        {
            InitializeComponent();
            this.TextChanged += new EventHandler(ServerForm_TextChanged);
            this.multimediaServer = server;
            this.multimediaServer.UserConnected += new CbGeneric<string>(multimediaServer_UserConnected);
            this.multimediaServer.UserDisconnected += new CbGeneric<string>(multimediaServer_UserDisconnected);
            this.label_time.Text = DateTime.Now.ToString();
            this.label_port.Text = this.multimediaServer.Port.ToString();

            this.timer = new System.Threading.Timer(this.Callback, null, 1000, 1000);
        }

        void ServerForm_TextChanged(object sender, EventArgs e)
        {
            this.notifyIcon1.Text = this.Text;
        }

        void multimediaServer_UserDisconnected(string userID)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<string>(this.multimediaServer_UserDisconnected), userID);
            }
            else
            {
                this.label_userCount.Text = this.multimediaServer.UserCount.ToString();
                this.toolStripLabel_msg.Text = string.Format("{0} 下线。{1}", userID, DateTime.Now.ToString());
            }
        }

        void multimediaServer_UserConnected(string userID)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<string>(this.multimediaServer_UserConnected), userID);
            }
            else
            {
                this.label_userCount.Text = this.multimediaServer.UserCount.ToString();
                this.toolStripLabel_msg.Text = string.Format("{0} 上线。{1}", userID, DateTime.Now.ToString());
            }
        }

        private void Callback(object state)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<object>(this.Callback), state);
            }
            else
            {
                this.label_userCount.Text = this.multimediaServer.UserCount.ToString();
            }
        }

        private bool toClose = false;
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ESBasic.Helpers.WindowsHelper.ShowQuery("您确定要退出OMCS服务器吗？"))
            {
                return;
            }

            this.toClose = true;
            this.Close();

        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.toClose)
            {
                e.Cancel = true;
                this.Visible = false;
                return;
            }

            this.multimediaServer.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.multimediaServer.AgileChannelBusyGuesserEnabled = this.checkBox1.Checked;
        }
    }
}
