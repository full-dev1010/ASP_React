using ForSureLife.repo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface IApplicationManager
    {
        Task<Application> GetApplication(Guid applicationId);
        Task<string> GetApplicationByEmailPhone(string email, string phone);
        Task<Application> GetApplicationByChallengeCode(string email, string phone, string challengeCode);
        Task<Application> CreateApplication(Application application);
        Task<Application> UpdateApplication(Application application);
    }
}
