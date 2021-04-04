using System;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class Agreement
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Good { get; set; }
        public decimal Sum { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public OrderAgreement OrderAgreement { get; set; }
    }
}
