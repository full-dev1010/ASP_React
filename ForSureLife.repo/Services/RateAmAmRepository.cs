using ForSureLife.Models.Enums;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Rate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class RateAmAmRepository : IRateAmAmRepository
    {
        private readonly ForSureLifeDBContext ctx;
        public RateAmAmRepository(ForSureLifeDBContext _ctx)
        {
            ctx = _ctx;
        }
        public async Task<List<CarrierPlanRate>> GetRates()
        {
           
                return ctx.CarrierPlanRate.Where(x=> x.Company == InsuranceCompanyRate.AmAm).ToList();
           
        }

        public async Task<CarrierPlanRate> GetRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age)
        {
           
                return ctx.CarrierPlanRate.Where(x => x.Gender == gender && x.PremiumType == premiumType && x.Tobacoo == tobacco && x.Age == age && x.Company == InsuranceCompanyRate.AmAm).FirstOrDefault();
          
        }

        public async Task<List<CarrierPlanRate>> GetSusaRates()
        {

            return ctx.CarrierPlanRate.Where(x => x.Company == InsuranceCompanyRate.Susa).ToList();

        }

        public async Task<CarrierPlanRate> GetSusaRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age)
        {

            return ctx.CarrierPlanRate.Where(x => x.Gender == gender && x.PremiumType == premiumType && x.Tobacoo == tobacco && x.Age == age && x.Company == InsuranceCompanyRate.Susa).FirstOrDefault();

        }

        public async Task<List<CarrierPlanRate>> GetForesterRates()
        {

            return ctx.CarrierPlanRate.Where(x => x.Company == InsuranceCompanyRate.Foresters).ToList();

        }

        public async Task<CarrierPlanRate> GetForesterRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age)
        {

            return ctx.CarrierPlanRate.Where(x => x.Gender == gender && x.PremiumType == premiumType && x.Tobacoo == tobacco && x.Age == age && x.Company == InsuranceCompanyRate.Foresters).FirstOrDefault();

        }

        public async Task<List<CarrierPlanRate>> GetEagleRates()
        {

            return ctx.CarrierPlanRate.Where(x => x.Company == InsuranceCompanyRate.Eagle).ToList();

        }

        public async Task<List<CarrierPlanRate>> GetEagleRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age)
        {

            return ctx.CarrierPlanRate.Where(x => x.Gender == gender && x.PremiumType == premiumType && x.Tobacoo == tobacco && x.Age == age && x.Company == InsuranceCompanyRate.Eagle).OrderBy(x => x.BenefitAmount).ToList();

        }
    }
}
