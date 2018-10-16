using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Repositories.Administration;

namespace webviews.Components
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly IHttpContextAccessor ContextAccessor;
        private readonly IUserRepository UserRepository;
        private readonly ISessionRepository SessionRepository;
        public HeaderViewComponent(
            ISessionRepository SessionRepository,
            IUserRepository UserRepository,
            IHttpContextAccessor ContextAccessor)
        {
            this.SessionRepository = SessionRepository;
            this.ContextAccessor = ContextAccessor;
            this.UserRepository = UserRepository;
        }

        public IViewComponentResult Invoke()    
        {
            var model = UserRepository.Logged(ContextAccessor);

            return View(model);
        }
    }
}