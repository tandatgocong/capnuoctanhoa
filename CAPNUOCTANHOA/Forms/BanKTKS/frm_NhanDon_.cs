using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frm_NhanDon_ : UserControl
    {
        public frm_NhanDon_()
        {
            InitializeComponent();
            FromLoad();
        }
        void FromLoad() {
            dateNgayNhan.Value = DateTime.Now.Date;
            cbLoaiDon.DataSource = DAL.LinQConnection.getDataTable("SELECT * FROM KTKS_LOAIDON");
            cbLoaiDon.DisplayMember = "TENLOAI";
            cbLoaiDon.ValueMember = "MALOAI";

            cbNhomThongTin.DataSource = DAL.LinQConnection.getDataTable("SELECT MANHOM, (CONVERT(VARCHAR(50),MANHOM) + '. '+ TENNHOM) AS 'TENNHOM' FROM KTKS_NHOMTHONGTIN ORDER BY MANHOM  ASC");
            cbNhomThongTin.DisplayMember = "TENNHOM";
            cbNhomThongTin.ValueMember = "MANHOM";

        }

    }
}
