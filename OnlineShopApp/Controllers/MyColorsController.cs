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
    public class MyColorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyColors
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyColor.ToListAsync());
        }

        // GET: MyColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myColor = await _context.MyColor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myColor == null)
            {
                return NotFound();
            }

            return View(myColor);
        }

        // GET: MyColors/Create
        public IActionResult Create()
        {
            if (TempData["msg"]!=null)
            {

                ViewBag.msg = TempData["msg"].ToString();
            }
            return View();
        }

        // POST: MyColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ColorName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] MyColor myColor)
        {
            string msg = "";
            string colorName = myColor.ColorName;

            if (ModelState.IsValid)
            {

            var result = _context.MyColor.Where(c=>c.ColorName==colorName).FirstOrDefault();

                if (result!=null)
                {
                    msg = "Color Name already Exist.";
                    TempData["msg"] = msg;
                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    _context.Add(myColor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(myColor);
        }

        // GET: MyColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myColor = await _context.MyColor.FindAsync(id);
            if (myColor == null)
            {
                return NotFound();
            }
            return View(myColor);
        }

        // POST: MyColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColorName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] MyColor myColor)
        {
            if (id != myColor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyColorExists(myColor.Id))
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
            return View(myColor);
        }

        // GET: MyColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myColor = await _context.MyColor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myColor == null)
            {
                return NotFound();
            }

            return View(myColor);
        }

        // POST: MyColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myColor = await _context.MyColor.FindAsync(id);
            _context.MyColor.Remove(myColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyColorExists(int id)
        {
            return _context.MyColor.Any(e => e.Id == id);
        }
    }
}
