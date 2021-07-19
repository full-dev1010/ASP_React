using ForSureLife.biz.Interfaces;
using ForSureLife.repo;
using ForSureLife.repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class ApplicationManager : IApplicationManager
    {
        public IApplicationRepository _applicationRepo { get; set; }
        public ApplicationManager(IApplicationRepository applicationRepo)
        {
            _applicationRepo = applicationRepo;
        }
        public async Task<Application> CreateApplication(Application application)
        {
            var applicationId =  await _applicationRepo.CreateApplication(application);
            var applicationFromDb = await _applicationRepo.GetApplication(applicationId);
            return applicationFromDb;
        }

        public async Task<Application> GetApplication(Guid applicationId)
        {
            return await _applicationRepo.GetApplication(applicationId);
        }

        public async Task<string> GetApplicationByEmailPhone(string email, string phone)
        {
            return await _applicationRepo.GetApplicationByEmailPhone(email, phone);
        }

        public async Task<Application> GetApplicationByChallengeCode(string email, string phone, string challengeCode)
        {
            return await _applicationRepo.GetApplicationByChallengeCode(email, phone, challengeCode);
        }

        public async Task<Application> UpdateApplication(Application application)
        {
            await _applicationRepo.UpdateApplication(application);
            var applicationFromDb = await _applicationRepo.GetApplication(application.ApplicationId);
            return applicationFromDb;
        }
    }
}
