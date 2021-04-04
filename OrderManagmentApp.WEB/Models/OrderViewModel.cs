using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrderManagmentApp.Infrastructure.Enums;

namespace OrderManagmentApp.WEB.Models
{
    public class OrderViewModel
    {
        [Required]
        [Range(99999, int.MaxValue, ErrorMessage = "Некоректный номер спецификации")]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfCreating { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<string> CustomerPhones { get; set; }
        [Display(Name = "Договор")]
        public string CurrentAgreement { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string Good { get; set; }
        [DataType(DataType.Currency)]
        public decimal ContractSum { get; set; }
        [DataType(DataType.Currency)]
        public decimal Advance { get; set; }
        public string AdditionalInfo { get; set; }
        public OrderState OrderState { get; set; }
        public string ShipmentSpecialist { get; set; }
        public string ShipmentDestination { get; set; }
        [Required]
        public string Manager { get; set; }
        public string OrderInFactory_StateOfShipment { get; set; }
        [UIHint("Boolean")]
        public bool IsArchived { get; set; }
    }
}
