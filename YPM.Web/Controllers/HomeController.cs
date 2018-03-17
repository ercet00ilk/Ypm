﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YPM.Web.Models;

namespace YPM.Web.Controllers
{
    public class HomeController 
        : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        
    }
}