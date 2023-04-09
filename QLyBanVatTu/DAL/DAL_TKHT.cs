using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;

namespace DAL
{
    public class DAL_TKHT : DbConnect
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        public string CheckLogin(DTO_TKHT TKHT)
        {
            string info = CheckLoginDTO(TKHT);

            return info;
        }
        public string checkRole(DTO_TKHT tkht)
        {
            string role = checkRoleDTO(tkht);
            return role;
        }
        public DataTable GetTKHT(string role, string email)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT b.PQ_Ten, a.PQ_Ma FROM dbo.TAI_KHOAN_HE_THONG as a, dbo.PHAN_QUYEN AS b where a.PQ_Ma = b.PQ_Ma and b.PQ_Ma = @PQ_Ma and a.TKHT_Email = @TKHT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PQ_Ma", role);
                cmd.Parameters.AddWithValue("@TKHT", email);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(table);
            }
            catch (Exception)
            {
                // Xử lý ngoại lệ
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
            return ma;
        }
        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ChangePassword";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("oldPassword", oldPassword);
                cmd.Parameters.AddWithValue("newPassword", newPassword);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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
    }

}
