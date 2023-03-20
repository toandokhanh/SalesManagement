using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhaCungCap
    {
        string stringConnect = @"Server=MSI\SQL;Database=QLBH;integrated security=true";
        public DataTable GetNhaCungCap()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                string query = "SELECT NCC_Ma, NCC_Ten FROM dbo.NHACUNGCAP";
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
