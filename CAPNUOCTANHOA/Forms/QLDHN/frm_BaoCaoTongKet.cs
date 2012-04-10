using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_BaoCaoTongKet : UserControl
    {
        public frm_BaoCaoTongKet()
        {
            InitializeComponent();
        }

        private void radioThayDinhKy_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tbTongKetDinhKy());
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tb_TinhHinhBaoThay());
        }
    }
}
