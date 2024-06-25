using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFlatWEB.Areas.Management.Models.Users;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Account;

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
        [Route("UserDetails")]
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
        [Route("[controller]/AddUser")]
        public IActionResult AddUser()
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
        [Route("[controller]/AddNewUser")]
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
                    return View("AddUser", _addUserModel);
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
                return View("AddUser", _addUserModel);
            }
        }

        [HttpPost]
        [Route("[controller]/AddRoleToUser")]
        public IActionResult AddRoleToUser(UserWithRolesModel model)
        {
            RoleUserModel roleUserModel = new RoleUserModel();
            var user = _dataManager.Accounts.GetUserWithRoles(model.User.Id);
            user.RolesList = roleNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            if (model.Role == null)
            {
                user.RolesList = roleNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                ModelState.AddModelError("Add", "Select role !");
                return View("UserDetails", user);
            }
            if (user.Roles.Contains(model.Role))
            {
                user.RolesList = roleNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                ModelState.AddModelError("Add", "The User already has a role !");
                return View("UserDetails", user);
            }
            else
            {
                ModelState.AddModelError("Add", String.Empty);
                roleUserModel.UserId = model.User.Id;
                roleUserModel.Role = model.Role;

                bool result = _dataManager.Accounts.AddRoleToUser(roleUserModel).GetAwaiter().GetResult();
                if (result)
                {
                    user = _dataManager.Accounts.GetUserWithRoles(model.User.Id);
                    user.RolesList = roleNames.Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    });
                    ModelState.AddModelError("Add", "Role added.");
                    return View("UserDetails", user);
                }
                else
                {
                    ModelState.AddModelError("Add", "Role is not added !");
                    return View("UserDetails", user);
                }
            }
        }

        [HttpPost]
        [Route("[controller]/DeleteRoleUser")]
        public IActionResult DeleteRoleUser(UserWithRolesModel model)
        {
            RoleUserModel roleUserModel = new RoleUserModel();
            var user = _dataManager.Accounts.GetUserWithRoles(model.User.Id);
            user.RolesList = roleNames.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
            if (!user.Roles.Any() || user.Roles.Count < 1)
            {
                user.RolesList = roleNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                ModelState.AddModelError("Delete", "The User has no roles !");
                return View("UserDetails", user);
            }
            if (model.Role == null)
            {
                user.RolesList = roleNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                ModelState.AddModelError("Delete", "Select role !");
                return View("UserDetails", user);
            }
            if (!user.Roles.Contains(model.Role))
            {
                user.RolesList = roleNames.Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });
                ModelState.AddModelError("Delete", "The User has no role !");
                return View("UserDetails", user);
            }
            else
            {
                ModelState.AddModelError("Delete", String.Empty);
                roleUserModel.UserId = model.User.Id;
                roleUserModel.Role = model.Role;

                bool result = _dataManager.Accounts.DeleteRoleUser(roleUserModel).GetAwaiter().GetResult();
                if (result)
                {
                    user = _dataManager.Accounts.GetUserWithRoles(model.User.Id);
                    user.RolesList = roleNames.Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    });
                    ModelState.AddModelError("Delete", "Role removed.");
                    return View("UserDetails", user);
                }
                else
                {
                    user.RolesList = roleNames.Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    });
                    ModelState.AddModelError("Delete", "Role is not removed !");
                    return View("UserDetails", user);
                }
            }
        }

        [HttpGet]
        [Route("[controller]/DeleteUser")]
        public IActionResult DeleteUser(string id)
        {
            bool resultRoles = _dataManager.Accounts.DeleteRolesUser(id).GetAwaiter().GetResult();
            if (resultRoles)
            {
                bool resultUser = _dataManager.Accounts.DeleteUser(id).GetAwaiter().GetResult();
                if (resultUser)
                {
                    var users = _dataManager.Accounts.GetUsers();
                    ModelState.AddModelError(String.Empty, "User deleted.");
                    return View("AllUsers", users);
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "User is not deleted !");
                    var users = _dataManager.Accounts.GetUsers();
                    return View("AllUsers", users);
                }
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Roles for user is not removed !");
                var users = _dataManager.Accounts.GetUsers();
                return View("AllUsers", users);
            }
        }


    }
}
