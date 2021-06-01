using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Task_WebAndCloud.Data;
using Task_WebAndCloud.Models;

namespace Task_WebAndCloud.Controllers
{
   [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IPostsRepository postsRepository;
        private readonly UserManager<User> _userManager;
        private string  currentUserID;

        public AdminController (IPostsRepository repository, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            postsRepository = repository;
            _userManager = userManager;
            currentUserID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<IActionResult> Index()
        {
            // get user who posted 
            return View(postsRepository.Posts);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int postId)
        {
            var user = await _userManager.FindByIdAsync(currentUserID);
            var post = postsRepository.Posts.Where(p => p.PostId == postId).FirstOrDefault();
            ViewBag.CurrentUserEmail = user.Email;

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(currentUserID);
                ViewBag.CurrentUserEmail = user.Email;
                await postsRepository.SavePostAsync(post);
                TempData["message"] = $"Post with title {post.Title} has been saved";
                return RedirectToAction(nameof(AdminController.Index), post);  // or hardcode it
            }
            else
            { 
                return View(post);
            }
        }

        public async Task<IActionResult> Create()
        {
            DateTime timeNow = DateTime.Now;
            Post post = new Post();
            post.PostingDate = timeNow;

            var user = await _userManager.FindByIdAsync(currentUserID);
            ViewBag.CurrentUserEmail = user.Email;

            return View("Edit", post);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int postId)
        {
            Post postForDelete = await postsRepository.DeleteProductAsync(postId);
            if (postForDelete != null)
            {
                TempData["message"] = $"{postForDelete.Title} was deleted";
            } 

            return RedirectToAction("Index");
        }

        public IActionResult SeeUsers()
        {
            return View("SeeUsers", postsRepository.Posts);
        }
    }
}
