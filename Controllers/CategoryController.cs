using ASPLAB_2.Data;
using ASPLAB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ASPLAB_2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryContext dbCategoryContext;

        public CategoryController(CategoryContext dbCategoryContext)
        {
            this.dbCategoryContext = dbCategoryContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await dbCategoryContext.Categories.ToListAsync();
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category_)
        {
            await dbCategoryContext.AddAsync(category_);
            await dbCategoryContext.SaveChangesAsync();

            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var category = await dbCategoryContext.Categories.FindAsync(Id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category_)
        {
            var category = await dbCategoryContext.Categories.FindAsync(category_.Id);

            if (category is not null)
            {
                category.Id = category_.Id;
                category.Name = category_.Name;
                category.Description = category_.Description;

                await dbCategoryContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Category");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Category category_) 
        {
            var category = await dbCategoryContext.Categories.FindAsync(category_.Id);

            if (category is not null)
            {
                dbCategoryContext.Categories.Remove(category);

                await dbCategoryContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Category");
        }
    }
}
