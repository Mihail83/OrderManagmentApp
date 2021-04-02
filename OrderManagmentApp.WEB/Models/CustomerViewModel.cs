using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OrderManagmentApp.WEB.Services.Validation;

namespace OrderManagmentApp.WEB.Models
{
    [CompanyOfCustomerValidation]
    public class CustomerViewModel
    {
        [ScaffoldColumn(true)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите Имя клиента")]
        [Display(Name ="Имя")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }        
        
        [Required(ErrorMessage = "Введите телефонный номер")]        
        [DataType(DataType.PhoneNumber)]        
        [RegularExpression(@"^\+[0-9]{3}[ /-][0-9]{2}[ -/][0-9]{3}[ /-][0-9]{2}[ -/][0-9]{2}$", ErrorMessage = "+XXX XX XXX XX XX")]
        [Display(Name = "Телефон")]
        public string FirstPhone { get; set; }
        [Phone]
        [Display(Name = "доп телефон")]
        public string SecondPhone { get; set; }
        [Phone]
        [Display(Name = "доп телефон 2")]
        public string ThirdPhone { get; set; }
        [EmailAddress]
        [Display(Name = "Электронная почта")]
        public string Emeil { get; set; }
        [Display(Name = "Комментарий")]
        public string AdditionalInfo { get; set; }

        [Display(Name = "Название компании")]
        public string CompanyName { get; set; }
       
        [Display(Name = "УНП")]
        public string CompanyTaxPayerId { get; set; }
        
        [Display(Name = "Адрес компании ")]
        public string CompanyAddress { get; set; }    
        
        [Display(Name = "Номер счета")]
        public string BankAccount { get; set; }
        
    }
}
