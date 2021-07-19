using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo.Models.Quote
{
    public class PlanQuote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid PlanQuoteId { get; set; }
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public string Carrier { get; set; }
        public PlanBenefit BenefitLevel { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}