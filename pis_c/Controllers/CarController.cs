using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pis_c.Models.DBEntities;
using pis_c.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace pis_c.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        AppDbContext dbContext;

        public CarController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult All()
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            return View(dbContext.Cars
                .Where(c => c.DeletedAt == null)
                .Include(c => c.Model).ThenInclude(m => m.Brand)
                .OrderBy(c => c.Model.Brand.Name)
                .ToList());
        }

        public IActionResult Add()
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            FillViewBagForAddingCar();
            return View();
        }



        [HttpPost]
        public IActionResult Add(CarViewModel model)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");
            if (!ModelState.IsValid)
            {
                FillViewBagForAddingCar();
                return View(model);
            }
            AddCar(model);
            UploadPhoto(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int carId)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");

            //доделать
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(CarViewModel model, int carId)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");

            //доделать
            throw new NotImplementedException();
        }

        public IActionResult Delete(int carId)
        {
            if (!IsAdmin(HttpContext.User))
                return RedirectToAction("Index", "Home");

            dbContext.Cars.FirstOrDefault(c => c.Id == carId).DeletedAt = DateTime.Now;
            dbContext.SaveChanges();
            return RedirectToAction("All");
        }

        [AllowAnonymous]
        public IActionResult GetPhoto(int carId)
        {
            var bytes = dbContext.Photos.FirstOrDefault(ph => ph.CarId == carId).Content;
            return File(bytes, "image/jpeg");
        }

        private void UploadPhoto(CarViewModel model)
        {
            var stream = model.Photo.OpenReadStream();
            byte[] bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, (int) stream.Length);
            dbContext.Photos.Add(new Photo()
            {
                Content = bytes,
                //вообще лучше по-другому, работает при условии, что админ один
                CarId = dbContext.Cars.Last().Id
            });
            dbContext.SaveChanges();
        }

        private void AddCar(CarViewModel model)
        {
            dbContext.Cars.Add(new Car()
            {
                ModelId = model.ModelId,
                Abs = model.Abs,
                Ac = model.Ac,
                Asc = model.Asc,
                BodyTypeId = model.BodyTypeId,
                CarClassId = model.CarClassId,
                Climate = model.Climate,
                Cost = model.Cost,
                Cruise = model.Cruise,
                Description = model.Description,
                DriverAirbag = model.DriverAirbag,
                DriveTypeId = model.DriveTypeId,
                EngineVol = (float) model.EngineVol,
                Esp = model.Esp, 
                FuelTypeId = model.FuelTypeId,
                GearBoxId = model.GearBoxId,
                Kilometrage = model.Kilometrage,
                PassangerAirbag = model.PassangerAirbag,
                Power = model.Power,
                SeatsAmmount = model.SeatsAmmount,
                StateNum = model.StateNum,
                Year = model.Year,
            });
            dbContext.SaveChanges();
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

        private bool IsAdmin(ClaimsPrincipal user)
        {
            var email = user.Claims.ElementAt(0).Value;
            return dbContext.Users.FirstOrDefault(u => u.Email == email).IsAdmin;
        }
    }
}
