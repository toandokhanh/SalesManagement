using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_NuocSanXuat
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        public DataTable GetProduct()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                string query = "SELECT * FROM dbo.NUOC_SAN_XUAT";
                SqlDataAdapter data = new SqlDataAdapter(query, conn);
                data.Fill(table);
            }
            catch (Exception) 
            {
            }
            finally 
            { 
                conn.Close(); 
            }
            return table;
        }
    }
}
