using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OMCS.Tools;

namespace OMCS.Boost.Controls
{
    /// <summary>
    /// 选择摄像头的下拉列表。
    /// </summary>
    public partial class CameraComboBox : UserControl
    {
        private List<CameraInformation> list = Camera.GetCameras(); 
        public CameraComboBox()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
           
            this.comboBox1.DataSource = list;
            if (list.Count > 0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
        }       

        public int SelectedIndex
        {
            get
            {
                return this.comboBox1.SelectedIndex;
            }
            set
            {
                if (list == null)
                {
                    return;
                }

                if (list.Count <= value)
                {
                    this.comboBox1.SelectedIndex = 0;
                    return;
                }

                this.comboBox1.SelectedIndex = value;
            }
        }
    }
}
