using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OrderManagmentApp.DataLayer.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //create
        public void Add(TEntity entity);
        //reade        
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);       
        public IEnumerable<TEntity> GetAll();
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        //update
        public void Update(TEntity entity);

        //delete 
        public void Delete(TEntity entity);

        //context
        public void SaveChanges();
        public Task SaveChangesAsync();
        



    }
}
