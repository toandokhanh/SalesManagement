using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ImportBill
    {
        DAL_ImportBill dalImportBill= new DAL_ImportBill();
        public DataTable ListImportBill(string ma)
        {
            return dalImportBill.ListImportBills(ma);
        }
    }
}
