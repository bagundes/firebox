using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Models.Administration;
using webviews.Models.ViewModels;
using webviews.Repositories.Administration;
using webviews.Repositories.Invariable;

using static webviews.Enums;

namespace webviews.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository UserRepository;
        private readonly IPerfilRepository PerfilRepository;
        private readonly IVendorRepository VendorRepository;

        public UserController(
            IUserRepository UserRepository,
            IPerfilRepository PerfilRepository,
            IVendorRepository VendorRepository,
            IHttpContextAccessor ContextAccessor) : base("UserController", UserRepository, ContextAccessor)
        {
            this.UserRepository = UserRepository;
            this.PerfilRepository = PerfilRepository;
            this.VendorRepository = VendorRepository;
        }

        [Route("/app/users/index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/app/users/list")]
        public IActionResult List()
        {
            try
            {
            var action = "List";
            if(base.PermissionToView(action) == PermissionsControl.No)
                throw new System.Exception("Usuário sem permissão de acesso");

            var model = new UsersViewModel(UserLogin.Id, UserRepository, PermissionToView(action));

            return View(model);

            }catch(Exception ex)
            {
                //AddTempData(ex);
                TempData["Exception"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [Route("/app/user/{unique}")]
        public IActionResult Edit(string unique)
        {
            var action = "List";
            if(base.PermissionToView(action) == PermissionsControl.No)
                throw new System.Exception("Usuário sem permissão de acesso");

            var user = new UsersViewModel(unique, UserRepository, PerfilRepository, VendorRepository);

            return View(user);
        }

        [Route("/app/user/{unique}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UsersViewModel model)
        {
            model.UserModel.UserIdUpdate = UserLogin.Id;
            UserRepository.Update(model.UserModel);
            var user = new UsersViewModel(model.UserModel.Unique, UserRepository, PerfilRepository, VendorRepository);

            return View(user);
        }
        [HttpGet]
        public IActionResult EditBlock(string unique)
        {
            var model = UserRepository.Get(unique);
            model.Blocked = !model.Blocked;
            UserRepository.Update(model.Id, model);

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult EditEnable(string unique)
        {
            var model = UserRepository.Get(unique);
            model.Actived = !model.Actived;
            UserRepository.Update(model.Id, model);

            return RedirectToAction("List");
        }
    }
}