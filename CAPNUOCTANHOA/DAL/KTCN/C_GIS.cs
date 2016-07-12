using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTANHOA.DAL.KTCN
{
    class C_GIS
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_GIS).Name);
        static GISDataContext db = new GISDataContext();

        public static void Insert(HOSO_DONGHOKHACHHANG chuyendm)
        {
            try
            {
                db.HOSO_DONGHOKHACHHANGs.InsertOnSubmit(chuyendm);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Update()
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        public static DataTable getListGanHopByDate(string ngay)
        {
            string sql = " SELECT ID,DANHBO, LOTRINH, HOTEN, DIACHI, HOPDONG, GB, DM, HIEU, CO, GHICHU  FROM TB_GANHOPBV WHERE TODS='" + DAL.SYS.C_USERS._toDocSo + "' AND NGAYLAP='" + ngay + "' ORDER BY DANHBO ASC ";
            return LinQConnection.getDataTable(sql);

        }
        public static int DeleteBYID(string id)
        {
            return LinQConnection.ExecuteCommand("DELETE FROM TB_GANHOPBV WHERE ID='" + id + "'");
        }


        public static HOSO_DONGHOKHACHHANG findByDanhBo(string danhbo)
        {
            try
            {
                var query = from q in db.HOSO_DONGHOKHACHHANGs where q.DBDongHoNuoc == danhbo orderby q.NgayCapNhat descending select q;
                return query.First();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

    }
}