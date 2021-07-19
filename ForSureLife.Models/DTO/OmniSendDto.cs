using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
    public class Email
    {
        public string status { get; set; }
        public string statusDate { get; set; }
    }

    public class Sms
    {
        public string status { get; set; }
        public string statusDate { get; set; }
    }

    public class Channels
    {

    }

    public class EmailChannels : Channels
    {
        public Email email { get; set; }

    }

    public class SMSChannels : Channels
    {
        public Sms sms { get; set; }
    }

    public class Identifier
    {
        public string type { get; set; }
        public string id { get; set; }
        public Channels channels { get; set; }
    }

    public class CustomProperties
    {
        public int Age { get; set; }
        public decimal SelectedBenefitAmount { get; set; }
        public decimal SelectedMonthlyRate { get; set; }
        public string PremiumType { get; set; }
        public string LeadFlow { get; set; }
        public string ProductType { get; set; }
        public string Beneficiary1 { get; set; }
        public string Beneficiary2 { get; set; }
        public string Beneficiary3 { get; set; }
        public decimal Revenue { get; set; }
        public Guid ApplicationId { get; set; }
    }

    public class OmniSendEventDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public CustomProperties Fields { get; set; }
    }

    public class OmniSendDto
    {
        public DateTime createdAt { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<string> tags { get; set; }
        public List<Identifier> identifiers { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string gender { get; set; }
        public string birthdate { get; set; }
        public CustomProperties customProperties { get; set; }
    }


    public class OmniSendResponse
    {
        public string email { get; set; }
        public string contactID { get; set; }
        public string firstName { get; set; }
        public string phone { get; set; }
    }
}
