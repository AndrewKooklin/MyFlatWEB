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
            var projects = _dataManager.PageEditor.GetProjectsFromDB();
            return View("ProjectsPage", projects);
        }

        [Route("AddProject")]
        public IActionResult AddProject()
        {
            return View("AddProjectPage");
        }

        [Route("AddProjectToDB")]
        public async Task<IActionResult> AddProjectToDB(ProjectModel model, IFormFile image)
        {
            if (String.IsNullOrEmpty(model.ProjectHeader) ||
                String.IsNullOrEmpty(model.ProjectDescription) ||
                image == null)
            {
                return View("AddProjectPage");
            }
            else
            {
                model.ProjectImage = new byte[image.Length];
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }

                model.ProjectImage = imageData;

                bool result = await _dataManager.PageEditor.AddProjectToDB(model);

                if (result)
                {
                    var projects = _dataManager.PageEditor.GetProjectsFromDB();
                    return View("ProjectsPage", projects);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("ChangeProjectPage")]
        public IActionResult ChangeProjectPage(int id)
        {
            var project = _dataManager.PageEditor.GetProjectById(id) ;
            ViewBag.FileName = "Choose image";
            return View("ChangeProjectPage", project);
        }
        
        [Route("ChangeProject")]
        public async Task<IActionResult> ChangeProject(ProjectModel model, IFormFile image)
        {
            if (String.IsNullOrEmpty(model.ProjectHeader) ||
                String.IsNullOrEmpty(model.ProjectDescription) ||
                image == null)
            {
                ViewBag.FileName = "Choose image";
                return View("ChangeProjectPage", model);
            }
            else
            {
                ViewBag.FileName = image.FileName;
                model.ProjectImage = new byte[image.Length];
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }

                model.ProjectImage = imageData;

                bool result = await _dataManager.PageEditor.ChangeProject(model);

                if (result)
                {
                    var projects = _dataManager.PageEditor.GetProjectsFromDB();
                    return View("ProjectsPage", projects);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("DeleteProjectById")]
        public async Task<IActionResult> DeleteProjectById(int id)
        {
            bool result = await _dataManager.PageEditor.DeleteProjectById(id);

            if (result)
            {
                return RedirectToAction("Projects", "ManageProjectsPage");
            }
            else
            {
                ErrorModel error = new ErrorModel();
                error.Message = "Server error";
                return View("ErrorView", error);
            }
        }
        
    }
}
