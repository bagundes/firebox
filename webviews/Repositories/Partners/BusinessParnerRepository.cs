using System;
using System.Linq;
using System.Collections.Generic;
using webviews.Models.Partners;
using webviews.Repositories.Invariable;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webviews.Repositories.Partners
{
    public interface IBusinessPartnerRepository : IBaseRepository<BusinessPartnerModel>
    {
        BusinessPartnerModel GetByInterCode(int id);
        BusinessPartnerModel GetByCardCode(string cardcode);
        IEnumerable<SelectListItem> GetSelectBySalesman(int saleman);
        IEnumerable<SelectListItem> GetSelect();

        List<BusinessPartnerModel> GetBySalesman(int saleman);
    }
    public class BusinessPartnerRepository : BaseRepository<BusinessPartnerModel>, IBusinessPartnerRepository
    {
        public BusinessPartnerRepository(AppContext context) : base(context)
        {
        }

        public override BusinessPartnerModel Add(BusinessPartnerModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var address = new AddressRepository(context);

                    if(model.AddressShipId == 0)
                        model.AddressShipId = address.Add(model.AddressShip).Id;
                    
                    if(model.AddressBillId == 0)
                        model.AddressBillId = address.Add(model.AddressBill).Id;

                    var bparter = base.Add(model);

                    transaction.Commit();

                    return bparter;

                }catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public BusinessPartnerModel GetByInterCode(int id)
        {
            var bparter = this.GetByCode(id);
            GetWithChildren(ref bparter);

            return bparter;
        }

        public BusinessPartnerModel GetByCardCode(string cardcode)
        {
            var bparter = this.GetByName(cardcode);
            GetWithChildren(ref bparter);

            return bparter;
        }

        public List<BusinessPartnerModel> GetBySalesman(int saleman)
        {
            var bpartners = dbSet.Where(t => t.Salesman == saleman).ToList();
            GetWithChildren(ref bpartners);

            return bpartners;
        }

        public IEnumerable<SelectListItem> GetSelectBySalesman(int saleman)
        {
            return (from t in dbSet
                    where t.Salesman == saleman
                    select new SelectListItem
                    {
                        Value = t.Code.ToString(),
                        Text = t.CompanyName
                    }).ToList();
        }

        public IEnumerable<SelectListItem> GetSelect()
        {
            return (from t in dbSet
                    select new SelectListItem
                    {
                        Value = t.Code.ToString(),
                        Text = t.CompanyName
                    }).Distinct().ToList();
        }

        private void GetWithChildren(ref BusinessPartnerModel model)
        {
            var address = new Repositories.Invariable.AddressRepository(context);

            model.AddressShip = address.Get(model.AddressShipId);
            model.AddressBill = address.Get(model.AddressBillId);
        }

        private void GetWithChildren(ref List<BusinessPartnerModel> model)
        {
            var address = new Repositories.Invariable.AddressRepository(context);
            for(int i = 0; i < model.Count; i++)
            {
                model[i].AddressBill = address.Get(model[i].AddressBillId);
                model[i].AddressShip = address.Get(model[i].AddressShipId);
            }
            
        }

        public void CreateDefault()
        {
            throw new System.NotImplementedException();
        }

    }
}
