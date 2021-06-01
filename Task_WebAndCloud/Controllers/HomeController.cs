using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Task_WebAndCloud.Data;
using Task_WebAndCloud.ViewModels;

namespace Task_WebAndCloud.Controllers
{
    public class HomeController : Controller
    {
        private IPostsRepository repository;
        private int PageSize = 2;

        public HomeController(IPostsRepository repo)
        {
            repository = repo;
        }

/*        public IActionResult Index()
        {
            return View();
        }*/

        public IActionResult Index(string Message)
        {
            ViewBag.Message = Message;
            return View();
        }
    }
}
