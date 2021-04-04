using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrderManagmentApp.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<Customer>();

        }
        public void Add(Customer entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new Customer { Id = id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAllByExpression(IEnumerable<Expression<Func<Customer, bool>>> expressions = null)
        {
            var customerEntities = new List<Customer>();

            if (expressions == null)
            {
                customerEntities.AddRange(_dbSet.AsNoTracking());
            }
            else
            {
                throw new NotImplementedException(GetType().ToString());
            }
            return customerEntities;
        }

        public Customer GetById(int id)
        {
            return _dbSet.FirstOrDefault(cust => cust.Id == id);
        }

        public void Update(Customer entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
