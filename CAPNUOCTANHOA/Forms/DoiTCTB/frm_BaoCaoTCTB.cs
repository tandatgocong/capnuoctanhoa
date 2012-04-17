using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.DoiTCTB.Tab;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frm_BaoCaoTCTB : UserControl
    {
        public frm_BaoCaoTCTB()
        {
            InitializeComponent();
        }

        private void radioThayDinhKy_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();

            tabThongKeVatTu baothay = new tabThongKeVatTu();
            baothay.Height = this.splitContainer1.Panel2.Size.Height ;
            baothay.Width = this.splitContainer1.Panel2.Size.Width ;
            this.splitContainer1.Panel2.Controls.Add(baothay);
            this.splitContainer1.Panel2.Controls.Add(new tabThongKeVatTu());
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(new h_tab_TinhHinhBaoThay());
        }

        
    }
}
