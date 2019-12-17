using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pis_c.Models.DBEntities;
using pis_c.ViewModels;

namespace pis_c.Controllers
{
    public class ModelController : Controller
    {
        AppDbContext dbContext;

        public ModelController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult All()
        {
            return View(dbContext.Models.Include(m => m.Brand).OrderBy(m => m.Brand.Name));
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Brands = dbContext.Brands.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(ModelViewModel model)
        {
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
            dbContext.Models.Remove(dbContext.Models.FirstOrDefault(m => m.Id == modelId));
            dbContext.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult ModelsHtmlOptions(int brandId)
        {
            return PartialView(dbContext.Models.Where(m => m.BrandId == brandId).ToList());
        }
    }
}