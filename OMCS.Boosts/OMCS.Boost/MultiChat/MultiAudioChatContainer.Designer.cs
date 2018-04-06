using OMCS.Boost;
using OMCS.Boost.Controls;
namespace OMCS.Boost.MultiChat
{
    partial class MultiAudioChatContainer
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
            this.decibelDisplayer_speaker = new OMCS.Boost.Controls.DecibelDisplayer();
            this.skinCheckBox_speaker = new CCWin.SkinControl.SkinCheckBox();
            this.decibelDisplayer_mic = new OMCS.Boost.Controls.DecibelDisplayer();
            this.groupBox_members = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
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
            this.skinCheckBox_mic.Location = new System.Drawing.Point(21, 31);
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
            // decibelDisplayer_speaker
            // 
            this.decibelDisplayer_speaker.BackColor = System.Drawing.Color.White;
            this.decibelDisplayer_speaker.Location = new System.Drawing.Point(84, 64);
            this.decibelDisplayer_speaker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.decibelDisplayer_speaker.Name = "decibelDisplayer_speaker";
            this.decibelDisplayer_speaker.Size = new System.Drawing.Size(20, 8);
            this.decibelDisplayer_speaker.TabIndex = 132;
            this.decibelDisplayer_speaker.ValueVisible = false;
            this.decibelDisplayer_speaker.Working = true;
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
            this.skinCheckBox_speaker.Location = new System.Drawing.Point(21, 58);
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
            // decibelDisplayer_mic
            // 
            this.decibelDisplayer_mic.BackColor = System.Drawing.Color.White;
            this.decibelDisplayer_mic.Location = new System.Drawing.Point(84, 37);
            this.decibelDisplayer_mic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.decibelDisplayer_mic.Name = "decibelDisplayer_mic";
            this.decibelDisplayer_mic.Size = new System.Drawing.Size(20, 8);
            this.decibelDisplayer_mic.TabIndex = 133;
            this.decibelDisplayer_mic.ValueVisible = false;
            this.decibelDisplayer_mic.Working = true;
            // 
            // groupBox_members
            // 
            this.groupBox_members.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_members.BackColor = System.Drawing.Color.White;
            this.groupBox_members.Controls.Add(this.flowLayoutPanel1);
            this.groupBox_members.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_members.Location = new System.Drawing.Point(3, 101);
            this.groupBox_members.Name = "groupBox_members";
            this.groupBox_members.Size = new System.Drawing.Size(225, 374);
            this.groupBox_members.TabIndex = 135;
            this.groupBox_members.TabStop = false;
            this.groupBox_members.Text = "成员列表";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(219, 352);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.SizeChanged += new System.EventHandler(this.flowLayoutPanel1_SizeChanged);
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.skinGroupBox1.Controls.Add(this.skinCheckBox_mic);
            this.skinGroupBox1.Controls.Add(this.decibelDisplayer_speaker);
            this.skinGroupBox1.Controls.Add(this.decibelDisplayer_mic);
            this.skinGroupBox1.Controls.Add(this.skinCheckBox_speaker);
            this.skinGroupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.Size = new System.Drawing.Size(225, 92);
            this.skinGroupBox1.TabIndex = 134;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "我的设备";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.Transparent;
            // 
            // MultiAudioChatContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.groupBox_members);
            this.Name = "MultiAudioChatContainer";
            this.Size = new System.Drawing.Size(228, 475);
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CCWin.SkinControl.SkinCheckBox skinCheckBox_speaker;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;

    }
}
