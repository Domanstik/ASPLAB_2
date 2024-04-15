using Microsoft.AspNetCore.Mvc;

namespace ASPLAB_2.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
