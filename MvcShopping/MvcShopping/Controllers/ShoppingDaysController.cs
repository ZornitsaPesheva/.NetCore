using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcShopping.Models;

namespace MvcShopping.Controllers
{
    public class ShoppingDaysController : Controller
    {
        private readonly MvcShoppingContext _context;

        public ShoppingDaysController(MvcShoppingContext context)
        {
            _context = context;
        }

        // GET: ShoppingDays
        public async Task<IActionResult> Index(string shoppingStore, DateTime searchDate)
        {
            IQueryable<string> storeQuery = from s in _context.ShoppingDay
                                            orderby s.Store
                                            select s.Store;

            var records = from r in _context.ShoppingDay
                       select r;

            if (!(searchDate == DateTime.MinValue))
            {
                records = records.Where(s => s.ShoppingDate==(searchDate));
            }

            if (!String.IsNullOrEmpty(shoppingStore))
            {
                records = records.Where(x => x.Store == shoppingStore);
            }

            var storeVM = new StoreViewModel();
            storeVM.Stores = new SelectList(await storeQuery.Distinct().ToListAsync());
            storeVM.ShoppingDays = await records.ToListAsync();
            storeVM.SearchDate = searchDate;    

            return View(storeVM);
        }

        // GET: ShoppingDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingDay = await _context.ShoppingDay
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingDay == null)
            {
                return NotFound();
            }

            return View(shoppingDay);
        }

        // GET: ShoppingDays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ShoppingDate,Store,Sum")] ShoppingDay shoppingDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingDay);
        }

        // GET: ShoppingDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingDay = await _context.ShoppingDay.FindAsync(id);
            if (shoppingDay == null)
            {
                return NotFound();
            }
            return View(shoppingDay);
        }

        // POST: ShoppingDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ShoppingDate,Store,Sum")] ShoppingDay shoppingDay)
        {
            if (id != shoppingDay.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingDayExists(shoppingDay.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingDay);
        }

        // GET: ShoppingDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingDay = await _context.ShoppingDay
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingDay == null)
            {
                return NotFound();
            }

            return View(shoppingDay);
        }

        // POST: ShoppingDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingDay = await _context.ShoppingDay.FindAsync(id);
            _context.ShoppingDay.Remove(shoppingDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingDayExists(int id)
        {
            return _context.ShoppingDay.Any(e => e.ID == id);
        }
    }
}
