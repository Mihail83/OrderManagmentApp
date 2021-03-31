using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.Interfaces;
using OrderManagmentApp.DataLayer.EntityModels;
using System.Linq.Expressions;


namespace OrderManagmentApp.DataLayer.Interfaces
{
    public interface IGenericAdvancedRepository<TEntity> : IGenericCrudRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);    //основа для фильтрации???
    }
}
