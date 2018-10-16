using System.Collections.Generic;
using webviews.Models.Administration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using webviews.Models.Invariable;

namespace webviews.Repositories.Invariable
{
    public interface IUfToPriceListRepository : IBaseRepository<UfToPriceListModel>
    {
        IEnumerable<SelectListItem> GetForSelect();
    }
    public class UfToPriceListRepository : BaseRepository<UfToPriceListModel>, IUfToPriceListRepository
    {
        public UfToPriceListRepository(AppContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetForSelect()
        {
            return (from t in dbSet
                      select new SelectListItem 
                      { 
                        Value = t.Code.ToString(), 
                        Text = t.Name }).Distinct().ToList();
        }

        public void CreateDefault()
        {
            throw new System.NotImplementedException();
        }

        private void GetWithChildren(ref UfToPriceListModel model)
        {
            var module = new Repositories.Invariable.PriceListRepository(context);
            model.PriceList = module.Get(model.PriceListCode);
        }

        private void GetWithChildren(ref List<UfToPriceListModel> model)
        {
            var module = new Repositories.Invariable.PriceListRepository(context);
            for(int i = 0; i < model.Count; i++)
            {
                model[i].PriceList = module.Get(model[i].PriceListCode);
            }
        }

    }
}