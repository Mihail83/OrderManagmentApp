using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Enums;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class Order
    {        
        public int Id { get; set; }
        public DateTime DateOfCreating { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }        
        public List<string> CustomerPhones { get; set; }        
        public string CurrentAgreement { get; set; }
        public string Good { get; set; }    
        public decimal ContractSum { get; set; }   
        public decimal Advance { get; set; }
        public string AdditionalInfo { get; set; }
        public string OrderState { get; set; }
        //public int? ShipmentSpecialistId { get; set; }
        public string ShipmentSpecialist { get; set; }
        //public int? ShipmentDestinationId { get; set; }
        public string ShipmentDestination { get; set; }
        //public int ManagerId { get; set; }
        public string Manager { get; set; }
        public string OrderInFactory_StateOfShipment { get; set; }
        public bool IsArchived { get; set; }
    }
}
