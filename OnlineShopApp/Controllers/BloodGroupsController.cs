using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShopApp.Data;
using OnlineShopApp.Models;

namespace OnlineShopApp.Controllers
{
    public class BloodGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BloodGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.BloodGroup.ToListAsync());
        }

        // GET: BloodGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroup = await _context.BloodGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodGroup == null)
            {
                return NotFound();
            }

            return View(bloodGroup);
        }

        // GET: BloodGroups/Create
        public IActionResult Create()
        {
            if (TempData["msg"]!=null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            return View();
        }

        // POST: BloodGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BloodGroupName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] BloodGroup bloodGroup)
        {
            if (ModelState.IsValid)
            {
                string msg = string.Empty;
                var result = _context.BloodGroup.FirstOrDefault(b => b.BloodGroupName == bloodGroup.BloodGroupName);
                if (result!=null)
                {
                    msg = "This blood Group name already exist!";
                    TempData["msg"] = msg;
                    return RedirectToAction("create");
                }
                else
                {
                    _context.Add(bloodGroup);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(bloodGroup);
        }

        // GET: BloodGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroup = await _context.BloodGroup.FindAsync(id);
            if (bloodGroup == null)
            {
                return NotFound();
            }
            return View(bloodGroup);
        }

        // POST: BloodGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BloodGroupName,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] BloodGroup bloodGroup)
        {
            if (id != bloodGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodGroupExists(bloodGroup.Id))
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
            return View(bloodGroup);
        }

        // GET: BloodGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodGroup = await _context.BloodGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodGroup == null)
            {
                return NotFound();
            }

            return View(bloodGroup);
        }

        // POST: BloodGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodGroup = await _context.BloodGroup.FindAsync(id);
            _context.BloodGroup.Remove(bloodGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodGroupExists(int id)
        {
            return _context.BloodGroup.Any(e => e.Id == id);
        }
    }
}
