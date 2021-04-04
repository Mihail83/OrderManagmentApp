using OrderManagmentApp.WEB.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OrderManagmentApp.WEB.Services.Validation
{
    public class CompanyOfCustomerValidationAttribute : ValidationAttribute
    {
        public CompanyOfCustomerValidationAttribute()
        {
            ErrorMessage = "Заполните все поля компании или ни одного";
        }

        public override bool IsValid(object value)
        {
            CustomerViewModel customer = value as CustomerViewModel;
            bool[] array = new bool[] { customer?.CompanyName == null, customer?.CompanyAddress == null, customer?.BankAccount == null, customer?.CompanyTaxPayerId == null };
            if (array.Contains(!array[0]))
            {
                return false;
            }
            return true;

        }


    }
}
