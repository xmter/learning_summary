using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GISDesign.Query
{
    public partial class frmPromptQuerying : Form
    {
        public frmPromptQuerying()
        {
            InitializeComponent();
        }
        public frmPromptQuerying(int i)
        {
            InitializeComponent();
            if (i == 1)
                label.Text = "正在加载地图，请稍候...";
            if (i == 2)
                label.Text = "正在加载数据，请稍候...";
            if (i == 3)
                label.Text = "正在进行处理，请稍候...";
            if(i==4)
                label.Text = "构造查询条件，请稍候...";
            if (i == 5)
                label.Text = "进行空间查询，请稍候...";
        }

        private void frmPromptQuerying_Load(object sender, EventArgs e)
        {

        }
    }
}