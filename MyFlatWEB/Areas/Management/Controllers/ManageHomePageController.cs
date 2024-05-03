using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Data;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageHomePage/")]
    public class ManageHomePageController : Controller
    {
        private DataManager _dataManager;

        public ManageHomePageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("HomePage")]
        public IActionResult HomePage()
        {



            return View();
        }
    }
}
