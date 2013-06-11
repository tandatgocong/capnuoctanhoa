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
            string sql = "SELECT DHN_SOBANGKE, DHN_DANHBO,DHN_HUYCAMKET,DHN_CAMKET,DHN_BAMHI,DHN_GHICHU,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',CODH,SOTHANDH,DHN_DOT,DHN_KY,DHN_NAM,DHN_NGAYGHINHAN,DHN_TODS,LOTRINH";
            sql += " FROM DK_GIAMHOADON GHD,TB_DULIEUKHACHHANG kh WHERE  kh.DANHBO=GHD.DHN_DANHBO AND DHN_SOBANGKE='" + sobangke + "' ORDER BY DHN_DANHBO ASC ";
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
        public static int UpdateSoBangKe(string danhbo,string sobangke,string ngayghinhan,string nam,string tods,string ghichu,string bamchi,int ky,string dot,string chisoky,string huycamket)
        {
            int kq = 0;
            string sql = "UPDATE DK_GIAMHOADON set DHN_NGAYGHINHAN='" + ngayghinhan + "',DHN_NAM=" + nam + ",DHN_TODS='" + tods + "',DHN_GHICHU='" + ghichu + "',DHN_DOT='" + dot + "',DHN_KY='"+chisoky +"'";
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
        //public static int Insert(DK_GIAMHOADON ghd)
        //{
        //    int kq = 0;
        //    string sql = "insert into DK_GIAMHOADON(DHN_SOBANGKE,DHN_NAM,DHN_DANHBO,DHN_NGAYGHINHAN,DHN_KY,DHN_DOT,DHN_TODS,DHN_CAMKET,DHN_BAMHI,DHN_GHICHU,DHN_HUYCAMKET)values "('DHN_SOBANGKE='" + ghd.DHN_SOBANGKE +"' DHN_NAM='"+ ghd.DHN_NAM +"' DHN_DANHBO='" + ghd.DHN_DANHBO+ "')";
        //    kq = LinQConnection.ExecuteCommand_(sql);
        //    return kq;
        //}
       
        public static int DeleteThongTin(DK_GIAMHOADON ghd)
        {
            int kq = 0;
            string sql = "delete from DK_GIAMHOADON where DHN_DANHBO='" + ghd.DHN_DANHBO + "' and DHN_SOBANGKE='"+ ghd.DHN_SOBANGKE +"' ";
            kq = LinQConnection.ExecuteCommand_(sql);
            return kq;
        }
    }
}
