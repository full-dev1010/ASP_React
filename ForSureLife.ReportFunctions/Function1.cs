using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ForSureLife.repo;
//using ForSureLife.Models.DTO;
using ForSureLife.repo.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using ForSureLife.Models.Enums;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs;
using ForSureLife.repo.Models.Quote;
using ForSureLife.repo._3rdPartyIntegrations;
using Microsoft.EntityFrameworkCore.Query;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ForSureLife.ReportFunctions
{
    public class Function1
    {
        private string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private string ApplicationName = "Google Sheets API .NET Quickstart";

        private IAmAmApplicationRepository _amAmRepo { get; set; }
        private IOmniSendAPI _omniSend { get; set; }
        private readonly ForSureLifeDBContext ctx;
        public Function1(IAmAmApplicationRepository amAmRepo, IOmniSendAPI omniSend, ForSureLifeDBContext _ctx)
        {
            _amAmRepo = amAmRepo;
            _omniSend = omniSend;
            ctx = _ctx;
        }

        [Function("Function1")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ReportFunctions")] HttpRequestData req,
            string name,
            FunctionContext context)
        {
            ProcessLeadsAndSales();
            //ImportExistingDataIntoOmniSend();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            var exceptionMessage = string.Empty;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(responseMessage);
            return response;
        }

        public void ResentLeads()
        {
            try
            {

                var rejectedLeads = "LeadFailures!A:E";
                var spreadsheetId = "1LjTq9YD0okww2hdcxNEEHVZ3fZ6h5RUg8z_nN4Mqy8U";
                var service = SendToGoogleSheet();
                var leadDTOs = new List<LeadSpreadSheetDto>();
                var leadFailureDTOs = new List<LeadSpreadSheetDto>();
                var completedLeads = ctx.Application.Where(x => x.LeadCaputred == true
                                                            && x.SentToIntegrity == false
                                                            && x.ApplicationInfo.FirstName != null
                                                            && x.ApplicationInfo.FirstName != string.Empty
                                                            && x.UpdateDate > DateTime.Now.AddDays(-30)
                                                            && !x.ApplicationInfo.FirstName.ToLower().Contains("test")
                                                            && !x.ApplicationInfo.FirstName.ToLower().Contains("andrew")
                                                            && !x.ApplicationInfo.FirstName.ToLower().Contains("craig")
                                                            && !x.ApplicationInfo.FirstName.ToLower().Contains("omar")
                                                            && x.LeadInfo.Address1 != string.Empty)
                                                                            .Include(e => e.ApplicationInfo)
                                                                            .Include(e => e.LeadInfo)
                                                                            .Include(e => e.PaymentInfo);

                foreach (var leads in completedLeads)
                {
                    var lead = ConvertSheet(leads);


                    if (!lead.FirstName.ToLower().Contains("test"))
                    {
                        lead.SentToIntegrity = SendLeadsToNationalBuyer(lead);

                    }
                    if (lead.SentToIntegrity == false)
                    {
                        leadFailureDTOs.Add(lead);

                    }
                    leads.SentToIntegrity = lead.SentToIntegrity;
                    leads.LeadCaputred = true;
                }

                if (leadFailureDTOs.Any())
                {
                    UpdatGoogleSheetinBatch(SetGoogleObject(leadFailureDTOs), spreadsheetId, rejectedLeads, service);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }



        public void ProcessLeadsAndSales()
        {
            try
            {

                //   ResentLeads();
                var completedSales = ctx.AmAmFinalExpense.Where(x => x.Signed == true && (x.Application.LeadCaputred == false))
                .Include(e => e.Application)
                   .ThenInclude(e => e.ApplicationInfo)
                .Include(e => e.Application)
                   .ThenInclude(e => e.LeadInfo)
                .Include(e => e.Application)
                   .ThenInclude(e => e.HealthQuestions);

                var spreadsheetId = "1LjTq9YD0okww2hdcxNEEHVZ3fZ6h5RUg8z_nN4Mqy8U";
                var rangeSales = "Sales!A:E";
                var rangeLeads = "Leads!A:E";
                var ImmediateLeads = "ImmediateLeads!A:E";
                var rejectedLeads = "LeadFailures!A:E";
                var rangeSoldLeads = "SoldLeads!A:E";
                var service = SendToGoogleSheet();
                var leadDTOs = new List<LeadSpreadSheetDto>();

                try
                {
                    if (completedSales.Any())
                    {
                        foreach (var sales in completedSales)
                        {
                            leadDTOs.Add(ConvertSheet(sales.Application));
                            sales.Application.LeadCaputred = true;
                            sales.Application.ImmediateLeadCaptured = true;
                            sales.Application.Language = string.Empty;
                        }
                    }

                    if (leadDTOs.Any())
                    {
                        UpdatGoogleSheetinBatch(SetGoogleObject(leadDTOs), spreadsheetId, rangeSales, service);
                    }

                    ctx.SaveChanges();

                }
                catch (Exception ex)
                {
                  //  throw new Exception("Error in processing lead info", ex);
                }

                var threshold = DateTime.UtcNow.AddHours(-1);
              
                    var completedLeads = ctx.Application.Where(x => x.LeadCaputred == false && x.ApplicationInfo.FirstName != null && x.ApplicationInfo.FirstName != string.Empty
                     && x.UpdateDate <= threshold
                     && !x.ApplicationInfo.FirstName.ToLower().Contains("test")
                     && !x.LeadInfo.SecondQuoteReceived)
                          .Include(e => e.ApplicationInfo)
                          .Include(e => e.LeadInfo)
                          .Include(e => e.PaymentInfo).ToList();

                    SendLeads(spreadsheetId, rangeLeads, rejectedLeads, service, completedLeads, true, false);

                    ctx.SaveChanges();


                     var gradedModifiedLeads = ctx.Application.Where(x => x.ImmediateLeadCaptured == false && x.LeadCaputred == false && x.ApplicationInfo.FirstName != null && x.ApplicationInfo.FirstName != string.Empty
                        && x.UpdateDate <= threshold
                        && !x.ApplicationInfo.FirstName.ToLower().Contains("test")
                        && x.LeadInfo.PremiumType != SeniorChoicePremiumType.Immediate
                        && x.LeadInfo.SecondQuoteReceived)
                    .Include(e => e.ApplicationInfo)
                    .Include(e => e.LeadInfo)
                    .Include(e => e.PaymentInfo).ToList();

                    SendLeads(spreadsheetId, rangeLeads, rejectedLeads, service, gradedModifiedLeads, true, true);

                    ctx.SaveChanges();



                    var immediateLeads = ctx.Application.Where(x => x.ImmediateLeadCaptured == false && x.ApplicationInfo.FirstName != null && x.ApplicationInfo.FirstName != string.Empty
                        && x.UpdateDate <= threshold
                        && !x.ApplicationInfo.FirstName.ToLower().Contains("test")
                        && x.LeadInfo.PremiumType == SeniorChoicePremiumType.Immediate
                        && x.LeadInfo.SecondQuoteReceived)
                    .Include(e => e.ApplicationInfo)
                    .Include(e => e.LeadInfo)
                    .Include(e => e.PaymentInfo).ToList();

                    SendLeads(spreadsheetId, ImmediateLeads, rejectedLeads, service, immediateLeads, false, true);

                    ctx.SaveChanges();

         
                var immediateThreshold = DateTime.UtcNow.AddHours(-72);

                var sendImmediateLeadsToIntegrity = ctx.Application.Where(x => x.ImmediateLeadCaptured == true && x.Language == null && x.LeadInfo.SecondQuoteReceived && x.ApplicationInfo.FirstName != null && x.ApplicationInfo.FirstName != string.Empty
                   && x.UpdateDate <= immediateThreshold
                   && !x.ApplicationInfo.FirstName.ToLower().Contains("test")
                   && x.LeadInfo.PremiumType == SeniorChoicePremiumType.Immediate)
                .Include(e => e.ApplicationInfo)
                .Include(e => e.LeadInfo)
                .Include(e => e.PaymentInfo).ToList();

                SendLeads(spreadsheetId, rangeLeads, rejectedLeads, service, sendImmediateLeadsToIntegrity, true, true);

                ctx.SaveChanges();

                var soldLeads = ctx.LeadSale.Where(x => x.Invoiced == false).ToList();
                if (soldLeads != null && soldLeads.Any())
                {
                    UpdatGoogleSheetinBatch(SetGoogleObjectSoldLeads(soldLeads), spreadsheetId, rangeSoldLeads, service);
                }


                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Error in processing lead info", ex);
            }
        }

        private List<LeadSpreadSheetDto> SendLeads(string spreadsheetId, string rangeLeads, string rejectedLeads, SheetsService service, 
            List<Application> completedLeads, 
            bool SendLeadToIntegrity, 
            bool setLeadCapturedImmediate)
        {
            List<LeadSpreadSheetDto> leadDTOs = new List<LeadSpreadSheetDto>();
            var leadFailureDTOs = new List<LeadSpreadSheetDto>();
            foreach (var leads in completedLeads)
            {
                try
                {
                    var lead = ConvertSheet(leads);
                    leadDTOs.Add(lead);

                    if (!lead.FirstName.ToLower().Contains("test") && SendLeadToIntegrity)
                    {
                        lead.SentToIntegrity = SendLeadsToNationalBuyer(lead);
                    }
                    if (lead.SentToIntegrity == false && SendLeadToIntegrity)
                    {
                        leadFailureDTOs.Add(lead);
                    }
                    
                    leads.SentToIntegrity = lead.SentToIntegrity;
                    leads.LeadCaputred = true;
                    leads.Language = string.Empty;


                    if (setLeadCapturedImmediate)
                    {
                        leads.ImmediateLeadCaptured = true;
                    }
                    
                    if(leads.LeadInfo.Email != null && leads.LeadInfo.Email != string.Empty && leads.LeadInfo.PremiumType == SeniorChoicePremiumType.Immediate)
                    {
                        SendEmail(leads);
                    }
                                  
                }
                catch (Exception ex)
                {
                    leads.LeadCaputred = true;
                    var test = ex;
                }
            }
            if (leadDTOs.Any())
            {
                UpdatGoogleSheetinBatch(SetGoogleObject(leadDTOs), spreadsheetId, rangeLeads, service);
            }

            if (leadFailureDTOs.Any())
            {
                UpdatGoogleSheetinBatch(SetGoogleObject(leadFailureDTOs), spreadsheetId, rejectedLeads, service);
            }

            return leadDTOs;
        }



        public async void SendEmail(Application application)
        {
            var client = new SendGridClient("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");
            var url = string.Format("https://americanseniordirect.com/#/resume/landing?applicationId={0}&email={1}&phone={2}", application.ApplicationId, application.LeadInfo.Email, application.LeadInfo.Phone);
            var dynamic = new SendGridTemplateData()
            {
                BenefitAmount = string.Format("{0:C}", application.LeadInfo.SelectedBenefitAmount),
                MonthlyPremium = string.Format("{0:C}", application.LeadInfo.SelectedMonthlyRate),
                ResumeUrl = url
            };

            var from = new EmailAddress("admin@americanseniordirect.com", "Admin");
            var to = new EmailAddress(application.LeadInfo.Email, application.ApplicationInfo.FirstName + " " + application.ApplicationInfo.LastName);
            if (application.LeadInfo.SecondQuoteReceived && !application.ImmediateLeadEmailed)
            {
                var templateId = "d-88285b96542d4c0d860615a096e4da63";
                var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamic);
                var response = await client.SendEmailAsync(msg);
                application.ImmediateLeadEmailed = true;
                application.QuoteLeadEmailed = true;
            }
            else if(application.LeadInfo.QuoteReceived && !application.QuoteLeadEmailed)
            {
                var templateId = "d-ecd165a0d4cb403c9d4df0fb0afed5a2";
                var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamic);
                var response = await client.SendEmailAsync(msg);
                application.QuoteLeadEmailed = true;
            }         

        }





        public bool SendLeadsToNationalBuyer(LeadSpreadSheetDto lead)
        {

            var url = "https://leads-api.integritymarketing.com/ffl/gametime/lead";
            var APIKey = "0209d022e3a146c3b501c1c0c1974cee";
            // var url  = "https://dev-leads-api.integritymarketing.com/ffl/gametime/lead";
            // var APIKey = "c6aaa51f8e1b433e99261e62bf44de39";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(ConvertToLeadIntegrityMarketing(lead)), Encoding.UTF8, "application/json");
                    content.Headers.Add("ApiKey", APIKey);
                    var response = httpClient.PostAsync(url, content);
                    var test = response.Result.ToString();
                    lead.FailureReason = response.Result.Content.ReadAsStringAsync().Result;
                    response.Result.EnsureSuccessStatusCode();
                    lead.FailureReason = string.Empty;
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SheetsService SendToGoogleSheet()
        {
            try
            {
                //  UserCredential credential;
                var baseDirectory = Directory.GetCurrentDirectory();
                var pathToCredential = baseDirectory + "\\credential.json";

                var credential = GoogleCredential.FromFile(pathToCredential);

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                return service;
            }
            catch (Exception ex)
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, "token.json/");
                throw new Exception("Got to here as service is not produce " + credPath, ex);
                var test1 = ex;
            }
            return null;
        }


        private void UpdatGoogleSheetinBatch(List<IList<object>> leads, string spreadsheetId, string newRange, SheetsService service)
        {
            try
            {
                var valueRange = new ValueRange();
                valueRange.Values = leads;

                var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, newRange);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var appendReponse = appendRequest.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to process or execute on sending data to google. ", ex);
            }
        }

        private List<IList<object>> SetGoogleObject(IList<LeadSpreadSheetDto> leads)
        {
            var prop = typeof(LeadSpreadSheetDto);
            var rang = new List<IList<object>>();
            foreach (var item in leads)
            {
                var oblist = prop.GetProperties().Select(k => k.GetValue(item)).ToList();
                rang.Add(oblist);
            }
            return rang;
        }

        private List<IList<object>> SetGoogleObjectOne(LeadSpreadSheetDto leads)
        {
            var prop = typeof(LeadSpreadSheetDto);
            var rang = new List<IList<object>>();

            var oblist = prop.GetProperties().Select(k => k.GetValue(leads)).ToList();
            rang.Add(oblist);

            return rang;
        }

        private List<IList<object>> SetGoogleObjectSoldLeads(IList<LeadSale> leads)
        {
            var prop = typeof(SoldLeadsSpreadsheetDto);
            var rang = new List<IList<object>>();
            foreach (var item in leads)
            {
                var applicationSold = ctx.Application.Where(x => x.ApplicationId == item.LeadId).Include(e => e.ApplicationInfo)
                      .Include(e => e.LeadInfo)
                      .Include(e => e.PaymentInfo)
                      .FirstOrDefault();
                var items = ConvertSoldSheet(applicationSold, item);
                var oblist = prop.GetProperties().Select(k => k.GetValue(items)).ToList();
                rang.Add(oblist);
                item.Invoiced = true;
            }

            return rang;
        }

        private LeadSpreadSheetDto ConvertSheet(Application sales)
        {

            var age = DateTime.Today.Year - sales.ApplicationInfo.DOB.Year;
            if (sales.ApplicationInfo.DOB > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            var gender = "Male";
            if (sales.LeadInfo.Gender == Gender.Female)
            {
                gender = "Female";
            }

            var desiredBeneficiary = "Other";

            if (sales.LeadInfo.DesiredBeneficiary == Relationship.Child)
            {
                desiredBeneficiary = "Child";
            }
            else if (sales.LeadInfo.DesiredBeneficiary == Relationship.Spouse)
            {
                desiredBeneficiary = "Spouse";
            }
            else if (sales.LeadInfo.DesiredBeneficiary == Relationship.Relative)
            {
                desiredBeneficiary = "Relative";
            }


            var sheet = new LeadSpreadSheetDto();

            sheet.LeadId = sales.ApplicationId.ToString();
            sheet.ExternalLeadId = sales.LeadInfo.ExternalLeadId;
            sheet.FirstName = sales.ApplicationInfo.FirstName;
            sheet.MiddleName = sales.ApplicationInfo.MiddleName;
            sheet.LastName = sales.ApplicationInfo.LastName;
            sheet.Address1 = sales.LeadInfo.Address1;
            sheet.Address2 = sales.LeadInfo.Address2;
            sheet.State = sales.LeadInfo.State;
            if (sales.LeadInfo.ZipCode.Length < 5)
            {
                sheet.ZipCode = sales.LeadInfo.ZipCode.ToString();
            }
            else
            {
                sheet.ZipCode = sales.LeadInfo.ZipCode.ToString().Substring(0, 5);
            }

            sheet.City = sales.LeadInfo.City;
            sheet.Email = sales.LeadInfo.Email;
            sheet.Phone = sales.LeadInfo.Phone;
            sheet.SSN = sales.ApplicationInfo.SSN;
            sheet.HeightFt = sales.ApplicationInfo.HeightFt;
            sheet.HeightIn = sales.ApplicationInfo.HeightIn;
            sheet.Weight = sales.ApplicationInfo.Weight;
            sheet.DoctorName = sales.ApplicationInfo.DoctorName;
            sheet.DoctorCity = sales.ApplicationInfo.DoctorCity;
            sheet.LeadSource = sales.LeadInfo.LeadSource;
            sheet.Age = age;
            sheet.DesiredBeneficiary = desiredBeneficiary;
            sheet.CurrentCoverage = sales.LeadInfo.CurrentCoverage;
            sheet.DesiredCoverageAmount = sales.LeadInfo.DesiredCoverageAmount;
            sheet.Hobby = sales.LeadInfo.Hobby;
            sheet.Gender = gender;
            sheet.DateSent = DateTime.Now;
            sheet.emptyObject = string.Empty;
            sheet.SentToIntegrity = sales.SentToIntegrity;

            sheet.IsEligible = sales.LeadInfo.IsEligible;
            sheet.HealthQuestionsAnswered = sales.LeadInfo.HealthQuestionsAnswered;
            sheet.ClickedApplied = sales.LeadInfo.ClickedApplied;
            sheet.ClickedEnrolled = sales.LeadInfo.ClickedEnrolled;
            sheet.ContactAgent = sales.LeadInfo.ContactAgent;
            sheet.KnockedOut = sales.LeadInfo.KnockedOut;
            sheet.BeneficiarySet = sales.LeadInfo.BeneficiarySet;
            sheet.LeadCompleted = sales.LeadInfo.LeadCompleted;
            sheet.QuoteReceived = sales.LeadInfo.QuoteReceived;
            sheet.PaymentDateSet = sales.LeadInfo.PaymentDateSet;
            sheet.PaymentAccountSet = sales.LeadInfo.PaymentAccountSet;
            sheet.SocialSet = sales.LeadInfo.SocialSet;
            sheet.ReviewPageSeen = sales.LeadInfo.ReviewPageSeen;
            sheet.ReviewPageSubmit = sales.LeadInfo.ReviewPageSubmit;
            sheet.SecondQuoteReceived = sales.LeadInfo.SecondQuoteReceived;
            sheet.SelectedBenefitAmount = sales.LeadInfo.SelectedBenefitAmount;
            sheet.SelectedMonthlyRate = sales.LeadInfo.SelectedMonthlyRate;

            DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            sheet.ShortDate = currentTime.ToShortDateString();
            return sheet;
        }

        private SoldLeadsSpreadsheetDto ConvertSoldSheet(Application sales, LeadSale leadSale)
        {
            var age = 55;
            try
            {
                age = DateTime.Today.Year - sales.ApplicationInfo.DOB.Year;
                if (sales.ApplicationInfo.DOB > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
            }
            catch (Exception ex)
            {

            }

            var gender = "Male";
            try
            {
                if (sales.LeadInfo.Gender == Gender.Female)
                {
                    gender = "Female";
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                var sheet = new SoldLeadsSpreadsheetDto()
                {
                    LeadId = sales.ApplicationId.ToString(),
                    ExternalLeadId = sales.LeadInfo.ExternalLeadId,
                    FirstName = sales.ApplicationInfo.FirstName,
                    LastName = sales.ApplicationInfo.LastName,
                    Gender = gender,
                    Address1 = sales.LeadInfo.Address1,
                    State = sales.LeadInfo.State,
                    ZipCode = sales.LeadInfo.ZipCode.Substring(0, 5),
                    City = sales.LeadInfo.City,
                    Email = sales.LeadInfo.Email,
                    Phone = sales.LeadInfo.Phone,
                    HeightFt = sales.ApplicationInfo.HeightFt,
                    HeightIn = sales.ApplicationInfo.HeightIn,
                    Weight = sales.ApplicationInfo.Weight,
                    Age = age,
                    Invoiced = leadSale.Invoiced,
                    UpdatedDate = leadSale.UpdatedDate
                };
                            return sheet;
            }
            catch (Exception ex)
            {

            }
            return new SoldLeadsSpreadsheetDto();

        }


        private LeadIntegrityMarketing ConvertToLeadIntegrityMarketing(LeadSpreadSheetDto leadDto)
        {
            var sheet = new LeadIntegrityMarketing()
            {
                jornaya_lead_id = leadDto.ExternalLeadId,
                lead_id = leadDto.LeadId,
                lead_date = leadDto.DateSent,
                first_name = leadDto.FirstName,
                last_name = leadDto.LastName,
                address_1 = leadDto.Address1,
                address_2 = leadDto.Address2,
                city = leadDto.City,
                state = leadDto.State,
                zip = leadDto.ZipCode,
                phone = leadDto.Phone,
                email = string.Empty,
                age = leadDto.Age,
                gender = leadDto.Gender,
                beneficiary = leadDto.DesiredBeneficiary,
                has_coverage = leadDto.CurrentCoverage,
                current_coverage_amount = 0,
                desired_coverage_amount = Convert.ToInt32(leadDto.DesiredCoverageAmount),
                hobby = leadDto.Hobby

            };

            if (sheet.jornaya_lead_id == null || sheet.jornaya_lead_id == string.Empty)
            {
                sheet.jornaya_lead_id = sheet.lead_id;
            }

            return sheet;
        }

    }


    public class LeadIntegrityMarketing
    {
        public string jornaya_lead_id { get; set; }
        public string lead_id { get; set; }
        public DateTime lead_date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string beneficiary { get; set; }
        public bool has_coverage { get; set; }
        public int current_coverage_amount { get; set; }
        public int desired_coverage_amount { get; set; }
        public string hobby { get; set; }
    }

    public class LeadSpreadSheetDto
    {
        public string LeadId { get; set; }
        public string ExternalLeadId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public int? HeightFt { get; set; }
        public int? HeightIn { get; set; }
        public decimal Weight { get; set; }
        public string DoctorName { get; set; }
        public string DoctorCity { get; set; }
        public string LeadSource { get; set; }
        public int Age { get; set; }
        public bool CurrentCoverage { get; set; }
        public decimal DesiredCoverageAmount { get; set; }
        public string Hobby { get; set; }
        public string Gender { get; set; }
        public string DesiredBeneficiary { get; set; }
        public DateTime DateSent { get; set; }
        public bool SentToIntegrity { get; set; }
        public string FailureReason { get; set; }
        public string emptyObject { get; set; }
        public string ShortDate { get; set; }

        public decimal SelectedBenefitAmount { get; set; }
        public decimal SelectedMonthlyRate { get; set; }
        public bool LeadCompleted { get; set; }
        public bool QuoteReceived { get; set; }
        public bool ClickedApplied { get; set; }
        public bool ContactAgent { get; set; }
        public bool KnockedOut { get; set; }
        public bool IsEligible { get; set; }
        public bool HealthQuestionsAnswered { get; set; }
        public bool SecondQuoteReceived { get; set; }
        public bool ClickedEnrolled { get; set; }
        public bool BeneficiarySet { get; set; }
        public bool PaymentDateSet { get; set; }
        public bool PaymentAccountSet { get; set; }
        public bool SocialSet { get; set; }
        public bool ReviewPageSeen { get; set; }
        public bool ReviewPageSubmit { get; set; }
    }

    public class SoldLeadsSpreadsheetDto
    {
        public string LeadId { get; set; }
        public string ExternalLeadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address1 { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? HeightFt { get; set; }
        public int? HeightIn { get; set; }
        public decimal Weight { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Invoiced { get; set; }

    }
}

