using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Areas.Management.Models;
using MyFlatWEB.Areas.Management.Models.EditPages;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Rendering;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageProjectsPage/")]
    public class ManageProjectsPageController : Controller
    {
        private DataManager _dataManager;
        private static readonly Encoding encoding = Encoding.UTF8;

        public ManageProjectsPageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("Projects")]
        public IActionResult Projects()
        {
            return View("ProjectsPage");
        }

        [Route("AddProject")]
        public IActionResult AddProject()
        {
            return View("AddProjectPage");
        }

        [Route("AddProjectToDB")]
        public IActionResult AddProjectToDB(ProjectModel model, IFormFile image)
        {
            return View("AddProjectPage");
        }
    }
}
