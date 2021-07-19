using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Quote;
using ForSureLife.repo.Models.Rate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class BankInfoRepository : IBankInfoRepository
    {
        private readonly ForSureLifeDBContext ctx;
        public BankInfoRepository(ForSureLifeDBContext _ctx)
        {
            ctx = _ctx;
        }
  
        public async Task<List<BankInfo>> GetBankName(string bankName)
        {
            var bankInfos =  ctx.BankInfo.Where(x => x.BankName.Contains(bankName)).Take(20).ToList();
            return bankInfos;
        }

        public async Task<List<BirthPlaces>> GetBirthPlaces(string birthPlace)
        {
            var birthPlaces = ctx.BirthPlaces.Where(x => x.Name.Contains(birthPlace)).OrderBy(x => x.Name).Take(20).ToList();
            return birthPlaces;
        }

        public async Task<List<Doctor>> GetDoctors(string name)
        {
            var doctors = ctx.Doctors.Where(x => x.DoctorName.Contains(name)).OrderBy(x => x.DoctorName).Take(20).ToList();
            return doctors;
        }

        public async Task<BankInfo> GetRoutingInfo(string routingNumber)
        {
            var routingSearchNumber = routingNumber;
            if(routingNumber.Substring(0,1) == "0")
            {
                routingSearchNumber = routingNumber.Remove(0, 1);
            }
            var bankInfo = ctx.BankInfo.Where(x => x.RoutingNumber.Contains(routingSearchNumber)).FirstOrDefault();
            return bankInfo;
        }
    }
}
