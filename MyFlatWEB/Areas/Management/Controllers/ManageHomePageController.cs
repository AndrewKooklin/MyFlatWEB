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

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageHomePage/")]
    public class ManageHomePageController : Controller
    {
        private DataManager _dataManager;
        private static readonly Encoding encoding = Encoding.UTF8;

        public ManageHomePageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        
        [Route("HomePage")]
        public IActionResult HomePage()
        {
            //byte[] photo = System.IO.File.ReadAllBytes(@"C:\repos\MyFlatWEB\MyFlatWEB\wwwroot\Images\hand-draft.webp");

            //string photoStr = Convert.ToBase64String(photo);

            //string m = "";

            var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();

            return View(placeHolder);
        }


        [HttpPost]
        [Route("ChangeNameLinkTopMenu")]
        public IActionResult ChangeNameLinkTopMenu(int id, string linkName)
        {
            if (String.IsNullOrEmpty(linkName))
            {
                var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                var topMenuLinks = placeHolder.LinkNames.ToList();
                foreach (var item in topMenuLinks)
                {
                    if (item.Id == id)
                    {
                        item.InputLinkNameError = "Fill field";
                    }
                    else
                    {
                        item.InputLinkNameError = "";
                    }
                }

                return View("HomePage", placeHolder);
            }
            else
            {
                TopMenuLinkNameModel linkModel = new TopMenuLinkNameModel();
                linkModel.Id = id;
                linkModel.LinkName = linkName;

                bool change = _dataManager.PageEditor.ChangeNameLinkTopMenu(linkModel).GetAwaiter().GetResult();

                if (change)
                {
                    var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                    return View("HomePage", placeHolder);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [HttpPost]
        [Route("AddRandomPhrase")]
        public IActionResult AddRandomPhrase(string phrase)
        {
            if (String.IsNullOrEmpty(phrase))
            {
                HomePagePlaceholderModel placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                placeHolder.InputAddPhraseError = "Fill field";

                return View("HomePage", placeHolder);
            }
            else
            {
                RandomPhraseModel rpm = new RandomPhraseModel();
                rpm.Phrase = phrase;

                var result = _dataManager.PageEditor.AddRandomPhrase(rpm).GetAwaiter().GetResult();

                if (result)
                {
                    HomePagePlaceholderModel placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                    placeHolder.InputAddPhraseError = "";
                    return View("HomePage", placeHolder);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [HttpPost]
        [Route("ChangeRandomPhrase")]
        public IActionResult ChangeRandomPhrase(int id, string changePhrase)
        {
            if (String.IsNullOrEmpty(changePhrase))
            {
                var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                var randomPhrases = placeHolder.RandomPhrases.ToList();
                
                foreach (var item in randomPhrases)
                {
                    if (item.Id == id)
                    {
                        item.InputChangePhraseError = "Fill field";
                    }
                    else
                    {
                        item.InputChangePhraseError = "";
                    }
                }

                return View("HomePage", placeHolder);
            }
            else
            {
                RandomPhraseModel rpm = new RandomPhraseModel { Id = id, Phrase = changePhrase };

                var result = _dataManager.PageEditor.ChangeRandomPhrase(rpm).GetAwaiter().GetResult();

                if (result)
                {
                    HomePagePlaceholderModel placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                    return View("HomePage", placeHolder);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("DeleteRandomPhrase")]
        public IActionResult DeleteRandomPhrase(int id)
        {
            var result = _dataManager.PageEditor.DeleteRandomPhrase(id).GetAwaiter().GetResult();

            if (result)
            {
                HomePagePlaceholderModel placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                return View("HomePage", placeHolder);
            }
            else
            {
                ErrorModel error = new ErrorModel();
                error.Message = "Server error";
                return View("ErrorView", error);
            }
        }

        
        [Route("ChangeLeftCentralAreaText")]
        public IActionResult ChangeLeftCentralAreaText(int id, string leftCentralAreaText)
        {
            if (String.IsNullOrEmpty(leftCentralAreaText))
            {
                var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                ViewBag.InputLeftCentralAreaPhrase = "Fill field";

                return View("HomePage", placeHolder);
            }
            else if (leftCentralAreaText.Length < 3)
            {
                var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                ViewBag.InputLeftCentralAreaPhrase = "At least 3 characters";

                return View("HomePage", placeHolder);
            }
            else
            {
                HomePagePlaceholderModel hphm = new HomePagePlaceholderModel
                {
                    Id = id,
                    LeftCentralAreaText = leftCentralAreaText
                };

                var result = _dataManager.PageEditor.ChangeLeftCentralAreaText(hphm).GetAwaiter().GetResult();

                if (result)
                {
                    var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                    ViewBag.InputLeftCentralAreaPhrase = "";
                    return View("HomePage", placeHolder);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("ChangeMainImage")]
        public async Task<IActionResult> ChangeMainImage(IFormFile image)
        {
            var placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();

            if (image == null)
            {
                return View("HomePage", placeHolder);
            }
            else
            {
                placeHolder.MainPicture = new byte[image.Length];
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }
                
                placeHolder.MainPicture = imageData;

                var result = await _dataManager.PageEditor.ChangeMainImage(placeHolder);

                if (result)
                {
                    placeHolder = _dataManager.PageEditor.GetHomePagePlaceholder();
                    return View("HomePage", placeHolder);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }

        }

        [Route("ChangeBottomAreaHeader")]
        public IActionResult ChangeBottomAreaHeader(string bottomHeader)
        {
            HomePagePlaceholderModel hphm = new HomePagePlaceholderModel();
            hphm = _dataManager.PageEditor.GetHomePagePlaceholder();
            hphm.BottomAreaHeader = bottomHeader;

            var result = _dataManager.PageEditor.ChangeBottomAreaHeader(hphm).GetAwaiter().GetResult();

            if (result)
            {
                return View("HomePage");
            }
            else
            {
                ErrorModel error = new ErrorModel();
                error.Message = "Server error";
                return View("ErrorView", error);
            }
        }

        [Route("ChangeBottomAreaContent")]
        public IActionResult ChangeBottomAreaContent(string bottomContent)
        {
            HomePagePlaceholderModel hphm = new HomePagePlaceholderModel();
            hphm = _dataManager.PageEditor.GetHomePagePlaceholder();
            hphm.BottomAreaHeader = bottomContent;

            var result = _dataManager.PageEditor.ChangeBottomAreaContent(hphm).GetAwaiter().GetResult();

            if (result)
            {
                return View("HomePage");
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
