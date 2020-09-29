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
    public class PostOfficesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostOfficesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostOffices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PostOffice.Include(p => p.ThanaOrUpazila);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PostOffices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postOffice = await _context.PostOffice
                .Include(p => p.ThanaOrUpazila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postOffice == null)
            {
                return NotFound();
            }

            return View(postOffice);
        }

        // GET: PostOffices/Create
        public IActionResult Create()
        {
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id");
            return View();
        }

        // POST: PostOffices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PostCode,ThanaOrUpazilaId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] PostOffice postOffice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id", postOffice.ThanaOrUpazilaId);
            return View(postOffice);
        }

        // GET: PostOffices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postOffice = await _context.PostOffice.FindAsync(id);
            if (postOffice == null)
            {
                return NotFound();
            }
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id", postOffice.ThanaOrUpazilaId);
            return View(postOffice);
        }

        // POST: PostOffices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PostCode,ThanaOrUpazilaId,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] PostOffice postOffice)
        {
            if (id != postOffice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostOfficeExists(postOffice.Id))
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
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id", postOffice.ThanaOrUpazilaId);
            return View(postOffice);
        }

        // GET: PostOffices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postOffice = await _context.PostOffice
                .Include(p => p.ThanaOrUpazila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postOffice == null)
            {
                return NotFound();
            }

            return View(postOffice);
        }

        // POST: PostOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postOffice = await _context.PostOffice.FindAsync(id);
            _context.PostOffice.Remove(postOffice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostOfficeExists(int id)
        {
            return _context.PostOffice.Any(e => e.Id == id);
        }
    }
}
