using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using CAPNUOCTANHOA.LinQ;
using System.Configuration;
 

namespace CAPNUOCTANHOA
{
    public partial class frm_Main : Form
    {
      private static readonly ILog log = LogManager.GetLogger(typeof(frm_Main).Name);
        public frm_Main()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            dataGridView1.DataSource = DAL.OledbConnection.getDataTable(ConfigurationManager.ConnectionStrings["CAPNUOCTANHOA.Properties.Settings.AccessFile"].ConnectionString,"SELECT * FROM LyLichDHN WHERE DOT='20'"); 

        }
    }
}
