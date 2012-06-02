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

        public static DataSet getThongKeDHN(int ky, int nam)
        {
            LinQConnection.ExecuteStoredProcedure("THONGKEDHN", ky, nam);
            DataSet ds = new DataSet();
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

            db.Connection.Open();
            string query = "SELECT * FROM TB_THONGKEDHN WHERE HIEUCU='False' ORDER BY STT ASC ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN");


            query = "SELECT * FROM TB_THONGKEDHN  WHERE HIEUCU='True' ORDER BY STT ASC";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN_CU");

            query = "SELECT SUM(CO15) AS SUM_CO15, SUM(CO20) AS SUM_CO20, SUM(CO25) AS SUM_CO25, SUM(CO40) AS SUM_CO40, SUM(CO50) AS SUM_CO50, SUM(CO80) AS SUM_CO80, SUM(CO100) AS SUM_CO100, SUM(CO150) AS SUM_CO150, SUM(CO200) AS SUM_CO200, SUM(NHOCO15) AS SUM_NHOCO15, SUM(NHOCO20) AS SUM_NHOCO20, SUM(NHOCO25) AS SUM_NHOCO25, SUM(NHOCO40) AS SUM_NHOCO40, SUM(NHOCO50) AS SUM_NHOCO50, SUM(NHOCO80) AS SUM_NHOCO80, SUM(NHOCO100) AS SUM_NHOCO100, SUM(NHOCO150) AS SUM_NHOCO150, SUM(NHOCO200) AS SUM_NHOCO200, SUM(LONCO15) AS SUM_LONCO15, SUM(LONCO20) AS SUM_LONCO20, SUM(LONCO25) AS SUM_LONCO25, SUM(LONCO40) AS SUM_LONCO40, SUM(LONCO50) AS SUM_LONCO50, SUM(LONCO80) AS SUM_LONCO80, SUM(LONCO100) AS SUM_LONCO100, SUM(LONCO150) AS SUM_LONCO150, SUM(LONCO200) AS SUM_LONCO200 FROM TB_THONGKEDHN";
            adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);
            adapter.Fill(ds, "TB_THONGKEDHN_SUM");
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
                sql += " SELECT t.MAY, COUNT(t.DANHBA) AS SOLUONG,(case when SUM(t.TIEUTHU) IS NULL then 0 else SUM(t.TIEUTHU) end) AS SANLUONG,";
                sql += "  COUNT(case when (t.CODE LIKE 'F%' OR t.CODE='61' OR t.CODE='64'  OR t.CODE='66')  then 1 else null end) AS KOGHI,";
                sql += "   COUNT(case when (t.GHICHUMOI LIKE N'%Xây dựng%') then 1 else null end )AS XAYDUNG,";
                sql += " COUNT(case when (t.TIEUTHU-t3.TIEUTHU)>" + khoi + "  then 1 else null end) AS TANG,";
                sql += " COUNT(case when (t.TIEUTHU-t3.TIEUTHU)<" + khoi + "  then 1 else null end) AS GAM";
                sql += " FROM DocSo_PHT.dbo.DS" + nam + "  t ";
                sql += " LEFT JOIN ( ";
                sql += " SELECT DANHBA,TIEUTHU FROM DocSo_PHT.dbo.DS" + nam + " WHERE KY=" + (ky - 1) + "  ) as t3";
                sql += " ON t.DANHBA=t3.DANHBA";
                sql += " WHERE  KY=" + ky ;
                sql += " GROUP BY  MAY ";
                sql += " ) as t2 ";
                sql += " ON TB_NHANVIENDOCSO.MAYDS = t2.MAY";
            }
            else
            {
                sql += " SET SOLUONGDHN=t2.SOLUONG,SANLUONG=t2.SANLUONG,KHONGGHI=t2.KOGHI,TANG=t2.TANG,GIAM=t2.GAM ,NHAXD=t2.XAYDUNG";
                sql += " FROM	TB_NHANVIENDOCSO INNER JOIN  ";
                sql += " (  ";
                sql += " SELECT t.MAY, COUNT(t.DANHBA) AS SOLUONG,(case when SUM(t.TIEUTHU) IS NULL then 0 else SUM(t.TIEUTHU) end) AS SANLUONG,";
                sql += "  COUNT(case when (t.CODE LIKE 'F%' OR t.CODE='61' OR t.CODE='64'  OR t.CODE='66')  then 1 else null end) AS KOGHI,";
                sql += "   COUNT(case when (t.GHICHUMOI LIKE N'%Xây dựng%') then 1 else null end )AS XAYDUNG,";
                sql += " COUNT(case when (t.TIEUTHU-t3.TIEUTHU)>" + khoi + "  then 1 else null end) AS TANG,";
                sql += " COUNT(case when (t.TIEUTHU-t3.TIEUTHU)<" + khoi + "  then 1 else null end) AS GAM";
                sql += " FROM DocSo_PHT.dbo.DS" + nam+"  t ";
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
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

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
    }
}