using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entities;
using TaskManager.WebApi.Controllers;
using TaskManager.WebApp.BusinessLayer;
using TaskManager.WebApp.ViewModels;
using TaskManager.Common;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        PlanManager planManager = new PlanManager();
        TMUserManager userManager = new TMUserManager();

        public IActionResult Index(Plan plan)
        {
            if(HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Index", "User");
            }
            
            ViewBag.PlanTypes = Ortak.GetPlanTypeList();

            if (plan.UserId != null)
            {
                return View(plan);
            }

            return View();
        }

        public IActionResult IndexGetPlan(string Id)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Index", "User");
            }
            
            ViewBag.PlanTypes = Ortak.GetPlanTypeList();

            TaskManagerResult<Plan> taskManagerResult = planManager.GetPlanById(Id);

            return View("Index", taskManagerResult.Result);
        }

        [HttpPost]
        public IActionResult AddPlan(Plan model)
        {
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                model.Owner = taskManagerResult.Result;
                model.UserId = taskManagerResult.Result.Id.ToString();

                if (ModelState.IsValid)
                { 
                    TaskManagerResult<Plan> result = planManager.AddPlan(model);

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
                }
            
                
            }

            

            return RedirectToAction("Plans");
        }

        public IActionResult Plans(List<Plan> plans)
        {
            List<Plan> listPlans = new List<Plan>();
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                listPlans = planManager.GetPlan(taskManagerResult.Result.Id.ToString());
            }

            return View(listPlans);
        }

        public IActionResult Daily()
        {
            List<Plan> listPlans = new List<Plan>();
            List<Plan> plans = new List<Plan>();
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                listPlans = planManager.GetPlan(taskManagerResult.Result.Id.ToString());
            }
            
            plans = listPlans.FindAll(x => x.Type == "Günlük").ToList();

            return View("Plans", plans);
        }

        public IActionResult Weekly()
        {
            List<Plan> listPlans = new List<Plan>();
            List<Plan> plans = new List<Plan>();
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                listPlans = planManager.GetPlan(taskManagerResult.Result.Id.ToString());
            }

            plans = listPlans.FindAll(x => x.Type == "Haftalık").ToList();

            return View("Plans", plans);
        }

        public IActionResult Monthly()
        {
            List<Plan> listPlans = new List<Plan>();
            List<Plan> plans = new List<Plan>();
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                listPlans = planManager.GetPlan(taskManagerResult.Result.Id.ToString());
            }

            plans = listPlans.FindAll(x => x.Type == "Aylık").ToList();

            return View("Plans", plans);
        }

        public IActionResult EndPlans()
        {
            List<Plan> listPlans = new List<Plan>();
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                listPlans = planManager.GetEndPlan(taskManagerResult.Result.Id.ToString());
            }

            return View(listPlans);
        }

        public IActionResult InCompletePlans()
        {
            List<Plan> listPlans = new List<Plan>();
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                listPlans = planManager.GetInCompletePlan(taskManagerResult.Result.Id.ToString());
            }

            return View(listPlans);
        }

        public IActionResult EditPlan(string Id)
        {
            TaskManagerResult<Plan> taskManagerResult = planManager.GetPlanById(Id);

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                List<PlanType> planTypes = new List<PlanType>();
                planTypes.Add(PlanType.Günlük);
                planTypes.Add(PlanType.Haftalık);
                planTypes.Add(PlanType.Aylık);

                ViewBag.PlanTypes = planTypes;

                return RedirectToAction("IndexGetPlan", taskManagerResult.Result);
            }
        }

        public IActionResult DeletePlan(string Id)
        {
            TaskManagerResult<Plan> taskManagerResult = planManager.DeletePlan(Id);

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                return RedirectToAction("Plans");
            }
        }

        [HttpPost]
        public IActionResult UpdatePlan(Plan model, string Id)
        {
            TaskManagerResult<TaskManagerUser> taskManagerResult = userManager.GetUser(HttpContext.Session.GetString("email"));

            if (taskManagerResult.Errors.Count > 0)
            {
                taskManagerResult.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "İşlem Başarısız",
                    RedirectingUrl = "Index",
                    Items = taskManagerResult.Errors
                };

                return PartialView("~/Views/Shared/ErrorModal.cshtml", errorModel);
            }
            else
            {
                model.Owner = taskManagerResult.Result;
                model.UserId = taskManagerResult.Result.Id.ToString();

                if (ModelState.IsValid)
                {
                    TaskManagerResult<Plan> result = planManager.UpdatePlan(model, Id);

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
                }


            }
            
            return RedirectToAction("Plans");
        }

    }
}
