using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.WEB.Models;

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
                FirstPhone = model.FirstPhone,
                SecondPhone = model.SecondPhone,
                ThirdPhone = model.ThirdPhone
            };
            if (!String.IsNullOrWhiteSpace(model.CompanyName) && model.CompanyName.Length != 0 )
            {
                customerViewModel.CompanyName = model.CompanyName;
                customerViewModel.CompanyAddress = model.CompanyAddress;
                customerViewModel.CompanyTaxPayerId = model.CompanyTaxPayerId;
                customerViewModel.CompanyOKPO = model.CompanyOKPO;
                customerViewModel.BankName = model.BankName;
                customerViewModel.BankNumber = model.BankNumber;
                customerViewModel.BankAccount= model.BankAccount;
            }            
            return customerViewModel;            
        }
    }
}
