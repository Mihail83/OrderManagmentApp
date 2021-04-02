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
                Address = model.Address ?? String.Empty,
                FirstPhone = model.Phones?.FirstNumber ?? String.Empty,
                SecondPhone = model.Phones?.SecondNumber ?? String.Empty,
                ThirdPhone = model.Phones?.ThirdNumber ?? String.Empty,   //   null   or empty
                Emeil = model.Emeil ?? String.Empty,
                AdditionalInfo = model.AdditionalInfo ?? String.Empty                
            };
            if (model.Company !=null)
            {
                customer.CompanyName = model.Company?.Name;
                customer.CompanyTaxPayerId = model.Company?.TaxPayerId;
                customer.CompanyAddress = model.Company?.Address;                
                customer.BankAccount = model.Company?.BankAccount; 
            }
                return customer;
        }
    }
}
