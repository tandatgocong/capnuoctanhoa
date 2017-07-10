using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using CAPNUOCTANHOA.DAL;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class Mess : Form
    {
        int _ticks = 0;
        public Mess(DataTable tb)
        {
            InitializeComponent();
            dataGrid.DataSource = tb;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            if (_ticks % 2 == 0)
            {
                string file =  @"c:\Windows\Media\Windows Ringin.wav";
                SoundPlayer simpleSound = new SoundPlayer(file);
                simpleSound.Play();
            }
        }

        private void bttiepnhan_Click(object sender, EventArgs e)
        {
            string listDanhBa = "";
            int flag = 0;
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                    flag++;
                    listDanhBa += ("'" + (this.dataGrid.Rows[i].Cells["sohoso"].Value + "").Replace(" ", "") + "',");
                
            }
            string sql = "UPDATE TTKH_TiepNhan SET Mess='False'  WHERE SoHoSo IN (" + listDanhBa.Remove(listDanhBa.Length - 1, 1) + ") ";
            CCallCenter.ExecuteCommand_(sql);
            timer1.Stop();
            this.Close();
        }

        private void Mess_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            timer1.Stop();
        }
    }
}