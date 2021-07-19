using ForSureLife.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo
{
    public class PaymentInfo
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid PaymentId { get; set; }
		public PaymentType PaymentType { get; set; }
		public string CreditCardRef { get; set; }
		public string BankingInsitution { get; set; }
		public string BankAddress { get; set; }
		public string AccountNumber { get; set; }
		public string RoutingNumber { get; set; }
		public AccountType BankType { get; set; }
		public int PaymentWithdrawlDate { get; set; }
		public SSDDate SocialSecurityWithdrawDate { get; set; }
	}
}