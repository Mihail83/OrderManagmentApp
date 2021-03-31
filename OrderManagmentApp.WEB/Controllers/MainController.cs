using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;

namespace OrderManagmentApp.WEB.Controllers
{
    public class MainController : Controller
    {
        public IActionResult MainPage([FromServices] OrderSupplierForMainPage orders, [FromServices] IMapper<Order, OrderViewModel> mapper )
        {
            var AllOrderViewModel = new List<OrderViewModel>();
            foreach (var order in orders.GetOrdersToMainPage())
            {
                AllOrderViewModel.Add(mapper.Map(order));
            }
            
            return View(AllOrderViewModel);
        }
    }
}
