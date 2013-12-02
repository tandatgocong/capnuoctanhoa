using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.DAL.SYS
{
    public class C_Quan
    {
        public static List<QUAN> getList(){
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var quan = from p in data.QUANs select p;
           return quan.ToList();
        }
        public static QUAN finByMaQuan(int maquan) { 
             CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
             var quan = from q in data.QUANs where q.MAQUAN == maquan select q;
             return quan.SingleOrDefault();
        }
        public static QUAN finbyTenQuan(string tenquan) {
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var quan = from q in data.QUANs where q.TENQUAN == tenquan select q;
            return quan.SingleOrDefault();
        }
    }
}
