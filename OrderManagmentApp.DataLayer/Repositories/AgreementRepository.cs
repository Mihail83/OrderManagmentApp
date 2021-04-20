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
    public class AgreementRepository : IAgreementRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Agreement> _dbSet;

        public AgreementRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<Agreement>();

        }
        public void Add(Agreement entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new Agreement { Id = id });
            _dbContext.SaveChanges();
        }

        public IQueryable<Agreement> GetAllByExpression(IEnumerable<Expression<Func<Agreement, bool>>> expressions = null)
        {
            var agreementEntities = _dbSet.Include("Customer").Include("OrderAgreement").AsNoTracking();
            agreementEntities.UseExpresionsList(expressions);
            return agreementEntities;
        }

        public Agreement GetById(int id)
        {
            return _dbSet.Include("Customer").Include("OrderAgreement").FirstOrDefault(treaty => treaty.Id == id);
        }

        public void Update(Agreement entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
