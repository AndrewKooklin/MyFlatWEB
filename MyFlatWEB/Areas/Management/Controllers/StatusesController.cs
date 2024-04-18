using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Areas.Management.Models;
using MyFlatWEB.Areas.Management.Models.Rendering;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Rendering;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/Statuses")]
    public class StatusesController : Controller
    {
        private DataManager _dataManager;

        public StatusesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        
    }
}
