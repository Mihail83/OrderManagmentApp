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
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<OrderEntity> _dbSet;

        public OrderRepository(OrderManagmentAppContext context )
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<OrderEntity>();

        }

        public void Add(OrderEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new OrderEntity { ID=id });
        }

        public IEnumerable<OrderEntity> FindBy(Expression<Func<OrderEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }
        public IEnumerable<OrderEntity> GetAllOrdersNoArchive()
        {
            return _dbSet.Where(order=>order.IsArchive==false)
                .Include(order=>order.Customer)
                .Include(order => order.Manager)
                .Include(order => order.ShipmentDestination)
                .Include(order => order.ShipmentSpecialist)
                .Include(order => order.OrderInALuteh).AsNoTracking();
        }

        public OrderEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(order=>order.ID==id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(OrderEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
