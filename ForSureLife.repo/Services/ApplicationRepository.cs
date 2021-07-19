using ForSureLife.Models.ErrorHandling;
using ForSureLife.repo._3rdPartyIntegrations;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Quote;
using ForSureLife.repo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        private readonly ILogger _logger;
        private readonly ForSureLifeDBContext ctx;
        private readonly ChildForSureLifeDBContext ctx2;
        private readonly IOmniSendAPI _omniSend;
        private readonly IASDSendGrid _sendGrid;
        
        public ApplicationRepository(ILoggerFactory logFactory, ForSureLifeDBContext _ctx, ChildForSureLifeDBContext _ctx2, IOmniSendAPI omniSend, IASDSendGrid asdSendGrid)
        {
            _logger = logFactory.CreateLogger<ApplicationRepository>();
            ctx = _ctx;
            ctx2 = _ctx2;
            _omniSend = omniSend;
            _sendGrid = asdSendGrid;
        }
        public async Task<Guid> CreateApplication(Application application)
        {
            try
            {
                _logger.LogInformation($"Creating Application {0}", application.ApplicationId);
                var applicationFromDb = GetApplicationFromDb(application.ApplicationId, ctx);
                if (applicationFromDb != null)
                {

                    _logger.LogError("Application Already Created");
                    throw new RepoLayerException(ErrorCode.BadRequest, "Application Already Created");
                }

                application.CreatedDate = DateTime.Now;
                application.UpdateDate = DateTime.Now;
                ctx.Application.Add(application);
                if (ctx.ApplicationInfo.Where(x => x.ApplicationInfoId == application.ApplicationInfo.ApplicationInfoId).Any())
                {
                    ctx.Entry(application.ApplicationInfo).State = EntityState.Modified;
                }

                if (ctx.PaymentInfo.Where(x => x.PaymentId == application.PaymentInfo.PaymentId).Any())
                {
                    ctx.Entry(application.PaymentInfo).State = EntityState.Modified;
                }

                if (ctx.Lead.Where(x => x.LeadId == application.LeadInfo.LeadId).Any())
                {
                    ctx.Entry(application.LeadInfo).State = EntityState.Modified;
                }

                if (ctx.Designee.Where(x => x.DesigneeId == application.Designee.DesigneeId).Any())
                {
                    ctx.Entry(application.Designee).State = EntityState.Modified;
                }

                foreach (var healthQuestion in application.HealthQuestions)
                {
                    if (ctx.HealthQuestion.Where(x => x.HealthQuestionId == healthQuestion.HealthQuestionId).Any())
                    {
                        ctx.Entry(healthQuestion).State = EntityState.Modified;
                    }
                }

                foreach (var beneficiary in application.Beneficiaries)
                {
                    var beneficiaryLookup = ctx.FamilyOrBeneficiary.Where(x => x.FamilyOrBeneficiaryId == beneficiary.FamilyOrBeneficiaryId);
                    if (beneficiaryLookup.Any())
                    {
                        ctx.Entry(beneficiary).State = EntityState.Modified;
                        ctx.Entry(beneficiary.PersonalInfo).State = EntityState.Modified;
                    }

                    var familyMemberLookup = ctx.FamilyMember.Where(x => x.FamilyMemberId == beneficiary.PersonalInfo.FamilyMemberId);
                    if (familyMemberLookup.Any())
                    {
                        ctx.Entry(beneficiary.PersonalInfo).State = EntityState.Modified;
                    }
                }

                foreach (var beneficiary in application.ContingentBeneficiaries)
                {
                    var beneficiaryLookup = ctx.FamilyOrBeneficiary.Where(x => x.FamilyOrBeneficiaryId == beneficiary.FamilyOrBeneficiaryId);
                    if (beneficiaryLookup.Any())
                    {
                        ctx.Entry(beneficiary).State = EntityState.Modified;
                        ctx.Entry(beneficiary.PersonalInfo).State = EntityState.Modified;
                    }

                    var familyMemberLookup = ctx.FamilyMember.Where(x => x.FamilyMemberId == beneficiary.PersonalInfo.FamilyMemberId);
                    if (familyMemberLookup.Any())
                    {
                        ctx.Entry(beneficiary.PersonalInfo).State = EntityState.Modified;
                    }
                }

               

                ctx.SaveChanges();
                _logger.LogInformation("Application Successfully Created");
                return application.ApplicationId;
            }
            catch (Exception ex)
            {
                await UpdateApplication(application, true);
                return GetApplicationFromDb(application.ApplicationId, ctx).ApplicationId;
            }


        }

        public async Task<Application> GetApplication(Guid applicationId)
        {

            _logger.LogInformation($"Getting Application {0}", applicationId);
            var originalApplication = ctx.Application.Where(x => x.ApplicationId == applicationId)
                .Include(e => e.ApplicationInfo)
                .Include(e => e.Beneficiaries)
                    .ThenInclude(x => x.PersonalInfo)
                .Include(e => e.PaymentInfo)
                .Include(e => e.Designee)
                .Include(e => e.LeadInfo)
                .Include(e => e.HealthQuestions)
                .Include(e => e.ContingentBeneficiaries)
                     .ThenInclude(x => x.PersonalInfo)

                .FirstOrDefault();

            if (originalApplication is null)
            {
                _logger.LogError($"Application Does not exist in DB Application {0}", applicationId);
                throw new RepoLayerException(ErrorCode.NotFound, "Application Is NOt Found Not found");
            }
            _logger.LogInformation($"Successfully retrieved from DB Application {0}", applicationId);
            return originalApplication;

        }

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

        public bool UserHavePermissions(Application application, ForSureLifeDBContext ctx)
        {
            //if (ctx.Application.Where(x => x.ApplicationId == application.ApplicationId && x.LeadInfo.LeadId == application.LeadInfo.LeadId).Select(x => x.LeadInfo).Any())
            //{
            //    return true;
            //}
            //_logger.LogError($"User does not have permission {0}", application.ApplicationId);
            //throw new RepoLayerException(ErrorCode.Forbidden, "User does not have permission");
            return true;
        }

        public async Task UpdateApplication(Application application, bool createdRan = false)
        {


            var applicationFromDb = GetApplicationFromDb(application.ApplicationId, ctx2);
            //if (applicationFromDb == null)
            //{
            //    //var applicationInfoFromDB = ctx.Application.Where(x => x.ApplicationInfo.ApplicationInfoId == application.ApplicationInfo.ApplicationInfoId);
            //    //if(applicationInfoFromDB != null)
            //    //{
            //    //    applicationFromDb = GetApplicationFromDb(applicationInfoFromDB.FirstOrDefault().ApplicationId, ctx2);
            //    //}
            //}

            if (applicationFromDb == null && createdRan == false)
            {

                application.CreatedDate = DateTime.Now;
                application.UpdateDate = DateTime.Now;
                await CreateApplication(application);
            }
            else
            {
                application.CreatedDate = applicationFromDb.CreatedDate;
                application.LeadCaputred = applicationFromDb.LeadCaputred;
                application.SentToIntegrity = applicationFromDb.SentToIntegrity;
                application.OmniSendContactId = applicationFromDb.OmniSendContactId;
                application.ImmediateLeadCaptured = applicationFromDb.ImmediateLeadCaptured;
                application.ImmediateLeadEmailed = applicationFromDb.ImmediateLeadEmailed;
                application.QuoteLeadEmailed = applicationFromDb.QuoteLeadEmailed;
                if (application.LeadInfo.SelectedMonthlyRate == 0)
                {
                    application.LeadInfo.PremiumType = applicationFromDb.LeadInfo.PremiumType;
                    application.LeadInfo.SelectedBenefitAmount = applicationFromDb.LeadInfo.SelectedBenefitAmount;
                    application.LeadInfo.SelectedMonthlyRate = applicationFromDb.LeadInfo.SelectedMonthlyRate;

                }


                // applicationFromDb.UpdateDate = DateTime.Now;
                application.UpdateDate = DateTime.Now;
                _logger.LogInformation($"Updating Application {0}", application.ApplicationId);


                UserHavePermissions(application, ctx);


                ctx.Add(application);

                ctx.Entry(application).State = EntityState.Modified;

                if (application.ApplicationInfo != null)
                {
                    if (applicationFromDb.ApplicationInfo == null)
                    {
                        if (ctx.ApplicationInfo.Where(x => x.ApplicationInfoId == application.ApplicationInfo.ApplicationInfoId).Any())
                        {
                            ctx.Entry(application.ApplicationInfo).State = EntityState.Modified;
                        }
                        else
                        {
                            ctx.Add(application.ApplicationInfo);
                        }

                    }
                    else
                    {
                        ctx.Entry(application.ApplicationInfo).State = EntityState.Modified;
                    }
                }
                else if (applicationFromDb.ApplicationInfo == null)
                {
                    ctx2.ApplicationInfo.Remove(applicationFromDb.ApplicationInfo);
                }



                if (application.PaymentInfo != null)
                {
                    if (applicationFromDb.PaymentInfo == null)
                    {
                        ctx.Add(application.PaymentInfo);
                    }
                    else
                    {
                        ctx.Entry(application.PaymentInfo).State = EntityState.Modified;
                    }
                }
                else if (applicationFromDb.PaymentInfo == null)
                {
                    ctx2.PaymentInfo.Remove(applicationFromDb.PaymentInfo);
                }

  



                if (application.Designee != null)
                {
                    if (applicationFromDb.Designee == null)
                    {
                        ctx.Add(application.Designee);
                    }
                    else
                    {
                        ctx.Entry(application.Designee).State = EntityState.Modified;
                    }
                }
                else if (application.Designee == null && applicationFromDb.Designee != null)
                {
                    ctx2.Designee.Remove(applicationFromDb.Designee);
                }


                if (application.LeadInfo != null)
                {
                    if (applicationFromDb.LeadInfo == null)
                    {
                        ctx.Add(application.LeadInfo);
                    }
                    else
                    {
                        ctx.Entry(application.LeadInfo).State = EntityState.Modified;
                    }
                }
                else if (applicationFromDb.LeadInfo == null)
                {
                    ctx2.Lead.Remove(applicationFromDb.LeadInfo);
                }



                foreach (var beneficiary in application.Beneficiaries)
                {
                    FamilyOrBeneficiary beneficiaryLookup = null;
                    if (applicationFromDb.Beneficiaries != null)
                    {
                        beneficiaryLookup = applicationFromDb.Beneficiaries.Where(x => x.FamilyOrBeneficiaryId == beneficiary.FamilyOrBeneficiaryId).FirstOrDefault();
                    }
                    if (beneficiaryLookup != null)
                    {
                        ctx.Entry(beneficiary).State = EntityState.Modified;
                        if (beneficiaryLookup.PersonalInfo != null)
                        {
                            ctx.Entry(beneficiary.PersonalInfo).State = EntityState.Modified;
                        }
                        else if (beneficiary.PersonalInfo != null && beneficiaryLookup.PersonalInfo == null)
                        {
                            if (ctx.FamilyMember.Where(x => x.FamilyMemberId == beneficiary.PersonalInfo.FamilyMemberId).Any())
                            {
                                ctx.Entry(beneficiary.PersonalInfo).State = EntityState.Modified;
                            }
                            else
                            {
                                ctx.Add(beneficiary.PersonalInfo);
                            }
                        }

                    }
                    else
                    {
                        if (ctx.FamilyOrBeneficiary.Where(x => x.FamilyOrBeneficiaryId == beneficiary.FamilyOrBeneficiaryId).Any())
                        {
                            ctx.Entry(beneficiary).State = EntityState.Modified;

                            var familyMemberLookup = ctx.FamilyMember.Where(x => x.FamilyMemberId == beneficiary.PersonalInfo.FamilyMemberId);
                            if (familyMemberLookup.Any())
                            {
                                ctx.Entry(beneficiary.PersonalInfo).State = EntityState.Modified;
                            }
                        }
                        else
                        {
                            ctx.Add(beneficiary);
                        }
                    }

                }

                var benficiariesToDelete = applicationFromDb.Beneficiaries.Where(s => !application.Beneficiaries.Where(es => es.FamilyOrBeneficiaryId == s.FamilyOrBeneficiaryId).Any());

                foreach (var benficiaryToDelete in benficiariesToDelete)
                {
                    ctx2.FamilyOrBeneficiary.Remove(benficiaryToDelete);
                }


                foreach (var contingentBeniciaries in application.ContingentBeneficiaries)
                {
                    FamilyOrBeneficiary conintengentBeneficiaryLookup = null;
                    if (applicationFromDb.ContingentBeneficiaries != null)
                    {
                        conintengentBeneficiaryLookup = applicationFromDb.ContingentBeneficiaries.Where(x => x.FamilyOrBeneficiaryId == contingentBeniciaries.FamilyOrBeneficiaryId).FirstOrDefault();
                    }
                    if (conintengentBeneficiaryLookup != null)
                    {
                        ctx.Entry(contingentBeniciaries).State = EntityState.Modified;
                        if (conintengentBeneficiaryLookup.PersonalInfo != null)
                        {
                            ctx.Entry(contingentBeniciaries.PersonalInfo).State = EntityState.Modified;
                        }
                        else if (contingentBeniciaries.PersonalInfo != null && conintengentBeneficiaryLookup.PersonalInfo == null)
                        {
                            if (ctx.FamilyMember.Where(x => x.FamilyMemberId == contingentBeniciaries.PersonalInfo.FamilyMemberId).Any())
                            {
                                ctx.Entry(contingentBeniciaries.PersonalInfo).State = EntityState.Modified;
                            }
                            else
                            {
                                ctx.Add(contingentBeniciaries.PersonalInfo);
                            }
                        }

                    }
                    else
                    {
                        if (ctx.FamilyOrBeneficiary.Where(x => x.FamilyOrBeneficiaryId == contingentBeniciaries.FamilyOrBeneficiaryId).Any())
                        {
                            ctx.Entry(contingentBeniciaries).State = EntityState.Modified;

                            var familyMemberLookup = ctx.FamilyMember.Where(x => x.FamilyMemberId == contingentBeniciaries.PersonalInfo.FamilyMemberId);
                            if (familyMemberLookup.Any())
                            {
                                ctx.Entry(contingentBeniciaries.PersonalInfo).State = EntityState.Modified;
                            }
                        }
                        else
                        {

                            ctx.Add(contingentBeniciaries);
                        }

                    }

                }

                var contingentBenficiariesToDelete = applicationFromDb.ContingentBeneficiaries.Where(s => !application.ContingentBeneficiaries.Where(es => es.FamilyOrBeneficiaryId == s.FamilyOrBeneficiaryId).Any());

                foreach (var contingentbenficiaryToDelete in contingentBenficiariesToDelete)
                {
                    ctx2.FamilyOrBeneficiary.Remove(contingentbenficiaryToDelete);
                }






                foreach (var healthQuestion in application.HealthQuestions)
                {
                    HealthQuestion healthQuestionLookup = null;
                    if (applicationFromDb.HealthQuestions != null)
                    {
                        healthQuestionLookup = applicationFromDb.HealthQuestions.Where(x => x.HealthQuestionId == healthQuestion.HealthQuestionId).FirstOrDefault();
                    }

                    if (healthQuestionLookup == null)
                    {
                        if (ctx.HealthQuestion.Where(x => x.HealthQuestionId == healthQuestion.HealthQuestionId).Any())
                        {
                            ctx.Entry(healthQuestion).State = EntityState.Modified;
                        }
                        else
                        {
                            ctx.Add(healthQuestion);
                        }

                    }
                    else
                    {
                        ctx.Entry(healthQuestion).State = EntityState.Modified;
                    }
                }


                var healthQuestionsToDelete = applicationFromDb.HealthQuestions.Where(s => !application.HealthQuestions.Where(es => es.HealthQuestionId == s.HealthQuestionId).Any());
                foreach (var healthQuestionToDelete in healthQuestionsToDelete)
                {
                    ctx2.HealthQuestion.Remove(healthQuestionToDelete);
                }

                _omniSend.SendToOmniSend(application);

                ctx.Database.BeginTransaction();
                ctx2.Database.BeginTransaction();
                ctx2.SaveChanges();
                ctx.SaveChanges();
                ctx2.Database.CommitTransaction();
                ctx.Database.CommitTransaction();



                _logger.LogInformation($"Successfully Updated Application {0}", application.ApplicationId);
            }


        }

        public async Task DeleteApplication(Guid applicationId)
        {

            _logger.LogInformation($"Deleting Application {0}", applicationId);
            ctx.RemoveRange(ctx.Application.Where(x => x.ApplicationId == applicationId));
            ctx.SaveChanges();
            _logger.LogInformation($"Successfully deleted Application {0}", applicationId);

        }

        public async Task<string> GetApplicationByEmailPhone(string email, string phone)
        {
             var application = ctx.Application.Where(x => x.LeadInfo.Email == email && x.LeadInfo.Phone == phone).Include(e => e.ApplicationInfo)
                    .Include(e => e.Beneficiaries)
                        .ThenInclude(x => x.PersonalInfo)
                    .Include(e => e.PaymentInfo)
                    .Include(e => e.LeadInfo)
                    .Include(e => e.HealthQuestions)
                    .Include(e => e.Designee)
                        .Include(e => e.ContingentBeneficiaries)
                         .ThenInclude(x => x.PersonalInfo)
                    .FirstOrDefault();
            
            application.ChallengeCode = RandomNumberGenerator.GetInt32(1000, 9999).ToString();
            application.ExpirationDate = DateTime.Now.AddMinutes(30);
            _sendGrid.SendResumeEmail(application);

            ctx.SaveChanges();
            return application.ChallengeCode;
        }

        public async Task<Application> GetApplicationByChallengeCode(string email, string phone, string challengeCode)
        {
            var application = ctx.Application.Where(x => x.LeadInfo.Email == email && x.LeadInfo.Phone == phone && x.ChallengeCode == challengeCode)
                   .Include(e => e.ApplicationInfo)
                   .Include(e => e.Beneficiaries)
                       .ThenInclude(x => x.PersonalInfo)
                   .Include(e => e.PaymentInfo)
                   .Include(e => e.LeadInfo)
                   .Include(e => e.HealthQuestions)
                   .Include(e => e.Designee)
                       .Include(e => e.ContingentBeneficiaries)
                        .ThenInclude(x => x.PersonalInfo)
                   .FirstOrDefault();

            if(application != null && application.ExpirationDate > DateTime.Now)
            {
                return application;
            }
            else
            {
                throw new RepoLayerException(ErrorCode.BadRequest, "Code has expired");
            }
        }

    }
}
