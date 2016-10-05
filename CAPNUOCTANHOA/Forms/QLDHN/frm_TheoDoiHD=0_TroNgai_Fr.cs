using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class frm_TheoDoiHD_0_TroNgai_Fr : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_CapNhatTroNgaiThay).Name);


        public frm_TheoDoiHD_0_TroNgai_Fr()
        {
            InitializeComponent();            
            
            frm_TheoDoiHD_0_TroNgai baothay = new frm_TheoDoiHD_0_TroNgai();
          
            panel1.Controls.Add(baothay);
           

        }
    }
}