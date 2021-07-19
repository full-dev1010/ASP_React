using System;

namespace ForSureLife.repo.Models.Rate
{
    public class CarrierPlanBenefit
    {
        public Guid CarrierPlanBenefitId { get; set; }
        public string BenefitName { get; set; }
        public string BenefitAmount { get; set; }
    }
}