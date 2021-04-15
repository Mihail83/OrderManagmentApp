using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.Infrastructure.StateKeepers
{
    public class OrderManagerState
    {
        public OrderManagerState() 
        {
            PageState = new PageState();
            FilterState = new FilterStateOfOrders();
            SortState = new SortStateOfOrders();
        }
        public PageState PageState { get; set; }
        public FilterStateOfOrders FilterState { get; set; }
        public SortStateOfOrders SortState { get; set; }
    }
}
