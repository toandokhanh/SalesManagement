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
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Wordprocessing;

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

        private bool CheckIsNummber(string text)
        {
            return int.TryParse(text, out int s);
        }
        private void LoadComboBoxNuocSanXuat()
        {
            DAL_NuocSanXuat NuocSanXuat = new DAL_NuocSanXuat();
            DataTable dt = NuocSanXuat.GetProduct();
            cbNuocSX.DisplayMember= "NSX_Ten";
            cbNuocSX.ValueMember= "NSX_Ma";
            cbNuocSX.DataSource= dt;
        }
        private void LoadComboBoxLoaiHang()
        {
            DAL_LoaiHang LoaiHang = new DAL_LoaiHang();
            DataTable dt = LoaiHang.GetLoaiHang();
            cbLoaiVT.DisplayMember = "LH_Ten";
            cbLoaiVT.ValueMember = "LH_Ma";
            cbLoaiVT.DataSource = dt;
        }
        private void LoadComboBoxNhaCungCap()
        {
            DAL_NhaCungCap NhaCungCap = new DAL_NhaCungCap();
            DataTable dt = NhaCungCap.GetNhaCungCap();
            cbNCC.DisplayMember = "NCC_Ten";
            cbNCC.ValueMember = "NCC_Ma";
            cbNCC.DataSource = dt;
        }
        private void LoadGridView()
        {
            dtgvProduct.Columns[0].HeaderText = "Mã hàng";
            dtgvProduct.Columns[1].HeaderText = "Loại hàng";
            dtgvProduct.Columns[2].HeaderText = "Nước sản xuất";
            dtgvProduct.Columns[3].HeaderText = "Nhà cung cấp";
            dtgvProduct.Columns[4].HeaderText = "Tên hàng";
            dtgvProduct.Columns[5].HeaderText = "Số lượng";
            dtgvProduct.Columns[6].HeaderText = "Mô tả";
            dtgvProduct.Columns[7].HeaderText = "Đơn giá";
            dtgvProduct.Columns[8].HeaderText = "Hình ảnh";
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
            LoadComboBoxNhaCungCap();
            cbLoaiVT.SelectedIndex = -1;
            cbNCC.SelectedIndex = -1;
            cbNuocSX.SelectedIndex = -1;
            DAL_NuaMua nuamua = new DAL_NuaMua();
            txtIDProduct.Text = nuamua.CreateNewID("SELECT MAX(hh_ma) AS Largest_ma_kh FROM HANGHOA");
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (txtIDProduct.Text == "")
                MessBox("Vui lòng nhập mã đơn", true);
            else if (txtName.Text == "")
                MessBox("Vui lòng nhập tên vật tư!", true);
            else if (txtNumber.Text == "")
                MessBox("Vui lòng nhập số lượng vật tư", true);
            else if (txtPrice.Text == "")
                MessBox("Vui lòng nhập đơn giá vật tư", true);
            else if (cbLoaiVT.SelectedIndex == -1)
                MessBox("Vui lòng chọn loại vật tư", true);
            else if (cbNuocSX.SelectedIndex == -1)
                MessBox("Vui lòng chọn nước sản xuất",true);
            else if (cbNCC.SelectedIndex == -1)
                MessBox("Vui lòng chọn nhà cung cấp", true);
            else if (!CheckIsNummber(txtNumber.Text) || !CheckIsNummber(txtPrice.Text))
                MessBox("Vui lòng nhập chữ số!", true);
            else if (guna2PictureBox1.Image == null)
                MessBox("Vui lòng chọn hình!", true);
            else
            {
               

                dto_HangHoa = new DTO_HangHoa
                    (
                        txtIDProduct.Text,
                        cbLoaiVT.SelectedValue.ToString(),
                        cbNuocSX.SelectedValue.ToString(),
                        cbNCC.SelectedValue.ToString(),
                        txtName.Text,
                        int.Parse(txtNumber.Text),
                        txtMoTa.Text,
                        float.Parse(txtPrice.Text),
                        txtImg.Text

                    );
                if (busproduct.InsertProduct(dto_HangHoa))
                {
                    dtgvProduct.DataSource = busproduct.ListProduct();
                    LoadGridView();
                    txtIDProduct.ReadOnly = false;
                    txtIDProduct.Text = null;
                    cbNCC.SelectedIndex = -1;
                    cbLoaiVT.SelectedIndex = -1;
                    cbNuocSX.SelectedIndex = -1;
                    
                    txtName.Text = null;
                    txtNumber.Text = null;
                    txtMoTa.Text = null;
                    txtPrice.Text = null;
                    txtImg.Text = null;
                    guna2PictureBox1.Image = null;
                    DAL_NuaMua nuamua = new DAL_NuaMua();
                    txtIDProduct.Text = nuamua.CreateNewID("SELECT MAX(hh_ma) AS Largest_ma_kh FROM HANGHOA");
                    MessBox("Thêm vật tư thành công");                    
                }
                else
                {
                    MessBox("Thêm vật tư không thành công", true);
                }
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
                cbLoaiVT.Text = dtgvProduct.CurrentRow.Cells[1].Value.ToString();
                cbNuocSX.Text = dtgvProduct.CurrentRow.Cells[2].Value.ToString();
                cbNCC.Text = dtgvProduct.CurrentRow.Cells[3].Value.ToString();
                txtName.Text = dtgvProduct.CurrentRow.Cells[4].Value.ToString();
                txtNumber.Text = dtgvProduct.CurrentRow.Cells[5].Value.ToString();
                txtMoTa.Text = dtgvProduct.CurrentRow.Cells[6].Value.ToString();
                txtPrice.Text = dtgvProduct.CurrentRow.Cells[7].Value.ToString();
                txtImg.Text = dtgvProduct.CurrentRow.Cells[8].Value.ToString();
                if (txtImg.Text != "")
                {
                    string linkImage = txtImg.Text;
                    guna2PictureBox1.Image = Image.FromFile(linkImage);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!CheckIsNummber(txtNumber.Text) || !CheckIsNummber(txtPrice.Text))
                    MessBox("Vui lòng nhập chữ số!", true);
                else if (txtName.Text == "")
                    MessBox("Vui lòng nhập tên vật tư!", true);
                else if (guna2PictureBox1.Image == null)
                    MessBox("Vui lòng chọn hình!", true);
                else
                {
                    dto_HangHoa = new DTO_HangHoa
                    (
                        txtIDProduct.Text,
                        cbLoaiVT.SelectedValue.ToString(),
                        cbNuocSX.SelectedValue.ToString(),
                        cbNCC.SelectedValue.ToString(),
                        txtName.Text,
                        int.Parse(txtNumber.Text),
                        txtMoTa.Text,
                        float.Parse(txtPrice.Text),
                        txtImg.Text

                    );
                    if (busproduct.UpdateProduct(dto_HangHoa))
                    {
                        dtgvProduct.DataSource = busproduct.ListProduct();
                        LoadGridView();                        
                        //DAL_NuaMua nuamua = new DAL_NuaMua();
                        //txtIDProduct.Text = nuamua.CreateNewID("SELECT MAX(hh_ma) AS Largest_ma_kh FROM HANGHOA");
                        MessBox("Sửa vật tư thành công");
                    }
                    else
                    {
                        MessBox("Sửa vật tư không thành công", true);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtIDProduct.Text == "")
            {
                MessageBox.Show("VUi lòng chọn vật tư cần xóa");
            }
            else
            {
                string ma = txtIDProduct.Text;
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busproduct.DeleteProduct(txtIDProduct.Text))
                    {
                        //MessageBox.Show(ma);
                        busproduct.DeleteProduct(ma);
                        dtgvProduct.DataSource = busproduct.ListProduct();
                        LoadGridView();
                        txtIDProduct.ReadOnly = false;
                        txtIDProduct.Text = null;
                        cbNCC.SelectedIndex = -1;
                        cbLoaiVT.SelectedIndex = -1;
                        cbNuocSX.SelectedIndex = -1;
                        cbNCC.SelectedIndex = -1;
                        cbLoaiVT.SelectedIndex = -1;
                        cbNuocSX.SelectedIndex = -1;
                        txtName.Text = null;
                        txtNumber.Text = null;
                        txtMoTa.Text = null;
                        txtPrice.Text = null;
                        txtImg.Text = null;
                        guna2PictureBox1.Image = null;
                        DAL_NuaMua nuamua = new DAL_NuaMua();
                        txtIDProduct.Text = nuamua.CreateNewID("SELECT MAX(hh_ma) AS Largest_ma_kh FROM HANGHOA");
                        MessBox("Xóa vật tư thành công");
                    }
                    else
                    {
                        MessBox("Xóa không thành công", true);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtIDProduct.ReadOnly = true;
            cbNCC.SelectedIndex = -1;
            cbLoaiVT.SelectedIndex = -1;
            cbNuocSX.SelectedIndex = -1;
            cbNCC.SelectedIndex = -1;
            cbLoaiVT.SelectedIndex = -1;
            cbNuocSX.SelectedIndex = -1;
            txtName.Text = null;
            txtNumber.Text = null;
            txtMoTa.Text = null;
            txtPrice.Text = null;
            txtImg.Text = null;
            guna2PictureBox1.Image = null;
            DAL_NuaMua nuamua = new DAL_NuaMua();
            txtIDProduct.Text = nuamua.CreateNewID("SELECT MAX(hh_ma) AS Largest_ma_kh FROM HANGHOA");
        }


        private void btnInsertImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files(*.jpg;*png)|*.jpg;*png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Image = new Bitmap(open.FileName);
                guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                txtImg.Text = open.FileName;
            }
        }

        private void guna2TextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            string name = guna2TextBox6.Text.Trim();
            if(e.KeyCode== Keys.Enter)
            {
                if(name == "")
                {
                    frmProducts_Load(sender, e);
                }
                else
                {
                    DataTable table = busproduct.SearchProduct(guna2TextBox6.Text);
                    dtgvProduct.DataSource = table;
                }
                             
            }
        }
    }
}
