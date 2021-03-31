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

        public IEnumerable<AgreementEntity> FindBy(Expression<Func<AgreementEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }

        public IEnumerable<AgreementEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
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
