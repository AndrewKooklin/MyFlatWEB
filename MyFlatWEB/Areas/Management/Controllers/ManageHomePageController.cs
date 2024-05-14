﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ManageHomePageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("HomePage")]
        public IActionResult HomePage()
        {
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
    }
}
