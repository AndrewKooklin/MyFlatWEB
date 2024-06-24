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
                    return RedirectToAction("LogInUser", "Account");
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
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            return View("LoginUser");
        }

        [HttpPost]
        public async Task<IActionResult> LogInUser(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                bool userExist = await _dataManager.Accounts.CheckUserToDB(model);
                if(!userExist)
                {
                    return Redirect("LogInError");
                }
                else
                {
                    UserRolesModel.Roles = await _dataManager.Accounts.GetUserRoles(model);
                    if (UserRolesModel.Roles == null)
                    {
                        UserRolesModel.EMail = model.Email;
                        UserRolesModel.Roles = new List<string> { "Anonymus" };
                        return RedirectToAction("Index", "Home");
                    }
                    else if (UserRolesModel.Roles != null)
                    {
                        UserRolesModel.EMail = model.Email;

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register model.");
                return View(model);
            }
            return View(model);
        }

        public IActionResult LogInError()
        {
            return View("LogInError");
        }

        public IActionResult LogoutUser()
        {
            _dataManager.Accounts.LogoutUser();
            UserRolesModel.EMail = "";
            UserRolesModel.Roles = new List<string> { "Anonymus" };
            return RedirectToAction("Index", "Home");
        }
    }
}
