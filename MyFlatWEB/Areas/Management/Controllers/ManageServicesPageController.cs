using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Areas.Management.Models;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Rendering;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageServicesPage/")]
    public class ManageServicesPageController : Controller
    {
        private DataManager _dataManager;

        public ManageServicesPageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("Services")]
        public IActionResult Services()
        {
            var services = _dataManager.PageEditor.GetServicesFromDB();
            return View("ServicesPage", services);
        }

        [Route("AddServicePage")]
        public IActionResult AddServicePage()
        {
            return View("AddServicePage");
        }

        [Route("AddServiceToDB")]
        public async Task<IActionResult> AddServiceToDB(ServiceModel model)
        {
            if (String.IsNullOrEmpty(model.ServiceName) ||
                String.IsNullOrEmpty(model.ServiceDescription))
            {
                return View("AddServicePage");
            }
            else
            {
                bool result = await _dataManager.PageEditor.AddServiceToDB(model);

                if (result)
                {
                    var services = _dataManager.PageEditor.GetServicesFromDB();
                    return View("ServicesPage", services);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("ChangeServicePage")]
        public IActionResult ChangeServicePage(int id)
        {
            var service = _dataManager.PageEditor.GetServiceById(id);
            return View("ChangeServicePage", service);
        }

        [Route("ChangeService")]
        public async Task<IActionResult> ChangeService(ServiceModel model)
        {
            if (String.IsNullOrEmpty(model.ServiceName) ||
                String.IsNullOrEmpty(model.ServiceDescription))
            {
                return View("ChangeServicePage", model);
            }
            else
            {
                bool result = await _dataManager.PageEditor.ChangeService(model);

                if (result)
                {
                    var services = _dataManager.PageEditor.GetServicesFromDB();
                    return View("ServicesPage", services);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("DeleteServiceById")]
        public async Task<IActionResult> DeleteServiceById(int id)
        {
            bool result = await _dataManager.PageEditor.DeleteServiceById(id);

            if (result)
            {
                return RedirectToAction("Services", "ManageServicesPage");
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
