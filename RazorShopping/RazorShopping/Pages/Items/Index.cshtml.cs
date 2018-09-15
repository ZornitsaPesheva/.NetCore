using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorShopping.Models;

namespace RazorShopping.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly RazorShopping.Models.RazorShoppingContext _context;

        public IndexModel(RazorShopping.Models.RazorShoppingContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }
        public SelectList ProductTypes { get; set; }
        public string selectedProductType { get; set; }


        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task OnGetAsync(string selectedProductType, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> productTypeQuery = from i in _context.Item
                                                  orderby i.ProductType
                                                  select i.ProductType;

            var items = from i in _context.Item
                        select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(selectedProductType))
            {
                items = items.Where(x => x.ProductType == selectedProductType);
            }

            ProductTypes = new SelectList(await productTypeQuery.Distinct().ToListAsync());
            Item = await items.ToListAsync();
        }
    }
}
