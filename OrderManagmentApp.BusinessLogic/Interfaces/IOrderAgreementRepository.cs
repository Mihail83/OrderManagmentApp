using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using OrderManagmentApp.BusinessLogic.Models;

namespace OrderManagmentApp.BusinessLogic.Interfaces
{
    public interface IOrderAgreementRepository 
    {
        public IEnumerable<OrderAgreement> GetAllByExpression(IEnumerable<Expression<Func<OrderAgreement, bool>>> expressions = null);
        public void Add(OrderAgreement entity);
        public void Update(OrderAgreement entity);
        public void Delete(OrderAgreement entity);
        public OrderAgreement Get(OrderAgreement entity);
    }
}
