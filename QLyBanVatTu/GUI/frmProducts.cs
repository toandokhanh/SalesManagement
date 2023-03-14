using BUS;
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
        BUS_Product busproduct = new BUS_Product();
        DTO_HangHoa dTO_HangHoa;
        public frmProducts()
        {
            InitializeComponent();
        }

        private void LoadGridView()
        {
        }


        private void frmProducts_Load(object sender, EventArgs e)
        {
            dtgvProduct.DataSource= busproduct.ListProduct();
            LoadGridView();
        }
    }
}
