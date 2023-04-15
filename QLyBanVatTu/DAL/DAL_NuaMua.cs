using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_NuaMua
    {
        public string CreateNewID(string query)
        {
            //code nửa mùa của anh tònh
            string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
            SqlConnection conn = new SqlConnection(stringConnect);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            string largestHHMa = command.ExecuteScalar().ToString();
            string[] parts = largestHHMa.Split('_');  // Tách chuỗi thành mảng các chuỗi con bằng dấu '_'
            string a = parts[0];  // Lấy phần tử đầu tiên của mảng là chuỗi a
            string b = parts.Length > 1 ? parts[1] : "";  // Lấy phần tử thứ hai của mảng nếu có, nếu không có thì lấy chuỗi rỗng ""
            int intValue;
            int.TryParse(b, out intValue);
            int intB = intValue;
            intB++;
            a = a + '_';
            string newID = a + intB.ToString();
            conn.Close();
            //kết thúc code nửa
            return newID;
        }

    }
}
