using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class CustomerService
    {
        
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {          
            _customerRepository = customerRepository;
        }

        public void SaveCustomer(Customer customer)
        {           
            _customerRepository.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomer(IEnumerable<Expression<Func<Customer, bool>>> expressions = null)
        {
            var customers = _customerRepository.GetAllByExpression(expressions);
            return customers;
        }

        public void UpdateCustomer(Customer customer)
        {           
            _customerRepository.Update(customer);
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _customerRepository.GetById(id);            

            return customer;
        }
    }
}
