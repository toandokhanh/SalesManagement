using BUS;
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
    public partial class frmHome : Form
    {
        private string role;
        public frmHome(string role)
        {
            InitializeComponent();
            this.role = role;

            lbUserName.Text = "Xin chào đến với trang quản trị hệ thống quản lý vật tư xây dựng ";
            if (role == "PQ03")
            {
                guna2GradientButton7.Enabled = false;
            }
        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            frmRevenue fRevenue = new frmRevenue();
            this.Hide();
            fRevenue.ShowDialog();
            this.Show();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            frmProducts fProduct = new frmProducts();
            this.Hide();
            fProduct.ShowDialog();
            this.Show();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            frmInformation fInformation = new frmInformation();
            this.Hide();
            fInformation.ShowDialog();
            this.Show();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            frmCustomers fCustomers = new frmCustomers();
            this.Hide();
            fCustomers.ShowDialog();
            this.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.role = role;
            frmBills fBills = new frmBills(role);
            this.Hide();
            fBills.ShowDialog();
            this.Show();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {

            frmStaffs fStaffs = new frmStaffs();
            this.Hide();
            fStaffs.ShowDialog();
            this.Show();
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
