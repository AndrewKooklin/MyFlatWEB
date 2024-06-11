using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        [Route("ChangeContacts")]
        public async Task<IActionResult> ChangeContacts(ContactsPlaceholderModel model)
        {
            if(String.IsNullOrEmpty(model.Contacts.ContactAddress) ||
               String.IsNullOrEmpty(model.Contacts.ContactPhone) ||
               String.IsNullOrEmpty(model.Contacts.ContactEmail))
            {
                return RedirectToAction("Contacts", "ManageContactsPage");
            }
            else
            {
                bool result = await _dataManager.PageEditor.ChangeContacts(model.Contacts);

                if (result)
                {
                    return RedirectToAction("Contacts", "ManageContactsPage");
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("AddSocialPage")]
        public IActionResult AddSocialPage()
        {
            return View("AddSocialPage");
        }

        [Route("AddSocialToDB")]
        public async Task<IActionResult> AddSocialToDB(SocialModel model, IFormFile image)
        {
            if (String.IsNullOrEmpty(model.SocialLink) ||
                image == null)
            {
                return View("AddSocialPage");
            }
            else
            {
                model.SocialImage = new byte[image.Length];
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }

                model.SocialImage = imageData;

                bool result = await _dataManager.PageEditor.AddSocialToDB(model);

                if (result)
                {
                    return RedirectToAction("Contacts", "ManageContactsPage");
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("ChangeSocial")]
        public async Task<IActionResult> ChangeSocial(SocialModel model, IFormFile image)
        {
            if (String.IsNullOrEmpty(model.SocialLink) ||
                image == null)
            {
                ViewBag.FileName = "Choose image";
                return View("ChangeSocialPage", model);
            }
            else
            {
                ViewBag.FileName = image.FileName;
                model.SocialImage = new byte[image.Length];
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }

                model.SocialImage = imageData;

                bool result = await _dataManager.PageEditor.ChangeSocial(model);

                if (result)
                {
                    return RedirectToAction("Contacts", "ManageContactsPage");
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("DeleteSocialById")]
        public async Task<IActionResult> DeleteSocialById(int id)
        {
            bool result = await _dataManager.PageEditor.DeleteProjectById(id);

            if (result)
            {
                return RedirectToAction("Contacts", "ManageContactsPage");
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
