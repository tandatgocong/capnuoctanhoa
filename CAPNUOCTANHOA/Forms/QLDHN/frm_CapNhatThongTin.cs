﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.Forms.QLDHN.Tab;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CrystalDecisions.CrystalReports.Engine;
using CAPNUOCTANHOA.Forms.Reports;
using CAPNUOCTANHOA.Forms.QLDHN.tabDieuChinh;
using CAPNUOCTANHOA.Forms.QLDHN.BC;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_CapNhatThongTin : UserControl
    {
        public frm_CapNhatThongTin()
        {
            InitializeComponent();
        }
        int tods = 0;
        private void frm_CapNhatThongTin_Load(object sender, EventArgs e)
        {

            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbDotDS.SelectedIndex = 1;

            this.qlNam.Text = DateTime.Now.Year.ToString();
            qlKy.SelectedIndex = DateTime.Now.Month - 1;
            qlDot.SelectedIndex = 1;

            this.kdNam.Text = DateTime.Now.Year.ToString();
            kdKy.SelectedIndex = DateTime.Now.Month - 1;
            kdDot.SelectedIndex = 1;
            txtNgayGan.Value = DateTime.Now.Date;

            this.dcNam.Text = DateTime.Now.Year.ToString();
            dcKy.SelectedIndex = DateTime.Now.Month - 1;
            dcDot.SelectedIndex = 1;
            dcNgayYC.Value = DateTime.Now.Date;

            this.ksdlNam.Text = DateTime.Now.Year.ToString();
            ksdlKy.SelectedIndex = DateTime.Now.Month - 1;
            ksdlDot.SelectedIndex = 1;


        }
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_CapNhatThongTin).Name);
        private void btThem_Click(object sender, EventArgs e)
        {
            string dot = cbDotDS.Items[cbDotDS.SelectedIndex].ToString();
            string ky = cbKyDS.Items[cbKyDS.SelectedIndex].ToString();
            string nam = txtNam.Text.Trim();
            try
            {
                if (ckSoNha.Checked)
                {
                    UpDateSoNha(dot, ky, nam);
                    UpDateCSNuocGBDM(dot, ky, nam);
                }
                if (ckHieuGM.Checked)
                {
                    UpDateHieuGM(dot, ky, nam);
                }
                if (ckHieuHH.Checked)
                {
                    UpDateHieuHH(dot, ky, nam);
                }
                if (ckCSNuoc.Checked)
                {
                    UpDateCSNuoc(dot, ky, nam);
                }
                if (ckLoTrinhDot.Checked)
                {
                    UpDateCSLoTrinh(dot, ky, nam);
                }
                if (ckGhichu.Checked)
                {
                    UpdateChiChu(dot, ky, nam);
                }
                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateChiChu(string dot, string ky, string nam)
        {
            string sql = " UPDATE DocSo_PHT.dbo.DS" + nam + " SET  GHICHUVANPHONG=t2.NOIDUNG ";
            sql += " FROM (SELECT NOIDUNG,DANHBO FROM CAPNUOCTANHOA.dbo.TB_GHICHU as t2 WHERE DONVI='QLDHN' ) as t2  ";
            sql += "  WHERE DANHBA= t2.DANHBO AND LEFT(MALOTRINH,2)='" + dot + "' AND KY='" + int.Parse(ky) + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "MALOTRINH"); ;
            DAL.LinQConnection.ExecuteCommand(sql);
        }
        public void UpDateSoNha(string dot, string ky, string nam)
        {
            string sql = " UPDATE DocSo_PHT.dbo.KHACHHANG SET  SO=t2.SONHA ,DUONG=t2.TENDUONG ";
            sql += "FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2 ";
            sql += " WHERE  DANHBA = t2.DANHBO AND LEFT(t2.LOTRINH,2)='" + dot + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "t2.LOTRINH"); ;
            DAL.LinQConnection.ExecuteCommand(sql);
        }
        public void UpDateHieuHH(string dot, string ky, string nam)
        {
            string sql = " UPDATE DocSo_PHT.dbo.KHACHHANG SET  VITRI=LEFT(t2.VITRIDHN,1) ,HIEU=t2.HIEUDH, SOTHAN= t2.SOTHANDH ";
            sql += " FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2";
            sql += " WHERE  DANHBA = t2.DANHBO AND LEFT(t2.LOTRINH,2)='" + dot + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "t2.LOTRINH"); ;
            DAL.LinQConnection.ExecuteCommand(sql);
        }
        public void UpDateHieuGM(string dot, string ky, string nam)
        {
            string sql = " UPDATE DocSo_PHT.dbo.KHACHHANG SET  VITRI=t2.VITRIDHN ,HIEU=t2.HIEUDH, SOTHAN= t2.SOTHANDH ";
            sql += " FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2";
            sql += " WHERE DANHBA = t2.DANHBO AND t2.KY='" + int.Parse(ky) + "' AND t2.NAM='" + int.Parse(nam) + "'";
            DAL.LinQConnection.ExecuteCommand(sql);
        }
        public void UpDateCSNuocGBDM(string dot, string ky, string nam)
        {
            string sql = "  UPDATE TB_DULIEUKHACHHANG SET  GIABIEU=GB, DINHMUC=DM ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ";
            sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSo_PHT.dbo.DS" + nam + ".DANHBA ";
            sql += "		AND DocSo_PHT.dbo.DS" + nam + ".KY ='" + int.Parse(ky) + "'  AND DocSo_PHT.dbo.DS" + nam + ".DOT = " + int.Parse(dot) + "";
            DAL.LinQConnection.ExecuteCommand(sql);
        }

        public void UpDateCSNuoc(string dot, string ky, string nam)
        {
            string sql = "  UPDATE TB_DULIEUKHACHHANG SET  CHISOKYTRUOC= CSMOI, TB_DULIEUKHACHHANG.CODE=DocSo_PHT.dbo.DS" + nam + ".CODE ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " ";
            sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSo_PHT.dbo.DS" + nam + ".DANHBA ";
            sql += "	  AND CSMOI IS NOT NULL  AND CSCU<=CSMOI ";
            sql += "		AND DocSo_PHT.dbo.DS" + nam + ".KY ='" + int.Parse(ky) + "'  AND DocSo_PHT.dbo.DS" + nam + ".DOT = " + int.Parse(dot) + "";
            DAL.LinQConnection.ExecuteCommand(sql);
        }
        public void UpDateCSLoTrinh(string dot, string ky, string nam)
        {
            if ("TB01".Equals(DAL.SYS.C_USERS._toDocSo) == true)
            {
                tods = 1;
            }
            if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo) == true)
            {
                tods = 2;
            }
            if ("TP".Equals(DAL.SYS.C_USERS._toDocSo) == true)
            {
                tods = 3;
            }
            string sql = " UPDATE DocSo_PHT.dbo.KHACHHANG SET  MALOTRINH=t2.LOTRINH ,MALOTRINH2=t2.LOTRINH, DOT= LEFT(t2.LOTRINH,2), MAY=SUBSTRING(MALOTRINH,3,2), TODS='" + tods + "' ";
            sql += " FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2";
            sql += " WHERE  DANHBA = t2.DANHBO AND LEFT(t2.LOTRINH,2)='" + dot + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "t2.LOTRINH"); ;
            DAL.LinQConnection.ExecuteCommand(sql);
        }


        public DataTable getThongTinCapNhat(string dot, string ky, string nam)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT MALOTRINH, DANHBA,HIEUDHN,SOTHAN, VITRI, HIEUMOI,SOTHANMOI, VITRIMOI  FROM [DocSo_PHT].[dbo].[DS" + nam + "] ";
                sql += " WHERE LEN(HIEUMOI)=5  AND KY='" + int.Parse(ky) + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "MALOTRINH");
                return DAL.LinQConnection.getDataTable(sql);

            }
            else
            {
                string sql = " SELECT MALOTRINH, DANHBA,HIEUDHN,SOTHAN, VITRI, HIEUMOI,SOTHANMOI, VITRIMOI  FROM [DocSo_PHT].[dbo].[DS" + nam + "] ";
                sql += " WHERE LEN(HIEUMOI)=5  AND KY='" + int.Parse(ky) + "' AND DOT = '" + int.Parse(dot) + "'  " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "MALOTRINH");
                return DAL.LinQConnection.getDataTable(sql);
            }

        }

        public DataTable getThongTinDiaChi(string dot, string ky, string nam)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT MALOTRINH, DANHBA, kh.SONHA,kh.TENDUONG, ds.SOMOI, (kh.SONHA + '('+ ds.SOMOI +')' ) as TH ";
                sql += " FROM [DocSo_PHT].[dbo].[DS" + nam + "] ds ,TB_DULIEUKHACHHANG kh ";
                sql += " WHERE kh.DANHBO= ds.DANHBA AND ds.SOMOI IS NOT NULL AND ds.SOMOI <> ''  AND ds.KY='" + int.Parse(ky) + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "ds.MALOTRINH");
                return DAL.LinQConnection.getDataTable(sql);

            }
            else
            {
                string sql = " SELECT MALOTRINH, DANHBA, kh.SONHA,kh.TENDUONG, ds.SOMOI, (kh.SONHA + '('+ ds.SOMOI +')' ) as TH ";
                sql += " FROM [DocSo_PHT].[dbo].[DS" + nam + "] ds ,TB_DULIEUKHACHHANG kh ";
                sql += " WHERE kh.DANHBO= ds.DANHBA AND ds.SOMOI IS NOT NULL AND ds.SOMOI <> ''  AND ds.KY='" + int.Parse(ky) + "' AND ds.DOT = '" + int.Parse(dot) + "'  " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "ds.MALOTRINH");
                return DAL.LinQConnection.getDataTable(sql);
            }

        }


        private void btXemTT_Click(object sender, EventArgs e)
        {
            string dot = qlDot.Items[qlDot.SelectedIndex].ToString();
            string ky = qlKy.Items[qlKy.SelectedIndex].ToString();
            string nam = qlNam.Text.Trim();
            dataGridView1.DataSource = getThongTinCapNhat(dot, ky, nam);
            Utilities.DataGridV.formatRows(dataGridView1);

            gridSoNha.DataSource = getThongTinDiaChi(dot, ky, nam);
            Utilities.DataGridV.formatRows(gridSoNha);
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    string DanhBo = dataGridView1.Rows[i].Cells["DANHBO"].Value + "";
                    string HieuMoi = dataGridView1.Rows[i].Cells["HIEUMOI"].Value + "";
                    string SoThan = dataGridView1.Rows[i].Cells["SOTHANMOI"].Value + "";
                    string Vitrimoi = dataGridView1.Rows[i].Cells["VTMOI"].Value + "";
                    string HM = HieuMoi.Substring(0, 3);
                    string nam = "20" + HieuMoi.Substring(3, 2);
                    string sqlUPdate = "UPDATE TB_DULIEUKHACHHANG SET HIEUDH = '" + HM + "',NGAYTHAY = '01/01/" + nam + "' , MODIFYBY='" + DAL.SYS.C_USERS._userName + "' , MODIFYDATE=GETDATE() ";
                    if ("".Equals(SoThan) == false)
                    {
                        sqlUPdate += " , SOTHANDH='" + SoThan + "'";
                    }
                    if ("".Equals(Vitrimoi) == false)
                    {
                        sqlUPdate += " , VITRIDHN=N'" + Vitrimoi + "' ";
                    }
                    sqlUPdate += " WHERE DANHBO='" + DanhBo.Replace(" ", "") + "'";

                    DAL.LinQConnection.ExecuteCommand(sqlUPdate);


                }
                catch (Exception ex)
                {
                    log.Error("Cap Nhat HandHeld Loi " + ex.Message);
                }

            }
            MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /*
         *  Tab 2
         */
        public static DataTable getThonTinDieuChinh(string danhbo, string nam)
        {
            string sql = "SELECT TOP(1) ds.KY,ds.DOT, DANHBO, ds.MALOTRINH as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM, ds.TBTHU as TTBQ ,ds.GHICHUMOI as CONGDUNG ";
            sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
            sql += "  WHERE  ds.DANHBA=kh.DANHBO AND  ds.DANHBA ='" + danhbo + "' ORDER BY ds.KY DESC ";
            return DAL.LinQConnection.getDataTable(sql);
        }

        DataTable result = null;
        private void kdXemTT_Click(object sender, EventArgs e)
        {
            string dot = kdDot.Items[kdDot.SelectedIndex].ToString();
            string ky = kdKy.Items[kdKy.SelectedIndex].ToString();
            string nam = kdNam.Text.Trim();
            string list = "SELECT DANHBA FROM [DocSo_PHT].[dbo].[DS" + nam + "] where KY=" + int.Parse(ky) + " AND DOT=" + int.Parse(dot) + " AND LEN(REPLACE(GHICHUMOI,'/',''))>=2 " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "MALOTRINH");
            DataTable listdb = DAL.LinQConnection.getDataTable(list);

            for (int i = 0; i < listdb.Rows.Count; i++)
            {
                string db = listdb.Rows[i]["DANHBA"] + "";
                if (result == null)
                {
                    result = getThonTinDieuChinh(db, nam);
                }
                else
                {
                    result.Merge(getThonTinDieuChinh(db, nam));
                }
            }
            dataBangKe.DataSource = result;

        }

        private void dataBangKe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(this, e.KeyChar + "");
            //if (e.KeyChar == (char)Keys.Delete)
            //{
            //    result.Rows.RemoveAt(dataBangKe.CurrentRow.Index);
            //    dataBangKe.DataSource = result;
            //}

        }

        private void dataBangKe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (result != null)
                {
                    result.Rows.RemoveAt(dataBangKe.CurrentRow.Index);
                    dataBangKe.DataSource = result;
                }
            }
        }

        private void dataBangKe_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    result.Rows.RemoveAt(dataBangKe.CurrentRow.Index);
            //    dataBangKe.DataSource = result;
            //}
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataBangKe.Rows.Count; i++)
            {

                try
                {
                    TB_CHUYENDINHMUC chuyendm = DAL.QLDHN.C_ChuyenDinhMuc.findByDanhBoChuyenDM((dataBangKe.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", ""), this.txtNgayGan.Value.Date);
                    if (chuyendm != null)
                    {
                        chuyendm.KY = int.Parse(dataBangKe.Rows[i].Cells["G_KY"].Value + "");
                        chuyendm.DOT = int.Parse(dataBangKe.Rows[i].Cells["DOT"].Value + "");
                        chuyendm.NAM = DateTime.Now.Date.Year;
                        chuyendm.TODS = DAL.SYS.C_USERS._toDocSo;
                        chuyendm.DANHBO = dataBangKe.Rows[i].Cells["G_DANHBO"].Value + "";
                        chuyendm.LOTRINH = dataBangKe.Rows[i].Cells["G_LOTRINH"].Value + "";
                        chuyendm.HOTEN = dataBangKe.Rows[i].Cells["HOTEN"].Value + "";
                        chuyendm.DIACHI = dataBangKe.Rows[i].Cells["DIACHI"].Value + "";
                        chuyendm.HOPDONG = dataBangKe.Rows[i].Cells["HOPDONG"].Value + "";
                        chuyendm.GB = dataBangKe.Rows[i].Cells["GB"].Value + "";
                        chuyendm.DM = dataBangKe.Rows[i].Cells["DM"].Value + "";
                        chuyendm.TTBQ = int.Parse(dataBangKe.Rows[i].Cells["TTBQ"].Value + "");
                        chuyendm.CONGDUNG = dataBangKe.Rows[i].Cells["CONGDUNG"].Value + "";
                        chuyendm.NGAYLAP = this.txtNgayGan.Value.Date;
                        chuyendm.CREATEDATE = DateTime.Now;
                        chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;
                        DAL.QLDHN.C_ChuyenDinhMuc.Update();
                    }
                    else
                    {
                        chuyendm = new TB_CHUYENDINHMUC();
                        chuyendm.KY = int.Parse(dataBangKe.Rows[i].Cells["G_KY"].Value + "");
                        chuyendm.DOT = int.Parse(dataBangKe.Rows[i].Cells["DOT"].Value + "");
                        chuyendm.NAM = DateTime.Now.Date.Year;
                        chuyendm.TODS = DAL.SYS.C_USERS._toDocSo;
                        chuyendm.DANHBO = dataBangKe.Rows[i].Cells["G_DANHBO"].Value + "";
                        chuyendm.LOTRINH = dataBangKe.Rows[i].Cells["G_LOTRINH"].Value + "";
                        chuyendm.HOTEN = dataBangKe.Rows[i].Cells["HOTEN"].Value + "";
                        chuyendm.DIACHI = dataBangKe.Rows[i].Cells["DIACHI"].Value + "";
                        chuyendm.HOPDONG = dataBangKe.Rows[i].Cells["HOPDONG"].Value + "";
                        chuyendm.GB = dataBangKe.Rows[i].Cells["GB"].Value + "";
                        chuyendm.DM = dataBangKe.Rows[i].Cells["DM"].Value + "";
                        chuyendm.TTBQ = int.Parse(dataBangKe.Rows[i].Cells["TTBQ"].Value + "");
                        chuyendm.CONGDUNG = dataBangKe.Rows[i].Cells["CONGDUNG"].Value + "";
                        chuyendm.NGAYLAP = this.txtNgayGan.Value.Date;
                        chuyendm.CREATEDATE = DateTime.Now;
                        chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;
                        DAL.QLDHN.C_ChuyenDinhMuc.Insert(chuyendm);
                    }


                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
            ReportDocument rp = new rpt_PhieuChuyenDinhMuc();
            rp.SetDataSource(DAL.QLDHN.C_ChuyenDinhMuc.getReport(this.txtNgayGan.Value.ToShortDateString()));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();

        }
        /*sfsdfds */
        public static DataTable getListDutChiThan(string dot, string ky, string nam)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT kh.DANHBO, ds.MALOTRINH as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GHICHUMOI  ";
                sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.KY=" + int.Parse(ky) + " AND LEN(REPLACE(GHICHUMOI,'/',''))>=2 " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH");
                sql += " ORDER BY ds.MALOTRINH ASC";

                return DAL.LinQConnection.getDataTable(sql);

            }
            else
            {
                string sql = " SELECT kh.DANHBO, ds.MALOTRINH as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GHICHUMOI  ";
                sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.KY=" + int.Parse(ky) + " AND ds.DOT=" + int.Parse(dot) + "  AND LEN(REPLACE(GHICHUMOI,'/',''))>=2 " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH");
                sql += " ORDER BY ds.MALOTRINH ASC";
                return DAL.LinQConnection.getDataTable(sql);
            }

        }
        public static DataTable getListDutChiThan(string dot, string ky, string nam, string ngay)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT kh.DANHBO, ds.MALOTRINH as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GHICHUMOI  ";
                sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.KY=" + int.Parse(ky) + " AND LEN(REPLACE(GHICHUMOI,'/',''))>=2 " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH") + " AND  ds.DANHBA NOT IN (SELECT DANHBO FROM TB_TLKDUTCHI  WHERE  NGAYBAO='" + ngay + "')";
                sql += " ORDER BY ds.MALOTRINH ASC";

                return DAL.LinQConnection.getDataTable(sql);

            }
            else
            {
                string sql = " SELECT kh.DANHBO, ds.MALOTRINH as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GHICHUMOI  ";
                sql += " FROM DocSo_PHT.dbo.DS" + nam + " AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.KY=" + int.Parse(ky) + " AND ds.DOT=" + int.Parse(dot) + "  AND LEN(REPLACE(GHICHUMOI,'/',''))>=2 " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH") + " AND  ds.DANHBA NOT IN (SELECT DANHBO FROM TB_TLKDUTCHI  WHERE  NGAYBAO='" + ngay + "')";
                sql += " ORDER BY ds.MALOTRINH ASC";
                return DAL.LinQConnection.getDataTable(sql);
            }

        }

        DataTable dutchi = null;
        private void bt_DCIN_Click(object sender, EventArgs e)
        {
            string dot = dcDot.Items[dcDot.SelectedIndex].ToString();
            string ky = dcKy.Items[dcKy.SelectedIndex].ToString();
            string nam = dcNam.Text.Trim();

            dutchi = getListDutChiThan(dot, ky, nam);
            dataDutChiThan.DataSource = dutchi;

        }

        private void dataDutChiThan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dutchi != null)
                {
                    dutchi.Rows.RemoveAt(dataDutChiThan.CurrentRow.Index);
                    dataDutChiThan.DataSource = dutchi;
                }
            }
        }

        private void btInTLKDutChi_Click(object sender, EventArgs e)
        {
            string listDanhBa = "";
            for (int i = 0; i < dataDutChiThan.Rows.Count; i++)
            {
                if ("True".Equals(this.dataDutChiThan.Rows[i].Cells["checkChon"].Value + ""))
                {
                    string DC_DANHBO = this.dataDutChiThan.Rows[i].Cells["DC_DANHBO"].Value + "";
                    string DC_LOTRINH = this.dataDutChiThan.Rows[i].Cells["DC_LOTRINH"].Value + "";
                    string DC_HOTEN = this.dataDutChiThan.Rows[i].Cells["DC_HOTEN"].Value + "";
                    string DC_DIACHI = this.dataDutChiThan.Rows[i].Cells["DC_DIACHI"].Value + "";
                    string DC_HOPDONG = this.dataDutChiThan.Rows[i].Cells["DC_HOPDONG"].Value + "";
                    string DC_GB = this.dataDutChiThan.Rows[i].Cells["DC_GB"].Value + "";
                    string DC_DM = this.dataDutChiThan.Rows[i].Cells["DC_DM"].Value + "";
                    string DC_HIEU = this.dataDutChiThan.Rows[i].Cells["DC_HIEU"].Value + "";
                    string DC_CO = this.dataDutChiThan.Rows[i].Cells["DC_CO"].Value + "";
                    string SOTHANDH = this.dataDutChiThan.Rows[i].Cells["SOTHANDH"].Value + "";

                    TB_TLKDUTCHI dc = DAL.QLDHN.C_DhnAmSau.findByDanhBoDutChi(DC_DANHBO.Replace(" ", ""), this.dcNgayYC.Value.Date);
                    if (dc != null)
                    {
                        dc.TODS = DAL.SYS.C_USERS._toDocSo;
                        dc.DANHBO = DC_DANHBO;
                        dc.LOTRINH = DC_LOTRINH;
                        dc.HOTEN = DC_HOTEN;
                        dc.DIACHI = DC_DIACHI;
                        dc.HOPDONG = DC_HOPDONG;
                        dc.GB = DC_GB;
                        dc.DM = DC_DM;
                        dc.HIEU = DC_HIEU;
                        dc.CO = DC_CO;
                        dc.SOTHAN = SOTHANDH;
                        dc.NGAYBAO = this.dcNgayYC.Value.Date;
                        dc.MODIFYDATE = DateTime.Now;
                        dc.MODIFYBY = DAL.SYS.C_USERS._userName;
                        DAL.QLDHN.C_DhnAmSau.Update();
                    }
                    else
                    {
                        dc = new TB_TLKDUTCHI();
                        dc.TODS = DAL.SYS.C_USERS._toDocSo;
                        dc.DANHBO = DC_DANHBO;
                        dc.LOTRINH = DC_LOTRINH;
                        dc.HOTEN = DC_HOTEN;
                        dc.DIACHI = DC_DIACHI;
                        dc.HOPDONG = DC_HOPDONG;
                        dc.GB = DC_GB;
                        dc.DM = DC_DM;
                        dc.HIEU = DC_HIEU;
                        dc.CO = DC_CO;
                        dc.SOTHAN = SOTHANDH;
                        dc.NGAYBAO = this.dcNgayYC.Value.Date;
                        dc.CREATEDATE = DateTime.Now;
                        dc.CREATEBY = DAL.SYS.C_USERS._userName;
                        DAL.QLDHN.C_DhnAmSau.Insert(dc);
                    }
                    listDanhBa += ("'" + (DC_DANHBO.Replace(" ", "") + "',"));
                }
            }
            listDanhBa = listDanhBa.Remove(listDanhBa.Length - 1, 1);
            ReportDocument rp = new rpt_TLKDutChi();
            rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReportDutChi(listDanhBa, this.dcNgayYC.Value.Date.ToShortDateString()));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();


            string dot = dcDot.Items[dcDot.SelectedIndex].ToString();
            string ky = dcKy.Items[dcKy.SelectedIndex].ToString();
            string nam = dcNam.Text.Trim();

            dutchi = getListDutChiThan(dot, ky, nam, this.dcNgayYC.Value.Date.ToShortDateString());
            dataDutChiThan.DataSource = dutchi;
        }

        private void btSoNhaMoi_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridSoNha.Rows.Count; i++)
                {
                    try
                    {


                        string DC_DB = gridSoNha.Rows[i].Cells["DC_DB"].Value + "";
                        string TONGHOPDC = gridSoNha.Rows[i].Cells["TONGHOPDC"].Value + "";
                        string DC_DUONGMOI = gridSoNha.Rows[i].Cells["DC_DUONGMOI"].Value + "";

                        string sqlUPdate = "UPDATE TB_DULIEUKHACHHANG SET  MODIFYBY='" + DAL.SYS.C_USERS._userName + "' , MODIFYDATE=GETDATE() ";

                        if ("".Equals(TONGHOPDC) == false)
                        {
                            sqlUPdate += " , SONHA=N'" + TONGHOPDC.ToUpper() + "' ";
                        }

                        if ("".Equals(DC_DUONGMOI) == false)
                        {
                            sqlUPdate += " , TENDUONG=N'" + DC_DUONGMOI.ToUpper() + "' ";
                        }

                        sqlUPdate += " WHERE DANHBO='" + DC_DB.Replace(" ", "") + "'";

                        DAL.LinQConnection.ExecuteCommand(sqlUPdate);


                    }
                    catch (Exception ex)
                    {
                        log.Error("Cap Nhat HandHeld Loi " + ex.Message);
                    }

                }
                MessageBox.Show(this, "Cập Nhật Thông Tin Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ksdlBT_Click(object sender, EventArgs e)
        {
            string dot = ksdlDot.Items[ksdlDot.SelectedIndex].ToString();
            string ky = ksdlKy.Items[ksdlKy.SelectedIndex].ToString();
            string nam = ksdlNam.Text.Trim();
            string SQL = "SELECT TODS,DANHBA,MALOTRINH FROM DocSo_PHT.dbo.DS" + nam + " WHERE CSMOI IS NULL AND KY=" + ky + " AND DOT=" + dot + " ORDER BY TODS ASC";
            dataGridView2.DataSource = DAL.LinQConnection.getDataTable(SQL);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string SQL = " SELECT (CONVERT(VARCHAR,[KY])+'/'+CONVERT(VARCHAR,[NAM])) AS HL,LTCU,LTMOI FROM [CAPNUOCTANHOA].[dbo].[TB_YEUCAUDC]  WHERE DANHBO='" + txtSoDanhBo.Text.Replace("-","").Replace(" ","") + "'";
            dataGridView3.DataSource = DAL.LinQConnection.getDataTable(SQL);

        }

        private void txtSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                string SQL = " SELECT (CONVERT(VARCHAR,[KY])+'/'+CONVERT(VARCHAR,[NAM])) AS HL,LTCU,LTMOI FROM [CAPNUOCTANHOA].[dbo].[TB_YEUCAUDC]  WHERE DANHBO='" + txtSoDanhBo.Text.Replace("-", "").Replace(" ", "") + "'";
                dataGridView3.DataSource = DAL.LinQConnection.getDataTable(SQL);
            }
        }
    }
}