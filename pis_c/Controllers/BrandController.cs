using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pis_c.Models.DBEntities;
using pis_c.ViewModels;

namespace pis_c.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        AppDbContext dbContext;

        public BrandController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult All()
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            return View(dbContext.Brands.OrderBy(b => b.Name).ToList());
        }

        public IActionResult Add()
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Add(BrandViewModel model)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                dbContext.Brands.Add(new Brand()
                {
                    Name = model.Name
                });
                dbContext.SaveChanges();
                return RedirectToAction("All");
            }
            return View(model);
        }

        public IActionResult Delete(int brandId)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");

            dbContext.Remove(dbContext.Brands.FirstOrDefault(b => b.Id == brandId));
            dbContext.SaveChanges();
            return RedirectToAction("All");
        }

        private bool IsAdmin(ClaimsPrincipal user)
        {
            var email = user.Claims.ElementAt(0).Value;
            return dbContext.Users.FirstOrDefault(u => u.Email == email).IsAdmin;
        }
    }
}