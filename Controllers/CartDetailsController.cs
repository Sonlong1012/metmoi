using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webbanhang_22011267.Data;
using Webbanhang_22011267.Models;

namespace Webbanhang_22011267.Controllers
{
    public class CartDetailsController : Controller
    {
        private readonly AppDBContext _context;

        public CartDetailsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: CartDetails
        public async Task<IActionResult> Index()
        {
              return _context.CartDetails != null ? 
                          View(await _context.CartDetails.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.CartDetails'  is null.");
        }

        // GET: CartDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CartDetails == null)
            {
                return NotFound();
            }

            var cartDetails = await _context.CartDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartDetails == null)
            {
                return NotFound();
            }

            return View(cartDetails);
        }

        // GET: CartDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GioHangID,SanPhamID,SoLuong,TongTien")] CartDetails cartDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartDetails);
        }

        // GET: CartDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CartDetails == null)
            {
                return NotFound();
            }

            var cartDetails = await _context.CartDetails.FindAsync(id);
            if (cartDetails == null)
            {
                return NotFound();
            }
            return View(cartDetails);
        }

        // POST: CartDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GioHangID,SanPhamID,SoLuong,TongTien")] CartDetails cartDetails)
        {
            if (id != cartDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartDetailsExists(cartDetails.Id))
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
            return View(cartDetails);
        }

        // GET: CartDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CartDetails == null)
            {
                return NotFound();
            }

            var cartDetails = await _context.CartDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartDetails == null)
            {
                return NotFound();
            }

            return View(cartDetails);
        }

        // POST: CartDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CartDetails == null)
            {
                return Problem("Entity set 'AppDBContext.CartDetails'  is null.");
            }
            var cartDetails = await _context.CartDetails.FindAsync(id);
            if (cartDetails != null)
            {
                _context.CartDetails.Remove(cartDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartDetailsExists(int id)
        {
          return (_context.CartDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
