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
        public OrderEntityAgreementEntity OrderAgreement { get; set; }

        [MaxLength(200)]
        public string Good { get; set; }        
        public decimal ContractSum { get; set; }       
        public decimal Advance { get; set; }
        [MaxLength(200)]
        public string AdditionalInfo { get; set; }              
        public OrderState OrderState { get; set; }
        public ShipmentSpecialistEntity ShipmentSpecialist { get; set; }
        public ShipmentDestinationEntity ShipmentDestination { get; set; }
        public ManagerEntity Manager { get; set; }
        public OrderInFactoryEntity OrderInFactory { get; set; }
        public bool IsArchived { get; set; }
    }
}
