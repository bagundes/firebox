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
    public interface IVendorRepository : IBaseRepository<VendorModel>
    {
        IEnumerable<SelectListItem> GetForSelect();
    }
    public class VendorRepository : BaseRepository<VendorModel>, IVendorRepository
    {
        public VendorRepository(AppContext context) : base(context)
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
    }
}