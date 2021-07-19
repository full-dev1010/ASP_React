using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo.Models.Quote
{
    public class Plan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid PlanId { get; set; }
        public string PlanName { get; set; }
        public string Carrier { get; set; }
        public PlanDetails PlanDetails { get; set; }
        public PlanBenefit BenefitAmount { get; set; }
        public bool Selected { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
