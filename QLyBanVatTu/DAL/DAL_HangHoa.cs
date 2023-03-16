using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HangHoa 
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVatTu;integrated security=true";
        
        public DataTable ListProduct()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT * FROM dbo.HANGHOA", conn);
                comd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally { 
                conn.Close();
            }
        }
        public bool InsertProduct(DTO_HangHoa product)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("InsertProduct", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("mahang", product.Hh_Ma);
                comd.Parameters.AddWithValue("maloai", product.Lh_Ma);
                comd.Parameters.AddWithValue("manuocsx", product.Nsx_Ma);
                comd.Parameters.AddWithValue("tenhang", product.Hh_Ten);
                comd.Parameters.AddWithValue("motahang", product.Hh_MoTa);
                comd.Parameters.AddWithValue("dongiahang", product.Hh_DonGia);
                comd.Parameters.AddWithValue("hinhanh", product.Hh_HinhAnh);
                comd.Parameters.AddWithValue("soluonghang", product.Hh_SoLuong);
                if (comd.ExecuteNonQuery() > 0)
                    return true;
                else 
                    return false;
            }
            catch(Exception)
            {

            }
            finally
            {
                conn.Close ();
            }

            return false;
        }
    }
}
