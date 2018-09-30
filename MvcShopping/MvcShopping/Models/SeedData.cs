using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MvcShopping.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcShoppingContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcShoppingContext>>()))
            {
                // Look for any products.
                if (context.Product.Any())
                {
                    return; // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "Хляб",
                        Number = 1,
                        Price = 0.99M
                    },

                    new Product
                    {
                        Name = "Памперси",
                        Number = 1,
                        Price = 19.99M
                    },

                    new Product
                    {
                        Name = "Масло",
                        Number = 2,
                        Price = 5.39M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
