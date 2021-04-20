using System.Collections.Generic;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class ShipmentSpecialist
    {
        public int Id { get; set; }
        public string Specialist { get; set; }
        public List<Order> Orders { get; set; }
        public bool IsDismissed { get; set; }
    }
}
