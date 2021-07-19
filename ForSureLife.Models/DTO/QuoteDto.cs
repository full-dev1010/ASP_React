using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForSureLife.Models.DTO
{
    public class QuoteDto
    {
        public decimal SelectedBenefitAmount { get; set; }
        public decimal SelectedMonthlyRate { get; set; }
        public SeniorChoicePremiumType PremiumType { get; set; }
        public string PlanInfo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public List<RateDto> Rates { get; set; }
        public List<RateDto> SusaRates { get; set; }
        public List<RateDto> ForesterRates { get; set; }
        public List<RateDto> EagleRates { get; set; }
        //public List<RateDto> Company2Rates { get; set; }
        //public List<RateDto> Company3Rates { get; set; }


    }
}
