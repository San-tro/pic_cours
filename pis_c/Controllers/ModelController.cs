using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pis_c.Models.DBEntities;
using pis_c.ViewModels;

namespace pis_c.Controllers
{
    [Authorize]
    public class ModelController : Controller
    {
        AppDbContext dbContext;

        public ModelController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult All()
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            return View(dbContext.Models.Include(m => m.Brand).OrderBy(m => m.Brand.Name));
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            ViewBag.Brands = dbContext.Brands.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(ModelViewModel model)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                dbContext.Models.Add(new Model()
                {
                    BrandId = model.BrandId,
                    Name = model.Name
                });
                dbContext.SaveChanges();
                return RedirectToAction("All");
            }
            return View(model);
        }

        public IActionResult Delete(int modelId)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            dbContext.Models.Remove(dbContext.Models.FirstOrDefault(m => m.Id == modelId));
            dbContext.SaveChanges();
            return RedirectToAction("All");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ModelsHtmlOptions(int brandId)
        {
            return PartialView(dbContext.Models.Where(m => m.BrandId == brandId).ToList());
        }

        [HttpPost]
        public int GetFirstModel(int brandId)
        {
            return dbContext.Models.Where(m => m.BrandId == brandId).First().Id;
        }

        private bool IsAdmin(ClaimsPrincipal user)
        {
            var email = user.Claims.ElementAt(0).Value;
            return dbContext.Users.FirstOrDefault(u => u.Email == email).IsAdmin;
        }
    }
}