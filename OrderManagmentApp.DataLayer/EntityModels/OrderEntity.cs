using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrderManagmentApp.DataLayer.Enums;

namespace OrderManagmentApp.DataLayer.EntityModels
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime DateOfCreating { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }
        public string CurrentAgreement { get; set; } //  One to zero/one  
        [MaxLength(200)]
        public string Good { get; set; }    //if contract.good != emty... then   this=contract.good
        
        public decimal ContractSum { get; set; }   //if contract.Price != emty... then   this=contract.Price
        
       
        public decimal Advance { get; set; }
        [MaxLength(200)]
        public string AdditionalInfo { get; set; }              
        public OrderState OrderState { get; set; }
        
        //public int? ShipmentSpecialistId { get; set; }
        public ShipmentSpecialistEntity ShipmentSpecialist { get; set; }
        //public int? ShipmentDestinationId { get; set; }
        public ShipmentDestinationEntity ShipmentDestination { get; set; }
        //public int ManagerId { get; set; }
        public ManagerEntity Manager { get; set; }
        public OrderInFactoryEntity OrderInFactory { get; set; }

        public bool IsArchived { get; set; }
    }
}
