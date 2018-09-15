using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace RazorShopping.Models
{

        public static class SeedData
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new RazorShoppingContext(
                    serviceProvider.GetRequiredService<DbContextOptions<RazorShoppingContext>>()))
                {
                    // Look for any Items.
                    if (context.Item.Any())
                    {
                        return; // DB has been seeded
                    }

                    context.Item.AddRange(
                        new Item
                        {
                            Name = "Памперси",
                            Price = 19.99M,
                            ProductType = "Памперси"
                        },

                        new Item
                        {
                            Name = "хляб",
                            Price = 1.00M,
                            ProductType = "храна"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
 }
