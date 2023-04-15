using BUS;
using DAL;
using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace GUI
{
    public partial class frmExportBills : Form
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        BUS_ExportBill busExportBill = new BUS_ExportBill();
        DAL_ExportBills dalHDX = new DAL_ExportBills();
        //DTO_HoaDonXuat dtoHDX;
        private string role;
        private string email;
        public frmExportBills(string role, string email)
        {
            InitializeComponent();
            this.role = role;
            LoadComboBoxTKHT(role,email);
            this.email = email;
        }
        private void MessBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string CovertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;
        }
        private void LoadComboBoxKhachHang()
        {
            DAL_KhachHang kh = new DAL_KhachHang();
            DataTable data = kh.GetCustomer();
            cbCustomer.DisplayMember = "TEN_KH";
            cbCustomer.ValueMember = "MA_KH";
            cbCustomer.DataSource = data;
        }
        private void LoadComboBoxTKHT(string role, string email)
        {
            string str;
            DAL_TKHT tkht = new DAL_TKHT();
            DataTable data = tkht.GetTKHT(role, email);
            cbPQNV.DisplayMember = "PQ_Ten";
            cbPQNV.ValueMember = "PQ_Ma";
            cbPQNV.DataSource = data;
            str = "Select TKHT_Email from TAI_KHOAN_HE_THONG where PQ_Ma =N'" + role + "' and TKHT_Email = N'"+email+"'";
            txtStaff.Text = tkht.GetFieldValues(str);

        }
        private void LoadComboBoxVatTu()
        {
            DAL_HangHoa hanghoa = new DAL_HangHoa();
            DataTable data = hanghoa.GetVatTu();
            cbIDProduct.DisplayMember = "HH_Ten";
            cbIDProduct.ValueMember = "HH_Ma";
            cbIDProduct.DataSource = data;
        }
        private void LoadDataGV()
        {
            dtgvExportBill.Columns[0].HeaderText = "Mã hàng";
            dtgvExportBill.Columns[1].HeaderText = "Tên hàng";
            dtgvExportBill.Columns[2].HeaderText = "Số lượng";
            dtgvExportBill.Columns[3].HeaderText = "Đơn giá";
            dtgvExportBill.Columns[4].HeaderText = "Thành tiền";
            foreach (DataGridViewColumn item in dtgvExportBill.Columns)
                item.DividerWidth = 1;
        }
        private void frmExportBills_Load(object sender, System.EventArgs e)
        {
            txtIDExprotBill.ReadOnly= true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            cbPQNV.Enabled = false;
            txtStaff.ReadOnly = true;
            txtIDCustomer.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtIDProduct.ReadOnly = true;
            txtPrice.ReadOnly = true;
            txtTotalProduct.ReadOnly = true;
            txtTotalBill.ReadOnly = true;
            LoadComboBoxKhachHang();
            cbCustomer.SelectedIndex = -1;
            datepicker.Value = DateTime.Now;
            LoadComboBoxTKHT(role, email);
            LoadComboBoxVatTu();
            cbIDProduct.SelectedIndex = -1;
            dtgvExportBill.DataSource = busExportBill.ListExportBill(txtIDExprotBill.Text);
            LoadDataGV();
            DAL_NuaMua nuamua = new DAL_NuaMua();
            txtIDExprotBill.Text = nuamua.CreateNewID("SELECT MAX(hdx_ma) AS Largest_ma_kh FROM HOA_DON_XUAT");

        }

        private void cbCustomer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SqlConnection connection = new SqlConnection(stringConnect);
            if (cbCustomer.SelectedItem != null)
            {
                string ma = cbCustomer.SelectedValue.ToString();
                string query = "Select * from KHACH_HANG where MA_KH = @Ten";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Ten", ma);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtIDCustomer.Text = reader["MA_KH"].ToString();
                        txtAddress.Text = reader["DIACHI"].ToString();
                        txtPhone.Text = reader["SDT"].ToString();
                    }
                }
                else
                {
                    txtIDCustomer.Text = "";
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                }
                reader.Close();
                connection.Close();

            }
            else
            {
                txtIDCustomer.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
            }
        }
        private void cbIDProduct_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SqlConnection connection = new SqlConnection(stringConnect);
            if (cbIDProduct.SelectedItem != null)
            {
                string ma = cbIDProduct.SelectedValue.ToString();
                string query = "Select * from HANGHOA where HH_Ma = @Ma";                
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Ma", ma);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtIDProduct.Text = reader["HH_Ma"].ToString();
                        txtIntro.Text = reader["HH_MoTa"].ToString();
                        txtPrice.Text = reader["HH_DonGia"].ToString();
                    }
                }
                else
                {
                    txtIDProduct.Text = "";
                    txtIntro.Text = "";
                    txtPrice.Text = "";
                }
                reader.Close();
                connection.Close();

            }
            else
            {
                txtIDProduct.Text = "";
                txtIntro.Text = "";
                txtPrice.Text = "";
            }
        }
        private void ResetValuesHangHoa()
        {
            cbIDProduct.Text = "";
            txtNumberProduct.Text = "";
            txtTotalProduct.Text = "0";

        }
        private void btnInsert_Click(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            string sql = "Select HDX_Ma from HOA_DON_XUAT where HDX_Ma = '" + txtIDExprotBill.Text + "'";
            if(!dalHDX.CheckKey(sql))
            {
                //Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                if (txtIDExprotBill.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
                {
                    MessBox("Bạn phải nhập mã hóa đơn", true);
                    txtIDExprotBill.Focus();
                    return;
                }
                if (datepicker.Text.Length == 0)
                {
                    MessBox("Bạn phải nhập ngày bán", true);
                    datepicker.Focus();
                    return;
                }
                if (cbCustomer.Text.Length == 0)
                {
                    MessBox("Bạn phải nhập khách hàng", true);
                    cbCustomer.Focus();
                    return;
                }
                
                // code nửa mùa 
                conn.Open();
                sql = "INSERT INTO HOA_DON_XUAT(HDX_Ma, Ma_KH, TKHT_Email, HDX_NgayLap, HDX_TongTien) VALUES('" + txtIDExprotBill.Text + "', '" + cbCustomer.SelectedValue.ToString() + "', '" + txtStaff.Text + "', '" + datepicker.Value + "', '" + txtTotalBill.Text + "')";

                try
                {
                    SqlCommand comd = new SqlCommand(sql, conn);
                    comd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }

            }

            // them vao chi tiet hoa don xuat
            if (cbIDProduct.Text.Trim().Length == 0)
            {
                MessBox("Bạn phải chọn mã hàng", true);
                cbIDProduct.Focus();
                return;
            }
            if ((txtNumberProduct.Text.Trim().Length == 0) || (txtNumberProduct.Text == "0"))
            {
                MessBox("Bạn phải nhập số lượng", true);
                txtNumberProduct.Text = "";
                txtNumberProduct.Focus();
                return;
            }
            sql = "Select HH_Ma from CHI_TIET_HD_XUAT where HH_Ma = '" + cbIDProduct.SelectedValue.ToString() + "' and HDX_Ma = '" + txtIDExprotBill.Text + "'";
            if (dalHDX.CheckKey(sql))
            {
                MessBox("Mã hàng này đã có, bạn phải nhập mã khác", true);
                ResetValuesHangHoa();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            double sl = Convert.ToDouble(dalHDX.GetFieldValues("Select HH_SoLuong from HANGHOA where HH_Ma = '"+cbIDProduct.SelectedValue+"'"));
            if(Convert.ToDouble(txtNumberProduct.Text) > sl)
            {
                MessBox("Số lượng mặt hàng này chỉ còn " + sl ,true);
                txtNumberProduct.Text = "";
                txtNumberProduct.Focus();
                return;
            }   
            conn.Open();
            sql = "INSERT INTO CHI_TIET_HD_XUAT(HDX_Ma, HH_Ma, SoLuongXuat, DonGiaXuat, ThanhTien) VALUES('" + txtIDExprotBill.Text + "', '" + cbIDProduct.SelectedValue.ToString() + "', '" + txtNumberProduct.Text + "', '" + txtPrice.Text + "', '" + txtTotalProduct.Text + "')";
            try
            {
                SqlCommand comd = new SqlCommand(sql, conn);
                comd.ExecuteNonQuery();
                dtgvExportBill.DataSource = busExportBill.ListExportBill(txtIDExprotBill.Text);
                LoadDataGV();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            // Cập nhật lại số lượng của mặt hàng vào bảng HANGHOA
            double slconlai = sl - Convert.ToDouble(txtNumberProduct.Text) ;
            sql = "Update HANGHOA SET HH_SoLuong = "+ slconlai +" where HH_Ma = '"+cbIDProduct.SelectedValue+"'";
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand(sql, conn);
                comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            // Cập nhật lại tổng tiền vào bảng hóa đơn xuất(HOA_DON_XUAT)
            double tong = Convert.ToDouble(dalHDX.GetFieldValues("Select HDX_TongTien from HOA_DON_XUAT where HDX_Ma = '"+txtIDExprotBill.Text+"'"));
            double tongmoi = tong + Convert.ToDouble(txtTotalProduct.Text);
            sql = "Update HOA_DON_XUAT SET HDX_TongTien = "+tongmoi+" where HDX_Ma = '" + txtIDExprotBill.Text + "'";
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand(sql, conn);
                comd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            txtTotalBill.Text = tongmoi.ToString();
            ResetValuesHangHoa();
            btnDelete.Enabled = true;
            btnPrint.Enabled = true;
            
        }
        private void txtNumberProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text != "" && txtNumberProduct.Text.Length > 0)
            {
                int price = Convert.ToInt32(txtPrice.Text);
                int quantity = Convert.ToInt32(txtNumberProduct.Text);
                int total = quantity * price;
                txtTotalProduct.Text = Convert.ToString(total);
            }
            else if (txtNumberProduct.Text == "")
            {
                int price = Convert.ToInt32(txtPrice.Text);
                int quantity = 0;
                int total = quantity * price;
                txtTotalProduct.Text = Convert.ToString(total);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Hệ thống quản lý vật tư";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Cần Thơ";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            exRange.Range["C1:E3"].Font.Size = 16;
            exRange.Range["C1:E3"].Font.Bold = true;
            exRange.Range["C1:E3"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C1:E3"].MergeCells = true;
            exRange.Range["C1:E3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C1:E3"].VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
            exRange.Range["C1:E3"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.HDX_Ma, a.HDX_NgayLap, a.HDX_TongTien, b.Ten_KH, b.DIACHI, b.SDT, c.TKHT_HoTen FROM HOA_DON_XUAT AS a, KHACH_HANG AS b, TAI_KHOAN_HE_THONG AS c WHERE a.HDX_Ma = '" + txtIDExprotBill.Text + "' AND a.Ma_KH = b.Ma_KH AND a.TKHT_Email = c.TKHT_Email";
            tblThongtinHD = dalHDX.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B5:B5"].Value = "Mã hóa đơn:";
            exRange.Range["C5:E5"].MergeCells = true;
            exRange.Range["C5:E5"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B6:B6"].Value = "Khách hàng:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B7:B7"].Value = "Địa chỉ:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B8:B8"].Value = "Điện thoại:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.HH_Ten, a.SoLuongXuat, b.HH_DonGia, a.ThanhTien " +
                  "FROM CHI_TIET_HD_XUAT AS a , HANGHOA AS b WHERE a.HDX_Ma = N'" +
                  txtIDExprotBill.Text + "' AND a.HH_Ma = b.HH_Ma";
            tblThongtinHang = dalHDX.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            //exRange.Range["A1:F1"].Value = "Bằng chữ: " + dalHDX.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void dtgvExportBill_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            if (busExportBill.ListExportBill(txtIDExprotBill.Text).Rows.Count == 0)
            {
                MessBox("Không có dữ liệu!", true);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                string mahang = dtgvExportBill.CurrentRow.Cells["HH_Ma"].Value.ToString();
                double soluongxoa = Convert.ToDouble(dtgvExportBill.CurrentRow.Cells["SoLuongXuat"].Value.ToString());
                double thanhtienxoa = Convert.ToDouble(dtgvExportBill.CurrentRow.Cells["ThanhTien"].Value.ToString());
                string sql = "Delete CHI_TIET_HD_XUAT WHERE HDX_Ma = '"+txtIDExprotBill.Text+"' and HH_Ma = '"+mahang+"'";
                try
                {
                    conn.Open();
                    SqlCommand comd = new SqlCommand(sql, conn);
                    comd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                // Cập nhật lại số lượng cho các mặt hàng
                double sl = Convert.ToDouble(dalHDX.GetFieldValues("Select HH_SoLuong from HANGHOA where HH_Ma = '" + mahang + "'"));
                double slcon = sl + soluongxoa;
                sql = "Update HANGHOA SET HH_SoLuong = " + slcon + " where HH_Ma = '" + mahang + "'";
                try
                {
                    conn.Open();
                    SqlCommand comd = new SqlCommand(sql, conn);
                    comd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                // Cập nhật lại tổng tiền cho hóa đơn bán
                double tong = Convert.ToDouble(dalHDX.GetFieldValues("Select HDX_TongTien from HOA_DON_XUAT where HDX_Ma = '" + txtIDExprotBill.Text + "'"));
                double tongmoi = tong - thanhtienxoa;
                sql = "update HOA_DON_XUAT SET HDX_TongTien = '" + tongmoi + "' where HDX_Ma = '" + txtIDExprotBill.Text + "'";
                try
                {
                    conn.Open();
                    SqlCommand comd = new SqlCommand(sql, conn);
                    comd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                txtTotalBill.Text = tongmoi.ToString();
                dtgvExportBill.DataSource = busExportBill.ListExportBill(txtIDExprotBill.Text);
                LoadDataGV();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cbHDX_Ma.Text == "")
            {
                MessBox("Bạn phải chọn một hóa đơn để tìm kiếm", true);
                cbHDX_Ma.Focus();
                return;
            }
            txtIDExprotBill.Text= cbHDX_Ma.Text;
            LoadComboBoxKhachHang();
            LoadComboBoxTKHT(role, email);
            LoadComboBoxVatTu();
            string query = "Select HDX_NgayLap from HOA_DON_XUAT where HDX_Ma = '" + txtIDExprotBill.Text + "'";
            datepicker.Text = dalHDX.GetFieldValues(query);
            dtgvExportBill.DataSource = busExportBill.ListExportBill(txtIDExprotBill.Text);
            LoadDataGV();
        }

        private void cbHDX_Ma_DropDown(object sender, EventArgs e)
        {
            dalHDX.FillCombo("Select HDX_Ma from HOA_DON_XUAT", cbHDX_Ma, "HDX_Ma", "HDX_Ma");
            cbHDX_Ma.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtgvExportBill.ClearSelection();
            cbCustomer.SelectedIndex = -1;
            cbHDX_Ma.SelectedIndex = -1;
            cbIDProduct.SelectedIndex = -1;
            cbCustomer.SelectedIndex = -1;
            cbHDX_Ma.SelectedIndex = -1;
            cbIDProduct.SelectedIndex = -1;
            txtNumberProduct.Text = "";
            txtTotalBill.Text = "";
            txtTotalProduct.Text = "";
            DAL_NuaMua nuamua = new DAL_NuaMua();
            txtIDExprotBill.Text = nuamua.CreateNewID("SELECT MAX(hdx_ma) AS Largest_ma_kh FROM HOA_DON_XUAT");
            dtgvExportBill.DataSource = busExportBill.ListExportBill(txtIDExprotBill.Text);
            dtgvExportBill.ClearSelection();
        }

        private void cbHDX_Ma_SelectedValueChanged(object sender, EventArgs e)
        {
            txtIDExprotBill.Text = cbHDX_Ma.Text;
            LoadComboBoxKhachHang();
            LoadComboBoxTKHT(role, email);
            LoadComboBoxVatTu();
            string query = "Select HDX_NgayLap from HOA_DON_XUAT where HDX_Ma = '" + txtIDExprotBill.Text + "'";
            datepicker.Text = dalHDX.GetFieldValues(query);
            dtgvExportBill.DataSource = busExportBill.ListExportBill(txtIDExprotBill.Text);
            btnPrint.Enabled = true;
            LoadDataGV();
        }      
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }          
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }

        
    
}
