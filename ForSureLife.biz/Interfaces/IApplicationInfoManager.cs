using ForSureLife.repo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface IApplicationInfoManager
    {
        Task<Guid> CreateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId);
        Task<ApplicationInfo> GetApplicationInfo(Guid applicationInfoId, Guid applicationId);
        Task UpdateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId);
        Task DeleteApplicationInfo(Guid applicationInfoId, Guid applicationId);
    }
}
