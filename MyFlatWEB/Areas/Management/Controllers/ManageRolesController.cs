using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Data;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageRoles/")]
    public class ManageRolesController : Controller
    {
        private readonly DataManager _dataManager;

        public ManageRolesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Roles()
        {
            var roles = _dataManager.Accounts.GetRoles();
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRole(IdentityRole role)
        {
            var result = _dataManager.Accounts.CreateRole(role).GetAwaiter().GetResult();
            if (result)
            {
                return RedirectToAction("Roles", "ManageRoles");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid add role !");
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteRole(string id)
        {
            var result = _dataManager.Accounts.DeleteRole(id).GetAwaiter().GetResult();
            if (result)
            {
                return RedirectToAction("Roles", "ManageRoles");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid delete role !");
                return RedirectToAction("Roles", "ManageRoles");
            }
        }
    }
}
