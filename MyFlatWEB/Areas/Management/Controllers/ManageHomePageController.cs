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

        [Route("ChangeNameLinkTopMenu")]
        public IActionResult ChangeNameLinkTopMenu(int id, string linkName)
        {
            TopMenuLinkNameModel linkModel = new TopMenuLinkNameModel();
            linkModel.Id = id;
            linkModel.LinkName = linkName;

            bool change = _dataManager.PageEditor.ChangeNameLinkTopMenu(linkModel).GetAwaiter().GetResult();

            if (change)
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

        [Route("AddRandomPhrase")]
        public IActionResult AddRandomPhrase(string phrase)
        {
            RandomPhraseModel rpm = new RandomPhraseModel();
            rpm.Phrase = phrase;

            var result = _dataManager.PageEditor.AddRandomPhrase(rpm).GetAwaiter().GetResult();

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

        [Route("ChangeRandomPhrase")]
        public IActionResult ChangeRandomPhrase(int id, string changePhrase)
        {
            RandomPhraseModel rpm = new RandomPhraseModel { Id = id, Phrase = changePhrase};

            var result = _dataManager.PageEditor.ChangeRandomPhrase(rpm).GetAwaiter().GetResult();

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

        [Route("DeleteRandomPhrase")]
        public IActionResult DeleteRandomPhrase(int id)
        {
            var result = _dataManager.PageEditor.DeleteRandomPhrase(id).GetAwaiter().GetResult();

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

        
        [Route("ChangeLeftCentralAreaText")]
        public IActionResult ChangeLeftCentralAreaText(int id, string leftCentralAreaPhrase)
        {
            HomePagePlaceholderModel hphm = new HomePagePlaceholderModel { Id = id, 
                                                                            LeftCentralAreaText = leftCentralAreaPhrase };

            var result = _dataManager.PageEditor.ChangeLeftCentralAreaText(hphm).GetAwaiter().GetResult();

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

        [Route("ChangeMainImage")]
        public async Task<IActionResult> ChangeMainImage(List<IFormFile> image)
        {
            HomePagePlaceholderModel hphm = new HomePagePlaceholderModel();
            hphm = _dataManager.PageEditor.GetHomePagePlaceholder();

            foreach (var item in image)
            {
                if(item.Length > 0)
                {
                    using(var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        hphm.MainPicture = stream.ToArray();
                    }
                }
            }

            var result = _dataManager.PageEditor.ChangeMainImage(hphm).GetAwaiter().GetResult();

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
