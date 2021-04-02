using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;

namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperCustomerViewModel_Customer : IMapper<CustomerViewModel, Customer>
    {
        public Customer Map(CustomerViewModel model)
        {
            var customer = new Customer
            {
                Id = model.Id,
                AdditionalInfo = model.AdditionalInfo,
                Address = model.Address,
                Emeil = model.Emeil,
                Name = model.Name,
                FirstPhone = model.FirstPhone,
                SecondPhone = model.SecondPhone,
                ThirdPhone = model.ThirdPhone
            };              
                customer.CompanyName = model.CompanyName ?? String.Empty;
                customer.CompanyAddress = model.CompanyAddress ?? String.Empty;
                customer.CompanyTaxPayerId = model.CompanyTaxPayerId ?? String.Empty;               
                customer.BankAccount = model.BankAccount ?? String.Empty;
            
            return customer;
        }
    }
}
