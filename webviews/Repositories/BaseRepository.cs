using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webviews.Models;
using System.Linq;
using System;

namespace webviews.Repositories
{

    public interface IBaseRepository<T> where T : BaseModel
    {
        
        T Add(T model);
        T Update(T model);
        T Update(int id, T model);
        void Delete(int id);
        void Delete(T model);
        List<T> Get();
        T Get(int id);
        T Get(string unique);
        T GetByCode(int code);
        T GetByName(string name);
        List<T> GetListByFather(int fatherId);
        List<T> GetListByUser(int userId);
        List<T> GetListByCode(int? code);
        List<T> GetListByName(string name);
        void CreateDefault();
        void SecurityRulles(ref T model, Enums.ActionRepository action);

         
    }

    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly AppContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(AppContext context)
        {
            dbSet = context.Set<T>();
            this.context = context;
        }

        public virtual T Add(T model)
        {
            SecurityRulles(ref model, Enums.ActionRepository.Add);

            dbSet.Add(model);
            context.SaveChanges();

            return Get(model.Unique);
        }
        /// <summary>
        /// Atualiza model com regras de bloqueio
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual T Update(T model)
        {
            SecurityRulles(ref model, Enums.ActionRepository.Update);

            var foo = dbSet.Where(t => t.Id == model.Indentify && model.Unique == model.Unique).FirstOrDefault();

            if(foo != null && !foo.Blocked)
            {
                return Update(foo.Id, model);
            } 
            else 
                throw new System.Exception($"Modelo não existe ou bloqueado. ID:{model.Id}");
        }
        /// <summary>
        /// Atualiza o model sem a regras de bloqueio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual T Update(int id, T model)
         {
             SecurityRulles(ref model, Enums.ActionRepository.Update);

             var foo = dbSet.Where(t => t.Id == id).FirstOrDefault();
             if(foo != null)
            {
                foo.Update(model);
                context.SaveChanges();   

                return foo;
            } 
            else 
                throw new System.Exception($"Modelo não existe. ID:{model.Id}");

         }
        public virtual void Delete(int id)
        {
            var model = dbSet.Where(t => t.Id == id).FirstOrDefault();
            if (model != null && !model.Blocked)
                Delete(model);
            else
                throw new System.Exception($"Modelo não existe ou bloqueado. ID:{model.Id}");
        }
        public virtual void Delete(T model)
        {
            SecurityRulles(ref model, Enums.ActionRepository.Delete);

            var foo = dbSet.Where(t => t.Id == model.Id && t.Unique == model.Unique).FirstOrDefault();
            if (foo != null && !foo.Blocked)
                Delete(foo);
            else
                throw new System.Exception($"Modelo não existe ou bloqueado. ID:{model.Id}");
        }
        public virtual T Get(int id)
        {
            return dbSet.Where(t => t.Id == id).FirstOrDefault();
        }
        public virtual T Get(string unique)
        {
            return dbSet.Where(t => t.Unique == unique).FirstOrDefault();
        }
        public virtual T GetByCode(int code)
        {
            return dbSet.Where(t => t.Code == code).FirstOrDefault();
        }
        public virtual T GetByName(string name)
        {
            return dbSet.Where(t => t.Name == name).FirstOrDefault();
        }
        public virtual List<T> GetListByFather(int fatherId)
        {
            return dbSet.Where(t => t.FatherId == fatherId).ToList();
        }
        public virtual List<T> GetListByName(string name)
        {
            return dbSet.Where(t => t.Name == name.Trim()).ToList();
        }
        public virtual List<T> GetListByUser(int userId)
        {
            return dbSet.Where(t => t.UserIdProper == userId).ToList();
        }
        public virtual List<T> GetListByCode(int? code)
        {
            return dbSet.Where(t => t.Code == code) .ToList();
        }
        public virtual List<T> Get()
        {
            return dbSet.ToList();
        }
        public virtual void SecurityRulles(ref T model,Enums.ActionRepository action)
        {
            switch (action)
            {
                case Enums.ActionRepository.All:
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
            
            #region Required
            if(model.ValidUntil != null && model.ValidUntil < DateTime.Now)
                model.Blocked = true;
            
            if(model.UserIdProper == 0 || model.UserIdUpdate == 0)
                throw new Exception("Modelo tem usuário proprietário");
            #endregion
        }
    }
}