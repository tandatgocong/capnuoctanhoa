using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.BANKTKS
{
    public static class C_GiamHoaDon
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BANKTKS).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        /// <summary>
        /// Lấy danh sách theo số bảng kê
        /// </summary>
        /// <param name="sobangke"></param>
        /// <returns></returns>
        public static DataTable getBangKeBySoBangKe(string sobangke)
        {
            string sql = "SELECT hd.ID,DHN_DANHBO,DHN_SOBANGKE,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) AS DHN_NGAYGHINHAN,LOTRINH,SOTHANDH,CODH,HIEUDH,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_KY,DHN_DOT,DHN_NAM,";
            sql += "DHN_BAMHI,DHN_CAMKET,DHN_HUYCAMKET,DHN_GHICHU,DHN_TODS,KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI,KTKS_NGAYBAMCHI,KTKS_MAKIEMBC,KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,KTKS_TH_NGAY,KTKS_NHANVIEN,KTKS_GHICHU";
            sql += " FROM DK_GIAMHOADON hd,TB_DULIEUKHACHHANG kh WHERE DHN_SOBANGKE='" + sobangke + "' AND kh.DANHBO=hd.DHN_DANHBO ORDER BY DHN_DANHBO ASC";
            return LinQConnection.getDataTable(sql);
        }

        /// <summary>
        /// Lấy danh sách theo số danh bộ
        /// </summary>
        /// <param name="sodanhbo"></param>
        /// <returns></returns>
        public static DataTable getBangKeBySoDanhBo(string sodanhbo)
        {
            string sql = "SELECT hd.ID,DHN_DANHBO,DHN_SOBANGKE,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) AS DHN_NGAYGHINHAN,LOTRINH,SOTHANDH,CODH,HIEUDH,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_KY,DHN_DOT,DHN_NAM,";
            sql += "DHN_BAMHI,DHN_CAMKET,DHN_HUYCAMKET,DHN_GHICHU,DHN_TODS,KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI,KTKS_NGAYBAMCHI,KTKS_MAKIEMBC,KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,KTKS_TH_NGAY,KTKS_NHANVIEN,KTKS_GHICHU";
            sql += " FROM DK_GIAMHOADON hd,TB_DULIEUKHACHHANG kh WHERE DHN_DANHBO='" + sodanhbo + "' AND kh.DANHBO=hd.DHN_DANHBO ORDER BY DHN_DANHBO ASC";
            return LinQConnection.getDataTable(sql);
        }

        /// <summary>
        /// Lấy danh sách theo ngày yêu cầu
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DataTable getBangKeByNgayYeuCau(DateTime date)
        {
            string sql = "SELECT hd.ID,DHN_DANHBO,DHN_SOBANGKE,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) AS DHN_NGAYGHINHAN,LOTRINH,SOTHANDH,CODH,HIEUDH,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_KY,DHN_DOT,DHN_NAM,";
            sql += "DHN_BAMHI,DHN_CAMKET,DHN_HUYCAMKET,DHN_GHICHU,DHN_TODS,KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI,KTKS_NGAYBAMCHI,KTKS_MAKIEMBC,KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,KTKS_TH_NGAY,KTKS_NHANVIEN,KTKS_GHICHU";
            sql += " FROM DK_GIAMHOADON hd,TB_DULIEUKHACHHANG kh WHERE CONVERT(VARCHAR(10), DHN_CREATEDATE, 103)='" + date.ToString("dd/MM/yyyy") + "' AND kh.DANHBO=hd.DHN_DANHBO ORDER BY DHN_DANHBO ASC";
            return LinQConnection.getDataTable(sql);
        }

        /// <summary>
        /// Lấy thông tin khách hàng theo danh bộ
        /// </summary>
        /// <param name="danhbo"></param>
        /// <returns></returns>
        public static DataTable getThongTinKhachHang(string danhbo)
        {
            string sql = "SELECT DANHBO,LOTRINH,SOTHANDH,CODH,HIEUDH,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI' FROM TB_DULIEUKHACHHANG WHERE DANHBO='" + danhbo + "'";
            return LinQConnection.getDataTable(sql);
        }

        /// <summary>
        /// Thêm 1 danh bộ vào bảng DK_GIAMHOADON
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Insert(DK_GIAMHOADON item)
        {
            try
            {
                db.DK_GIAMHOADONs.InsertOnSubmit(item);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            try
            {
                //DK_GIAMHOADON hdtam = db.DK_GIAMHOADONs.Single(item => item.ID == hd.ID);
                //hdtam.KTKS_CAMKET = hd.KTKS_CAMKET;
                //hdtam.KTKS_GHICHU = hd.KTKS_GHICHU;
                //hdtam.KTKS_NGAYTIEPXUC = hd.KTKS_NGAYTIEPXUC;
                //hdtam.KTKS_BAMHI = hd.KTKS_BAMHI;
                //hdtam.KTKS_MAKIEMBC = hd.KTKS_MAKIEMBC;
                //hdtam.KTKS_NGAYBAMCHI = hd.KTKS_NGAYBAMCHI;
                //hdtam.KTKS_TH_MAKIEM = hd.KTKS_TH_MAKIEM;
                //hdtam.KTKS_TH_HIEU = hd.KTKS_TH_HIEU;
                //hdtam.KTKS_TH_CO = hd.KTKS_TH_CO;
                //hdtam.KTKS_TH_SOTHAN = hd.KTKS_TH_SOTHAN;
                //hdtam.KTKS_TH_CHISO = hd.KTKS_TH_CHISO;
                //hdtam.KTKS_NHANVIEN = hd.KTKS_NHANVIEN;
                //hdtam.KTKS_TH_NGAY = hd.KTKS_TH_NGAY;
                //hdtam.KTKS_MODIFYDATE = hd.KTKS_MODIFYDATE;
                //hdtam.KTKS_MODIFYBY = hd.KTKS_MODIFYBY;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Tìm DK_GIAMHOADON theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>class DK_GIAMHOADON</returns>
        public static DK_GIAMHOADON findByID(int id)
        {
            return db.DK_GIAMHOADONs.Single(item => item.ID == id);
        }

        /// <summary>
        /// Kiểm tra danh bộ có trong bảng DK_GIAMHOADON
        /// </summary>
        /// <param name="danhbo"></param>
        /// <returns>true/false</returns>
        public static bool findByDanhBo(string danhbo)
        {
            return db.DK_GIAMHOADONs.Any(item => item.DHN_DANHBO == danhbo);
        }

        /// <summary>
        /// Lấy Danh sách đồng hồ thu hồi
        /// </summary>
        /// <returns></returns>
        public static DataTable getDSThuHoi()
        {
            string sql = "SELECT DHN_DANHBO,HOPDONG,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',";
            sql += "KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) KTKS_TH_NGAY";
            sql += " FROM DK_GIAMHOADON hd,TB_DULIEUKHACHHANG kh WHERE KTKS_BAMHI='thuhoi' AND kh.DANHBO=hd.DHN_DANHBO ORDER BY DHN_DANHBO ASC";
            return LinQConnection.getDataTable(sql);
        }

        /// <summary>
        /// Lấy Lịch sử hóa đơn bằng 0
        /// </summary>
        /// <returns></returns>
        public static DataTable getLichSuHoaDon0(string sodanhbo)
        {
            string sql = "SELECT DHN_SOBANGKE,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) DHN_NGAYGHINHAN,DHN_BAMHI,DHN_CAMKET,DHN_HUYCAMKET,CONVERT(VARCHAR(10), KTKS_NGAYTIEPXUC, 103) KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI";
            sql += " FROM DK_GIAMHOADON WHERE DHN_DANHBO='" + sodanhbo + "' ORDER BY DHN_SOBANGKE ASC";
            return LinQConnection.getDataTable(sql);
        }
    }
}
