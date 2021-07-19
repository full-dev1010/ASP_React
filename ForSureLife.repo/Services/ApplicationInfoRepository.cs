using ForSureLife.Models.ErrorHandling;
using ForSureLife.repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class ApplicationInfoRepository : BaseRepository, IApplicationInfoRepository
    {
        private readonly ForSureLifeDBContext ctx;
        private readonly ILogger _logger;
        public ApplicationInfoRepository(ILoggerFactory logFactory, ForSureLifeDBContext _ctx)
        {
            ctx = _ctx;
            _logger = logFactory.CreateLogger<ApplicationInfoRepository>();
        }
        public async Task<Guid> CreateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId)
        {
         
                _logger.LogInformation($"Creating ApplicationInfo {0}", applicationId);
                var applicationFromDb = GetApplicationFromDb(applicationId, ctx);
                if (applicationFromDb.ApplicationInfo != null)
                {
                    _logger.LogError("Application Already Created");
                    throw new RepoLayerException(ErrorCode.BadRequest, "Application Already Created");
                }

                applicationFromDb.ApplicationInfo = applicationInfo;

                ctx.Add(applicationFromDb.ApplicationInfo);
                ctx.SaveChanges();
                _logger.LogInformation("Application Successfully Created");
                var applicationInfoId = applicationFromDb.ApplicationInfo.ApplicationInfoId;
                return applicationInfoId;
            
        }

        public async Task DeleteApplicationInfo(Guid applicationInfoId, Guid applicationId)
        {
            
                _logger.LogInformation($"Deleting ApplicationInfo {0}", applicationInfoId);
                ctx.RemoveRange(ctx.Application.Where(x => x.ApplicationId == applicationId && x.ApplicationInfo.ApplicationInfoId == applicationInfoId));
                ctx.SaveChanges();
                _logger.LogInformation($"Successfully deleted ApplicationInfo {0}", applicationId);
            
        }

        public async Task<ApplicationInfo> GetApplicationInfo(Guid applicationInfoId, Guid applicationId)
        {
           
                _logger.LogInformation($"Getting ApplicationInfo {0}", applicationInfoId);

                var applicationInfo = ctx.Application.Where(x => x.ApplicationId == applicationId && x.ApplicationInfo.ApplicationInfoId == applicationInfoId)
                    .Include(e => e.ApplicationInfo)
                    .Select(x => x.ApplicationInfo)
                    .FirstOrDefault();

                if (applicationInfo is null)
                {
                    _logger.LogError($"ApplicationInfo Does not exist in DB Application {0}", applicationInfoId);
                    throw new RepoLayerException(ErrorCode.NotFound, "ApplicationInfo Is NOt Found Not found");
                }

                _logger.LogInformation($"Successfully retrieved from Db ApplicationInfo  {0}", applicationId);
                return applicationInfo;
            
        }

        public async Task UpdateApplicationInfo(ApplicationInfo applicationInfo, Guid applicationId)
        {
              
                ctx.Entry(applicationInfo).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            
        }
    }
}
