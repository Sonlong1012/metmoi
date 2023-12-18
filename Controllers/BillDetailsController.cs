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
    public class BillDetailsController : Controller
    {
        private readonly AppDBContext _context;

        public BillDetailsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: BillDetails
        public async Task<IActionResult> Index()
        {
              return _context.BillDetails != null ? 
                          View(await _context.BillDetails.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.BillDetails'  is null.");
        }

        // GET: BillDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BillDetails == null)
            {
                return NotFound();
            }

            var billDetails = await _context.BillDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billDetails == null)
            {
                return NotFound();
            }

            return View(billDetails);
        }

        // GET: BillDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BillDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoaDonID,SanPhamID,Gia,SoLuong,TongTien")] BillDetails billDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billDetails);
        }

        // GET: BillDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BillDetails == null)
            {
                return NotFound();
            }

            var billDetails = await _context.BillDetails.FindAsync(id);
            if (billDetails == null)
            {
                return NotFound();
            }
            return View(billDetails);
        }

        // POST: BillDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoaDonID,SanPhamID,Gia,SoLuong,TongTien")] BillDetails billDetails)
        {
            if (id != billDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillDetailsExists(billDetails.Id))
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
            return View(billDetails);
        }

        // GET: BillDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BillDetails == null)
            {
                return NotFound();
            }

            var billDetails = await _context.BillDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billDetails == null)
            {
                return NotFound();
            }

            return View(billDetails);
        }

        // POST: BillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BillDetails == null)
            {
                return Problem("Entity set 'AppDBContext.BillDetails'  is null.");
            }
            var billDetails = await _context.BillDetails.FindAsync(id);
            if (billDetails != null)
            {
                _context.BillDetails.Remove(billDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillDetailsExists(int id)
        {
          return (_context.BillDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
