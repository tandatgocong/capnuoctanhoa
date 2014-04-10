using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;
using CAPNUOCTANHOA.Forms.BanKTKS.tab;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frm_BaoCaoTongKet_KTKS : UserControl
    {
        public frm_BaoCaoTongKet_KTKS()
        {
            InitializeComponent();
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tbKiemTraCamket());
        }

        private void rtThongKeDHN_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tbKiemTraCamket());
        }

        private void radioThayDinhKy_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new tbKiemTheoDoi0());
        }

    }
}