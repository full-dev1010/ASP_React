using ForSureLife.biz.Interfaces;
using ForSureLife.repo;
using ForSureLife.repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class PaymentInfoManager : IPaymentInfoManager
    {
        public IPaymentInfoRepository _paymentInfoRepo {get; set;} 
        public PaymentInfoManager(IPaymentInfoRepository paymentInfoRepo)
        {
            _paymentInfoRepo = paymentInfoRepo;
        }

        public async Task<Guid> CreatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId)
        {
            return await _paymentInfoRepo.CreatePaymentInfo(paymentInfo, applicationId);
        }

        public async Task DeletePaymentInfo(Guid paymentInfoId, Guid applicationId)
        {
           await _paymentInfoRepo.DeletePaymentInfo(paymentInfoId, applicationId);
        }

        public async Task<PaymentInfo> GetPaymentInfo(Guid paymentInfoId, Guid applicationId)
        {
            return await _paymentInfoRepo.GetPaymentInfo(paymentInfoId, applicationId);
        }

        public async Task UpdatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId)
        {
            await _paymentInfoRepo.UpdatePaymentInfo(paymentInfo, applicationId);
        }
    }
}
