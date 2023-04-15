using BUS;
using DAL;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmStaffs : Form
    {
        DAL_TKHT daltkht = new DAL_TKHT();
        BUS_TKHT bustkht = new BUS_TKHT();
        DTO_TKHT dtotkht;
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        public frmStaffs()
        {
            InitializeComponent();
        }
        private void MessBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadGridView()
        {
            dtgvStaff.Columns[0].HeaderText = "Email nhân viên";
            dtgvStaff.Columns[1].HeaderText = "Họ tên";
            dtgvStaff.Columns[2].HeaderText = "Tên phân quyền";
            dtgvStaff.Columns[3].HeaderText = "Địa chỉ";
            dtgvStaff.Columns[4].HeaderText = "Số điện thoại";
            dtgvStaff.Columns[5].HeaderText = "Giới tính";
            dtgvStaff.Columns[6].HeaderText = "Ngày sinh";
            foreach (DataGridViewColumn item in dtgvStaff.Columns)
                item.DividerWidth = 1;
        }
        private void LoadComboBoxPhanQuyen()
        {
            DataTable dt = daltkht.PhanQuyen();
            cbPhanQuyen.DisplayMember = "PQ_Ten";
            cbPhanQuyen.ValueMember = "PQ_Ma";
            cbPhanQuyen.DataSource = dt;
        }
        private void frmStaffs_Load(object sender, EventArgs e)
        {
            dtgvStaff.DataSource = bustkht.ListStaff();            
            LoadGridView();
            LoadComboBoxPhanQuyen();
            cbPhanQuyen.SelectedIndex = -1;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DateTime ngaySinh;
            string ngaySinhString = txtNgaySinh.Text;
            string ngaySinhFormat = "dd/MM/yyyy"; // Thay đổi định dạng theo ý muốn

            ngaySinh = DateTime.ParseExact(ngaySinhString, ngaySinhFormat, CultureInfo.InvariantCulture);

            bool gioitinh = true;
            SqlConnection conn = new SqlConnection(stringConnect);
            if (txtEmail.Text != "" && txtAddress.Text != "" && txtName.Text != "" && txtPassword.Text != "" && txtPhone.Text != "" && txtNgaySinh.Text != null)
            {
                string query = daltkht.GetFieldValues("Select TKHT_Email from TAI_KHOAN_HE_THONG where TKHT_Email = '" + txtEmail.Text + "'");
                if (!string.IsNullOrEmpty(query))
                {
                    MessBox("Email này đã tồn tại, bạn hãy nhập email khác!", true);
                    txtEmail.Focus();
                    txtEmail.Text = "";
                    return;
                }
                if (cbPhanQuyen.SelectedIndex == -1)
                {
                    MessBox("Vui lòng chọn phân quyên cho nhân viên", true);
                }
                if(checkMale.Checked == false && checkFemale.Checked == false)
                {
                    MessBox("Vui lòng chọn giới tính nhân viên", true);
                }
                else
                {
                    if(gioitinh == true)
                    {
                        checkMale.Checked = true;
                    }
                    else
                    {
                        checkFemale.Checked = true;
                    }
                    string sql;
                    conn.Open();
                    sql = "Insert into TAI_KHOAN_HE_THONG VALUES('"+txtEmail.Text+"', '"+txtName.Text+"', '"+cbPhanQuyen.SelectedValue.ToString()+"', '"+txtPassword.Text+"', '"+txtAddress.Text+"', '"+txtPhone.Text+"', '"+gioitinh+"', '"+ ngaySinh + "')";
                    MessageBox.Show(sql);
                    try
                    {
                        SqlCommand comd = new SqlCommand(sql, conn);
                        comd.ExecuteNonQuery();
                        MessBox("Thêm nhân viên thành công");
                        LoadGridView();
                        dtgvStaff.DataSource = bustkht.ListStaff();
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            
            else
            {
              MessBox("Vui lòng nhập đầy đủ thông tin!", true);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime ngaySinh;
            string ngaySinhString = txtNgaySinh.Text;
            string ngaySinhFormat = "dd/MM/yyyy"; // Thay đổi định dạng theo ý muốn

            ngaySinh = DateTime.ParseExact(ngaySinhString, ngaySinhFormat, CultureInfo.InvariantCulture);
            bool gioitinh = true;
            SqlConnection conn = new SqlConnection(stringConnect);
            if (txtEmail.Text != "" && txtName.Text != "" && txtAddress.Text != "" && txtPhone.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gioitinh == true)
                    {
                        checkMale.Checked = true;
                    }
                    else
                    {
                        checkFemale.Checked = true;
                    }
                    string sql;
                    sql = "Update TAI_KHOAN_HE_THONG SET TKHT_HoTen = '" + txtName.Text + "', PQ_Ma = '" + cbPhanQuyen.SelectedValue.ToString() + "', TKHT_Password = '" + txtPassword.Text + "', TKHT_DiaChi = '" + txtAddress.Text + "', TKHT_SoDienThoai = '" + txtPhone.Text + "', TKHT_GioiTinh = '" + gioitinh + "', TKHT_NgaySinh= '" + ngaySinh + "' where TKHT_Email = '" + txtEmail.Text + "'";

                    MessageBox.Show(sql);
                    try
                    {
                        conn.Open();
                        SqlCommand comd = new SqlCommand(sql, conn);
                        comd.ExecuteNonQuery();
                        MessBox("Sửa thông tin nhân viên thành công");
                        LoadGridView();
                        dtgvStaff.DataSource = bustkht.ListStaff();
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
                else
                {
                    MessBox("Vui lòng kiểm tra lại thông tin thông tin", true);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            if (txtEmail.Text != "" && txtName.Text != "" && txtAddress.Text != "" && txtPhone.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    string sql;
                    sql = "Delete TAI_KHOAN_HE_THONG where TKHT_Email = '" + txtEmail.Text + "'";

                    MessageBox.Show(sql);
                    try
                    {
                        conn.Open();
                        SqlCommand comd = new SqlCommand(sql, conn);
                        comd.ExecuteNonQuery();
                        MessBox("Xóa thông tin nhân viên thành công");
                        LoadGridView();
                        dtgvStaff.DataSource = bustkht.ListStaff();
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        conn.Close();
                    }
                }               
            }
        }

        private void dtgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvStaff.Rows.Count > 0)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                txtEmail.ReadOnly = true;
                txtEmail.Text = dtgvStaff.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dtgvStaff.CurrentRow.Cells[1].Value.ToString();
                txtAddress.Text = dtgvStaff.CurrentRow.Cells[3].Value.ToString();
                txtPhone.Text = dtgvStaff.CurrentRow.Cells[4].Value.ToString();
                cbPhanQuyen.Text = dtgvStaff.CurrentRow.Cells[2].Value.ToString();
                DateTime ngaysinh = (DateTime)dtgvStaff.CurrentRow.Cells[6].Value;
                txtNgaySinh.Text = ngaysinh.ToString("dd/MM/yyyy");
                string gioitinh = dtgvStaff.CurrentRow.Cells[5].Value.ToString();
                txtPassword.Text = daltkht.GetFieldValues("Select TKHT_Password from TAI_KHOAN_HE_THONG where TKHT_Email = '"+txtEmail.Text+"'");
                if (gioitinh == "Nam")
                {
                    checkMale.Checked = true;
                }
                else
                {
                    checkFemale.Checked = true;
                }                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtNgaySinh.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            checkMale.Checked = false;
            checkFemale.Checked = false;
            cbPhanQuyen.SelectedIndex = -1;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dtgvStaff);
        }
        public void ExportToExcel(DataGridView dataGridView)
        {

            // Định dạng lại theo chuẩn của SQL Server
            string fileName = "dsnv.xlsx";
            SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook);

            // Tạo các sheet và cấu hình file excel
            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet 1" };
            sheets.Append(sheet);

            // Đổ data từ datagridview vào file excel
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            Row headerRow = new Row();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                headerRow.AppendChild(CreateCell(column.HeaderText));
            }

            sheetData.AppendChild(headerRow);

            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                Row row = new Row();

                foreach (DataGridViewCell cell in dataGridViewRow.Cells)
                {
                    string cellValue = cell.Value != null ? cell.Value.ToString() : "";
                    row.AppendChild(CreateCell(cellValue));
                }
                sheetData.AppendChild(row);
            }
            Row totalRow = new Row();

            worksheetPart.Worksheet.Save();

            workbookPart.Workbook.Save();

            document.Close();

            // Mở file excel sau khi export thành công
            System.Diagnostics.Process.Start(fileName);
        }

        // Hàm tạo một cell với giá trị được cung cấp
        private Cell CreateCell(string text)
        {
            if (int.TryParse(text, out int result))
            {
                return new Cell(new CellValue(result.ToString())) { DataType = CellValues.Number };
            }
            else
            {
                return new Cell(new CellValue(text ?? string.Empty)) { DataType = CellValues.String };
            }
        }
    }
}
