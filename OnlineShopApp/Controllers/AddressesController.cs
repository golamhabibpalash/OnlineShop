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
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Address.Include(a => a.District).Include(a => a.Division).Include(a => a.PostOffice).Include(a => a.ThanaOrUpazila);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.District)
                .Include(a => a.Division)
                .Include(a => a.PostOffice)
                .Include(a => a.ThanaOrUpazila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id");
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "Id");
            ViewData["PostOfficeId"] = new SelectList(_context.PostOffice, "Id", "Id");
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DivisionId,DistrictId,ThanaOrUpazilaId,PostOfficeId,EmployeeId,CustomerId,MyAddress,SupplierId,AddressType,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", address.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "Id", address.DivisionId);
            ViewData["PostOfficeId"] = new SelectList(_context.PostOffice, "Id", "Id", address.PostOfficeId);
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id", address.ThanaOrUpazilaId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", address.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "Id", address.DivisionId);
            ViewData["PostOfficeId"] = new SelectList(_context.PostOffice, "Id", "Id", address.PostOfficeId);
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id", address.ThanaOrUpazilaId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DivisionId,DistrictId,ThanaOrUpazilaId,PostOfficeId,EmployeeId,CustomerId,MyAddress,SupplierId,AddressType,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Id", address.DistrictId);
            ViewData["DivisionId"] = new SelectList(_context.Division, "Id", "Id", address.DivisionId);
            ViewData["PostOfficeId"] = new SelectList(_context.PostOffice, "Id", "Id", address.PostOfficeId);
            ViewData["ThanaOrUpazilaId"] = new SelectList(_context.ThanaOrUpazila, "Id", "Id", address.ThanaOrUpazilaId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.District)
                .Include(a => a.Division)
                .Include(a => a.PostOffice)
                .Include(a => a.ThanaOrUpazila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Address.FindAsync(id);
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
