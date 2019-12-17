using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pis_c.Models;
using pis_c.Models.DBEntities;

namespace pis_c.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext dbContext;

        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        public IActionResult Index()
        {
            ViewBag.Cars = dbContext.Cars
                .Where(c => c.DeletedAt == null)
                .Include(c => c.DriveType)
                .Include(c => c.FuelType)
                .Include(c => c.GearBox)
                .Include(c => c.Photos)
                .Include(c => c.Model).ThenInclude(m => m.Brand)
                .Include(c => c.BodyType)
                .OrderByDescending(c => c.Id)
                .ToList();
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
