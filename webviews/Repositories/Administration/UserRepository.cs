using System.Collections.Generic;
using webviews.Models.Administration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System;

namespace webviews.Repositories.Administration
{

    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel Login(string email, string passwd, IHttpContextAccessor contextAccessor, bool remember = false);
        void Logout( IHttpContextAccessor contextAccessor);
        UserModel Logged(IHttpContextAccessor contextAccessor);
    }
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        

        public UserRepository(AppContext context) : base(context)
        {
        }
        
        #region IBaseRepository
        public override UserModel Add(UserModel model)
        {
            if(dbSet.Where(t => t.User == model.User || t.Email == model.Email).Any())
                throw new Exception("Usuário ou e-mail já cadastrado na plataforma.");

            model.Blocked = true;
            model.AddHashPasswd();
            SecurityRulles(ref model, Enums.ActionRepository.Add);
   
            return base.Add(model);
        }

        public override UserModel Update(UserModel model)
        {
            SecurityRulles(ref model, Enums.ActionRepository.Update);
            
             var foo = dbSet.Where(t => t.Id == model.Indentify && model.Unique == model.Unique).FirstOrDefault();

            if(foo != null)
            {
                foo.Update(model);
                return base.Update(foo.Id, foo);
            } 
            else 
                throw new System.Exception($"Modelo não existe ou bloqueado. ID:{model.Id}");

            return base.Update(model);
        }

        public override UserModel Get(int id)
        {
            var model = base.Get(id);
            GetWithChildren(ref model);

            return model;
        }
        public override List<UserModel> Get()
        {
            var models = base.Get();
            GetWithChildren(ref models);
            return models;
        }
        
        #endregion
        

        public void Logout( IHttpContextAccessor contextAccessor)
        {
            contextAccessor.HttpContext.SignOutAsync();
        }

        public UserModel Logged(IHttpContextAccessor contextAccessor)
        {
            
            try
            {
                var session = new SessionRepository(contextAccessor);
                var id = session.GetUserId();

                return Get(id);
            } 
            catch
            {
                contextAccessor.HttpContext.SignOutAsync();
                throw new Exception("Usuário não logado");
            }            
        }
        public UserModel Login(string user, string passwd, IHttpContextAccessor contextAccessor, bool remember = false)
        {
            var expired = true ? 10080 : 10; //min

            var model = dbSet.Where(t => t.User == user).FirstOrDefault();
            if(model != null)
            {
                if(!model.IsValidPasswd(passwd))
                    throw new System.Exception("Usuário ou senha inválida."); 
                
                if(model.Blocked)
                    throw new System.Exception("Usuário bloqueado, por favor contate o suporte."); 

            }
            else
            {
                throw new System.Exception("Usuário ou senha inválida"); 
            }        
            
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{model.Id}")
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(userIdentity);

            contextAccessor.HttpContext.SignInAsync(principal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(expired)
            });

            var session = new SessionRepository(contextAccessor);
            
            session.AddUser(model);

            return model;
        }

        public override void SecurityRulles(ref UserModel model, Enums.ActionRepository action)
        {
            switch (action)
            {
                case Enums.ActionRepository.All:
                    this.SecurityRulles(ref model, action);
                    SecurityRulles(ref model, Enums.ActionRepository.Add);
                    SecurityRulles(ref model, Enums.ActionRepository.Update);
                    SecurityRulles(ref model, Enums.ActionRepository.Delete);
                    SecurityRulles(ref model, Enums.ActionRepository.None); 
                    break;
                case Enums.ActionRepository.Add: 
                    model.UserIdProper = -1;
                break;
                case Enums.ActionRepository.Update: 
                    model.UserIdProper = -1;
                break;
                case Enums.ActionRepository.Delete: break;
                case Enums.ActionRepository.None: break;

            }
            
            #region Required

            if(!dbSet.Any() || model.Admin == true)
            {
                model.Admin = true;
                model.Blocked = false;
                model.ValidUntil = DateTime.Now.AddYears(5);
                model.UserIdProper = 1;
                model.UserIdUpdate = 1;
                model.Terms = true;
            }

            if(!model.Terms)
                throw new Exception("Obrigatório aceitar os termos de uso");

            base.SecurityRulles(ref model, action); 
            #endregion
        }
        public void CreateDefault()
        {
            if(dbSet.Any())
                return;
                
            var user = new UserModel()
            {
                Name = "Administrador",
                FullName = "Adm System",
                Email = "admin@mail.com",
                Passwd = "Qwerty123@",
                Admin = true,
                UserIdProper = -1, 
                UserIdUpdate = -1,
            };

            Add(user);
        }
        private void GetWithChildren(ref UserModel model)
        {
            var module = new Repositories.Administration.PerfilRepository(context);
            model.Perfil = module.GetPerfilId(model.PerfilId);
        }

        /// <summary>
        /// Carrega os objetos filho.
        /// </summary>
        /// <param name="model"></param>
        private void GetWithChildren(ref List<UserModel> model)
        {
            var module = new Repositories.Administration.PerfilRepository(context);
            for(int i = 0; i < model.Count; i++)
            {
                model[i].Perfil = module.GetPerfilId(model[i].PerfilId);
            }
            
        }
    }
}