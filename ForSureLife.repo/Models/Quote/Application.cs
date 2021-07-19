using ForSureLife.repo.Models.Quote;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ForSureLife.repo
{
    public class Application
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ApplicationId { get; set; }

        public Lead LeadInfo { get; set; }
        public List<HealthQuestion> HealthQuestions { get; set; }
        public List<Quote> SelectedQuotes { get; set; }
        public List<FamilyOrBeneficiary> Beneficiaries { get; set; }
        public List<FamilyOrBeneficiary> ContingentBeneficiaries { get; set; }
        public Designee Designee { get; set; }
        public ApplicationInfo ApplicationInfo { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public string Language { get; set; }
        public bool Signed { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
        public bool LeadCaputred { get; set; }
        public bool ImmediateLeadCaptured { get; set; }
        public bool SentToIntegrity { get; set; }
        public bool ImmediateLeadEmailed { get; set; }
        public bool QuoteLeadEmailed { get; set; }
        public string OmniSendContactId { get; set; }
        public bool SaleCaputured { get; set; }
        public bool ImmediateLeadSendToIntegrity { get; set; }
        public string ChallengeCode { get; set; }
     
        public DateTime ExpirationDate { get; set; }
    }
}
