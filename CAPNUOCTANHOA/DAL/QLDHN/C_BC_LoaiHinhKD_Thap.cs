using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_BC_LoaiHinhKD_Thap
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BaoCaoTK).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static DataTable get_BAOCAO_SANLUONG()
        {
            return DAL.LinQConnection.getDataTable("SELECT * FROM W_BAOCAO_LOAIKD_THAP");
        }
        public static void CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY(string nam, int ky)
        {
            string sql = "UPDATE 	W_BAOCAO_LOAIKD_THAP ";
            sql += " SET	KN_SH0 =t2.KN_SH0,KN_SH4=t2.KN_SH4 ,";
            sql += " KN_SX0 =t2.KN_SX0,KN_SX4=t2.KN_SX4 ,";
            sql += " KN_KD0 =t2.KN_KD0,KN_KD4=t2.KN_KD4 ,";
            sql += " KN_CC0 =t2.KN_CC0,KN_CC4=t2.KN_CC4 ,";
            sql += " KN_HCSN0 =t2.KN_HCSN0,KN_HCSN4=t2.KN_HCSN4 ";
            sql += " FROM W_BAOCAO_LOAIKD_THAP INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when (GB=11 AND TIEUTHU=0) then 1 else null end)) AS KN_SH0, (COUNT(case when (GB=11 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SH4,";
            sql += " (COUNT(case when (GB IN (12,14,34,24) AND TIEUTHU=0)  then 1 else null end)) AS KN_SX0, (COUNT(case when (GB IN (12,14,34,24) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SX4,";
            sql += " (COUNT(case when (GB IN (15,13,33,23) AND TIEUTHU=0) then 1 else null end)) AS KN_KD0, (COUNT(case when (GB IN (15,13,33,23) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_KD4,";
            sql += " (COUNT(case when (GB IN (21,51,52) AND TIEUTHU=0) then 1 else null end)) AS KN_CC0, (COUNT(case when (GB IN (21,51,52) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_CC4,";
            sql += " (COUNT(case when (GB=31 AND TIEUTHU=0) then 1 else null end)) AS KN_HCSN0, (COUNT(case when (GB=31 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_HCSN4	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD_THAP.TODS = t2.TODS ";

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
            string sql = "UPDATE 	W_BAOCAO_LOAIKD_THAP ";
            sql += " SET KT_SH0 =t2.KT_SH0,KT_SH4=t2.KT_SH4 ,";
            sql += " KT_SX0 =t2.KT_SX0,KT_SX4=t2.KT_SX4 ,";
            sql += " KT_KD0 =t2.KT_KD0,KT_KD4=t2.KT_KD4 ,";
            sql += " KT_CC0 =t2.KT_CC0,KT_CC4=t2.KT_CC4 ,";
            sql += " KT_HCSN0 =t2.KT_HCSN0,KT_HCSN4=t2.KT_HCSN4 ";
            sql += " FROM W_BAOCAO_LOAIKD_THAP INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when (GB=11 AND TIEUTHU=0) then 1 else null end)) AS KN_SH0, (COUNT(case when (GB=11 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SH4,";
            sql += " (COUNT(case when (GB IN (12,14,34,24) AND TIEUTHU=0)  then 1 else null end)) AS KN_SX0, (COUNT(case when (GB IN (12,14,34,24) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SX4,";
            sql += " (COUNT(case when (GB IN (15,13,33,23) AND TIEUTHU=0) then 1 else null end)) AS KN_KD0, (COUNT(case when (GB IN (15,13,33,23) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_KD4,";
            sql += " (COUNT(case when (GB IN (21,51,52) AND TIEUTHU=0) then 1 else null end)) AS KN_CC0, (COUNT(case when (GB IN (21,51,52) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_CC4,";
            sql += " (COUNT(case when (GB=31 AND TIEUTHU=0) then 1 else null end)) AS KN_HCSN0, (COUNT(case when (GB=31 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_HCSN4	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD_THAP.TODS = t2.TODS ";

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
            string sql = "UPDATE 	W_BAOCAO_LOAIKD_THAP ";
            sql += " SET	KN_SH0 =t2.KN_SH0,KN_SH4=t2.KN_SH4 ,";
            sql += " KN_SX0 =t2.KN_SX0,KN_SX4=t2.KN_SX4 ,";
            sql += " KN_KD0 =t2.KN_KD0,KN_KD4=t2.KN_KD4 ,";
            sql += " KN_CC0 =t2.KN_CC0,KN_CC4=t2.KN_CC4 ,";
            sql += " KN_HCSN0 =t2.KN_HCSN0,KN_HCSN4=t2.KN_HCSN4 ";
            sql += " FROM W_BAOCAO_LOAIKD_THAP INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when (GB=11 AND TIEUTHU=0) then 1 else null end)) AS KN_SH0, (COUNT(case when (GB=11 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SH4,";
            sql += " (COUNT(case when (GB IN (12,14,34,24) AND TIEUTHU=0)  then 1 else null end)) AS KN_SX0, (COUNT(case when (GB IN (12,14,34,24) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SX4,";
            sql += " (COUNT(case when (GB IN (15,13,33,23) AND TIEUTHU=0) then 1 else null end)) AS KN_KD0, (COUNT(case when (GB IN (15,13,33,23) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_KD4,";
            sql += " (COUNT(case when (GB IN (21,51,52) AND TIEUTHU=0) then 1 else null end)) AS KN_CC0, (COUNT(case when (GB IN (21,51,52) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_CC4,";
            sql += " (COUNT(case when (GB=31 AND TIEUTHU=0) then 1 else null end)) AS KN_HCSN0, (COUNT(case when (GB=31 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_HCSN4	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD_THAP.TODS = t2.TODS ";

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
            string sql = "UPDATE 	W_BAOCAO_LOAIKD_THAP ";
            sql += " SET	KT_SH0 =t2.KT_SH0,KT_SH4=t2.KT_SH4 ,";
            sql += " KT_SX0 =t2.KT_SX0,KT_SX4=t2.KT_SX4 ,";
            sql += " KT_KD0 =t2.KT_KD0,KT_KD4=t2.KT_KD4 ,";
            sql += " KT_CC0 =t2.KT_CC0,KT_CC4=t2.KT_CC4 ,";
            sql += " KT_HCSN0 =t2.KT_HCSN0,KT_HCSN4=t2.KT_HCSN4 ";
            sql += " FROM W_BAOCAO_LOAIKD_THAP INNER JOIN";
            sql += " (";
            sql += " SELECT TODS,";
            sql += " (COUNT(case when (GB=11 AND TIEUTHU=0) then 1 else null end)) AS KN_SH0, (COUNT(case when (GB=11 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SH4,";
            sql += " (COUNT(case when (GB IN (12,14,34,24) AND TIEUTHU=0)  then 1 else null end)) AS KN_SX0, (COUNT(case when (GB IN (12,14,34,24) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_SX4,";
            sql += " (COUNT(case when (GB IN (15,13,33,23) AND TIEUTHU=0) then 1 else null end)) AS KN_KD0, (COUNT(case when (GB IN (15,13,33,23) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_KD4,";
            sql += " (COUNT(case when (GB IN (21,51,52) AND TIEUTHU=0) then 1 else null end)) AS KN_CC0, (COUNT(case when (GB IN (21,51,52) AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_CC4,";
            sql += " (COUNT(case when (GB=31 AND TIEUTHU=0) then 1 else null end)) AS KN_HCSN0, (COUNT(case when (GB=31 AND (TIEUTHU>=1  AND TIEUTHU<=4)) then 1 else null end)) AS KN_HCSN4	";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS";
            sql += " ) as t2";
            sql += " ON	W_BAOCAO_LOAIKD_THAP.TODS = t2.TODS ";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_LOAIKD_KYNAY " + ex.Message);
            }
        }

    }
}