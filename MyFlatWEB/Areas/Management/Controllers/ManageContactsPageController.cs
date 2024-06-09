using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Areas.Management.Models.EditPages;
using MyFlatWEB.Data;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageContactsPage/")]
    public class ManageContactsPageController : Controller
    {
        private DataManager _dataManager;
        private static readonly Encoding encoding = Encoding.UTF8;

        public ManageContactsPageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("Contacts")]
        public IActionResult Contacts()
        {
            ContactsPlaceholderModel cphm = new ContactsPlaceholderModel();
            cphm.Contacts = _dataManager.PageEditor.GetContactsFromDB();
            cphm.SocialLinks = _dataManager.PageEditor.GetSocialLinksFromDB();
            return View("ContactsPage", cphm);
        }


    }
}
