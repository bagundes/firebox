using Microsoft.AspNetCore.Http;
using webviews.Models.Administration;
using System;

namespace webviews.Repositories.Administration
{
    public interface ISessionRepository
    {
        void DelUser(UserModel model);
        void AddUser(UserModel model);
        int GetUserId();
        int GetPerfilId();
        void AddValue(string key, string value);
        string GetValue(string key);

    }
    public class SessionRepository : ISessionRepository
    {
        private readonly IHttpContextAccessor ContextAccessor;
        private int Time {get;} = 60;

        public SessionRepository(IHttpContextAccessor ContextAccessor)
        {
            this.ContextAccessor = ContextAccessor;
        }

        public void DelUser(UserModel model)
        {
            ContextAccessor.HttpContext.Session.SetInt32(Enums.USERID,0);
            ContextAccessor.HttpContext.Session.SetInt32(Enums.PERFILID,0);
        }
        public void AddUser(UserModel model)
        {
            
            // Session
            ContextAccessor.HttpContext.Session.SetInt32(Enums.USERID, model.Id);
            ContextAccessor.HttpContext.Session.SetInt32(Enums.PERFILID, model.PerfilId);
            // Cookie
            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(Time);
            ContextAccessor.HttpContext.Response.Cookies.Append(Enums.USERID, model.Id.ToString(), option);
            ContextAccessor.HttpContext.Response.Cookies.Append(Enums.PERFILID, model.PerfilId.ToString(), option);
        }
        public int GetUserId()
        {
            var id = ContextAccessor.HttpContext.User.Identity.Name;
            
            if(string.IsNullOrEmpty(id))
                id = GetValue(Enums.USERID);

            if(string.IsNullOrEmpty(id))
                throw new Exception("Usuário não logado");
            else
                return int.Parse(id);
        }
        public int GetPerfilId()
        {
            var id = GetValue(Enums.PERFILID);

            if(string.IsNullOrEmpty(id))
                return -1;
            else
                return int.Parse(id);
        }
        public void AddValue(string key, string value)
        {
            // Session
            ContextAccessor.HttpContext.Session.SetString(key, value);
            // Cookie
            ContextAccessor.HttpContext.Response.Cookies.Append(key, value);
        }
        public string GetValue(string key)
        {
            var value = ContextAccessor.HttpContext.Session.GetString(key);
            if(String.IsNullOrEmpty(value))
                value = ContextAccessor.HttpContext.Request.Cookies[key];

            return value;
        }
    }
}