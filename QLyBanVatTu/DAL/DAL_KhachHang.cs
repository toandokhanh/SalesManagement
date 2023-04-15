using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhachHang
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        public DataTable ListCustomers()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT * FROM dbo.KHACH_HANG", conn);
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
        public bool InsertCustomer(DTO_KhachHang dtoKhachHang)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("InsertCustomers", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("makh", dtoKhachHang.Ma_KH);
                comd.Parameters.AddWithValue("tenkh", dtoKhachHang.Ten_KH);
                comd.Parameters.AddWithValue("diachi", dtoKhachHang.DiaChi);
                comd.Parameters.AddWithValue("sdt", dtoKhachHang.SDT);
                if (comd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

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
        public bool UpdateCustomer(DTO_KhachHang khachhang)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("UpdateCustomers", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("makh", khachhang.Ma_KH);
                comd.Parameters.AddWithValue("tenkh", khachhang.Ten_KH);
                comd.Parameters.AddWithValue("diachi", khachhang.DiaChi);
                comd.Parameters.AddWithValue("sdt", khachhang.SDT);
                if (comd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
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
        public bool DeleteCustomer(string kh_ma)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "Delete from KHACH_HANG where MA_KH = '" + kh_ma + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("makh", kh_ma);
                if (cmd.ExecuteNonQuery() > 0)
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
        public DataTable SearchCustomer(string khachhang)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SearchCustomers", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("ten", khachhang);
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetCustomer()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT * FROM dbo.KHACH_HANG";
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
        public string GetFieldValues(string sql)
        {
            string ma = "";
            SqlConnection conn = new SqlConnection(stringConnect);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            conn.Close();
            return ma;
        }
    }
}
