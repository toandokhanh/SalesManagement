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
        string stringConnect = @"Server=MSI\SQL;Database=QLVT;integrated security=true";
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
        public DataTable GetTKHT(string role)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT TKHT_Email, PQ_Ma FROM dbo.TAI_KHOAN_HE_THONG where PQ_Ma = @PQ_Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PQ_Ma", role);
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


    }

}
