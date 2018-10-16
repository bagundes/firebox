using webviews.Models.Invariable;
using System;
using System.Linq;
using System.Collections.Generic;

namespace webviews.Repositories.Invariable
{
    public interface ICityRepository : IBaseRepository<CityModel>
    {
        List<string> getUFBrazil();
    }
    public class CityRepository : BaseRepository<CityModel>, ICityRepository
    {
        public CityRepository(AppContext context) : base(context)
        {
        }

        public List<string> getUFBrazil()
        {
            return dbSet.Select(t => t.StateShort).Distinct().ToList();
        }
        public void CreateDefault()
        {
            throw new System.NotImplementedException();
        }
    }
}