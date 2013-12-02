using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;
using System.Collections;
using CAPNUOCTANHOA.Utilities;
namespace CAPNUOCTANHOA.DAL.SYS
{
    public class C_Phuong
    {
        public static List<PHUONG> getListByQuan(int maquan) {
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var lisPhuong = from phuong in data.PHUONGs where phuong.MAQUAN == maquan select phuong;
            return lisPhuong.ToList();
        }
        public static List<PHUONG> getListPhuongAdmin()
        {
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var lisPhuong = from phuong in data.PHUONGs  select phuong;
            return lisPhuong.ToList();
        }
        public static PHUONG finbyPhuong(int maquan, string maphuong) {
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var phuong = from p in data.PHUONGs where p.MAQUAN == maquan && p.MAPHUONG == maphuong select p;
            return phuong.SingleOrDefault();
        }
        public static PHUONG finbyTenPhuong(int maquan, string tenPhuong) {
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var phuong = from p in data.PHUONGs where p.MAQUAN == maquan && p.TENPHUONG == tenPhuong select p;
            return phuong.SingleOrDefault();
        }
        
        public static ArrayList getListPhuong()
        {
            ArrayList list = new ArrayList();
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var lisPhuong = from phuong in data.PHUONGs select phuong;
            foreach (var a in lisPhuong)
            {
                list.Add(new AddValueCombox(a.TENPHUONG, a.MAPHUONG));
            }
            return list;
        }
        public static List<PHUONG> ListPhuongByTenPhuong(string tenPhuong)
        {
            CapNuocTanHoaDataContext data = new CapNuocTanHoaDataContext();
            var lisPhuong = from phuong in data.PHUONGs where phuong.TENPHUONG == tenPhuong select phuong;
            return lisPhuong.ToList();
        }
    }
}
