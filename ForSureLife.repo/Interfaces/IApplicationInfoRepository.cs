using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IApplicationInfoRepository
    {
        Task<Guid> CreateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId);
        Task<ApplicationInfo> GetApplicationInfo(Guid applicationInfoId, Guid applicationId);
        Task UpdateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId);
        Task DeleteApplicationInfo(Guid applicationInfoId, Guid applicationId);
    }
}
