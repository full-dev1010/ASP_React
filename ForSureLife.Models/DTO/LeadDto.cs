using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForSureLife.Models.DTO
{
    public class LeadDTO
    {
        public Guid LeadId { get; set; }
        public string LeadSource { get; set; }
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
        public string County { get; set; }
        public Relationship DesiredBeneficiary { get; set; }
        public DateTime DOB { get; set; }
        public bool CurrentCoverage { get; set; }
        public decimal DesiredCoverageAmount { get; set; }
        public decimal OriginalDesiredCoverageAmount { get; set; }
        public string Hobby { get; set; }
        public Gender Gender { get; set; }
        public string ExternalLeadId { get; set; }
        public bool IsEligible { get; set; }
        public bool HealthQuestionsAnswered { get; set; }
        public bool ClickedApplied { get; set; }
        public bool ClickedEnrolled { get; set; }
        public bool ContactAgent { get; set; }
        public bool KnockedOut { get; set; }
        public bool BeneficiarySet { get; set; }
        public bool LeadCompleted { get; set; }
        public bool QuoteReceived { get; set; }
        public bool PaymentDateSet { get; set; }
        public bool PaymentAccountSet { get; set; }
        public bool SocialSet { get; set; }
        public bool ReviewPageSeen { get; set; }
        public bool ReviewPageSubmit { get; set; }
        public bool SecondQuoteReceived { get; set; }
        public decimal SelectedBenefitAmount { get; set; }
        public decimal SelectedMonthlyRate { get; set; }
        public SeniorChoicePremiumType PremiumType { get; set; }
        public List<LeadHealthQuestionDto> HealthQuestions { get; set; }
    }
}
