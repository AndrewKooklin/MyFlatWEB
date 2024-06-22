using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Account;

namespace MyFlatWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataManager _dataManager;

        public AccountController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View("RegisterUser");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _dataManager.Accounts.CreateUser(model);
                if (result)
                {
                    ViewBag.Message = "You have successfully registered," +
                                      "\nlog in with your email and password.";
                    RedirectToAction("LogInUser", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User already exist.");
                    return View("RegisterUser");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register model.");
                return View("RegisterUser");
            }

            return View("RegisterUser");
        }
    }
}
