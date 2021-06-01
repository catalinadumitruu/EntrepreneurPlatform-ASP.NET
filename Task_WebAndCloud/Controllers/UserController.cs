using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Task_WebAndCloud.Data;
using Task_WebAndCloud.Models;
using Task_WebAndCloud.ViewModels;

namespace Task_WebAndCloud.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private IPostsRepository postsRepository;
        private readonly UserManager<User> _userManager;
        private string currentUserID;
        private int PageSize = 5;

        public UserController(IPostsRepository repo, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            postsRepository = repo;
            _userManager = userManager;
            currentUserID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index(int postPage = 1)
        {
            var viewModel = new PostsListViewModel
            {
                Posts = postsRepository.Posts
                .OrderBy(post => post.PostId)
                .Skip((postPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = postPage,
                    ItemsPerPage = PageSize,
                    TotalItems = postsRepository.Posts.Count()
                }
            };

            return View(viewModel);
        }

        public async Task<IActionResult> MyPosts(int postPage = 1)
        {
            var user = await _userManager.FindByIdAsync(currentUserID);
            
            var viewModel = new PostsListViewModel
            {
                Posts = postsRepository.Posts
                  .OrderBy(post => post.PostId)
                  .Skip((postPage - 1) * PageSize)
                  .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = postPage,
                    ItemsPerPage = PageSize,
                    TotalItems = postsRepository.Posts.Count()
                }
            };

            Console.WriteLine("Total no of posts " + postsRepository.Posts.Count());
            Console.WriteLine("Total no of posts of " + user.Email + " user " + postsRepository.Posts.Where(p => p.UserEmail == user.Email).Count());

            ViewBag.CurrentUserEmail = user.Email;

            return View("MyPosts", postsRepository.Posts);
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


                return RedirectToAction("MyPosts");  // or hardcode it
            }
            else
            {
                var user = await _userManager.FindByIdAsync(currentUserID);
                ViewBag.CurrentUserEmail = user.Email;
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
    }
}
