using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderManagmentApp.WEB.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Имя")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Required]
        //public List<string> PhoneNumbers { get; set; }
        [Phone]
        [Display(Name = "Телефон")]
        public string FirstPhone { get; set; }
        [Phone]
        [Display(Name = "доп телефон")]
        public string SecondPhone { get; set; }
        [Phone]
        [Display(Name = "доп телефон")]
        public string ThirdPhone { get; set; }
        [EmailAddress]
        [Display(Name = "Электронная почта")]
        public string Emeil { get; set; }
        [Display(Name = "Информация")]
        public string AdditionalInfo { get; set; }
        [Display(Name = "Название компании")]
        public string CompanyName { get; set; }
       
        [Display(Name = "УНП")]
        public string CompanyTaxPayerId { get; set; }
        
        [Display(Name = "Адрес компании ")]
        public string CompanyAddress { get; set; }
       
        [Display(Name = "ОКПО")]
        public ulong CompanyOKPO { get; set; }
       

        [Display(Name = "Название банка")]
        public string BankName { get; set; }
        [Display(Name = "Код Банка")]
        public string BankNumber { get; set; }
        
        [Display(Name = "Номер счета")]
        public string BankAccount { get; set; }
        
    }
}
