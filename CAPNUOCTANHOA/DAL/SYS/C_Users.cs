using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.DAL.SYS
{
    public class C_USERS
    {
        public static string _fullName = null;
        public static string _userName = null;
        public static string _roles = null;
        public static string _maphong = null;
        public static string _toDocSo = null;
        public static string _tenDocSo = null;
        public static string _gioihan = "";
        public bool AddNew(SYS_USER user)
        {
            try
            {
                CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
                db.SYS_USERs.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }
        public static string KHVTDuyet()
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            var data = from user in db.SYS_USERs where user.DUYET == true && user.MAPHONG.Equals("VTTH") == true select user;
           return data.SingleOrDefault().USERNAME;     
        }
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        public static SYS_USER findByUserName(string username)
        {

            var data = from user in db.SYS_USERs where user.USERNAME == username select user;
            SYS_USER us = data.SingleOrDefault();     
            return us;
        }
        public static SYS_USER findByToDS(string tods) {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            var data = from user in db.SYS_USERs where user.TODS == tods select user;
            if (data.ToList().Count > 0) {
                return data.ToList()[0];
            }
            return null;
        }
        public static SYS_USER findByFullName(string fullName)
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            var data = from user in db.SYS_USERs where user.FULLNAME == fullName select user;
            SYS_USER us = data.SingleOrDefault();
            return us;
        }
        public static bool UpdateUser()
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            { }
            return false;
        }
        public bool DeleteUser(SYS_USER user)
        {
            try
            {
                CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
                db.SYS_USERs.DeleteOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {}
            return false;
        }
        public  DataTable getList(string username, string fullName, string rolesId)
        {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            db.Connection.Open();
            string sql = " SELECT  USERNAME ,FULLNAME ,TENPHONG,ROLENAME, CASE WHEN CAP='0' THEN N'Phó Phòng'  WHEN CAP='1' THEN N'Tổ Trưởng' ELSE N'Nhân Viên' END as 'CHUCVU',  CASE WHEN ENABLED='True' THEN N'Kích Hoạt' ELSE N'Chưa Kích Hoạt' END as 'TINHTRANG'  ";
            sql +="  FROM USERS u, ROLES  r, PHONGBANDOI p ";
            sql +=" WHERE u.ROLEID = r.ROLEID AND u.MAPHONG=p.MAPHONG ";
            if(username!= null && !"".Equals(username)){
                sql += " AND USERNAME LIKE '%"+ username +"%'";
            }
            
            if (fullName != null && !"".Equals(fullName))
            {
                sql += " AND FULLNAME LIKE '%" + fullName + "%'";
            }

            if (rolesId != null && !"".Equals(rolesId))
            {
                sql += " AND USERS.ROLEID = '" + rolesId + "'";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.Connection.Close();
           return table;
        }
        public bool UserLogin(string userName, string passWord) {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            var data = from user in db.SYS_USERs where user.USERNAME == userName && user.PASSWORD == passWord && user.ENABLED ==true select user;
            SYS_USER userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
                SYS_USER userlogin = (SYS_USER)data.SingleOrDefault();
                _userName = userlogin.USERNAME;
                _fullName = userlogin.FULLNAME;
                _roles = userlogin.ROLEID;
                _maphong = userlogin.MAPHONG;
                _toDocSo = userlogin.TODS;
                _gioihan = userlogin.GIOIHAN;
                return true;
            }
            return false;
        }

        //public static List<USER> getAll() {
        //    CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        //    var data = from user in db.USERs   select user;       
        //    return data.ToList();
        //}
        public static List<SYS_USER> getUserByMaPhongAndLevel(string maphong, int cap)
        {

            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            var data = from user in db.SYS_USERs where user.MAPHONG == maphong && user.CAP == cap select user;
            return data.ToList();

        }
        public static int ChangePass(string username, string passold, string passNew) {
            CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
            var data = from user in db.SYS_USERs where user.USERNAME == username select user;
            SYS_USER u = data.SingleOrDefault();
            if(passold.Equals(Utilities.LogIn.Decrypt(u.PASSWORD))==true){
                try
                {
                    u.PASSWORD = Utilities.LogIn.Encrypt(passNew);
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception)
                {
                     
                }
                return 0;
            }
            return -1;

        }

    }
}
