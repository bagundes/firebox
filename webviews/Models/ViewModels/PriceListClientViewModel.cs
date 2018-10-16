using System.Collections.Generic;
using webviews.Models.Invariable;
using webviews.Repositories.Invariable;

namespace webviews.Models.ViewModels
{
    public class PriceListClientViewModel
    {
        public readonly List<UfToPriceListModel> UfToPriceList;
        public readonly List<string> UFList;
        public readonly List<PriceListModel> PriceList;

        public PriceListClientViewModel(IUfToPriceListRepository ufToPriceListRepository, IPriceListRepository priceListRepository, ICityRepository cityRepository)
        {
            UfToPriceList = ufToPriceListRepository.Get();

        }
    }
}