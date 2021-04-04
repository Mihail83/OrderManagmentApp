using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;


namespace OrderManagmentApp.BusinessLogic.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            
        }
        public IEnumerable<Order> GetOrdersToMainPage(IEnumerable<Expression<Func<Order, bool>>> expressions = null)
        {
            var orders = _orderRepository.GetAllOrdersNoArchive(expressions);
          
            return orders;
        }

    }
}
