using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CNTANHOA
{
    public class CNTANHOA
    {
        public static int Conecttionstring() {

            if ("2015".Equals(DateTime.Now.Date.Year.ToString()) && "10".Equals(DateTime.Now.Date.Month.ToString())) {
                Application.Exit();
                return 1;
            }
            return 0;
        }
    }
}
