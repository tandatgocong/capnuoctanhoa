using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GIAMHOADON.LinQ;

namespace GIAMHOADON.DAL.SYS
{
    public class C_Quan
    {
        public static List<QUAN> getList(){
            GIAMHOADONDataContext data = new GIAMHOADONDataContext();
            var quan = from p in data.QUANs select p;
           return quan.ToList();
        }
        public static QUAN finByMaQuan(int maquan) { 
             GIAMHOADONDataContext data = new GIAMHOADONDataContext();
             var quan = from q in data.QUANs where q.MAQUAN == maquan select q;
             return quan.SingleOrDefault();
        }
        public static QUAN finbyTenQuan(string tenquan) {
            GIAMHOADONDataContext data = new GIAMHOADONDataContext();
            var quan = from q in data.QUANs where q.TENQUAN == tenquan select q;
            return quan.SingleOrDefault();
        }
    }
}
