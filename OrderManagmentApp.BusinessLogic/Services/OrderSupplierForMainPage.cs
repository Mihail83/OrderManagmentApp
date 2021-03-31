using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Repositories;
using OrderManagmentApp.BusinessLogic.Services.MAP;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;


namespace OrderManagmentApp.BusinessLogic.Services
{
    public class OrderSupplierForMainPage
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper<OrderEntity, Order> _mapper;
        public OrderSupplierForMainPage(IOrderRepository orderRepository, IMapper<OrderEntity, Order> mapper )
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public IEnumerable<Order> GetOrdersToMainPage()
        {
            var orderEntities = _orderRepository.GetAllOrdersNoArchive();
            List<Order> orders = null;

            if (orderEntities != null)
            {
                orders = new List<Order>();
                foreach (var orderEntity in orderEntities)
                {
                    orders.Add(_mapper.Map(orderEntity));
                }                    
            }          
            return orders;
        }

    }
}
