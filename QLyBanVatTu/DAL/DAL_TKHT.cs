using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_TKHT : DbConnect
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        public string CheckLogin(DTO_TKHT TKHT)
        {
            string info = CheckLoginDTO(TKHT);

            return info;
        }
        public string checkRole(DTO_TKHT tkht)
        {
            string role = checkRoleDTO(tkht);
            return role;
        }
        public DataTable GetTKHT(string role, string email)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT b.PQ_Ten, a.PQ_Ma FROM dbo.TAI_KHOAN_HE_THONG as a, dbo.PHAN_QUYEN AS b where a.PQ_Ma = b.PQ_Ma and b.PQ_Ma = @PQ_Ma and a.TKHT_Email = @TKHT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PQ_Ma", role);
                cmd.Parameters.AddWithValue("@TKHT", email);
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(table);
            }
            catch (Exception)
            {
                // Xử lý ngoại lệ
            }
            finally
            {
                conn.Close();
            }
            return table;
        }
        public string GetFieldValues(string sql)
        {
            string query = "";
            SqlConnection conn = new SqlConnection(stringConnect);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                query = reader.GetValue(0).ToString();
            reader.Close();
            return query;
        }
        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ChangePassword";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("oldPassword", oldPassword);
                cmd.Parameters.AddWithValue("newPassword", newPassword);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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
        public DataTable ListStaff()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT a.TKHT_Email, a.TKHT_HoTen, b.PQ_Ten, a.TKHT_DiaChi, a.TKHT_SoDienThoai,CASE WHEN a.TKHT_GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END AS TKHT_GioiTinh,a.TKHT_NgaySinh FROM TAI_KHOAN_HE_THONG AS a JOIN PHAN_QUYEN AS b ON a.PQ_Ma = b.PQ_Ma", conn);
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
        public DataTable PhanQuyen()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT * FROM dbo.PHAN_QUYEN";
                SqlDataAdapter data = new SqlDataAdapter(query, conn);
                data.Fill(table);
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            return table;
        }

        //public bool InsertStaff(DTO_TKHT dtotkht)
        //{
        //    SqlConnection conn = new SqlConnection(stringConnect);
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand comd = new SqlCommand("Insert into TAI_KHOAN_HE_THONG VALUES(@email, @hoten, @pq_ma, @matkhau, @diachi, @sodienthoai, @gioitinh, @ngaysinh)", conn);
        //        comd.CommandType = CommandType.Text;
        //        comd.Parameters.AddWithValue("@email", dtotkht.Tkht_Email);
        //        comd.Parameters.AddWithValue("@hoten", dtotkht.Tkht_HoTen);
        //        comd.Parameters.AddWithValue("@pqma", dtotkht.Pq_Ma);
        //        comd.Parameters.AddWithValue("@diachi", dtotkht.Tkht_DiaChi);
        //        comd.Parameters.AddWithValue("@sodienthoai", dtotkht.Tkht_SoDienThoai);
        //        comd.Parameters.AddWithValue("@gioitinh", dtotkht.Tkht_GioiTinh);
        //        comd.Parameters.AddWithValue("@ngaysinh", dtotkht.Tkht_NgaySinh);
        //        string parametersString = "";
        //        foreach (SqlParameter parameter in comd.Parameters)
        //        {
        //            parametersString += parameter.ParameterName + " = " + parameter.Value + "; ";
        //        }

        //        MessageBox.Show(parametersString);
        //        if (comd.ExecuteNonQuery() > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return false;
        //}
    }

}
