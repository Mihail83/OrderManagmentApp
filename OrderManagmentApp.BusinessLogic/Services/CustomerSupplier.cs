using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class CustomerSupplier
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper<CustomerEntity, Customer> _mapper;
        public CustomerSupplier(ICustomerRepository customerRepository, IMapper<CustomerEntity, Customer> mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public Customer GetCustomerById(int id)
        {
            var customerEntity = _customerRepository.GetById(id);
            var customer = _mapper.Map(customerEntity);

            return customer;
        }


    }
}
