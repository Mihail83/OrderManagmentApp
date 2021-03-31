using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using OrderManagmentApp.BusinessLogic.Models;



namespace OrderManagmentApp.BusinessLogic.Services.MAP
{
    public class MapperCustomerEntity_Customer : IMapper<CustomerEntity, Customer>
    {
        public Customer Map(CustomerEntity model)
        {
            var customer = new Customer            
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address ?? string.Empty,
                FirstPhone = model.Phones?.FirstNumber ?? String.Empty,
                SecondPhone = model.Phones?.SecondNumber ?? null,
                ThirdPhone = model.Phones?.ThirdNumber ?? null ,   //   null   or empty
                Emeil = model.Emeil,
                AdditionalInfo = model.AdditionalInfo ?? String.Empty                
            };
            if (model.Company !=null)
            {
                customer.CompanyTaxPayerId = model.Company?.TaxPayerId;
                customer.CompanyAddress = model.Company?.Address;
                customer.CompanyOKPO = model.Company?.OKPO ?? 0;
                customer.BankName = model.Company?.Bank?.Name;
                customer.BankNumber = model.Company?.Bank?.Number;
                customer.BankAccount = model.Company?.Bank?.Account; 
            }
                return customer;
        }
    }
}
