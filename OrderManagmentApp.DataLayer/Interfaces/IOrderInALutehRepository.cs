using System;
using System.Collections.Generic;
using System.Text;
using OrderManagmentApp.DataLayer.EntityModels;

namespace OrderManagmentApp.DataLayer.Interfaces
{
    public interface IOrderInALutehRepository 
    {
        public OrderInALutehEntity GetById(int id);
        public void Add(OrderInALutehEntity entity);
        public void AddRange(IEnumerable<OrderInALutehEntity> entities);
        public void Delete(int id);
        public void SaveChanges();
    }
}
