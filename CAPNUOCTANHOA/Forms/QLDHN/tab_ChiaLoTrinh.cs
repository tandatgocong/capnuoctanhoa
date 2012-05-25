using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAPNUOCTANHOA.LinQ;
using log4net;

namespace CAPNUOCTANHOA.Forms.QLDHN
{
    public partial class tab_ChiaLoTrinh : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(tab_ChiaLoTrinh).Name);
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

                this.txtTangBat.Text = "5";
            }
            else if ("TP".Equals(DAL.SYS.C_USERS._toDocSo.Trim()))
            {
                tods = 3;
                List<MAYDOCSO> list = DAL.DULIEUKH.C_PhienLoTrinh.getListMayDS(3);
                this.lbToDocSo.Text = "     TỔ TÂN PHÚ";
                this.txtTangBat.Text = "100";
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
                this.txtTangBat.Text = "5";
            }
            LoadTuMayDocSo();
        }
        bool flag = false;
        public void LoadTuMayDocSo()
        {


            dataDanhBoGanMoi.DataSource = DAL.DULIEUKH.C_GanMoi.getDataGanMoi(DAL.SYS.C_USERS._toDocSo, "", "0");

            Utilities.DataGridV.formatRows(dataDanhBoGanMoi, "TU_DANHBO");
            lbTuMayDS.Text = "TỔNG SỐ " + (dataDanhBoGanMoi.Rows.Count) + " DANH BỘ";
        }
        DataTable table = null;
        public void LoadDenMayDocSo()
        {
            table = null;
            string dotds = cbChiLoTrinhDotDS.Items[cbChiLoTrinhDotDS.SelectedIndex].ToString();
            string mayds = cbDenMayDocSo.Text;
            if (int.Parse(dotds) < 10)
            {
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
                if (this.cbTuMayDocSo.Text.Equals("0"))
                {
                    LoadTuMayDocSo();
                    dataDanhBoGanMoi.Columns["L_LOTRINH"].Visible = false;
                    dataDanhBoGanMoi.Columns["TMP_LOT"].Visible = true;
                    
                }
                else {
                    string dotds = cbChiLoTrinhDotDS.Items[cbChiLoTrinhDotDS.SelectedIndex].ToString();
                    string mayds = cbTuMayDocSo.Text;
                    if (int.Parse(dotds) < 10)
                    {
                        dotds = "0" + dotds;
                    }
                    if (int.Parse(mayds) < 10)
                    {
                        mayds = "0" + mayds;
                    }
                    dataDanhBoGanMoi.DataSource = DAL.DULIEUKH.C_GanMoi.getPhienLoTrinh(dotds + mayds);

                    Utilities.DataGridV.formatRows(dataDanhBoGanMoi, "TU_DANHBO");
                    lbTuMayDS.Text = "TỔNG SỐ " + (dataDanhBoGanMoi.Rows.Count) + " DANH BỘ";
                    dataDanhBoGanMoi.Columns["L_LOTRINH"].Visible = true;
                    dataDanhBoGanMoi.Columns["TMP_LOT"].Visible = false;
                
                }
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
                index = index + 1;
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

                            int ky = DateTime.Now.Month + 1;
                            int nam = DateTime.Now.Year;
                            try
                            {
                                ky = int.Parse(ganmoi.HIEULUC.Substring(0, 2));
                                nam = int.Parse(ganmoi.HIEULUC.Substring(3, 4));
                            }
                            catch (Exception)
                            {

                            }
                            //string insert = "INSERT INTO TB_DULIEUKHACHHANG(DANHBO,HOPDONG,HOTEN,SONHA,TENDUONG,QUAN,PHUONG,GIABIEU,DINHMUC,NGAYGANDH,NGAYTHAY,HIEUDH,CODH,SOTHANDH,CHISOKYTRUOC,CODE, KY,NAM) VALUES ";
                            //insert += "('" + ganmoi.DANHBO + "','" + ganmoi.HOPDONG + "','" + ganmoi.HOTEN + "','" + ganmoi.SONHA + "','" + ganmoi.DUONG + "','" + ganmoi.MAQUAN + "','" + ganmoi.MAPHUONG + "','" + ganmoi.GIABIEU + "','" + ganmoi.DINHMUC + "','" + ganmoi.NGAYGANTLK + "','" + ganmoi.NGAYGANTLK + "','" + ganmoi.HIEU + "','" + ganmoi.COTLK + "','" + ganmoi.SOTLK + "','" + ganmoi.CHISOTLK + "','M','" + ky + "','" + nam + "')";
                            //DAL.LinQConnection.ExecuteCommand(insert);

                            //// inset Table Doc So
                            //string insertGM = "INSERT INTO KHACHHANG (MAQUAN,MAPHUONG,TODS, MAY, DOT, DANHBA, HOPDONG, TENKH, SO, DUONG, GB, DM, TILESH, TILEHCSN, TILESX, TILEKD, MALOTRINH,MALOTRINH2, HIEULUCKY, NAM, NGAYGAN, CHISO, TIEUTHU, CODE,HIEU,SOTHAN)";
                            //insertGM += " VALUES ('" + ganmoi.MAQUAN + "','" + ganmoi.MAPHUONG + "'," + tods + "," + cbDenMayDocSo.Text + "," + ganmoi.DOT + ",'" + ganmoi.DANHBO + "','" + ganmoi.HOPDONG + "','" + ganmoi.HOTEN + "','" + ganmoi.SONHA + "','" + ganmoi.DUONG + "'," + ganmoi.GIABIEU + "," + ganmoi.DINHMUC + ",0,0,0,0,' ',' ','" + ganmoi.HIEULUC + "'," + ganmoi.NGAYGANTLK.Value.Year + ",'" + ganmoi.NGAYGANTLK.Value.Date.ToShortDateString() + "'," + ganmoi.CHISOTLK + ",0,'M','" + ganmoi.HIEU + "','" + ganmoi.SOTLK + "')";
                            //DAL.DULIEUKH.C_GanMoi.InsertDocSo(insertGM);

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

        private void btChoLoTrinhMoi_Click(object sender, EventArgs e)
        {
            string dotds = cbChiLoTrinhDotDS.Items[cbChiLoTrinhDotDS.SelectedIndex].ToString();
            string mayds = cbDenMayDocSo.Text;
            if (int.Parse(dotds) < 10)
            {
                dotds = "0" + dotds;
            }
            if (int.Parse(mayds) < 10)
            {
                mayds = "0" + mayds;
            }

            String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
            string id = "00000";
            for (int i = 0; i < dataLoTrinh.Rows.Count; i++)
            {
                id = obj.ID(dotds + mayds, id, "00000", int.Parse(this.txtTangBat.Text)) + "";
                dataLoTrinh.Rows[i].Cells["M_LOTRINH"].Value = id;
            }
            //MessageBox.Show(this, id);
        }

        public void CapNhatLoTrinhMoi_TB_DULIEUKHACHHANG()
        {

        }

        public void CapNhatLoTrinhMoi_TB_KHACHHANG()
        {

        }

        private void cbChiLoTrinhDotDS_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTuMayDocSo();
                LoadDenMayDocSo();
            }
            catch (Exception)
            {

            }

        }

        private void btCapNhatLoTrinhMoi_Click(object sender, EventArgs e)
        {
            try
            {
                int ky = DateTime.Now.Month + 1;
                int nam = DateTime.Now.Year;
                if (ky == 12)
                {
                    ky = 1;
                    nam = nam + 1;
                }
                else { ky = ky + 1; }



                for (int i = 0; i < dataLoTrinh.Rows.Count; i++)
                {
                    string danhbo = (dataLoTrinh.Rows[i].Cells["DEN_DANHBO"].Value + "").Replace(" ", "");
                    string C_LOTRINH = dataLoTrinh.Rows[i].Cells["C_LOTRINH"].Value + "";
                    string M_LOTRINH = dataLoTrinh.Rows[i].Cells["M_LOTRINH"].Value + "";
                    if (!"".Equals(danhbo) && !"".Equals(M_LOTRINH))
                    {
                        if (C_LOTRINH.Equals(M_LOTRINH) == false)
                        {
                            //cap nhat da cho lo trinh
                            DAL.LinQConnection.ExecuteCommand("UPDATE TB_GANMOI SET CHUYEN='True' WHERE DANHBO='" + danhbo + "'");
                            //
                            TB_YEUCAUDC dc = DAL.DULIEUKH.C_PhienLoTrinh.findByDanhBoDC(danhbo, ky, nam);
                            if (dc != null)
                            {
                                dc.LTCU = C_LOTRINH;
                                dc.LTMOI = M_LOTRINH;
                                dc.KY = ky;
                                dc.NAM = nam;
                                dc.DACHUYEN = false;
                                dc.CREATEDATE = DateTime.Now;
                                dc.CREATEBY = DAL.SYS.C_USERS._userName;
                                DAL.DULIEUKH.C_PhienLoTrinh.Update();
                            }
                            else
                            {
                                dc = new TB_YEUCAUDC();
                                dc.DANHBO = danhbo;
                                dc.LTCU = C_LOTRINH;
                                dc.LTMOI = M_LOTRINH;
                                dc.KY = ky;
                                dc.NAM = nam;
                                dc.DACHUYEN = false;
                                dc.CREATEDATE = DateTime.Now;
                                dc.CREATEBY = DAL.SYS.C_USERS._userName;
                                DAL.DULIEUKH.C_PhienLoTrinh.InsertYeuCauDC(dc);
                            }

                        }
                        DAL.DULIEUKH.C_PhienLoTrinh.CapNhatLoTrinh_DOCSO(danhbo.Replace(" ", ""), M_LOTRINH.Replace(" ", ""));
                        DAL.DULIEUKH.C_PhienLoTrinh.CapNhatLoTrinh_KHACHHANG(danhbo.Replace(" ", ""), M_LOTRINH.Replace(" ", ""));
                    }
                }
                MessageBox.Show(this, "Cập Nhật Lộ Trình Mới Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTuMayDocSo();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(this, "Cập Nhật Lộ Trình Mới Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataLoTrinh_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataLoTrinh, "DEN_DANHBO");
        }

        /*
             private Rectangle dragBoxFromMouseDown;
             private int rowIndexFromMouseDown;
             private int rowIndexOfItemUnderMouseToDrop;

             private void dataLoTrinh_MouseMove(object sender, MouseEventArgs e)
             {
                 if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                 {
                     if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                     {
                         DragDropEffects dropEffect = dataLoTrinh.DoDragDrop(dataLoTrinh.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                     }
                 }
             }

             private void dataLoTrinh_MouseDown(object sender, MouseEventArgs e)
             {
                 rowIndexFromMouseDown = dataLoTrinh.HitTest(e.X, e.Y).RowIndex;
                 if (rowIndexFromMouseDown != -1)
                 {
                     Size dragSize = SystemInformation.DragSize;
                     dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                 }
                 else
                 {
                     dragBoxFromMouseDown = Rectangle.Empty;
                 }
             }

             private void dataLoTrinh_DragOver(object sender, DragEventArgs e)
             {
                 e.Effect = DragDropEffects.Move;
             }

             private void dataLoTrinh_DragDrop(object sender, DragEventArgs e)
             {
                 //Point clientPoint = dataLoTrinh.PointToClient(new Point(e.X, e.Y));
                 //if (e.Effect == DragDropEffects.Move)
                 //{
                 //    DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                 //    dataLoTrinh.Rows.RemoveAt(rowIndexFromMouseDown);
                 //    dataLoTrinh.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
                 //}
                 Point clientPoint = dataLoTrinh.PointToClient(new Point(e.X, e.Y));
                 rowIndexOfItemUnderMouseToDrop = dataLoTrinh.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                 DataGridView.HitTestInfo hit = dataLoTrinh.HitTest(clientPoint.X, clientPoint.Y);
            
                 DataGridViewRow dgvr = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                 object[] celldata = new object[dgvr.Cells.Count];
                 for (int col = 0; col < dgvr.Cells.Count; col++)
                 {
                     celldata[col] = dgvr.Cells[col].Value;
                 }
                 DataRow row = table.NewRow();
                 row["DANHBO"] = celldata[1] + "";
                 row["DIACHI"] = celldata[2] + "";
                 row["QUANPHUONG"] = celldata[3] + "";
                 row["LOTRINH"] = "";
                 dgvr.DataGridView.Rows.Remove(dgvr);
                 MessageBox.Show(this, hit.RowIndex+"");
                 table.Rows.InsertAt(row, hit.RowIndex);
            
                 dataLoTrinh.DataSource=table;
           
             }
             */
        string _DanhBo = "";
        string _diachi = "";
        string _quanPhuong = "";
        string _lotrinh = "";
        private void menuCut_Click(object sender, EventArgs e)
        {

            _DanhBo = dataLoTrinh.Rows[dataLoTrinh.CurrentRow.Index].Cells["DEN_DANHBO"].Value + "";
            _diachi = dataLoTrinh.Rows[dataLoTrinh.CurrentRow.Index].Cells["DEN_DIACHI"].Value + "";
            _quanPhuong = dataLoTrinh.Rows[dataLoTrinh.CurrentRow.Index].Cells["DEN_QUANPHUONG"].Value + "";
            _lotrinh = dataLoTrinh.Rows[dataLoTrinh.CurrentRow.Index].Cells["C_LOTRINH"].Value + "";

            //dataLoTrinh.Rows.RemoveAt(dataLoTrinh.CurrentRow.Index);
            table.Rows.RemoveAt(dataLoTrinh.CurrentRow.Index);
            dataLoTrinh.DataSource = table;
            Utilities.DataGridV.formatRows(dataLoTrinh, "DEN_DANHBO");
            lbDenMayDocSo.Text = "TỔNG SỐ " + (dataLoTrinh.Rows.Count) + " DANH BỘ";

            this.menuCut.Visible = false;
            this.menuDann.Visible = true;
        }

        private void menuDann_Click(object sender, EventArgs e)
        {
            /// Tìm trong máy có danh bộ thì xóa trước khi xóa

            ///
            if (flag == true)
            {
                for (int i = 0; i < dataLoTrinh.Rows.Count;i++ )
                {
                    string lt = dataLoTrinh.Rows[i].Cells["DEN_DANHBO"].Value + "";
                    if (_DanhBo.Replace(" ", "").Equals(lt.Replace(" ", ""))) {
                        table.Rows.RemoveAt(i);
                        dataLoTrinh.DataSource = table;
                    }
                }
            }

            flag = false;
            string lotrinhmoi1 = "";
            int index = 0;
            try
            {
                index = dataLoTrinh.CurrentRow.Index;

                try
                {
                    lotrinhmoi1 = (int.Parse(dataLoTrinh.Rows[index].Cells["M_LOTRINH"].Value + "") + int.Parse(txtChen.Text)) + "";
                    if (lotrinhmoi1.Length < 9)
                    {
                        lotrinhmoi1 = "0" + lotrinhmoi1;
                    }

                    if (index < dataLoTrinh.Rows.Count)
                    {
                        index = index + 1;
                    }
                }
                catch (Exception)
                {

                    lotrinhmoi1 = (int.Parse(dataLoTrinh.Rows[index].Cells["C_LOTRINH"].Value + "") + int.Parse(txtChen.Text)) + "";
                    if (lotrinhmoi1.Length < 9)
                    {
                        lotrinhmoi1 = "0" + lotrinhmoi1;
                    }

                    if (index < dataLoTrinh.Rows.Count)
                    {
                        index = index + 1;
                    }
                }


                DataRow row = table.NewRow();
                row["DANHBO"] = _DanhBo;
                row["DIACHI"] = _diachi;
                row["QUANPHUONG"] = _quanPhuong;
                row["LOTRINH"] = _lotrinh;
                row["M_LOTRINH"] = lotrinhmoi1;

                table.Rows.InsertAt(row, index);
                dataLoTrinh.DataSource = table;
                Utilities.DataGridV.formatRows(dataLoTrinh, "DEN_DANHBO");
                lbDenMayDocSo.Text = "TỔNG SỐ " + (dataLoTrinh.Rows.Count) + " DANH BỘ";


                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.ForeColor = System.Drawing.Color.Blue;
                cellStyle.Font = new Font(dataLoTrinh.Font, FontStyle.Bold); ;
                dataLoTrinh.Rows[index].Cells["DEN_DANHBO"].Style = cellStyle;
                dataLoTrinh.Rows[index].Cells["C_LOTRINH"].Style = cellStyle;
                dataLoTrinh.Rows[index].Cells["M_LOTRINH"].Style = cellStyle;
                dataLoTrinh.Rows[index].Cells["DEN_DIACHI"].Style = cellStyle;

                this.menuCut.Visible = true;
                this.menuDann.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void dataLoTrinh_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dataLoTrinh, new Point(e.X, e.Y));
            }
        }

        private void dataDanhBoGanMoi_Sorted(object sender, EventArgs e)
        {
            Utilities.DataGridV.formatRows(dataDanhBoGanMoi, "TU_DANHBO");
        }

        private void dataDanhBoGanMoi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(dataDanhBoGanMoi, new Point(e.X, e.Y));
            }
        }


        private void tulotrinh_cut_Click(object sender, EventArgs e)
        {
            _DanhBo = dataDanhBoGanMoi.Rows[dataDanhBoGanMoi.CurrentRow.Index].Cells["TU_DANHBO"].Value + "";
            _diachi = dataDanhBoGanMoi.Rows[dataDanhBoGanMoi.CurrentRow.Index].Cells["TU_DIACHI"].Value + "";
            _quanPhuong = dataDanhBoGanMoi.Rows[dataDanhBoGanMoi.CurrentRow.Index].Cells["TU_QP"].Value + "";
            _lotrinh = dataDanhBoGanMoi.Rows[dataDanhBoGanMoi.CurrentRow.Index].Cells["L_LOTRINH"].Value + "";
            if ("".Equals(_lotrinh))
            {
                _lotrinh = dataDanhBoGanMoi.Rows[dataDanhBoGanMoi.CurrentRow.Index].Cells["TMP_LOT"].Value + "";
            }
            //dataLoTrinh.Rows.RemoveAt(dataLoTrinh.CurrentRow.Index);
            dataDanhBoGanMoi.Rows.RemoveAt(dataDanhBoGanMoi.CurrentRow.Index);
            lbTuMayDS.Text = "TỔNG SỐ " + (dataDanhBoGanMoi.Rows.Count) + " DANH BỘ";
            
            this.menuCut.Visible = false;
            this.menuDann.Visible = true;
            flag = true;
        }

    }
}