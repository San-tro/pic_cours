﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pis_c.Models;
using pis_c.Models.DBEntities;

namespace pis_c.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(AppDbContext dbContext)
        {

        }

        
        public IActionResult Index()
        {
            var test = "test";
            return View();
        }

        public IActionResult Privacy()
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
