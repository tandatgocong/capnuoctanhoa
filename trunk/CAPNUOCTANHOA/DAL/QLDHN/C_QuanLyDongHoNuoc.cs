using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using log4net;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_QuanLyDongHoNuoc
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_QuanLyDongHoNuoc).Name);
        
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        
        public static string getNhanVienDS(int mayds){
        
            string tennv="";
            var query = from q in db.TB_NHANVIENDOCSOs where q.MAYDS == mayds select q;
            TB_NHANVIENDOCSO nv =query.SingleOrDefault();
            if (nv != null) {
                return nv.NAME;
            }
            return tennv;
        }

        public static void setNhanVienDS(DataGridView g, string dataColum,string mayds) {

            for (int i = 0; i < g.Rows.Count; i++) {
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
    }
}
