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
    [Authorize]
    public class MainController : BaseController
    {
        public IUserRepository UserRepository;
        public MainController(
            IUserRepository userRepository,
            IHttpContextAccessor contextAccessor) : base("MainController", userRepository, contextAccessor)
        {
            this.UserRepository = userRepository;
        }

        [Route("/app/index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/app/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }

    
}
