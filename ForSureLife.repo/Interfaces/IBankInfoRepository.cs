using ForSureLife.repo.Models.Quote;
using ForSureLife.repo.Models.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IBankInfoRepository
    {
        public Task<List<BankInfo>> GetBankName(string bankName);
        public Task<BankInfo> GetRoutingInfo(string routingNumber);
        public Task<List<BirthPlaces>> GetBirthPlaces(string name);
        public Task<List<Doctor>> GetDoctors(string name);
    }
}
