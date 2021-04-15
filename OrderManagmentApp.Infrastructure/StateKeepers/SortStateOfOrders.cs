using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.Infrastructure.Enums;

namespace OrderManagmentApp.Infrastructure.StateKeepers
{
    public class SortStateOfOrders
    {
        public OrderSortState CurrentSort { get; set; } = OrderSortState.DateOfCreatingDesc;
        public OrderSortState IdSort 
            => CurrentSort == OrderSortState.IdAcs 
            ? OrderSortState.IdDecs : OrderSortState.IdAcs;
        public OrderSortState DateOfCreatingSort
            => CurrentSort == OrderSortState.DateOfCreatingAsc 
            ? OrderSortState.DateOfCreatingDesc : OrderSortState.DateOfCreatingAsc;
        public OrderSortState CustomerSort
            => CurrentSort == OrderSortState.CustomerAsc 
            ? OrderSortState.CustomerDesc : OrderSortState.CustomerAsc;
        public OrderSortState OrderStateSort
            => CurrentSort == OrderSortState.OrderStateAsc 
            ? OrderSortState.OrderStateDesc : OrderSortState.OrderStateAsc;
        public OrderSortState ShipmentSpecialistSort
            => CurrentSort == OrderSortState.ShipmentSpecialistAsc 
            ? OrderSortState.ShipmentSpecialistDesc : OrderSortState.ShipmentSpecialistAsc;
        public OrderSortState ShipmentDestinationSort 
            => CurrentSort == OrderSortState.ShipmentDestinationAsc 
            ? OrderSortState.ShipmentDestinationDesc : OrderSortState.ShipmentDestinationAsc;
        public OrderSortState ManagerSort 
            => CurrentSort == OrderSortState.ManagerAsc 
            ? OrderSortState.ManagerDesc : OrderSortState.ManagerAsc;
        public OrderSortState OrderInFactorySort 
            => CurrentSort == OrderSortState.OrderInFactoryAsc 
            ? OrderSortState.OrderInFactoryDesc : OrderSortState.OrderInFactoryAsc;
    }
}
