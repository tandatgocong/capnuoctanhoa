using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace CAPNUOCTANHOA.Forms.BanKTKS
{
    public partial class frm_DMChungCu : UserControl
    {
        public frm_DMChungCu()
        {
            InitializeComponent();
            loadCombobox();
        }
        void loadCombobox()
        {
            string recordKT = ConfigurationManager.AppSettings["locc"].ToString();
            string[] words = Regex.Split(recordKT, ",");
            for (int i = 0; i < words.Length; i++)
            {
                cbLoCC.Items.Add(words[i]);
            }
        }
    }
}
