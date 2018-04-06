namespace OMCS.Boost.Forms
{
    partial class RemoteDeskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDeskForm));
            this.desktopConnector1 = new OMCS.Passive.RemoteDesktop.DesktopConnector();
            this.skinPanel_pic = new CCWin.SkinControl.SkinPanel();
            this.skinLabel_msg = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_tip = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_quality = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel_quality = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // desktopConnector1
            // 
            this.desktopConnector1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.desktopConnector1.AutoScroll = true;
            this.desktopConnector1.BackColor = System.Drawing.Color.White;
            this.desktopConnector1.Cursor = System.Windows.Forms.Cursors.No;            
            this.desktopConnector1.Location = new System.Drawing.Point(2, 30);            
            this.desktopConnector1.Name = "desktopConnector1";
            this.desktopConnector1.ShowMouseCursor = true;
            this.desktopConnector1.Size = new System.Drawing.Size(750, 534);
            this.desktopConnector1.TabIndex = 0;
            this.desktopConnector1.WaitOwnerOnlineSpanInSecs = 0;
            this.desktopConnector1.WatchingOnly = true;
            // 
            // skinPanel_pic
            // 
            this.skinPanel_pic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinPanel_pic.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel_pic.BackgroundImage = global::OMCS.Boost.Properties.Resources.RemoteHelp;
            this.skinPanel_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skinPanel_pic.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel_pic.DownBack = null;
            this.skinPanel_pic.Location = new System.Drawing.Point(323, 207);
            this.skinPanel_pic.MouseBack = null;
            this.skinPanel_pic.Name = "skinPanel_pic";
            this.skinPanel_pic.NormlBack = null;
            this.skinPanel_pic.Size = new System.Drawing.Size(96, 96);
            this.skinPanel_pic.TabIndex = 131;
            // 
            // skinLabel_msg
            // 
            this.skinLabel_msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinLabel_msg.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_msg.AutoSize = true;
            this.skinLabel_msg.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_msg.BorderColor = System.Drawing.Color.White;
            this.skinLabel_msg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_msg.Location = new System.Drawing.Point(309, 317);
            this.skinLabel_msg.Name = "skinLabel_msg";
            this.skinLabel_msg.Size = new System.Drawing.Size(125, 17);
            this.skinLabel_msg.TabIndex = 130;
            this.skinLabel_msg.Text = "正在连接对方桌面 . . .";
            // 
            // skinLabel_tip
            // 
            this.skinLabel_tip.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_tip.AutoSize = true;
            this.skinLabel_tip.BackColor = System.Drawing.Color.White;
            this.skinLabel_tip.BorderColor = System.Drawing.Color.White;
            this.skinLabel_tip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_tip.Location = new System.Drawing.Point(299, 307);
            this.skinLabel_tip.Name = "skinLabel_tip";
            this.skinLabel_tip.Size = new System.Drawing.Size(125, 17);
            this.skinLabel_tip.TabIndex = 132;
            this.skinLabel_tip.Text = "正在等待对方回应 . . .";
            // 
            // skinComboBox_quality
            // 
            this.skinComboBox_quality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_quality.FormattingEnabled = true;
            this.skinComboBox_quality.Items.AddRange(new object[] {
            "优",
            "良",
            "中",
            "差"});
            this.skinComboBox_quality.Location = new System.Drawing.Point(606, 3);
            this.skinComboBox_quality.Name = "skinComboBox_quality";
            this.skinComboBox_quality.Size = new System.Drawing.Size(39, 22);
            this.skinComboBox_quality.TabIndex = 134;
            this.skinComboBox_quality.Visible = false;
            this.skinComboBox_quality.WaterText = "";
            this.skinComboBox_quality.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_quality_SelectedIndexChanged);
            // 
            // skinLabel_quality
            // 
            this.skinLabel_quality.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_quality.AutoSize = true;
            this.skinLabel_quality.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_quality.BorderColor = System.Drawing.Color.White;
            this.skinLabel_quality.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_quality.Location = new System.Drawing.Point(554, 6);
            this.skinLabel_quality.Name = "skinLabel_quality";
            this.skinLabel_quality.Size = new System.Drawing.Size(56, 17);
            this.skinLabel_quality.TabIndex = 135;
            this.skinLabel_quality.Text = "清晰度：";
            this.skinLabel_quality.Visible = false;
            // 
            // RemoteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.BorderPalace = ((System.Drawing.Image)(resources.GetObject("$this.BorderPalace")));
            this.CanResize = true;
            this.ClientSize = new System.Drawing.Size(755, 569);
            this.CloseDownBack = global::OMCS.Boost.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::OMCS.Boost.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::OMCS.Boost.Properties.Resources.btn_close_disable;
            this.Controls.Add(this.skinComboBox_quality);
            this.Controls.Add(this.skinLabel_quality);
            this.Controls.Add(this.skinLabel_tip);
            this.Controls.Add(this.desktopConnector1);
            this.Controls.Add(this.skinPanel_pic);
            this.Controls.Add(this.skinLabel_msg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaxDownBack = global::OMCS.Boost.Properties.Resources.btn_max_down;
            this.MaximizeBox = true;
            this.MaxMouseBack = global::OMCS.Boost.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::OMCS.Boost.Properties.Resources.btn_max_normal;
            this.MiniDownBack = global::OMCS.Boost.Properties.Resources.btn_mini_down;
            this.MinimizeBox = true;
            this.MiniMouseBack = global::OMCS.Boost.Properties.Resources.btn_mini_highlight;
            this.MiniNormlBack = global::OMCS.Boost.Properties.Resources.btn_mini_normal;
            this.Name = "RemoteForm";
            this.RestoreDownBack = global::OMCS.Boost.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = global::OMCS.Boost.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = global::OMCS.Boost.Properties.Resources.btn_restore_normal;
            this.Shadow = false;
            this.ShowInTaskbar = true;
            this.Text = "远程桌面";
            this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteHelpForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OMCS.Passive.RemoteDesktop.DesktopConnector desktopConnector1;
        private CCWin.SkinControl.SkinPanel skinPanel_pic;
        private CCWin.SkinControl.SkinLabel skinLabel_msg;
        private CCWin.SkinControl.SkinLabel skinLabel_tip;
        private CCWin.SkinControl.SkinComboBox skinComboBox_quality;
        private CCWin.SkinControl.SkinLabel skinLabel_quality;

    }
}