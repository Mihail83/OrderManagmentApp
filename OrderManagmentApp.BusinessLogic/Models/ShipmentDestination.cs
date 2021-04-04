using System.Collections.Generic;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class ShipmentDestination
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public List<Order> Orders { get; set; }


    }
}
