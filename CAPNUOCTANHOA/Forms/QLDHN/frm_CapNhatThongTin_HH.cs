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
using System.Configuration;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_CapNhatThongTin : UserControl
    {
        public frm_CapNhatThongTin()
        {
            InitializeComponent();
            this.comboBoxDutChi.SelectedIndex = 0;
        }
        int tods = 0;
        private void frm_CapNhatThongTin_Load(object sender, EventArgs e)
        {

            this.txtNam.Text = DateTime.Now.Year.ToString();
            cbKyDS.SelectedIndex = DateTime.Now.Month - 1;
            cbDotDS.SelectedIndex = 1;

            this.cnNam.Text = DateTime.Now.Year.ToString();
            cnKy.SelectedIndex = DateTime.Now.Month - 1;
            chDot.SelectedIndex = 1;


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
            cnMayDS.DataSource = DAL.LinQConnection.getDataTable("SELECT MAYDS FROM TB_NHANVIENDOCSO ORDER BY MAYDS ASC");
            cnMayDS.ValueMember = "MAYDS";
            cnMayDS.DisplayMember = "MAYDS";


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
                  //  UpDateCSNuocGBDM(dot, ky, nam);
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
                   // UpDateCSNuocGBDM(dot, ky, nam);
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
            string sql = " UPDATE DocSoTH.dbo.DocSo SET GhiChuKH=LEFT(t2.NOIDUNG,500) ";
            sql += " FROM ( SELECT  t2.NOIDUNG,t2.DANHBO,t2.CREATEDATE 	FROM CAPNUOCTANHOA.dbo.TB_GHICHU as t2 ,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG kh ";
            sql += " WHERE    kh.DANHBO= t2.DANHBO AND LEFT(kh.LOTRINH,2)='" + dot + "' AND  DONVI='QLDHN' and t2.CREATEBY not in (N'Trương Nguyễn Bảo Trân',N'IT',N'Bảo Bảo',N'Võ Thành Trung') and t2.CREATEDATE = (SELECT MAX(CREATEDATE) FROM  TB_GHICHU WHERE  DONVI='QLDHN' AND DANHBO=t2.DANHBO and CREATEBY not in (N'Trương Nguyễn Bảo Trân',N'IT',N'Bảo Bảo',N'Võ Thành Trung'))  ) as t2  ";
            sql += "  WHERE NAM=" + nam + " AND  DANHBA= t2.DANHBO AND DOT=" + int.Parse(dot) + " AND KY=" + int.Parse(ky) + "";
            DAL.LinQConnection.ExecuteCommand_(sql);

        }
        public void UpDateSoNha(string dot, string ky, string nam)
        {
            //string sql = " UPDATE DocSoTH.dbo.KhachHang SET  So=t2.SONHA ,Duong=t2.TENDUONG,SDT=t2.DIENTHOAI,ViTri=LEFT(t2.VITRIDHN,1) ,Hieu=t2.HIEUDH, SoThan= t2.SOTHANDH ";
            //sql += "FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2 ";
            //sql += " WHERE  DanhBa = t2.DANHBO ";
            //DAL.LinQConnection.ExecuteCommand_(sql);
            DAL.LinQConnection.ExecuteStoredProcedure("UpdateDHN");
        }
        public void UpDateHieuHH(string dot, string ky, string nam)
        {
            string sql = " UPDATE DocSoTH.dbo.KhachHang SET  ViTri=LEFT(t2.VITRIDHN,1) ,Hieu=t2.HIEUDH, SoThan= t2.SOTHANDH ";
            sql += " FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2";
            sql += " WHERE  DANHBA = t2.DANHBO AND DOT=" + int.Parse(dot) + " ";
            DAL.LinQConnection.ExecuteCommand_(sql);
        }
        public void UpDateHieuGM(string dot, string ky, string nam)
        {
            string sql = " UPDATE DocSoTH.dbo.KhachHang SET  ViTri=t2.VITRIDHN ,Hieu=t2.HIEUDH, SoThan= t2.SOTHANDH ";
            sql += " FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2";
            sql += " WHERE DANHBA = t2.DANHBO AND t2.KY=" + int.Parse(ky) + " AND t2.NAM=" + int.Parse(nam) + "";
            DAL.LinQConnection.ExecuteCommand_(sql);
        }
        public void UpDateCSNuocGBDM(string dot, string ky, string nam)
        {
            //if ("00".Equals(dot))
            //{
            //    string sql = "  UPDATE TB_DULIEUKHACHHANG SET  GIABIEU=GB, DINHMUC=DM ";
            //    sql += " FROM DocSoTH.dbo.DS" + nam + " ";
            //    sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSoTH.dbo.DS" + nam + ".DANHBA ";
            //    sql += "		AND DocSoTH.dbo.DS" + nam + ".KY ='" + int.Parse(ky) + "' ";
            //    DAL.LinQConnection.ExecuteCommand_(sql);
            //}
            //else
            //{
            //    string sql = "  UPDATE TB_DULIEUKHACHHANG SET  GIABIEU=GB, DINHMUC=DM ";
            //    sql += " FROM DocSoTH.dbo.DS" + nam + " ";
            //    sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSoTH.dbo.DS" + nam + ".DANHBA ";
            //    sql += "		AND DocSoTH.dbo.DS" + nam + ".KY ='" + int.Parse(ky) + "'  AND DocSoTH.dbo.DS" + nam + ".DOT = " + int.Parse(dot) + "";
            //    DAL.LinQConnection.ExecuteCommand_(sql);
            //}
        }

        public void UpDateCSNuoc(string dot, string ky, string nam)
        {

            DAL.LinQConnection.ExecuteStoredProcedure("UpdateChiSo", int.Parse(ky), int.Parse(nam));
            //if ("00".Equals(dot))
            //{
            //    string sql = "  UPDATE TB_DULIEUKHACHHANG SET  CHISOKYTRUOC= CSMoi, TB_DULIEUKHACHHANG.CODE=DocSoTH.dbo.DocSo.CodeMoi,SODHN=TieuThuMoi ";
            //    sql += " FROM DocSoTH.dbo.DocSo ";
            //    sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSoTH.dbo.DocSo.DANHBA ";
            //    sql += "		AND  DocSoTH.dbo.DocSo.NAM=" + nam + " AND  DocSoTH.dbo.DocSo.KY =" + int.Parse(ky);
            //    DAL.LinQConnection.ExecuteCommand_(sql);

            //}
            //else
            //{
            //    //string sql = "  UPDATE TB_DULIEUKHACHHANG SET  CHISOKYTRUOC= CSMOI, TB_DULIEUKHACHHANG.CODE=DocSoTH.dbo.DS" + nam + ".CODE,SODHN=TIEUTHU ";
            //    //sql += " FROM DocSoTH.dbo.DS" + nam + " ";
            //    //sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSoTH.dbo.DS" + nam + ".DANHBA ";
            //    //sql += "		AND DocSoTH.dbo.DS" + nam + ".KY ='" + int.Parse(ky) + "'  AND DocSoTH.dbo.DS" + nam + ".DOT = " + int.Parse(dot) + "";
            //    //DAL.LinQConnection.ExecuteCommand_(sql);
            //    string sql = "  UPDATE TB_DULIEUKHACHHANG SET  CHISOKYTRUOC= CSMoi, TB_DULIEUKHACHHANG.CODE=DocSoTH.dbo.DocSo.CodeMoi,SODHN=TieuThuMoi ";
            //    sql += " FROM DocSoTH.dbo.DocSo ";
            //    sql += " WHERE TB_DULIEUKHACHHANG.DANHBO = DocSoTH.dbo.DocSo.DANHBA ";
            //    sql += "AND  DocSoTH.dbo.DocSo.DOT=" + int.Parse(dot) + " AND  DocSoTH.dbo.DocSo.NAM=" + nam + " AND  DocSoTH.dbo.DocSo.KY =" + int.Parse(ky);
            //    DAL.LinQConnection.ExecuteCommand_(sql);

            
            //}

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
            if ("TP01".Equals(DAL.SYS.C_USERS._toDocSo) == true)
            {
                tods = 3;
            }
            if ("TP02".Equals(DAL.SYS.C_USERS._toDocSo) == true)
            {
                tods = 4;
            }
            string sql = " UPDATE DocSoTH.dbo.KHACHHANG SET  MLT1=t2.LOTRINH ,MLT2=t2.LOTRINH, DOT= LEFT(t2.LOTRINH,2), MAY=SUBSTRING(MLT1,3,2), TODS='" + tods + "' ";
            sql += " FROM CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG as t2";
            sql += " WHERE  DANHBA = t2.DANHBO AND LEFT(t2.LOTRINH,2)='" + dot + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "t2.LOTRINH"); ;
            DAL.LinQConnection.ExecuteCommand_(sql);
        }


        public DataTable getThongTinCapNhat(string dot, string ky, string nam)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT MLT1, DANHBA,HIEUDHN,SOTHAN, VITRI, HIEUMOI,SOTHANMOI, VITRIMOI  FROM DocSoTH.dbo.DocSo ";
                sql += " WHERE  DocSoTH.dbo.DocSo.NAM=" + nam + " AND  LEN(HIEUMOI)=5  AND KY='" + int.Parse(ky) + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "MLT1");
                return DAL.LinQConnection.getDataTable(sql);
            }
            else
            {
                string sql = " SELECT MLT1, DANHBA,HIEUDHN,SOTHAN, VITRI, HIEUMOI,SOTHANMOI, VITRIMOI  FROM DocSoTH.dbo.DocSo ";
                sql += " WHERE NAM=" + nam + " AND  LEN(HIEUMOI)=5  AND KY='" + int.Parse(ky) + "' AND DOT = '" + int.Parse(dot) + "'  " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "MLT1");
                return DAL.LinQConnection.getDataTable(sql);
            }
        }

        public DataTable getThongTinDiaChi(string dot, string ky, string nam)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT MLT1, DANHBA, kh.SONHA,kh.TENDUONG, ds.SOMOI, (kh.SONHA + '('+ ds.SOMOI +')' ) as TH ";
                sql += " FROM [DocSoTH].[dbo].[DS" + nam + "] ds ,TB_DULIEUKHACHHANG kh ";
                sql += " WHERE kh.DANHBO= ds.DANHBA AND ds.SOMOI IS NOT NULL AND ds.SOMOI <> ''  AND ds.KY='" + int.Parse(ky) + "' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "ds.MLT1");
                return DAL.LinQConnection.getDataTable(sql);

            }
            else
            {
                string sql = " SELECT MLT1, DANHBA, kh.SONHA,kh.TENDUONG, ds.SOMOI, (kh.SONHA + '('+ ds.SoNhaMoi +')' ) as TH ";
                sql += " FROM DocSoTH.dbo.DocSo ds ,TB_DULIEUKHACHHANG kh ";
                sql += " WHERE kh.DANHBO= ds.DANHBA AND ds.SOMOI IS NOT NULL AND ds.SOMOI <> ''  AND ds.Nam=" + nam + " AND  ds.KY='" + int.Parse(ky) + "' AND ds.DOT = '" + int.Parse(dot) + "'  " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "ds.MLT1");
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

                    DAL.LinQConnection.ExecuteCommand_(sqlUPdate);


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
            string sql = "SELECT TOP(1) ds.KY,ds.DOT, DANHBO, ds.MLT1 as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM, ds.TBTT as TTBQ ,ds.GhiChuDS as CONGDUNG ";
            sql += " FROM DocSoTH.dbo.DocSo AS ds, dbo.TB_DULIEUKHACHHANG as kh ";
            sql += "  WHERE  ds.DANHBA=kh.DANHBO AND ds.NAM="+nam+" AND  ds.DANHBA ='" + danhbo + "' ORDER BY ds.KY DESC ";
            return DAL.LinQConnection.getDataTable(sql);
        }

        DataTable result = null;
        private void kdXemTT_Click(object sender, EventArgs e)
        {
            string dot = kdDot.Items[kdDot.SelectedIndex].ToString();
            string ky = kdKy.Items[kdKy.SelectedIndex].ToString();
            string nam = kdNam.Text.Trim();
            string list = "SELECT DANHBA FROM [DocSoTH].[dbo].[DocSo] where NAM=" + nam + " AND   KY=" + int.Parse(ky) + " AND DOT=" + int.Parse(dot) + " " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "MLT1") + " AND LEN(REPLACE(GhiChuDS,'/',''))>=2 AND  (GhiChuDS NOT LIKE N'%Đức%' AND GhiChuDS NOT LIKE N'%Đứt%' AND  GhiChuDS NOT LIKE N'%GIẾ%' AND GhiChuDS NOT LIKE N'%CHẠY%')";
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
                  //  string sql1 = " UPDATE [DocSoTH].[dbo].[DS" + kdNam.Text.Trim() + "] SET GhiChuDS=NULL WHERE DANHBA='" + (dataBangKe.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") +"' ";
                    string sql2 = " UPDATE [DocSoTH].[dbo].[KHACHHANG] SET GhiChuKH=NULL WHERE DANHBA='" + (dataBangKe.Rows[i].Cells["G_DANHBO"].Value + "").Replace(" ", "") + "' ";
                 //   DAL.LinQConnection.ExecuteCommand_(sql1);
                    DAL.LinQConnection.ExecuteCommand_(sql2);


                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
            ReportDocument rp = new rpt_PhieuChuyenDinhMuc();
           // rp.SetDataSource(DAL.QLDHN.C_ChuyenDinhMuc.getReport(this.txtNgayGan.Value.ToShortDateString()));
            frm_Reports frm = new frm_Reports(rp);
            frm.ShowDialog();

        }
        /*sfsdfds */
        public DataTable getListDutChiThan(string dot, string ky, string nam)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT kh.DANHBO, ds.MLT1 as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GhiChuDS  ";
                sql += " FROM DocSoTH.dbo.DocSo AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH");
                sql += " AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.NAM="+nam+" AND ds.KY=" + int.Parse(ky) + "  AND  GhiChuDS NOT LIKE N'%GIẾ%' AND  GhiChuDS LIKE N'%" + this.comboBoxDutChi.Text + "%' ";
                sql += " ORDER BY ds.MLT1 ASC";

                return DAL.LinQConnection.getDataTable(sql);

            }
            else
            {
                string sql = " SELECT kh.DANHBO, ds.MLT1 as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GhiChuDS  ";
                sql += " FROM DocSoTH.dbo.DocSo AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO " +DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH");
                sql += " AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.NAM=" + nam + " AND ds.KY=" + int.Parse(ky) + " AND ds.DOT=" + int.Parse(dot) + "  AND GhiChuDS LIKE N'%" + this.comboBoxDutChi.Text + "%' ";
                sql += " ORDER BY ds.MLT1 ASC";
                return DAL.LinQConnection.getDataTable(sql);
            }

        }
        public static DataTable getListDutChiThan(string dot, string ky, string nam, string ngay)
        {
            if ("00".Equals(dot))
            {
                string sql = " SELECT kh.DANHBO, ds.MLT1 as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GhiChuDS  ";
                sql += " FROM DocSoTH.dbo.DocSo AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.NAM=" + nam + " AND ds.KY=" + int.Parse(ky) + " AND LEN(REPLACE(GhiChuDS,'/',''))>=2 " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH") + " AND  ds.DANHBA NOT IN (SELECT DANHBO FROM TB_TLKDUTCHI  WHERE  NGAYBAO='" + ngay + "')";
                sql += " ORDER BY ds.MLT1 ASC";

                return DAL.LinQConnection.getDataTable(sql);

            }
            else
            {
                string sql = " SELECT kh.DANHBO, ds.MLT1 as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GhiChuDS  ";
                sql += " FROM DocSoTH.dbo.DocSo AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.NAM=" + nam + " AND ds.KY=" + int.Parse(ky) + " AND ds.DOT=" + int.Parse(dot) + "  AND LEN(REPLACE(GhiChuDS,'/',''))>=2 " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH") + " AND  ds.DANHBA NOT IN (SELECT DANHBO FROM TB_TLKDUTCHI  WHERE  NGAYBAO='" + ngay + "')";
                sql += " ORDER BY ds.MLT1 ASC";
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

                    TB_TLKDUTCHI dc1 = DAL.QLDHN.C_DhnAmSau.findByDanhBoDutChi_khacgnay(DC_DANHBO.Replace(" ", ""), this.txtNgayGan.Value.Date);
                    if (dc1 != null)
                    {
                        string ngay = Utilities.DateToString.NgayVNVN(dc1.NGAYBAO.Value);
                        string mess = "Danh Bộ " + Utilities.FormatSoHoSoDanhBo.sodanhbo(this.txtSoDanhBo.Text, "-") + " đã báo đứt chì ngày " + ngay + " , Báo tiếp ?";
                        if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
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
                                dc.TYPE = comboBoxDutChi.SelectedIndex;
                                dc.SONAM = comboBoxTitle.SelectedIndex;
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
                                dc.TYPE = comboBoxDutChi.SelectedIndex;
                                dc.SONAM = comboBoxTitle.SelectedIndex;
                                dc.NGAYBAO = this.dcNgayYC.Value.Date;
                                dc.CREATEDATE = DateTime.Now;
                                dc.CREATEBY = DAL.SYS.C_USERS._userName;
                                DAL.QLDHN.C_DhnAmSau.Insert(dc);
                            }
                        }
                        listDanhBa += ("'" + (DC_DANHBO.Replace(" ", "") + "',"));
                    }
                    else {
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
                            dc.TYPE = comboBoxDutChi.SelectedIndex;
                            dc.SONAM = comboBoxTitle.SelectedIndex;
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
                            dc.TYPE = comboBoxDutChi.SelectedIndex;
                            dc.SONAM = comboBoxTitle.SelectedIndex;
                            dc.NGAYBAO = this.dcNgayYC.Value.Date;
                            dc.CREATEDATE = DateTime.Now;
                            dc.CREATEBY = DAL.SYS.C_USERS._userName;
                            DAL.QLDHN.C_DhnAmSau.Insert(dc);
                        }
                        listDanhBa += ("'" + (DC_DANHBO.Replace(" ", "") + "',"));
                    }
                }
            }
            listDanhBa = listDanhBa.Remove(listDanhBa.Length - 1, 1);

            int lan = 1;
            if (tabControl1.SelectedIndex == 1)
            {
                lan = 2;
            }

            if (comboBoxDutChi.SelectedIndex == 0)
            {
                ReportDocument rp = new rpt_TLKDutChi();
                rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReportDutChi(listDanhBa, this.dcNgayYC.Value.Date.ToShortDateString(), 0, comboBoxTitle.SelectedIndex, lan));
                rp.SetParameterValue("type", this.comboBoxTitle.Text);
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
            else if (comboBoxDutChi.SelectedIndex == 1)
            {
                ReportDocument rp = new rpt_TLKDutChi_Goc_();
                rp.SetDataSource(DAL.QLDHN.C_DhnAmSau.getReportDutChi(listDanhBa, this.dcNgayYC.Value.Date.ToShortDateString(), 1, lan));
                rp.SetParameterValue("NGUOILAP", DAL.SYS.C_USERS._fullName.ToUpper());
                frm_Reports frm = new frm_Reports(rp);
                frm.ShowDialog();
            }
           


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
                log.Error(ex.Message);
                MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ksdlBT_Click(object sender, EventArgs e)
        {
            string dot = ksdlDot.Items[ksdlDot.SelectedIndex].ToString();
            string ky = ksdlKy.Items[ksdlKy.SelectedIndex].ToString();
            string nam = ksdlNam.Text.Trim();
            string SQL = "SELECT TODS,DANHBA,MLT1 FROM DocSoTH.dbo.DocSo WHERE (CSMOI IS NULL OR CSCu IS NULL OR TieuThuMoi IS NULL)  AND  NAM=" + nam + " AND KY=" + ky + " AND DOT=" + dot + " ORDER BY TODS ASC";
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

        public void LoadGieng() {
            try
            {
                string dot = chDot.Items[chDot.SelectedIndex].ToString();
                string may = cnMayDS.Text;
                string ky = cnKy.Items[cnKy.SelectedIndex].ToString();
                string nam = cnNam.Text.Trim();
                string sql = " SELECT ROW_NUMBER() OVER (ORDER BY ds.ID  DESC) [STT], kh.DANHBO, ds.MLT1 as LOTRINH ,HOTEN,(SONHA+' '+TENDUONG) AS DIACHI,kh.HOPDONG,ds.GB ,ds.DM,hieu.TENDONGHO, ds.CO, kh.SOTHANDH ,ds.GhiChuDS  ";
                sql += " FROM DocSoTH.dbo.DocSo AS ds, dbo.TB_DULIEUKHACHHANG as kh, TB_HIEUDONGHO hieu ";
                sql += " WHERE  ds.DANHBA=kh.DANHBO AND LEFT(kh.HIEUDH,3)= hieu.HIEUDH AND ds.MAY=" + may + " AND ds.NAM=" + nam + " AND  ds.KY=" + int.Parse(ky) + " AND ds.DOT=" + int.Parse(dot) + "  AND GhiChuDS LIKE N'%GIẾ%' " + DAL.SYS.C_USERS._gioihan.Replace("LOTRINH", "kh.LOTRINH");
                dataGridView4.DataSource = DAL.LinQConnection.getDataTable(sql);
            }
            catch (Exception)
            {
            }
             
        }
        public int CapNhatGhiChu() {
            string dot = chDot.Items[chDot.SelectedIndex].ToString();
            string ky = cnKy.Items[cnKy.SelectedIndex].ToString();
            string nam = cnNam.Text.Trim();
            string sql = "UPDATE DocSoTH.dbo.DS" + nam + " SET GhiChuDS =N'" + this.txtGhiChuMoi.Text + "' WHERE DANHBA='" + this.txtDanhBo.Text.Replace("-","") + "' AND  KY=" + int.Parse(ky) + " AND DOT=" + int.Parse(dot);
            return DAL.LinQConnectionDS.ExecuteCommand(sql);
        }



        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGhiChuMoi.Focus();
            }
            
        }

        private void txtGhiChuDS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (CapNhatGhiChu() > 0)
                {
                    LoadGieng();
                    this.txtDanhBo.Text = "";                    
                    txtDanhBo.Focus();
                    this.txtGhiChuMoi.Text = ConfigurationManager.AppSettings["txtGhiChuDS"].ToString() + "/";
                }
                else
                {
                    MessageBox.Show(this, "Cập Nhật Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabItem6_Click(object sender, EventArgs e)
        {
            LoadGieng();
        }

        private void cnMayDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadGieng();
            }
            catch (Exception)
            {
                                
            }
        }

        void dataLoadDocso()
        {
            tods = 1;
            if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 2;
            }
            if ("TP01".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 3;
            }
            if ("TP02".Equals(DAL.SYS.C_USERS._toDocSo))
            {
                tods = 4;
            }
            string sql = "SELECT MAYDS,FULLNAME,NAME FROM TB_NHANVIENDOCSO WHERE TODS=" + tods + " ORDER BY MAYDS ASC";
            dataGridView5.DataSource = DAL.LinQConnection.getDataTable(sql);
        }
        private void tabItem7_Click(object sender, EventArgs e)
        {

            dataLoadDocso();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMayds.Text = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxTennv.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxTenvt.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();

        }
        bool themmoi = false;
        private void buttonX3_Click(object sender, EventArgs e)
        {
            textBoxMayds.ReadOnly = false;
            themmoi = true;
        }


        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                string chamcong = "INSERT INTO TB_BANGCHAMCONG(STT,NAME,FULLNAME,MAYDS,TODS) VALUES ('" + this.textBoxMayds.Text + "',N'" + this.textBoxTenvt.Text + "',N'" + textBoxTennv.Text + "','" + this.textBoxMayds.Text + "','" + tods + "')";
                DAL.LinQConnection.ExecuteCommand(chamcong);
                string nhanvien = "INSERT INTO TB_NHANVIENDOCSO(NAME,FULLNAME,MAYDS,TODS) VALUES (N'" + this.textBoxTenvt.Text + "',N'" + textBoxTennv.Text + "','" + this.textBoxMayds.Text + "','"+tods+"')";
                DAL.LinQConnection.ExecuteCommand(nhanvien);
                nhanvien = "INSERT INTO TB_BANGCHAMCONG_HD0(NAME,FULLNAME,MAYDS,TODS) VALUES (N'" + this.textBoxTenvt.Text + "',N'" + textBoxTennv.Text + "','" + this.textBoxMayds.Text + "','" + tods + "')";
                DAL.LinQConnection.ExecuteCommand(nhanvien);
                string slh = "INSERT INTO [DocSoTH].[dbo].[Users] ([Username],[UserID],[Password] ,[ToID] ,[MayID],[UserGroup])  VALUES ";
                slh += " (N'" + textBoxTennv.Text + "',N'" + this.textBoxTenvt.Text + "',NULL," + tods + "," + this.textBoxMayds.Text + ",'DS')";
                DAL.LinQConnection.ExecuteCommand(slh);

                themmoi = false;
                dataLoadDocso();
            }
            else {
                string chamcong = "UPDATE TB_BANGCHAMCONG SET NAME=N'" + this.textBoxTenvt.Text + "',FULLNAME=N'" + textBoxTennv.Text+ "' WHERE MAYDS='" + this.textBoxMayds.Text + "'";
                DAL.LinQConnection.ExecuteCommand(chamcong);
                string nhanvien = "UPDATE TB_NHANVIENDOCSO SET NAME=N'" + this.textBoxTenvt.Text + "',FULLNAME=N'" + textBoxTennv.Text + "' WHERE MAYDS='" + this.textBoxMayds.Text + "' AND MAYDS <> 0 ";
                DAL.LinQConnection.ExecuteCommand(nhanvien);
                nhanvien = "UPDATE TB_BANGCHAMCONG_HD0 SET NAME=N'" + this.textBoxTenvt.Text + "',FULLNAME=N'" + textBoxTennv.Text + "' WHERE MAYDS='" + this.textBoxMayds.Text + "' AND MAYDS <> 0 ";
                DAL.LinQConnection.ExecuteCommand(nhanvien);
                string slh = " UPDATE [DocSoTH].[dbo].[MayDS]   SET [NhanVienID] =N'" + textBoxTennv.Text + "'  WHERE MAY=" + this.textBoxMayds.Text + " AND MAY <> 0 ";
                DAL.LinQConnection.ExecuteCommand(slh);

                themmoi = false;
                dataLoadDocso();
            }


        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string chamcong = "DELETE TB_BANGCHAMCONG  WHERE MAYDS='" + this.textBoxMayds.Text + "'";
            DAL.LinQConnection.ExecuteCommand(chamcong);
             chamcong = "DELETE TB_BANGCHAMCONG_HD0  WHERE MAYDS='" + this.textBoxMayds.Text + "'";
            DAL.LinQConnection.ExecuteCommand(chamcong);
            string nhanvien = "DELETE TB_NHANVIENDOCSO  WHERE MAYDS='" + this.textBoxMayds.Text + "'";
            DAL.LinQConnection.ExecuteCommand(nhanvien);
            string slh = " DELETE [DocSoTH].[dbo].[Users]   WHERE MAY='" + this.textBoxMayds.Text + "'";
            DAL.LinQConnection.ExecuteCommand(slh);


            dataLoadDocso();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl2_Click(object sender, EventArgs e)
        {

        }
        /////   

    }
}