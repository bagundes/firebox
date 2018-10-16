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
using webviews.Models.ViewModels;

namespace webviews.Controllers
{
    public class PerfilController: BaseController
    {
        private readonly IUserRepository UserRepository;
        private readonly IPerfilRepository PerfilRepository;

        public PerfilController(
            IUserRepository UserRepository,
            IPerfilRepository PerfilRepository, 
            IHttpContextAccessor ContextAccessor) : base("PerfilController",UserRepository, ContextAccessor)
        {
            this.UserRepository = UserRepository;
            this.PerfilRepository = PerfilRepository;
        }

        [Route("/app/perfil/list")]
        public IActionResult List()
        {
            var modelList = new PerfilListViewModel(PerfilRepository);
            return View(modelList);
        }
    }
}