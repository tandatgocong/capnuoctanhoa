using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_ChuyenBangKe : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_ChuyenBangKe).Name);
        public frm_ChuyenBangKe()
        {
            InitializeComponent();
        }

        private void txtSoBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadData();
                //btIn.Enabled = true;
            }
        }
        public void LoadData()
        {
            try
            {
                dataBangKe.DataSource = DAL.DoiTCTB.C_HoanCongThay.getBangKeBaoThay(this.txtSoBangKe.Text.ToUpper());
                Utilities.DataGridV.formatRows(dataBangKe);
                setSTT();
            }
            catch (Exception ex)
            {
                log.Error("Loi Load Du Lieu Thay " + ex.Message);
            }

        }
        public void setSTT()
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {
                dataBangKe.Rows[i].Cells["DHN_STT"].Value = i + 1;
            }
        }
    }
}
