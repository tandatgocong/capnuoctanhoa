using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTANHOA.LinQ;
using System.Data.SqlClient;
using log4net;
using System.Data;
namespace CAPNUOCTANHOA.DAL.QLDHN
{
    class C_HoaDon_0
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_HoaDon_0).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();

        public static DataTable getBangKeBaoThay(int sobangke)
        {
            string sql = "SELECT GHD.ID,DHN_SOBANGKE, DHN_DANHBO,DHN_HUYCAMKET,DHN_CAMKET,DHN_BAMHI,DHN_GANMOI,DHN_GHICHU,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_TODS,LOTRINH";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE  kh.DANHBO=GHD.DHN_DANHBO AND DHN_SOBANGKE='" + sobangke + "' ORDER BY DHN_DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getDanhBo (string danhbo)
        {
            string sql = "SELECT GHD.ID,DHN_SOBANGKE, DHN_DANHBO,DHN_HUYCAMKET,DHN_CAMKET,DHN_BAMHI,DHN_GHICHU,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_TODS,LOTRINH";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE  kh.DANHBO=GHD.DHN_DANHBO AND DHN_DANHBO='" + danhbo + "' ORDER BY DHN_DANHBO ASC ";
            return LinQConnection.getDataTable(sql);

        }
        public static DataTable DataSoSanhKyTruoc(string sobangke,string danhbo,string ky,string nam)
        {
            string sql = "SELECT DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_CAMKET,DHN_BAMHI,DHN_TODS,DHN_GHICHU,LOTRINH,DHN_HUYCAMKET";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=GHD.DHN_DANHBO AND GHD.DHN_DANHBO='"+ danhbo +"' AND DHN_KY='"+ ky +"' AND DHN_NAM="+ nam +" AND DHN_SOBANGKE='"+ sobangke +"' ORDER BY DHN_DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static int getMaxBangKe()
        {
            string sql = "SELECT MAX(DHN_SOBANGKE)  FROM DK_GIAMHOADON";
            return LinQConnection.ExecuteCommand(sql);
        }
        public static DataTable getBangKeBaoThayCamKet(int sobangke)
        {
            string sql = "SELECT DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_CAMKET,DHN_TODS,DHN_GHICHU,LOTRINH,DHN_HUYCAMKET";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=GHD.DHN_DANHBO AND (DHN_CAMKET <>'' or DHN_CAMKET is not null ) AND DHN_SOBANGKE='" + sobangke + "' ORDER BY DHN_DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getBangKeBaoThayBamChi(int sobangke)
        {
            string sql = "SELECT DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_BAMHI,DHN_TODS,DHN_GHICHU,LOTRINH,DHN_HUYCAMKET";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE (DHN_BAMHI <>'' or DHN_BAMHI is not null) AND kh.DANHBO=GHD.DHN_DANHBO AND DHN_SOBANGKE='" + sobangke + "' ORDER BY DHN_DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getBangKeHuyCamKet(int sobangke)
        {
            string sql = "SELECT DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_BAMHI,DHN_TODS,DHN_GHICHU,LOTRINH,DHN_HUYCAMKET";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE (DHN_HUYCAMKET <>'' or DHN_HUYCAMKET is not null) AND kh.DANHBO=GHD.DHN_DANHBO AND DHN_SOBANGKE='" + sobangke + "' ORDER BY DHN_DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getBangKeBaoThayGanMoi(int sobangke)
        {
            string sql = "SELECT DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_BAMHI,DHN_TODS,DHN_GHICHU,LOTRINH,DHN_GANMOI";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE (DHN_GANMOI <>'' or DHN_GANMOI is not null) AND kh.DANHBO=GHD.DHN_DANHBO AND DHN_SOBANGKE='" + sobangke + "' ORDER BY DHN_DANHBO ASC ";
            return LinQConnection.getDataTable(sql);
        }
        public static int UpdateSoBangKe(string danhbo,string sobangke,string ngayghinhan,string nam,string tods,string ghichu,string bamchi,int ky,string dot,string chisoky,string huycamket,string ganmoi,string chuadanhdau)
        {
            int kq = 0;
            string sql = "UPDATE DK_GIAMHOADON set DHN_NGAYGHINHAN='" + ngayghinhan + "',DHN_NAM=" + nam + ",DHN_TODS='" + tods + "',DHN_GHICHU=N'" + ghichu + "',DHN_DOT='" + dot + "',DHN_KY='"+chisoky +"'";
            if(bamchi=="X"){
                sql = sql + ",DHN_BAMHI='" + bamchi  + "'";
            }
            else if (bamchi != "X")
            {
                sql = sql + ",DHN_BAMHI=null";
            }
            if (ky > 0)
            {
                sql = sql + ",DHN_CAMKET='" + ky.ToString() + "'";
            }
            else if(ky==0)
            {
                sql = sql + ",DHN_CAMKET=null";
            }
            if (huycamket == "X")
            {
                sql = sql + ",DHN_HUYCAMKET='" + huycamket + "'";
            }
            else if (huycamket != "X")
            {
                sql = sql + ",DHN_HUYCAMKET=null";
            }
            if (ganmoi == "X")
            {
                sql = sql + ",DHN_GANMOI='" + ganmoi +"'";
            }
            else if (ganmoi != "X")
            {
                sql = sql + ",DHN_GANMOI=null";
            }
            if (chuadanhdau == "X")
            {
                sql = sql + ",DHN_CHUADANHDAU='" + chuadanhdau + "'";
            }
            else if (chuadanhdau != "X")
            {
                sql = sql + ",DHN_CHUADANHDAU =null";
            }

            sql = sql + ",DHN_MODIFYDATE=getDate(),DHN_MODIFYBY='"+DAL.SYS.C_USERS._userName+"' where DHN_DANHBO='" + danhbo + "' and DHN_SOBANGKE='" + sobangke + "'";
            kq = LinQConnection.ExecuteCommand_(sql);
            return kq;
        }
        public static void Insert(DK_GIAMHOADON th_dhn)
        {
            try
            {
                db.DK_GIAMHOADONs.InsertOnSubmit(th_dhn);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
       

        public static int DeleteThongTin(string id)
        {
            int kq = 0;
            string sql = "delete from DK_GIAMHOADON where ID='" + id + "'";
            kq = LinQConnection.ExecuteCommand_(sql);
            return kq;
        }
      
       
    }
}
