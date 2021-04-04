using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagmentApp.DataLayer.Repositories
{
    class OrderInFactoryRepository : IOrderInFactoryRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<OrderInFactory> _dbSet;

        public OrderInFactoryRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<OrderInFactory>();

        }

        public OrderInFactory GetById(int id)
        {
            return _dbSet.FirstOrDefault(ord => ord.ID == id);

        }
        public void Add(OrderInFactory entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<OrderInFactory> entities)
        {
            _dbSet.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new OrderInFactory { ID = id });
            _dbContext.SaveChanges();
        }



    }
}
