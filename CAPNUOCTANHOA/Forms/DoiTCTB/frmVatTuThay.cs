using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.DoiTCTB.BC;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.BC;
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.DoiTCTB
{
    public partial class frmVatTuThay : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmVatTuThay).Name);
        public frmVatTuThay()
        {
            InitializeComponent();
            PagLoad();
            cbHieu.DataSource = DAL.LinQConnection.getDataTable("SELECT TENDONGHO FROM TB_HIEUDONGHO");
            cbHieu.DisplayMember = "TENDONGHO";
            cbHieu.ValueMember = "TENDONGHO";
        }
        void PagLoad()
        {
            dataVatTuThay.DataSource = DAL.LinQConnection.getDataTable("SELECT STT,MAVT,TENVT,DGVATLIEU,DGNHANCONG  FROM TB_VATUTHAY_DONGIA ORDER BY STT ASC");
            //Utilities.DataGridV.formatRows(dataVatTuThay);

        }
        string mahieuvt = "";
        private void dataVatTuThay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mahieuvt = dataVatTuThay.Rows[e.RowIndex].Cells["MAVT"].Value.ToString();
                string sql = "SELECT STT,MAVT, DGVATLIEU,DGNHANCONG,NGAYHIEULUC= CONVERT(VARCHAR(10),NGAYHIEULUC,103),CHON";
                sql += " FROM TB_VATUTHAY_DONGIA_H ";
                sql += " WHERE MAVT ='" + mahieuvt + "'";
                sql += " ORDER BY STT ASC ";
                this.GridDonGiaVT.DataSource = DAL.LinQConnection.getDataTable(sql);
                //    Utilities.DataGridV.formatRows(GridDonGiaVT);
            }
            catch (Exception)
            {


            }
        }
        int UpdateDG()
        {
            string sql = "UPDATE TB_VATUTHAY_DONGIA ";
            sql += " SET DGVATLIEU=H.DGVATLIEU, ";
            sql += " DGNHANCONG=H.DGNHANCONG, ";
            sql += " NGAYHIEULUC=GETDATE() ";
            sql += " FROM  TB_VATUTHAY_DONGIA_H H ";
            sql += " WHERE TB_VATUTHAY_DONGIA.MAVT=H.MAVT AND H.CHON='True' AND H.MAVT='" + mahieuvt + "' ";
          return  DAL.LinQConnection.ExecuteCommand_(sql);

        }
        private void btCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < GridDonGiaVT.Rows.Count - 1; i++)
                {
                    int stt = 1;
                    string mahieudg = GridDonGiaVT.Rows[i].Cells["MAHIEUDG"].Value + "";
                    string check = GridDonGiaVT.Rows[i].Cells[6].Value + "";
                    TB_VATUTHAY_DONGIA_H dgvt = DAL.DoiTCTB.C_DonGiaVatTu.finbyDonGiaVT(stt, mahieudg);
                    if (dgvt != null)
                    {
                        dgvt.CHON = bool.Parse(check);
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_vatlieu"].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_nhanCong"].Value + "");
                        dgvt.DGNHANCONG = nc;
                        dgvt.MODIFYBY = DAL.SYS.C_USERS._userName;
                        dgvt.MODIFYDATE = DateTime.Now.Date;
                        DAL.DoiTCTB.C_DonGiaVatTu.UpdateDGVT(dgvt);
                    }
                    else
                    {
                        dgvt = new TB_VATUTHAY_DONGIA_H();
                        dgvt.STT = stt;
                        dgvt.MAVT = mahieudg;
                        double vt = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_vatlieu"].Value + "");
                        dgvt.DGVATLIEU = vt;
                        double nc = double.Parse(GridDonGiaVT.Rows[i].Cells["dg_nhanCong"].Value + "");
                        dgvt.DGNHANCONG = nc;                      
                        dgvt.NGAYHIEULUC = DateTime.Now.Date;
                        dgvt.CHON = bool.Parse(check);
                        dgvt.CREATEBY = DAL.SYS.C_USERS._userName;
                        dgvt.CREATEDATE = DateTime.Now.Date;
                        DAL.DoiTCTB.C_DonGiaVatTu.InsertDGVT(dgvt);
                    }
                }
                if (UpdateDG() > 0)
                {
                    PagLoad();
                    MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Không Thành Công.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                log.Error("Loi Khi Cap Nhat Don Gia Vat Tu " + ex.Message);
                MessageBox.Show(this, "Cập Nhật Đơn Giá Vật Tư Thất Bại.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private Control txtKeypress;
        private void KeyPressHandle(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar) != 8 && (e.KeyChar) != 46 && (e.KeyChar) != 37 && (e.KeyChar) != 39 && (e.KeyChar) != 188)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
        }
      
        private void GridDonGiaVT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            try
            {
                txtKeypress = e.Control;
                if (GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_vatlieu" | GridDonGiaVT.CurrentCell.OwningColumn.Name == "dg_nhanCong" )
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                    txtKeypress.KeyPress += KeyPressHandle;
                }
                else
                {
                    txtKeypress.KeyPress -= KeyPressHandle;
                }
            }
            catch (Exception)
            {
            }
        }

        private void GridDonGiaVT_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[5].Value = Utilities.DateToString.NgayVN(DateTime.Now);
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells[0].Value = GridDonGiaVT.CurrentRow.Index + 1;
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells["dg_nhanCong"].Value = 0;
            GridDonGiaVT.Rows[GridDonGiaVT.CurrentRow.Index].Cells["MAHIEUDG"].Value = mahieuvt;

        }

        private void chonTLK_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbHieu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (chonTLK.Checked)
            {
                txtMaVT.Text = "TLK"+txtCoDhn.Text +cbHieu.SelectedValue.ToString().Substring(0,3);
            }
        }

        private void btHuyThay_Click(object sender, EventArgs e)
        {
            string cl = "25";
            if (rpCoLon.Checked)
                cl = "50";
            if (DAL.LinQConnection.getDataTable("SELECT * FROM TB_VATUTHAY_DONGIA WHERE MAVT='" + this.txtMaVT.Text + "'").Rows.Count > 0)
            {
                MessageBox.Show(this, "Trùng Mã Vật Tư !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                if (chonTLK.Checked==false)
                {
                    DAL.LinQConnection.ExecuteCommand_("INSERT INTO TB_VATUTHAY (MAVT,TENVT ,DVT ,CREATEBY) VALUES('" + this.txtMaVT.Text + "',N'" + this.txtTenVT.Text + "',N'" + this.txtDVT.Text + "','" + cl + "') ");
                }

                DAL.LinQConnection.ExecuteCommand_("INSERT INTO TB_VATUTHAY_DONGIA (MAVT,TENVT)VALUES('" + this.txtMaVT.Text + "',N'" + this.txtTenVT.Text + "' ) ");

                PagLoad();
                MessageBox.Show(this, "Thêm Mã Vật Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            
        }

        private void GridDonGiaVT_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }
    }
}