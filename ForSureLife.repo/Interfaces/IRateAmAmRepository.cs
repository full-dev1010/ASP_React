using ForSureLife.Models.Enums;
using ForSureLife.repo.Models.Rate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IRateAmAmRepository
    {
        Task<List<CarrierPlanRate>> GetRates();
        Task<CarrierPlanRate> GetRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age);
        Task<List<CarrierPlanRate>> GetSusaRates();
        Task<CarrierPlanRate> GetSusaRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age);
        Task<List<CarrierPlanRate>> GetForesterRates();
        Task<CarrierPlanRate> GetForesterRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age);
        Task<List<CarrierPlanRate>> GetEagleRates();
        Task<List<CarrierPlanRate>> GetEagleRates(Gender gender, SeniorChoicePremiumType premiumType, bool tobacco, int age);
    }
}