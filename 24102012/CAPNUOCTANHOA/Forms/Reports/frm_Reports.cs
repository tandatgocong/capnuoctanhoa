﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CAPNUOCTANHOA.Forms.Reports
{
    public partial class frm_Reports : Form
    {
        public frm_Reports(ReportDocument rp)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
