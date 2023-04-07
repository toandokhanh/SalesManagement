using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class frmCustomers : Form
    {
        BUS_KhachHang buskhachhang = new BUS_KhachHang();
        DTO_KhachHang dtokhachhang = new DTO_KhachHang();
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadGridView()
        {
            dtgvCustomer.Columns[0].HeaderText = "Mã khách hàng";
            dtgvCustomer.Columns[1].HeaderText = "Tên khách hàng";
            dtgvCustomer.Columns[2].HeaderText = "Địa chỉ";
            dtgvCustomer.Columns[3].HeaderText = "Số điện thoại";
            foreach (DataGridViewColumn item in dtgvCustomer.Columns)
                item.DividerWidth = 1;
        }
        private void MessBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void frmCustomers_Load(object sender, EventArgs e)
        {

            dtgvCustomer.DataSource = buskhachhang.ListCustomer();
            LoadGridView();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtName.Text != "" && txtAddress.Text != "" && txtPhone.Text != "")
            {
                dtokhachhang = new DTO_KhachHang
                (
                    txtID.Text,
                    txtName.Text,
                    txtAddress.Text,
                    txtPhone.Text
                );
                if (buskhachhang.InsertCustomer(dtokhachhang))
                {
                    dtgvCustomer.DataSource = buskhachhang.ListCustomer();
                    LoadGridView();
                    MessBox("Thêm khách hàng thành công");
                }
                else
                {
                    MessBox("Thêm khách hàng không thành công", true);
                }
            }
            else
            {
                MessBox("Vui lòng nhập nhập đầy đủ thông tin", true);
            }


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtID.ReadOnly = false;
            txtID.Text = null;
            txtName.Text = null;
            txtAddress.Text = null;
            txtPhone.Text = null;
        }

        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgvCustomer.Rows.Count > 0)
            {
                btnDelete.Enabled = true;
                btnDelete.Enabled = true;
                txtID.ReadOnly = true;
                txtID.Text = dtgvCustomer.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dtgvCustomer.CurrentRow.Cells[1].Value.ToString();
                txtAddress.Text = dtgvCustomer.CurrentRow.Cells[2].Value.ToString();
                txtPhone.Text = dtgvCustomer.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtName.Text != "" && txtAddress.Text != "" && txtPhone.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtokhachhang = new DTO_KhachHang
                    (
                        txtID.Text,
                        txtName.Text,
                        txtAddress.Text,
                        txtPhone.Text
                    );
                    if (buskhachhang.UpdateCustomer(dtokhachhang))
                    {
                        dtgvCustomer.DataSource = buskhachhang.ListCustomer();
                        LoadGridView();
                        MessBox("Sửa thông tin khách hàng thành công");
                    }
                    else
                        MessBox("Sửa thông tin khách hàng không thành công", true);
                }
                else
                {
                    MessBox("Vui lòng kiểm tra lại thông tin thông tin", true);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ma = txtID.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ma != null)
                {
                    //MessageBox.Show(ma);
                    buskhachhang.DeleteCustomer(ma);
                    dtgvCustomer.DataSource = buskhachhang.ListCustomer();
                    LoadGridView();
                    MessBox("Xóa vật tư thành công");
                }
                else
                {
                    MessBox("Xóa không thành công", true);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kh = txtFind.Text;
            if(kh == "")
            {
                frmCustomers_Load(sender, e);
            }
            else
            {
                DataTable table = buskhachhang.SearchCustomer(kh);
                dtgvCustomer.DataSource = table;
            }
        }
    }
}
