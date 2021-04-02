using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.BusinessLogic.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public List<string> PhoneNumbers { get; set; }
        public string FirstPhone { get; set; }
        public string SecondPhone { get; set; }
        public string ThirdPhone { get; set; }
        public string Emeil { get; set; }
        public string AdditionalInfo { get; set; }

        public string CompanyName { get; set; }
        public string CompanyTaxPayerId { get; set; }
        public string CompanyAddress { get; set; }
        //public ulong?  CompanyOKPO { get; set; }
        //public string BankName { get; set; }
        //public string BankNumber { get; set; }
        public string BankAccount { get; set; }
        

        public List<int> OrdersId { get; set; }   
        public List<int> AgreementsId { get; set; } 

    }
}
