using ForSureLife.biz.Interfaces;
using ForSureLife.repo;
using ForSureLife.repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class ApplicationInfoManager : IApplicationInfoManager
    {

        public IApplicationInfoRepository _applicationInfoRepo { get; set; }
        public ApplicationInfoManager(IApplicationInfoRepository applicationRepo)
        {
            _applicationInfoRepo = applicationRepo;
        }
        public async Task<Guid> CreateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId)
        {
            return await _applicationInfoRepo.CreateApplicationInfo(applicationInfo, applicationId);
        }

        public async Task DeleteApplicationInfo(Guid applicationInfoId, Guid applicationId)
        {
            await _applicationInfoRepo.DeleteApplicationInfo(applicationInfoId, applicationId);
        }

        public async Task<ApplicationInfo> GetApplicationInfo(Guid applicationInfoId, Guid applicationId)
        {
            return await _applicationInfoRepo.GetApplicationInfo(applicationInfoId, applicationId);
        }

        public async Task UpdateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId)
        {
            await _applicationInfoRepo.UpdateApplicationInfo(applicationInfo, applicationId);
        }
    }
}
