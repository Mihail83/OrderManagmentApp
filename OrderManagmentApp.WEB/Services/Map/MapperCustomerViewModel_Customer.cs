using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;
using System;

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
                Name = model.Name                
            };
            
                customer.Company = new Company
                {
                    Name = model.CompanyName ?? String.Empty,
                    Address = model.CompanyAddress ?? String.Empty,
                    TaxPayerId = model.CompanyTaxPayerId ?? String.Empty,
                    BankAccount = model.BankAccount ?? String.Empty
                };
            customer.Phones.Add(model.FirstPhone);
            customer.Phones.Add(model.SecondPhone ?? string.Empty);
            customer.Phones.Add(model.ThirdPhone ?? string.Empty); 







            return customer;
        }
    }
}
