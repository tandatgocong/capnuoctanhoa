using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class tab_ChiaLoTrinh : UserControl
    {
        int tods = 0;
        public tab_ChiaLoTrinh()
        {
            InitializeComponent();
            cbChiLoTrinhDotDS.SelectedIndex = 0;
            if ("TB02".Equals(DAL.SYS.C_USERS._toDocSo.Trim()))
            {
                tods = 2;
                this.lbToDocSo.Text = "     TỔ TÂN BÌNH 02";
                List<MAYDOCSO> list = DAL.DULIEUKH.C_PhienLoTrinh.getListMayDS(2);
                this.cbTuMayDocSo.DataSource = list;
                this.cbTuMayDocSo.DisplayMember = "MAY";
                this.cbTuMayDocSo.DisplayMember = "MAY";
                ///
                this.cbDenMayDocSo.DataSource = DAL.DULIEUKH.C_PhienLoTrinh.getListMayDS(2);
                this.cbDenMayDocSo.DisplayMember = "MAY";
                this.cbDenMayDocSo.DisplayMember = "MAY";
            }
            else if ("TP".Equals(DAL.SYS.C_USERS._toDocSo.Trim()))
            {
                tods = 3;
                List<MAYDOCSO> list = DAL.DULIEUKH.C_PhienLoTrinh.getListMayDS(3);
                this.lbToDocSo.Text = "     TỔ TÂN PHÚ";
                this.cbTuMayDocSo.DataSource = list;
                this.cbTuMayDocSo.DisplayMember = "MAY";
                this.cbTuMayDocSo.DisplayMember = "MAY";
                ///
                this.cbDenMayDocSo.DataSource = DAL.DULIEUKH.C_PhienLoTrinh.getListMayDS(3);
                this.cbDenMayDocSo.DisplayMember = "MAY";
                this.cbDenMayDocSo.DisplayMember = "MAY";
            }
            else if ("TB01".Equals(DAL.SYS.C_USERS._toDocSo.Trim()))
            {
                tods = 1;
                List<MAYDOCSO> list = DAL.DULIEUKH.C_PhienLoTrinh.getListMayDS(1);
                this.lbToDocSo.Text = "     TỔ TÂN BÌNH 01";
                this.cbTuMayDocSo.DataSource = list;
                this.cbTuMayDocSo.DisplayMember = "MAY";
                this.cbTuMayDocSo.DisplayMember = "MAY";
                ///
                this.cbDenMayDocSo.DataSource = DAL.DULIEUKH.C_PhienLoTrinh.getListMayDS(1); ;
                this.cbDenMayDocSo.DisplayMember = "MAY";
                this.cbDenMayDocSo.DisplayMember = "MAY";
            }
            
        }

        public void LoadTuMayDocSo() {
            string dotds = cbChiLoTrinhDotDS.Items[cbChiLoTrinhDotDS.SelectedIndex].ToString();
            string mayds = cbTuMayDocSo.Text;
            dataDanhBoGanMoi.DataSource = DAL.DULIEUKH.C_GanMoi.getDataGanMoi(DAL.SYS.C_USERS._toDocSo, dotds, mayds);
            
            Utilities.DataGridV.formatRows(dataDanhBoGanMoi, "TU_DANHBO");
            lbTuMayDS.Text = "TỔNG SỐ " + (dataDanhBoGanMoi.Rows.Count) + " DANH BỘ";
        }
        DataTable table = null;
        public void LoadDenMayDocSo() {
            table = null;
            string dotds = cbChiLoTrinhDotDS.Items[cbChiLoTrinhDotDS.SelectedIndex].ToString();
            string mayds = cbDenMayDocSo.Text;
            if (int.Parse(dotds) < 10) {
                dotds = "0" + dotds;
            }
            if (int.Parse(mayds) < 10)
            {
                mayds = "0" + mayds;
            }
            table = DAL.DULIEUKH.C_GanMoi.getPhienLoTrinh(dotds + mayds);
            dataLoTrinh.DataSource = table;
            Utilities.DataGridV.formatRows(dataLoTrinh, "DEN_DANHBO");
            lbDenMayDocSo.Text = "TỔNG SỐ " + (dataLoTrinh.Rows.Count) + " DANH BỘ";
        }

        private void cbTuMayDocSo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTuMayDocSo();
            }
            catch (Exception)
            {
                
            }
        }

        private void cbDenMayDocSo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!"0".Equals(cbTuMayDocSo.Items[cbTuMayDocSo.SelectedIndex].ToString()))
                {
                    LoadDenMayDocSo();
                }
            }
            catch (Exception)
            {
                
            }
           
        }

        private void pictureChuyen_Click(object sender, EventArgs e)
        {
            int index = 0;
            try
            {
                index = dataLoTrinh.CurrentCell.RowIndex;
            }
            catch (Exception)
            {
                
            }
            if (index < dataLoTrinh.Rows.Count)
            { 
                index = index+1;
            }
            
            for (int i = 0; i < dataDanhBoGanMoi.Rows.Count; i++)
            {
                if ("1".Equals(dataDanhBoGanMoi.Rows[i].Cells["CHECK"].Value + ""))
                {
                    if (table != null)
                    {
                        string danhbo = dataDanhBoGanMoi.Rows[i].Cells["TU_DANHBO"].Value + "";
                        TB_GANMOI ganmoi = DAL.DULIEUKH.C_GanMoi.finByDanhBo(danhbo.Replace(" ", ""));
                        if (ganmoi != null)
                        {
                            ganmoi.CHUYEN = true;
                            DAL.DULIEUKH.C_GanMoi.Update();

                            DataRow row = table.NewRow();
                            row["DANHBO"] = dataDanhBoGanMoi.Rows[i].Cells["TU_DANHBO"].Value + "";
                            row["DIACHI"] = dataDanhBoGanMoi.Rows[i].Cells["TU_DIACHI"].Value + "";
                            row["QUANPHUONG"] = dataDanhBoGanMoi.Rows[i].Cells["TU_QP"].Value + "";
                            row["LOTRINH"] = "";
                            table.Rows.InsertAt(row, index);
                            dataLoTrinh.DataSource = table;
                            Utilities.DataGridV.formatRows(dataLoTrinh, "DEN_DANHBO");
                            lbDenMayDocSo.Text = "TỔNG SỐ " + (dataLoTrinh.Rows.Count) + " DANH BỘ";

                            dataDanhBoGanMoi.Rows.RemoveAt(i);
                            /// Insert Du Lieu Khach Hang de quan ly
                            string insert = "INSERT INTO TB_DULIEUKHACHHANG(DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,QUAN,PHUONG,GIABIEU,DINHMUC,NGAYGANDH,NGAYTHAY,HIEUDH,CODH,SOTHANDH,CHISOKYTRUOC,CODE) VALUES ";
                            insert += "('" + ganmoi.DANHBO + "','" + ganmoi.HOPDONG + "','" + ganmoi.HOTEN + "','" + ganmoi.SONHA + "','" + ganmoi.DUONG + "','" + ganmoi.MAQUAN + "','" + ganmoi.MAPHUONG + "','" + ganmoi.GIABIEU + "','" + ganmoi.DINHMUC + "','" + ganmoi.NGAYGANTLK + "','" + ganmoi.NGAYGANTLK + "','" + ganmoi.HIEU + "','" + ganmoi.COTLK + "','" + ganmoi.SOTLK + "','" + ganmoi.CHISOTLK + "','M')";
                            DAL.LinQConnection.ExecuteCommand(insert);
                           
                            // inset Table Doc So
                            string insertGM= "INSERT INTO KHACHHANG (MAQUAN,MAPHUONG,TODS, MAY, DOT, DANHBA, HOPDONG, TENKH, SO, DUONG, GB, DM, TILESH, TILEHCSN, TILESX, TILEKD, MALOTRINH,MALOTRINH2, HIEULUCKY, NAM, NGAYGAN, CHISO, TIEUTHU, CODE)";
                            insertGM+=" VALUES ('"+ganmoi.MAQUAN+"','"+ganmoi.MAPHUONG+"'," + tods + "," + cbDenMayDocSo.Text + "," + ganmoi.DOT + ",'" + ganmoi.DANHBO + "','" + ganmoi.HOPDONG + "','" + ganmoi.HOTEN + "','" + ganmoi.SONHA + "','" + ganmoi.DUONG + "'," + ganmoi.GIABIEU + "," + ganmoi.DINHMUC + ",0,0,0,0,' ',' ','" + ganmoi.HIEULUC + "'," + ganmoi.NGAYGANTLK.Value.Year + ",'" + ganmoi.NGAYGANTLK.Value.Date.ToShortDateString() + "'," + ganmoi.CHISOTLK + ",0,'M')" ;
                            DAL.DULIEUKH.C_GanMoi.InsertDocSo(insertGM);

                            /////
                        }
                        //data.update("UPDATE KHACHHANG SET MAY=" + cbDenMay.SelectedValue.ToString() + sqlTo + " WHERE ID_KH = " + gvTuMay.Rows[i].Cells["ID_KH"].Value.ToString());
            

                       
                    }
                    //DataGridViewRow row = new DataGridViewRow();

                    //dataLoTrinh.Rows.Add(row);

                    //DataGridViewCell cellDanhBo = new DataGridViewTextBoxCell();
                    //cellDanhBo.Value = dataDanhBoGanMoi.Rows[i].Cells["TU_DANHBO"].Value + "";
                    //row.Cells["DEN_DANHBO"] = cellDanhBo;

                    //DataGridViewCell cellC_LOTRINH = new DataGridViewTextBoxCell();
                    //cellC_LOTRINH.Value = "";
                    //row.Cells["C_LOTRINH"] = cellC_LOTRINH;

                    //DataGridViewCell cellM_LOTRINH = new DataGridViewTextBoxCell();
                    //cellM_LOTRINH.Value = "";
                    //row.Cells["M_LOTRINH"] = cellM_LOTRINH;

                    //DataGridViewCell cellDiACHI = new DataGridViewTextBoxCell();
                    //cellDiACHI.Value = dataDanhBoGanMoi.Rows[i].Cells["TU_DIACHI"].Value + "";
                    //row.Cells["DEN_DIACHI"] = cellDiACHI;

                    //DataGridViewCell cellQUANPHUONG = new DataGridViewTextBoxCell();
                    //cellQUANPHUONG.Value = dataDanhBoGanMoi.Rows[i].Cells["TU_QP"].Value + "";
                    //row.Cells["DEN_QUANPHUONG"] = cellQUANPHUONG;

                    

                    //string danhbo=dataDanhBoGanMoi.Rows[i].Cells["TU_DANHBO"].Value+"";
                    //TB_GANMOI ganmoi= DAL.DULIEUKH.C_GanMoi.finByDanhBo(danhbo.Replace("", ""));
                    //if (ganmoi != null) {

                    //    ganmoi.CHUYEN = true;
                    //    DAL.DULIEUKH.C_GanMoi.Update();
                    //    ///
                    //}
                    //data.update("UPDATE KHACHHANG SET MAY=" + cbDenMay.SelectedValue.ToString() + sqlTo + " WHERE ID_KH = " + gvTuMay.Rows[i].Cells["ID_KH"].Value.ToString());
                }

            }
        }
    }
}
