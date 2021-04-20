using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;
using OrderManagmentApp.BusinessLogic.FilteringExtensions;
using OrderManagmentApp.BusinessLogic.SortingExtensions;
using OrderManagmentApp.Infrastructure.Constatnts;
using OrderManagmentApp.Infrastructure.StateKeepers;



namespace OrderManagmentApp.BusinessLogic.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderAgreementRepository _orderAgreementRepository;

        public OrderService (IOrderRepository orderRepository, IOrderAgreementRepository orderAgreementRepository)
        {
            _orderRepository = orderRepository;
            _orderAgreementRepository = orderAgreementRepository;
        }
        public IEnumerable<Order> GetOrdersToOrderManagerPage(OrderManagerState ordersState)
        {            
            int pageSize = ordersState.PageState.CurrentPageSize;
            int page = ordersState.PageState.CurrentPage;

            var orders = _orderRepository.GetOrdersNoArchive()
                .FilterByCustomerName(ordersState?.FilterState?.ValueOfFilterByCustomerName)
                .FilterByDateOfCreating(ordersState?.FilterState?.ValueOfFilterByDateOfCreating)
                .FilterById(ordersState?.FilterState?.ValueOfFilterById)
                .FilterByOrderState(ordersState?.FilterState ?.ValueOfFilterByOrderState)
                .FilterByManagerId(ordersState?.FilterState ?.ValueOfFilterByManagerId)
                .FilterByShipmentDestId(ordersState?.FilterState?.ValueOfFilterByShipmentDestId)
                .FilterByShipmentSpecId(ordersState?.FilterState?.ValueOfFilterByShipmentSpecId)
                .SortBy(ordersState.SortState.CurrentSort);

            ordersState.PageState.PageTotal = (int)Math.Ceiling (orders.Count()/ (double)pageSize);

            return orders
                .Skip(pageSize * (page - 1))
                .Take(pageSize);
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

        public void UpdateOrder(Order newOrder)
        {
            var tempOrderAgreement = newOrder.OrderAgreement;
            newOrder.OrderAgreement = null;

            _orderRepository.Update(newOrder);

            if (tempOrderAgreement != null && _orderAgreementRepository.GetAllByExpression()
                .FirstOrDefault(ordAgr => ordAgr.OrderId == tempOrderAgreement.OrderId) == null)
            {
                _orderAgreementRepository.Add(tempOrderAgreement);
            }
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
