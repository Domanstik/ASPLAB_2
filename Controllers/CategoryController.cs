﻿using Microsoft.AspNetCore.Mvc;

namespace ASPLAB_2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
