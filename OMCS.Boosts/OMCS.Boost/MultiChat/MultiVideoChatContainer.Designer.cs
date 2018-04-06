
using OMCS.Boost.Controls;
namespace OMCS.Boost.MultiChat
{
    partial class MultiVideoChatContainer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.skinCheckBox_mic = new CCWin.SkinControl.SkinCheckBox();
            this.skinCheckBox_speaker = new CCWin.SkinControl.SkinCheckBox();
            this.groupBox_members = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.decibelDisplayer_speaker = new OMCS.Boost.Controls.DecibelDisplayer();
            this.decibelDisplayer_mic = new OMCS.Boost.Controls.DecibelDisplayer();
            this.skinCheckBox_camera = new CCWin.SkinControl.SkinCheckBox();
            this.groupBox_members.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinCheckBox_mic
            // 
            this.skinCheckBox_mic.AutoSize = true;
            this.skinCheckBox_mic.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_mic.Checked = true;
            this.skinCheckBox_mic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox_mic.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_mic.DownBack = null;
            this.skinCheckBox_mic.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_mic.Location = new System.Drawing.Point(71, 31);
            this.skinCheckBox_mic.MouseBack = null;
            this.skinCheckBox_mic.Name = "skinCheckBox_mic";
            this.skinCheckBox_mic.NormlBack = null;
            this.skinCheckBox_mic.SelectedDownBack = null;
            this.skinCheckBox_mic.SelectedMouseBack = null;
            this.skinCheckBox_mic.SelectedNormlBack = null;
            this.skinCheckBox_mic.Size = new System.Drawing.Size(63, 21);
            this.skinCheckBox_mic.TabIndex = 131;
            this.skinCheckBox_mic.Text = "麦克风";
            this.skinCheckBox_mic.UseVisualStyleBackColor = false;
            this.skinCheckBox_mic.CheckedChanged += new System.EventHandler(this.skinCheckBox1_CheckedChanged);
            // 
            // skinCheckBox_speaker
            // 
            this.skinCheckBox_speaker.AutoSize = true;
            this.skinCheckBox_speaker.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_speaker.Checked = true;
            this.skinCheckBox_speaker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox_speaker.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_speaker.DownBack = null;
            this.skinCheckBox_speaker.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_speaker.Location = new System.Drawing.Point(161, 31);
            this.skinCheckBox_speaker.MouseBack = null;
            this.skinCheckBox_speaker.Name = "skinCheckBox_speaker";
            this.skinCheckBox_speaker.NormlBack = null;
            this.skinCheckBox_speaker.SelectedDownBack = null;
            this.skinCheckBox_speaker.SelectedMouseBack = null;
            this.skinCheckBox_speaker.SelectedNormlBack = null;
            this.skinCheckBox_speaker.Size = new System.Drawing.Size(63, 21);
            this.skinCheckBox_speaker.TabIndex = 130;
            this.skinCheckBox_speaker.Text = "扬声器";
            this.skinCheckBox_speaker.UseVisualStyleBackColor = false;
            this.skinCheckBox_speaker.CheckedChanged += new System.EventHandler(this.skinCheckBox2_CheckedChanged);
            // 
            // groupBox_members
            // 
            this.groupBox_members.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_members.BackColor = System.Drawing.Color.White;
            this.groupBox_members.Controls.Add(this.flowLayoutPanel1);
            this.groupBox_members.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_members.Location = new System.Drawing.Point(3, 74);
            this.groupBox_members.Name = "groupBox_members";
            this.groupBox_members.Size = new System.Drawing.Size(262, 401);
            this.groupBox_members.TabIndex = 135;
            this.groupBox_members.TabStop = false;
            this.groupBox_members.Text = "成员列表";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(256, 379);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.skinGroupBox1.Controls.Add(this.decibelDisplayer_speaker);
            this.skinGroupBox1.Controls.Add(this.decibelDisplayer_mic);
            this.skinGroupBox1.Controls.Add(this.skinCheckBox_camera);
            this.skinGroupBox1.Controls.Add(this.skinCheckBox_mic);
            this.skinGroupBox1.Controls.Add(this.skinCheckBox_speaker);
            this.skinGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.Size = new System.Drawing.Size(262, 65);
            this.skinGroupBox1.TabIndex = 134;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "我的设备";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.Transparent;
            // 
            // decibelDisplayer_speaker
            // 
            this.decibelDisplayer_speaker.BackColor = System.Drawing.Color.White;
            this.decibelDisplayer_speaker.Location = new System.Drawing.Point(223, 37);
            this.decibelDisplayer_speaker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.decibelDisplayer_speaker.Name = "decibelDisplayer_speaker";
            this.decibelDisplayer_speaker.Size = new System.Drawing.Size(20, 8);
            this.decibelDisplayer_speaker.TabIndex = 132;
            this.decibelDisplayer_speaker.ValueVisible = false;
            this.decibelDisplayer_speaker.Working = true;
            // 
            // decibelDisplayer_mic
            // 
            this.decibelDisplayer_mic.BackColor = System.Drawing.Color.White;
            this.decibelDisplayer_mic.Location = new System.Drawing.Point(131, 37);
            this.decibelDisplayer_mic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.decibelDisplayer_mic.Name = "decibelDisplayer_mic";
            this.decibelDisplayer_mic.Size = new System.Drawing.Size(20, 8);
            this.decibelDisplayer_mic.TabIndex = 133;
            this.decibelDisplayer_mic.ValueVisible = false;
            this.decibelDisplayer_mic.Working = true;
            // 
            // skinCheckBox_camera
            // 
            this.skinCheckBox_camera.AutoSize = true;
            this.skinCheckBox_camera.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox_camera.Checked = true;
            this.skinCheckBox_camera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skinCheckBox_camera.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox_camera.DownBack = null;
            this.skinCheckBox_camera.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox_camera.Location = new System.Drawing.Point(8, 31);
            this.skinCheckBox_camera.MouseBack = null;
            this.skinCheckBox_camera.Name = "skinCheckBox_camera";
            this.skinCheckBox_camera.NormlBack = null;
            this.skinCheckBox_camera.SelectedDownBack = null;
            this.skinCheckBox_camera.SelectedMouseBack = null;
            this.skinCheckBox_camera.SelectedNormlBack = null;
            this.skinCheckBox_camera.Size = new System.Drawing.Size(63, 21);
            this.skinCheckBox_camera.TabIndex = 131;
            this.skinCheckBox_camera.Text = "摄像头";
            this.skinCheckBox_camera.UseVisualStyleBackColor = false;
            this.skinCheckBox_camera.CheckedChanged += new System.EventHandler(this.skinCheckBox_camera_CheckedChanged);
            // 
            // MultiVideoChatContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.groupBox_members);
            this.Name = "MultiVideoChatContainer";
            this.Size = new System.Drawing.Size(265, 475);
            this.groupBox_members.ResumeLayout(false);
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DecibelDisplayer decibelDisplayer_speaker;
        private DecibelDisplayer decibelDisplayer_mic;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_mic;
        private System.Windows.Forms.GroupBox groupBox_members;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_speaker;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_camera;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}
