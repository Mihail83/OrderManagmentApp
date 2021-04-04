using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;

namespace OrderManagmentApp.BusinessLogic.Interfaces
{
    public interface IOrderInFactoryRepository
    {
        public OrderInFactory GetById(int id);
        public void Add(OrderInFactory entity);
        public void AddRange(IEnumerable<OrderInFactory> entities);
        public void Delete(int id);
    }
}
