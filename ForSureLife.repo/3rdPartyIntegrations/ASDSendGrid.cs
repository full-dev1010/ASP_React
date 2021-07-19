using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.repo._3rdPartyIntegrations
{
    public class ASDSendGrid : IASDSendGrid
    {
        public IConfiguration Configuration { get; set; }
        public async void SendResumeEmail(Application application)
        {

            //   var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient("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");
            var url = string.Format("https://americanseniordirect.com/#/resume/landing?ChallengeCode={0}&email={1}&phone={2}", application.ChallengeCode, application.LeadInfo.Email, application.LeadInfo.Phone);
            var dynamic = new SendGridTemplateData()
            {
                BenefitAmount = string.Format("{0:C}", application.LeadInfo.SelectedBenefitAmount),
                MonthlyPremium = string.Format("{0:C}", application.LeadInfo.SelectedMonthlyRate),
                ResumeUrl = url
            };

            var templateId = "d-3630a5ab26cb47bc8b9ce196970f2cc9";
            var from = new EmailAddress("help@americanseniordirect.com", "Help");
            var subject = "Please click this email to verify your identity";
            var to = new EmailAddress(application.LeadInfo.Email, application.ApplicationInfo.FirstName + " " + application.ApplicationInfo.LastName);
            //  var plainTextContent = "https://www.americanseniordirect.com/#/resume/landing?ChallengeCode={0}&email={1}&phone={phone}";
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamic);
            var response = await client.SendEmailAsync(msg);

        }



    }
    public class SendGridTemplateData
    {
        public string BenefitAmount { get; set; }
        public string MonthlyPremium { get; set; }
        public string ResumeUrl { get; set; }
    }
}
