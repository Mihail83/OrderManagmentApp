using OrderManagmentApp.BusinessLogic.Interfaces;
using OrderManagmentApp.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace OrderManagmentApp.BusinessLogic.Services
{
    public class AgreementService
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly IOrderAgreementRepository _orderAgreementRepository;
        private OrderAgreement tempOrderAgreement;

        public AgreementService(IAgreementRepository agreementRepository, IOrderAgreementRepository orderAgreementRepository)
        {
            _agreementRepository = agreementRepository;
            _orderAgreementRepository = orderAgreementRepository;
        }

        public IEnumerable<Agreement> GetAgreementToAgreementPage(IEnumerable<Expression<Func<Agreement, bool>>> expressions = null)
        {
            var orders = _agreementRepository.GetAllByExpression(expressions);
            return orders;
        }

        public void SaveAgreement(Agreement newAgreement)
        {            
            SetTempOrderAgreemenr(newAgreement);

            _agreementRepository.Add(newAgreement);
            


            if (tempOrderAgreement != null)
            {
                tempOrderAgreement.AgreementId = newAgreement.Id;
                if (_orderAgreementRepository. Get(tempOrderAgreement) == null)
                {
                    _orderAgreementRepository.Add(tempOrderAgreement);
                }                
            }
        }
        public void UpdateAgreement(Agreement newAgreement)
        {
            
            SetTempOrderAgreemenr(newAgreement);

            _agreementRepository.Update(newAgreement);

            if (tempOrderAgreement != null)
            {
                _orderAgreementRepository.Add(tempOrderAgreement);
            }
        }

        public Agreement GetAgreement(int id)
        {
            return _agreementRepository.GetById(id);
        }

        private void SetTempOrderAgreemenr(Agreement Agreement)
        {
            tempOrderAgreement = Agreement.OrderAgreement;
            Agreement.OrderAgreement = null;
        }
    }
}
