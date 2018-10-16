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
using webviews.Repositories.Invariable;
using webviews.Models.ViewModels;

namespace webviews.Controllers
{
    public class ListPriceController: BaseController
    {
        private readonly IUserRepository UserRepository;
        private readonly IPriceListRepository PriceListRepository;
        private readonly IUfToPriceListRepository UfToPriceListRepository;
        private readonly IPerfilRepository PerfilRepository;

        public ListPriceController(
            IUserRepository UserRepository,
            IPriceListRepository PriceListRepository,
            IUfToPriceListRepository UfToPriceListRepository,
            IPerfilRepository perfilRepository,
            IHttpContextAccessor ContextAccessor) : base("PerfilController",UserRepository, ContextAccessor)
        {
            this.UserRepository = UserRepository;
            this.PriceListRepository = PriceListRepository;
            this.PerfilRepository = perfilRepository;
            this.UfToPriceListRepository = UfToPriceListRepository;
        }

        [Route("/app/list/uf")]
        public IActionResult Client()
        {
            var modelList = new PerfilListViewModel(PerfilRepository);
            return View(modelList);
        }
    }
}