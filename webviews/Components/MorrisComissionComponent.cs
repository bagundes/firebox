using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Models.ViewModels;
using webviews.Repositories.Documents;

namespace webviews.Components
{
    
    public class MorrisComissionViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor ContextAccessor;
        private readonly ISalesOrder_ItemRepository SalesOrder_ItemRepository;
        
        public MorrisComissionViewComponent(
            ISalesOrder_ItemRepository order_ItemRepository,
            IHttpContextAccessor contextAccessor)
        {
            this.ContextAccessor = contextAccessor;
            this.SalesOrder_ItemRepository = order_ItemRepository;
        }

        public IViewComponentResult Invoke()    
        {
            var modelView = new MorrisComissionViewModel(SalesOrder_ItemRepository);
            return View(modelView);
        }
    }
}