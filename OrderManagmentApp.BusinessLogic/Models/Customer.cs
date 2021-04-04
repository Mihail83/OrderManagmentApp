using System.Collections.Generic;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<string> Phones { get; set; }
        public string Emeil { get; set; }
        public string AdditionalInfo { get; set; }       
        public Company Company { get; set; }
        public List<Order> Orders { get; set; }
        public List<Agreement> Agreements { get; set; }




    }
}
