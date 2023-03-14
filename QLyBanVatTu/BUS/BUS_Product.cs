using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Product
    {
        DAL_Products dalproduct = new DAL_Products();
        public DataTable ListProduct()
        {
            return dalproduct.ListProduct();
        }
    }
}
