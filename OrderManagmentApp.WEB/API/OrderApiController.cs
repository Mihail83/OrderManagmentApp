using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Services;

namespace OrderManagmentApp.WEB.API
{
    
    [ApiController]
    public class OrderApiController : Controller
    {
        private readonly OrderManagmentAppContext _appContext;
        private readonly OrderService _orderService;
        public OrderApiController(OrderManagmentAppContext appContext, OrderService orderService) 
        {
            _appContext = appContext;
            _orderService = orderService;
        }
       

        [Produces("application/json")]
        [HttpGet]
        [Route("api/GetOrdersThisCustomer")]
        public  JsonResult GetOrdersThisCustomer(int id)
        {
            var Orders = _appContext.Orders
                .Include(ord=>ord.OrderAgreement)
                .Where(order => order.CustomerId == id && order.OrderAgreement == null)
                .Select(order =>  new {id = order.Id, date= ((DateTime)order.DateOfCreating).ToShortDateString()  } );                
                
            return Json(Orders.ToList());
        }
    }
}
