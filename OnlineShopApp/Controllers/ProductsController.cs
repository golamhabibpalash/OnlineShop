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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.Brand).Include(p => p.MyColor).Include(p => p.MySize).Include(p => p.ProductType).Include(p => p.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.MyColor)
                .Include(p => p.MySize)
                .Include(p => p.ProductType)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Id");
            ViewData["MyColorId"] = new SelectList(_context.MyColor, "Id", "ColorName");
            ViewData["MySizeId"] = new SelectList(_context.Set<MySize>(), "Id", "SizeName");
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Id");
            ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,UoM,ProductPrice,Discount,MyColorId,MySizeId,BrandId,ProductTypeId,SupplierId,IsAvailable,ProdImage,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Id", product.BrandId);
            ViewData["MyColorId"] = new SelectList(_context.MyColor, "Id", "ColorName", product.MyColorId);
            ViewData["MySizeId"] = new SelectList(_context.Set<MySize>(), "Id", "SizeName", product.MySizeId);
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Id", product.ProductTypeId);
            ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "Id", product.SupplierId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Id", product.BrandId);
            ViewData["MyColorId"] = new SelectList(_context.MyColor, "Id", "ColorName", product.MyColorId);
            ViewData["MySizeId"] = new SelectList(_context.Set<MySize>(), "Id", "SizeName", product.MySizeId);
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Id", product.ProductTypeId);
            ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "Id", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,UoM,ProductPrice,Discount,MyColorId,MySizeId,BrandId,ProductTypeId,SupplierId,IsAvailable,ProdImage,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "Id", product.BrandId);
            ViewData["MyColorId"] = new SelectList(_context.MyColor, "Id", "ColorName", product.MyColorId);
            ViewData["MySizeId"] = new SelectList(_context.Set<MySize>(), "Id", "SizeName", product.MySizeId);
            ViewData["ProductTypeId"] = new SelectList(_context.Set<ProductType>(), "Id", "Id", product.ProductTypeId);
            ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "Id", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.MyColor)
                .Include(p => p.MySize)
                .Include(p => p.ProductType)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
