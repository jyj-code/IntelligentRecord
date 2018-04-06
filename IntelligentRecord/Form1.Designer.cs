namespace IntelligentRecord
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_db = new System.Windows.Forms.Label();
            this.label_RecordSign = new System.Windows.Forms.Label();
            this.decibelDisplayer1 = new OMCS.Boost.Controls.DecibelDisplayer();
            this.button_OpenDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "音量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "音量：";
            // 
            // label_db
            // 
            this.label_db.AutoSize = true;
            this.label_db.ForeColor = System.Drawing.Color.Blue;
            this.label_db.Location = new System.Drawing.Point(72, 29);
            this.label_db.Name = "label_db";
            this.label_db.Size = new System.Drawing.Size(0, 15);
            this.label_db.TabIndex = 3;
            // 
            // label_RecordSign
            // 
            this.label_RecordSign.AutoSize = true;
            this.label_RecordSign.Location = new System.Drawing.Point(258, 129);
            this.label_RecordSign.Name = "label_RecordSign";
            this.label_RecordSign.Size = new System.Drawing.Size(0, 15);
            this.label_RecordSign.TabIndex = 4;
            // 
            // decibelDisplayer1
            // 
            this.decibelDisplayer1.BackColor = System.Drawing.Color.White;
            this.decibelDisplayer1.Location = new System.Drawing.Point(72, 62);
            this.decibelDisplayer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.decibelDisplayer1.Name = "decibelDisplayer1";
            this.decibelDisplayer1.Size = new System.Drawing.Size(207, 24);
            this.decibelDisplayer1.TabIndex = 1;
            this.decibelDisplayer1.ValueVisible = false;
            this.decibelDisplayer1.Working = true;
            // 
            // button_OpenDirectory
            // 
            this.button_OpenDirectory.Location = new System.Drawing.Point(95, 112);
            this.button_OpenDirectory.Name = "button_OpenDirectory";
            this.button_OpenDirectory.Size = new System.Drawing.Size(106, 29);
            this.button_OpenDirectory.TabIndex = 5;
            this.button_OpenDirectory.Text = "查看文件目录";
            this.button_OpenDirectory.UseVisualStyleBackColor = true;
            this.button_OpenDirectory.Click += new System.EventHandler(this.button_OpenDirectory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 153);
            this.Controls.Add(this.button_OpenDirectory);
            this.Controls.Add(this.label_RecordSign);
            this.Controls.Add(this.label_db);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.decibelDisplayer1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "智能录制";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private OMCS.Boost.Controls.DecibelDisplayer decibelDisplayer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_db;
        private System.Windows.Forms.Label label_RecordSign;
        private System.Windows.Forms.Button button_OpenDirectory;
    }
}

