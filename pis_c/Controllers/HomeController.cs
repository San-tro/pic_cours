using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pis_c.Models;
using pis_c.Models.DBEntities;
using pis_c.ViewModels;

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
            FillViewBagForAddingCar();
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

        [HttpPost]
        public List<CarResponse> Filter(CarFilter model)
        {
            if (model.BrandId != null && model.ModelId == null)
            {
                model.ModelId = dbContext.Models.Where(m => m.BrandId == model.BrandId).First().Id;
            } // TODO: SORTING!!!!!
            var cars = dbContext.Cars
                .Where(car => 
                    car.DeletedAt == null
                    && ((model.CostFrom == null && model.CostTo == null) || car.Cost >= model.CostFrom && car.Cost <= model.CostTo)
                    && (model.Year == null || car.Year == model.Year)
                    && (!model.DriverAirbag || car.DriverAirbag)
                    && (!model.PassangerAirbag || car.PassangerAirbag)
                    && (!model.Abs || car.Abs)
                    && (!model.Asc || car.Asc)
                    && (!model.Esp || car.Esp)
                    && (!model.Climate || car.Climate)
                    && (!model.Ac || car.Ac)
                    && (!model.Cruise || car.Cruise)
                    && (model.SeatsAmmount == null || car.SeatsAmmount == model.SeatsAmmount)
                    && (model.EngineVol == null || car.EngineVol == model.EngineVol)
                    && (model.Power == null || car.Power == model.Power)
                    && (model.CarClassId == null || car.CarClassId == model.CarClassId)
                    && (model.ModelId == null || car.ModelId == model.ModelId)
                    && (model.FuelTypeId == null || car.FuelTypeId == model.FuelTypeId)
                    && (model.BodyTypeId == null || car.BodyTypeId == model.BodyTypeId)
                    && (model.DriveTypeId == null || car.DriveTypeId == model.DriveTypeId)
                    && (model.GearBoxId == null || car.GearBoxId == model.GearBoxId)
                )
                .Include(c => c.DriveType)
                .Include(c => c.GearBox)
                .Include(c => c.Model).ThenInclude(m => m.Brand)
                .Include(c => c.BodyType)
                .OrderByDescending(c => c.Id)
                .ToList();
            var carsResponse = new List<CarResponse>();
            foreach(var car in cars) // i love crutches, пришлось так сделать из-за невозможности сериализации
            {
                carsResponse.Add(new CarResponse
                {
                    Id = car.Id,
                    DriveType = car.DriveType.Name,
                    GearBox = car.GearBox.Name,
                    Model = car.Model.Name,
                    Brand = dbContext.Brands.Where(x => x.Id == car.Model.BrandId).First().Name,
                    BodyType = car.BodyType.Name
                });

            }
            return carsResponse;
        }

        private void FillViewBagForAddingCar()
        {
            ViewBag.Brands = dbContext.Brands.ToList();
            ViewBag.CarClasses = dbContext.CarClasses.ToList();
            ViewBag.FuelTypes = dbContext.FuelTypes.ToList();
            ViewBag.BodyTypes = dbContext.BodyTypes.ToList();
            ViewBag.DriveTypes = dbContext.DriveTypes.ToList();
            ViewBag.GearBoxes = dbContext.GearBoxes.ToList();
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
