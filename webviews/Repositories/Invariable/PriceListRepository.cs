
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
    public interface IPriceListRepository : IBaseRepository<PriceListModel>
    {

    }
    public class PriceListRepository : BaseRepository<PriceListModel>, IPriceListRepository
    {
        public PriceListRepository(AppContext context) : base(context)
        {
        }


        public void CreateDefault()
        {
            throw new System.NotImplementedException();
        }
    }
}