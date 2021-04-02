﻿using System;
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
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new OrderEntity { Id=id });
            _dbContext.SaveChanges();
        }       

        public IEnumerable<OrderEntity> GetAllByExpression(IEnumerable<Expression<Func<OrderEntity, bool>>> expressions = null)
        {
            var managerEntity = new List<OrderEntity>();

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
        public IEnumerable<OrderEntity> GetAllOrdersNoArchive()
        {
            return _dbSet.Where(order=>order.IsArchived==false)
                .Include(order => order.Customer)
                .Include(order => order.Manager)
                .Include(order => order.ShipmentDestination)
                .Include(order => order.ShipmentSpecialist)
                .Include(order => order.OrderInFactory)
                .AsNoTracking();
        }

        public OrderEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(order=>order.Id==id);
        }     

        public void Update(OrderEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}