using Microsoft.AspNetCore.Mvc;

namespace ASPLAB_2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
