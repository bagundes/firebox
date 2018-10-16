using System;
using webviews.Repositories.Documents;

namespace webviews.Models.ViewModels
{
    public class MorrisComissionViewModel
    {
        public int[] ListThisMonth = new int[4];
        public int[] ListLastMonth = new int[4];
        public double ValueThisMonth {get;set;}
        public double ValueLastMonth {get;set;}

        public MorrisComissionViewModel(ISalesOrder_ItemRepository salesOrder_ItemRepository)
        {
            var today = DateTime.Now; 
            var firstDate = new DateTime(today.Year, today.Month, 1);
            var lastDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            ValueThisMonth = salesOrder_ItemRepository.GetComission(firstDate, lastDate, Enums.BaseStatus.Close);
            ListThisMonth[0] = (int) salesOrder_ItemRepository.GetComission(firstDate, firstDate.AddDays(7), Enums.BaseStatus.Close);
            ListThisMonth[1] = (int) salesOrder_ItemRepository.GetComission(firstDate.AddDays(8), firstDate.AddDays(14), Enums.BaseStatus.Close);
            ListThisMonth[2] = (int) salesOrder_ItemRepository.GetComission(firstDate.AddDays(20), firstDate.AddDays(21), Enums.BaseStatus.Close);
            ListThisMonth[3] = (int) salesOrder_ItemRepository.GetComission(firstDate.AddDays(22), lastDate, Enums.BaseStatus.Close);

            firstDate = firstDate.AddMonths(-1);
            lastDate = lastDate.AddMonths(-1);

            ValueLastMonth = salesOrder_ItemRepository.GetComission(firstDate, firstDate, Enums.BaseStatus.Close);
            ListLastMonth[0] = (int) salesOrder_ItemRepository.GetComission(firstDate, firstDate.AddDays(7), Enums.BaseStatus.Close);
            ListLastMonth[1] = (int) salesOrder_ItemRepository.GetComission(firstDate.AddDays(8), firstDate.AddDays(14), Enums.BaseStatus.Close);
            ListLastMonth[2] = (int) salesOrder_ItemRepository.GetComission(firstDate.AddDays(20), firstDate.AddDays(21), Enums.BaseStatus.Close);
            ListLastMonth[3] = (int) salesOrder_ItemRepository.GetComission(firstDate.AddDays(22), lastDate, Enums.BaseStatus.Close);
            
        }
    }
}