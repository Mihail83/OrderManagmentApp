using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.Infrastructure.Enums;

namespace OrderManagmentApp.BusinessLogic.SortingExtensions
{
    public static class SortingOrdersExtensions
    {
        public static IQueryable<Order> SortBy(this IQueryable<Order> orders, OrderSortState sortState = OrderSortState.DateOfCreatingAsc)
        {
            orders = sortState switch     
            {
                OrderSortState.CustomerAsc => orders.OrderBy(ord=>ord.Customer.Name),
                OrderSortState.CustomerDesc => orders.OrderByDescending(ord => ord.Customer.Name),

                OrderSortState.DateOfCreatingDesc => orders.OrderByDescending(ord => ord.DateOfCreating),
                OrderSortState.DateOfCreatingAsc => orders.OrderBy(ord => ord.DateOfCreating),

                OrderSortState.IdAcs => orders.OrderBy(ord => ord.Id),
                OrderSortState.IdDecs => orders.OrderByDescending(ord => ord.Id),

                OrderSortState.OrderInFactoryAsc => orders.OrderBy(ord => ord.OrderInFactory),
                OrderSortState.OrderInFactoryDesc => orders.OrderByDescending(ord => ord.OrderInFactory),

                OrderSortState.ManagerAsc => orders.OrderBy(ord => ord.Manager.Name),
                OrderSortState.ManagerDesc => orders.OrderByDescending(ord => ord.Manager.Name),

                OrderSortState.OrderStateAsc => orders.OrderBy(ord => ord.OrderState),
                OrderSortState.OrderStateDesc => orders.OrderByDescending(ord => ord.OrderState),

                OrderSortState.ShipmentDestinationAsc => orders.OrderBy(ord => ord.ShipmentDestination.Destination),
                OrderSortState.ShipmentDestinationDesc => orders.OrderByDescending(ord => ord.ShipmentDestination.Destination),

                OrderSortState.ShipmentSpecialistAsc => orders.OrderBy(ord => ord.ShipmentSpecialist.Specialist),
                OrderSortState.ShipmentSpecialistDesc => orders.OrderByDescending(ord => ord.ShipmentSpecialist.Specialist), 
                _ =>orders.OrderByDescending(ord=> ord.DateOfCreating)
            };
            return orders;
        }
    }
}
