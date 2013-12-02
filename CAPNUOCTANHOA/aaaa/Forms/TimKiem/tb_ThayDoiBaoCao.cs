using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.TimKiem
{
    public partial class tb_ThayDoiBaoCao : UserControl
    {
        TB_DHN_BAOCAO dhn_bc = null;
        public tb_ThayDoiBaoCao()
        {
            InitializeComponent();
            dhn_bc = DAL.QLDHN.C_BaoThay.getBaoCao();
            if (dhn_bc != null)
            {
                CVPGKD.Text = dhn_bc.CVPGKD;
                TENPGKD.Text = dhn_bc.TENPGKD;
                CVDQLDH.Text = dhn_bc.CVDQLDH;
                TENQLDHN.Text = dhn_bc.TENQLDHN;
                CVPGDKT.Text = dhn_bc.CVPGDKT;
                TENPGDKT.Text = dhn_bc.TENPGDKT;
                CVKIEMTRA.Text = dhn_bc.CVKIEMTRA;
                TENKIEMTRA.Text = dhn_bc.TENKIEMTRA;
                CVTHICONG.Text = dhn_bc.CVTHICONG;
                TENTHICONG.Text = dhn_bc.TENTHICONG;
                txtKT.Text = dhn_bc.CVKT;
            }
        }

        private void txtCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dhn_bc != null)
                {
                    dhn_bc.CVPGKD = CVPGKD.Text;
                    dhn_bc.TENPGKD = TENPGKD.Text;
                    dhn_bc.CVDQLDH = CVDQLDH.Text;
                    dhn_bc.TENQLDHN = TENQLDHN.Text;
                    dhn_bc.CVPGDKT = CVPGDKT.Text;
                    dhn_bc.TENPGDKT = TENPGDKT.Text;
                    dhn_bc.CVKIEMTRA = CVKIEMTRA.Text;
                    dhn_bc.TENKIEMTRA = TENKIEMTRA.Text;
                    dhn_bc.CVTHICONG = CVTHICONG.Text;
                    dhn_bc.TENTHICONG = TENTHICONG.Text;
                    dhn_bc.CVKT = txtKT.Text;
                    DAL.QLDHN.C_BaoThay.Update();
                    MessageBox.Show(this, "Cập Nhật Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Cập Nhật Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
