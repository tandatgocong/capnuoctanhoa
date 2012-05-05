using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.TimKiem
{
    class C_TimKiem
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_TimKiem).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

         public static DataTable search(  string searchBangKe,
                                                    string searchDanhBo,
                                                    string searchTenKH,
                                                    string searchDiaChi,
                                                    string searchLoTrinh,
                                                    string searchNgayGan)
        {
            string sql = "SELECT * FROM V_SEARCH WHERE DHN_DANHBO IS NOT NULL ";
            if (!"".Equals(searchBangKe))
            {
                sql += " AND SO_BANGKE='" + searchBangKe + "'";

            }
            if (!"".Equals(searchDanhBo))
            {
                sql += " AND DHN_DANHBO='" + searchDanhBo + "'";
            }
            if (!"".Equals(searchTenKH))
            {
                sql += " AND HOTEN LIKE '%" + searchTenKH + "%'";
            }
            if (!"".Equals(searchDiaChi))
            {
                sql += " AND DIACHI LIKE '%" + searchDiaChi + "%'";
            }
            if (!"".Equals(searchLoTrinh))
            {
                sql += " AND LOTRINH='" + searchLoTrinh + "'";
            }
            if (!"".Equals(searchNgayGan) && !"1/1/0001".Equals(searchNgayGan))
            {
                sql += " AND CONVERT(DATETIME,HCT_NGAYGAN,103) ='" + searchNgayGan + "' ";
            }
            sql += " ORDER BY DHN_NGAYBAOTHAY DESC ";
            return LinQConnection.getDataTable(sql);
        }
 

             ////replace(DUONG,' ','')
   
    }
}
