using ForSureLife.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo.Models.Rate
{
    public class CarrierPlanRate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid CarrierPlanRateId { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public bool Tobacoo { get; set; }
        public SeniorChoicePremiumType PremiumType { get; set; }
        public InsuranceCompanyRate Company { get; set; }
        public decimal AnnualRate { get; set; }
        public decimal BenefitAmount { get; set; }
    }
}