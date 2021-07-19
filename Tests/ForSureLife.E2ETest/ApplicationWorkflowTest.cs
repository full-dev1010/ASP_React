
#define MYTEST


using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Net.Http.Headers;
using ForSureLife.repo.Models.Enroll;
using ForSureLife.Models.DTO;
using System.IO;
using ForSureLife.repo.Carrier_Access;
using System.Threading;

namespace ForSureLife.E2ETest
{
    [TestClass]
    public class ApplicationWorkflowTest
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Startup> _factory;
        private static List<Tuple<AAFinalExpense, ApplicationDto>> _testData;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testData = TestExcelMatrixReader.ReadTestData();
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Startup>();
            AmAmFTPClient.SkipUpload = true;
        }

        [TestMethod]
        public async Task TestAuthApiResponse()
        {
            Console.WriteLine(_testContext.TestName);
            var client = _factory.CreateClient();
            Guid applicationId = await AuthTest(client);
        }

        [TestMethod]
        public async Task TestExcelMatrixData()
        {
            Console.WriteLine(_testContext.TestName);
            var testPassed = true;
            var client = _factory.CreateClient();
            foreach (var tpl in _testData)
            {
                try
                {
                    if(tpl.Item1.SignatureLocationState == "VT")
                    {
                        var test = 1;


                    }
                    var excelAAFinalExpense = tpl.Item1;
                    var excelAppDto = tpl.Item2;
                    Guid applicationId = await AuthTest(client);
                    //CREATE APPLICATION
                    excelAppDto.ApplicationId = applicationId;
                    var appR = await client.PostAsJsonAsync("/api/Application", excelAppDto);
                    var app = await appR.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                    //GET APPLICATION

                    if(excelAAFinalExpense.SignatureLocationState == "VT")
                    {
                        var testThis = 111; 
                    }

                    var appVal = (await client.GetFromJsonAsync<AAFinalExpense>("/api/Application/AmAmApplication"));
                    PatchAAFinalExpenseValues(excelAAFinalExpense, appVal);
                    var rput = await client.PatchAsync("/api/Application/AmAmApplication", new StringContent(JsonSerializer.Serialize(appVal), Encoding.UTF8, "application/json"));
                     var retApplication = await rput.Content.ReadFromJsonAsync<AAFinalExpense>();
                    
                    WriteTestDataToJsonFile(excelAAFinalExpense, excelAppDto, appVal, retApplication); await client.PostAsync("/api/Application/AmAmApplication", new StringContent(""));
                    Assert.AreEqual(retApplication.SelectedMonthlyRate, excelAAFinalExpense.SelectedMonthlyRate);
                }
                catch (Exception ex)
                {
                    testPassed = false; 
                }
            }
            Assert.IsTrue(testPassed);
        }

        private static async Task<Guid> AuthTest(HttpClient client)
        {
            var response = await client.PostAsJsonAsync("api/auth", new { UserName = "ForSureLifeApp", Password = "SomethingSecret" });
            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            Assert.IsTrue(result.ContainsKey("token") && !string.IsNullOrEmpty(result["token"]));
            var applicationId = Guid.Parse(result["applicationId"]);
            Assert.IsTrue(applicationId != Guid.Empty);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", result["token"]);
            return applicationId;
        }

        private static void WriteTestDataToJsonFile(AAFinalExpense excelAAFinalExpense, ApplicationDto excelAppDto, AAFinalExpense appVal, AAFinalExpense retApplication)
        {
            if (!Directory.Exists("assets/testdata/")) Directory.CreateDirectory("assets/testdata/");
            File.WriteAllText("assets/testdata/" + retApplication.FileNumber + "-" + excelAAFinalExpense.FileNumber + "-result.json",
                        JsonSerializer.Serialize(retApplication, new JsonSerializerOptions { WriteIndented = true, }));
            File.WriteAllText("assets/testdata/" + retApplication.FileNumber + "-01-create-app.json",
                        JsonSerializer.Serialize(excelAppDto, new JsonSerializerOptions { WriteIndented = true, }));
            File.WriteAllText("assets/testdata/" + retApplication.FileNumber + "-03-patch.json",
                        JsonSerializer.Serialize(appVal, new JsonSerializerOptions { WriteIndented = true, }));

            // sumit appplicaiton 

        }

        private static void PatchAAFinalExpenseValues(AAFinalExpense excelAAFinalExpense, AAFinalExpense appVal)
        {
            //patch APPLICATION 
            foreach (var item in appVal.ApplicationAnswers)
            {
                var excelAnser = excelAAFinalExpense.ApplicationAnswers.FirstOrDefault(k => k.Question.QuestionName == item.Question.QuestionName);
                if (excelAnser != null)
                {
                    item.Answer = excelAnser.Answer;
                }
            }

            appVal.PremiumType = excelAAFinalExpense.PremiumType;
            appVal.SignatureLocationState = excelAAFinalExpense.SignatureLocationState;
            appVal.SignatureLocationCity = excelAAFinalExpense.SignatureLocationCity;
            appVal.SelectedBenefitAmount = excelAAFinalExpense.SelectedBenefitAmount;
            appVal.SignedDate = excelAAFinalExpense.SignedDate;
            appVal.ClientIPAddress = excelAAFinalExpense.ClientIPAddress;
            // appVal.= excelAAFinalExpense.;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Thread.Sleep(6000);
             _factory.Dispose();
        }
    }
}
