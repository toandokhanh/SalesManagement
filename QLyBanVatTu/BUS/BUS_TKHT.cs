using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
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
    }
}
