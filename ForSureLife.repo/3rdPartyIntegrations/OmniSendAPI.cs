using ForSureLife.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ForSureLife.repo._3rdPartyIntegrations
{
    public class OmniSendAPI : IOmniSendAPI
    {
        private string APIKey = "60676f274c7fa45454333eb2-sy9s3fr0PlTW68S8f15jG5bRea2R2QYaI8llMGSH6rdru9ox4r";
        private string eventSignedId = "60c7751372a40100191f6f1e";
        private string eventQuoteId = "60c774b772a40100191f6f1d";
        private string emailId = "60c7746872a40100191f6f1c";
        private string eventSecondQuoteId = "60c774c4fbedd800180ec01e";
        private string url = "https://api.omnisend.com/v3/contacts";
        private string urlCreate = "https://api.omnisend.com/v3/contacts/";
        private string urlEvent = "https://api.omnisend.com/v3/events/";
        public bool SendToOmniSend(Application application)
        {
            if (application.LeadInfo.Email != null && application.LeadInfo.Email != string.Empty)
            {
                var createUrl = urlCreate + application.OmniSendContactId;
                // var url  = "https://dev-leads-api.integritymarketing.com/ffl/gametime/lead";
                // var APIKey = "c6aaa51f8e1b433e99261e62bf44de39";
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(ConvertToOmniSend(application)), Encoding.UTF8, "application/json");
                        content.Headers.Add("X-API-KEY", APIKey);
                        var response = application.OmniSendContactId != null && application.OmniSendContactId != string.Empty ? httpClient.PatchAsync(createUrl, content) : httpClient.PostAsync(url, content);

                        var test = response.Result.ToString();
                        application.OmniSendContactId = JsonConvert.DeserializeObject<OmniSendResponse>(response.Result.Content.ReadAsStringAsync().Result.ToString()).contactID;
                        response.Result.EnsureSuccessStatusCode();


                        return true;
                    }
                      SendEvents(application);
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            return true;
        }

        public bool SendEvents(Application application)
        {
            if (application.LeadInfo.Email != null && application.LeadInfo.Email != string.Empty)
            {
                var eventId = emailId;
                if (application.Signed)
                {
                    eventId = eventSignedId;
                }
                else if (application.LeadInfo.SecondQuoteReceived)
                {
                    eventId = eventSecondQuoteId;
                }
                else if (application.LeadInfo.QuoteReceived)
                {
                    eventId = eventQuoteId;
                }

                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(ConvertToOmniSendEvent(application)), Encoding.UTF8, "application/json");
                        content.Headers.Add("X-API-KEY", APIKey);
                        var response = httpClient.PostAsync(urlEvent + eventId, content);

                        var test = response.Result.ToString();
                        // application.OmniSendContactId = JsonConvert.DeserializeObject<OmniSendResponse>(response.Result.Content.ReadAsStringAsync().Result.ToString()).contactID;
                        response.Result.EnsureSuccessStatusCode();


                        return true;
                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            return true;
        }

        private OmniSendEventDto ConvertToOmniSendEvent(Application application)
        {
            var omniSendEvent = new OmniSendEventDto();

            omniSendEvent.Email = application.LeadInfo.Email;
            omniSendEvent.Phone = application.LeadInfo.Phone;

            omniSendEvent.Fields = SetCustomProperties(application);
            return omniSendEvent;
        }


        private OmniSendDto ConvertToOmniSend(Application application)
        {
            var omniSendDto = new OmniSendDto();
            omniSendDto.createdAt = DateTime.Now;
            omniSendDto.firstName = application.LeadInfo.FirstName;
            omniSendDto.lastName = application.LeadInfo.LastName;
            omniSendDto.tags = AddTags(application);
            omniSendDto.identifiers = SetIdentifiers(application);
            omniSendDto.state = application.LeadInfo.State;
            omniSendDto.city = application.LeadInfo.City;
            omniSendDto.address = application.LeadInfo.Address1;
            omniSendDto.postalCode = application.LeadInfo.ZipCode;
            omniSendDto.gender = application.LeadInfo.Gender == 0 ? "m" : "f";
            omniSendDto.birthdate = application.ApplicationInfo.DOB.ToString("yyyy-MM-dd");
            omniSendDto.customProperties = SetCustomProperties(application);

            return omniSendDto;
        }

        private List<string> AddTags(Application application)
        {
            var tags = new List<string>();

            if (application.LeadInfo.IsEligible) { tags.Add("KnockoutCompleted"); }
            if (application.LeadInfo.HealthQuestionsAnswered) { tags.Add("HealthCompleted"); }
            if (application.LeadInfo.ClickedApplied) { tags.Add("ClickedApplied"); }
            if (application.LeadInfo.ClickedEnrolled) { tags.Add("ClickedEnroll"); }
            if (application.LeadInfo.ContactAgent) { tags.Add("ContactAgent"); }
            if (application.LeadInfo.KnockedOut) { tags.Add("KnockedOut"); }
            if (application.LeadInfo.BeneficiarySet) { tags.Add("BeneficiariesCompleted"); }
            if (application.LeadInfo.QuoteReceived) { tags.Add("QuoteReceived"); }
            if (application.LeadInfo.PaymentDateSet) { tags.Add("PaymentDateCompleted"); }
            if (application.LeadInfo.PaymentAccountSet) { tags.Add("PaymentInfoCompleted"); }
            if (application.LeadInfo.SocialSet) { tags.Add("SocialSecurityCompleted"); }
            if (application.LeadInfo.ReviewPageSeen) { tags.Add("ReviewPageSeen"); }
            if (application.LeadInfo.ReviewPageSubmit) { tags.Add("SubmittedCompleted"); }
            if (application.LeadInfo.SecondQuoteReceived) { tags.Add("SecondQuoteReceived"); }

            return tags;
        }

        private List<Identifier> SetIdentifiers(Application application)
        {
            var identifiers = new List<Identifier>();

            var identifier = new Identifier();
            identifier.type = "email";
            identifier.id = application.LeadInfo.Email;
            identifier.channels = SetEmailChannels(application);
            identifiers.Add(identifier);

            var identifierSMS = new Identifier();
            identifierSMS.type = "phone";
            identifierSMS.id = application.LeadInfo.Phone;
            identifierSMS.channels = SetSMSChannels(application);
            identifiers.Add(identifierSMS);

            return identifiers;
        }


        private EmailChannels SetEmailChannels(Application application)
        {
            var channels = new EmailChannels();
            channels.email = SetEmailChannel(application);
            return channels;
        }

        private SMSChannels SetSMSChannels(Application application)
        {
            var channels = new SMSChannels();
            channels.sms = SetSMSChannel(application);
            return channels;
        }

        private Email SetEmailChannel(Application application)
        {
            var email = new Email();
            email.status = "subscribed";
            email.statusDate = application.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return email;
        }

        private Sms SetSMSChannel(Application application)
        {
            var sms = new Sms();
            sms.status = "nonSubscribed";
            sms.statusDate = application.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return sms;
        }




        private CustomProperties SetCustomProperties(Application application)
        {
            var customProperties = new CustomProperties();

            customProperties.ApplicationId = application.ApplicationId;

            customProperties.SelectedBenefitAmount = application.LeadInfo.SelectedBenefitAmount;
            customProperties.SelectedMonthlyRate = application.LeadInfo.SelectedMonthlyRate;

            var premiumType = "Immediate";
            if (application.LeadInfo.PremiumType == ForSureLife.Models.Enums.SeniorChoicePremiumType.Graded)
            {
                premiumType = "Graded";
            }
            else if (application.LeadInfo.PremiumType == ForSureLife.Models.Enums.SeniorChoicePremiumType.Premium)
            {
                premiumType = "Modified";
            }
            customProperties.PremiumType = premiumType;
            customProperties.LeadFlow = application.LeadInfo.LeadSource;
            customProperties.ProductType = "FinalExpense";

            var age = DateTime.Today.Year - application.ApplicationInfo.DOB.Year;
            if (application.ApplicationInfo.DOB > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            if (application.Beneficiaries != null && application.Beneficiaries.Count > 0)
            {

                customProperties.Beneficiary1 = application.Beneficiaries[0].PersonalInfo.FirstName;


                if (application.Beneficiaries.Count > 1)
                {
                    customProperties.Beneficiary2 = application.Beneficiaries[1].PersonalInfo.FirstName;
                }
                if (application.Beneficiaries.Count > 2)
                {
                    customProperties.Beneficiary3 = application.Beneficiaries[2].PersonalInfo.FirstName;
                }
            }
            customProperties.Age = age;

            return customProperties;
        }
    }
}
