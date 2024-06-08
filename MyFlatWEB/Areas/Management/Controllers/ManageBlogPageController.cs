using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFlatWEB.Areas.Management.Models;
using MyFlatWEB.Data;
using MyFlatWEB.Models.Rendering;

namespace MyFlatWEB.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/ManageBlogPage/")]
    public class ManageBlogPageController : Controller
    {
        private DataManager _dataManager;
        private static readonly Encoding encoding = Encoding.UTF8;

        public ManageBlogPageController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("Posts")]
        public IActionResult Posts()
        {
            var posts = _dataManager.PageEditor.GetPostsFromDB();
            return View("PostsPage", posts);
        }

        [Route("AddPost")]
        public IActionResult AddPost()
        {
            return View("AddPostPage");
        }

        [Route("AddPostToDB")]
        public async Task<IActionResult> AddPostToDB(PostModel model, IFormFile image)
        {
            if (String.IsNullOrEmpty(model.PostHeader) ||
                String.IsNullOrEmpty(model.PostDescription) ||
                image == null)
            {
                return View("AddPostPage");
            }
            else
            {
                model.PostImage = new byte[image.Length];
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }

                model.PostImage = imageData;

                bool result = await _dataManager.PageEditor.AddPostToDB(model);

                if (result)
                {
                    var posts = _dataManager.PageEditor.GetPostsFromDB();
                    return View("PostsPage", posts);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("ChangePostPage")]
        public IActionResult ChangePostPage(int id)
        {
            var post = _dataManager.PageEditor.GetPostById(id);
            ViewBag.FileName = "Choose image";
            return View("ChangePostPage", post);
        }

        [Route("ChangePost")]
        public async Task<IActionResult> ChangePost(PostModel model, IFormFile image)
        {
            if (String.IsNullOrEmpty(model.PostHeader) ||
                String.IsNullOrEmpty(model.PostDescription) ||
                image == null)
            {
                ViewBag.FileName = "Choose image";
                return View("ChangePostPage", model);
            }
            else
            {
                ViewBag.FileName = image.FileName;
                model.PostImage = new byte[image.Length];
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)image.Length);
                }

                model.PostImage = imageData;

                bool result = await _dataManager.PageEditor.ChangePost(model);

                if (result)
                {
                    var posts = _dataManager.PageEditor.GetPostsFromDB();
                    return View("PostsPage", posts);
                }
                else
                {
                    ErrorModel error = new ErrorModel();
                    error.Message = "Server error";
                    return View("ErrorView", error);
                }
            }
        }

        [Route("DeletePostById")]
        public async Task<IActionResult> DeletePostById(int id)
        {
            bool result = await _dataManager.PageEditor.DeletePostById(id);

            if (result)
            {
                return RedirectToAction("Posts", "ManageBlogPage");
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
