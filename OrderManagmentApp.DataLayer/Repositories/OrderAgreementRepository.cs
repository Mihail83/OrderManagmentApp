﻿using Microsoft.EntityFrameworkCore;
using OrderManagmentApp.DataLayer.EF;
using OrderManagmentApp.BusinessLogic.Models;
using OrderManagmentApp.BusinessLogic.Interfaces;
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

        public IEnumerable<OrderAgreement> GetAllByExpression(IEnumerable<Expression<Func<OrderAgreement, bool>>> expressions = null)
        {
            var entities = new List<OrderAgreement>();

            if (expressions == null)
            {
                entities.AddRange(_dbSet.Include("Agreement").AsNoTracking());
            }
            else
            {
                throw new NotImplementedException(GetType().ToString());
            }
            return entities;
        }

        public void Update(OrderAgreement entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        void IOrderAgreementRepository.Delete(OrderAgreement entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();           
        }
    }
}