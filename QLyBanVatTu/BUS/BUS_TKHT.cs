using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

namespace BUS
{
    public class BUS_TKHT
    {
        DAL_TKHT thkt = new DAL_TKHT();
        public string CheckLogin(DTO_TKHT TKHT)
        {
            // Kiểm tra nghiệp vụ
            if (TKHT.Tkht_Email == "")
            {
                return "requeid_taikhoan";
            }

            if (TKHT.Tkht_Password == "")
            {
                return "requeid_password";
            }
            string info = thkt.CheckLogin(TKHT);
            return info;
        }
        public string checkRole(DTO_TKHT TKHT)
        {
            string role = thkt.checkRole(TKHT);
            return role;
        }
    }
}
