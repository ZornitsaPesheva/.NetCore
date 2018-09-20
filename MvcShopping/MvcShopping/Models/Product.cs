using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcShopping.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public short Number { get; set; }
        public decimal Price { get; set; }
    }
}
