using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DAL
{
    public class DAL_ExportBills
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";

        public DataTable ListExportBills(string ma)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT a.HH_Ma, b.HH_Ten, a.SoLuongXuat, b.HH_DonGia,a.ThanhTien FROM CHI_TIET_HD_XUAT AS a, HANGHOA AS b WHERE a.HDX_Ma = @HDX_Ma AND a.HH_Ma=b.HH_Ma", conn);
                comd.CommandType = CommandType.Text;
                comd.Parameters.AddWithValue("@HDX_Ma", ma);
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
        public void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public bool InsertExportBills(DTO_HoaDonXuat HDX)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "INSERT INTO HOA_DON_XUAT(HDX_Ma, Ma_KH, TKHT_Email, HDX_NgayBan, HDX_TongTien) VALUES(maDon, makh, emailtkht, ngaylap, tongtien)";
                SqlCommand comd = new SqlCommand(query);
                comd.CommandType = CommandType.Text;
                comd.Parameters.AddWithValue("maDon", HDX.Hdx_Ma);
                comd.Parameters.AddWithValue("makh",HDX.Ma_KH);
                comd.Parameters.AddWithValue("emailtkht", HDX.Tkht_Email);
                comd.Parameters.AddWithValue("ngaylap", HDX.Hdx_NgayLap);
                comd.Parameters.AddWithValue("tongtien", HDX.TongTien);
                //MessageBox.Show(HDX.Hdx_Ma);
                //MessageBox.Show(HDX.Ma_KH);
                //MessageBox.Show(HDX.Tkht_Email);
                //MessageBox.Show(HDX.TongTien);
                if (comd.ExecuteNonQuery() > 0) { 
                    return true;
                    }
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
        public bool UpdateExportBills(DTO_HoaDonXuat HDX)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("UpdateHDX", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("maDon", HDX.Hdx_Ma);
                comd.Parameters.AddWithValue("makh", HDX.Ma_KH);
                comd.Parameters.AddWithValue("emailtkht", HDX.Tkht_Email);
                comd.Parameters.AddWithValue("ngaylap", HDX.Hdx_NgayLap);
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
        public bool CheckKey(string sql)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
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
        public DataTable GetDataToTable(string sql)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            SqlDataAdapter dap = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = conn; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        public static string ChuyenSoSangChu(string sNumber)
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
        public bool DeleteHDX(string mahdx)
        {
            //MessageBox.Show("Tầng DAL:" + hh_ma);
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "Delete from HOA_DON_XUAT where HDX_Ma = '" + mahdx + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                //MessageBox.Show(query);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("mahdx", mahdx);
                if (cmd.ExecuteNonQuery() > 0)
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
        public DataTable SearchHDX(string tenkh)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SearchHDX", conn);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("tenkh", tenkh);
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
