using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;

namespace OrderManagmentApp.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<CustomerEntity> _dbSet;

        public CustomerRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<CustomerEntity>();

        }
        public void Add(CustomerEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new CustomerEntity { Id=id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<CustomerEntity> FindBy(Expression<Func<CustomerEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public CustomerEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault( cust=>cust.Id==id );
        }        

        public void Update(CustomerEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
