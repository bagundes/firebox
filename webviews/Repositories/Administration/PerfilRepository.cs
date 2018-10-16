using System.Collections.Generic;
using webviews.Models.Administration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webviews.Repositories.Administration
{

    public interface IPerfilRepository : IBaseRepository<PerfilModel>
    {
        List<PerfilModel> GetPerfilId(int perfilId);
        IEnumerable<SelectListItem> GetForSelect();
        
    }
    public class PerfilRepository : BaseRepository<PerfilModel>, IPerfilRepository
    {
        
        public PerfilRepository(AppContext context) : base(context)
        {

        }

        public List<PerfilModel> Get()
        {
            var models = dbSet.ToList();
            GetWithChildren(ref models);
            return models;
        }

        public void CreateDefault()
        {
            if(dbSet.Any())
                return;

            var modRep = new ModuleRepository(context);
            
            var modulos = modRep.Get();

            foreach (var modulo in modulos)
            {
                Add(new PerfilModel()
                {
                    PerfilId = 1,
                    Perfil = "Administração",
                    ModuleId = modulo.Id,
                    View = false,
                    Add = false,
                    Edit = false,
                    AllUsers = false,
                });

                Add(new PerfilModel()
                {
                    PerfilId = 2,
                    Perfil = "Vendedor",
                    ModuleId = modulo.Id,
                    View = false,
                    Add = false,
                    Edit = false,
                    AllUsers = false,
                });
            }
        }

        public override PerfilModel Add(PerfilModel model)
        {
            var db = dbSet.Where(t => t.Perfil == model.Perfil).OrderBy(t => t.Id).FirstOrDefault();
            
            if(db != null)
                model.Code = db.Id;
            else if(dbSet.Any())
                model.Code = dbSet.Max(t => t.Id) + 1;
            else
                model.Code = 1;

            dbSet.Add(model);
            context.SaveChanges();

            return Get(model.Unique);
        }

        public override List<PerfilModel> GetListByCode(int? code)
        {
            return dbSet.Where(t => t.Code == code).OrderBy(t => t.VisOrder).ToList();
        }

        public override List<PerfilModel> GetListByUser(int userId)
        {
            var models = base.GetListByUser(userId);
            GetWithChildren(ref models);
            
            return models;
        }


 
        public override void SecurityRulles(ref PerfilModel model, Enums.ActionRepository action)
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
                case Enums.ActionRepository.Add: break;
                case Enums.ActionRepository.Update: break;
                case Enums.ActionRepository.Delete: break;
                case Enums.ActionRepository.None: break;

            }

            base.SecurityRulles(ref model, action); 

            #region Required
            #endregion
        }

        public List<PerfilModel> GetPerfilId(int perfilId)
        {
            var perfils = GetListByCode(perfilId);
            GetWithChildren(ref perfils);

            return perfils;
        }

        private void GetWithChildren(ref PerfilModel model)
        {
            var module = new Repositories.Administration.ModuleRepository(context);
            model.Module = module.Get(model.ModuleId);
        }

        private void GetWithChildren(ref List<PerfilModel> model)
        {
            var module = new Repositories.Administration.ModuleRepository(context);
            for(int i = 0; i < model.Count; i++)
            {
                model[i].Module = module.Get(model[i].ModuleId);
            }
        }

        public IEnumerable<SelectListItem> GetForSelect()
        {
            return (from t in dbSet
                      select new SelectListItem 
                      { 
                        Value = t.Code.ToString(), 
                        Text = t.Name }).Distinct().ToList();
        }
    }
}