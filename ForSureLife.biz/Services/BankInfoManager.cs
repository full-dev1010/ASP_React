using ForSureLife.biz.Interfaces;
using ForSureLife.repo;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Quote;
using ForSureLife.repo.Models.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class BankInfoManager : IBankInfoManager
    {
        private readonly IBankInfoRepository _bankInfoRepo;
        public BankInfoManager(IBankInfoRepository bankInfoRepo)
        {
            _bankInfoRepo = bankInfoRepo;
        }
        public async Task<BankInfo> GetRoutingInfo(string routingNumber)
        {
            return await _bankInfoRepo.GetRoutingInfo(routingNumber);
          
        }

        public async Task<List<BankInfo>> GetBankName(string bankName)
        {
            return await _bankInfoRepo.GetBankName(bankName);
        }

        public async Task<List<Doctor>> GetDoctors(string name)
        {
            return await _bankInfoRepo.GetDoctors(name);
        }
    }
}
