﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_BaoCaoCODE
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_BaoCaoCODE).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static DataTable get_BAOCAO_CODE()
        {
            return DAL.LinQConnection.getDataTable("SELECT * FROM W_BAOCAO_CODE");
        }
        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYNAY(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_CODE SET ";
            sql += "  W_BAOCAO_CODE.KN_CODE4 = t2.CODE4, W_BAOCAO_CODE.KN_CODE5= t2.CODE5, ";
            sql += "  W_BAOCAO_CODE.KN_CODE6 = t2.CODE6, W_BAOCAO_CODE.KN_CODE8= t2.CODE8, ";
            sql += "  W_BAOCAO_CODE.KN_CODEM = t2.CODEM, W_BAOCAO_CODE.KN_CODEN= t2.CODEN, ";
            sql += "  W_BAOCAO_CODE.KN_CODEQ = t2.CODEQ, W_BAOCAO_CODE.KN_CODEF= t2.CODEF, ";
            sql += "  W_BAOCAO_CODE.KN_CODEK = t2.CODEK ";
            sql += " FROM W_BAOCAO_CODE INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS CODE4,";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS CODE5,";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS CODE6,";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS CODE8,";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS CODEM,";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS CODEN,";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS CODEQ,";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS CODEF,";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS CODEK";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_CODE.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYNAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_CODE SET ";
            sql += "  W_BAOCAO_CODE.KT_CODE4 = t2.CODE4, W_BAOCAO_CODE.KT_CODE5= t2.CODE5, ";
            sql += "  W_BAOCAO_CODE.KT_CODE6 = t2.CODE6, W_BAOCAO_CODE.KT_CODE8= t2.CODE8, ";
            sql += "  W_BAOCAO_CODE.KT_CODEM = t2.CODEM, W_BAOCAO_CODE.KT_CODEN= t2.CODEN, ";
            sql += "  W_BAOCAO_CODE.KT_CODEQ = t2.CODEQ, W_BAOCAO_CODE.KT_CODEF= t2.CODEF, ";
            sql += "  W_BAOCAO_CODE.KT_CODEK = t2.CODEK ";
            sql += "FROM W_BAOCAO_CODE INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS CODE4,";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS CODE5,";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS CODE6,";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS CODE8,";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS CODEM,";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS CODEN,";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS CODEQ,";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS CODEF,";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS CODEK";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_CODE.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC " + ex.Message);
            }
        }


        /// chi tiet tung may doc so 
        /// 
        public static DataTable get_BAOCAO_CODE_MAY(int tods)
        {
            string sql = "SELECT * FROM W_BAOCAO_CODE_MAY WHERE TODS='" + tods + "' ORDER BY MAYDS ASC ";
            return DAL.LinQConnection.getDataTable(sql.Replace(@"\t", " "));
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYNAY(string nam, int ky)
        {
            string sql = " INSERT INTO W_BAOCAO_CODE_MAY ";
            sql += " SELECT TODS,MAY AS MAYDS, ";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS KN_CODE4, ";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS KN_CODE5, ";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS KN_CODE6, ";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS KN_CODE8, ";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS KN_CODEM, ";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS KN_CODEN, ";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS KN_CODEQ, ";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS KN_CODEF, ";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS KN_CODEK, ";
            sql += " KT_CODE4=0,KT_CODE5=0,KT_CODE6=0,KT_CODE8=0 ,KT_CODEM=0 ,KT_CODEN=0,KT_CODEQ=0,KT_CODEF=0,KT_CODEK=0";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE KY=" + ky;
            sql += " GROUP BY TODS,MAY ";
            try
            {
                DAL.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_CODE_MAY ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYNAY_MAY " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_MAY_KYTRUOC(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_CODE_MAY SET ";
            sql += " W_BAOCAO_CODE_MAY.KT_CODE4 = t2.CODE4, W_BAOCAO_CODE_MAY.KT_CODE5= t2.CODE5, ";
            sql += " W_BAOCAO_CODE_MAY.KT_CODE6 = t2.CODE6, W_BAOCAO_CODE_MAY.KT_CODE8= t2.CODE8, ";
            sql += " W_BAOCAO_CODE_MAY.KT_CODEM = t2.CODEM, W_BAOCAO_CODE_MAY.KT_CODEN= t2.CODEN, ";
            sql += " W_BAOCAO_CODE_MAY.KT_CODEQ = t2.CODEQ, W_BAOCAO_CODE_MAY.KT_CODEF= t2.CODEF, ";
            sql += " W_BAOCAO_CODE_MAY.KT_CODEK = t2.CODEK ";
            sql += " FROM W_BAOCAO_CODE_MAY INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,MAY AS MAYDS,";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS CODE4,";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS CODE5,";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS CODE6,";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS CODE8,";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS CODEM,";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS CODEN,";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS CODEQ,";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS CODEF,";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS CODEK";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky;
            sql += " GROUP BY TODS,MAY ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_CODE_MAY.TODS = t2.TODS AND W_BAOCAO_CODE_MAY.MAYDS = t2.MAYDS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC " + ex.Message);
            }
        }

        ///// THEO ĐỢT

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_CODE SET ";
            sql += "  W_BAOCAO_CODE.KN_CODE4 = t2.CODE4, W_BAOCAO_CODE.KN_CODE5= t2.CODE5, ";
            sql += "  W_BAOCAO_CODE.KN_CODE6 = t2.CODE6, W_BAOCAO_CODE.KN_CODE8= t2.CODE8, ";
            sql += "  W_BAOCAO_CODE.KN_CODEM = t2.CODEM, W_BAOCAO_CODE.KN_CODEN= t2.CODEN, ";
            sql += "  W_BAOCAO_CODE.KN_CODEQ = t2.CODEQ, W_BAOCAO_CODE.KN_CODEF= t2.CODEF, ";
            sql += "  W_BAOCAO_CODE.KN_CODEK = t2.CODEK ";
            sql += "FROM W_BAOCAO_CODE INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS CODE4,";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS CODE5,";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS CODE6,";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS CODE8,";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS CODEM,";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS CODEN,";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS CODEQ,";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS CODEF,";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS CODEK";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_CODE.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_CODE SET ";
            sql += "  W_BAOCAO_CODE.KT_CODE4 = t2.CODE4, W_BAOCAO_CODE.KT_CODE5= t2.CODE5, ";
            sql += "  W_BAOCAO_CODE.KT_CODE6 = t2.CODE6, W_BAOCAO_CODE.KT_CODE8= t2.CODE8, ";
            sql += "  W_BAOCAO_CODE.KT_CODEM = t2.CODEM, W_BAOCAO_CODE.KT_CODEN= t2.CODEN, ";
            sql += "  W_BAOCAO_CODE.KT_CODEQ = t2.CODEQ, W_BAOCAO_CODE.KT_CODEF= t2.CODEF, ";
            sql += "  W_BAOCAO_CODE.KT_CODEK = t2.CODEK ";
            sql += "FROM W_BAOCAO_CODE INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS CODE4,";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS CODE5,";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS CODE6,";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS CODE8,";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS CODEM,";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS CODEN,";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS CODEQ,";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS CODEF,";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS CODEK";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_CODE.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DOT " + ex.Message);
            }
        }


        /// chi tiet tung may doc so 
        /// 
        public static DataTable get_BAOCAO_CODE_MAY_DOT(int tods)
        {
            string sql = "SELECT * FROM W_BAOCAO_CODE_MAY WHERE TODS='" + tods + "' ORDER BY MAYDS ASC ";
            return DAL.LinQConnection.getDataTable(sql.Replace(@"\t", " "));
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_MAY_DOT(string nam, int ky, int dot)
        {

            string sql = " INSERT INTO W_BAOCAO_CODE_MAY ";
            sql += " SELECT TODS,MAY AS MAYDS, ";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS KN_CODE4, ";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS KN_CODE5, ";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS KN_CODE6, ";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS KN_CODE8, ";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS KN_CODEM, ";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS KN_CODEN, ";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS KN_CODEQ, ";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS KN_CODEF, ";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS KN_CODEK, ";
            sql += " KT_CODE4=0,KT_CODE5=0,KT_CODE6=0,KT_CODE8=0 ,KT_CODEM=0 ,KT_CODEN=0,KT_CODEQ=0,KT_CODEF=0,KT_CODEK=0";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS,MAY ";


            try
            {
                DAL.LinQConnection.ExecuteCommand("DELETE FROM W_BAOCAO_CODE_MAY ");
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_MAY_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_MAY_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_CODE SET ";
            sql += "  W_BAOCAO_CODE.KT_CODE4 = t2.CODE4, W_BAOCAO_CODE.KT_CODE5= t2.CODE5, ";
            sql += "  W_BAOCAO_CODE.KT_CODE6 = t2.CODE6, W_BAOCAO_CODE.KT_CODE8= t2.CODE8, ";
            sql += "  W_BAOCAO_CODE.KT_CODEM = t2.CODEM, W_BAOCAO_CODE.KT_CODEN= t2.CODEN, ";
            sql += "  W_BAOCAO_CODE.KT_CODEQ = t2.CODEQ, W_BAOCAO_CODE.KT_CODEF= t2.CODEF, ";
            sql += "  W_BAOCAO_CODE.KT_CODEK = t2.CODEK ";
            sql += "FROM W_BAOCAO_CODE INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS,MAY AS MAYDS,";
            sql += " COUNT(case when CODE LIKE '4%' then 1 else null end) AS CODE4,";
            sql += " COUNT(case when CODE LIKE '5%' then 1 else null end) AS CODE5,";
            sql += " COUNT(case when CODE LIKE '6%' then 1 else null end) AS CODE6,";
            sql += " COUNT(case when CODE LIKE '8%' then 1 else null end) AS CODE8,";
            sql += " COUNT(case when CODE LIKE 'M%' then 1 else null end) AS CODEM,";
            sql += " COUNT(case when CODE LIKE 'N%' then 1 else null end) AS CODEN,";
            sql += " COUNT(case when CODE LIKE 'Q%' then 1 else null end) AS CODEQ,";
            sql += " COUNT(case when CODE LIKE 'F%' then 1 else null end) AS CODEF,";
            sql += " COUNT(case when CODE LIKE 'K%' then 1 else null end) AS CODEK";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += " GROUP BY TODS,MAY ";
            sql += " ) as t2 ";
            sql += " ON	W_BAOCAO_CODE_MAY.TODS = t2.TODS AND W_BAOCAO_CODE_MAY.MAYDS = t2.MAYDS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_SANLUONG_KYTRUOC_DOT " + ex.Message);
            }
        }

        // CODE DETAIL 
        public static DataTable get_BAOCAO_CODE_DETAIL()
        {
            return DAL.LinQConnection.getDataTable("SELECT * FROM W_BAOCAO_CODE_DETAIL ");
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_CODE_DETAIL SET  ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_60 = t2.KN_60, W_BAOCAO_CODE_DETAIL.KN_61= t2.KN_61,  ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_62 = t2.KN_62, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_63 = t2.KN_63, W_BAOCAO_CODE_DETAIL.KN_64= t2.KN_64, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_65 = t2.KN_65, W_BAOCAO_CODE_DETAIL.KN_66= t2.KN_66, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_67 = t2.KN_67, W_BAOCAO_CODE_DETAIL.KN_68= t2.KN_68, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_54 = t2.KN_54, W_BAOCAO_CODE_DETAIL.KN_58= t2.KN_58, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_F1 = t2.KN_F1, W_BAOCAO_CODE_DETAIL.KN_F2= t2.KN_F2, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_F3 = t2.KN_F3, W_BAOCAO_CODE_DETAIL.KN_F5= t2.KN_F5";
            sql += "   FROM W_BAOCAO_CODE_DETAIL INNER JOIN ";
            sql += "   ( ";
            sql += "   SELECT TODS,";
            sql += "   COUNT(case when CODE='60' then 1 else null end) AS KN_60,";
            sql += "   COUNT(case when CODE='61' then 1 else null end) AS KN_61,";
            sql += "   COUNT(case when CODE='62' then 1 else null end) AS KN_62,";
            sql += "   COUNT(case when CODE='63' then 1 else null end) AS KN_63,";
            sql += "   COUNT(case when CODE='64' then 1 else null end) AS KN_64,";
            sql += "   COUNT(case when CODE='65' then 1 else null end) AS KN_65,";
            sql += "   COUNT(case when CODE='66' then 1 else null end) AS KN_66,";
            sql += "   COUNT(case when CODE='67' then 1 else null end) AS KN_67,";
            sql += "   COUNT(case when CODE='68' then 1 else null end) AS KN_68,";
            sql += "   COUNT(case when CODE='54' then 1 else null end) AS KN_54,";
            sql += "   COUNT(case when CODE='58' then 1 else null end) AS KN_58,";
            sql += "   COUNT(case when CODE='F1' then 1 else null end) AS KN_F1,";
            sql += "    COUNT(case when CODE='F2' then 1 else null end) AS KN_F2,";
            sql += "   COUNT(case when CODE='F3' then 1 else null end) AS KN_F3,";
            sql += "   COUNT(case when CODE='F5' then 1 else null end) AS KN_F5";
            sql += "   FROM DocSo_PHT.dbo.DS" + nam;
            sql += "   WHERE  KY=" + ky;
            sql += "   GROUP BY TODS ";
            sql += "   ) as t2 ";
            sql += "  ON	W_BAOCAO_CODE_DETAIL.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL(string nam, int ky)
        {
            string sql = "UPDATE W_BAOCAO_CODE_DETAIL SET  ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_60 = t2.KT_60, W_BAOCAO_CODE_DETAIL.KT_61= t2.KT_61,  ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_62 = t2.KT_62,  ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_63 = t2.KT_63, W_BAOCAO_CODE_DETAIL.KT_64= t2.KT_64, ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_65 = t2.KT_65, W_BAOCAO_CODE_DETAIL.KT_66= t2.KT_66, ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_67 = t2.KT_67, W_BAOCAO_CODE_DETAIL.KT_68= t2.KT_68, ";
            sql += " W_BAOCAO_CODE_DETAIL.KT_54 = t2.KT_54, W_BAOCAO_CODE_DETAIL.KT_58= t2.KT_58, ";
            sql += " W_BAOCAO_CODE_DETAIL.KT_F1 = t2.KT_F1, W_BAOCAO_CODE_DETAIL.KT_F2= t2.KT_F2, ";
            sql += " W_BAOCAO_CODE_DETAIL.KT_F3 = t2.KT_F3, W_BAOCAO_CODE_DETAIL.KT_F5= t2.KT_F5";
            sql += " FROM W_BAOCAO_CODE_DETAIL INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, ";
            sql += " COUNT(case when CODE='60' then 1 else null end) AS KT_60, ";
            sql += " COUNT(case when CODE='61' then 1 else null end) AS KT_61,";
            sql += " COUNT(case when CODE='62' then 1 else null end) AS KT_62,";
            sql += " COUNT(case when CODE='63' then 1 else null end) AS KT_63,";
            sql += " COUNT(case when CODE='64' then 1 else null end) AS KT_64,";
            sql += " COUNT(case when CODE='65' then 1 else null end) AS KT_65,";
            sql += " COUNT(case when CODE='66' then 1 else null end) AS KT_66,";
            sql += " COUNT(case when CODE='67' then 1 else null end) AS KT_67,";
            sql += " COUNT(case when CODE='68' then 1 else null end) AS KT_68,";
            sql += " COUNT(case when CODE='54' then 1 else null end) AS KT_54,";
            sql += " COUNT(case when CODE='58' then 1 else null end) AS KT_58,";
            sql += " COUNT(case when CODE='F1' then 1 else null end) AS KT_F1,";
            sql += " COUNT(case when CODE='F2' then 1 else null end) AS KT_F2,";
            sql += "COUNT(case when CODE='F3' then 1 else null end) AS KT_F3,";
            sql += "    COUNT(case when CODE='F5' then 1 else null end) AS KT_F5";
            sql += "   FROM DocSo_PHT.dbo.DS" + nam;
            sql += "   WHERE  KY=" + ky;
            sql += "   GROUP BY TODS ";
            sql += "    ) as t2 ";
            sql += "  ON	W_BAOCAO_CODE_DETAIL.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_CODE_DETAIL SET  ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_60 = t2.KN_60, W_BAOCAO_CODE_DETAIL.KN_61= t2.KN_61,  ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_62 = t2.KN_62, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_63 = t2.KN_63, W_BAOCAO_CODE_DETAIL.KN_64= t2.KN_64, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_65 = t2.KN_65, W_BAOCAO_CODE_DETAIL.KN_66= t2.KN_66, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_67 = t2.KN_67, W_BAOCAO_CODE_DETAIL.KN_68= t2.KN_68, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_54 = t2.KN_54, W_BAOCAO_CODE_DETAIL.KN_58= t2.KN_58, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_F1 = t2.KN_F1, W_BAOCAO_CODE_DETAIL.KN_F2= t2.KN_F2, ";
            sql += "    W_BAOCAO_CODE_DETAIL.KN_F3 = t2.KN_F3, W_BAOCAO_CODE_DETAIL.KN_F5= t2.KN_F5";
            sql += "   FROM W_BAOCAO_CODE_DETAIL INNER JOIN ";
            sql += "   ( ";
            sql += "   SELECT TODS,";
            sql += "   COUNT(case when CODE='60' then 1 else null end) AS KN_60,";
            sql += "   COUNT(case when CODE='61' then 1 else null end) AS KN_61,";
            sql += "   COUNT(case when CODE='62' then 1 else null end) AS KN_62,";
            sql += "   COUNT(case when CODE='63' then 1 else null end) AS KN_63,";
            sql += "   COUNT(case when CODE='64' then 1 else null end) AS KN_64,";
            sql += "   COUNT(case when CODE='65' then 1 else null end) AS KN_65,";
            sql += "   COUNT(case when CODE='66' then 1 else null end) AS KN_66,";
            sql += "   COUNT(case when CODE='67' then 1 else null end) AS KN_67,";
            sql += "   COUNT(case when CODE='68' then 1 else null end) AS KN_68,";
            sql += "   COUNT(case when CODE='54' then 1 else null end) AS KN_54,";
            sql += "   COUNT(case when CODE='58' then 1 else null end) AS KN_58,";
            sql += "   COUNT(case when CODE='F1' then 1 else null end) AS KN_F1,";
            sql += "    COUNT(case when CODE='F2' then 1 else null end) AS KN_F2,";
            sql += "   COUNT(case when CODE='F3' then 1 else null end) AS KN_F3,";
            sql += "   COUNT(case when CODE='F5' then 1 else null end) AS KN_F5";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += "   GROUP BY TODS ";
            sql += "   ) as t2 ";
            sql += "  ON	W_BAOCAO_CODE_DETAIL.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYNAY_DETAIL_DOT " + ex.Message);
            }
        }

        public static void CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL_DOT(string nam, int ky, int dot)
        {
            string sql = "UPDATE W_BAOCAO_CODE_DETAIL SET  ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_60 = t2.KT_60, W_BAOCAO_CODE_DETAIL.KT_61= t2.KT_61,  ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_62 = t2.KT_62,  ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_63 = t2.KT_63, W_BAOCAO_CODE_DETAIL.KT_64= t2.KT_64, ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_65 = t2.KT_65, W_BAOCAO_CODE_DETAIL.KT_66= t2.KT_66, ";
            sql += "  W_BAOCAO_CODE_DETAIL.KT_67 = t2.KT_67, W_BAOCAO_CODE_DETAIL.KT_68= t2.KT_68, ";
            sql += " W_BAOCAO_CODE_DETAIL.KT_54 = t2.KT_54, W_BAOCAO_CODE_DETAIL.KT_58= t2.KT_58, ";
            sql += " W_BAOCAO_CODE_DETAIL.KT_F1 = t2.KT_F1, W_BAOCAO_CODE_DETAIL.KT_F2= t2.KT_F2, ";
            sql += " W_BAOCAO_CODE_DETAIL.KT_F3 = t2.KT_F3, W_BAOCAO_CODE_DETAIL.KT_F5= t2.KT_F5";
            sql += " FROM W_BAOCAO_CODE_DETAIL INNER JOIN ";
            sql += " ( ";
            sql += " SELECT TODS, ";
            sql += " COUNT(case when CODE='60' then 1 else null end) AS KT_60, ";
            sql += " COUNT(case when CODE='61' then 1 else null end) AS KT_61,";
            sql += "  COUNT(case when CODE='62' then 1 else null end) AS KT_62,";
            sql += "   COUNT(case when CODE='63' then 1 else null end) AS KT_63,";
            sql += "  COUNT(case when CODE='64' then 1 else null end) AS KT_64,";
            sql += "    COUNT(case when CODE='65' then 1 else null end) AS KT_65,";
            sql += "   COUNT(case when CODE='66' then 1 else null end) AS KT_66,";
            sql += "   COUNT(case when CODE='67' then 1 else null end) AS KT_67,";
            sql += "   COUNT(case when CODE='68' then 1 else null end) AS KT_68,";
            sql += "   COUNT(case when CODE='54' then 1 else null end) AS KT_54,";
            sql += "    COUNT(case when CODE='58' then 1 else null end) AS KT_58,";
            sql += "    COUNT(case when CODE='F1' then 1 else null end) AS KT_F1,";
            sql += "    COUNT(case when CODE='F2' then 1 else null end) AS KT_F2,";
            sql += "   COUNT(case when CODE='F3' then 1 else null end) AS KT_F3,";
            sql += "    COUNT(case when CODE='F5' then 1 else null end) AS KT_F5";
            sql += " FROM DocSo_PHT.dbo.DS" + nam;
            sql += " WHERE  KY=" + ky + " AND DOT =" + dot;
            sql += "   GROUP BY TODS ";
            sql += "    ) as t2 ";
            sql += "  ON	W_BAOCAO_CODE_DETAIL.TODS = t2.TODS";

            try
            {
                int resqult = DAL.LinQConnection.ExecuteCommand(sql.Replace(@"\t", " "));

            }
            catch (Exception ex)
            {
                log.Error("CAPNHATSOLIEU_BAOCAO_CODE_KYTRUOC_DETAIL_DOT  " + ex.Message);
            }
        }

    }
}