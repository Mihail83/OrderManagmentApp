using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrderManagmentApp.DataLayer.Repositories
{
    public class OrderAgreementRepository : IOrderAgreementRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<OrderAgreement> _dbSet;

        public OrderAgreementRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<OrderAgreement>();

        }
        public void Add(OrderAgreement entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public OrderAgreement Get(int orderId)
        {            
            return _dbSet.FirstOrDefault(item => item.OrderId == orderId);
        }

        public IQueryable<OrderAgreement> GetAllByExpression(IEnumerable<Expression<Func<OrderAgreement, bool>>> expressions = null)
        {
            var entities = _dbSet.Include("Agreement").AsNoTracking();
            entities.UseExpresionsList(expressions);
            return entities;
        }

        public void Update(OrderAgreement entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int orderId)
        {
            var entity = Get(orderId);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();

            }
                       
        }
    }
}
