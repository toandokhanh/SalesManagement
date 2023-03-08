﻿using Guna.UI2.WinForms;
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
    public partial class fHome : Form
    {
        private string username;
        private string password;
        public fHome(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            lbUserName.Text = "Xin chào " + username + " đến với trang quản trị" + password;
        }
        public static string LoggedInUserName;

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            fRevenue fMain = new fRevenue();
            this.Hide();
            fMain.ShowDialog();
            this.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            fInformation fMain = new fInformation();
            this.Hide();
            fMain.ShowDialog();
            this.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            fProducts fMain = new fProducts();
            this.Hide();
            fMain.ShowDialog();
            this.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            fBills fMain = new fBills();
            this.Hide();
            fMain.ShowDialog();
            this.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            fCustomers fMain = new fCustomers();
            this.Hide();
            fMain.ShowDialog();
            this.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            fStaffs fMain = new fStaffs();
            this.Hide();
            fMain.ShowDialog();
            this.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fLogin fMain = new fLogin();
            this.Hide();
            fMain.ShowDialog();
            this.Show();
        }

        private void lbUserName_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}