using Microsoft.AspNetCore.Mvc;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;
using OrderManagmentApp.WEB.Models;
using System.Collections.Generic;

namespace OrderManagmentApp.WEB.Controllers
{
    public class MainController : Controller
    {
        public IActionResult MainPage([FromServices] OrderService orders, [FromServices] IMapper<Order, OrderViewModel> mapper)
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
