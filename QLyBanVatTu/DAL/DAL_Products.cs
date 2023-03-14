using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Products 
    {

        public DataTable ListProduct()
        {
            string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVatTu;integrated security=true";
            SqlConnection conn = new SqlConnection(stringConnect);

            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT HH_Ma, HH_Ten, HH_MoTa, HH_DonGia, HH_HinhAnh FROM dbo.HANGHOA", conn);
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally { 
                conn.Close();
            }
        }
    }
}
