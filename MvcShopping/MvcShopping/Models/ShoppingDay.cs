﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcShopping.Models
{
    public class ShoppingDay
    {
        public int ID { get; set; }

        [Display(Name = "Shopping Date")]
        [DataType(DataType.Date)]
        public DateTime ShoppingDate { get; set; }
        public Dictionary<int, string> BougthOutProducts =
            new Dictionary<int, string>();

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Sum { get; set; }
    }
}
