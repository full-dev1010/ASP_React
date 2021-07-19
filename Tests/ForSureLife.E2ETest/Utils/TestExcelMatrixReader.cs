
#define MYTEST


using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using ClosedXML.Excel;
using System.IO;
using Humanizer;
using ForSureLife.repo.Models.Enroll;
using ForSureLife.repo;
using System;
using System.Linq;
using ForSureLife.Models.Enums;
using ForSureLife.Models.DTO;
using Bogus;
using Bogus.Extensions.UnitedStates;

namespace ForSureLife.E2ETest
{
    public static class TestExcelMatrixReader
    {

        public partial class ExcelApplicatoinData
        {
            public string MyCaseForCheckingModal { get; set; }
            public string Index { get; set; }
            public string YourKCase { get; set; }
            public string Co { get; set; }
            public string SigningCity { get; set; }
            public string SigningState { get; set; }
            public string NameExpectedFormVariations { get; set; }
            public string Dob { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string Tobacco { get; set; }
            public string Plan { get; set; }
            public string AcceptAnyPlanCheckBox { get; set; }
            public string Mode { get; set; }
            public string Face { get; set; }
            public string ModalPremiumShouldCalculateOutToThisAmount { get; set; }
            public string HealthQuestions { get; set; }
            public string CovidQuestionsYes { get; set; }
            public string Method { get; set; }
            public string IfBankSocSecurityChoice { get; set; }
            public string IfBankRequestedDraftDay { get; set; }
            public string IfBankCheckingOrSavings { get; set; }
            public string LiveAtZipCode { get; set; }
            public string LiveAtCity { get; set; }
            public string LiveAtState { get; set; }
            public string ZipCity { get; set; }
            public string AnyStateOfBirthOrForeign { get; set; }
            public string PrimaryBeneRelationship { get; set; }
            public string ContingentBeneRelationship { get; set; }
            public string ExistingInsurance { get; set; }
            public string IfDesigneeStateDesignate { get; set; }
            public string RidersNotInThisProject { get; set; }
            public string ChildrenUnitsNotInThisProject { get; set; }
            public string GrandChildrenCountUnitNotInThisProject { get; set; }
            public string OwnerAlwaysInsured { get; set; }
            public string OwnerRelationshipNotInThisProject { get; set; }
            public string PayorNotInThisProject { get; set; }

            public string Mode324ClientOnlyDoingM { get; set; }

            public string Zipcode { get; set; }


        }
        public static string CleanColumnName(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            var ret = new StringBuilder();
            foreach (var c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    ret.Append(c);
                }
                else ret.Append(" ");
            }
            return ret.ToString().ToLower().Pascalize();
        }
        public static List<Tuple<AAFinalExpense, ApplicationDto>> ReadTestData()
        {
            var path = "./Assets/SeniorChoice-Testing-Matrix.xlsx";
            var ret = new List<List<string>>();
            var dic = new List<Dictionary<string, string>>();
            using (var excelWorkbook = new XLWorkbook(path))
            {
                var sheet = excelWorkbook.Worksheet(1);
                var nonEmptyDataRows = sheet.RowsUsed();
                var n = sheet.RangeUsed();
                var header = new List<string>();
                for (int j = 1; j <= n.ColumnCount(); j++)
                {
                    header.Add(CleanColumnName(sheet.Cell(1, j).Value?.ToString()?.Trim())?.Trim());
                }
                int index = 0;
                for (int i = 2; i <= n.RowCount(); i++)
                {
                    var r = new List<string>();
                    var d = new Dictionary<string, string>();


                    for (int j = 1; j <= n.ColumnCount(); j++)
                    {
                        var v = sheet.Cell(i, j).Value?.ToString()?.Trim();
                        r.Add(v);
                        d.TryAdd(header[j - 1], v);
                    }
                    if (!string.IsNullOrEmpty(d["NameExpectedFormVariations"]))
                    {
                        dic.Add(d);
                        d.Add("Index", (index++).ToString());
                        ret.Add(r);

                    }
                }
            }

            var json = System.Text.Json.JsonSerializer.Serialize(dic, new JsonSerializerOptions { WriteIndented = true, });
            var data = System.Text.Json.JsonSerializer.Deserialize<List<ExcelApplicatoinData>>(json);

            try
            {
                var zipDic = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText("./Assets/SeniorChoice-Testing-Matrix-states.json"));

                foreach (var row in data)
                {
                    if (zipDic.ContainsKey(row.LiveAtZipCode))
                    {
                        row.LiveAtState = zipDic[row.LiveAtZipCode]["state"];
                        row.LiveAtCity = zipDic[row.LiveAtZipCode]["city"];
                    }
                }
            }
            catch (System.Exception)
            {

            }
            File.WriteAllText("./Assets/SeniorChoice-Testing-Matrix.json", System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true, }));

            return data
                .Where(k => !string.IsNullOrWhiteSpace(k.NameExpectedFormVariations))
                .Select(k => ReadTestDataAAFinalExpense(k)).ToList();
        }

        static Faker faker = new Faker();
        public static Tuple<AAFinalExpense, ApplicationDto> ReadTestDataAAFinalExpense(ExcelApplicatoinData row)
        {
            try { 
            var nameExpectedFormVariations = row.NameExpectedFormVariations.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(k => k.Trim());
            var names = nameExpectedFormVariations.FirstOrDefault().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            nameExpectedFormVariations = nameExpectedFormVariations.Skip(1);
            var firstName = names.FirstOrDefault();
            var lastName = names.LastOrDefault();

            var midleName = string.Empty;

            var p = new Person();

            if (names.Count() >= 3)
            {
                midleName = names.Skip(1).FirstOrDefault();
                if (names.Count() > 3)
                {
                    lastName = string.Join(" ", names.Skip(2));
                }
            }
            // todo fix age depond on the birth date;
            var age = int.Parse(row.Age);
            var dob = DateTime.Parse(row.Dob);
            var tobacco = row.Tobacco == "Y";
            var gender = row.Gender == "M" ? Gender.Male : Gender.Female;
            var premiumType = SeniorChoicePremiumType.Graded;
            if (row.Plan.Contains("Immed"))
            {
                premiumType = SeniorChoicePremiumType.Immediate;
            }
            if (row.Plan.Contains("Graded"))
            {
                premiumType = SeniorChoicePremiumType.Graded;
            }
            var ret = new AAFinalExpense()
            {
                AAFinalExpenseId = Guid.NewGuid(),
                InsuranceCompanyName = row.Co.ToLower().Contains("aa") ? InsuranceCompany.AmericanAmicable : InsuranceCompany.Occidental,
                ApplicationAnswers = new List<AmAmApplicationAnswers>(),
                SignatureLocationCity = row.SigningCity.Split("\n").FirstOrDefault(),
                SignatureLocationState = row.SigningState,
                FileNumber = int.Parse(row.MyCaseForCheckingModal),
                ClientIPAddress = "23.23.21.12",
                SelectedBenefitAmount = int.Parse(row.Face),
                SelectedMonthlyRate = decimal.Parse(row.ModalPremiumShouldCalculateOutToThisAmount),
                PremiumType = premiumType,
                SignedDate = DateTime.Now
            };
            int.TryParse(row.IfBankRequestedDraftDay, out int IfBankRequestedDraftDay);
            SSDDate socialSecurityWithdrawDate = SSDDate.FirststDOM;

            switch (row.IfBankRequestedDraftDay)
            {
                case "1S": socialSecurityWithdrawDate = SSDDate.FirststDOM; break;
                case "3S": socialSecurityWithdrawDate = SSDDate.ThirdDOM; break;
                case "2W": socialSecurityWithdrawDate = SSDDate.SecondW; break;
                case "3W": socialSecurityWithdrawDate = SSDDate.ThirdW; break;
                case "4W": socialSecurityWithdrawDate = SSDDate.ForthW; break;
            }
            var lead = new LeadDTO()
            {
                LeadId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                DOB = dob,
                Email = faker.Person.Email,
                MiddleName = midleName,
                Phone = faker.Phone.PhoneNumber("###-###-####"),
                DesiredCoverageAmount = int.Parse(row.Face),
                Address1 = faker.Address.StreetAddress(),
                Address2 = faker.Address.SecondaryAddress(),
                Gender = gender,
                State = row.LiveAtState,
                ZipCode = row.LiveAtZipCode,
                City = row.ZipCity?.Split("\n",StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(),
                HealthQuestions = new List<LeadHealthQuestionDto>()

            };
            var r = new Random();
            var states = Enum.GetValues(typeof(States)).OfType<States>().ToList();
            var doctor = new Person();
            States docState;
            States.TryParse(row.LiveAtState, out docState);
            var h = r.Next() % 14;
            var appDto = new ApplicationDto()
            {

                LeadInfo = lead,

                ApplicationInfo = new ApplicationInfoDto()
                {

                    FirstName = firstName,
                    LastName = lastName,
                    HeightFt = 5 + (h / 8),
                    HeightIn = 2 + (h % 8),
                    Weight = 150 + (r.Next() % 100),
                    DOB = dob,
                    SSN = p.Ssn().Replace("-", ""),
                    StateOfBirth = row.AnyStateOfBirthOrForeign == "Any" ? (states.ElementAt(r.Next() % states.Count).ToString()) : row.AnyStateOfBirthOrForeign,
                    MiddleName = midleName,
                    ApplicationInfoId = Guid.NewGuid(),
                    AcceptAnyPlan = row.AcceptAnyPlanCheckBox == "Y",
                    DoctorCity = doctor.Address.City,
                    DoctorName = doctor.FullName,
                    DoctorPhone = faker.Phone.PhoneNumber("###-###-####"),
                    DoctorState = docState

                },
                Beneficiaries = new List<BeneficiaryDto>(),
                ContingentBeneficiaries = new List<BeneficiaryDto>(),
                HealthQuestions = new List<ApplicationHealthQuestionDto>(),

                PaymentInfo = new PaymentInfoDto()
                {
                    PaymentId = Guid.NewGuid(),
                    BankType = row.IfBankCheckingOrSavings == "C" ? AccountType.Checking : AccountType.Savings,
                    BankingInsitution = "Federal Credit Union",
                    BankAddress = faker.Address.FullAddress(),
                    AccountNumber = faker.Finance.Account(),
                    RoutingNumber = faker.Finance.RoutingNumber(),
                    PaymentWithdrawlDate = row.IfBankSocSecurityChoice == "Y" ? 0 : IfBankRequestedDraftDay,
                    SocialSecurityWithdrawDate = socialSecurityWithdrawDate
                },



            };
            appDto.LeadInfo.HealthQuestions.Add(new LeadHealthQuestionDto()
            {
                LeadHealthQuestion = LeadHealthQuestions.TobaccoUse,
                HealthQuestionId = Guid.NewGuid(),
                HealthAnswer = tobacco
            });
            var covids = row.CovidQuestionsYes.Split("\n", StringSplitOptions.RemoveEmptyEntries).Where(k => !k.Contains("Quest")).ToArray().SelectMany(k =>
                       {
                           var v = k.Split("/", StringSplitOptions.RemoveEmptyEntries).Select(k => k.Trim()).ToList();
                           var cov = new bool[3] { v.FirstOrDefault() == "Y", v.Skip(1).FirstOrDefault() == "Y", v.Skip(2).FirstOrDefault() == "Y" };
                           if (cov[2])
                           {
                               System.Console.WriteLine("tes");
                           }
                           return cov;
                       }).ToArray();
            // todo set confvid unsers 
            foreach (var k in Enum.GetValues(typeof(ApplicationHealthQuestions)).OfType<ApplicationHealthQuestions>())
            {
                var healthAnswer = false;
                if (
                   // todo adjust question order as the excel
                   (k == ApplicationHealthQuestions.CovidQuestionMain && covids[0]) ||
                   (k == ApplicationHealthQuestions.CovidWithin90DaysMain && covids[1]) ||
                   (k == ApplicationHealthQuestions.CovidEffectsMain && covids[2]) ||
                   (k == ApplicationHealthQuestions.Covid2 && covids[3]) ||
                   (k == ApplicationHealthQuestions.Covid290Days && covids[4]) ||
                   (k == ApplicationHealthQuestions.Covid2Effects && covids[5]) ||
                   (k == ApplicationHealthQuestions.CovidQuestionThree && covids[6])
                )
                {
                    healthAnswer = true;
                }
                appDto.HealthQuestions.Add(new ApplicationHealthQuestionDto()
                {
                    HealthQuestionId = Guid.NewGuid(),
                    ApplicationQuestion = k,
                    HealthAnswer = healthAnswer
                });
            }




            foreach (var k in Enum.GetValues(typeof(AmAmApplicationQuestion)).OfType<AmAmApplicationQuestion>())
            {
                var id = Guid.NewGuid();
                ret.ApplicationAnswers.Add(new AmAmApplicationAnswers()
                {
                    AmAmApplicationAnswersId = id,
                    Question = new AmAmApplicationQuestions()
                    {
                        AmAmApplicationQuestionsId = id,
                        QuestionName = k
                    }
                });

            }
            if (!row.HealthQuestions.Contains("All No"))
            {
                foreach (var line in row.HealthQuestions.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()))
                {
                    var qs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToArray();
                    if (qs.LastOrDefault() == "Yes")
                    {
                        var question = ret.ApplicationAnswers.FirstOrDefault(k => k.Question.QuestionName.ToString().ToLower().EndsWith(qs.FirstOrDefault()));
                        if (question != null) question.Answer = true;
                    }
                }
            }
            var top10 = RelationShipExtension.FamilyRelations().ToList();
            var contingent = CreateBeneficiary();
            switch (row.ContingentBeneRelationship)
            {
                case "Mother": { contingent.PrimaryRelationship = Relationship.Mother; break; }
                case "Father": { contingent.PrimaryRelationship = Relationship.Father; break; }
                case "Child (Daughter)": { contingent.PrimaryRelationship = Relationship.ChildDaughter; break; }
                case "Child (Son)": { contingent.PrimaryRelationship = Relationship.ChildSon; break; }
                case "Brother": { contingent.PrimaryRelationship = Relationship.Brother; break; }
                case "Sister": { contingent.PrimaryRelationship = Relationship.Sister; break; }
                case "Cousin": { contingent.PrimaryRelationship = Relationship.Cousin; break; }
                case "Aunt": { contingent.PrimaryRelationship = Relationship.Aunt; break; }
                case "Uncle": { contingent.PrimaryRelationship = Relationship.Uncle; break; }
                case "Grandfather": { contingent.PrimaryRelationship = Relationship.GrandFather; break; }
                case "Grandmother": { contingent.PrimaryRelationship = Relationship.GrandMother; break; }
                case "Grandchild": { contingent.PrimaryRelationship = Relationship.GrandChild; break; }
                case "Niece": { contingent.PrimaryRelationship = Relationship.Niece; break; }
                case "Nephew": { contingent.PrimaryRelationship = Relationship.Nephew; break; }
                case "Life Partner": { contingent.PrimaryRelationship = Relationship.LifePartner; break; }
                case "Spouse": { contingent.PrimaryRelationship = Relationship.Spouse; break; }
                // todo check 
                case "Fiance": { contingent.PrimaryRelationship = Relationship.Fiance; break; }
                case "Estate": { contingent.PrimaryRelationship = Relationship.Estate; break; }
                case "Trust": { contingent.PrimaryRelationship = Relationship.Trust; break; }
                case "Other":
                    {
                        contingent.PrimaryRelationship = Relationship.Other; break;
                    }

                case "Multi Bene Select last 4 relationships":
                    
                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(Relationship.Niece));
                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(Relationship.Nephew));
                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(Relationship.LifePartner));
                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(Relationship.Spouse));
                        contingent = null;
                    break;

                    case "Multi Bene Select last 3 relationships":

                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(Relationship.Niece));
                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(Relationship.Nephew));
                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(Relationship.Spouse));
                        contingent = null;
                        break;



                    case "Multi Bene first 4 relatinonships":
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                appDto.ContingentBeneficiaries.Add(CreateBeneficiary(top10[i]));
                            }
                            contingent = null;
                            break;
                        }

                    case "Multi Bene \n(10 bene's)\n(Select first 10 relationships)":


                    for (int i = 0; i < 10; i++)
                    {
                        appDto.ContingentBeneficiaries.Add(CreateBeneficiary(top10[i]));
                    }
                    contingent = null;
                    break;
                default:
                    contingent = null;
                    break;

            }

            if (contingent != null)
            {
                appDto.ContingentBeneficiaries.Add(contingent);
            }

            var primary = CreateBeneficiary();
            switch (row.PrimaryBeneRelationship)
            {
                case "Mother": { primary.PrimaryRelationship = Relationship.Mother; break; }
                case "Father": { primary.PrimaryRelationship = Relationship.Father; break; }
                case "Daughter":
                case "Child (Daughter)": { primary.PrimaryRelationship = Relationship.ChildDaughter; break; }
                case "Son":
                case "Child (Son)": { primary.PrimaryRelationship = Relationship.ChildSon; break; }
                case "Brother": { primary.PrimaryRelationship = Relationship.Brother; break; }
                case "Sister": { primary.PrimaryRelationship = Relationship.Sister; break; }
                case "Cousin": { primary.PrimaryRelationship = Relationship.Cousin; break; }
                case "Aunt": { primary.PrimaryRelationship = Relationship.Aunt; break; }
                case "Uncle": { primary.PrimaryRelationship = Relationship.Uncle; break; }
                case "Grandfather": { primary.PrimaryRelationship = Relationship.GrandFather; break; }
                case "Grandmother": { primary.PrimaryRelationship = Relationship.GrandMother; break; }
                case "Grandchild": { primary.PrimaryRelationship = Relationship.GrandChild; break; }
                case "Niece": { primary.PrimaryRelationship = Relationship.Niece; break; }
                case "Nephew": { primary.PrimaryRelationship = Relationship.Nephew; break; }
                case "Fiance": { primary.PrimaryRelationship = Relationship.Fiance; break; }
                case "Trust": { primary.PrimaryRelationship = Relationship.Trust; break; }

                case "Other": { primary.PrimaryRelationship = Relationship.Other; break; }
                case "Spouse": { primary.PrimaryRelationship = Relationship.Spouse; break; }
                // todo explaint thouse

                case "Multi Bene \n(10 bene's)\n(Select first 10 relationships)":
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            appDto.Beneficiaries.Add(CreateBeneficiary(top10[i]));
                        }
                        primary = null;
                        break;
                    }

                case "Multi Bene Select last 4 relationships":
                        {
                            appDto.Beneficiaries.Add(CreateBeneficiary(Relationship.Niece));
                            appDto.Beneficiaries.Add(CreateBeneficiary(Relationship.Nephew));
                            appDto.Beneficiaries.Add(CreateBeneficiary(Relationship.LifePartner));
                            appDto.Beneficiaries.Add(CreateBeneficiary(Relationship.Spouse));

                            primary = null;
                            break;
                        }



                    case "Multi Bene first 4 relatinonships":
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            appDto.Beneficiaries.Add(CreateBeneficiary(top10[i]));
                        }
                        primary = null;
                        break;
                    }

                // todo explaint thouse
                case "Life Partner": { primary.PrimaryRelationship = Relationship.LifePartner; break; }
                case "Estate\n(Info on Addendum)":
                case "Estate\n(Check Addendum)":
                case "Estate":
                    { primary.PrimaryRelationship = Relationship.Estate; break; }
                default:
                    primary = null;
                    break;

            }
            if (primary != null)
            {
                appDto.Beneficiaries.Add(primary);
            }

            return new Tuple<AAFinalExpense, ApplicationDto>(ret, appDto);
            }catch (Exception ex)
            {
                var craig = 1;
            }
            return null;
        }

        private static BeneficiaryDto CreateBeneficiary(Relationship relationship = Relationship.Other)
        {
            var r = new Random();

            var p = new Person();
            var h = r.Next() % 14;
            return new BeneficiaryDto()
            {
                PersonalInfo = new FamilyMemberDto()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    MiddleName = "M",
                    SSN = p.Ssn().Replace("-", ""),
                    Weight = 150 + (r.Next() % 100),
                    HeightFt = 5 + (h / 8),
                    HeightIn = 2 + (h % 8),
                    DateOfBirth = p.DateOfBirth
                },
                PrimaryRelationship = relationship


            };
        }
    }
}
