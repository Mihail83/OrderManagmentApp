using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OrderManagmentApp.BusinessLogic.Interfaces
{
    public interface IGenericCrudRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAllByExpression(IEnumerable<Expression<Func<TEntity, bool>>> expressions = null);
        public TEntity GetById(int id);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
    }
}
