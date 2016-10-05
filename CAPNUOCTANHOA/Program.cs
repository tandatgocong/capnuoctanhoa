using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAPNUOCTANHOA.LayDuLieu;
using System.Threading;
using System.Globalization;
using CAPNUOCTANHOA.Forms.QLDHN;

namespace CAPNUOCTANHOA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            // Sets the UI culture to French (France)
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frm_TheoDoiHD_0_TroNgai_Fr());
           Application.Run(new frm_Main());
             
        }
    }
}
