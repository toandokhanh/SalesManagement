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

namespace GUI
{
    public partial class frmBills : Form
    {
        BUS_ExportBill busExportBill = new BUS_ExportBill();
        DTO_HoaDonXuat dtoHDX = new DTO_HoaDonXuat();
        private string role;
        public frmBills(string role)
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
            cbBill.DisplayMember = "MA_KH";
            cbBill.ValueMember = "TEN_KH";
            cbBill.DataSource= dt;
        }
        private void LoadGridView()
        {
            dtgvExprotBill.Columns[0].HeaderText = "Mã hóa đơn xuất";
            dtgvExprotBill.Columns[1].HeaderText = "Mã khách hàng";
            dtgvExprotBill.Columns[2].HeaderText = "Email nhân viên lập";
            dtgvExprotBill.Columns[3].HeaderText = "Ngày lập";
            foreach (DataGridViewColumn item in dtgvExprotBill.Columns)
                item.DividerWidth = 1;
        }

        private void frmBills_Load(object sender, EventArgs e)
        {
            dtgvExprotBill.DataSource = busExportBill.ListExportBill();
            LoadGridView();
            LoadComboBoxKhachHang();
        }

        private void dtgvExprotBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvExprotBill.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                txtName.ReadOnly = true;
                txtName.Text = dtgvExprotBill.CurrentRow.Cells[0].Value.ToString();
                cbBill.SelectedValue = dtgvExprotBill.CurrentRow.Cells[1].Value.ToString();
                txtStaff.Text = dtgvExprotBill.CurrentRow.Cells[2].Value.ToString();
                DateTimePicker.Text = dtgvExprotBill.CurrentRow.Cells[3].Value.ToString();
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
                txtName.Text,
                cbBill.SelectedValue.ToString(),
                txtStaff.Text,
                DateTimePicker.Value

            );
            if (busExportBill.InsertExportBills(dtoHDX))
            {
                dtgvExprotBill.DataSource = busExportBill.ListExportBill();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
