using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Models;
using webviews.Repositories.Administration;

namespace webviews.Controllers
{
    public class HomeController : BaseController
    {
        public IUserRepository UserRepository;
        public HomeController(
            IUserRepository userRepository,
            IHttpContextAccessor contextAccessor) : base("HomeController",userRepository, contextAccessor)
        {
            this.UserRepository = userRepository;
        }

        public IActionResult Index()
        {

            return RedirectToAction("Login","Access");
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
