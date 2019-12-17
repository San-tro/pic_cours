using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pis_c.Models.DBEntities;

namespace pis_c.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        AppDbContext dbContext;

        public AdminController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if (HttpContext.User == null || !IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            return View();
        }

        private bool IsAdmin(ClaimsPrincipal user)
        {
            var email = user.Claims.ElementAt(0).Value;
            return dbContext.Users.FirstOrDefault(u => u.Email == email).IsAdmin;
        }
    }
}