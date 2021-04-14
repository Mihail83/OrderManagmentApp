using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.Infrastructure.Enums;

namespace OrderManagmentApp.BusinessLogic.FilteringExtensions
{
    public static class OrderFilterExtensions
    {
        public static IQueryable<Order> FilterByCustomerName(this IQueryable<Order> orders, string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return orders;
            }
            else
            {
                return orders.Where(ord => ord.Customer.Name.Contains(name));
            }
        }
        public static IQueryable<Order> FilterByDateOfCreating(this IQueryable<Order> orders, DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                return orders;
            }
            else
            {
                var date = ((DateTime)dateTime).Date;
                return orders.Where(ord => ((DateTime)ord.DateOfCreating).Date == date );
            }
        }
        public static IQueryable<Order> FilterById(this IQueryable<Order> orders, int? id = null)
        {
            if (id != null)
            {
                orders = orders.Where(order => order.Id == id);
            }
            return orders;


        }
        public static IQueryable<Order> FilterByOrderState(this IQueryable<Order> orders, OrderState? orderState = null)
        {
            if (orderState != null)
            {
                orders = orders.Where(order => order.OrderState == orderState);
            }
            return orders;
        }

        public static IQueryable<Order> FilterByShipmentSpecId(this IQueryable<Order> orders, int? shipSpec = null)
        {
            if (shipSpec != null)
            {
                orders = orders.Where(order => order.ShipmentSpecialistId == shipSpec);
            }
            return orders;
        }
        public static IQueryable<Order> FilterByShipmentDestId(this IQueryable<Order> orders, int? shipDest = null)
        {
            if (shipDest != null)
            {
                orders = orders.Where(order => order.ShipmentDestinationId == shipDest);
            }
            return orders;
        }

        public static IQueryable<Order> FilterByManagerId(this IQueryable<Order> orders, int? managerId = null)
        {
            if (managerId != null)
            {
                orders = orders.Where(order => order.ManagerId == managerId);
            }
            return orders;
        }
        //OrderInFactory_StateOfShipment   filter






    }
}
