using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Models.Administration;
using webviews.Models.ViewModels;
using webviews.Repositories.Administration;

namespace webviews.Components
{
    public class MenuNavegationViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor ContextAccessor;
        private readonly IPerfilRepository PerfilRepository;
        private readonly IUserRepository UserRepository;
        private readonly IModuleRepository ModuleRepository;
        public MenuNavegationViewComponent(
            IUserRepository UserRepository,
            IPerfilRepository PerfilRepository,
            IHttpContextAccessor ContextAccessor,
            IModuleRepository ModuleRepository)
        {
            this.UserRepository = UserRepository;
            this.ContextAccessor = ContextAccessor;
            this.PerfilRepository = PerfilRepository;
            this.ModuleRepository = ModuleRepository;
        }

        public IViewComponentResult Invoke()    
        {
            var userModel = UserRepository.Logged(ContextAccessor);
            var listMenuModule = new MenuNavegationViewModel(userModel, PerfilRepository, ModuleRepository);

            return View(listMenuModule);
        }
        
    }
}