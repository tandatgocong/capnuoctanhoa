using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_BaoCaoTK
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BaoCaoTK).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static DataTable get_BAOCAO_SANLUONG()
        {
            return DAL.LinQConnection.getDataTable("SELECT * FROM W_BAOCAO_SANLUONG");
        }
        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KN_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KN_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam ;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam ;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.NT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam ;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }
        /// chi tiet tung may doc so 
        /// 
        public static DataTable get_BAOCAO_SANLUONG_MAY(int tods)
        {
            string sql = "SELECT * FROM W_BAOCAO_SANLUONG_MAY WHERE TODS='"+tods+"' ORDER BY MAYDS ASC ";
            return DAL.LinQConnection.getDataTable(sql.Replace(@"\t"," "));
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY(string nam, int ky)
        {
            string sql = "INSERT INTO W_BAOCAO_SANLUONG_MAY ";
            sql += " SELECT TODS,MAY, COUNT(DANHBA) AS 'KN_DHN', ";
            sql += " (case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS KN_SANLUONG, ";
            sql += " KT_DHN=0,KT_SANLUONG=0,TANGIAM_DHN=0,TANGIAM_SANLUONG=0,NT_DHN=0,NT_SANLUONG=0,NT_TANGIAM_DHN=0,NT_TANGIAM_SANLUONG=0 ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE KY=" + ky + " AND NAM="+nam ;
            sql += " GROUP BY TODS,MAY ";
            try
            {
                DAL.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_SANLUONG_MAY ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.KT_SANLUONG= t2.SANLUONG ";
            sql += " FROM W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,MAY, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE KY=" + ky + " AND NAM="+nam ;
            sql += " GROUP BY TODS,MAY ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG_MAY.TODS = t2.TODS AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAY";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.NT_SANLUONG= t2.SANLUONG ";
            sql += " FROM W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,MAY, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE KY=" + ky + " AND NAM="+nam ;
            sql += " GROUP BY TODS,MAY ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG_MAY.TODS = t2.TODS AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAY";
            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC " + ex.Message);
            }
        }

        
        ///// THEO ĐỢT
        
        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KN_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KN_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += "(";
            sql += " SELECT TODS, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam  +" AND DOT ="+dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS=t2.TODS";

            try
            {
                sql = sql.Replace(@"\t", " ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql);
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.KT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam  + " AND DOT =" + dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET W_BAOCAO_SANLUONG.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG.NT_SANLUONG= t2.SANLUONG ";
            sql += "FROM W_BAOCAO_SANLUONG INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam  + " AND DOT =" + dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_SANLUONG.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_DOT()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }
        /// chi tiet tung may doc so 
        /// 
        public static DataTable get_BAOCAO_SANLUONG_MAY_DOT(int tods)
        {
            string sql = "SELECT * FROM W_BAOCAO_SANLUONG_MAY WHERE TODS='" + tods + "' ORDER BY MAYDS ASC ";
            return DAL.LinQConnection.getDataTable(sql.Replace(@"\t"," "));
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "INSERT INTO W_BAOCAO_SANLUONG_MAY ";
            sql += " SELECT TODS,MAY, COUNT(DANHBA) AS 'KN_DHN' ,  ";
            sql += " (case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS KN_SANLUONG, ";
            sql += " KT_DHN=0,KT_SANLUONG=0,TANGIAM_DHN=0,TANGIAM_SANLUONG=0,NT_DHN=0,NT_SANLUONG=0,NT_TANGIAM_DHN=0,NT_TANGIAM_SANLUONG=0 ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam  + " AND DOT =" + dot;
            sql += " GROUP BY TODS,MAY ";
            try
            {
                DAL.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_SANLUONG_MAY ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.KT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.KT_SANLUONG= t2.SANLUONG ";
            sql += " FROM	W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,MAY, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam  + " AND DOT =" + dot;
            sql += " GROUP BY TODS,MAY ";
            sql += " ) as t2 ";
            sql += " ON W_BAOCAO_SANLUONG_MAY.TODS = t2.TODS AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAY";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET W_BAOCAO_SANLUONG_MAY.NT_DHN = t2.COUNTDHN, W_BAOCAO_SANLUONG_MAY.NT_SANLUONG= t2.SANLUONG ";
            sql += " FROM W_BAOCAO_SANLUONG_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,MAY, COUNT(DANHBA) AS COUNTDHN,(case when SUM(TieuThuMoi) IS NULL then 0 else SUM(TieuThuMoi) end) AS SANLUONG ";
            sql += " FROM DocSoTH.dbo.DocSo  t  ";
            sql += " WHERE  KY=" + ky + " AND NAM="+nam  + " AND DOT =" + dot;
            sql += " GROUP BY TODS,MAY ";
            sql += " ) as t2 ";
            sql += " ON W_BAOCAO_SANLUONG_MAY.TODS = t2.TODS AND W_BAOCAO_SANLUONG_MAY.MAYDS = t2.MAY";
            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_SANLUONG_TANGGIAM_MAY_DOT()
        {
            string sql = "UPDATE W_BAOCAO_SANLUONG_MAY ";
            sql += " SET TANGIAM_DHN =KN_DHN-KT_DHN, ";
            sql += " TANGIAM_SANLUONG =KN_SANLUONG-KT_SANLUONG, ";
            sql += " NT_TANGIAM_DHN =KN_DHN- NT_DHN ,";
            sql += " NT_TANGIAM_SANLUONG =KN_SANLUONG -NT_SANLUONG ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t"," "));
                log.Info("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT  " + resqult + " record");
            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KY_NAMTRUOC_DOT " + ex.Message);
            }
        }
    
    
    }
}