using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo
{
    public class PlanBenefit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid PlanBenefitId { get; set; }
        public string BenefitName { get; set; }
        public string BenefitAmount { get; set; }
    }
}