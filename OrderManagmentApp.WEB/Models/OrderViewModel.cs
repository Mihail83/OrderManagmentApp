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
        [Display(Name ="Спецификация")]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Создан")]
        public DateTime DateOfCreating { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Display(Name = "Клиент")]
        public string CustomerName { get; set; }
        [Display(Name = "Телефон")]
        public List<string> CustomerPhones { get; set; }
        [Display(Name = "Договор")]
        public string CurrentAgreement { get; set; }
        public int? CurrentAgreementId { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        [Display(Name = "Товар")]
        public string Good { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Сумма контракта")]
        public decimal ContractSum { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Аванс")]
        public decimal Advance { get; set; }
        [Display(Name = "Комментарий")]
        public string AdditionalInfo { get; set; }
        [Display(Name = "Статус")]
        public OrderState OrderState { get; set; }

        public int? ShipmentSpecialistId { get; set; }

        [Display(Name = "Кто отгружает")]
        public string ShipmentSpecialist { get; set; }

        public int? ShipmentDestinationId { get; set; }

        [Display(Name = "Отгрузка в")]
        public string ShipmentDestination { get; set; }
        [Required]
        public int ManagerId { get; set; }
        
        [Display(Name = "Менеджер")]
        public string Manager { get; set; }

        [Display(Name = "Статус Алютех")]
        public string OrderInFactory_StateOfShipment { get; set; }
        [UIHint("Boolean")]
        public bool IsArchived { get; set; }
    }
}
