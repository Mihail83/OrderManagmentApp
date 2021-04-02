﻿using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.BusinessLogic.Services.MAP
{
    public class MapperCustomer_CustomerEntity : IMapper<Customer, CustomerEntity>
    {
        public CustomerEntity Map(Customer model)
        {
            return new CustomerEntity
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address ?? string.Empty,
                Phones = new Phones { 
                    FirstNumber = model.FirstPhone, 
                    SecondNumber = model.SecondPhone, 
                    ThirdNumber = model.ThirdPhone 
                },
                Emeil = model.Emeil ?? String.Empty,
                AdditionalInfo = model.AdditionalInfo ?? string.Empty,
                Company = model.CompanyName != null ? new Company
                {
                    
                    Name = model.CompanyName,
                    TaxPayerId = model.CompanyTaxPayerId,
                    Address = model.CompanyAddress,
                    BankAccount = model.BankAccount,
                } :null
            };            
        }
    }
}