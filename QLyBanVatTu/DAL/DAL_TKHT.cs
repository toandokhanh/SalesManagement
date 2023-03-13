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
       public string CheckLogin(DTO_TKHT TKHT)
        {
            string info = CheckLoginDTO(TKHT);

            return info;
        }
    }

}
