using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ImportBill
    {   
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        public DataTable ListImportBills(string ma)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT a.HH_Ma, b.HH_Ten, a.SoLuongNhap, b.HH_DonGia,a.ThanhTien FROM CHITIET_HD_NHAP AS a, HANGHOA AS b WHERE a.HDn_Ma = @HDN_Ma AND a.HH_Ma=b.HH_Ma", conn);
                comd.CommandType = CommandType.Text;
                comd.Parameters.AddWithValue("@HDN_Ma", ma);
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
    }

}
