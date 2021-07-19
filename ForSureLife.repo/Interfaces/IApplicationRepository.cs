using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Guid> CreateApplication(Application application);
        Task<Application> GetApplication(Guid applicationId);
        Task UpdateApplication(Application application, bool createdRan = false);
        Task DeleteApplication(Guid applicationId);
        Task<string> GetApplicationByEmailPhone(string email, string phone);
        Task<Application> GetApplicationByChallengeCode(string email, string phone, string challengeCode);

    }
}
