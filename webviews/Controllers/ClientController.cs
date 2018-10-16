using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Repositories.Administration;

namespace webviews.Controllers
{
    public class ClientController : BaseController
    {
        public IUserRepository UserRepository;
        public ClientController(
            IUserRepository UserRepository,
            IHttpContextAccessor ContextAccessor) : base("HomeController",UserRepository, ContextAccessor)
        {
            this.UserRepository = UserRepository;
        }

        [Route("/app/user/clients")]
        public IActionResult ListUser()
        {
            return View();
        }
    }
}