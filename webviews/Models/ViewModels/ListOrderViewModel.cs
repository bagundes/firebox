using System.Collections.Generic;
using webviews.Repositories.Documents;

namespace webviews.Models.ViewModels
{
    public class ListOrderViewModel
    {
        public List<Models.Documents.SalesOrderModel> Documents { get; set; } = new List<Documents.SalesOrderModel>();

        public ListOrderViewModel(int userId, ISalesOrderRepository salesOrder)
        {
            Documents = salesOrder.GetListByUser(userId);
        }

    }
}