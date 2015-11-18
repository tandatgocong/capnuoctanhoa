using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using System.IO;
using System.Data.SqlClient;
using log4net;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frmPdf : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frmPdf).Name);
        public frmPdf(string danhbo)
        {
            InitializeComponent();
            string varPathToNewLocation = AppDomain.CurrentDomain.BaseDirectory + @"\Test.pdf";

            try
            {

                GISDataContext db = new GISDataContext();


                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();

                SqlConnection sqlCon;
                sqlCon = new SqlConnection(db.Connection.ConnectionString);
                sqlCon.Open();
                using (var sqlQuery = new SqlCommand(@"SELECT DataBlob FROM HOSO_DONGHOKHACHHANG WHERE DBDongHoNuoc='" + danhbo + "' ", sqlCon))
                {

                    using (var sqlQueryResult = sqlQuery.ExecuteReader())
                        if (sqlQueryResult != null)
                        {
                            sqlQueryResult.Read();
                            var blob = new Byte[(sqlQueryResult.GetBytes(0, 0, null, 0, int.MaxValue))];
                            sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length);
                            using (var fs = new FileStream(varPathToNewLocation, FileMode.Create, FileAccess.Write))
                                fs.Write(blob, 0, blob.Length);
                        }
                }
                sqlCon.Close();
                axAcroPDF1.LoadFile(varPathToNewLocation);

            }
            catch (Exception Ex)
            {
                log.Error(Ex.Message);
            }
        }

    }
}
