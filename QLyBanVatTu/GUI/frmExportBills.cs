using BUS;
using DAL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace GUI
{
    public partial class frmExportBills : Form
    {
        BUS_ExportBill busExportBill = new BUS_ExportBill();
        DTO_HoaDonXuat dtoHDX = new DTO_HoaDonXuat();
        private string role;
        public frmExportBills(string role)
        {
            InitializeComponent();
            this.role = role;
            txtStaff.Text = role;
            txtStaff.ReadOnly = true;
        }
        private void LoadComboBoxKhachHang()
        {
            DAL_KhachHang khachhang = new DAL_KhachHang();
            DataTable dt = khachhang.GetCustomer();
            cbCustomer.DisplayMember = "MA_KH";
            cbCustomer.ValueMember = "TEN_KH";
            cbCustomer.DataSource= dt;
            
        }
        private void LoadGridView()
        {
            dtgvExportBill.Columns[0].HeaderText = "Mã hóa đơn xuất";
            dtgvExportBill.Columns[1].HeaderText = "Mã khách hàng";
            dtgvExportBill.Columns[2].HeaderText = "Email nhân viên lập";
            dtgvExportBill.Columns[3].HeaderText = "Ngày lập";
            foreach (DataGridViewColumn item in dtgvExportBill.Columns)
                item.DividerWidth = 1;
        }

        private void frmBills_Load(object sender, EventArgs e)
        {
            dtgvExportBill.DataSource = busExportBill.ListExportBill();
            LoadGridView();
            LoadComboBoxKhachHang();
        }

        private void dtgvExprotBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvExportBill.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                txtNameCustomer.ReadOnly = true;
                txtNameCustomer.Text = dtgvExportBill.CurrentRow.Cells[0].Value.ToString();
                cbCustomer.SelectedValue = dtgvExportBill.CurrentRow.Cells[1].Value.ToString();
                txtStaff.Text = dtgvExportBill.CurrentRow.Cells[2].Value.ToString();
                DateTimePicker.Text = dtgvExportBill.CurrentRow.Cells[3].Value.ToString();
            }
        }
        private void MessBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            dtoHDX = new DTO_HoaDonXuat
            (
                txtNameCustomer.Text,
                cbCustomer.SelectedValue.ToString(),
                txtStaff.Text,
                DateTimePicker.Value

            );
            if (busExportBill.InsertExportBills(dtoHDX))
            {
                dtgvExportBill.DataSource = busExportBill.ListExportBill();
                LoadGridView();
                MessBox("thêm hóa đơn xuất thành công");
            }
            else
            {
                MessBox("Thêm hóa đơn xuất không thành công", true);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
