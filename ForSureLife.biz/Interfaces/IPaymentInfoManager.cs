using ForSureLife.repo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface IPaymentInfoManager
    {
        Task<Guid> CreatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId);
        Task<PaymentInfo> GetPaymentInfo(Guid paymentInfoId, Guid applicationId);
        Task UpdatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId);
        Task DeletePaymentInfo(Guid paymentInfoId, Guid applicationId);
    }
}
