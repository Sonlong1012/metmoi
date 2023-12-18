using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webbanhang_22011267.Models;
using Webbanhang_22011267.Data;
namespace Webbanhang_22011267.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _dbContext;
        public HomeController(ILogger<HomeController> logger, AppDBContext context )
        {
            _logger = logger;
            this._dbContext = context;
        }

        //public IActionResult Details(int id)
        //{
        //    var products = _dbContext.Products.ToList();
        //    return View(products);
        //}
        public IActionResult Index()
        {
            var products = _dbContext.Products.ToList();

            return View(products);
        }

        public IActionResult List(int id)
        {
            var products = _dbContext.Products.Where(c=>c.DanhMucID == id).ToList();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult subpage()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}