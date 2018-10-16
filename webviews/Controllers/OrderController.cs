using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webviews.Models.Documents;
using webviews.Models.ViewModels;
using webviews.Repositories.Administration;
using webviews.Repositories.Documents;
using webviews.Repositories.Partners;

namespace webviews.Controllers
{
    public class OrderController : BaseController
    {
        private readonly ISalesOrderRepository SalesOrderRepository;
        private readonly ISalesOrder_ItemRepository SalesOrder_ItemRepository;
        private readonly IBusinessPartnerRepository BusinessPartnerRepository;

        public OrderController(IUserRepository UserRepository,
            IBusinessPartnerRepository BusinessPartnerRepository,
            ISalesOrderRepository SalesOrderRepository,
            ISalesOrder_ItemRepository SalesOrder_ItemRepository, 
            IHttpContextAccessor ContextAccessor) : base("OrderController", UserRepository, ContextAccessor)
        {
            this.SalesOrderRepository = SalesOrderRepository;
            this.BusinessPartnerRepository = BusinessPartnerRepository;
        }

        [Route("/app/order/list")]
        public IActionResult List()
        {
            var model = new webviews.Models.ViewModels.ListOrderViewModel(UserLogin.Id, SalesOrderRepository);
            return View(model);
        }

        [Route("/app/order/header/{unique?}")]
        public IActionResult Header(string unique)
        {
            var model = new DocumentHeaderViewModel(UserLogin, unique, SalesOrderRepository, BusinessPartnerRepository);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/app/order/header/")]
        public IActionResult Header(DocumentHeaderViewModel model)
        {
            try
            {
                model.Order = SalesOrderRepository.Add(model.Order);

               return RedirectToAction("docId", new { docId = model.Order.Id });
            }
            catch (Exception ex)
            {
                AddTempData(ex);
                return View(model);
            }
        }

        [HttpGet]
        [Route("/app/order/lines/{docId}")]
        public IActionResult Lines(int docId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/app/order/lines/")]
        public IActionResult Lines(SalesOrder_ItemModel model)
        {
            return View();
        }

        [HttpGet]
        [Route("/app/order/footer/{unique}")]
        public IActionResult Footer(string unique)
        {
            return View();
        }

        [HttpPost]
        [Route("/app/order/footer")]
        public IActionResult Footer(SalesOrderModel model)
        {
            return View();
        }
    }
}
