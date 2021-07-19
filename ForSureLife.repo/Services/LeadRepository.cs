using ForSureLife.Models.ErrorHandling;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Enroll;
using ForSureLife.repo.Models.Quote;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class LeadRepository : BaseRepository, ILeadRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly ForSureLifeDBContext _forSureLifeDbContext;

        public LeadRepository(ILoggerFactory logFactory, ForSureLifeDBContext forSureLifeDbContext)
        {
            _logger = logFactory.CreateLogger<LeadRepository>();
            _forSureLifeDbContext = forSureLifeDbContext;
        }
        public async Task<Guid> CreateLead(Application application)
        {
            var leadId = Guid.NewGuid();
            using (var ctx = _forSureLifeDbContext)
            {
                var leadFromDb = GetApplication(application.ApplicationId, ctx);
                if (leadFromDb != null && leadFromDb.LeadId != Guid.Empty)
                {
                    _logger.LogError("Lead Already Created");
                    throw new RepoLayerException(ErrorCode.BadRequest, "Lead Already Created");
                }

                application.LeadInfo.LeadId = leadId;
                ctx.Application.Add(application);
                ctx.SaveChanges();
                _logger.LogInformation("Lead Successfully Created");
                return leadId;
            }
        }

        public async Task<Lead> GetLead(Guid leadId, Guid applicationId)
        {
            using (var ctx = _forSureLifeDbContext)
            {
                var originalLeadId = ctx.Application.Where(x => x.ApplicationId == applicationId && x.LeadInfo.LeadId == leadId).Select(x => x.LeadInfo).FirstOrDefault();
                if (originalLeadId is null)
                {
                    throw new RepoLayerException(ErrorCode.NotFound, "LeadId Not found");
                }

                return originalLeadId;
            }
        }

        public Lead GetApplication(Guid applicationId, ForSureLifeDBContext ctx)
        {
            return ctx.Application.Where(x => x.ApplicationId == applicationId).Select(x => x.LeadInfo).FirstOrDefault();
        }

        public bool UserHavePermissions(Application application, ForSureLifeDBContext ctx)
        {
            if (ctx.Application.Where(x => x.ApplicationId == application.ApplicationId && x.LeadInfo.LeadId == application.LeadInfo.LeadId).Select(x => x.LeadInfo).Any())
            {
                return true;
            }
            throw new RepoLayerException(ErrorCode.Forbidden, "User does not have permission");
        }

        public async Task UpdateLead(Application application)
        {
            using (var ctx = _forSureLifeDbContext)
            {
                UserHavePermissions(application, ctx);
                ctx.Lead.Add(application.LeadInfo);
                ctx.Entry(application.LeadInfo).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public async Task DeleteLead(Guid leadId, Guid applicationId)
        {
            using (var ctx = _forSureLifeDbContext)
            {
                ctx.Lead.RemoveRange(ctx.Application.Where(x => x.ApplicationId == applicationId && x.LeadInfo.LeadId == leadId).Select(x => x.LeadInfo).FirstOrDefault());
                ctx.SaveChanges();
            }
        }

        public async Task CreateLeadSale(LeadSale leadSale)
        {
            _forSureLifeDbContext.LeadSale.Add(leadSale);
            _forSureLifeDbContext.SaveChanges();
        }

        public async Task CreateLeadSale(List<LeadSale> leadSales)
        {
            foreach(var leadSale in leadSales)
            {
                _forSureLifeDbContext.LeadSale.Add(leadSale);
            }

            _forSureLifeDbContext.SaveChanges();
        }
    }
}
