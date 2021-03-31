using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.Interfaces
{
    public interface IOrderInFactoryRepository 
    {
        public OrderInFactoryEntity GetById(int id);
        public void Add(OrderInFactoryEntity entity);
        public void AddRange(IEnumerable<OrderInFactoryEntity> entities);
        public void Delete(int id);       
    }
}
