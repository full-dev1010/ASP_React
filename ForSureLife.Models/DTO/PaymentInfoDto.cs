using ForSureLife.Models.Enums;
using System;

namespace ForSureLife.Models.DTO
{
    public class PaymentInfoDto
    {
        public Guid PaymentId { get; set; }
        public string BankingInsitution { get; set; }
        public PaymentType PaymentType { get; set; }
        public string CreditCardRef { get; set; }
        public string BankAddress { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public AccountType BankType { get; set; }
        public int PaymentWithdrawlDate { get; set; }
        public SSDDate SocialSecurityWithdrawDate { get; set; }
    }
}