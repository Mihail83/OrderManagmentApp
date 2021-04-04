using System;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class OrderInFactory
    {
        public int ID { get; set; }
        public string StateOfSet { get; set; }
        public string StateOfShipment { get; set; }
        public decimal Sum { get; set; }
        public decimal PaymentedSum { get; set; }
        public string StateOfPayment { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string StateOfOrder { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
