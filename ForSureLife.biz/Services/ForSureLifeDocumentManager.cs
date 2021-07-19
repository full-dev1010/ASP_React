using ForSureLife.biz.Interfaces;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Enroll;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;
using ForSureLife.Models.Enums;
using ForSureLife.repo;
using iTextSharp.text;
using System.Globalization;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using ForSureLife.repo.Carrier_Access;
using System.Collections;

namespace ForSureLife.biz.Services
{
    public class ForSureLifeDocumentManager : IForSureLifeDocumentManager
    {
        private readonly IAmAmApplicationRepository repository;
        private readonly IAmAmFTPClient amAmFTPClient;
        private readonly IAmAmBlobClient amAmBlobClient;
        protected const string ApplicationTemplateFolderPath = "Assets/templates/application";
        protected const string AA9820C_Form = "Assets/templates/forms/AA9820-C.pdf";
        protected const string AA9820P_Form = "Assets/templates/forms/AA9820-P.pdf";
        protected const string ApplicationBeneficiariesTemplateFolderPath = "Assets/templates/application/Beneficiaries/";
        protected const string ApplicationOutputFolderPath = "Assets/Output/application";
        protected const string SignatureFontPath = "Assets/Cedarville-Cursive.ttf";
        protected const string SeniorChoiceFormsConfigPath = "Assets/configs/seniorchoice-forms.json";

        public ForSureLifeDocumentManager(IAmAmApplicationRepository repository, IAmAmFTPClient amAmFTPClient, IAmAmBlobClient amAmBlobClient)
        {
            this.repository = repository;
            this.amAmFTPClient = amAmFTPClient;
            this.amAmBlobClient = amAmBlobClient;
        }

        public async Task<string> GetApplicationPDF(Guid applicationId)
        {
            var application = await repository.GetApplication(applicationId);

            var initialFiles = new DirectoryInfo(ApplicationOutputFolderPath).GetFiles("*" + application.FileNumber + "*.pdf");
            var findPath = string.Empty;
            foreach (var file in initialFiles)
            {
                findPath = file.FullName;
            }

            if (findPath == string.Empty)
            {
                (string applicationFlatFileName, string applicationPdfFileName) = await FillPdfFlatFiles(application);
                findPath = applicationPdfFileName;
            }

            return findPath;
        }

        /// <summary>
        /// create both flat theapplication then send to correspending ftp repository
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public async Task SubmitApplicationFiles(AAFinalExpense app)
        {
            // var app = await repository.GetApplication(application);

            // app.FileNumber = await repository.GetApplicationNumber();
            (string applicationFlatFileName, string applicationPdfFileName) = await FillPdfFlatFiles(app);
            // upload file to blob server
            await amAmBlobClient.UploadApplicationFile(applicationPdfFileName, Path.GetFileName(applicationPdfFileName));
            await amAmBlobClient.UploadApplicationFile(applicationFlatFileName, Path.GetFileName(applicationFlatFileName));

            // connect to the FTP server
            if (!app.Application.ApplicationInfo.FirstName.ToLower().Equals("test"))
            {
                await amAmFTPClient.UploadApplicationFile(applicationPdfFileName);
                await amAmFTPClient.UploadApplicationFile(applicationFlatFileName);
            }

            await repository.UpdateApplication(app);
        }

        private static int FindText(PdfReader reader, string searchText)
        {
            for (int i = 0; i < reader.NumberOfPages; i++)
            {

                var streamBytes = reader.GetPageContent(i + 1);
                var tokenizer = new PrTokeniser(new RandomAccessFileOrArray(streamBytes));

                var stringsList = new List<string>();
                while (tokenizer.NextToken())
                {
                    if (tokenizer.TokenType == PrTokeniser.TK_STRING)
                    {
                        if (!string.IsNullOrEmpty(tokenizer.StringValue) && tokenizer.StringValue.Contains(searchText))
                        {
                            return i + 1;
                        }
                        stringsList.Add(tokenizer.StringValue);
                    }
                }

            }

            return -1;
        }
        public async Task<(string applicationFlatFileName, string applicationPdfFileName)> FillPdfFlatFiles(AAFinalExpense app)
        {
            string applicationSate = app.SignatureLocationState.ToString();
            var lead = app.Application.LeadInfo;
            var appinfo = app.Application.ApplicationInfo;

            var seniorChoiceForms = (await GetSeniorChoiceForms()).FirstOrDefault(k => k.State == applicationSate);

            // todo : after modeling
            // todo fill thouse vairables 
            // todo do use lead or applicationinfo for filling personnel information
            string AppNumber = "K" + (app.FileNumber).ToString("D6");
            var SeparatePolicyOwner = app.Application.Beneficiaries.FirstOrDefault(k => k.PrimaryRelationship.ToString().StartsWith("SeparatePolicy"));
            var PrimaryBeneficiaries = app.Application.Beneficiaries.Where(k => !k.PrimaryRelationship.ToString().StartsWith("SeparatePolicy")).ToArray();

            ApplicationInfo echeckPayor = null;

            string agentNumber = "1000074";


            string agentName = "Nathan Schmidt";// (printed version with e-signed on end)
            string companyCode3Digit = "110";
            if (app.InsuranceCompanyName == InsuranceCompany.Occidental)
            {
                //agentNumber = "0000195281";
                companyCode3Digit = "770";
            }


            // todo double chekc the Account Holder
            string AccountHolder = appinfo.FirstName + " " + appinfo.LastName;
            // string AccountHolder = "Betty Boop";

            string MenuAgent = companyCode3Digit + agentNumber;

            string AgentSignature1 = agentName + " (e-signed)";
            var Party = "Insured";
            var agentMail = "nathan.schmidt@forsurelife.com";
            // todo set a valid email for a
            var addendumEmail = lead.Email;
            var AgentIP = app.ClientIPAddress;
            var SignatureIP = app.ClientIPAddress;
            var TimeStampRequest = app.SignedDate;
            var TimeStampSigned = app.SignedDate;
            string X = "X";

            string AppInitial = appinfo.FirstName.FirstOrDefault() + "" + (appinfo.MiddleName != null ? appinfo.MiddleName.FirstOrDefault().ToString() : "") + "" + appinfo.LastName.FirstOrDefault();
            string AppPrintedName7 = appinfo.FirstName + " " + appinfo.LastName;// (Applicant’s combined First/Last Name) – Used on 9396 form
            string OwnerSignature = AppPrintedName7;// the application is always the payer SeparatePolicyOwner != null ? (SeparatePolicyOwner.PersonalInfo.FirstName + " " + SeparatePolicyOwner.PersonalInfo.LastName) : null;//
            string AppSignature7 = appinfo.FirstName + " " + appinfo.MiddleName + " " + appinfo.LastName + " (e-signed)";// the application is always the payer SeparatePolicyOwner != null ? OwnerSignature : AppPrintedName7;// (can contain either the Insured’s or other named Owner’s signature)

            string DesigneeSignature = AppSignature7;// (Applicant’s signature when naming a designee)
            string WaiverSignature = AppSignature7;//(Applicant’s signature when waiving designating a designee) 
            string ProposedInsuredSignature = AppSignature7 + "";//
            string PACInsured = AppPrintedName7;// (Applicant’s combined First/Last Name) – used for printing in Bank Draft area
            string ReceivedFrom = AppPrintedName7;// (Applicant’s combined First/Last Name) – Used on conditional receipt 
            string ReceiptInsured = AppPrintedName7;// (Applicant’s printed First/Last Name) – Used on ID designee form only

            // (the PAYOR’S esigned name whether it’s the insured or a different person selected as payor.)
            string DepositSignature = AppSignature7;// the application is always the payer  = echeckPayor != null ? (echeckPayor.FirstName + " " + echeckPayor.LastName) : AppPrintedName7;// 

            string eCheckSignature = AppSignature7;// the application is always the payer = echeckPayor != null ? DepositSignature : AppPrintedName7;// (contains either the Insured’s or other named Payor’s signature)
            if (!Directory.Exists(ApplicationOutputFolderPath)) Directory.CreateDirectory(ApplicationOutputFolderPath);
            var applicationPdfFileName = Path.Join(ApplicationOutputFolderPath, "App-Web" + companyCode3Digit + agentNumber + "-" + AppNumber + ".pdf");
            var applicationFlatFileName = Path.Join(ApplicationOutputFolderPath, companyCode3Digit + AppNumber + "1WebApp.txt");

            // Add page for each benficiary after changine fields name to 
            // then merge to state template 
            var templateFile = Path.Join(ApplicationOutputFolderPath, Path.GetFileNameWithoutExtension(applicationPdfFileName) + "tmpl" + ".pdf");
            var stateTemplateFile = GetTemplateFilePath(applicationSate);

            List<string> tmpFiles = new List<string>();

            // remove this code for Beneficiary details
            // templateFile = JoinAddiontalBeneficiariesPages(applicationSate, PrimaryBeneficiaries, applicationPdfFileName, templateFile, stateTemplateFile, tmpFiles);

            templateFile = stateTemplateFile;
            PdfReader pdfReader = new PdfReader(templateFile);
            var AA9761_Page = FindText(pdfReader, "AA9761");
            var AA9761MN_Page = FindText(pdfReader, "AA9761-MN");
            if (AA9761_Page < 0)
            {
                AA9761_Page = FindText(pdfReader, "CCELERATED BENEFITS RIDER - CONFINED CARE");

            }
            if (AA9761MN_Page < 0)
            {
                AA9761MN_Page = FindText(pdfReader, "BENEFITS RIDER - CONFINED CARE");
            }
            var AA3157_Page = FindText(pdfReader, "AA3157");
            if (AA3157_Page < 0)
            {
                AA3157_Page = FindText(pdfReader, "CCELERATED BENEFITS RIDER - CONFINED CARE");

            }
            if (AA3157_Page < 0)
            {
                AA3157_Page = FindText(pdfReader, "2345");
            }

            using var fs = new FileStream(applicationPdfFileName, FileMode.Create);
            var pagesToDelete = new HashSet<int>();
            // todo after fixing the templates(remove addendum page ) you have to delete the next line 
            pagesToDelete.Add(pdfReader.NumberOfPages);
            if (app.PremiumType == SeniorChoicePremiumType.Graded || app.PremiumType == SeniorChoicePremiumType.Premium)
            {
                if (AA9761_Page >= 0)
                {
                    pagesToDelete.Add(AA9761_Page);
                }

                if (AA9761MN_Page >= 0)
                {
                    pagesToDelete.Add(AA9761MN_Page);
                }

                if (app.SignatureLocationState == "NC")
                {
                    if (AA3157_Page < 0)
                    {
                        AA3157_Page = FindText(pdfReader, "CONFINED CARE");
                    }
                    if (AA3157_Page >= 0)
                    {
                        pagesToDelete.Add(AA3157_Page);
                    }
                }
            }


            DeleteUnsedPages(pdfReader, pagesToDelete);
            var pdfStamper = new PdfStamper(pdfReader, fs);
            // pdfStamper.FormFlattening = true;

            AcroFields acroFields = pdfStamper.AcroFields;

            var fieldNames = acroFields.Fields.OfType<System.Collections.DictionaryEntry>().Select(k => k.Key.ToString()).OrderBy(k => k).ToHashSet();


            // set signatures fonts if the file SignatureFontPath exists
            if (File.Exists(SignatureFontPath))
            {
                BaseFont si = BaseFont.CreateFont(SignatureFontPath, BaseFont.CP1252, BaseFont.EMBEDDED);

                var signatureFields = new List<string>{
                  "ProposedInsuredSignature",
                  "OwnerSignature",
                  "DepositSignature",
                  "AppSignature7",
                  "eCheckSignature",
                  "DesigneeSignature",
                  "WaiverSignature",
                  "AgentSignature1",
                //   "PACInsured",
                  "ReceivedFrom",
                //   "AppPrintedName7",
                  "ReceiptInsured",
                };
                // set signatures fonts 
                // foreach (var key in fieldNames.Where(fieldName => signatureFields.Any(signatureField => fieldName.ToLower().Contains(signatureField.ToLower()))))
                // {
                //     acroFields.SetFieldProperty(key, "textfont", si, null);
                // }
            }
            // foreach (var item in fieldNames) acroFields.SetField(item, item);
            // File.WriteAllText("Assets/AK.fields.txt", string.Join("\n", fieldNames));

            var flatbuilder = new StringBuilder();


            // field AppNumber 
            SetAllFieldStartWith(acroFields, fieldNames, "AppNumber", AppNumber);



            var applicationDateVal = app.SignedDate;
            var applicationDate = applicationDateVal.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            var applicationDateShort = applicationDateVal.ToString("M/d/yyyy");
            // field ApplicationDate
            var applicationEffectiveVal = app.EffectiveDate;
            var applicationEffectiveDate = applicationEffectiveVal.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            var applicationEffectiveDateShort = applicationEffectiveVal.ToString("M/d/yyyy");

            // page 3

            // field appform 
            flatbuilder.AppendLine("PDFFORM=" + "AA9466");
            flatbuilder.AppendLine("SITENAME=" + "SC9466 SENIOR CHOICE");

            // todo: question if use ESIGN or SCREEN  page 3 word
            flatbuilder.AppendLine("SIGTYPE=" + "ESIGN");

            flatbuilder.AppendLine("MENUAGENT=" + MenuAgent);
            var strMenuAgent = MenuAgent[6..];
            SetAllFieldStartWith(acroFields, fieldNames, "MenuAgent", strMenuAgent);


            flatbuilder.AppendLine("APPLICATIONDATE=" + applicationDate);
            SetAllFieldStartWith(acroFields, fieldNames, "ApplicationDate", applicationDate);

            flatbuilder.AppendLine("AGTNUMBER1=" + agentNumber);
            flatbuilder.AppendLine("AGTPERCENT1=" + "100");
            flatbuilder.AppendLine("AGTNAME1=" + agentName);

            SetAllFieldStartWith(acroFields, fieldNames, "AgentName", agentName);

            // todo : Sample of logging the signature capture: page 3 word


            // page 4

            acroFields.SetField("InterviewCo", "INTERVIEW NOT REQ");
            acroFields.SetField("CaseNumber", "");

            flatbuilder.AppendLine("TELEPHONEINTERVIEWNO=X");
            acroFields.SetField("TelephoneInterviewNo", X);
            acroFields.SetField("TelephoneInterviewYes", "");

            acroFields.SetField("BestTimeToCall1", "");
            acroFields.SetField("BestTimeToCallam", "");
            acroFields.SetField("BestTimeToCallpm", "");

            // page 5 

            SetAllFieldStartWith(acroFields, fieldNames, "StateSigned", app.SignatureLocationState);
            SetAllFieldStartWith(acroFields, fieldNames, "CitySigned", app.SignatureLocationCity);

            // var lead = appinfo;
            var bidate = appinfo.DOB;
            flatbuilder.AppendLine("CITYSIGNED=" + app.SignatureLocationCity);
            flatbuilder.AppendLine("STATESIGNED=" + app.SignatureLocationState);
            var age = (new DateTime(1, 1, 1) + (DateTime.Now - bidate)).Year - 1;
            flatbuilder.AppendLine("FIRSTNAME=" + appinfo.FirstName);
            flatbuilder.AppendLine("LASTNAME=" + appinfo.LastName);
            flatbuilder.AppendLine("MIDDLENAME=" + appinfo.MiddleName);
            flatbuilder.AppendLine("AGE=" + age.ToString());
            flatbuilder.AppendLine("BIRTHDATE=" + appinfo.DOB.ToString("M/d/yyyy"));
            if (lead.Gender == Gender.Male) flatbuilder.AppendLine("SEXMALE=X");
            else flatbuilder.AppendLine("SEXFEMALE=X");

            SetAllFieldStartWith(acroFields, fieldNames, "FirstName", appinfo.FirstName);
            SetAllFieldStartWith(acroFields, fieldNames, "LastName", appinfo.LastName);
            SetAllFieldStartWith(acroFields, fieldNames, "MiddleName", appinfo.MiddleName);
            SetAllFieldStartWith(acroFields, fieldNames, "Age", age.ToString());
            SetAllFieldStartWith(acroFields, fieldNames, "BirthDate", appinfo.DOB.ToString("M/d/yyyy"));
            if (lead.Gender == Gender.Male) acroFields.SetField("SexMale", X);
            else acroFields.SetField("SexFemale", X);
            // page 6
            var tobaco = app.Application.HealthQuestions.Where(x => x.LeadHealthQuestion == LeadHealthQuestions.TobaccoUse).FirstOrDefault()?.HealthAnswer;
            if (tobaco == true)
            {
                acroFields.SetField("TobaccoYes", X);
                flatbuilder.AppendLine("TOBACCOYES=X");
            }
            if (tobaco == false)
            {
                acroFields.SetField("TobaccoNo", X);
                flatbuilder.AppendLine("TOBACCONO=X");

            }



            // DONE clarify how to get selected plan
            var plan = app.PremiumType;

            var planDesc = "Senior Choice " + plan;
            switch (plan)
            {
                case SeniorChoicePremiumType.Immediate:
                    flatbuilder.AppendLine("PLANIMMEDIATE=X");
                    acroFields.SetField("PlanImmediate", X);
                    planDesc = "Senior Choice Immediate";
                    break;
                case SeniorChoicePremiumType.Graded:
                    flatbuilder.AppendLine("PLANGRADED=X");
                    acroFields.SetField("PlanGraded", X);
                    planDesc = "Senior Choice Graded";
                    break;
                case SeniorChoicePremiumType.Premium:
                    flatbuilder.AppendLine("PLANROP=X");
                    acroFields.SetField("PlanROP", X);
                    planDesc = "Senior Choice ROP";
                    break;
            }
            acroFields.SetField("PlanDesc", planDesc);


            //if (false)
            //{
            //    acroFields.SetField("DesigneeName", "Debby Young");
            //    acroFields.SetField("DesigneeAddress", "2575 W Cranberry Ridge Rd Lehi UT 84043");
            //    flatbuilder.AppendLine("DesigneeName=Debby Young");
            //    flatbuilder.AppendLine("DesigneeAddress=2575 W Cranberry Ridge Rd Lehi UT 84043");
            //}


            // page 7 

            var ACCEPTANCE = appinfo.AcceptAnyPlan;
            if (ACCEPTANCE)
            {
                acroFields.SetField("Acceptance", X);
                flatbuilder.AppendLine("ACCEPTANCE=True");
            }
            else
            {
                flatbuilder.AppendLine("ACCEPTANCE=False");
            }

            //****************************************************************************
            // NO RIDERS  no use for this section 
            // var userRider = false;
            // var NHWP = false;
            // if (plan == SeniorChoicePremiumType.Immediate)
            // {
            //     // todo get value of •	Nursing Home Waiver of Premium 
            //     if (age >= 50 && age <= 80)
            //     {
            //         acroFields.SetField("NHWP", X);
            //         acroFields.SetField("WPTXT1", "NHWP");
            //         NHWP = true;
            //         flatbuilder.AppendLine("NHWP=True");
            //     }
            // }
            // if (!NHWP)
            // {
            //     flatbuilder.AppendLine("NHWP=False");
            // }
            // // page 8  
            // // todo Accidental Death Benefit information
            // if (plan != SeniorChoicePremiumType.Premium)
            // {
            //     if (age >= 50 && age <= 80 && appinfo.LifePolicy)
            //     {
            //         var RidersADBAmt = appinfo.LifeCoverageAmount;
            //         acroFields.SetField("ADB", X);
            //         acroFields.SetField("RidersADBAmt", RidersADBAmt.ToString());

            //         flatbuilder.AppendLine("ADB=X");
            //         flatbuilder.AppendLine("ADBAMOUNT=" + RidersADBAmt.ToString());
            //     }

            // }
            // //  no  riders: how to get CIRUnits in  Child Rider (Not available on ROP plan) – Up to 10
            // if (plan != SeniorChoicePremiumType.Premium)
            // {
            //     int CIRUnits = 1;

            //     int childcount = app.Application.Beneficiaries.Count(k =>
            //               k.PrimaryRelationship == Relationship.Child
            //         );
            //     if (childcount > 0 && CIRUnits > 0)
            //     {
            //         acroFields.SetField("CIR", X);
            //         acroFields.SetField("CIRUnits", CIRUnits.ToString());
            //         flatbuilder.AppendLine("CIA=" + CIRUnits.ToString());
            //     }

            // }

            // // todo  how to get GCIRUnits	Grandchild Rider (Available on all plans)
            // int GCIRCount = app.Application.Beneficiaries.Count(k =>
            //                 k.PrimaryRelationship == Relationship.GrandChild
            //         );
            // if (GCIRCount > 0)
            // {
            //     var GCIRUnits = 1;

            //     flatbuilder.AppendLine("GCIR=X");
            //     flatbuilder.AppendLine("GCIACOUNT=" + GCIRCount.ToString());
            //     flatbuilder.AppendLine("GCIRAMT=" + GCIRUnits.ToString());
            //     acroFields.SetField("GCIR", X);
            //     acroFields.SetField("GCIRCount", GCIRCount.ToString());
            //     // acroFields.SetField("GCIRExceptions", app.GCIRExceptions);
            //     acroFields.SetField("GCIRUnits", GCIRUnits.ToString());
            // }

            // page 9
            //    confirm payment mode i useed MONTHLY
            var paymentMode = "Monthly";
            var isBankPayementMode = true;
            acroFields.SetField("ModeOther", X);
            var txtpaymentMode = "MODEMONTHLY";
            switch (paymentMode)
            {
                case "Monthly":
                    acroFields.SetField("ModeOtherDesc", isBankPayementMode ? "Bank Mon" : "Dir Mon");
                    txtpaymentMode = "MODEMONTHLY";
                    break;
                case "Quarterly":
                    acroFields.SetField("ModeOtherDesc", isBankPayementMode ? "Bank Q" : "Dir Q");
                    txtpaymentMode = "MODEQUARTERLY";
                    break;
                case "Semi-Annual":
                    acroFields.SetField("ModeOtherDesc", isBankPayementMode ? "Bank SA" : "Dir SA");
                    txtpaymentMode = "MODESEMIANNUAL";
                    break;
                case "Annually":
                    acroFields.SetField("ModeOtherDesc", isBankPayementMode ? "Bank A" : "Dir A");
                    txtpaymentMode = "MODEANNUAL";
                    break;
            }
            flatbuilder.AppendLine(txtpaymentMode + "=X");

            // page 10
            // TODO GET APL Automatic Premium Loan (Yes/No)
            var APL = true;

            if (APL)
            {
                flatbuilder.AppendLine("APLYES=X");
                acroFields.SetField("APLYes", X);
            }
            else
            {
                flatbuilder.AppendLine("APLNO=X");
                acroFields.SetField("APLNo", X);
            }

            var MailPolicy = app.MailPolicyTo;
            MailPolicy = MailPolicy.Insured;
            switch (MailPolicy)
            {
                case MailPolicy.Agent:
                    acroFields.SetField("MailToAgent", X);
                    flatbuilder.AppendLine("MAILTOAGENT=X");

                    break;
                case MailPolicy.Insured:
                    acroFields.SetField("MailToInsured", X);
                    flatbuilder.AppendLine("MAILTOINSURED=X");
                    break;
                case MailPolicy.Owner:
                    acroFields.SetField("MailToOwner", X);
                    flatbuilder.AppendLine("MAILTOOWNER=X");
                    break;
            }
            // PAGE 11
            // done: confirm •	Policy Date //  confirm save age 
            var ReqPolicyDate = app.EffectiveDate;
            if ((ReqPolicyDate - DateTime.Now).Days < 35)
            {
                acroFields.SetField("ReqPolicyDate", ReqPolicyDate.ToString("M/d/yyyy"));
                flatbuilder.AppendLine("REQPOLICYDATE=" + ReqPolicyDate.ToString("M/d/yyyy"));
                flatbuilder.AppendLine("SAVEAGE=True");
            }
            else
            {
                acroFields.SetField("ReqPolicyDate", "On Approval");
                flatbuilder.AppendLine("REQPOLICYDATE=OnApproval");
                flatbuilder.AppendLine("SAVEAGE=False");

            }

            var FaceAmount = app.SelectedBenefitAmount;

            flatbuilder.AppendLine("FACEAMOUNT=" + ((int)FaceAmount).ToString());
            acroFields.SetField("FaceAmount", ((int)FaceAmount).ToString());

            var ModalPremium = app.SelectedMonthlyRate;
            if (ModalPremium > 0)
            {
                SetAllFieldStartWith(acroFields, fieldNames, "ModalPremium", ModalPremium.ToString("N2", CultureInfo.InvariantCulture));
                flatbuilder.AppendLine("MODALPREMIUM=" + ModalPremium.ToString("N2", CultureInfo.InvariantCulture));

            }

            // page 13

            foreach (var question in app.ApplicationAnswers.OrderBy(k => k?.Question?.QuestionName.ToString()))
            {
                // question format Question8b
                // field format SectionA7a

                var fieldCode = question.Question.QuestionName.ToString().Substring("Question".Length);
                var fieldName = "SectionA" + (fieldCode) + (question.Answer ? "Yes" : "No");
                acroFields.SetField(fieldName, X);
                flatbuilder.AppendLine(fieldName.ToUpper() + "=" + X);
                if (fieldNames.Contains(fieldName) == false)
                {
                    System.Console.WriteLine(fieldName);
                }

            }
            // CONFIRM  THE IS NO COMMENT 
            // flatbuilder.AppendLine("COMMENTS=" + "Giving some additional comments after answering all of the health questions.");

            // PAGE 14
            // done no covid question for the moment source (plus in the text file it use CTL72)
            var covidQuestion1 = app.Application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidQuestionMain).FirstOrDefault()?.HealthAnswer == true;
            var covid90Day1 = app.Application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidWithin90DaysMain).FirstOrDefault()?.HealthAnswer == true;

            var covidEffects1 = app.Application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidEffectsMain).FirstOrDefault()?.HealthAnswer == true;
            var covidQuestion2 = app.Application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Covid2).FirstOrDefault()?.HealthAnswer == true;
            var covid290Day2 = app.Application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Covid290Days).FirstOrDefault()?.HealthAnswer == true;
            var covidEffects2 = app.Application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Covid2Effects).FirstOrDefault()?.HealthAnswer == true;
            var covidQuestion3 = app.Application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidQuestionThree).FirstOrDefault()?.HealthAnswer == true;
            if (app.Application.LeadInfo.State.ToLower() != "fl" && app.Application.LeadInfo.State.ToLower() != "florida")
            {

                if (covidQuestion1)
                {
                    flatbuilder.AppendLine("CVQ1=Yes");
                    acroFields.SetField("CVQ1Yes", X);
                    flatbuilder.AppendLine("CVQInfo1a=" + (covid90Day1 ? "Yes" : "No"));
                    flatbuilder.AppendLine("CVQInfo2=" + (covidEffects1 ? "Yes" : "No"));
                }
                else
                {
                    flatbuilder.AppendLine("CVQ1=No");
                    acroFields.SetField("CVQ1No", X);
                }
                if (covidQuestion2)
                {
                    flatbuilder.AppendLine("CVQ2=Yes");
                    acroFields.SetField("CVQ2Yes", X);
                    flatbuilder.AppendLine("CVQInfo1b=" + (covid290Day2 ? "Yes" : "No"));
                    flatbuilder.AppendLine("CVQInfo4=" + (covidEffects2 ? "Yes" : "No"));
                }
                else
                {
                    flatbuilder.AppendLine("CVQ2=No");
                    acroFields.SetField("CVQ2No", X);
                }
                if (covidQuestion3)
                {

                    flatbuilder.AppendLine("CVQ3=Yes");
                    acroFields.SetField("CVQ3Yes", X);

                }
                else
                {
                    flatbuilder.AppendLine("CVQ3=No");
                    acroFields.SetField("CVQ3No", X);


                }
            }
            // page 17 

            // todo confirm fields  FormBankDraft / ACCOUNTHOLDER
            var FormBankDraft = true;
            var payementInfo = app.Application.PaymentInfo;
            if (FormBankDraft)
            {
                // todo change to logic if there is seperate polowner 
                acroFields.SetField("FormBank Draft", X);
                flatbuilder.AppendLine("FORMBANK DRAFT=" + X);
                flatbuilder.AppendLine("BANKNAME=" + payementInfo.BankingInsitution);
                flatbuilder.AppendLine("BANKADDRESS=" + payementInfo.BankAddress);
                flatbuilder.AppendLine("ACCOUNTHOLDER=" + AccountHolder);
                flatbuilder.AppendLine("ACCOUNTNUMBER=" + payementInfo.AccountNumber);
                flatbuilder.AppendLine("TRANSITNUMBER=" + payementInfo.RoutingNumber);

                SetAllFieldStartWith(acroFields, fieldNames, "BankName", payementInfo.BankingInsitution);
                SetAllFieldStartWith(acroFields, fieldNames, "BankAddress", payementInfo.BankAddress);
                SetAllFieldStartWith(acroFields, fieldNames, "AccountHolder", AccountHolder);
                SetAllFieldStartWith(acroFields, fieldNames, "AccountNumber", payementInfo.AccountNumber);
                SetAllFieldStartWith(acroFields, fieldNames, "TransitNumber", payementInfo.RoutingNumber);

                //SetAllFieldStartWith(acroFields, fieldNames, "PACInsured_1", PACInsured);
                //SetAllFieldStartWith(acroFields, fieldNames, "AccountHolder_1", PACInsured);
                acroFields.SetField("PACInsured_1", PACInsured);
                acroFields.SetField("PACInsured", PACInsured);
                acroFields.SetField("AccountHolder_1", PACInsured);
                acroFields.SetField("AccountHolder", PACInsured);
                acroFields.SetField("DepositSignature_1", DepositSignature);
                acroFields.SetField("ApplicationDate_5", TimeStampSigned.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));




                // page 18 
                if (true)
                {
                    var sspPrefix = "";
                    if (payementInfo.PaymentWithdrawlDate > 0)
                    {
                        sspPrefix = payementInfo.PaymentWithdrawlDate.ToString();
                        flatbuilder.AppendLine("SSP=No");
                    }
                    else
                    {

                        flatbuilder.AppendLine("SSP=Yes");

                        switch (payementInfo.SocialSecurityWithdrawDate)
                        {
                            case SSDDate.FirststDOM:
                                sspPrefix = "1S";
                                break;
                            case SSDDate.ThirdDOM:
                                sspPrefix = "3S";
                                break;
                            case SSDDate.SecondW:
                                sspPrefix = "2W";
                                break;
                            case SSDDate.ThirdW:
                                sspPrefix = "3W";
                                break;
                            case SSDDate.ForthW:
                                sspPrefix = "4W";
                                break;
                            default:
                                // todo: check default condition page 19 
                                // •	Else	1 through 28
                                sspPrefix = payementInfo.PaymentWithdrawlDate.ToString();
                                break;

                        }
                    }
                    flatbuilder.AppendLine("REQUESTEDDRAFTDAY=" + sspPrefix);
                    acroFields.SetField("RequestedDraftDay", sspPrefix);

                }

            }
            // page 19
            // don its bank draft get fields Echeck ,Draft1st ,ReceivedFrom ,eCheckSignature
            var eCheck = false;
            var CWA = 300.25;
            string Draft1st = "";
            if (eCheck)
            {
                flatbuilder.AppendLine("ECHECKYES=" + X);
                acroFields.SetField("eCheck", X);
                acroFields.SetField("CWA", CWA.ToString());
                acroFields.SetField("Draft1st", Draft1st);

                acroFields.SetField("eCheckSignature", eCheckSignature);
            }
            else
            {
                flatbuilder.AppendLine("ECHECKNO=" + X);
                // todo remove  page (not KS ? 3: 4) if possible 
            }
            acroFields.SetField("ReceivedFrom", ReceivedFrom);
            acroFields.SetField("2.ApplicationDate_1", applicationDate);
            acroFields.SetField("2.AgentSignature1", AgentSignature1);

            // page 20

            if (payementInfo.BankType == AccountType.Savings)
            {
                flatbuilder.AppendLine("CHECKPLAN=Savings");
                acroFields.SetField("CheckPlanSaving", X);
            }
            else
            {
                acroFields.SetField("CheckPlanChecking", X);
                flatbuilder.AppendLine("CHECKPLAN=Checking");

            }

            // page 21 
            var FormDirect = true;
            // todo all missing fields Selection: Direct  
            SetAllFieldStartWith(acroFields, fieldNames, "PACInsured", PACInsured);
            SetAllFieldStartWith(acroFields, fieldNames, "DepositSignature", DepositSignature);

            if (FormDirect)
            {

            }
            else
            {
                // todo Print consideration: Even though this is not Bank Draft, the conditional receipt still requires completion. The only field not completed is CWA field.

            }
            // page 23
            acroFields.SetField("StreetAddress", lead.Address1 + " " + lead.Address2);
            flatbuilder.AppendLine("STREETADDRESS=" + lead.Address1 + " " + lead.Address2);
            flatbuilder.AppendLine("CITY=" + lead.City);
            acroFields.SetField("City", lead.City);

            // page 24
            acroFields.SetField("State", lead.State);
            flatbuilder.AppendLine("STATE=" + lead.State);
            flatbuilder.AppendLine("ZIPCODE=" + lead.ZipCode);
            acroFields.SetField("ZipCode", lead.ZipCode.ToString());
            SetAllFieldStartWith(acroFields, fieldNames, "SSN", FormatSSN(appinfo.SSN));
            flatbuilder.AppendLine("SSN=" + FormatSSN(appinfo.SSN));
            flatbuilder.AppendLine("PHONE=" + lead.Phone);
            acroFields.SetField("Phone", lead.Phone);
            // Email,Phone,City,Address1,Address2,ZipCode,State,Gender
            // page 25
            acroFields.SetField("Email1", lead.Email);
            flatbuilder.AppendLine("EMAIL1=" + lead.Email);


            SetAllFieldStartWith(acroFields, fieldNames, "BirthState", appinfo.StateOfBirth);
            flatbuilder.AppendLine("BIRTHSTATE=" + appinfo.StateOfBirth);

            flatbuilder.AppendLine("HEIGHT=" + appinfo.HeightFt + "'" + appinfo.HeightIn);

            SetAllFieldStartWith(acroFields, fieldNames, "Height", (appinfo.HeightFt + "'" + appinfo.HeightIn).ToString());

            flatbuilder.AppendLine("WEIGHT=" + appinfo.Weight.ToString("N0"));
            acroFields.SetField("Weight", appinfo.Weight.ToString("N0"));

            // page 26
            // blank doctors  get filds do
            var DoctorName = "None";
            var DoctorCity = "None";
            // var DoctorName1 = "DoctorName1 ss";
            var PPhone = "000-000-0000";
            if (!string.IsNullOrEmpty(appinfo.DoctorName))
            {

                DoctorName = appinfo.DoctorName;
                DoctorCity = appinfo.DoctorCity + " / " + appinfo.DoctorState.ToString();
            }

            if (!string.IsNullOrEmpty(appinfo.DoctorPhone))
            {
                PPhone = appinfo.DoctorPhone;
            }

            flatbuilder.AppendLine("PPHONE=" + PPhone);
            flatbuilder.AppendLine("DOCTORNAME1=" + DoctorName);
            flatbuilder.AppendLine("DOCTORNAME=" + DoctorCity);

            acroFields.SetField("PPhone", PPhone);
            acroFields.SetField("DoctorName", DoctorName);
            acroFields.SetField("DoctorName1", DoctorCity);

            var PrimaryBeneficiary = PrimaryBeneficiaries.Length == 1 ? PrimaryBeneficiaries.First() : null;
            // todo confirm the is no step child relation
            var childs = PrimaryBeneficiaries.Where(k => k.PrimaryRelationship == Relationship.Child).ToArray();
            var grandChilds = PrimaryBeneficiaries.Where(k => k.PrimaryRelationship == Relationship.GrandChild).ToArray();

            var createSeeAddendum1 = false;

            if (PrimaryBeneficiaries.Length > 1)
            {
                createSeeAddendum1 = true;
                // no riders
                // acroFields.SetField("SeeAddendum1", PrimaryBeneficiaries.Length > 1 ? "See Addendum" : "");

                // for (int i = 1; i <= childs.Length; i++)
                // {
                //     var child = childs[i - 1];
                //     flatbuilder.AppendLine("CIRANOTHER" + i + "=" + (i == childs.Length ? "No" : "Yes"));
                //     flatbuilder.AppendLine("CIRDOB" + i + "=" + child.PersonalInfo.DateOfBirth.ToString("M/d/yyyy"));
                //     flatbuilder.AppendLine("CIRNAME" + i + "=" + child.PersonalInfo.FirstName + " " + child.PersonalInfo.LastName);
                //     flatbuilder.AppendLine("CIRREL" + i + "=" + (child.PrimaryRelationship == Relationship.Child ? "Child" : "StepChild"));
                //     // todo confirm that the child has no gender field
                //     flatbuilder.AppendLine("CIRSEX" + i + "=Female");
                //     // flatbuilder.AppendLine("CIRSEX" + i + "=Male");
                // }

                // // page 27
                // for (int i = 1; i <= childs.Length; i++)
                // {
                //     var child = childs[i - 1];
                //     flatbuilder.AppendLine("GCIRANOTHER" + i + "=" + (i == childs.Length ? "No" : "Yes"));
                //     flatbuilder.AppendLine("GCIRDOB" + i + "=" + child.PersonalInfo.DateOfBirth.ToString("M/d/yyyy"));
                //     flatbuilder.AppendLine("GCIRNAME" + i + "=" + child.PersonalInfo.FirstName + " " + child.PersonalInfo.LastName);
                //     flatbuilder.AppendLine("GCIRREL" + i + "=" + (child.PrimaryRelationship == Relationship.Child ? "Child" : "StepChild"));
                //     // todo confirm that the child has no gender field
                //     flatbuilder.AppendLine("GCIRSEX" + i + "=Female");
                //     // flatbuilder.AppendLine("GCIRSEX" + i + "=Male");
                // }
                // // page 29
                // acroFields.SetField("GCIRExceptions", "None");
                // flatbuilder.AppendLine("GCIREXCEPTIONS=None");

            }
            else
            {

            }

            if (SeparatePolicyOwner != null)
            {
                // Owner/Payor Info:
                var owner = SeparatePolicyOwner.PersonalInfo;

                // page 30
                string relation = GetRelationName(SeparatePolicyOwner);

                acroFields.SetField("OwnerAddress", owner.Address1 + " " + owner.Address2);
                acroFields.SetField("OwnerName", owner.FirstName + " " + owner.LastName);
                SetAllFieldStartWith(acroFields, fieldNames, "OwnerSignature", owner.FirstName + " " + owner.LastName);
                acroFields.SetField("OwnerSS", FormatSSN(owner.SSN));
                acroFields.SetField("OwnerRelationship", relation);

                flatbuilder.AppendLine("OWNERADDRESS=" + owner.Address1 + " " + owner.Address2);
                flatbuilder.AppendLine("OWNERNAME=" + owner.FirstName + " " + owner.LastName);
                flatbuilder.AppendLine("OWNERSS=" + FormatSSN(owner.SSN));
                flatbuilder.AppendLine("OWNERRELATIONSHIP=" + relation);

            }

            //todo: Why is this on this line? 
            flatbuilder.AppendLine("OWNERINFO=True");

            // note  remove the code for mutiple PrimaryBeneficiaries is removed
            // for (int i = 1; i <= PrimaryBeneficiaries.Length; i++)
            // {
            //     var beneficiary = PrimaryBeneficiaries[i - 1];
            //     var fm = beneficiary.PersonalInfo;
            //     // set benificiry information for
            //     // BNF

            //     acroFields.SetField("BNF" + i + "BirthDate", fm.DateOfBirth.ToString("M/d/yyyy"));
            //     acroFields.SetField("BNF" + i + "Weight", fm.Weight.ToString());
            //     acroFields.SetField("BNF" + i + "AppNumber", AppNumber);
            //     acroFields.SetField("BNF" + i + "ApplicationDate", applicationDateShort);
            //     acroFields.SetField("BNF" + i + "ProposedInsuredSignature", ProposedInsuredSignature);
            //     acroFields.SetField("BNF" + i + "SSN", FormatSSN(fm.SSN));
            //     acroFields.SetField("BNF" + i + "Height", fm.HeightFt + "'" + fm.HeightIn);
            //     acroFields.SetField("BNF" + i + "PBeneAddress1", fm.Address1);
            //     acroFields.SetField("BNF" + i + "PBeneAddress2", fm.Address2);
            //     acroFields.SetField("BNF" + i + "PBeneRel", GetRelationName(beneficiary));
            //     acroFields.SetField("BNF" + i + "SLSName", fm.FirstName + " " + fm.LastName);

            // }

            // page 31
            string PTRUSTNAME = "General Trust Funds for Grandchildren";
            string PTRUSTEENAME = "Sophia Hassel";
            string PTRUSTCONTACT = "3909 Trust Information Little Elm Tx 75068";

            string CTRUSTNAME = "General Trust Funds for Grandchildren";
            string CTRUSTEENAME = "Sophia Hassel";
            string CTRUSTCONTACT = "3909 Trust Information Little Elm Tx 75068";

            if (PrimaryBeneficiary != null)
            {
                if (PrimaryBeneficiary.PrimaryRelationship == Relationship.Trust)
                {
                    acroFields.SetField("PrimaryBeneficiary", "Trust - See Addendum");
                    acroFields.SetField("PrimaryRelationship", "Trust");

                    flatbuilder.AppendLine("PRIMARYRELATIONSHIP=Trust");
                    flatbuilder.AppendLine("PRIMARYBENEFICIARY=Trust");
                    flatbuilder.AppendLine("PTRUSTNAME=" + PTRUSTNAME);
                    flatbuilder.AppendLine("PTRUSTEENAME=" + PTRUSTEENAME);
                    flatbuilder.AppendLine("PTRUSTCONTACT=" + PTRUSTCONTACT);
                }
                else if (PrimaryBeneficiary.PrimaryRelationship == Relationship.Other)
                {
                    var primary = PrimaryBeneficiary.PersonalInfo;
                    acroFields.SetField("PrimaryBeneficiary", primary.FirstName + " " + primary.LastName);
                    acroFields.SetField("PrimaryRelationship", GetRelationName(PrimaryBeneficiary));

                    // flatbuilder.AppendLine("PBENEFINANCE=" + primary.FirstName);
                    //flatbuilder.AppendLine("PBENEINSURANCEYES=X");
                    // flatbuilder.AppendLine("PBENELOSS=");
                    // flatbuilder.AppendLine("PBENEREASON=" + app.PBENEREASON);
                    // flatbuilder.AppendLine("PBENEYES=" + app.PBENEYES);

                    acroFields.SetField("PBeneAddress1", "2613 Elk Horn Drive");
                    acroFields.SetField("PBeneAddress2", "LIttle Elm Texasm 75068");
                    acroFields.SetField("PBeneReason", "God Child");
                    acroFields.SetField("PBeneFinance", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                    acroFields.SetField("PBeneLoss", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                    acroFields.SetField("PBeneInsuranceNo", "X");
                    acroFields.SetField("PBeneNo", "They don't have insurance ");


                    flatbuilder.AppendLine("PrimaryBeneficiary=" + primary.FirstName + " " + primary.LastName);
                    flatbuilder.AppendLine("PBENEADDRESS1=" + "2613 Elk Horn Drive");
                    flatbuilder.AppendLine("PBENEADDRESS2=" + "LIttle Elm Texasm 75068");
                    flatbuilder.AppendLine("PBENEREL=" + "Best Friend");
                    flatbuilder.AppendLine("PBENEREASON=" + "God Child");
                    flatbuilder.AppendLine("PBENEFINANCE=" + "None");
                    flatbuilder.AppendLine("PBENELOSS=" + "None");
                    flatbuilder.AppendLine("PBENEINSURANCENO=" + "X");
                    flatbuilder.AppendLine("PBENENo=" + "They don't have insurance ");



                    // PBENEREL=Best Friend
                    // PBENEREASON=Closer to me than my family members
                    // PBENEFINANCE=No financial responsibilities shared with applicant
                    // PBENELOSS=No financial loss would incur if insured dies
                    // PBENEINSURANCEYES=X
                    // PBENEYES=Giving face amount of life coverage in force for bene insured

                }
                else
                {
                    var primary = PrimaryBeneficiary.PersonalInfo;
                    // todo confirm that the child/granchild can be primary if there is one benficiary  
                    // to clarify the requriment docs indicate that it my be possible to find multiple primary benficiary
                    acroFields.SetField("PrimaryBeneficiary", primary.FirstName + " " + primary.LastName);
                    acroFields.SetField("PrimaryRelationship", PrimaryBeneficiary.Relationships);

                    flatbuilder.AppendLine("PRIMARYBENEFICIARY=" + primary.FirstName + " " + primary.LastName);
                    if (RelationShipExtension.FamilyRelations().Contains(PrimaryBeneficiary.PrimaryRelationship))
                    {
                        flatbuilder.AppendLine("PRIMARYRELATIONSHIP=Family Member");
                        flatbuilder.AppendLine("PFAMILYMEMBER=" + PrimaryBeneficiary.Relationships);
                    }
                    else
                        flatbuilder.AppendLine("PRIMARYRELATIONSHIP=" + PrimaryBeneficiary.Relationships);

                }

            }
            else if (PrimaryBeneficiaries.Length > 1)
            {
                acroFields.SetField("PrimaryBeneficiary", "Multi Bene - See Addendum");
                acroFields.SetField("PrimaryRelationship", "Multiple Beneficiaries");
                flatbuilder.AppendLine("PRIMARYBENEFICIARY=Multi");
                flatbuilder.AppendLine("PRIMARYRELATIONSHIP=" + "Multiple Beneficiaries");

                // flatbuilder.AppendLine("PRIMARYRELATIONSHIP=");
                var fullPersentageDistribution = 100;
                for (int i = 1; i <= PrimaryBeneficiaries.Length; i++)
                {
                    var primary = PrimaryBeneficiaries[i - 1];
                    if (primary.Percentage == 0)
                    {
                        primary.Percentage = (int)Math.Floor(100f / PrimaryBeneficiaries.Length);
                    }
                    if (i == PrimaryBeneficiaries.Length)
                    {
                        primary.Percentage = fullPersentageDistribution;
                    }
                    fullPersentageDistribution -= primary.Percentage;
                    if (fullPersentageDistribution < 0)
                    {
                        primary.Percentage = Math.Max(0, primary.Percentage + fullPersentageDistribution);
                    }
                    // Percentage 50
                    // fullPersentageDistribution -10
                    flatbuilder.AppendLine("MPBENENAME" + i + "=" + primary.PersonalInfo.FirstName + " " + primary.PersonalInfo.LastName);
                    flatbuilder.AppendLine("MPBRELATIONSHIP" + i + "=" + GetRelationName(primary));
                    // todo get the percentage fields
                    flatbuilder.AppendLine("MPBENEPERCENT" + i + "=" + primary.Percentage);
                    if (i > 1)
                    {
                        flatbuilder.AppendLine("MPBANOTHER" + i + "=" + (i == PrimaryBeneficiaries.Length ? "No" : "Yes"));
                    }

                    // flatbuilder.AppendLine("GCIRSEX" + i + "=Male");
                }
            }
            // page 35
            // done explanation needed for Contingent Beneficiary:
            var ContingentBeneficiaries = app.Application.ContingentBeneficiaries;
            var ContingentBeneficiary = ContingentBeneficiaries.FirstOrDefault();
            if (ContingentBeneficiaries.Count == 1)
            {

                var contingent = ContingentBeneficiary.PersonalInfo;


                if (ContingentBeneficiary.PrimaryRelationship == Relationship.Trust)
                {
                    acroFields.SetField("ContingentBeneficiary", "Trust - See Addendum");
                    acroFields.SetField("ContingentRelationship", "Trust");

                    flatbuilder.AppendLine("CONTINGENTBENEFICIARY=Trust");
                    flatbuilder.AppendLine("CONTINGENTRELATIONSHIP=Trust");
                    flatbuilder.AppendLine("CTRUSTNAME=" + CTRUSTNAME);
                    flatbuilder.AppendLine("CTRUSTEENAME=" + CTRUSTEENAME);
                    flatbuilder.AppendLine("CTRUSTCONTACT=" + CTRUSTCONTACT);

                    // CONTINGENTBENEFICIARY=Trust
                    // CONTINGENTRELATIONSHIP=Trust
                    // CTRUSTNAME=Name of Trust
                    // CTRUSTEENAME=Trustee Name
                    // CTRUSTCONTACT=3909 Trust Information Anywhere Tx 76710

                }
                else if (ContingentBeneficiary.PrimaryRelationship == Relationship.Other)
                {
                    acroFields.SetField("ContingentBeneficiary", contingent.FirstName + " " + contingent.LastName);
                    acroFields.SetField("ContingentRelationship", "Best Friend");
                    // flatbuilder.AppendLine("CBENEFINANCE=" + primary.FirstName);
                    //flatbuilder.AppendLine("CBENEINSURANCEYES=X");
                    // flatbuilder.AppendLine("CBENELOSS=");
                    // flatbuilder.AppendLine("CBENEREASON=" + app.CBENEREASON);
                    //flatbuilder.AppendLine("CBENEREL=" + "Best Friend");
                    // flatbuilder.AppendLine("CBENEYES=" + app.CBENEYES); 


                    acroFields.SetField("CBeneAddress1", "2613 Elk Horn Drive");
                    acroFields.SetField("CBeneAddress2", "LIttle Elm Texasm 75068");
                    acroFields.SetField("CBeneReason", "God Child");
                    acroFields.SetField("CBeneFinance", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                    acroFields.SetField("CBeneLoss", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                    acroFields.SetField("CBeneInsuranceNo", "X");
                    acroFields.SetField("CBeneNo", "They don't have insurance ");


                    flatbuilder.AppendLine("CONTINGENTBENEFICIARY=" + contingent.FirstName + " " + contingent.LastName);
                    flatbuilder.AppendLine("CBENEADDRESS1=" + "2613 Elk Horn Drive");
                    flatbuilder.AppendLine("CBENEADDRESS2=" + "LIttle Elm Texasm 75068");
                    flatbuilder.AppendLine("CBENEREL=" + "Best Friend");
                    flatbuilder.AppendLine("CBENEREASON=" + "God Child");
                    flatbuilder.AppendLine("CBENEFINANCE=" + "Something really long about all of the things that they have financial information about THis is a second line test to make sure that you can see that this works. ");
                    flatbuilder.AppendLine("CBENELOSS=" + "Something really long about all of the things that they have financial information about  THis is a second line test to make sure that you can see that this works. ");
                    flatbuilder.AppendLine("CBENEINSURANCENO=" + "X");
                    flatbuilder.AppendLine("CBENENo=" + "They don't have insurance ");


                }
                else
                {
                    // todo confirm that the child/granchild can be primary if there is one benficiary  
                    // to clarify the requriment docs indicate that it my be possible to find multiple primary benficiary
                    acroFields.SetField("ContingentBeneficiary", contingent.FirstName + " " + contingent.LastName);
                    acroFields.SetField("ContingentRelationship", GetRelationName(ContingentBeneficiary));

                    flatbuilder.AppendLine("CONTINGENTBENEFICIARY=" + contingent.FirstName + " " + contingent.LastName);

                    if (RelationShipExtension.FamilyRelations().Contains(ContingentBeneficiary.PrimaryRelationship))
                    {
                        flatbuilder.AppendLine("CONTINGENTRELATIONSHIP=Family Member");
                        flatbuilder.AppendLine("CFAMILYMEMBER=" + GetRelationName(ContingentBeneficiary));
                    }
                    else
                        flatbuilder.AppendLine("CONTINGENTRELATIONSHIP=" + GetRelationName(ContingentBeneficiary));

                }

            }
            else if (ContingentBeneficiaries.Count > 1)
            {
                acroFields.SetField("ContingentBeneficiary", "Multi Bene - See Addendum");
                acroFields.SetField("ContingentRelationship", "Multiple Beneficiaries");
                flatbuilder.AppendLine("CONTINGENTBENEFICIARY=Multi");
                flatbuilder.AppendLine("CONTINGENTRELATIONSHIP=" + "Multiple Beneficiaries");

                // flatbuilder.AppendLine("PRIMARYRELATIONSHIP=");
                var fullPersentageDistribution = 100;
                for (int i = 1; i <= ContingentBeneficiaries.Count; i++)
                {
                    var contingent = ContingentBeneficiaries[i - 1];
                    if (contingent.Percentage == 0)
                    {
                        contingent.Percentage = (int)Math.Floor(100f / ContingentBeneficiaries.Count);
                    }
                    if (i == ContingentBeneficiaries.Count)
                    {
                        contingent.Percentage = fullPersentageDistribution;
                    }
                    fullPersentageDistribution -= contingent.Percentage;
                    if (fullPersentageDistribution < 0)
                    {
                        contingent.Percentage = Math.Max(0, contingent.Percentage + fullPersentageDistribution);
                    }
                    // Percentage 50
                    // fullPersentageDistribution -10
                    flatbuilder.AppendLine("MCBENENAME" + i + "=" + contingent.PersonalInfo.FirstName + " " + contingent.PersonalInfo.LastName);
                    flatbuilder.AppendLine("MCBRELATIONSHIP" + i + "=" + GetRelationName(contingent));
                    // todo get the percentage fields
                    flatbuilder.AppendLine("MCBENEPERCENT" + i + "=" + contingent.Percentage);
                    if (i > 1)
                    {
                        flatbuilder.AppendLine("MCBANOTHER" + i + "=" + (i == ContingentBeneficiaries.Count ? "No" : "Yes"));
                    }

                    // flatbuilder.AppendLine("GCIRSEX" + i + "=Male");
                }

            }
            else
            {

                flatbuilder.AppendLine("CONTINGENTRELATIONSHIP=None");
            }

            // page 39
            // Existing Coverage Information:

            //  app
            //
            // app.Application.p
            // the applicant by default does not has Existing Insurance 
            if (!string.IsNullOrEmpty(appinfo.LifePolicyNumber) && false)
            {
                acroFields.SetField("ExistingInsuranceYes", X);
                flatbuilder.AppendLine("EXISTINGINSURANCEYES=" + X);
                flatbuilder.AppendLine("POLICYNUM=" + appinfo.LifePolicyNumber);
                flatbuilder.AppendLine("COMPANY=" + appinfo.LifePolicyInsuranceCompany);
                flatbuilder.AppendLine("AMOUNTOFCOVERAGE=" + appinfo.LifeCoverageAmount);
                acroFields.SetField("AmountofCoverage", appinfo.LifeCoverageAmount.ToString());
                acroFields.SetField("Company", appinfo.LifePolicyInsuranceCompany);
                acroFields.SetField("PolicyNum", appinfo.LifePolicyNumber.ToString());
            }
            else
            {
                acroFields.SetField("ExistingInsuranceNo", X);
                flatbuilder.AppendLine("EXISTINGINSURANCENO=" + X);
            }

            var RepInsNo = true;
            // non existing xisting Insurance 
            if (RepInsNo)
            {
                flatbuilder.AppendLine("REPINSNO=" + X);
                acroFields.SetField("RepInsNo", X);
            }
            else
            {

                flatbuilder.AppendLine("REPINSYES=" + X);
                acroFields.SetField("RepInsYes", X);

            }
            SetAllFieldStartWith(acroFields, fieldNames, "AgentSignature1", AgentSignature1);
            flatbuilder.AppendLine("AGENTSIGNATURE1=" + agentName);//AgentSignature1
            SetAllFieldStartWith(acroFields, fieldNames, "ProposedInsuredSignature", ProposedInsuredSignature);


            // page 9396
            // ask about neext
            var RepQuestion1 = false;
            var RepQuestion2 = false;

            //flatbuilder.AppendLine("REPQUESTION1=" + (RepQuestion1 ? "Yes" : "No"));
            //flatbuilder.AppendLine("REPQUESTION2=" + (RepQuestion2 ? "Yes" : "No"));
            //SetAllFieldStartWith(acroFields, fieldNames, "RepQuestion1" + (RepQuestion1 ? "Yes" : "No"), X);
            //SetAllFieldStartWith(acroFields, fieldNames, "RepQuestion2" + (RepQuestion2 ? "Yes" : "No"), X);

            //flatbuilder.AppendLine("READNOTICE=No");
            //flatbuilder.AppendLine("APPINITIAL=" + AppInitial);
            SetAllFieldStartWith(acroFields, fieldNames, "AppInitial", AppInitial);

            SetAllFieldStartWith(acroFields, fieldNames, "AppSignature7", AppSignature7);
            SetAllFieldStartWith(acroFields, fieldNames, "AppPrintedName7", AppPrintedName7);



            flatbuilder.AppendLine("AGENTEXISTINGINSURANCE=No");


            flatbuilder.AppendLine("AGENTREPINS=No");

            flatbuilder.AppendLine("PAYORINFO=True");

            // Trustee Fields 


            // Create Addendum pages 

            // Agent Information page
            int total = pdfReader.NumberOfPages + 1;

            if (app.SignatureLocationState == "KS")
            {
                total = Math.Min(total, 5);
            }
            else
            {
                total = Math.Min(total, 4);
            }

            var pagesize = pdfReader.GetPageSize(1);
            pdfStamper.InsertPage(total, pagesize);
            var dc = pdfStamper.GetOverContent(total);
            var canvas = pdfStamper.GetUnderContent(1);

            var tableHeaderFont = FontFactory.GetFont(BaseFont.HELVETICA, 12, Font.BOLD);

            var textContentFont = FontFactory.GetFont(BaseFont.HELVETICA, 11, Font.NORMAL);
            dc.BeginText();
            dc.SetColorFill(BaseColor.Blue);
            dc.SetFontAndSize(tableHeaderFont.BaseFont, 16);
            var text = "Addendum";
            var localHeighCursor = 35;
            // put the alignment and coordinates here
            dc.ShowTextAligned(Element.ALIGN_CENTER, text, pagesize.Width / 2, pagesize.Height - localHeighCursor, 0);
            // canvas.ShowTextAligned(PdfContentByte.ALIGN_CENTER, text, (pagesize.Left + pagesize.Right) / 2, 50, 0);

            dc.SetColorFill(BaseColor.Black);
            dc.SetFontAndSize(tableHeaderFont.BaseFont, 12);
            text = "e-Sign footprint (all time stamps are in server time, central standard)";
            localHeighCursor += 58;// 140
            dc.ShowTextAligned(Element.ALIGN_CENTER, text, pagesize.Width / 2, pagesize.Height - localHeighCursor, 0);

            text = "e-Sign footprint (all time stamps are in server time, central standard)";
            localHeighCursor += 80;
            if (PrimaryBeneficiary != null)
            {
                if (PrimaryBeneficiary.PrimaryRelationship == Relationship.Trust)
                {
                    localHeighCursor += 20;
                    text = "Primary Beneficiary Trust Details";
                    dc.ShowTextAligned(Element.ALIGN_CENTER, text, pagesize.Width / 2, pagesize.Height - localHeighCursor, 0);
                    dc.SetFontAndSize(textContentFont.BaseFont, 10);
                    text = "Name of Trust:" + PTRUSTNAME;
                    localHeighCursor += 20;
                    dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);

                    text = "Name of Trustee:" + PTRUSTEENAME;
                    localHeighCursor += 20;
                    dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);

                    text = "Contact Information for the Trust:" + PTRUSTCONTACT;
                    localHeighCursor += 20;
                    dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);
                    localHeighCursor += 20;

                }
            }
            if (ContingentBeneficiary != null)
            {
                if (ContingentBeneficiary.PrimaryRelationship == Relationship.Trust)
                {
                    localHeighCursor += 20;
                    text = "Contingent Beneficiary Trust Details";
                    dc.ShowTextAligned(Element.ALIGN_CENTER, text, pagesize.Width / 2, pagesize.Height - localHeighCursor, 0);

                    dc.SetFontAndSize(textContentFont.BaseFont, 10);


                    text = "Name of Trust:" + CTRUSTNAME;
                    localHeighCursor += 20;
                    dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);

                    text = "Name of Trustee:" + CTRUSTEENAME;
                    localHeighCursor += 20;
                    dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);

                    text = "Contact Information for the Trust:" + CTRUSTCONTACT;
                    localHeighCursor += 20;
                    dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);
                    localHeighCursor += 20;

                }
            }
            dc.SetColorFill(BaseColor.Black);
            dc.SetFontAndSize(textContentFont.BaseFont, 10);
            if (covidQuestion1)
            {
                var answerCovid90Day = covid90Day1 ? "Yes" : "No";
                var answercovidEffects1 = covidEffects1 ? "Yes" : "No";

                text = "Covid19 Question 1a: Has it been 90 days or longer since you fully recovered from Covid-19? " + answerCovid90Day;
                localHeighCursor += 20;
                dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);

                text = "Covid19 Question 1b: Do you have any residual effects or complications form COVID-19? " + answercovidEffects1;
                localHeighCursor += 20;
                dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);
            }

            if (covidQuestion2)
            {
                var answercovid290Day2 = covid290Day2 ? "Yes" : "No";
                var answercovidEffects2 = covidEffects2 ? "Yes" : "No";

                text = "Covid19 Question 2a: Has it been 90 days or longer since you fully recovered from Covid-19? " + answercovid290Day2;
                localHeighCursor += 20;
                dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);

                text = "Covid19 Question 2b: Do you have any residual effects or complications from COVID-19? " + answercovidEffects2;
                localHeighCursor += 20;
                dc.ShowTextAligned(Element.ALIGN_LEFT, text, 50, pagesize.Height - localHeighCursor, 0);
            }

            dc.SetFontAndSize(tableHeaderFont.BaseFont, 12);
            if (PrimaryBeneficiaries.Length > 1)
            {
                localHeighCursor += 30;
                text = "Beneficiary Details";
                dc.ShowTextAligned(Element.ALIGN_CENTER, text, pagesize.Width / 2, pagesize.Height - localHeighCursor, 0);
                localHeighCursor += 10;
            }
            dc.EndText();

            var agentTable = new PdfPTable(3);
            // agentTable.SetWidths(new[] { 10, 2 });
            agentTable.TotalWidth = pagesize.Width - 130;
            // agentTable.DefaultCell.Border = Rectangle.NO_BORDER;
            agentTable.DefaultCell.FixedHeight = 20;
            agentTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            agentTable.AddCell(new Paragraph("Agent Number", tableHeaderFont));
            agentTable.AddCell(new Paragraph("Agent Name", tableHeaderFont));
            agentTable.AddCell(new Paragraph("Agent % of Case", tableHeaderFont));
            agentTable.AddCell(new Paragraph(agentNumber));
            agentTable.AddCell(new Paragraph(agentName));
            agentTable.AddCell(new Paragraph("100"));

            agentTable.WriteSelectedRows(0, -1, 0, -1, 60, pagesize.Height - 40, dc);
            // pdfSampleTAble().WriteSelectedRows(0, -1, 0, -1, 60, 800, dc);
            agentTable = new PdfPTable(6);
            // agentTable.SetWidths(new[] { 10, 2 });
            agentTable.TotalWidth = pagesize.Width - 130;
            // agentTable.DefaultCell.Border = Rectangle.NO_BORDER;
            // agentTable.DefaultCell.FixedHeight = 20;
            agentTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            agentTable.AddCell(new Paragraph("Party", tableHeaderFont));
            agentTable.AddCell(new Paragraph("Email", tableHeaderFont));
            agentTable.AddCell(new Paragraph("Agent IP", tableHeaderFont));
            agentTable.AddCell(new Paragraph("Signature IP", tableHeaderFont));
            agentTable.AddCell(new Paragraph("Time Stamp Request", tableHeaderFont));
            agentTable.AddCell(new Paragraph("Time Stamp Signed", tableHeaderFont));

            // agentTable.DefaultCell.FixedHeight = 65;
            agentTable.AddCell(new Paragraph(Party));
            agentTable.AddCell(new Paragraph(addendumEmail));
            agentTable.AddCell(new Paragraph(AgentIP));
            agentTable.AddCell(new Paragraph(SignatureIP));
            agentTable.AddCell(new Paragraph(TimeStampRequest.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)));
            agentTable.AddCell(new Paragraph(TimeStampSigned.ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)));

            agentTable.WriteSelectedRows(0, -1, 0, -1, 60, pagesize.Height - 100, dc);
            // createing the PrimaryBeneficiaries.Length
            if (PrimaryBeneficiaries.Length > 1)
            {
                agentTable = new PdfPTable(4);
                // agentTable.SetWidths(new[] { 10, 2 });
                agentTable.TotalWidth = pagesize.Width - 130;
                // agentTable.DefaultCell.Border = Rectangle.NO_BORDER;
                // agentTable.DefaultCell.FixedHeight = 20;
                agentTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                agentTable.AddCell(new Paragraph("Primary Name", tableHeaderFont));
                // agentTable.AddCell(new Paragraph("Gender", tableHeaderFont));
                // agentTable.AddCell(new Paragraph("DOB", tableHeaderFont));
                agentTable.AddCell(new Paragraph("SSN", tableHeaderFont));
                agentTable.AddCell(new Paragraph("Relationship", tableHeaderFont));
                agentTable.AddCell(new Paragraph("Percent", tableHeaderFont));
                for (int i = 0; i < PrimaryBeneficiaries.Length; i++)
                {
                    var beneficiary = PrimaryBeneficiaries[i];
                    var fm = beneficiary.PersonalInfo;
                    agentTable.AddCell(new Paragraph(fm.FirstName + " " + fm.LastName));
                    // agentTable.AddCell(new Paragraph(fm.Gender == Gender.Male ? "Male" : "Female"));
                    // agentTable.AddCell(new Paragraph(fm.DateOfBirth.ToString("M/d/yyyy")));
                    agentTable.AddCell(new Paragraph(""));//FormatSSN(fm.SSN)  nea to be empty
                    agentTable.AddCell(new Paragraph(GetRelationName(beneficiary)));
                    agentTable.AddCell(new Paragraph(beneficiary.Percentage.ToString()));

                }
                agentTable.WriteSelectedRows(0, -1, 0, -1, 60, pagesize.Height - localHeighCursor, dc);
                localHeighCursor += (PrimaryBeneficiaries.Length + 1) * 30;
            }
            if (ContingentBeneficiaries.Count > 1)
            {
                agentTable = new PdfPTable(4);
                // agentTable.SetWidths(new[] { 10, 2 });
                agentTable.TotalWidth = pagesize.Width - 130;
                // agentTable.DefaultCell.Border = Rectangle.NO_BORDER;
                // agentTable.DefaultCell.FixedHeight = 20;
                agentTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                agentTable.AddCell(new Paragraph("Contingent Name", tableHeaderFont));
                // agentTable.AddCell(new Paragraph("Gender", tableHeaderFont));
                // agentTable.AddCell(new Paragraph("DOB", tableHeaderFont));
                agentTable.AddCell(new Paragraph("SSN"));// FormatSSN(fm.SSN) nea to be empty
                agentTable.AddCell(new Paragraph("Relationship", tableHeaderFont));
                agentTable.AddCell(new Paragraph("Percent", tableHeaderFont));
                for (int i = 0; i < ContingentBeneficiaries.Count; i++)
                {
                    var beneficiary = ContingentBeneficiaries[i];
                    var fm = beneficiary.PersonalInfo;
                    agentTable.AddCell(new Paragraph(fm.FirstName + " " + fm.LastName));
                    // agentTable.AddCell(new Paragraph(fm.Gender == Gender.Male ? "Male" : "Female"));
                    // agentTable.AddCell(new Paragraph(fm.DateOfBirth.ToString("M/d/yyyy")));
                    agentTable.AddCell(new Paragraph(""));
                    agentTable.AddCell(new Paragraph(GetRelationName(beneficiary)));
                    agentTable.AddCell(new Paragraph(beneficiary.Percentage.ToString()));

                }
                agentTable.WriteSelectedRows(0, -1, 0, -1, 60, pagesize.Height - localHeighCursor, dc);
            }
            dc.SaveState();

            pdfReader.RemoveUsageRights();
            pdfStamper.FormFlattening = true;
            pdfStamper.Close();
            fs.Flush();
            fs.Close();

            // todo create amendment page 




            var AA9820CList = app.Application.ContingentBeneficiaries.Where(k => k.PrimaryRelationship == Relationship.Other).ToArray();
            var AA9820PList = app.Application.Beneficiaries.Where(k => k.PrimaryRelationship == Relationship.Other).ToArray();
            if (AA9820CList.Length > 0 || AA9820PList.Length > 0)
            {
                var distFile = applicationPdfFileName;
                var JoinableFiles = new List<string>();
                var tmp = applicationPdfFileName + "_join.pdf";
                JoinableFiles.Add(tmp);
                File.Move(distFile, tmp, true);
                int k = 0;

                for (int i = 1; i <= AA9820PList.Length; i++)
                {


                    var beneficiary = AA9820PList[i - 1];
                    var distFom_AA9820P = applicationPdfFileName + i + "_AA9820P.pdf";
                    FillAA9820Page(AppNumber, ProposedInsuredSignature, AA9820P_Form, distFom_AA9820P, applicationDateShort, beneficiary, flatbuilder);


                    JoinableFiles.Add(distFom_AA9820P);
                }
                for (int i = 1; i <= AA9820CList.Length; i++)
                {
                    var beneficiary = AA9820CList[i - 1];
                    var distFom_AA9820C = applicationPdfFileName + i + "_AA9820C.pdf";
                    FillAA9820Page(AppNumber, ProposedInsuredSignature, AA9820C_Form, distFom_AA9820C, applicationDateShort, beneficiary, flatbuilder, "CB");

                    JoinableFiles.Add(distFom_AA9820C);
                }
                MergeMultiplePDF(JoinableFiles, distFile);
                tmpFiles.AddRange(JoinableFiles);
            }

            // delete all intermediate files
            foreach (var item in tmpFiles)
            {
                File.Delete(item);
            }
            await File.WriteAllTextAsync(applicationFlatFileName, flatbuilder.ToString());
            return (applicationFlatFileName, applicationPdfFileName);
        }

        private static void DeleteUnsedPages(PdfReader pdfReader, HashSet<int> PageToDelete)
        {
            if (PageToDelete.Count == 0)
            {
                return;
            }
            var allPages = new ArrayList(pdfReader.NumberOfPages - 1);
            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
            {
                if (!PageToDelete.Contains(i)) allPages.Add(i);
            }

            pdfReader.SelectPages(allPages);
        }

        // fill AA9820(-p -c ) form file  use prifix ="BP" for AA9820-P or "CB" For AA9820-C form
        private static void FillAA9820Page(string AppNumber, string ProposedInsuredSignature, string template, string outputFile, string applicationDateShort, FamilyOrBeneficiary beneficiary, StringBuilder flatbuilder, string prefix = "PB")
        {

            PdfReader pdfReader = new PdfReader(template);
            var newFile = outputFile;
            using var fs = new FileStream(newFile, FileMode.Create);
            var pdfStamper = new PdfStamper(pdfReader, fs);
            AcroFields acroFields = pdfStamper.AcroFields;
            var fm = beneficiary.PersonalInfo;
            acroFields.SetField("ApplicationDate", applicationDateShort);
            acroFields.SetField("AppNumber", AppNumber);
            acroFields.SetField("BirthDate", fm.DateOfBirth.ToString("M/d/yyyy"));
            acroFields.SetField("Height", fm.HeightFt + "'" + fm.HeightIn);
            acroFields.SetField(prefix + "eneAddress1", fm.Address1);
            acroFields.SetField(prefix + "eneAddress2", fm.Address2);
            acroFields.SetField(prefix + "eneRel", "Best Friend");
            acroFields.SetField("ProposedInsuredSignature", ProposedInsuredSignature);
            acroFields.SetField("SLSName", fm.FirstName + " " + fm.LastName);
            acroFields.SetField("SSN", FormatSSN(fm.SSN));
            acroFields.SetField("Weight", ((int)fm.Weight).ToString());
            acroFields.SetField("TobaccoNo", "X");
            acroFields.SetField("Weight", ((int)fm.Weight).ToString());
            acroFields.SetField("Weight", ((int)fm.Weight).ToString());

            if (prefix == "PB")
            {
                acroFields.SetField("PrimaryBeneficiary", beneficiary.PersonalInfo.FirstName + " " + beneficiary.PersonalInfo.LastName);

                acroFields.SetField("PBeneAddress1", "2613 Elk Horn Drive");
                acroFields.SetField("PBeneAddress2", "LIttle Elm Texasm 75068");
                acroFields.SetField("PBeneReason", "God Child");
                acroFields.SetField("PBeneFinance", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                acroFields.SetField("PBeneLoss", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                acroFields.SetField("PBeneInsuranceNo", "X");
                acroFields.SetField("PBeneNo", "They don't have insurance ");

                //flatbuilder.AppendLine("PBENEADDRESS1=" + "2613 Elk Horn Drive");
                //flatbuilder.AppendLine("PBENEADDRESS2=" + "LIttle Elm Texasm 75068");
                //flatbuilder.AppendLine("PBENEREL=" + "Other");
                //flatbuilder.AppendLine("PBENEREASON=" + "God Child");
                //flatbuilder.AppendLine("PBENEFINANCE=" + "None");
                //flatbuilder.AppendLine("PBENELOSS=" + "None");
                //flatbuilder.AppendLine("PBENEINSURANCENO=" + "X");
                //flatbuilder.AppendLine("PBENENo=" + "They don't have insurance ");
            }
            else
            {
                acroFields.SetField("ContingentBeneficiary", beneficiary.PersonalInfo.FirstName + " " + beneficiary.PersonalInfo.LastName);

                acroFields.SetField("CBeneAddress1", "2613 Elk Horn Drive");
                acroFields.SetField("CBeneAddress2", "LIttle Elm Texasm 75068");
                acroFields.SetField("CBeneReason", "God Child");
                acroFields.SetField("CBeneFinance", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                acroFields.SetField("CBeneLoss", "Something really long about all of the things that they have financial information about " +
                        "/n THis is a second line test to make sure that you can see that this works. ");
                acroFields.SetField("CBeneInsuranceNo", "X");
                acroFields.SetField("CBeneNo", "They don't have insurance ");

                //flatbuilder.AppendLine("CCBENEADDRESS1=" + "2613 Elk Horn Drive");
                //flatbuilder.AppendLine("CBENEADDRESS2=" + "LIttle Elm Texasm 75068");
                //flatbuilder.AppendLine("CBENEREL=" + "Other");
                //flatbuilder.AppendLine("CBENEREASON=" + "God Child");
                //flatbuilder.AppendLine("CBENEFINANCE=" + "None");
                //flatbuilder.AppendLine("CBENELOSS=" + "None");
                //flatbuilder.AppendLine("CBENEINSURANCENO=" + "X");
                //flatbuilder.AppendLine("CBENENo=" + "They don't have insurance ");
            }
            pdfReader.RemoveUsageRights();
            pdfStamper.FormFlattening = true;
            pdfStamper.Close();

            fs.Flush();
            fs.Close();

        }

        private static string JoinAddiontalBeneficiariesPages(string applicationSate, FamilyOrBeneficiary[] PrimaryBeneficiaries, string applicationPdfFileName, string templateFile, string stateTemplateFile, List<string> tmpFiles)
        {
            if (PrimaryBeneficiaries.Length > 0)
            {

                var benTmplates = GeneratePdfBeneficiariesTemplates(PrimaryBeneficiaries.Length, applicationPdfFileName, applicationSate);
                tmpFiles.Add(templateFile);
                var files = new List<string>() { stateTemplateFile };
                files.AddRange(benTmplates);
                tmpFiles.AddRange(benTmplates);
                MergeMultiplePDF(files, templateFile);
            }
            else
            {
                templateFile = stateTemplateFile;
            }

            return templateFile;
        }

        private static string GetRelationName(FamilyOrBeneficiary SeparatePolicyOwner)
        {
            switch (SeparatePolicyOwner?.PrimaryRelationship)
            {
                case Relationship.Primary:
                    return "Primary";
                case Relationship.Spouse:
                case Relationship.SeparatePolicyOwnerSpouse:
                    return "Spouse";
                case Relationship.ChildDaughter:
                    return "Child daughter";
                case Relationship.ChildSon:
                    return "Child son";
                case Relationship.Brother:
                    return "Brother";
                case Relationship.Sister:
                    return "Sister";
                case Relationship.Cousin:
                    return "Cousin";
                case Relationship.Aunt:
                    return "Aunt";
                case Relationship.Uncle:
                    return "Uncle";
                case Relationship.GrandFather:
                    return "Grand father";
                case Relationship.GrandMother:
                    return "Grand mother";
                case Relationship.GrandParent:
                    return "Grand parent";
                case Relationship.GrandChild:
                    return "Grand child";
                case Relationship.Niece:
                    return "Niece";
                case Relationship.Nephew:
                    return "Nephew";
                case Relationship.Child:
                    return "Child";
                case Relationship.Relative:
                    return "Relative";
                case Relationship.Other:
                    return "Other";
                case Relationship.Estate:
                    return "Estate";
                case Relationship.LifePartner:
                case Relationship.SeparatePolicyOwnerLifePartner:
                    return "Life Partner";
                case Relationship.Trust:
                    return "Trust";
                case Relationship.SeparatePolicyOwnerFiance:
                case Relationship.Fiance:
                    return "Fiance";
                case Relationship.SeparatePolicyOwnerChild:
                    return "Child";
                case Relationship.Father:
                    return "Father";
                case Relationship.Mother:
                    return "Mother";
                default:
                    return "Other";
            }

        }

        public static string FormatSSN(string ssn)
        {
            if (string.IsNullOrEmpty(ssn)) return "000-00-00000";
            return ssn.Substring(0, 3) + "-" + ssn.Substring(4, 2) + "-" + ssn.Substring(5);
        }
        public static string FormatHeight(int n)
        {
            var str = n.ToString("D9");
            return str.Substring(0, 1) + "'" + str.Substring(1);
        }
        public static string FormatPhone(int n)
        {
            var str = n.ToString("D9");
            return str.Substring(0, 3) + "-" + str.Substring(4, 2) + "-" + str.Substring(5);
        }
        /// <summary>
        /// Set all fields that field name start with fieldName
        /// </summary>
        /// <param name="acroFields"></param>
        /// <param name="fielNames"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        private static void SetAllFieldStartWith(AcroFields acroFields, HashSet<string> fielNames, string fieldName, string fieldValue)
        {
            foreach (var item in fielNames.Where(k => k == fieldName || k.ToLower().StartsWith(fieldName.ToLower() + "_")))
            {

                acroFields.SetField(item, fieldValue);
            }
        }

        private static string GetTemplateFilePath(string applicationSate)
        {
            var di = new DirectoryInfo(ApplicationTemplateFolderPath + "/" + applicationSate);
            var templateFile = di.Exists ? di.EnumerateFiles("*.pdf").FirstOrDefault() : null;
            if (templateFile?.Exists != true)
            {
                throw new Exception("The pdf template file does not exist for " + applicationSate);
            }
            string fullpath = templateFile.FullName;
            return fullpath;
        }
        // you need to create multiple files for each benifi
        private static List<string> GeneratePdfBeneficiariesTemplates(int count, string distinationFileName, string state)
        {
            var paths = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                var path = Path.Join(ApplicationOutputFolderPath, Path.GetFileNameWithoutExtension(distinationFileName) + "-ben-" + i + ".pdf");

                PdfReader reader = new PdfReader(GetBeneficiariesTemplateFilePath(state));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    PdfStamper stamper = new PdfStamper(reader, fs);
                    AcroFields fields = stamper.AcroFields;
                    var fielNames = fields.Fields.OfType<System.Collections.DictionaryEntry>().Select(k => k.Key.ToString());

                    foreach (var item in fielNames.ToList())
                    {

                        fields.RenameField(item, ("BNF" + i + item).Trim());
                    }
                    stamper.Close();
                    fs.Flush();
                    paths.Add(path);
                }
            }
            return paths;
        }
        public static void MergeMultiplePDF(IEnumerable<string> PDFfileNames, string OutputFile)
        {
            // Create document object  
            var PDFdoc = new iTextSharp.text.Document();
            // Create a object of FileStream which will be disposed at the end  
            using (System.IO.FileStream MyFileStream = new System.IO.FileStream(OutputFile, System.IO.FileMode.Create))
            {
                // Create a PDFwriter that is listens to the Pdf document  
                iTextSharp.text.pdf.PdfCopy PDFwriter = new iTextSharp.text.pdf.PdfCopy(PDFdoc, MyFileStream);
                if (PDFwriter == null)
                {
                    return;
                }
                // Open the PDFdocument  
                PDFdoc.Open();
                foreach (string fileName in PDFfileNames)
                {
                    // Create a PDFreader for a certain PDFdocument  
                    iTextSharp.text.pdf.PdfReader PDFreader = new iTextSharp.text.pdf.PdfReader(fileName);
                    PDFreader.ConsolidateNamedDestinations();
                    // Add content  
                    for (int i = 1; i <= PDFreader.NumberOfPages; i++)
                    {
                        iTextSharp.text.pdf.PdfImportedPage page = PDFwriter.GetImportedPage(PDFreader, i);
                        PDFwriter.AddPage(page);
                    }
                    var form = PDFreader.AcroForm;
                    if (form != null)
                    {
                        PDFwriter.CopyAcroForm(PDFreader);
                    }
                    // Close PDFreader  
                    PDFreader.Close();
                }
                // Close the PDFdocument and PDFwriter  
                PDFwriter.Close();
                PDFdoc.Close();
            }// Disposes the Object of FileStream  
        }
        private static string GetBeneficiariesTemplateFilePath(string applicationSate)
        {
            // todo check if there is a type for each State
            var di = new DirectoryInfo(ApplicationBeneficiariesTemplateFolderPath);//+ "/" + applicationSate);
            var templateFile = di.Exists ? di.EnumerateFiles("*.pdf").FirstOrDefault() : null;
            if (templateFile?.Exists != true)
            {
                throw new Exception("The pdf template file does not exist for " + applicationSate);
            }
            string fullpath = templateFile.FullName;
            return fullpath;
        }
        public static string GetEnumDescription(Enum enumValue)
        {
            return enumValue.GetType()
                       .GetMember(enumValue.ToString())
                       .FirstOrDefault()?
                       .GetCustomAttribute<DescriptionAttribute>()?
                       .Description ?? string.Empty;
        }

        public async Task<IEnumerable<SeniorChoiceForms>> GetSeniorChoiceForms()
        {
            return JsonConvert.DeserializeObject<IEnumerable<SeniorChoiceForms>>(
                        await File.ReadAllTextAsync(SeniorChoiceFormsConfigPath)
                       );
        }



        public class SeniorChoiceForms
        {
            public string ProductCode { get; set; }
            public string CompanyCode { get; set; }
            public string AppConditionalReceipt { get; set; }
            public string State { get; set; }
            public string ConditionalReceiptSeparate { get; set; }
            public string Addendum { get; set; }
            public string ECheckBankAuth { get; set; }
            public string Hipaa { get; set; }
            public string TerminalIllnessRider { get; set; }
            public string ConfinedCare { get; set; }
            public string Replacement9396 { get; set; }
            public string Replacement { get; set; }
            public string Sales { get; set; }
            public string AgentSaleDisclosure { get; set; }
            public string Designee { get; set; }
            public string PaDisclosure { get; set; }
            public string PrimaryBene { get; set; }
            public string ContingentBene { get; set; }
            public string Covid19 { get; set; }
        }

    }
}