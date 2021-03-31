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
            if (!String.IsNullOrWhiteSpace(model.CompanyName) && model.CompanyName.Length > 2)
            {
                customer.CompanyName = model.CompanyName;
                customer.CompanyAddress = model.CompanyAddress;
                customer.CompanyTaxPayerId = model.CompanyTaxPayerId;
                customer.CompanyOKPO = model.CompanyOKPO;
                customer.BankName = model.BankName;
                customer.BankNumber = model.BankNumber;
                customer.BankAccount = model.BankAccount;
            }
            return customer;
        }
    }
}
