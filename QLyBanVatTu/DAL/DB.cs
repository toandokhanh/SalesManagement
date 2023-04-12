using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DB
    {
        static string connstr = ConfigurationManager.ConnectionStrings["QLVT"].ToString();
        protected SqlConnection conn = new SqlConnection(connstr);
    }
}
