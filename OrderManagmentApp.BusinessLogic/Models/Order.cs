using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class Order
    {        
        public int ID { get; set; }
        public DateTime DateOfCreating { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<string> CustomerPhones { get; set; }

        public string CurrentTreaty { get; set; }
        public string Good { get; set; }    //if contract.good != emty... then   this=contract.good
        public decimal ContractAmount { get; set; }   //if contract.Price != emty... then   this=contract.Price
        public decimal Advance { get; set; }
        public string Comment { get; set; }
        public string OrderState { get; set; } //map   from enum to string   and back 
        public int? ShipmentSpecialistId { get; set; }
        public string ShipmentSpecialist { get; set; }
        public int? ShipmentDestinationId { get; set; }
        public string ShipmentDestination { get; set; }
        public int ManagerId { get; set; }
        public string Manager { get; set; }
        public string OrderInALuteh_StateOfShipment { get; set; }
        public bool IsArchive { get; set; }
    }
}
