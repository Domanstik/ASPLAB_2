using ASPLAB_2.Data;
using ASPLAB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext dbProductContext;

        public ProductController(ProductContext dbProductContext)
        {
            this.dbProductContext = dbProductContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await dbProductContext.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product_)
        {
            await dbProductContext.AddAsync(product_);
            await dbProductContext.SaveChangesAsync();

            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var product = await dbProductContext.Products.FindAsync(Id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product_)
        {
            var product = await dbProductContext.Products.FindAsync(product_.Id);

            if (product is not null)
            {
                product.Id = product_.Id;
                product.Name = product_.Name;
                product.Prise = product_.Prise;

                await dbProductContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product_)
        {
            var product = await dbProductContext.Products.FindAsync(product_.Id);

            if (product is not null)
            {
                dbProductContext.Products.Remove(product);

                await dbProductContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
