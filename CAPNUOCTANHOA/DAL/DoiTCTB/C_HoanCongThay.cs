using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.DoiTCTB
{
    public static class C_HoanCongThay
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_HoanCongThay).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        
        public static DataTable getBangKeBaoThay(string sobangke)
        {
            string sql = "SELECT ID_BAOTHAY,DHN_LOAIBANGKE,DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_NGAYBAOTHAY,DHN_NGAYGAN,DHN_CHITHAN,DHN_CHIGOC,DHN_HIEUDHN,DHN_CODH,DHN_SOTHAN,DHN_CHISO,DHN_LYDOTHAY ";
            sql += " ,HCT_CAP , HCT_CHISOGO, HCT_SOTHANGO, HCT_HIEUDHNGAN, HCT_CODHNGAN, HCT_SOTHANGAN, HCT_CHISOGAN, HCT_LOAIDHGAN, HCT_NGAYGAN, HCT_CHITHAN, HCT_CHIGOC, HCT_TRONGAI, HCT_LYDOTRONGAI,HCT_NGAYKIEMDINH  ";
            sql += " FROM TB_THAYDHN thay,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=thay.DHN_DANHBO AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + sobangke + "' ORDER BY kh.LOTRINH ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getBangKeBaoThayDMA(string sobangke)
        {
            string sql = "SELECT ID_BAOTHAY,DHN_LOAIBANGKE,DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_NGAYBAOTHAY,DHN_NGAYGAN,DHN_CHITHAN,DHN_CHIGOC,DHN_HIEUDHN,DHN_CODH,DHN_SOTHAN,DHN_CHISO,DHN_LYDOTHAY ";
            sql += " ,HCT_CAP , HCT_CHISOGO, HCT_SOTHANGO, HCT_HIEUDHNGAN, HCT_CODHNGAN, HCT_SOTHANGAN, HCT_CHISOGAN, HCT_LOAIDHGAN, HCT_NGAYGAN, HCT_CHITHAN, HCT_CHIGOC, HCT_TRONGAI, HCT_LYDOTRONGAI,HCT_NGAYKIEMDINH  ";
            sql += " FROM TB_THAYDHN thay,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=thay.DHN_DANHBO AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + sobangke + "' ORDER BY thay.DHN_STT ASC ";
            return LinQConnection.getDataTable(sql);
        }
       
        public static DataSet ReportHoanCongThay(string sobangke)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "select *, N'" + DAL.SYS.C_USERS._fullName + "' as 'TENDANGNHAP' FROM V_DHN_BANGKE where (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + sobangke + "' ORDER BY TENBANGKE ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "V_DHN_BANGKE");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");

            return ds;
        }

        public static DataTable getVatTuThay(string codh)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY STT  DESC) [STT] ,MAVT,TENVT,DVT, SL='0', GHICHU='' ";
            sql += " FROM TB_VATUTHAY WHERE CREATEBY='"+codh+"' ORDER BY STT ASC ";
            return LinQConnection.getDataTable(sql);

        }
        public static void InsertVatTuThay(TB_VATUTHAY_DHN vtthay) {
            try
            {
                db.TB_VATUTHAY_DHNs.InsertOnSubmit(vtthay);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static DataTable getVatTuThay_DATHAY(int id_baothay)
        {
            string sql = "SELECT STT,MAVT,TENVT,DVT, SOLUONG as'SL',GHICHU";
            sql += " FROM TB_VATUTHAY_DHN WHERE ID_BAOTHAY='"+id_baothay+"' ORDER BY STT ASC ";
            return LinQConnection.getDataTable(sql);

        }

        public static DataSet ReportThongKeVT(string sobangke, DateTime tungay, DateTime denngay) {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "select *, N'" + DAL.SYS.C_USERS._fullName + "' as 'TENDANGNHAP' FROM V_DHN_BANGKE where DHN_SOBANGKE='" + sobangke + "' AND DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "' ORDER BY DHN_STT ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "V_DHN_BANGKE");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");

            return ds;        
        }

        public static DataSet ReportBaoThay(string sobangke)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "select TENBANGKE, HOPDONG, HOTEN, SONHA, TENDUONG, ID_BAOTHAY, DHN_LANTHAY, DHN_LOAIBANGKE, DHN_SOBANGKE, DHN_STT, DHN_DANHBO, DHN_NGAYBAOTHAY, DHN_DOT, DHN_TODS, DHN_NGAYGAN, DHN_CHITHAN, DHN_CHIGOC, DHN_HIEUDHN, DHN_CODH, DHN_CAP, DHN_SOTHAN, DHN_CHISO, DHN_LYDOTHAY, DHN_GHICHU, DHN_NGAYCHUYEN, DHN_CREATEDATE, DHN_CREATEBY, DHN_MODIFYDATE, DHN_MODIFYBY, HCT_CHISOGO, HCT_SOTHANGO, HCT_HIEUDHNGAN, HCT_CODHNGAN, HCT_CAP, HCT_SOTHANGAN, HCT_CHISOGAN, HCT_LOAIDHGAN, HCT_NGAYGAN, HCT_NGAYKIEMDINH, HCT_CHITHAN, HCT_CHIGOC, HCT_TRONGAI, HCT_LYDOTRONGAI, HCT_CREATEDATE, HCT_CREATEBY, HCT_MODIFYDATE, LOTRINH AS 'HCT_MODIFYBY' , N'" + DAL.SYS.C_USERS._fullName + "' as 'TENDANGNHAP' FROM V_DHN_BANGKE where (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + sobangke + "' ORDER BY TENBANGKE ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "V_DHN_BANGKE");

            query = "select * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");

            return ds;
        }

        public static DataSet HoanCongNhanh(string ngay)
        {
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string query = "select *, N'" + DAL.SYS.C_USERS._fullName + "' as 'NGUOIDUYET' FROM V_TCTB_HOANCONGNHANH WHERE  HCT_NGAYGAN=CONVERT(DATETIME,'" + ngay+ "',103) ORDER BY TENBK ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "V_TCTB_HOANCONGNHANH");

            return ds;
        }
    }
}
