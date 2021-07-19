using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForSureLife.biz.Services;
using ForSureLife.biz.Interfaces;
using System.IO;
using ForSureLife.BizTest;
using System.Threading.Tasks;
using System.Linq;
using ForSureLife.repo;
using ForSureLife.Models.Enums;
using ForSureLife.repo.Models.Enroll;
using ForSureLife.repo.Carrier_Access;

namespace ForSureLife.biz
{
    [TestClass]
    public class TestForSureLifeDocumentManager
    {
        //private IConfiguration config { get; set; }
        public TestForSureLifeDocumentManager()
        {
            RepositoryMock = new AmAmApplicationRepositoryMock();
            //amAmFTPClient = new AmAmFTPClient();
            //documentManager = new ForSureLifeDocumentManager(RepositoryMock, amAmFTPClient);
        }
        AmAmFTPClient amAmFTPClient;
        ForSureLifeDocumentManager documentManager;
        AmAmApplicationRepositoryMock RepositoryMock;
        [TestMethod]
        public async Task TestPdfApplication()
        {
            var appId = Guid.Parse("00016cbe-a9b7-49ae-9dad-ce1e8941724f");
            var app = await RepositoryMock.GetApplication(appId);
            Assert.IsNotNull(app?.Application, "Mock is working");

            (string applicationFlatFileName, string applicationPdfFileName)
                = await documentManager.FillPdfFlatFiles(app);
            await TestFiles(applicationFlatFileName, applicationPdfFileName);

            (applicationFlatFileName, applicationPdfFileName)
                            = await documentManager.FillPdfFlatFiles
                                (await RepositoryMock.GetApplication(
                                    Guid.Parse("00026cbe-a9b7-49ae-9dad-ce1e8941724f")));
            await TestFiles(applicationFlatFileName, applicationPdfFileName);


            (applicationFlatFileName, applicationPdfFileName)
                            = await documentManager.FillPdfFlatFiles
                                (await RepositoryMock.GetApplication(
                                    Guid.Parse("00036cbe-a9b7-49ae-9dad-ce1e8941724f")));
            await TestFiles(applicationFlatFileName, applicationPdfFileName);
            (applicationFlatFileName, applicationPdfFileName)
                            = await documentManager.FillPdfFlatFiles
                                (await RepositoryMock.GetApplication(
                                    Guid.Parse("00046cbe-a9b7-49ae-9dad-ce1e8941724f")));
            await TestFiles(applicationFlatFileName, applicationPdfFileName);
            await amAmFTPClient.UploadApplicationFile(applicationFlatFileName);
            await amAmFTPClient.UploadApplicationFile(applicationPdfFileName);
            // Assert.IsNotNull(v);
        }

        // [TestMethod]
        public async Task UpdateApplicationSamples()
        {
            var app = await RepositoryMock.GetApplication(Guid.Parse("00016cbe-a9b7-49ae-9dad-ce1e8941724f"));
            if (app.Application.Beneficiaries.Count < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    var ben = CreateSampleBenficiary("Family" + i);
                    app.Application.Beneficiaries.Add(ben);
                }
            }
            AddMissingAppAnsers(app);
            await RepositoryMock.UpdateApplication(app);

            app = await RepositoryMock.GetApplication(Guid.Parse("00026cbe-a9b7-49ae-9dad-ce1e8941724f"));
            if (app.Application.Beneficiaries.Count < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    var ben = CreateSampleBenficiary("Family" + i);
                    app.Application.Beneficiaries.Add(ben);
                }
                {
                    FamilyOrBeneficiary ben = CreateSampleBenficiary("SO");
                    ben.PrimaryRelationship = Models.Enums.Relationship.SeparatePolicyOwnerSpouse;
                    app.Application.Beneficiaries.Add(ben);
                }
            }
            AddMissingAppAnsers(app);

            await RepositoryMock.UpdateApplication(app);
            app = await RepositoryMock.GetApplication(Guid.Parse("00036cbe-a9b7-49ae-9dad-ce1e8941724f"));
            if (app.Application.Beneficiaries.Count < 1)
            {

                {
                    FamilyOrBeneficiary ben = CreateSampleBenficiary("SO");
                    ben.PrimaryRelationship = Models.Enums.Relationship.SeparatePolicyOwnerSpouse;
                    app.Application.Beneficiaries.Add(ben);
                }
            }
            AddMissingAppAnsers(app);
            await RepositoryMock.UpdateApplication(app);

            app = await RepositoryMock.GetApplication(Guid.Parse("00046cbe-a9b7-49ae-9dad-ce1e8941724f"));

            AddMissingAppAnsers(app);
            await RepositoryMock.UpdateApplication(app);
            // Assert.IsNotNull(v);
        }

        private static void AddMissingAppAnsers(AAFinalExpense app)
        {
            foreach (var k in Enum.GetValues(typeof(AmAmApplicationQuestion)).OfType<AmAmApplicationQuestion>())
            {
                if (!app.ApplicationAnswers.Any(an => an.Question.QuestionName == k))
                {
                    var anser = new AmAmApplicationAnswers()
                    {
                        Question = new AmAmApplicationQuestions()
                        {
                            QuestionName = k
                        }
                    };
                    app.ApplicationAnswers.Add(anser);
                }
            }
        }

        private static FamilyOrBeneficiary CreateSampleBenficiary(string prefix)
        {
            var ben = new FamilyOrBeneficiary();
            var r = new Random();
            ben.PersonalInfo = new FamilyMember()
            {
                FirstName = prefix + "FirstName",
                LastName = prefix + "LastName",
                MiddleName = prefix + "MiddleName",
                Address1 = prefix + "Address1",
                SSN = "111-111-1111",
            };
            return ben;
        }

        private static async Task TestFiles(string applicationFlatFileName, string applicationPdfFileName)
        {
            Assert.IsTrue(File.Exists(applicationPdfFileName), "Pdf file Exist");
            Assert.IsTrue(File.Exists(applicationFlatFileName), "Flat file Exist");

            ;
            var flatFieldDic = (await File.ReadAllTextAsync(applicationFlatFileName))
                            .Split("\n", StringSplitOptions.RemoveEmptyEntries).GroupBy(k => k.FirstOrDefault()).Select(k => k.FirstOrDefault().Split("=", StringSplitOptions.RemoveEmptyEntries)).ToDictionary(k => k.FirstOrDefault(), k => k.Count() > 1 ? k.LastOrDefault() : null);


            Assert.IsTrue(flatFieldDic.All(k => !string.IsNullOrEmpty(k.Value)), "Flat fields are not empty");
        }
    }
}
