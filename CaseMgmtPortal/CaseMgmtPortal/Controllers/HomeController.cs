﻿using Microsoft.AspNetCore.Mvc;

namespace CaseMgmtPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
