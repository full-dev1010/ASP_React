using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.repo.Models.Rate
{
    public class CarrierPlan
    {
        public Guid CarrierPlanId { get; set; }
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public string Carrier { get; set; }
        public string Language { get; set; }
        public CarrierPlanDetails PlanDetails { get; set; }
        public CarrierPlanBenefit BenefitAmount { get; set; }
        public DateTime CreatedDate { get
            {
                return CreatedDate;
            }
                set
            {
                CreatedDate = DateTime.Now;
            }
        }
    }
}
