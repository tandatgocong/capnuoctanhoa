using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

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
            string sql = "SELECT hd.ID,DHN_SOBANGKE,KTKS_SODON,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) AS DHN_NGAYGHINHAN,DHN_DANHBO,LOTRINH,SOTHANDH,CODH,HIEUDH,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_KY,DHN_DOT,DHN_NAM,";
            sql += "DHN_CAMKET,DHN_BAMHI,DHN_HUYCAMKET,DHN_GHICHU,DHN_TODS,KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI,KTKS_NGAYBAMCHI,KTKS_MAKIEMBC,KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,KTKS_TH_NGAY,KTKS_NHANVIEN,KTKS_GHICHU,KTKS_DONGTIEN";
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
            string sql = "SELECT hd.ID,DHN_SOBANGKE,KTKS_SODON,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) AS DHN_NGAYGHINHAN,DHN_DANHBO,LOTRINH,SOTHANDH,CODH,HIEUDH,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_KY,DHN_DOT,DHN_NAM,";
            sql += "DHN_CAMKET,DHN_BAMHI,DHN_HUYCAMKET,DHN_GHICHU,DHN_TODS,KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI,KTKS_NGAYBAMCHI,KTKS_MAKIEMBC,KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,KTKS_TH_NGAY,KTKS_NHANVIEN,KTKS_GHICHU,KTKS_DONGTIEN";
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
            string sql = "SELECT hd.ID,DHN_SOBANGKE,KTKS_SODON,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) AS DHN_NGAYGHINHAN,DHN_DANHBO,LOTRINH,SOTHANDH,CODH,HIEUDH,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_KY,DHN_DOT,DHN_NAM,";
            sql += "DHN_CAMKET,DHN_BAMHI,DHN_HUYCAMKET,DHN_GHICHU,DHN_TODS,KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI,KTKS_NGAYBAMCHI,KTKS_MAKIEMBC,KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,KTKS_TH_NGAY,KTKS_NHANVIEN,KTKS_GHICHU,KTKS_DONGTIEN";
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
        public static bool checkByDanhBo(string danhbo)
        {
            return db.DK_GIAMHOADONs.Any(item => item.DHN_DANHBO == danhbo);
        }

        /// <summary>
        /// Kiểm tra số đơn có trong bảng DK_GIAMHOADON
        /// </summary>
        /// <param name="sodon"></param>
        /// <param name="danhbo"></param>
        /// <returns></returns>
        public static bool checkBySoDon(int sodon,string danhbo)
        {
            return db.DK_GIAMHOADONs.Any(item => item.KTKS_SODON == sodon && item.DHN_DANHBO != danhbo);
        }

        /// <summary>
        /// Kiểm tra thông tin khách hàng trong bảng TB_DULIEUKHACHHANG
        /// </summary>
        /// <param name="danhbo"></param>
        /// <returns></returns>
        public static bool checkKHByDanhBo(string danhbo)
        {
            return db.TB_DULIEUKHACHHANGs.Any(item => item.DANHBO == danhbo);
        }

        /// <summary>
        /// Lấy Số Đơn lớn nhất
        /// </summary>
        /// <returns></returns>
        public static int getMaxSoDon()
        {
            return Convert.ToInt32(db.DK_GIAMHOADONs.Max(item=>item.KTKS_SODON));
        }

        /// <summary>
        /// Lấy Danh sách đồng hồ thu hồi
        /// </summary>
        /// <param name="tungay">Từ Ngày</param>
        /// <param name="denngay">Đến Ngày</param>
        /// <returns></returns>
        public static DataTable getDSThuHoi(string tungay, string denngay)
        {
            string sql = "SELECT DHN_DANHBO,HOPDONG,HOTEN,SONHA + ' ' +TENDUONG AS 'DIACHI',";
            sql += "KTKS_TH_HIEU,KTKS_TH_CO,KTKS_TH_SOTHAN,KTKS_TH_CHISO,KTKS_TH_MAKIEM,CONVERT(VARCHAR(10), KTKS_TH_NGAY, 103) KTKS_TH_NGAY";
            sql += " FROM DK_GIAMHOADON hd,TB_DULIEUKHACHHANG kh WHERE KTKS_BAMHI='thuhoi' AND KTKS_TH_NGAY BETWEEN '" + tungay + "' AND '" + denngay + "' AND kh.DANHBO=hd.DHN_DANHBO ORDER BY convert(datetime, KTKS_TH_NGAY, 103) ASC";
            return LinQConnection.getDataTable(sql);
        }

        /// <summary>
        /// Lấy Lịch sử hóa đơn bằng 0
        /// </summary>
        /// <returns></returns>
        public static DataTable getLichSuHoaDon0(string sodanhbo)
        {
            string sql = "SELECT DHN_SOBANGKE,CONVERT(VARCHAR(10), DHN_NGAYGHINHAN, 103) DHN_NGAYGHINHAN,DHN_BAMHI,DHN_CAMKET,DHN_HUYCAMKET,CONVERT(VARCHAR(10), KTKS_NGAYTIEPXUC, 103) KTKS_NGAYTIEPXUC,KTKS_CAMKET,KTKS_BAMHI,KTKS_DONGTIEN";
            sql += " FROM DK_GIAMHOADON WHERE DHN_DANHBO='" + sodanhbo + "' ORDER BY DHN_SOBANGKE ASC";
            return LinQConnection.getDataTable(sql);
        }

        /// <summary>
        /// Load Tiêu Thụ
        /// </summary>
        /// <param name="danhba"></param>
        /// <param name="nam"></param>
        /// <param name="ky"></param>
        /// <returns></returns>
        public static DataSet getListHoaDonReport(string danhba, int nam, int ky)
        {
            DocSoDataContext db = new DocSoDataContext();
            DataSet ds = new DataSet();

            string query = "SELECT  TOP(1)  " +
                  " ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+ '/" + nam + "') as NAM, H.CODE, H.CSCU, H.CSMOI, H.TIEUTHU AS 'LNCC' , CONVERT(NCHAR(10), H.DENNGAYDOCSO, 103) AS DENNGAY  FROM DS" + nam + " AS H LEFT OUTER JOIN" +
                " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.KY DESC, NAM DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TIEUTHU");

            query = "SELECT  TOP(9) " +
                "( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+ '/" + nam + "') as NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON FROM HD" + nam + " AS H LEFT OUTER JOIN" +
              " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";
            DataTable TB_HD = DAL.LinQConnectionDS.getDataTable(query);
            ds.Tables["TIEUTHU"].Merge(TB_HD);

            int scl = 10 - ds.Tables["TIEUTHU"].Rows.Count;
            if (scl > 0)
            {
                nam = nam - 1;
                query = "SELECT  TOP(" + scl + ")   " +
          " ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+ '/" + nam + "') as NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON FROM HD" + nam + " AS H LEFT OUTER JOIN" +
        " KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";

                DataTable b_Old = DAL.LinQConnectionDS.getDataTable(query);
                ds.Tables["TIEUTHU"].Merge(b_Old);
            }
            //    scl = 4 - ds.Tables["TIEUTHU"].Rows.Count;
            //    if (scl > 0)
            //    {
            //        nam = nam - 1;
            //        query = "SELECT  TOP(" + scl + ")   " +
            //  " ( CASE WHEN H.KY<10 THEN '0'+ CONVERT(VARCHAR(20),H.KY) ELSE CONVERT(VARCHAR(20),H.KY) END+ '/" + nam + "') as NAM, H.CODE, H.CSCU, H.CSMOI,H.LNCC , CONVERT(NCHAR(10), H.DENNGAY, 103) AS DENNGAY, H.SOHOADON FROM HD" + nam + " AS H LEFT OUTER JOIN" +
            //" KHACHHANG AS KH ON H.DANHBA = KH.DANHBA WHERE KH.DANHBA ='" + danhba + "' ORDER BY H.DENNGAY DESC ";

            //        DataTable b_Old = DAL.LinQConnectionDS.getDataTable(query);
            //        ds.Tables["TIEUTHU"].Merge(b_Old);
            //    }
            return ds;
        }
    }
}
