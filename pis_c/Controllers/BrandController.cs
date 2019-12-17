using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pis_c.Models.DBEntities;
using pis_c.ViewModels;

namespace pis_c.Controllers
{
    public class BrandController : Controller
    {
        AppDbContext dbContext;

        public BrandController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult All()
        {
            return View(dbContext.Brands.OrderBy(b => b.Name).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BrandViewModel model)
        {
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
            dbContext.Remove(dbContext.Brands.FirstOrDefault(b => b.Id == brandId));
            dbContext.SaveChanges();
            return RedirectToAction("All");
        }
    }
}