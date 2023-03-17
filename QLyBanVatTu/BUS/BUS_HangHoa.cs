﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_HangHoa
    {
        DAL_HangHoa dalproduct = new DAL_HangHoa();
        public DataTable ListProduct()
        {
            return dalproduct.ListProduct();
        }
        public bool InsertProduct(DTO_HangHoa product) 
        {
            return dalproduct.InsertProduct(product);
        }
        public bool UpdateProduct(DTO_HangHoa product) 
        {
            return dalproduct.UpdateProduct(product);
        }
        public bool DelectProduct(string hh_ma)
        {
            return dalproduct.DelectProduct(hh_ma);
        }
    }
}
