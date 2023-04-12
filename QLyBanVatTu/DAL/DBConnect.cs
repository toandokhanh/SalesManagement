using System.Data.SqlClient;
using System.Configuration;
using DTO;
using System.Data;
using System.Reflection.Emit;

namespace DAL
{

    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";    
            SqlConnection conn = new SqlConnection(stringConnect);
            //conn.ConnectionString = stringConnect;
            //conn.Open();
            return conn;
        }
    }
    public class DbConnect
    {
        public static string CheckLoginDTO(DTO_TKHT tkht)
        {
            string user = null;
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("proc_check_login", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", tkht.Tkht_Email);
            command.Parameters.AddWithValue("@pass", tkht.Tkht_Password);
            //command.Parameters.AddWithValue("@roles", tkht.Pq_Ma);
            command.Connection = conn;


            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                }
                reader.Close();
                
                conn.Close();

            }
            else
            {
                return "Tài khoản hoặc mật khẩu không chích xác";
            }
            return user;
        }
        public string checkRoleDTO(DTO_TKHT tkht)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("select PQ_Ma from TAI_KHOAN_HE_THONG WHERE TKHT_Email = @username",conn);
            command.CommandType = CommandType.Text;
            command.Connection = conn;
            command.Parameters.AddWithValue("@username", tkht.Tkht_Email);
            string role = (string)command.ExecuteScalar();
            return role;

        }
    }
}
