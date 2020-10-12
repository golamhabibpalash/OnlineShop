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
    public class MySizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MySizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MySizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MySize.ToListAsync());
        }

        // GET: MySizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySize = await _context.MySize
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mySize == null)
            {
                return NotFound();
            }

            return View(mySize);
        }

        // GET: MySizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MySizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SizeName,ShortName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] MySize mySize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mySize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mySize);
        }

        // GET: MySizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySize = await _context.MySize.FindAsync(id);
            if (mySize == null)
            {
                return NotFound();
            }
            return View(mySize);
        }

        // POST: MySizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SizeName,ShortName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] MySize mySize)
        {
            if (id != mySize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mySize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MySizeExists(mySize.Id))
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
            return View(mySize);
        }

        // GET: MySizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySize = await _context.MySize
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mySize == null)
            {
                return NotFound();
            }

            return View(mySize);
        }

        // POST: MySizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mySize = await _context.MySize.FindAsync(id);
            _context.MySize.Remove(mySize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MySizeExists(int id)
        {
            return _context.MySize.Any(e => e.Id == id);
        }
    }
}
