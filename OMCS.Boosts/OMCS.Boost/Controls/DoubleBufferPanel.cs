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
    /// 启用了双缓冲的Panel，防止视频闪烁。
    /// 如果使用DynamicCameraConnector，则可使用该DoubleBufferPanel控件来绘制视频。
    /// </summary>
    public partial class DoubleBufferPanel : UserControl
    {
        public DoubleBufferPanel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);//调整大小时重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);// 双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);// 禁止擦除背景.
            this.SetStyle(ControlStyles.UserPaint, true);//自行绘制            
            this.UpdateStyles();
        }
    }
}
