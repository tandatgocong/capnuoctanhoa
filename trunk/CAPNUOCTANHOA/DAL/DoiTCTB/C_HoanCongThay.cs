using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Data;

namespace CAPNUOCTANHOA.DAL.DoiTCTB
{
    public static class C_HoanCongThay
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_HoanCongThay).Name);
        static CapNuocTanHoaDataContext db = new CapNuocTanHoaDataContext();
        
        public static DataTable getBangKeBaoThay(string sobangke)
        {
            string sql = "SELECT ID_BAOTHAY,DHN_LOAIBANGKE,DHN_SOBANGKE, DHN_DANHBO,HOTEN, SONHA + ' ' +TENDUONG AS 'DIACHI',DHN_NGAYBAOTHAY,DHN_NGAYGAN,DHN_CHITHAN,DHN_CHIGOC,DHN_HIEUDHN,DHN_CODH,DHN_SOTHAN,DHN_CHISO,DHN_LYDOTHAY ";
            sql += " , HCT_CHISOGO, HCT_SOTHANGO, HCT_HIEUDHNGAN, HCT_CODHNGAN, HCT_SOTHANGAN, HCT_CHISOGAN, HCT_LOAIDHGAN, HCT_NGAYGAN, HCT_CHITHAN, HCT_CHIGOC, HCT_TRONGAI, HCT_LYDOTRONGAI  ";
            sql += " FROM TB_THAYDHN thay,TB_DULIEUKHACHHANG kh WHERE kh.DANHBO=thay.DHN_DANHBO AND (DHN_TODS+'-'+CONVERT(VARCHAR(20),DHN_SOBANGKE)) = '" + sobangke + "' ORDER BY DHN_STT ASC ";
            return LinQConnection.getDataTable(sql);
        }
    }
}
