using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrderManagmentApp.DataLayer.Enums;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class OrderInALutehEntity
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
        public OrderEntity Order { get; set; }
    }
}
