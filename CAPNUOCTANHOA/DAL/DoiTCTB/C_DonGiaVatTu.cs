using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.DoiTCTB
{
    class C_DonGiaVatTu
    {
        public static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
       
        public static TB_VATUTHAY_DONGIA_H finbyDonGiaVT(int stt, string mahieudg)
        {
            var query = from dg in db.TB_VATUTHAY_DONGIA_Hs where dg.STT == stt && dg.MAVT == mahieudg select dg;
            return query.SingleOrDefault();
        }
        public static TB_VATUTHAY_DONGIA_H finbyDonGiaVTbyMahieu(string mahieudg)
        {
            var query = from dg in db.TB_VATUTHAY_DONGIA_Hs where dg.CHON == true && dg.MAVT == mahieudg select dg;
            return query.SingleOrDefault();
        }
        public static void UpdateDGVT(TB_VATUTHAY_DONGIA_H dgvt)
        {
            db.SubmitChanges();
        }
        public static void InsertDGVT(TB_VATUTHAY_DONGIA_H dgvt)
        {
            db.TB_VATUTHAY_DONGIA_Hs.InsertOnSubmit(dgvt);
            db.SubmitChanges();
        }
        public static TB_VATUTHAY_DONGIA_H getDonGia(string mahieudg)
        {
            var query = from dg in db.TB_VATUTHAY_DONGIA_Hs where dg.CHON == true && dg.MAVT == mahieudg select dg;
            return query.SingleOrDefault();
        }
        public static DataTable getDonGiaBoVT(string mahieudg)
        {
            string sql = "select SUM(DGVATLIEU*DM),SUM(DGNHANCONG*DM),SUM(DGMAYTHICONG*DM) ";
            sql += " FROM DANHMUCVATTU dmvt,DONGIAVATTU dg,DANHMUCBOVATTU bovt  ";
            sql += " WHERE dmvt.MAHIEU= bovt.MAHIEU AND dmvt.MAHIEU=dg.MAHIEUDG AND dg.CHON='True' AND bovt.MABOVT='" + mahieudg + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
            return table;
        }


        public static TB_VATUTHAY_DONGIA finbyDonGiaVT( string mahieudg)
        {
            var query = from dg in db.TB_VATUTHAY_DONGIAs where  dg.MAVT == mahieudg select dg;
            return query.SingleOrDefault();
        }
       
        public static void UpdateDGVT()
        {
            db.SubmitChanges();
        }


    }
}
