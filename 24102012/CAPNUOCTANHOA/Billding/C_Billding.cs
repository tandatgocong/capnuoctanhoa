using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNUOCTANHOA.Billding
{
    class C_Billding
    {
        public BILLING set55field(string[] words)
        {
            BILLING bill = new BILLING();
            bill.KHU = words[0].Replace("\"", "");
            bill.DOT = words[1].Replace("\"", "");
            bill.DBO = words[2].Replace("\"", "");
            bill.CD = words[3].Replace("\"", "");
            bill.CULY = words[4].Replace("\"", "");
            bill.MSTLK = words[5].Replace("\"", "");
            bill.GIAOUOC = words[6].Replace("\"", "");
            bill.HOTEN = words[7].Replace("\"", "");
            bill.DC1 = words[8].Replace("\"", "");
            bill.DC2 = words[9].Replace("\"", "");
            bill.MSKH = words[10].Replace("\"", "");
            bill.MSCQ = words[11].Replace("\"", "");
            bill.CB = words[12].Replace("\"", "");
            bill.SH = words[13].Replace("\"", "");
            bill.HCSN = words[14].Replace("\"", "");
            bill.SX = words[15].Replace("\"", "");
            bill.DV = words[16].Replace("\"", "");
            bill.TGDM = words[17].Replace("\"", "");
            bill.KY = words[18].Replace("\"", "");
            bill.NAM = words[19].Replace("\"", "");
            bill.CODE = words[20].Replace("\"", "");
            bill.CODEFU = words[21].Replace("\"", "");
            bill.CSCU = words[22].Replace("\"", "");
            bill.CSMOI = words[23].Replace("\"", "");
            bill.RT = words[24].Replace("\"", "");
            bill.NGAY_DS_KT = words[25].Replace("\"", "");
            bill.NGAY_DS_KN = words[26].Replace("\"", "");
            bill.CHUKY_DS = words[27].Replace("\"", "");
            bill.LNCC = words[28].Replace("\"", "");
            bill.LNCT = words[29].Replace("\"", "");
            bill.LN_BU_TOITHIEU = words[30].Replace("\"", "");
            bill.LN_SH = words[31].Replace("\"", "");
            bill.LN_HCSN = words[32].Replace("\"", "");
            bill.LN_SX = words[33].Replace("\"", "");
            bill.LN_DV = words[34].Replace("\"", "");
            bill.CUON_GCS = words[35].Replace("\"", "");
            bill.CUON_STT = words[36].Replace("\"", "");
            bill.GIABAN = words[37].Replace("\"", "");
            bill.THUEGTGT = words[38].Replace("\"", "");
            bill.PHIBVMT = words[39].Replace("\"", "");
            bill.TONGCONG = words[20].Replace("\"", "");
            bill.GIABAN_BU_TOITHIEU = words[41].Replace("\"", "");
            bill.THUEGTGT_BU_TOITHIEU = words[42].Replace("\"", "");
            bill.PHIBVMT_BU_THOITHIEU = words[43].Replace("\"", "");
            bill.TONGCONG_BU_TOITHIEU = words[44].Replace("\"", "");
            bill.SO_PHATTHANH = words[45].Replace("\"", "");
            bill.SO_HOADON = words[46].Replace("\"", "");
            //bill.NGAY_PHATHANH = words[47].Replace("\"","");
            bill.QUAN = words[48].Replace("\"", "");
            bill.PHUONG = words[49].Replace("\"", "");
            bill.SODHN = words[50].Replace("\"", "");
            bill.MSTHUE = words[51].Replace("\"", "");
            bill.TILE_TIEUTHU = words[52].Replace("\"", "");
            //bill.NGAY_GANDH = words[53].Replace("\"","");
            bill.SOHO = words[54].Replace("\"", "");
            return bill;
        }
        public BILLING set56field(string[] words)
        {
            BILLING bill = new BILLING();
            bill.KHU = words[0].Replace("\"", "");
            bill.DOT = words[1].Replace("\"", "");
            bill.DBO = words[2].Replace("\"", "");
            bill.CD = words[3].Replace("\"", "");
            bill.CULY = words[4].Replace("\"", "");
            bill.MSTLK = words[5].Replace("\"", "");
            bill.GIAOUOC = words[6].Replace("\"", "");
            bill.HOTEN = words[7].Replace("\"", "");
            bill.DC1 = words[8].Replace("\"", "");
            bill.DC2 = words[9].Replace("\"", "") + " , " + words[10].Replace("\"", "");
            bill.MSKH = words[11].Replace("\"", "");
            bill.MSCQ = words[12].Replace("\"", "");
            bill.CB = words[13].Replace("\"", "");
            bill.SH = words[14].Replace("\"", "");
            bill.HCSN = words[15].Replace("\"", "");
            bill.SX = words[16].Replace("\"", "");
            bill.DV = words[17].Replace("\"", "");
            bill.TGDM = words[18].Replace("\"", "");
            bill.KY = words[19].Replace("\"", "");
            bill.NAM = words[20].Replace("\"", "");
            bill.CODE = words[21].Replace("\"", "");
            bill.CODEFU = words[22].Replace("\"", "");
            bill.CSCU = words[23].Replace("\"", "");
            bill.CSMOI = words[24].Replace("\"", "");
            bill.RT = words[25].Replace("\"", "");
            //bill.NGAY_DS_KT = words[26].Replace("\"","");
            //bill.NGAY_DS_KN = words[27].Replace("\"","");
            bill.CHUKY_DS = words[28].Replace("\"", "");
            bill.LNCC = words[29].Replace("\"", "");
            bill.LNCT = words[30].Replace("\"", "");
            bill.LN_BU_TOITHIEU = words[31].Replace("\"", "");
            bill.LN_SH = words[32].Replace("\"", "");
            bill.LN_HCSN = words[33].Replace("\"", "");
            bill.LN_SX = words[34].Replace("\"", "");
            bill.LN_DV = words[35].Replace("\"", "");
            bill.CUON_GCS = words[36].Replace("\"", "");
            bill.CUON_STT = words[37].Replace("\"", "");
            bill.GIABAN = words[38].Replace("\"", "");
            bill.THUEGTGT = words[39].Replace("\"", "");
            bill.PHIBVMT = words[40].Replace("\"", "");
            bill.TONGCONG = words[41].Replace("\"", "");
            bill.GIABAN_BU_TOITHIEU = words[42].Replace("\"", "");
            bill.THUEGTGT_BU_TOITHIEU = words[43].Replace("\"", "");
            bill.PHIBVMT_BU_THOITHIEU = words[44].Replace("\"", "");
            bill.TONGCONG_BU_TOITHIEU = words[45].Replace("\"", "");
            bill.SO_PHATTHANH = words[46].Replace("\"", "");
            bill.SO_HOADON = words[47].Replace("\"", "");
            //bill.NGAY_PHATHANH = words[48].Replace("\"","");
            bill.QUAN = words[49].Replace("\"", "");
            bill.PHUONG = words[50].Replace("\"", "");
            bill.SODHN = words[51].Replace("\"", "");
            bill.MSTHUE = words[51].Replace("\"", "");
            bill.TILE_TIEUTHU = words[53].Replace("\"", "");
            // bill.NGAY_GANDH = words[54].Replace("\"","");
            bill.SOHO = words[55].Replace("\"", "");
            return bill;
        }

        public void Print(BILLING bill)
        {
            Console.WriteLine(bill.QUAN);
        }


    }
}
