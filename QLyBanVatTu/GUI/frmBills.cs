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
        private string role;
        public frmBills(string role)
        {
            InitializeComponent();
            this.role = role;
            txtStaff.Text = role;
            txtStaff.ReadOnly = true;
        }
    }
}
