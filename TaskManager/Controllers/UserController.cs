using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entities;
using TaskManager.Entities.Messages;
using TaskManager.Entities.ValueObjects;
using TaskManager.WebApi.Controllers;
using TaskManager.WebApi.Services;
using TaskManager.WebApp.BusinessLayer;
using TaskManager.WebApp.ViewModels;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {
        TMUserManager userManager = new TMUserManager();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                TaskManagerResult<TaskManagerUser> result = userManager.LoginUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    ErrorViewModel errorModel = new ErrorViewModel()
                    {
                        Title = "İşlem Başarısız",
                        RedirectingUrl = "Index",
                        Items = result.Errors
                    };

                    return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
                }

                HttpContext.Session.SetString("email", result.Result.Email);

                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                TaskManagerResult<TaskManagerUser> result = userManager.RegisterUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    ErrorViewModel errorModel = new ErrorViewModel()
                    {
                        Title = "İşlem Başarısız",
                        RedirectingUrl = "Register",
                        Items = result.Errors
                    };

                    return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
                }

                InfoViewModel infoModel = new InfoViewModel()
                {
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "Index"
                };

                return PartialView("~/Views/Shared/InfoModal.cshtml", infoModel);
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return View("Index");
        }
    }
}