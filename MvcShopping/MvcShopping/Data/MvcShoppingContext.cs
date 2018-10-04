using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcShopping.Models;

namespace MvcShopping.Models
{
    public class MvcShoppingContext : DbContext
    {
        public MvcShoppingContext (DbContextOptions<MvcShoppingContext> options)
            : base(options)
        {
        }

        public DbSet<MvcShopping.Models.Product> Product { get; set; }

        public DbSet<MvcShopping.Models.ShoppingDay> ShoppingDay { get; set; }
    }
}
