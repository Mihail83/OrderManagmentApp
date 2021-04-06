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
        private readonly IOrderAgreementRepository _orderAgreementRepository;

        public OrderService(IOrderRepository orderRepository, IOrderAgreementRepository orderAgreementRepository)
        {
            _orderRepository = orderRepository;
            _orderAgreementRepository = orderAgreementRepository;


        }
        public IEnumerable<Order> GetOrdersToOrderManagerPage(IEnumerable<Expression<Func<Order, bool>>> expressions = null)
        {
            var orders = _orderRepository.GetAllOrdersNoArchive(expressions);
          
            return orders;
        }

        public void SaveOrder(Order newOrder)
        {
            var tempOrderAgreement = newOrder.OrderAgreement;
            newOrder.OrderAgreement = null;
            _orderRepository.Add(newOrder);

            if (tempOrderAgreement != null)
            {
                _orderAgreementRepository.Add(tempOrderAgreement);
            }
        }
    }
}
