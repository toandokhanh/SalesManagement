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
    public class DAL_TKHT : DbConnect
    {
        public bool CheckLogin(string email, string password)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("proc_login", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@pass", password);
            return true;
            
        }
    }

}
