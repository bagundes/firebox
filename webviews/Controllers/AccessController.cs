using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Models;
using webviews.Models.Administration;
using webviews.Repositories.Administration;

namespace webviews.Controllers
{
    [AllowAnonymous]
    public class AccessController : BaseController
    {
        public IUserRepository UserRepository;
        public AccessController(
            IUserRepository userRepository,
            IHttpContextAccessor contextAccessor) : base("AccessController", userRepository, contextAccessor)
        {
            this.UserRepository = userRepository;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return RedirectToAction("Login", "Login");
        }

        [Route("/login")]
        public IActionResult Login()
        {
            if(UserLogin != null)
                return RedirectToAction("Index", "Main");
            else
                return View();
        }

        [Route("/login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel model)
        {
            try
            {
                UserRepository.Login(model.User, model.Passwd, ContextAccessor, model.Remember);
                return RedirectToAction("Index", "Main");
            }
            catch(Exception ex)
            {
                AddTempData(ex);
                model.Passwd = null;
                return View(model);
            }
        }

        [Route("/logout")]
        public IActionResult Logout()
        {
            UserRepository.Logout(ContextAccessor);
            return View();
        }

        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }


        [Route("/register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel model)
        {
            try
            {
                model.UserIdProper = -1;
                model.UserIdUpdate = -1;
                UserRepository.Add(model);
                return RedirectToAction("Registred");
            }
            catch(Exception ex)
            {
                AddTempData(ex);
                
                model.Passwd = null;
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("/registred")]
        public IActionResult Registred()
        {
            return View();
        }
    }
}
