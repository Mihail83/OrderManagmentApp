using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;
using System;

namespace OrderManagmentApp.WEB.Services.Map
{
    public class MapperCustomer_CustomerViewModel : IMapper<Customer, CustomerViewModel>
    {
        public CustomerViewModel Map(Customer model)
        {
            var customerViewModel = new CustomerViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                AdditionalInfo = model.AdditionalInfo,
                Emeil = model.Emeil,
                FirstPhone = model.Phones[0],
                SecondPhone = model.Phones.Count > 1 ? model.Phones[1]:null,
                ThirdPhone = model.Phones.Count > 2 ? model.Phones[2] : null
            };
            if (!String.IsNullOrWhiteSpace(model.Company?.Name) && model.Company.Name.Length != 0)
            {
                customerViewModel.CompanyName = model.Company.Name;
                customerViewModel.CompanyAddress = model.Company.Address;
                customerViewModel.CompanyTaxPayerId = model.Company.TaxPayerId;
                customerViewModel.BankAccount = model.Company.BankAccount;
            }
            return customerViewModel;
        }
    }
}
