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
using BUS;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace  GUI
{
    public partial class frmLogin : Form
    {
        DTO_TKHT tkht = new DTO_TKHT();
        BUS_TKHT tkBLL = new BUS_TKHT();        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {

                tkht.Tkht_Email = txtUsername.Text;
                tkht.Tkht_Password = txtPassword.Text;
                string getuser = tkBLL.CheckLogin(tkht);
                switch (getuser)
                {
                    case "requeid_taikhoan":
                        MessageBox.Show("Tài khoản không được để trống.");
                        return;
                    case "requeid_password":
                        MessageBox.Show("Mật khẩu không được để trống.");
                        return;
                    case "Tài khoản hoặc mật khẩu không chích xác":
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chích xác.");
                        return;
                }
                string getrole = tkBLL.checkRole(tkht);
                string getemail = tkBLL.CheckLogin(tkht);
                frmHome fHome = new frmHome(getrole, getemail);
                this.Hide();
                fHome.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để đăng nhập");
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode  == Keys.Enter)
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {

                    tkht.Tkht_Email = txtUsername.Text;
                    tkht.Tkht_Password = txtPassword.Text;
                    string getuser = tkBLL.CheckLogin(tkht);
                    switch (getuser)
                    {
                        case "requeid_taikhoan":
                            MessageBox.Show("Tài khoản không được để trống.");
                            return;
                        case "requeid_password":
                            MessageBox.Show("Mật khẩu không được để trống.");
                            return;
                        case "Tài khoản hoặc mật khẩu không chích xác":
                            MessageBox.Show("Tài khoản hoặc mật khẩu không chích xác.");
                            return;
                    }
                    string getrole = tkBLL.checkRole(tkht);
                    string getemail = tkBLL.CheckLogin(tkht);
                    frmHome fHome = new frmHome(getrole, getemail);
                    this.Hide();
                    fHome.ShowDialog();
                    this.Show();
                }
            }
        }
    }
}
