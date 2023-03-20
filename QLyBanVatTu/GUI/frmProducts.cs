using BUS;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmProducts : Form
    {
        BUS_HangHoa busproduct = new BUS_HangHoa();
        DTO_HangHoa dto_HangHoa;
        public frmProducts()
        {
            InitializeComponent();
        }
        private void LoadComboBoxNuocSanXuat()
        {
            DAL_NuocSanXuat NuocSanXuat = new DAL_NuocSanXuat();
            DataTable dt = NuocSanXuat.GetProduct();
            guna2ComboBox2.DisplayMember= "NSX_Ten";
            guna2ComboBox2.ValueMember= "NSX_Ma";
            guna2ComboBox2.DataSource= dt;
        }
        private void LoadComboBoxLoaiHang()
        {
            DAL_NhaCungCap NhaCungCap = new DAL_NhaCungCap();
            DataTable dt = NhaCungCap.GetNhaCungCap();
            guna2ComboBox3.DisplayMember = "NCC_Ten";
            guna2ComboBox3.ValueMember = "NCC_Ma";
            guna2ComboBox3.DataSource = dt;
        }
        private void LoadComboBoxNhaCungCap()
        {
            DAL_NhaCungCap NhaCungCap = new DAL_NhaCungCap();
            DataTable dt = NhaCungCap.GetNhaCungCap();

        }
        private void LoadGridView()
        {
            dtgvProduct.Columns[0].HeaderText = "Mã hàng";
            dtgvProduct.Columns[1].HeaderText = "Mã loại hàng";
            dtgvProduct.Columns[2].HeaderText = "Nước sản xuất";
            dtgvProduct.Columns[3].HeaderText = "Tên hàng";
            dtgvProduct.Columns[4].HeaderText = "Số lượng";
            dtgvProduct.Columns[5].HeaderText = "Mô tả";
            dtgvProduct.Columns[6].HeaderText = "Đơn giá";
            dtgvProduct.Columns[7].HeaderText = "Hình ảnh";
            foreach (DataGridViewColumn item in dtgvProduct.Columns)
                item.DividerWidth = 1;

        }
        private void MessBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void frmProducts_Load(object sender, EventArgs e)
        {
            dtgvProduct.DataSource= busproduct.ListProduct();
            LoadGridView();
            LoadComboBoxNuocSanXuat();
            LoadComboBoxLoaiHang();
            

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            dto_HangHoa = new DTO_HangHoa
            (
                txtIDProduct.Text,
                guna2ComboBox1.SelectedValue.ToString(),
                guna2ComboBox2.SelectedValue.ToString(),
                guna2TextBox2.Text,
                int.Parse(guna2TextBox3.Text),
                guna2TextBox4.Text,
                float.Parse(guna2TextBox5.Text),
                guna2TextBox7.Text

            );
            if (busproduct.InsertProduct(dto_HangHoa))
            {
                dtgvProduct.DataSource= busproduct.ListProduct();
                LoadGridView();
                MessBox("thêm vật tư thành công");
            }
            else
            {
                MessBox("Thêm vật tư không được",true);
            }
                
        }

        private void dtgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgvProduct.Rows.Count > 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                txtIDProduct.ReadOnly= true;
                txtIDProduct.Text = dtgvProduct.CurrentRow.Cells[0].Value.ToString();
                guna2ComboBox1.SelectedValue = dtgvProduct.CurrentRow.Cells[1].Value.ToString();
                guna2ComboBox2.SelectedValue = dtgvProduct.CurrentRow.Cells[2].Value.ToString();
                guna2TextBox2.Text = dtgvProduct.CurrentRow.Cells[3].Value.ToString();
                guna2TextBox3.Text = dtgvProduct.CurrentRow.Cells[4].Value.ToString();
                guna2TextBox4.Text = dtgvProduct.CurrentRow.Cells[5].Value.ToString();
                guna2TextBox5.Text = dtgvProduct.CurrentRow.Cells[6].Value.ToString();
                //chỉnh lại format của hình ảnh
                guna2TextBox7.Text = dtgvProduct.CurrentRow.Cells[7].Value.ToString();



                if (guna2TextBox7.Text != "")
                {
                    string linkImage = guna2TextBox7.Text;
                    guna2PictureBox1.Image = Image.FromFile(linkImage);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dto_HangHoa = new DTO_HangHoa
                (
                    txtIDProduct.Text,
                    guna2ComboBox1.SelectedValue.ToString(),
                    guna2ComboBox2.SelectedValue.ToString(),
                    guna2TextBox2.Text,
                    int.Parse(guna2TextBox3.Text),
                    guna2TextBox4.Text,
                    float.Parse(guna2TextBox5.Text),
                    guna2TextBox7.Text

                );
                if (busproduct.UpdateProduct(dto_HangHoa))
                {
                    dtgvProduct.DataSource = busproduct.ListProduct();
                    LoadGridView();
                    MessBox("Sửa vật tư thành công");
                }
                else
                {
                    MessBox("Sửa vật tư không thành công", true);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ma = txtIDProduct.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ma != null)
                {
                    //MessageBox.Show(ma);
                    busproduct.DeleteProduct(ma);
                    dtgvProduct.DataSource = busproduct.ListProduct();
                    
                    LoadGridView();
                    MessBox("Xóa vật tư thành công");
                }
                else
                {
                    MessBox("Xóa không thành công", true);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtIDProduct.Text = null;
            guna2ComboBox1.SelectedValue.ToString();
            guna2ComboBox2.SelectedValue.ToString();
            guna2TextBox2.Text = null;
            guna2TextBox3.Text = null;
            guna2TextBox4.Text = null;
            guna2TextBox5.Text = null;
            guna2TextBox7.Text = null;
            guna2PictureBox1.Image = null;
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsertImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files(*.jpg;*png)|*.jpg;*png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Image = new Bitmap(open.FileName);
                guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                guna2TextBox7.Text = open.FileName;
            }
        }
        
    }
}
