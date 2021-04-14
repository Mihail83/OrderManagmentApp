using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.Infrastructure.StateKeepers;

namespace OrderManagmentApp.WEB.Models
{
    public class OrderManagerViewModel
    {
        public IEnumerable<OrderViewModel> orderViewModels;
        public OrderManagerState state;
    }
}
