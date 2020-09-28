using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShopApp.Data;
using OnlineShopApp.Models;

namespace OnlineShopApp.Controllers
{
    public class ThanaOrUpazilasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThanaOrUpazilasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThanaOrUpazilas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ThanaOrUpazila.Include(t => t.District);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ThanaOrUpazilas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanaOrUpazila = await _context.ThanaOrUpazila
                .Include(t => t.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thanaOrUpazila == null)
            {
                return NotFound();
            }

            return View(thanaOrUpazila);
        }

        // GET: ThanaOrUpazilas/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id");
            return View();
        }

        // POST: ThanaOrUpazilas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DistrictId,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] ThanaOrUpazila thanaOrUpazila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanaOrUpazila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", thanaOrUpazila.DistrictId);
            return View(thanaOrUpazila);
        }

        // GET: ThanaOrUpazilas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanaOrUpazila = await _context.ThanaOrUpazila.FindAsync(id);
            if (thanaOrUpazila == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", thanaOrUpazila.DistrictId);
            return View(thanaOrUpazila);
        }

        // POST: ThanaOrUpazilas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DistrictId,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] ThanaOrUpazila thanaOrUpazila)
        {
            if (id != thanaOrUpazila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanaOrUpazila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanaOrUpazilaExists(thanaOrUpazila.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", thanaOrUpazila.DistrictId);
            return View(thanaOrUpazila);
        }

        // GET: ThanaOrUpazilas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanaOrUpazila = await _context.ThanaOrUpazila
                .Include(t => t.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thanaOrUpazila == null)
            {
                return NotFound();
            }

            return View(thanaOrUpazila);
        }

        // POST: ThanaOrUpazilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thanaOrUpazila = await _context.ThanaOrUpazila.FindAsync(id);
            _context.ThanaOrUpazila.Remove(thanaOrUpazila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanaOrUpazilaExists(int id)
        {
            return _context.ThanaOrUpazila.Any(e => e.Id == id);
        }
    }
}
