using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Models.Administration;
using webviews.Repositories.Administration;
using System.Linq;
using static webviews.Enums;

namespace webviews.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHttpContextAccessor ContextAccessor;

        protected readonly UserModel UserLogin;

        protected readonly string ControlName;

        public BaseController(
            string controlName,
            IUserRepository UserRepository,
            IHttpContextAccessor ContextAccessor)
        {
            this.ControlName = controlName.Replace("Controller","").ToLower();
            this.ContextAccessor = ContextAccessor;
            
            if(ContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                UserLogin = UserRepository.Get(int.Parse(ContextAccessor.HttpContext.User.Identity.Name));
            }

        }

        protected void AddPermitionEdit(PermissionsControl permission)
        {
            if(permission == PermissionsControl.No)
                TempData["edit"] = "disabled";
            else
                TempData["edit"] = null;
        }

        protected void AddTempData(System.Exception ex)
        {
            try
            {
                TempData["Exception"] = ex.InnerException.Message;
            }
            catch
            {
                TempData["Exception"] = ex.Message;
            }
        }
        
        /// <summary>
        /// Permissão para visualização
        /// </summary>
        /// <param name="action"></param>
        /// <returns>1 - Sim, 2 - Todos os usuários</returns>
        protected PermissionsControl PermissionToView(string action)
        {
            if(UserLogin.Admin)
                return PermissionsControl.YesAll;

            var model = GetPerfil(action); 
            var foo = model.View ? 1 : 0;
            foo += model.AllUsers && foo > 0 ? 1 : 0;

            return (PermissionsControl)foo;
        }
        protected PermissionsControl PermissionToAdd(string action)
        {
            if(UserLogin.Admin)
                return PermissionsControl.YesAll;
                
            var model = GetPerfil(action); 
            var foo = model.Add ? 1 : 0;
            foo += model.AllUsers && foo > 0 ? 1 : 0;

            return (PermissionsControl)foo;
        }
        protected PermissionsControl PermissionToEdit(string action)
        {
            var model = GetPerfil(action); 
            var foo = model.Edit ? 1 : 0;
            foo += model.AllUsers && foo > 0 ? 1 : 0;

            return (PermissionsControl)foo;
        }
        private PerfilModel GetPerfil(string action)
        {
            action = action.ToLower();
            var foo = UserLogin.Perfil.Where(t => t.Module.Controller == ControlName && t.Module.Action == action).FirstOrDefault();
            if(foo != null)
                return foo;
            else
                return new PerfilModel();
        }
    }
}