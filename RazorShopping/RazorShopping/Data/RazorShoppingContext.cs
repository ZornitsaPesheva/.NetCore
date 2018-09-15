using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorShopping.Models
{
    public class RazorShoppingContext : DbContext
    {
        public RazorShoppingContext (DbContextOptions<RazorShoppingContext> options)
            : base(options)
        {
        }

        public DbSet<RazorShopping.Models.Item> Item { get; set; }
    }
}
