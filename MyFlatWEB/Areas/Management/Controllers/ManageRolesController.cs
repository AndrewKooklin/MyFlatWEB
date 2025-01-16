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

        [HttpGet]
        [Route("[controller]/Roles")]
        public IActionResult Roles()
        {
            var roles = _dataManager.Accounts.GetRoles();
            return View(roles);
        }

        [HttpGet]
        [Route("[controller]/AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/CreateRole")]
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
        [Route("[controller]/DeleteRole")]
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
