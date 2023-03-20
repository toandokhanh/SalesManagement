using DTO;
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
    public class DAL_HangHoa 
    {
        string stringConnect = @"Server=MSI\SQL;Database=QLBH;integrated security=true";
        
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
                comd.Parameters.AddWithValue("manhacungcap", product.Ncc_ma);
                comd.Parameters.AddWithValue("tenhang", product.Hh_Ten);
                comd.Parameters.AddWithValue("soluonghang", product.Hh_SoLuong);
                comd.Parameters.AddWithValue("motahang", product.Hh_MoTa);
                comd.Parameters.AddWithValue("dongiahang", product.Hh_DonGia);
                comd.Parameters.AddWithValue("hinhanh", product.Hh_HinhAnh);
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
        public bool UpdateProduct(DTO_HangHoa product)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("UpdateProduct", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("mahang", product.Hh_Ma);
                comd.Parameters.AddWithValue("maloai", product.Lh_Ma);
                comd.Parameters.AddWithValue("manuocsx", product.Nsx_Ma);
                comd.Parameters.AddWithValue("manhacungcap", product.Ncc_ma);
                comd.Parameters.AddWithValue("tenhang", product.Hh_Ten);
                comd.Parameters.AddWithValue("soluonghang", product.Hh_SoLuong);
                comd.Parameters.AddWithValue("motahang", product.Hh_MoTa);
                comd.Parameters.AddWithValue("dongiahang", product.Hh_DonGia);
                comd.Parameters.AddWithValue("hinhanh", product.Hh_HinhAnh);
                if (comd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }
        public  bool DeleteProduct(string hh_ma)
        {
            //MessageBox.Show("Tầng DAL:" + hh_ma);
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "Delete from HANGHOA where HH_Ma = '" + hh_ma + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                //MessageBox.Show(query);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("hh_ma", hh_ma);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }
    }
}
