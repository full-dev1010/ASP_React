using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ForSureLife.repo.Models.Enroll
{
    public class AAFinalExpense
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid AAFinalExpenseId { get; set; }
        public States ApplicationState { get; set; }
        public decimal SelectedBenefitAmount { get; set; }
        public decimal SelectedMonthlyRate { get; set; }
        public SeniorChoicePremiumType PremiumType { get; set; }
        public MailPolicy MailPolicyTo { get; set; }
        public DateTime EffectiveDate { get; set; }
        public InsuranceCompany InsuranceCompanyName { get; set; }
        public string LicenseNumber { get; set; }
        public bool Signed { get; set; }
        public DateTime SignedDate { get; set; }
        public string SignatureLocationCity { get; set; }
        public string SignatureLocationState { get; set; }
        public string ClientIPAddress { get; set; }
        public int FileNumber { get; set; }
        public int testChange { get; set; }
        public bool Submitted { get; set; }
        public List<AmAmApplicationAnswers> ApplicationAnswers { get; set; }
        public Application Application { get; set; }
    }
}
