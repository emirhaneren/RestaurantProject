﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdminLayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
