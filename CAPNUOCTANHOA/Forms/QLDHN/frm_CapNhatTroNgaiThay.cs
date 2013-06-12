using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_CapNhatTroNgaiThay : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_CapNhatTroNgaiThay).Name);
        CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        TB_THAYDHN thaydhn = null;
        TB_GHICHU ghichu = null;
        TB_TLKDUTCHI dutchi = null;
        TB_DULIEUKHACHHANG kh = null;

        public frm_CapNhatTroNgaiThay(string id)
        {
            InitializeComponent();
            try
            {
                thaydhn = DAL.QLDHN.C_BaoThay.finByID_BAOTHAY(int.Parse(id));
                if (thaydhn != null)
                {

                    txtSoDanhBo.Text = thaydhn.DHN_DANHBO;
                    kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(thaydhn.DHN_DANHBO);
                    if (kh != null)
                    {
                        txtDiaChi.Text = kh.SONHA + " " + kh.TENDUONG;
                        txtTenKH.Text = kh.HOTEN;
                    }

                    txtCo.Text = thaydhn.DHN_CODH;
                    txtLyDoThay.Text = thaydhn.DHN_LYDOTHAY;
                    txtHieuDHN.Text = thaydhn.DHN_HIEUDHN;
                    txtSoThan.Text = thaydhn.DHN_SOTHAN;
                    txtTroNgaiThay.Text = thaydhn.HCT_LYDOTRONGAI;
                    ///thaydhn.XLT_CHUYENXL lưu 2 giá trị TCTB hoặc KTKS
                    if (thaydhn.XLT_CHUYENXL.Equals("TCTB"))
                        txtBoPhanChuyen.Text = "ĐỘI TCTB";
                    else
                        if (thaydhn.XLT_CHUYENXL.Equals("KTKS"))
                            txtBoPhanChuyen.Text = "BAN KTKS";

                    txtKetQuaThucHien.Text = thaydhn.XLT_KETQUA;
                }
            }
            catch (Exception)
            {
            }
        }

        public void Add()
        {
            string sodanhbo = this.txtSoDanhBo.Text.Replace("-", "");
            //ID, , , , , , , , , HIEU, CO, GHICHU, NGAYLAP, GANHOP, GH_GHICHU, CREATEDATE, CREATEBY, MODIFYDATE, MODIFYBY
            TB_DHNAMSAU chuyendm = DAL.QLDHN.C_DhnAmSau.findByDanhBo(sodanhbo);
            TB_DULIEUKHACHHANG kh = DAL.DULIEUKH.C_DuLieuKhachHang.finByDanhBo(sodanhbo);
            if (chuyendm != null)
            {
                string mess = "Danh Bộ Đã Nâng ĐHN Ngày " + Utilities.DateToString.NgayVNVN(chuyendm.NGAYLAP.Value) + ", Có Muốn Tiếp Tục ?";
                if (MessageBox.Show(this, mess, "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    chuyendm = new TB_DHNAMSAU();
                    chuyendm.TODS = DAL.SYS.C_USERS._toDocSo;
                    chuyendm.DANHBO = sodanhbo;
                    chuyendm.LOTRINH = kh.LOTRINH;
                    chuyendm.HOTEN = kh.HOTEN;
                    chuyendm.DIACHI = kh.SONHA + " " + kh.TENDUONG;
                    chuyendm.HOPDONG = kh.HOPDONG;
                    chuyendm.HIEU = kh.HIEUDH;
                    chuyendm.CO = kh.CODH;
                    chuyendm.GHICHU = this.txtKetQuaThucHien.Text;
                    chuyendm.NGAYLAP = DateTime.Now.Date;
                    chuyendm.CREATEDATE = DateTime.Now;
                    chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;

                    DAL.QLDHN.C_DhnAmSau.Insert(chuyendm);
                }
            }
            else
            {
                chuyendm = new TB_DHNAMSAU();
                chuyendm.TODS = DAL.SYS.C_USERS._toDocSo;
                chuyendm.DANHBO = sodanhbo;
                chuyendm.LOTRINH = kh.LOTRINH;
                chuyendm.HOTEN = kh.HOTEN;
                chuyendm.DIACHI = kh.SONHA + " " + kh.TENDUONG;
                chuyendm.HOPDONG = kh.HOPDONG;
                chuyendm.HIEU = kh.HIEUDH;
                chuyendm.CO = kh.CODH;
                chuyendm.GHICHU = this.txtKetQuaThucHien.Text;
                chuyendm.NGAYLAP = DateTime.Now.Date;
                chuyendm.CREATEDATE = DateTime.Now;
                chuyendm.CREATEBY = DAL.SYS.C_USERS._userName;

                DAL.QLDHN.C_DhnAmSau.Insert(chuyendm);
            }
            // DAL.DULIEUKH.C_DuLieuKhachHang.UpdateBaoThay(this.txtSoDanhBo.Text.Replace("-", ""), "True");
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            //if (thaydhn != null)
            //{
            //    thaydhn.XLT_XULY = true;
            //    if (txtBoPhanChuyen.Text.Equals("ĐỘI TCTB"))
            //    {
            //        Add();
            //        thaydhn.XLT_XULY = true;
            //        thaydhn.XLT_CHUYENXL = "TCTB";
            //        thaydhn.XLT_NGAYCHUYEN = DateTime.Now.Date;
            //        if (this.baothaylai.Checked == true)
            //        {
            //            DAL.LinQConnection.ExecuteCommand(" UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='" + thaydhn.DHN_DANHBO + "'");
            //        }
            //        DAL.QLDHN.C_BaoThay.Update();
            //    }
            //    else
            //    {
            //        if ("".Equals(this.txtKetQuaThucHien.Text) == false)
            //        {
            //            thaydhn.XLT_TRAKQ = true;
            //            thaydhn.XLT_KETQUA = txtKetQuaThucHien.Text;
            //            thaydhn.XLT_NGAYCAPNHAT = DateTime.Now.Date;
            //            if (this.baothaylai.Checked == true)
            //            {
            //                DAL.LinQConnection.ExecuteCommand(" UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='" + thaydhn.DHN_DANHBO + "'");
            //            }
            //            DAL.QLDHN.C_BaoThay.Update();
            //        }
            //    }
            //}
            if (thaydhn != null)
                try
                {
                    if (txtBoPhanChuyen.Text.Equals("ĐỘI TCTB"))
                        thaydhn.XLT_CHUYENXL = "TCTB";
                    else
                        if (txtBoPhanChuyen.Text.Equals("BAN KTKS"))
                        {
                            thaydhn.XLT_CHUYENXL = "KTKS";
                            dutchi = new TB_TLKDUTCHI();
                            ///lấy tên tổ đọc số từ lộ trình
                            if (int.Parse(kh.LOTRINH.Substring(2, 2)) >= 1 && int.Parse(kh.LOTRINH.Substring(2, 2)) <= 15)
                                dutchi.TODS = "TB01";
                            else
                                if (int.Parse(kh.LOTRINH.Substring(2, 2)) >= 16 && int.Parse(kh.LOTRINH.Substring(2, 2)) <= 30)
                                    dutchi.TODS = "TB02";
                                else
                                    if (int.Parse(kh.LOTRINH.Substring(2, 2)) >= 31 && int.Parse(kh.LOTRINH.Substring(2, 2)) <= 46)
                                        dutchi.TODS = "TP";
                            dutchi.DANHBO = kh.DANHBO;
                            dutchi.LOTRINH = kh.LOTRINH;
                            dutchi.HOTEN = kh.HOTEN;
                            dutchi.DIACHI = kh.SONHA + " " + kh.TENDUONG;
                            dutchi.HOPDONG = kh.HOPDONG;
                            dutchi.GB = kh.GIABIEU;
                            dutchi.DM = kh.DINHMUC;
                            dutchi.HIEU = kh.HIEUDH;
                            dutchi.SOTHAN = kh.SOTHANDH;
                            dutchi.NGAYBAO = thaydhn.DHN_NGAYBAOTHAY;
                            dutchi.CREATEDATE = DateTime.Now.Date;
                            dutchi.CREATEBY = DAL.SYS.C_USERS._userName;
                            dutchi.TYPE = 0;
                            dutchi.SONAM = kh.NAM;
                            db.TB_TLKDUTCHIs.InsertOnSubmit(dutchi);
                        }

                    if (!"".Equals(this.txtKetQuaThucHien.Text.Trim()) && thaydhn.XLT_KETQUA != this.txtKetQuaThucHien.Text.Trim())
                        {
                            thaydhn.XLT_TRAKQ = true;
                            thaydhn.XLT_KETQUA = txtKetQuaThucHien.Text;
                            thaydhn.XLT_NGAYCAPNHAT = DateTime.Now.Date;
                        }
      
                    
                    thaydhn.XLT_XULY = true;
                    thaydhn.XLT_NGAYCHUYEN = DateTime.Now.Date;

                    if (this.baothaylai.Checked == true)
                        DAL.LinQConnection.ExecuteCommand(" UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='" + thaydhn.DHN_DANHBO + "'");

                    DAL.QLDHN.C_BaoThay.Update();

                    ///Ghi nhận thay đổi vào TB_GhiChu
                    ghichu = new TB_GHICHU();
                    ghichu.DANHBO = thaydhn.DHN_DANHBO;
                    ghichu.NOIDUNG = txtKetQuaThucHien.Text.Trim();
                    ghichu.DONVI = DAL.SYS.C_USERS._maphong;
                    ghichu.CREATEDATE = DateTime.Now.Date;
                    ghichu.CREATEBY = DAL.SYS.C_USERS._userName;
                    db.TB_GHICHUs.InsertOnSubmit(ghichu);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}