using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Data;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageProjectsPage/")]
    public class ManageBlogPageController : Controller
    {
        private DataManager _dataManager;
        private static readonly Encoding encoding = Encoding.UTF8;

        public ManageBlogPageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("Blog")]
        public IActionResult Blog()
        {
            var posts = _dataManager.PageEditor.GetProjectsFromDB();
            return View("BlogPage", posts);
        }
    }
}
