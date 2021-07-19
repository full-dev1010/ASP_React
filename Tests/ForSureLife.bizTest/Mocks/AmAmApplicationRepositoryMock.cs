using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ForSureLife.Models.Enums;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Enroll;
using Newtonsoft.Json;

namespace ForSureLife.BizTest
{
    public class AmAmApplicationRepositoryMock : IAmAmApplicationRepository
    {
        public async Task<AAFinalExpense> GetApplication(Guid applicationId)
        {
            // todo replace in memory database provider 
            return JsonConvert.DeserializeObject<AAFinalExpense>(
             await File.ReadAllTextAsync("./Assets/samples/applications/" + applicationId.ToString() + ".json")
            );

        }

        public Task<int> GetApplicationNumber()
        {
            throw new NotImplementedException();
        }

        public Task<List<AAFinalExpense>> GetSalesLeads()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetStateAbbreviation(string applicationState)
        {
            throw new NotImplementedException();
        }

        public Task<List<AmAmApplicationQuestions>> GetStateQuestions(States? state)
        {
            throw new NotImplementedException();
        }

        public Task SubmitApplication(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateApplication(AAFinalExpense application)
        {
            await File.WriteAllTextAsync("./Assets/samples/applications/" + application.Application.ApplicationId.ToString() + ".json",
              JsonConvert.SerializeObject(application)
               );

        }
    }
}