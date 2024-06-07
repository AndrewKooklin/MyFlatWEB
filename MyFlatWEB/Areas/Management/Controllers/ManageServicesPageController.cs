using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Data;

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
    }
}
