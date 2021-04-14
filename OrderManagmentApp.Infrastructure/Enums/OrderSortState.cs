using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.Infrastructure.Enums
{
    public enum OrderSortState
    {
        IdAcs,
        IdDecs,        
        DateOfCreatingAsc,
        DateOfCreatingDesc,
        CustomerAsc,
        CustomerDesc,
        OrderStateAsc,
        OrderStateDesc,
        ShipmentSpecialistAsc,
        ShipmentSpecialistDesc,
        ShipmentDestinationAsc,
        ShipmentDestinationDesc,
        ManagerAsc,
        ManagerDesc,
        OrderInFactoryAsc,
        OrderInFactoryDesc
    }
}
