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
    class OrderInFactoryRepository : IOrderInFactoryRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<OrderInFactoryEntity> _dbSet;

        public OrderInFactoryRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<OrderInFactoryEntity>();

        }

        public OrderInFactoryEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(ord => ord.ID == id);

        }
        public void Add(OrderInFactoryEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<OrderInFactoryEntity> entities)
        {
            _dbSet.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new OrderInFactoryEntity { ID = id });
            _dbContext.SaveChanges();
        }
       

        
    }
}
