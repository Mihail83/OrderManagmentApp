using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class Customers_Supplier
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper<CustomerEntity, Customer> _mapper;
        public Customers_Supplier(ICustomerRepository customerRepository, IMapper<CustomerEntity, Customer> mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            var customerEntities = _customerRepository.GetAllByExpression();
            List<Customer> customers = null;

            if (customerEntities !=null)
            {
                customers = new List<Customer>();
                foreach (var customerEntity in customerEntities)
                {
                    customers.Add(_mapper.Map(customerEntity));
                }
            }
            return customers;
        }
    }
}
