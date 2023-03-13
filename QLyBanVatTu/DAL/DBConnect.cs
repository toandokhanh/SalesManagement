using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DbConnect
    {
        static string connstr = ConfigurationManager.ConnectionStrings["SalesManagement"].ToString();
        public SqlConnection conn = new SqlConnection(connstr);
    }
}
