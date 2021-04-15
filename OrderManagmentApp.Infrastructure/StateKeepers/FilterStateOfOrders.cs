using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.Infrastructure.Constatnts;
using OrderManagmentApp.Infrastructure.Enums;

namespace OrderManagmentApp.Infrastructure.StateKeepers
{
    public class FilterStateOfOrders
    {       
        public DateTime? ValueOfFilterByDateOfCreating { get; set; }
        public string ValueOfFilterByCustomerName { get; set; }
        public int? ValueOfFilterById { get; set; }        
        public OrderState? ValueOfFilterByOrderState { get; set; }
        public int? ValueOfFilterByShipmentSpecId { get; set; }
        public int? ValueOfFilterByShipmentDestId { get; set; }
        public int? ValueOfFilterByManagerId { get; set; }




    }
}
