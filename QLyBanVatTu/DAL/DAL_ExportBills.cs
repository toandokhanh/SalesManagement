using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ExportBills
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";

        public DataTable ListExportBills()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT * FROM dbo.HOA_DON_XUAT", conn);
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
        public bool InsertExportBills(DTO_HoaDonXuat HDX)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("InsertHDX", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("maDon", HDX.Hdx_Ma);
                comd.Parameters.AddWithValue("makh",HDX.Ma_KH);
                comd.Parameters.AddWithValue("emailtkht", HDX.Tkht_Email);
                comd.Parameters.AddWithValue("ngaylap", HDX.Hdx_NgayLap);
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
        public bool UpdateExportBills(DTO_HoaDonXuat HDX)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("UpdateHDX", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("maDon", HDX.Hdx_Ma);
                comd.Parameters.AddWithValue("makh", HDX.Ma_KH);
                comd.Parameters.AddWithValue("emailtkht", HDX.Tkht_Email);
                comd.Parameters.AddWithValue("ngaylap", HDX.Hdx_NgayLap);
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
        public bool DeleteHDX(string mahdx)
        {
            //MessageBox.Show("Tầng DAL:" + hh_ma);
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "Delete from HOA_DON_XUAT where HDX_Ma = '" + mahdx + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                //MessageBox.Show(query);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("mahdx", mahdx);
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
        public DataTable SearchHDX(string tenkh)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SearchHDX", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("tenkh", tenkh);
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
