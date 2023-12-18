using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Webbanhang_22011267.Areas.Admin.Controllers;
using Webbanhang_22011267.Data;
using Webbanhang_22011267.Models;

namespace Webbanhang_22011267.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly AppDBContext _context;
        

        public ProductsController(ILogger<ProductsController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = _context.Products.ToList();
            //return _context.Products != null ? 
            //              View(await _context.Products.ToListAsync()) :
            //              Problem("Entity set 'AppDBContext.Products'  is null.");
            return View(products);
        }

        /// Thêm sản phẩm vào cart
        [Route("addcart/{productid:int}")]
        public IActionResult AddToCart([FromRoute] int productid)
        {

            var product = _context.Products
                            .Where(p => p.Id == productid)
                            .FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");

            // Xử lý đưa vào Cart ...


            return RedirectToAction(nameof(Cart));
        }

        // Hiện thị giỏ hàng
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View();
        }

        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";

        // Lấy cart từ Session (danh sách CartItem)
        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
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
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DanhMucID,Ten,Gia,SoLuong,NgayNhap,ThuongHieu,MoTa,Hinh")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DanhMucID,Ten,Gia,SoLuong,NgayNhap,ThuongHieu,MoTa,Hinh")] Product product)
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
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
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDBContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> sachvan()
        {
            return _context.Products != null ?
                        View(await _context.Products.ToListAsync()) :
                        Problem("Entity set 'AppDBContext.Products'  is null.");
        }
        //public async Task<IActionResult> sachtoan()
        //{
        //    return _context.Products != null ?
        //                View(await _context.Products.ToListAsync()) :
        //                Problem("Entity set 'AppDBContext.Products'  is null.");
        //}
        //public async Task<IActionResult> sachvan()
        //{
        //    return _context.Products != null ?
        //                View(await _context.Products.ToListAsync()) :
        //                Problem("Entity set 'AppDBContext.Products'  is null.");
        //}

        public IActionResult Category(int? id)
        {
            var category = this._context.Products.Where(c => c.DanhMucID == id).ToList();

            return View(category);
        }
    }
    
}
