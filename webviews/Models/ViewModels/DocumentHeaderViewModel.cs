using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webviews.Models.Administration;
using webviews.Models.Documents;
using webviews.Models.Partners;
using webviews.Repositories.Documents;
using webviews.Repositories.Partners;

namespace webviews.Models.ViewModels
{
    public class DocumentHeaderViewModel
    {
        public SalesOrderModel Order { get; set; } = new SalesOrderModel();
        public IEnumerable<SelectListItem> Customer { get; set; }

        public DocumentHeaderViewModel() { }
        public DocumentHeaderViewModel(UserModel user, string unique, ISalesOrderRepository salesOrderRepository, IBusinessPartnerRepository businessPartnerRepository)
        {
            Order = salesOrderRepository.Get(unique);
            if (Order == null)
                Order = new SalesOrderModel();
            if (user.Admin)
                Customer = businessPartnerRepository.GetSelect();
            else
                Customer = businessPartnerRepository.GetSelectBySalesman(user.ERPVendor);
        }
    }
}
