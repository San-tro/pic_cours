using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Parties.Models.PasswordHasher;
using pis_c.Models.DBEntities;
using pis_c.ViewModels;

namespace pis_c.Controllers
{
    public class UserController : Controller
    {
        AppDbContext dbContext;
        IPasswordHasher passwordHasher;

        public UserController(AppDbContext dbContext, IPasswordHasher passwordHasher)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(dbContext.Users.FirstOrDefault(u => u.Email == model.Email) != null)
            {
                ModelState.AddModelError("", "Данный email уже используется");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                RegisterUser(model);
                await Authenticate(model.Email);
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Ошибка!");
            return View(model);
        }

        private void RegisterUser(RegisterViewModel model)
        {
            dbContext.Users.Add(new User
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Password = passwordHasher.GetHash(model.Password),
                Phone = model.Phone,
                DriverLicense = model.DriverLicense,
                Registration = model.Registration,
                IsAdmin = false,
                Passport = model.Passport
            });
            dbContext.SaveChanges();
        }

        [HttpGet]
        public IActionResult Login()
        {            
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Email == model.Login && u.Password == passwordHasher.GetHash(model.Password));
                if (user != null)
                {
                    await Authenticate(model.Login);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пожалуйста, введите корректный логин и пароль");
                }
            }
            return View(model);
        }

        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}