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
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<Order>();

        }

        public void Add(Order entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new Order { Id = id });
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllByExpression(IEnumerable<Expression<Func<Order, bool>>> expressions = null)
        {
            var managerEntity = new List<Order>();

            if (expressions == null)
            {
                managerEntity.AddRange(_dbSet.AsNoTracking());
            }
            else
            {
                throw new NotImplementedException(GetType().ToString());
            }
            return managerEntity;
        }
       

        public IEnumerable<Order> GetAllOrdersNoArchive(IEnumerable<Expression<Func<Order, bool>>> predicates = null)
        {
            if (predicates==null)
            {
                return _dbSet.Where(order => order.IsArchived == false)
                .Include(order => order.Customer)
                .Include(order => order.Manager)
                .Include(order => order.ShipmentDestination)
                .Include(order => order.ShipmentSpecialist)
                .Include(order => order.OrderInFactory)
                .Include(order => order.OrderAgreement)
                    .ThenInclude(ordAgr => ordAgr.Agreement)
                .AsNoTracking();
            }
            else
            {
                throw new NotImplementedException(GetType().ToString());
            }
        }

        public Order GetById(int id)
        {
            return _dbSet.FirstOrDefault(order => order.Id == id);
        }

        public void Update(Order entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
