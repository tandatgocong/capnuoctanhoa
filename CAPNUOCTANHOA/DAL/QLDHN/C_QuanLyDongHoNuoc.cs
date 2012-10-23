using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using log4net;
using System.Windows.Forms;
using System.Configuration;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_QuanLyDongHoNuoc
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_QuanLyDongHoNuoc).Name);

        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static string getNhanVienDS(int mayds)
        {

            string tennv = "";
            var query = from q in db.TB_NHANVIENDOCSOs where q.MAYDS == mayds select q;
            TB_NHANVIENDOCSO nv = query.SingleOrDefault();
            if (nv != null)
            {
                return nv.NAME;
            }
            return tennv;
        }
        public static TB_NHANVIENDOCSO findbyMayDS(int mayds) {
            var query = from q in db.TB_NHANVIENDOCSOs where q.MAYDS == mayds select q;
            TB_NHANVIENDOCSO nv = query.SingleOrDefault();
            return nv;
        }

        public static void setNhanVienDS(DataGridView g, string dataColum, string mayds)
        {

            for (int i = 0; i < g.Rows.Count; i++)
            {
                try
                {
                    g.Rows[i].Cells[dataColum].Value = getNhanVienDS(int.Parse(mayds));
                }
                catch (Exception)
                {

                }

            }
        }

        public static DataSet getThongKeDHN(int ky, int nam, string tods)
        {
            string updatedhn = "UPDATE TB_THONGKEDHN    SET CO15 = 0 ,CO20 =0 ,CO25 = 0 ,CO40 = 0 ,CO50 = 0 ,CO80 = 0 ,CO100 =0 ,CO150 = 0 ";
            updatedhn += " ,CO200 = 0 ,NHOCO15 = 0 ,NHOCO20 = 0 ,NHOCO25 = 0 ,NHOCO40 = 0 ,NHOCO50 = 0 ,NHOCO80 = 0 ";
            updatedhn += " ,NHOCO100 = 0 ,NHOCO150 = 0 ,NHOCO200 = 0 ,LONCO15 = 0 ,LONCO20 = 0 ,LONCO25 =0 ,LONCO40 = 0 ";
            updatedhn += " ,LONCO50 = 0 ,LONCO80 = 0 ,LONCO100 = 0 ,LONCO150 = 0 ,LONCO200 =0";
            DAL.LinQConnection.ExecuteCommand_(updatedhn);

            if ("TB01".Equals(tods))
            {
                LinQConnection.ExecuteStoredProcedure("THONGKEDHN_TB01", ky, nam);
            }
            else if ("TB02".Equals(tods))
            {
                LinQConnection.ExecuteStoredProcedure("THONGKEDHN_TB02", ky, nam);
            }
            else if ("TP".Equals(tods))
            {
                LinQConnection.ExecuteStoredProcedure("THONGKEDHN_TP", ky, nam);
            }
            else
            {
                LinQConnection.ExecuteStoredProcedure("THONGKEDHN", ky, nam);
            }
            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open) {
                db.Connection.Close();
            }
            db.Connection.Open();
            string query = "SELECT * FROM TB_THONGKEDHN WHERE HIEUCU='False' ORDER BY STT ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN");


            //query = "SELECT * FROM TB_THONGKEDHN  WHERE HIEUCU='True' ORDER BY STT ASC";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TB_THONGKEDHN_CU");

            query = "SELECT SUM(CO15) AS SUM_CO15, SUM(CO20) AS SUM_CO20, SUM(CO25) AS SUM_CO25, SUM(CO40) AS SUM_CO40, SUM(CO50) AS SUM_CO50, SUM(CO80) AS SUM_CO80, SUM(CO100) AS SUM_CO100, SUM(CO150) AS SUM_CO150, SUM(CO200) AS SUM_CO200, SUM(NHOCO15) AS SUM_NHOCO15, SUM(NHOCO20) AS SUM_NHOCO20, SUM(NHOCO25) AS SUM_NHOCO25, SUM(NHOCO40) AS SUM_NHOCO40, SUM(NHOCO50) AS SUM_NHOCO50, SUM(NHOCO80) AS SUM_NHOCO80, SUM(NHOCO100) AS SUM_NHOCO100, SUM(NHOCO150) AS SUM_NHOCO150, SUM(NHOCO200) AS SUM_NHOCO200, SUM(LONCO15) AS SUM_LONCO15, SUM(LONCO20) AS SUM_LONCO20, SUM(LONCO25) AS SUM_LONCO25, SUM(LONCO40) AS SUM_LONCO40, SUM(LONCO50) AS SUM_LONCO50, SUM(LONCO80) AS SUM_LONCO80, SUM(LONCO100) AS SUM_LONCO100, SUM(LONCO150) AS SUM_LONCO150, SUM(LONCO200) AS SUM_LONCO200 FROM TB_THONGKEDHN";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN_SUM");

            query = "SELECT * FROM TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");

            return ds;
        }
        static string khoi = ConfigurationManager.AppSettings["khoi"].ToString();
        public static void CAPNHAT_BIENDOCCHISO(string nam, int ky, int dot)
        {
            string sql = " UPDATE TB_NHANVIENDOCSO ";
            if (dot == 0)
            {
                sql += " SET SOLUONGDHN=t2.SOLUONG,SANLUONG=t2.SANLUONG,KHONGGHI=t2.KOGHI,TANG=t2.TANG,GIAM=t2.GAM ,NHAXD=t2.XAYDUNG";
                sql += " FROM	TB_NHANVIENDOCSO INNER JOIN  ";
                sql += " (  ";
                sql += " SELECT t.MAY, COUNT(t.DANHBA) AS SOLUONG,(case when SUM(t.TIEUTHU) IS NULL then 0 else SUM(CASE WHEN t.TIEUTHU<0 THEN 0 ELSE t.TIEUTHU END) end) AS SANLUONG,";
                sql += "  COUNT(case when (t.CODE LIKE 'F%' OR t.CODE='61' OR t.CODE='64'  OR t.CODE='66')  then 1 else null end) AS KOGHI,";
                sql += "   COUNT(case when (t.GHICHUMOI LIKE N'%Xây dựng%') then 1 else null end )AS XAYDUNG,";
                sql += " COUNT(case when (t.TIEUTHU >= (t.TBTHU * 1.51)) AND t.CODE='4' then 1 else null end) AS TANG,";
                sql += " COUNT(case when (t.TIEUTHU <= (t.TBTHU * 0.51)) AND t.CODE='4' then 1 else null end) AS GAM";
                sql += " FROM DocSo_PHT.dbo.DS" + nam + "  t ";
                sql += " LEFT JOIN ( ";
                sql += " SELECT DANHBA,TIEUTHU FROM DocSo_PHT.dbo.DS" + nam + " WHERE KY=" + (ky - 1) + "  ) as t3";
                sql += " ON t.DANHBA=t3.DANHBA";
                sql += " WHERE  KY=" + ky;
                sql += " GROUP BY  MAY ";
                sql += " ) as t2 ";
                sql += " ON TB_NHANVIENDOCSO.MAYDS = t2.MAY";
            }
            else
            {
                sql += " SET SOLUONGDHN=t2.SOLUONG,SANLUONG=t2.SANLUONG,KHONGGHI=t2.KOGHI,TANG=t2.TANG,GIAM=t2.GAM ,NHAXD=t2.XAYDUNG";
                sql += " FROM	TB_NHANVIENDOCSO INNER JOIN  ";
                sql += " (  ";
                sql += " SELECT t.MAY, COUNT(t.DANHBA) AS SOLUONG,(case when SUM(t.TIEUTHU) IS NULL then 0 else SUM(CASE WHEN t.TIEUTHU<0 THEN 0 ELSE t.TIEUTHU END) end) AS SANLUONG,";
                sql += "  COUNT(case when (t.CODE LIKE 'F%' OR t.CODE='61' OR t.CODE='64'  OR t.CODE='66')  then 1 else null end) AS KOGHI,";
                sql += "   COUNT(case when (t.GHICHUMOI LIKE N'%Xây dựng%') then 1 else null end )AS XAYDUNG,";
                sql += " COUNT(case when (t.TIEUTHU >= (t.TBTHU * 1.51)) AND t.CODE='4' then 1 else null end) AS TANG,";
                sql += " COUNT(case when (t.TIEUTHU <= (t.TBTHU * 0.51)) AND t.CODE='4' then 1 else null end) AS GAM";
                sql += " FROM DocSo_PHT.dbo.DS" + nam + "  t ";
                sql += " LEFT JOIN ( ";
                sql += " SELECT DANHBA,TIEUTHU FROM DocSo_PHT.dbo.DS" + nam + " WHERE KY=" + (ky - 1) + " AND DOT=" + dot + " ) as t3";
                sql += " ON t.DANHBA=t3.DANHBA";
                sql += " WHERE  KY=" + ky + " AND DOT =" + dot + "";
                sql += " GROUP BY  MAY ";
                sql += " ) as t2 ";
                sql += " ON TB_NHANVIENDOCSO.MAYDS = t2.MAY";
            }

            //string sql = "UPDATE TB_NHANVIENDOCSO ";
            //sql += " SET SET SOLUONGDHN=t2.SOLUONG,SANLUONG=t2.SANLUONG,KHONGGHI=t2.KOGHI,TANG=t2.TANG,GIAM=t2.GAM ";
            //sql += " FROM	TB_NHANVIENDOCSO INNER JOIN  ";
            //sql += "(";
            //sql += " SELECT MAY, COUNT(DANHBA) AS SOLUONG,(case when SUM(TIEUTHU) IS NULL then 0 else SUM(TIEUTHU) end) AS SANLUONG, ";
            //sql += "  COUNT(case when (CODE LIKE 'F%' OR CODE='61' OR CODE='64'  OR CODE='66')  then 1 else null end) AS KOGHI ";
            //sql += "  COUNT(case when (t.TIEUTHU-t3.TIEUTHU)>100  then 1 else null end) AS TANG,";
            //sql += "  COUNT(case when (t.TIEUTHU-t3.TIEUTHU)<100  then 1 else null end) AS GAM ";
            //sql += " FROM DocSo_PHT.dbo.DS" + nam;
            //if (dot == 0) {
            //    sql += " WHERE  KY=" + ky;
            //}
            //else
            //{
            //    sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            //}
            //sql += " GROUP BY MAY ";
            //sql += " ) as t2 ";
            //sql += " ON TB_NHANVIENDOCSO.MAYDS = t2.MAY";

            try
            {
                DAL.LinQConnection.ExecuteCommand("UPDATE TB_NHANVIENDOCSO SET SOLUONGDHN=0, SANLUONG=0, KHONGGHI=0, NHAXD=0, TANG=0, GIAM=0");
                sql = sql.Replace(@"\t", " ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql);
                log.Info("CAPNHAT_BIENDOCCHISO  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHAT_BIENDOCCHISO " + ex.Message);
            }
        }

        public static DataSet getTheoDoiBienDocChiSo()
        {
            DataSet ds = new DataSet();

            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();
            string query = "SELECT * FROM TB_NHANVIENDOCSO  ORDER BY MAYDS ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_NHANVIENDOCSO");

            query = "select * FROM W_BIENDOCCSTO ";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_TONG");
            //query = "SELECT * FROM TB_THONGKEDHN  WHERE HIEUCU='True' ORDER BY STT ASC";
            //adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            //adapter.Fill(ds, "TB_THONGKEDHN_CU");

            query = "select * FROM CAPNUOCTANHOA.dbo.TB_DHN_BAOCAO";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_DHN_BAOCAO");
            return ds;
        }

        public static void CAPNHAT_BANGCHAMCONG(string nam, int ky, int tods)
        {

            string sql = " UPDATE TB_BANGCHAMCONG SET ";
            sql += " DOT01=t2.SL01, DOT01_DC=t2.DC01, DOT02=t2.SL02, DOT02_DC=t2.DC02, ";
            sql += " DOT03=t2.SL03, DOT03_DC=t2.DC03, DOT04=t2.SL04, DOT04_DC=t2.DC04, ";
            sql += " DOT05=t2.SL05, DOT05_DC=t2.DC05, DOT06=t2.SL06, DOT06_DC=t2.DC06,  ";
            sql += " DOT07=t2.SL07, DOT07_DC=t2.DC07, DOT08=t2.SL08, DOT08_DC=t2.DC08,  ";
            sql += " DOT09=t2.SL09, DOT09_DC=t2.DC09, DOT10=t2.SL10, DOT10_DC=t2.DC10,  ";
            sql += " DOT11=t2.SL11, DOT11_DC=t2.DC11, DOT12=t2.SL12, DOT12_DC=t2.DC12,  ";
            sql += " DOT13=t2.SL13, DOT13_DC=t2.DC13, DOT14=t2.SL14, DOT14_DC=t2.DC14,  ";
            sql += " DOT15=t2.SL15, DOT15_DC=t2.DC15, DOT16=t2.SL16, DOT16_DC=t2.DC16,  ";
            sql += " DOT17=t2.SL17, DOT17_DC=t2.DC17, DOT18=t2.SL18, DOT18_DC=t2.DC18,  ";
            sql += " DOT19=t2.SL19, DOT19_DC=t2.DC19, DOT20=t2.SL20, DOT20_DC=t2.DC20 ";
            sql += " FROM TB_BANGCHAMCONG INNER JOIN   ";
            sql += " (                  ";
            sql += " SELECT t.MAY, ";
            sql += " COUNT(case when (t.DOT=1)  then 1 else null end) AS SL01, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=1)  then 1 else null end) AS DC01, ";
            sql += " COUNT(case when (t.DOT=2)  then 1 else null end) AS SL02, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=2)  then 1 else null end) AS DC02, ";
            sql += " COUNT(case when (t.DOT=3)  then 1 else null end) AS SL03, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=3)  then 1 else null end) AS DC03, ";
            sql += " COUNT(case when (t.DOT=4)  then 1 else null end) AS SL04, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=4)  then 1 else null end) AS DC04, ";
            sql += " COUNT(case when (t.DOT=5)  then 1 else null end) AS SL05, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=5)  then 1 else null end) AS DC05, ";
            sql += " COUNT(case when (t.DOT=6)  then 1 else null end) AS SL06, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=6)  then 1 else null end) AS DC06, ";
            sql += " COUNT(case when (t.DOT=7)  then 1 else null end) AS SL07, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=7)  then 1 else null end) AS DC07, ";
            sql += " COUNT(case when (t.DOT=8)  then 1 else null end) AS SL08, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=8)  then 1 else null end) AS DC08, ";
            sql += " COUNT(case when (t.DOT=9)  then 1 else null end) AS SL09, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=9)  then 1 else null end) AS DC09, ";
            sql += " COUNT(case when (t.DOT=10)  then 1 else null end) AS SL10, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=10)  then 1 else null end) AS DC10, ";
            sql += " COUNT(case when (t.DOT=11)  then 1 else null end) AS SL11, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=11)  then 1 else null end) AS DC11, ";
            sql += " COUNT(case when (t.DOT=12)  then 1 else null end) AS SL12, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=12)  then 1 else null end) AS DC12, ";
            sql += " COUNT(case when (t.DOT=13)  then 1 else null end) AS SL13, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=13)  then 1 else null end) AS DC13, ";
            sql += " COUNT(case when (t.DOT=14)  then 1 else null end) AS SL14, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=14)  then 1 else null end) AS DC14, ";
            sql += " COUNT(case when (t.DOT=15)  then 1 else null end) AS SL15, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=15)  then 1 else null end) AS DC15, ";
            sql += " COUNT(case when (t.DOT=16)  then 1 else null end) AS SL16, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=16)  then 1 else null end) AS DC16, ";
            sql += " COUNT(case when (t.DOT=17)  then 1 else null end) AS SL17, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=17)  then 1 else null end) AS DC17, ";
            sql += " COUNT(case when (t.DOT=18)  then 1 else null end) AS SL18, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=18)  then 1 else null end) AS DC18, ";
            sql += " COUNT(case when (t.DOT=19)  then 1 else null end) AS SL19, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=19)  then 1 else null end) AS DC19, ";
            sql += " COUNT(case when (t.DOT=20)  then 1 else null end) AS SL20, ";
            sql += " COUNT(case when (t.CODE ='F1' AND t.DOT=20)  then 1 else null end) AS DC20 ";
            sql += " FROM DocSo_PHT.dbo.DS"+nam+" t  ";
            sql += " WHERE  KY=" + ky ;
            sql += " GROUP BY  t.MAY  ";
            sql += " ) as t2  ";
            sql += " ON TB_BANGCHAMCONG.MAYDS = t2.MAY ";
            sql += " WHERE TODS="+tods;

            try
            {
                string cmd = "UPDATE TB_BANGCHAMCONG SET  DOT01=0, DOT01_DC=0, DOT02=0, DOT02_DC=0,";
                cmd += " DOT03=0, DOT03_DC=0, DOT04=0, DOT04_DC=0, ";
                cmd += " DOT05=0, DOT05_DC=0, DOT06=0, DOT06_DC=0, ";
                cmd += " DOT07=0, DOT07_DC=0, DOT08=0, DOT08_DC=0, ";
                cmd += " DOT09=0, DOT09_DC=0, DOT10=0, DOT10_DC=0, ";
                cmd += " DOT11=0, DOT11_DC=0, DOT12=0, DOT12_DC=0, ";
                cmd += " DOT13=0, DOT13_DC=0, DOT14=0, DOT14_DC=0, ";
                cmd += " DOT15=0, DOT15_DC=0, DOT16=0, DOT16_DC=0, ";
                cmd += " DOT17=0, DOT17_DC=0, DOT18=0, DOT18_DC=0, ";
                cmd += " DOT19=0, DOT19_DC=0, DOT20=0, DOT20_DC=0, ";
                cmd += " DOT01_TC=0, DOT02_TC=0, DOT03_TC=0, DOT04_TC=0, ";
                cmd += " DOT05_TC=0, DOT06_TC=0, DOT07_TC=0, DOT08_TC=0, ";
                cmd += " DOT09_TC=0, DOT10_TC=0, DOT11_TC=0, DOT12_TC=0, ";
                cmd += " DOT13_TC=0, DOT14_TC=0, DOT15_TC=0, DOT16_TC=0, ";
                cmd += " DOT17_TC=0, DOT18_TC=0, DOT19_TC=0, DOT20_TC=0 ";
                cmd += " WHERE TODS=" + tods;
                DAL.LinQConnection.ExecuteCommand(cmd);
                sql = sql.Replace(@"\t", " ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql);
                log.Info("CAPNHAT_BANGCHAMCONG  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHAT_BANGCHAMCONG " + ex.Message);
            }
        }


        public static DataSet reportChamCong(string nam, int ky, int tods)
        {
            CAPNHAT_BANGCHAMCONG(nam, ky, tods);
            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();
            
            string query = "SELECT * FROM TB_BANGCHAMCONG WHERE TODS='" + tods + "' ORDER BY STT ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_BANGCHAMCONG");

            return ds;
        }

        public static DataSet reportChamCong_1(string nam, int ky, int tods)
        {
            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();
           
            string query = "SELECT * FROM TB_BANGCHAMCONG WHERE TODS='" + tods + "' ORDER BY STT ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_BANGCHAMCONG");

            return ds;
        }
        public static DataTable getTable_CHAMCONG(int tods)
        {

            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();
            
            string query = "SELECT MAYDS,FULLNAME FROM TB_BANGCHAMCONG WHERE TODS='" + tods + "' ORDER BY STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_BANGCHAMCONG");
            return ds.Tables["TB_BANGCHAMCONG"];
        }
        public static DataTable getTable_CHAMCONG()
        {

            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();

            string query = "SELECT MAYDS,FULLNAME FROM TB_BANGCHAMCONG  ORDER BY STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_BANGCHAMCONG");
            return ds.Tables["TB_BANGCHAMCONG"];
        }


        public static DataTable getChamCongNVDS_TANGCUONG(int mayds)
        {

            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();
            string query = "SELECT MAYDS,DOT01_TC, DOT02_TC, DOT03_TC, DOT04_TC, DOT05_TC, DOT06_TC, DOT07_TC, DOT08_TC, DOT09_TC, DOT10_TC, DOT11_TC, DOT12_TC, DOT13_TC, DOT14_TC, DOT15_TC, DOT16_TC, DOT17_TC, DOT18_TC, DOT19_TC, DOT20_TC FROM TB_BANGCHAMCONG WHERE MAYDS='" + mayds + "' ORDER BY STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_BANGCHAMCONG");

            return ds.Tables["TB_BANGCHAMCONG"];
        }

        public static DataTable getChamCongNVDS_DHN(int mayds)
        {

            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();
            string query = "SELECT MAYDS,DOT01,DOT02,DOT03,DOT04,DOT05,DOT06,DOT07,DOT08,DOT09,DOT10,DOT11,DOT12,DOT13,DOT14,DOT15,DOT16,DOT17,DOT18,DOT19,DOT20 FROM TB_BANGCHAMCONG WHERE MAYDS='" + mayds + "' ORDER BY STT ASC ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_BANGCHAMCONG");

            return ds.Tables["TB_BANGCHAMCONG"];
        }

        public static DataTable getChamCongNVDS_DONGCUA(int mayds)
        {

            DataSet ds = new DataSet();
            if (db.Connection.State == ConnectionState.Open)
            {
                db.Connection.Close();
            }
            db.Connection.Open();
            string query = "SELECT MAYDS,DOT01_DC,DOT02_DC,DOT03_DC,DOT04_DC,DOT05_DC,DOT06_DC,DOT07_DC,DOT08_DC,DOT09_DC,DOT10_DC,DOT11_DC,DOT12_DC,DOT13_DC,DOT14_DC,DOT15_DC,DOT16_DC,DOT17_DC,DOT18_DC,DOT19_DC,DOT20_DC FROM TB_BANGCHAMCONG WHERE MAYDS='" + mayds + "' ORDER BY STT ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_BANGCHAMCONG");

            return ds.Tables["TB_BANGCHAMCONG"];
        }

        public static TB_BANGCHAMCONG getChamCongBy(int mayds)
        {

            try
            {
                var query = from q in db.TB_BANGCHAMCONGs where q.MAYDS == mayds select q;
                return query.SingleOrDefault();
            }
            catch (Exception)
            {

            }
            return null;
        }

        public static void Update() {

            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static int ExecuteUpdate(int MAYDS,string nameColume, string values)
        {
            int result = 0;
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE TB_BANGCHAMCONG SET " + nameColume + "= " + values + " WHERE MAYDS=" + MAYDS, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
               // log.Error("LinQConnection ExecuteCommand_ : " + sql);
                log.Error("LinQConnection ExecuteCommand_ : " + ex.Message);

            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

    }
}