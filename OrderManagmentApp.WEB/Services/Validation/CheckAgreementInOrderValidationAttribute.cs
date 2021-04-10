using OrderManagmentApp.WEB.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OrderManagmentApp.WEB.Services.Validation
{
    public class CheckAgreementInOrderValidationAttribute : ValidationAttribute
    {
        public CheckAgreementInOrderValidationAttribute()
        {
            ErrorMessage = "ВВедите cумму договора и товар ИЛИ укажите договор";
        }

        public override bool IsValid(object value)
        {
            if (!(value is OrderViewModel orderViewModel))
            {
                return true;
            }
            else
            {
                if (orderViewModel.CurrentAgreementId != null ||
                    (orderViewModel.ContractSum != null && !string.IsNullOrWhiteSpace(orderViewModel.Good)))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
