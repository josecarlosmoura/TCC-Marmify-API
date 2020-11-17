using Marmify.Domain.Entities;
using Marmify.Domain.Interfaces.Repositories;
using Marmify.Domain.Interfaces.Services;
using Marmify.Domain.Services.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Domain.Services.Entities
{
    public class PaymentConditionService : MarmifyServiceBase<PaymentCondition>, IPaymentConditionService
    {
        private readonly IPaymentConditionRepository _paymentConditionRepository;

        public PaymentConditionService(IPaymentConditionRepository paymentConditionRepository) 
            : base(paymentConditionRepository)
        {
            _paymentConditionRepository = paymentConditionRepository;
        }
    }
}
