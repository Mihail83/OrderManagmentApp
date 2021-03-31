using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.DataLayer.Interfaces
{
    public interface IGenericCrudRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(int id);
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);        
    }
}
