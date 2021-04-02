﻿using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class CustomerServiceForSaveNew
    {
        private readonly IMapper<Customer, CustomerEntity> _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CustomerServiceForSaveNew(IMapper<Customer, CustomerEntity> mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public void SaveNewCustomer(Customer customer)
        {
            var customerEntity = _mapper.Map(customer);
            _customerRepository.Add(customerEntity);            
        }
    }
}