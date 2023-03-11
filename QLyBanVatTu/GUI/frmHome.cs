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
        private string username;
        private string password;
        public frmHome(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            lbUserName.Text = "Xin chào " + username + " đến với trang quản trị";
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
            frmBills fBills = new frmBills();
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
    }
}
