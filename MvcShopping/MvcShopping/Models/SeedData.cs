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

                if (context.ShoppingDay.Any())
                {
                    return;
                }

                var sd = new ShoppingDay();

                context.ShoppingDay.AddRange(
                    new ShoppingDay
                    {
                        ShoppingDate = DateTime.Parse("2018-9-30"),
                        Sum = 28.25M
                    },

                    new ShoppingDay
                    {
                        ShoppingDate = DateTime.Parse("2018-10-4"),
                        Sum = 14.29M
                    },

                    new ShoppingDay
                    {
                        ShoppingDate = DateTime.Parse("2018-10-7"),
                        Sum = 15.67M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
