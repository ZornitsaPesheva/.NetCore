using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcShopping.Models
{
    public class StoreViewModel
    {
        public List<ShoppingDay> ShoppingDays;
        public SelectList Stores;
        public string ShoppingStore { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
