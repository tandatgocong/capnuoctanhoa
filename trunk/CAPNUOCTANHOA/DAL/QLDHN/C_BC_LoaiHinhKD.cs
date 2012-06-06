using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_BC_LoaiHinhKD
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BaoCaoTK).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static DataTable get_BAOCAO_SANLUONG()
        {
            return DAL.LinQConnection.getDataTable("SELECT * FROM W_BAOCAO_LOAIKD");
        }
        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY(string nam, int ky)
        {
            string sql = "UPDATE 	W_BAOCAO_LOAIKD ";
            sql += " SET	KN_SH_DH =t2.KN_SH_DH,KN_SH_SL=t2.KN_SH_SL ,";
            sql += " KN_SX_DH =t2.KN_SX_DH,KN_SX_SL=t2.KN_SX_SL ,";
            sql += " KN_KD_DH =t2.KN_KD_DH,KN_KD_SL=t2.KN_KD_SL ,";
            sql += " KN_CC_DH =t2.KN_CC_DH,KN_CC_SL=t2.KN_CC_SL ,";
            sql += " KN_HCSN_DH =t2.KN_HCSN_DH,KN_HCSN_SL=t2.KN_HCSN_SL ";
            sql += " FROM W_BAOCAO_LOAIKD INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KN_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KN_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KN_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KN_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KN_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KN_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KN_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KN_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KN_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KN_HCSN_SL	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD.TODS = t2.TODS ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY " + ex.Message);
            }
        }
        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC(string nam, int ky)
        {
            string sql = "UPDATE 	W_BAOCAO_LOAIKD ";
            sql += " SET	KT_SH_DH =t2.KT_SH_DH,KT_SH_SL=t2.KT_SH_SL ,";
            sql += " KT_SX_DH =t2.KT_SX_DH,KT_SX_SL=t2.KT_SX_SL ,";
            sql += " KT_KD_DH =t2.KT_KD_DH,KT_KD_SL=t2.KT_KD_SL ,";
            sql += " KT_CC_DH =t2.KT_CC_DH,KT_CC_SL=t2.KT_CC_SL ,";
            sql += " KT_HCSN_DH =t2.KT_HCSN_DH,KT_HCSN_SL=t2.KT_HCSN_SL ";
            sql += " FROM W_BAOCAO_LOAIKD INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KT_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KT_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KT_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KT_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KT_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KT_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KT_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KT_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KT_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KT_HCSN_SL	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD.TODS = t2.TODS ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE 	W_BAOCAO_LOAIKD ";
            sql += " SET	KN_SH_DH =t2.KN_SH_DH,KN_SH_SL=t2.KN_SH_SL ,";
            sql += " KN_SX_DH =t2.KN_SX_DH,KN_SX_SL=t2.KN_SX_SL ,";
            sql += " KN_KD_DH =t2.KN_KD_DH,KN_KD_SL=t2.KN_KD_SL ,";
            sql += " KN_CC_DH =t2.KN_CC_DH,KN_CC_SL=t2.KN_CC_SL ,";
            sql += " KN_HCSN_DH =t2.KN_HCSN_DH,KN_HCSN_SL=t2.KN_HCSN_SL ";
            sql += " FROM W_BAOCAO_LOAIKD INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KN_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KN_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KN_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KN_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KN_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KN_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KN_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KN_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KN_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KN_HCSN_SL	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD.TODS = t2.TODS ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY " + ex.Message);
            }
        }
        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE 	W_BAOCAO_LOAIKD ";
            sql += " SET	KT_SH_DH =t2.KT_SH_DH,KT_SH_SL=t2.KT_SH_SL ,";
            sql += " KT_SX_DH =t2.KT_SX_DH,KT_SX_SL=t2.KT_SX_SL ,";
            sql += " KT_KD_DH =t2.KT_KD_DH,KT_KD_SL=t2.KT_KD_SL ,";
            sql += " KT_CC_DH =t2.KT_CC_DH,KT_CC_SL=t2.KT_CC_SL ,";
            sql += " KT_HCSN_DH =t2.KT_HCSN_DH,KT_HCSN_SL=t2.KT_HCSN_SL ";
            sql += " FROM W_BAOCAO_LOAIKD INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KT_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KT_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KT_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KT_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KT_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KT_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KT_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KT_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KT_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KT_HCSN_SL	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD.TODS = t2.TODS ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY " + ex.Message);
            }
        }

        //---------------------------------------------------------------------------------------------------------------
        //// MÁY

        public static DataTable get_BAOCAO_BAOCAO_LOAIKD_MAY(int tods)
        {
            string sql = "SELECT * FROM W_BAOCAO_LOAIKD_MAY WHERE TODS='" + tods + "' ORDER BY MAYDS ASC ";
            return DAL.LinQConnection.getDataTable(sql.Replace(@"\t", " "));
        }

        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY_MAY(string nam, int ky)
        {
           
            string sql = "INSERT INTO W_BAOCAO_LOAIKD_MAY ";
            sql += " SELECT TODS,MAY,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KN_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KN_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KN_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KN_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KN_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KN_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KN_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KN_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KN_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KN_HCSN_SL,";
            sql += "  KT_SH_DH =0,KT_SH_SL =0, KT_SX_DH =0,KT_SX_SL =0,  KT_KD_DH =0,KT_KD_SL =0,  KT_CC_DH =0, KT_CC_SL =0,   KT_HCSN_DH =0,KT_HCSN_SL =0";           
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS,MAY";

            try
            {
                DAL.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_LOAIKD_MAY ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_W_BAOCAO_LOAIKD_MAY_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_MAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_LOAIKD_MAY ";
            sql += " SET	KT_SH_DH =t2.KT_SH_DH,KT_SH_SL=t2.KT_SH_SL ,";
            sql += " KT_SX_DH =t2.KT_SX_DH,KT_SX_SL=t2.KT_SX_SL ,";
            sql += " KT_KD_DH =t2.KT_KD_DH,KT_KD_SL=t2.KT_KD_SL ,";
            sql += " KT_CC_DH =t2.KT_CC_DH,KT_CC_SL=t2.KT_CC_SL ,";
            sql += " KT_HCSN_DH =t2.KT_HCSN_DH,KT_HCSN_SL=t2.KT_HCSN_SL ";
            sql += " FROM W_BAOCAO_LOAIKD_MAY INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,MAY,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KT_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KT_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KT_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KT_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KT_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KT_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KT_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KT_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KT_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KT_HCSN_SL	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS,MAY";
            sql += " ) as t2";
            sql += " ON W_BAOCAO_LOAIKD_MAY.TODS = t2.TODS AND W_BAOCAO_LOAIKD_MAY.MAYDS = t2.MAY";
            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_W_BAOCAO_LOAIKD_MAY_KYTRUOC " + ex.Message);
            }
        }

/// <summary>
/// 
/// </summary>
/// <param name="nam"></param>
/// <param name="ky"></param>
/// <param name="dot"></param>

        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "INSERT INTO W_BAOCAO_LOAIKD_MAY ";
            sql += " SELECT TODS,MAY,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KN_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KN_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KN_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KN_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KN_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KN_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KN_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KN_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KN_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KN_HCSN_SL,";
            sql += "  KT_SH_DH =0,KT_SH_SL =0, KT_SX_DH =0,KT_SX_SL =0,  KT_KD_DH =0,KT_KD_SL =0,  KT_CC_DH =0, KT_CC_SL =0,   KT_HCSN_DH =0,KT_HCSN_SL =0";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS,MAY";

            try
            {
                DAL.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_LOAIKD_MAY ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_W_BAOCAO_LOAIKD_MAY_KYNAY " + ex.Message);
            }

        }

        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_MAY_DOT(string nam, int ky, int dot)
        {
           
            string sql = "UPDATE W_BAOCAO_LOAIKD_MAY ";
            sql += " SET	KT_SH_DH =t2.KT_SH_DH,KT_SH_SL=t2.KT_SH_SL ,";
            sql += " KT_SX_DH =t2.KT_SX_DH,KT_SX_SL=t2.KT_SX_SL ,";
            sql += " KT_KD_DH =t2.KT_KD_DH,KT_KD_SL=t2.KT_KD_SL ,";
            sql += " KT_CC_DH =t2.KT_CC_DH,KT_CC_SL=t2.KT_CC_SL ,";
            sql += " KT_HCSN_DH =t2.KT_HCSN_DH,KT_HCSN_SL=t2.KT_HCSN_SL ";
            sql += " FROM W_BAOCAO_LOAIKD_MAY INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,MAY,";
            sql += " (COUNT(case when GB=11 then 1 else null end)) AS KT_SH_DH, 	(SUM(case when GB=11 then TIEUTHU else 0 end)) AS KT_SH_SL,";
            sql += " (COUNT(case when GB IN (12,14,34,24) then 1 else null end)) AS KT_SX_DH, 	(SUM(case when GB IN (12,14,34,24) then TIEUTHU else 0 end)) AS KT_SX_SL,";
            sql += " (COUNT(case when GB IN (15,13,33,23) then 1 else null end)) AS KT_KD_DH, 	(SUM(case when GB IN (15,13,33,23) then TIEUTHU else 0 end)) AS KT_KD_SL,";
            sql += " (COUNT(case when GB IN (21,51,52) then 1 else null end)) AS KT_CC_DH, 	(SUM(case when GB IN (21,51,52) then TIEUTHU else 0 end)) AS KT_CC_SL,";
            sql += " (COUNT(case when GB=31 then 1 else null end)) AS KT_HCSN_DH, 	(SUM(case when GB=31 then TIEUTHU else 0 end)) AS KT_HCSN_SL	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS,MAY";
            sql += " ) as t2";
            sql += " ON W_BAOCAO_LOAIKD_MAY.TODS = t2.TODS AND W_BAOCAO_LOAIKD_MAY.MAYDS = t2.MAY";
            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_LOAIKD_KYTRUOC_MAY_DOT " + ex.Message);
            }
        }

     
    }
}