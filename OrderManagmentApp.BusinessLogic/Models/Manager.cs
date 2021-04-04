using System.Collections.Generic;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> OrderEntities { get; set; }
    }
}
