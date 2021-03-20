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
        private readonly DbSet<TreatyEntity> _dbSet;

        public TreatyRepository(OrderManagmentAppContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TreatyEntity>();

        }
        public void Add(TreatyEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(new TreatyEntity { Id = id });
        }

        public IEnumerable<TreatyEntity> FindBy(Expression<Func<TreatyEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }

        public IEnumerable<TreatyEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public TreatyEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(treaty => treaty.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(TreatyEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
