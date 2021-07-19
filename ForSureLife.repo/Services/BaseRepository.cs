using ForSureLife.Models.ErrorHandling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSureLife.repo.Services
{
    public abstract class BaseRepository
    {

        public Application GetApplicationFromDb(Guid applicationId, ForSureLifeDBContext ctx)
        {
            return ctx.Application.Where(x => x.ApplicationId == applicationId).Include(e => e.ApplicationInfo)
                    .Include(e => e.Beneficiaries)
                        .ThenInclude(x => x.PersonalInfo)
                    .Include(e => e.PaymentInfo)
                    .Include(e => e.LeadInfo)
                    .Include(e => e.HealthQuestions)
                    .Include(e => e.Designee)
                    .Include(e => e.ContingentBeneficiaries)
                         .ThenInclude(x => x.PersonalInfo)
                    .FirstOrDefault();
        }
    }
}
