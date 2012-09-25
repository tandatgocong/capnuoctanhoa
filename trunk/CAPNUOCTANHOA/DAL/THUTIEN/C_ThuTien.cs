using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using CAPNUOCTANHOA.DAL.QLDHN;
using System.Data;

namespace CAPNUOCTANHOA.DAL.THUTIEN
{
    public static class C_ThuTien
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_ThuTien).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        public static bool Insert(TB_DONGNUOC th_dhn)
        {
            try
            {
                db.TB_DONGNUOCs.InsertOnSubmit(th_dhn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
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

        public static bool delete(TB_DONGNUOC dongnuoc)
        {
            try
            {
                db.TB_DONGNUOCs.DeleteOnSubmit(dongnuoc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        public static DataTable getDongNuocByDate(string month)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY ID  DESC) [STT],ID, DANHBO, HOTEN, SONHA, TENDUONG, NGAYDONGNUOC, NGAYMONUOC, NOIDUNG, HOPDONG,QUAN,PHUONG ";
            sql += " FROM  TB_DONGNUOC WHERE MONTH(NGAYDONGNUOC)='"+month+"'  ORDER BY ID DESC";
            return LinQConnection.getDataTable(sql);
        }


        public static TB_DONGNUOC finByDanhBo(string danhbo)
        {
            try
            {
                db = new CapNuocTanHoaDataContext();
                var query = from q in db.TB_DONGNUOCs where q.DANHBO == danhbo && q.NGAYDONGNUOC.Value.Year== DateTime.Now.Year orderby q.ID descending select q;
                return (TB_DONGNUOC)query.ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static string noidung(string danhbo) {

            string result = "Nợ hóa đơn kỳ ";
            HoaDonDataContext hd = new HoaDonDataContext();
            var query = from q in hd.HDs where q.DBo == danhbo orderby q.KyHD ascending, q.NamHD descending select q;
            foreach (var item in query.ToList())
            {
                HD hd_ = (HD)item;
                result += " " + hd_.KyHD + "/" + hd_.NamHD + ": " + String.Format("{0:0,0}", hd_.TNuoc).Replace(",",".") + " ; ";
            }
            return result;
        
        }
        //public static DataTable getBangKeBaoThay(string sobangke)
        //{
        //    string sql = "SELECT ID_BAOTHAY,DHN_LOAIBANGKE,DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_NGAYBAOTHAY,DHN_NGAYGAN,DHN_CHITHAN,DHN_CHIGOC,DHN_HIEUDHN,DHN_CODH,DHN_SOTHAN,DHN_CHISO,DHN_LYDOTHAY ";
        //    sql += " FROM TB_THAYDHN thay,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=thay.DHN_DANHBO AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + sobangke + "' ORDER BY DHN_DANHBO ASC ";
        //    return LinQConnection.getDataTable(sql);
        //}


        //public static int getMaxBangKe()
        //{
        //    string sql = "SELECT MAX(DHN_SOBANGKE)  FROM TB_THAYDHN where DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "'";
        //    return LinQConnection.ExecuteCommand(sql);
        //}
        //public static int getMaxLanThay(string danhbo)
        //{
        //    string sql = "SELECT MAX(DHN_LANTHAY) FROM TB_THAYDHN WHERE DHN_DANHBO='" + danhbo + "' AND DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "'";
        //    return LinQConnection.ExecuteCommand(sql);
        //}

        //public static DataTable getLoaiBangKe()
        //{
        //    string sql = "SELECT LOAIBK,TENBANGKE";
        //    sql += " FROM TB_LOAIBANGKE";
        //    return LinQConnection.getDataTable(sql);
        //}

        //public static DataTable HistoryThay(string danhbo)
        //{
        //    string sql = "SELECT DHN_LANTHAY,DHN_LYDOTHAY AS 'TENBANGKE',DHN_SOBANGKE,DHN_NGAYBAOTHAY,HCT_NGAYGAN,HCT_TRONGAI";
        //    sql += " FROM  TB_THAYDHN thay WHERE DHN_DANHBO='" + danhbo + "' ORDER BY DHN_LANTHAY ASC  ";
        //    return LinQConnection.getDataTable(sql);
        //}

        
        //public static TB_THAYDHN finByID_BAOTHAY(int id)
        //{
        //    try
        //    {
        //        db = new CapNuocTanHoaDataContext();
        //        var query = from q in db.TB_THAYDHNs where q.ID_BAOTHAY == id select q;
        //        return query.SingleOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return null;
        //}

        //public static bool deleteBAOTHAY(TB_THAYDHN THAY)
        //{
        //    try
        //    {
        //        db.TB_THAYDHNs.DeleteOnSubmit(THAY);
        //        db.SubmitChanges();
        //        LinQConnection.ExecuteCommand("UPDATE TB_DULIEUKHACHHANG SET BAOTHAY='False' WHERE DANHBO='" + THAY.DHN_DANHBO + "'");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return false;
        //}

        //public static bool Update()
        //{
        //    try
        //    {
        //        db.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return false;
        //}

        //public static TB_HIEUDONGHO finByHieuDH(string mahieu)
        //{
        //    try
        //    {
        //        var query = from q in db.TB_HIEUDONGHOs where q.HIEUDH == mahieu select q;
        //        return query.SingleOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return null;
        //}

        //public static DataSet ReportBaoThay(string sobangke)
        //{
        //    DataSet ds = new DataSet();
        //    CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        //    db.Connection.Open();
        //    string query = "select *, N'" + DAL.SYS.C_USERS._fullName + "' as 'TENDANGNHAP' FROM V_DHN_BANGKE where DHN_SOBANGKE='" + sobangke + "' AND DHN_TODS='" + DAL.SYS.C_USERS._toDocSo + "' ORDER BY DHN_DANHBO ASC ";

        //    SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
        //    adapter.Fill(ds, "V_DHN_BANGKE");

        //    query = "select * FROM TB_DHN_BAOCAO";
        //    adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
        //    adapter.Fill(ds, "TB_DHN_BAOCAO");

        //    return ds;
        //}
        //public static TB_THA YDHN finByBaoThay(int sobangke, string danhbo)
        //{
        //    try
        //    {
        //        db = new CapNuocTanHoaDataContext();
        //        var query = from q in db.TB_THAYDHNs where q.DHN_SOBANGKE == sobangke && q.DHN_DANHBO == danhbo && q.DHN_TODS == DAL.SYS.C_USERS._toDocSo && q.DHN_LOAIBANGKE == "DK" orderby q.DHN_SOBANGKE descending select q;
        //        List<TB_THAYDHN> th = query.ToList();
        //        if (th.Count >= 1)
        //            return th[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return null;
        //}
        //public static TB_DHN_BAOCAO getBaoCao()
        //{
        //    try
        //    {
        //        var query = from q in db.TB_DHN_BAOCAOs where q.ID_BC == 1 select q;
        //        return query.SingleOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return null;
        //}
    }
}
