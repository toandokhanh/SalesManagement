using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmImportBill : Form
    {
        DAL_ImportBill dalImportBill = new DAL_ImportBill();
        BUS_ImportBill busImportBill = new BUS_ImportBill();
        string stringConnect = @"Server=MSI\SQL;Database=QLVT;integrated security=true";
        private string role;
        private string email;
        public frmImportBill(string role, string email)
        {
            InitializeComponent();
            this.role = role;
            this.email = email;
            LoadComboBoxTKHT(role, email);
        }
        private void LoadComboBoxTKHT(string role, string email)
        {
            string str;
            DAL_TKHT tkht = new DAL_TKHT();
            DataTable data = tkht.GetTKHT(role, email);
            cbPQNV.DisplayMember = "PQ_Ma";
            cbPQNV.ValueMember = "TKHT_Email";
            cbPQNV.DataSource = data;
            str = "Select TKHT_Email from TAI_KHOAN_HE_THONG where PQ_Ma =N'" + role + "' and TKHT_Email = N'" + email + "'";
            txtStaff.Text = tkht.GetFieldValues(str);

        }
        private void LoadComboBoxVatTu()
        {
            DAL_HangHoa hanghoa = new DAL_HangHoa();
            DataTable data = hanghoa.GetVatTu();
            cbIDProduct.DisplayMember = "HH_Ma";
            cbIDProduct.ValueMember = "HH_Ma";
            cbIDProduct.DataSource = data;
        }
        private void LoadComboBoxNCC()
        {
            DAL_NhaCungCap kh = new DAL_NhaCungCap();
            DataTable data = kh.GetNhaCungCap();
            cbNCC.DisplayMember = "NCC_Ma";
            cbNCC.ValueMember = "NCC_Ma";
            cbNCC.DataSource = data;
        }
        private void LoadDataGV()
        {
            dtgvImportBill.Columns[0].HeaderText = "Mã hàng";
            dtgvImportBill.Columns[1].HeaderText = "Tên hàng";
            dtgvImportBill.Columns[2].HeaderText = "Số lượng";
            dtgvImportBill.Columns[3].HeaderText = "Đơn giá";
            dtgvImportBill.Columns[4].HeaderText = "Thành tiền";
            foreach (DataGridViewColumn item in dtgvImportBill.Columns)
                item.DividerWidth = 1;
        }
        private void frmImportBill_Load(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            cbPQNV.Enabled = false;
            txtStaff.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtNameProduct.ReadOnly = true;
            txtPrice.ReadOnly = true;
            txtTotalProduct.ReadOnly = true;
            txtTotalBill.ReadOnly = true;
            LoadComboBoxNCC();
            cbNCC.SelectedIndex = -1;
            DateTimePicker.Value = DateTime.Now;
            LoadComboBoxTKHT(role, email);
            LoadComboBoxVatTu();
            cbIDProduct.SelectedIndex = -1;
            dtgvImportBill.DataSource = busImportBill.ListImportBill(txtIDExprotBill.Text);
            LoadDataGV();
        }

        private void cbPQNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }
    }
}
