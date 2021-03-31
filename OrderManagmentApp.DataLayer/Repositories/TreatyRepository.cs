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
    public class TreatyRepository : ITreatyRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<AgreementEntity> _dbSet;

        public TreatyRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<AgreementEntity>();

        }
        public void Add(AgreementEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new AgreementEntity { Id = id });
            _dbContext.SaveChanges();
        }     

        public IEnumerable<AgreementEntity> GetAllByExpression(IEnumerable<Expression<Func<AgreementEntity, bool>>> expressions = null)
        {
            var managerEntity = new List<AgreementEntity>();

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

        public AgreementEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(treaty => treaty.Id == id);
        }     

        public void Update(AgreementEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
