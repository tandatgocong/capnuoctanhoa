using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_BaoThayDHN : UserControl
    {
        public frm_BaoThayDHN()
        {
            InitializeComponent();
            this.cbLoaiBangKe.Focus();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            var query = from q in db.TB_THAYDHNs where q.DHN_SOBANGKE == 1589 select q;
            dataBangKe.DataSource = query.ToList();
        }
 
    }
}
