using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OMCS.Boost.Controls
{
    /// <summary>
    /// 等比缩放容器：将对该容器内的控件进行等比缩放，并居中显示。
    /// （1）容器中只能有一个被等比缩放的控件。
    /// （2）再调用Initialize方法之前，请先将要被缩放的控件拖放到该容器中。
    /// </summary>
    public partial class AutoScaleContainer : UserControl
    {
        private Size standardSize;
        private Control target;

        public AutoScaleContainer()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(AutoScaleContainer_SizeChanged);
        }

        void AutoScaleContainer_SizeChanged(object sender, EventArgs e)
        {
            if (this.target == null)
            {
                return;
            }

            float wCoef = this.Width / (float)this.standardSize.Width;
            float hCoef = this.Height / (float)this.standardSize.Height;
            if (wCoef == hCoef)
            {
                this.target.Location = new Point(0, 0);
                this.target.Size = this.Size;
                return;
            }

            if (wCoef < hCoef)
            {
                int newHeight = (int)(wCoef*this.standardSize.Height) ;
                this.target.Location = new Point(0, (this.Height - newHeight) / 2);
                this.target.Size = new Size(this.Width, newHeight);
                return;
            }

            int newWidth = (int)(hCoef * this.standardSize.Width);
            this.target.Location = new Point((this.Width - newWidth) / 2, 0);
            this.target.Size = new Size(newWidth, this.Height);
        }

        /// <summary>
        /// 初始化等比缩放容器。
        /// </summary>
        /// <param name="targetCtrl">被缩放的控件。</param>
        /// <param name="_standardSize">用于等比缩放进行参考的标准尺寸</param>
        public void Initialize(Control targetCtrl, Size _standardSize)
        {
            if (targetCtrl.Parent != this)
            {
                targetCtrl.Parent.Controls.Remove(targetCtrl);
                this.Controls.Add(targetCtrl);
            }

            this.target = targetCtrl;
            this.standardSize = _standardSize;

            this.target.Dock = DockStyle.None;
            this.AutoScaleContainer_SizeChanged(this, new EventArgs());
        }
    }
}
