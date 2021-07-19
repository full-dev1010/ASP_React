using ForSureLife.repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class PaymentInfoRepository : BaseRepository, IPaymentInfoRepository
    {
          public async Task<Guid> CreatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId)
        {
            using (var ctx = new ForSureLifeDBContext())
            {
                var application = GetApplicationFromDb(applicationId, ctx);
                application.PaymentInfo = paymentInfo;
                ctx.SaveChanges();

                return paymentInfo.PaymentId;
            }
        }

        public async Task DeletePaymentInfo(Guid paymentInfoId, Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentInfo> GetPaymentInfo(Guid paymentInfoId, Guid applicationId)
        {
            using (var ctx = new ForSureLifeDBContext())
            {
                var paymentInfo = ctx.Application.Where(x => x.ApplicationId == applicationId)
                       .Include(x => x.PaymentInfo).Where(x => x.PaymentInfo.PaymentId == paymentInfoId).Select(x => x.PaymentInfo).FirstOrDefault();
                return paymentInfo;
            }
        }

        public async Task UpdatePaymentInfo(PaymentInfo paymentInfo, Guid applicationId)
        {
            using (var ctx = new ForSureLifeDBContext())
            {            
                    ctx.Entry(paymentInfo).State = EntityState.Modified;
                    ctx.SaveChanges();
            }
        }
    }
}
