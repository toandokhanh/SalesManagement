using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ExportBill
    {
        DAL_ExportBills dalHDX = new DAL_ExportBills();
        public DataTable ListExportBill()
        {
            return dalHDX.ListExportBills();
        }
        public bool InsertExportBills(DTO_HoaDonXuat bushdx)
        {
            return dalHDX.InsertExportBills(bushdx);
        }
        //public bool UpdateProduct(DTO_HangHoa product)
        //{
        //    return dalproduct.UpdateProduct(product);
        //}
        //public bool DeleteProduct(string hh_ma)
        //{
        //    //MessageBox.Show("Tầng BUS:" + hh_ma);
        //    return dalproduct.DeleteProduct(hh_ma);
        //}
        //public DataTable SearchProduct(string tenhang)
        //{
        //    return dalproduct.SearchProduct(tenhang);
        //}
    }
}
