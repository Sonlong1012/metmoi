using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Webbanhang_22011267.Data;

namespace Webbanhang_22011267.Components
{
    public class CategoryViewComponent: ViewComponent
    {
        private readonly AppDBContext _dbContext;

        public CategoryViewComponent(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CateList = await _dbContext.Category.ToListAsync();

            return View(CateList);
        }


    }
}
