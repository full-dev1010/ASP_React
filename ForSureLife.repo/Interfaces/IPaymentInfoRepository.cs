using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IPaymentInfoRepository
    {
        Task<Guid> CreatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId);
        Task<PaymentInfo> GetPaymentInfo(Guid paymentInfoId, Guid applicationId);
        Task UpdatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId);
        Task DeletePaymentInfo(Guid paymentInfoId, Guid applicationId);
    }
}
