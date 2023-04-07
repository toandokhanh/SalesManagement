using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_HangHoa 
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";

        public DataTable ListProduct()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT * FROM dbo.HANGHOA", conn);
                comd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally { 
                conn.Close();
            }
        }
        public bool InsertProduct(DTO_HangHoa product)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("InsertofProducts", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("mahang", product.Hh_Ma);
                comd.Parameters.AddWithValue("maloai", product.Lh_Ma);
                comd.Parameters.AddWithValue("manuocsx", product.Nsx_Ma);
                comd.Parameters.AddWithValue("manhacungcap", product.Ncc_ma);
                comd.Parameters.AddWithValue("tenhang", product.Hh_Ten);
                comd.Parameters.AddWithValue("soluonghang", product.Hh_SoLuong);
                comd.Parameters.AddWithValue("motahang", product.Hh_MoTa);
                comd.Parameters.AddWithValue("dongiahang", product.Hh_DonGia);
                comd.Parameters.AddWithValue("hinhanh", product.Hh_HinhAnh);
                if (comd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }
        public bool UpdateProduct(DTO_HangHoa product)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("UpdateProduct", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("mahang", product.Hh_Ma);
                comd.Parameters.AddWithValue("maloai", product.Lh_Ma);
                comd.Parameters.AddWithValue("manuocsx", product.Nsx_Ma);
                comd.Parameters.AddWithValue("manhacungcap", product.Ncc_ma);
                comd.Parameters.AddWithValue("tenhang", product.Hh_Ten);
                comd.Parameters.AddWithValue("soluonghang", product.Hh_SoLuong);
                comd.Parameters.AddWithValue("motahang", product.Hh_MoTa);
                comd.Parameters.AddWithValue("dongiahang", product.Hh_DonGia);
                comd.Parameters.AddWithValue("hinhanh", product.Hh_HinhAnh);
                if (comd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }
        public string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp break; 
                    switch ((mLen - i) % 9)
                    {
                        case 0:
                            mTemp = mTemp + " tỷ";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        case 6:
                            mTemp = mTemp + " triệu";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        case 3:
                            mTemp = mTemp + " nghìn";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        default:
                            switch ((mLen - i) % 3)
                            {
                                case 2:
                                    mTemp = mTemp + " trăm";
                                    break;
                                case 1:
                                    mTemp = mTemp + " mươi";
                                    break;
                            }
                            break;
                    }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", ""); //Loại bỏ trường hợp 00x 
            mTemp = mTemp.Replace("không mươi ", "linh "); //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }
        public  bool DeleteProduct(string hh_ma)
        {
            //MessageBox.Show("Tầng DAL:" + hh_ma);
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "Delete from HANGHOA where HH_Ma = '" + hh_ma + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                //MessageBox.Show(query);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("hh_ma", hh_ma);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }
        public DataTable SearchProduct(string tenhang)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SearchProduct", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("tenhanghoa", tenhang);
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetVatTu()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT HH_Ma FROM dbo.HANGHOA", conn);
                comd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
        public string GetFieldValues(string sql)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            conn.Close();
            return ma;
        }
    }
}
