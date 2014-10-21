﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsInformationApp.DLL.DAO
{
    class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(string code, string name, int quantity):this()
        {
            Code = code;
            Name = name;
            Quantity = quantity;
        }

        public Product()
        {
        }
    }
}
