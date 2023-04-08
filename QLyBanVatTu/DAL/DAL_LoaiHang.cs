using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiHang
    {
        string stringConnect = @"Server=MSI\SQL;Database=QLVT;integrated security=true";
        public DataTable GetLoaiHang()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT * FROM dbo.LOAI_HANG";
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
