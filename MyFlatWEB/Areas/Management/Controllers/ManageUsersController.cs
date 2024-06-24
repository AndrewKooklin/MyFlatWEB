using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFlatWEB.Areas.Management.Models.Users;
using MyFlatWEB.Data;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageUsers/")]
    public class ManageUsersController : Controller
    {
        private DataManager _dataManager;
        IEnumerable<string> roleNames;
        AddUserModel _addUserModel = new AddUserModel();

        public ManageUsersController(DataManager dataManager)
        {
            _dataManager = dataManager;
            roleNames = _dataManager.Accounts.GetRoleNames().AsEnumerable();
        }

        [HttpGet]
        [Route("AllUsers")]
        public IActionResult AllUsers()
        {
            var users = _dataManager.Accounts.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult UserDetails(string id)
        {
            var user = _dataManager.Accounts.GetUserWithRoles(id);
            user.RolesList = roleNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            return View(user);
        }

        [HttpGet]
        public IActionResult AddNewUser()
        {
            _addUserModel = new AddUserModel
            {
                RolesList = roleNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };
            return View(_addUserModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dataManager.Accounts.AddNewUser(model);
                if (result)
                {
                    return RedirectToAction("AllUsers", "ManageUsers");
                }
                else
                {
                    _addUserModel = new AddUserModel
                    {
                        RolesList = roleNames.Select(i => new SelectListItem
                        {
                            Text = i,
                            Value = i
                        })
                    };
                    ModelState.AddModelError(string.Empty, "User already exist.");
                    return View(_addUserModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register model.");
                _addUserModel = new AddUserModel
                {
                    RolesList = roleNames.Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    })
                };
                return View(_addUserModel);
            }
        }
    }
}
