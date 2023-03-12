using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class SqlConnectionData
    {
        // tao chuoi ket noi csdl
        public static SqlConnection Connnect()
        {
            string stringConnect = @"Server=MSI\SQL;Database=QLVatTu;integrated security=true";
            SqlConnection conn = new SqlConnection(stringConnect);
            //conn.ConnectionString = stringConnect;
            //conn.Open();
            return conn;
        }
    }
    public class DBConnect
    {
        public static string CheckLogin(DTO_TKHT TKHT)
        {
            string user = null;
            // ket noi den csdl
            SqlConnection conn = SqlConnectionData.Connnect();
            conn.Open();
            SqlCommand command= new SqlCommand("proc_login", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", TKHT.TKHT_Email);
            command.Parameters.AddWithValue("@pass", TKHT.TKHT_Password);
            // lay ma quyen de kiem tra 
            command.Parameters.AddWithValue("@roles", TKHT.PQ_Ma);
            return user;
        }

    } 
}
