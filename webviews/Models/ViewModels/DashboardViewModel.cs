using System.Collections.Generic;

namespace webviews.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int[] ListPay = new int[12];
        public int[] ListPaid = new int[12];

        public double ValuePay = 0.00;
        public double ValuePaid = 0.00;

        public int DocOrders = 0;
        public int DocInvoices = 0;
        public int DocCancelled = 0; 
        public int DocTotal = 0; 

       // public List<ListOrderViewModel> Documents {get;set;} = new List<ListOrderViewModel>();

        
    }
}