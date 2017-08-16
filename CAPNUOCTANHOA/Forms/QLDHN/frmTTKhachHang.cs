using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.DAL;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frmTTKhachHang : UserControl
    {
        string phong = "";
        int _ticks = 0;
        public frmTTKhachHang(string phongban)
        {
            InitializeComponent();
            dateTuNgay.ValueObject = DateTime.Now.Date;
            dateDenNgay.ValueObject = DateTime.Now.Date;
            phong = phongban;
            pLoad();
            timer1.Start();
            alrt2();
        }

        public void alrt2()
        {

            string sql = " SELECT tn.SoHoSo,DienThoai,DanhBo,lt.TenLoai,NgayNhan, GhiChu,CreateBy,ChuyenHS,DonViChuyen,NgayChuyen,NgayXuLy,KetQuaXuLy,NhanVienXuLy,TenKH,(SoNha + ' ' + TenDuong ) as DiaChi ";
            sql += "   FROM TTKH_TiepNhan tn, TTKH_LoaiTiepNhan lt ";
            sql += "   WHERE tn.LoaiHs=lt.ID  AND MaDVChuyen='" + phong + "' ";
            sql += " AND  DATEDIFF(DD,NgayNhan,GETDATE())>3 ";
            sql += "  AND NgayXuLy IS  NULL ";
            sql += " ORDER BY NgayNhan DESC";


            DataTable tb = CCallCenter.getDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                MessChuaXL of = new MessChuaXL(tb);
                of.ShowDialog();
                //if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK  )
                //    timer1.Start();
            }
        }


        public void pLoad()
        {
            string sql = " SELECT tn.SoHoSo,DienThoai,DanhBo,lt.TenLoai,NgayNhan, GhiChu,CreateBy,ChuyenHS,DonViChuyen,NgayChuyen,NgayXuLy,KetQuaXuLy,NhanVienXuLy,TenKH,(SoNha + ' ' + TenDuong ) as DiaChi ";
            sql += "   FROM TTKH_TiepNhan tn, TTKH_LoaiTiepNhan lt ";
            sql += "   WHERE tn.LoaiHs=lt.ID  ";
            sql += " AND CONVERT(DATE,NgayNhan,103) BETWEEN CONVERT(DATE,'" + Utilities.DateToString.NgayVN(dateTuNgay.Value.Date) + "',103) AND CONVERT(DATE,'" + Utilities.DateToString.NgayVN(dateDenNgay.Value.Date) + "',103) ";
            sql += " AND MaDVChuyen='" + phong + "'";

            if (ckChuaChuyen.Checked)
                sql += " AND (ChuyenHS is NULL OR ChuyenHS='False')";
            else if (ckChuaXuLy.Checked)
                sql += " AND (ChuyenHS is not null AND NgayXuLy is null) ";
            else if (ckHoanTat.Checked)
                sql += " AND NgayXuLy IS NOT NULL ";

             sql+=" ORDER BY NgayNhan DESC";

            dataGrid.DataSource = CCallCenter.getDataTable(sql);
          
        }
        private void check(object sender, EventArgs e)
        {
            pLoad();
        }

        void format()
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {

                if (!bool.Parse(this.dataGrid.Rows[i].Cells["ChuyenHS"].Value + ""))
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
                else if (bool.Parse(this.dataGrid.Rows[i].Cells["ChuyenHS"].Value + "") && "".Equals(this.dataGrid.Rows[i].Cells["NgayXuLy"].Value + ""))
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(149)))));
                }


            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            pLoad();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            pLoad();
        }

        private void dataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            format();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE TTKH_TiepNhan SET NgayXuLy=GETDATE(),KetQuaXuLy=N'" + txtKetQuaXL.Text + "',NhanVienXuLy=N'" + DAL.SYS.C_USERS._fullName + "'  WHERE SoHoSo='" + txtSoHoSo.Text + "'";
            if (CCallCenter.ExecuteCommand_(sql) > 0)
            { MessageBox.Show(this, "Cập Nhật Xử Lý Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information); pLoad(); }
            else
                MessageBox.Show(this, "Cập Nhật Xử Lý Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.CurrentCell.OwningColumn.Name != "checkChon")
            {
                try
                {
                    string sohoso = dataGrid.Rows[e.RowIndex].Cells["sohoso"].Value + "";
                    string DanhBo = dataGrid.Rows[e.RowIndex].Cells["DanhBo"].Value + "";
                    string DienThoai = dataGrid.Rows[e.RowIndex].Cells["DienThoai"].Value + "";
                    string TenLoai = dataGrid.Rows[e.RowIndex].Cells["TenLoai"].Value + "";
                    string TenKH = dataGrid.Rows[e.RowIndex].Cells["TenKH"].Value + "";
                    string DiaChi = dataGrid.Rows[e.RowIndex].Cells["DiaChi"].Value + "";
                    string GhiChu = dataGrid.Rows[e.RowIndex].Cells["GhiChu"].Value + "";
                    string Ngaytn = dataGrid.Rows[e.RowIndex].Cells["NgayNhan"].Value + "";
                    txtSoHoSo.Text = sohoso;
                    txtSoDanhBo.Text = DanhBo;
                    txtDienThoai.Text = DienThoai;
                    txtTenKH.Text = TenKH;
                    txtDuong.Text = DiaChi;
                    txtGhiChu.Text = GhiChu;
                    txtLoaiTiepNhan.Text = TenLoai;
                    dateNgaytn.ValueObject = Ngaytn;
                }
                catch (Exception)
                {

                }
            }

        }


        public void alrt()
        {

            string sql2 = " SELECT tn.SoHoSo,DienThoai,DanhBo,lt.TenLoai,NgayNhan, GhiChu,CreateBy ";
            sql2 += "   FROM TTKH_TiepNhan tn, TTKH_LoaiTiepNhan lt ";
            sql2 += "   WHERE tn.LoaiHs=lt.ID  ";
            //sql2 += " AND CONVERT(DATE,NgayNhan,103) BETWEEN CONVERT(DATE,'" + Utilities.DateToString.NgayVN(dateTuNgay.Value.Date) + "',103) AND CONVERT(DATE,'" + Utilities.DateToString.NgayVN(dateDenNgay.Value.Date) + "',103) ";
            sql2 += " AND MaDVChuyen='" + phong + "'  AND NgayXuLy IS NULL  AND Mess='True' ";
            DataTable tb = CCallCenter.getDataTable(sql2);
            if (tb.Rows.Count > 0)
            {
                Mess of = new Mess(tb);
                timer1.Stop();
                if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            if (_ticks % 2 == 0)
                alrt();
        }


    }
}
