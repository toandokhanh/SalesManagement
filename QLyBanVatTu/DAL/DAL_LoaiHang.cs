using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_LoaiHang
    {
        string stringConnect = @"Server=CAT-JUNIOR\SQLEXPRESS;Database=QLVT;integrated security=true";
        public DataTable GetLoaiHang()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            DataTable table = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT * FROM dbo.LOAI_HANG";
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


        public void HienThiDG(string sql, DataGridView dg, SqlConnection conn)
        {
            SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
            DataSet dase = new DataSet();
            dt.Fill(dase, "a");
            dg.DataSource = dase;
            dg.DataMember = "a";
        }
        public void addProducts(string mloai, string tloai, string mota, SqlConnection conn)
        {
            string query = "insert into LOAI_HANG values('" + mloai + "',N'" + tloai + "','" + mota + "')";

            try
            {
                SqlCommand comd = new SqlCommand(query, conn);
                comd.ExecuteNonQuery();
                MessageBox.Show("Thêm danh mục thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void deleteProducts(String maHang, DataGridView dg, SqlConnection conn)
        {
            string query_sql = "DELETE FROM LOAI_HANG WHERE LH_ma='" + maHang + "'";
            MessageBox.Show("Bạn có chắc chắn muốn xóa !");
            try
            {
                SqlCommand comd = new SqlCommand(query_sql, conn);
                comd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void updateProducts(string maloai, string tenloai, string mota, SqlConnection conn)
        {
            string query = "UPDATE LOAI_HANG SET LH_ten=N'" + tenloai + "',LH_mota=N'" + mota + "' Where LH_ma='"+maloai+"'";
            try
            {
                SqlCommand comd = new SqlCommand(query, conn);
                comd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật danh mục '" + maloai + "' thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowData(TextBox maloai, TextBox tenloai, TextBox mota, DataGridView dg, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
