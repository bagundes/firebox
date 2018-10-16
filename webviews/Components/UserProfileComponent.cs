using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Repositories.Administration;

namespace webviews.Components
{
    
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor ContextAccessor;
        private readonly IUserRepository UserRepository;
        private readonly ISessionRepository SessionRepository;

        public UserProfileViewComponent(
            IUserRepository UserRepository,
            ISessionRepository SessionRepository,
            IHttpContextAccessor ContextAccessor)
        {
            this.ContextAccessor = ContextAccessor;
            this.UserRepository = UserRepository;
            this.SessionRepository = SessionRepository;
        }

        public IViewComponentResult Invoke()    
        {
            var model = UserRepository.Get(SessionRepository.GetUserId());
            return View(model);
        }
    }
}