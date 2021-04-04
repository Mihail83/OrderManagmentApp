using OrderManagmentApp.Infrastructure.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfCreating { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public OrderAgreement OrderAgreement { get; set; }
        
        public string Good { get; set; }
        public decimal ContractSum { get; set; }
        public decimal Advance { get; set; }       
        public string AdditionalInfo { get; set; }
        public OrderState OrderState { get; set; }
        public ShipmentSpecialist ShipmentSpecialist { get; set; }
        public ShipmentDestination ShipmentDestination { get; set; }
        public Manager Manager { get; set; }
        public OrderInFactory OrderInFactory { get; set; }
        public bool IsArchived { get; set; }
    }
}
