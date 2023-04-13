using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_HangHoa 
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";

        public DataTable ListProduct()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT \r\n    HH.HH_Ma,\r\n    LH.LH_Ten,\r\n    NSX.NSX_Ten,\r\n    NCC.NCC_Ten,\r\n    HH.HH_Ten,\r\n    HH.HH_SoLuong,\r\n    HH.HH_MoTa,\r\n    HH.HH_DonGia,\r\n    HH.HH_HinhAnh\r\nFROM [HANGHOA] AS HH\r\nINNER JOIN [LOAI_HANG] AS LH ON HH.LH_Ma = LH.LH_Ma\r\nINNER JOIN [NUOC_SAN_XUAT] AS NSX ON NSX.NSX_Ma =HH.NSX_Ma \r\nINNER JOIN [NHA_CUNG_CAP] AS NCC ON NCC.NCC_Ma = HH.NCC_Ma ", conn);
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
                SqlCommand comd = new SqlCommand("InsertofProducts", conn);
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
        public DataTable SearchProduct(string tenhang)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SearchProduct", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("tenhanghoa", tenhang);
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetVatTu()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT HH_Ma, HH_Ten FROM dbo.HANGHOA", conn);
                comd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
        public string GetFieldValues(string sql)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            conn.Close();
            return ma;
        }

        //code a tonh 
        public DataTable ListRevenue()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT \r\n    HH.HH_Ma,\r\n    LH.LH_Ten,\r\n    NSX.NSX_Ten,\r\n    NCC.NCC_Ten,\r\n    HH.HH_Ten,\r\n    HH.HH_SoLuong,\r\n    HH.HH_MoTa,\r\n    HH.HH_DonGia,\r\n    HH.HH_HinhAnh\r\nFROM [HANGHOA] AS HH\r\nINNER JOIN [LOAI_HANG] AS LH ON HH.LH_Ma = LH.LH_Ma\r\nINNER JOIN [NUOC_SAN_XUAT] AS NSX ON NSX.NSX_Ma =HH.NSX_Ma \r\nINNER JOIN [NHA_CUNG_CAP] AS NCC ON NCC.NCC_Ma = HH.NCC_Ma ", conn);
                comd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
