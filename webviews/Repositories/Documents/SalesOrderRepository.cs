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

    public interface ISalesOrderRepository : IBaseRepository<SalesOrderModel>
    {
    }
    public class SalesOrderRepository : BaseRepository<SalesOrderModel>, ISalesOrderRepository
    {
        public SalesOrderRepository(AppContext context) : base(context)
        {
        }

        public void CreateDefault()
        {
            throw new NotImplementedException();
        }
        #region IBaseRepository

        #endregion



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