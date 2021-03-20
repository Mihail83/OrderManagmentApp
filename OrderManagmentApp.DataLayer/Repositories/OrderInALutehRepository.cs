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
    class OrderInALutehRepository : IOrderInALutehRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<OrderInALutehEntity> _dbSet;

        public OrderInALutehRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<OrderInALutehEntity>();

        }

        public OrderInALutehEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(ord => ord.ID == id);

        }
        public void Add(OrderInALutehEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<OrderInALutehEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new OrderInALutehEntity { ID = id });
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
