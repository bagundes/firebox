using System.Collections.Generic;
using webviews.Models.Administration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System;
using webviews.Models.Documents;

namespace webviews.Repositories.Documents
{

    public interface ISalesOrder_ItemRepository : IBaseRepository<SalesOrder_ItemModel>
    {
        double GetComission(int salesOrder, Enums.BaseStatus status);
        double GetComission(List<SalesOrderModel> salesOrder, Enums.BaseStatus status);

        double GetComission(DateTime ini, DateTime end,Enums.BaseStatus status);
    }
    public class SalesOrder_ItemRepository : BaseRepository<SalesOrder_ItemModel>, ISalesOrder_ItemRepository
    {
        public SalesOrder_ItemRepository(AppContext context) : base(context)
        {
        }

        public void CreateDefault()
        {
            throw new NotImplementedException();
        }

        #region IBaseRepository

        #endregion

        /// <summary>
        /// Return value total comissions
        /// </summary>
        /// <param name="salesOrder">List of sales order</param>
        /// <param name="status">Document status</param>
        /// <returns>Value total</returns>
        public double GetComission(int salesOrder, Enums.BaseStatus status)
        {
            
            return dbSet.Where(t => t.FatherId == salesOrder && t.Status == status).AsEnumerable().Sum(t => t.CommValue);
            
        }

        public double GetComission(List<SalesOrderModel> salesOrder, Enums.BaseStatus status)
        {
            var comissions = 0.0;
            foreach(var order in salesOrder)
            {
                comissions += GetComission(order.Id, status);
            }

            return comissions;
        }

        public double GetComission(DateTime ini, DateTime end,Enums.BaseStatus status)
        {
            return dbSet.Where(t => t.UpdateAt >= ini && t.UpdateAt <= end).AsEnumerable().Sum(t => t.CommValue);
        }

        public void SecurityRulles(ref UserModel model, Enums.ActionRepository action)
        {

            switch (action)
            {
                case Enums.ActionRepository.All:
                    this.SecurityRulles(ref model, action);
                    SecurityRulles(ref model, Enums.ActionRepository.Add);
                    SecurityRulles(ref model, Enums.ActionRepository.Update);
                    if(Get(model.Unique).Blocked)
                        throw new Exception("Não é possivel editar a linha bloqueada");
                    SecurityRulles(ref model, Enums.ActionRepository.Delete);
                    if(Get(model.Unique).Blocked)
                        throw new Exception("Não é possivel deletar a linha bloqueada");
                    SecurityRulles(ref model, Enums.ActionRepository.None); 
                    break;
                case Enums.ActionRepository.Add: break;
                case Enums.ActionRepository.Update: break;
                case Enums.ActionRepository.Delete: break;
                case Enums.ActionRepository.None: break;

            }

            this.SecurityRulles(ref model, action); 

            #region Required
            #endregion
        }
    }
}