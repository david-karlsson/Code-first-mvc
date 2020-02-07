using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demodb.Data;
using demodb.Models;

namespace demodb.Controllers
{
    public class ProductFeatImgsController : Controller
    {


        public PartialViewResult ProductsPartialView()
        {
            return PartialView();
        }

        private readonly DatabaseContext _context;

        public ProductFeatImgsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProductFeatImgs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductFeatImg.ToListAsync());
        }

        // GET: ProductFeatImgs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFeatImg = await _context.ProductFeatImg
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productFeatImg == null)
            {
                return NotFound();
            }

            return View(productFeatImg);
        }

        // GET: ProductFeatImgs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductFeatImgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Image")] ProductFeatImg productFeatImg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productFeatImg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productFeatImg);
        }

        // GET: ProductFeatImgs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFeatImg = await _context.ProductFeatImg.FindAsync(id);
            if (productFeatImg == null)
            {
                return NotFound();
            }
            return View(productFeatImg);
        }

        // POST: ProductFeatImgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Image")] ProductFeatImg productFeatImg)
        {
            if (id != productFeatImg.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productFeatImg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductFeatImgExists(productFeatImg.ID))
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
            return View(productFeatImg);
        }

        // GET: ProductFeatImgs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFeatImg = await _context.ProductFeatImg
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productFeatImg == null)
            {
                return NotFound();
            }

            return View(productFeatImg);
        }

        // POST: ProductFeatImgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productFeatImg = await _context.ProductFeatImg.FindAsync(id);
            _context.ProductFeatImg.Remove(productFeatImg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductFeatImgExists(int id)
        {
            return _context.ProductFeatImg.Any(e => e.ID == id);
        }
    }


}
