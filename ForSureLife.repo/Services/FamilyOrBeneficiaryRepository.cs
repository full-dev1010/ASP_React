using ForSureLife.Models.Enums;
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
    public class FamilyOrBeneficiaryRepository : BaseRepository, IFamilyOrBeneficiaryRepository
    {
        private readonly ForSureLifeDBContext ctx;
        private readonly ILogger _logger;

        public FamilyOrBeneficiaryRepository(ILoggerFactory logFactory, ForSureLifeDBContext _ctx)
        {
            ctx = _ctx;
            _logger = logFactory.CreateLogger<FamilyOrBeneficiaryRepository>();
        }
        public async Task<List<FamilyOrBeneficiary>> CreateFamilyOrBeneficiary(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId)
        {
          
                _logger.LogInformation($"Creating FamilyOrBeneficiary {0}", applicationId);
                var applicationFromDb = GetApplicationFromDb(applicationId, ctx);
                if (applicationFromDb.Beneficiaries == null || !applicationFromDb.Beneficiaries.Any())
                {
                    applicationFromDb.Beneficiaries.Add(familyOrBeneficiary);                  
                }
                else if(Convert.ToInt32(familyOrBeneficiary.PrimaryRelationship) >= 21 && Convert.ToInt32(familyOrBeneficiary.PrimaryRelationship) <= 25)
                {
                    if (applicationFromDb.Beneficiaries.Where(x => Convert.ToInt32(familyOrBeneficiary.PrimaryRelationship) >= 21 && Convert.ToInt32(familyOrBeneficiary.PrimaryRelationship) <= 25).Any())
                    {       
                        var currentBeneificary = applicationFromDb.Beneficiaries.Where(x => Convert.ToInt32(familyOrBeneficiary.PrimaryRelationship) >= 21 && Convert.ToInt32(familyOrBeneficiary.PrimaryRelationship) <= 25).FirstOrDefault();

                        currentBeneificary.Percentage = familyOrBeneficiary.Percentage;
                        currentBeneificary.PrimaryRelationship = familyOrBeneficiary.PrimaryRelationship;
                        currentBeneificary.Relationships = familyOrBeneficiary.Relationships;                   

                        ctx.Entry(currentBeneificary).State = EntityState.Modified;
                      
                        if (currentBeneificary.PersonalInfo != null)
                        {
                            currentBeneificary.PersonalInfo.Address1 = familyOrBeneficiary.PersonalInfo.Address1;
                            currentBeneificary.PersonalInfo.Address2 = familyOrBeneficiary.PersonalInfo.Address2;

                            currentBeneificary.PersonalInfo.City = familyOrBeneficiary.PersonalInfo.City;
                            currentBeneificary.PersonalInfo.DateOfBirth = familyOrBeneficiary.PersonalInfo.DateOfBirth;
                            currentBeneificary.PersonalInfo.FirstName = familyOrBeneficiary.PersonalInfo.FirstName;
                            currentBeneificary.PersonalInfo.HeightFt = familyOrBeneficiary.PersonalInfo.HeightFt;
                            currentBeneificary.PersonalInfo.HeightIn = familyOrBeneficiary.PersonalInfo.HeightIn;
                            currentBeneificary.PersonalInfo.LastName = familyOrBeneficiary.PersonalInfo.LastName;
                            currentBeneificary.PersonalInfo.LastName = familyOrBeneficiary.PersonalInfo.LastName;
                            currentBeneificary.PersonalInfo.SSN = familyOrBeneficiary.PersonalInfo.SSN;

                            currentBeneificary.PersonalInfo.State = familyOrBeneficiary.PersonalInfo.State;
                            currentBeneificary.PersonalInfo.StateOfBirth = familyOrBeneficiary.PersonalInfo.StateOfBirth;
                            currentBeneificary.PersonalInfo.Weight = familyOrBeneficiary.PersonalInfo.Weight;

                            ctx.Entry(currentBeneificary.PersonalInfo).State = EntityState.Modified;
                        }
                        else if (currentBeneificary.PersonalInfo != null && currentBeneificary.PersonalInfo == null && familyOrBeneficiary.PersonalInfo != null)
                        {
                            currentBeneificary.PersonalInfo = familyOrBeneficiary.PersonalInfo;
                            ctx.Add(currentBeneificary.PersonalInfo);
                        }
                        
                    }
                    else
                    {
                        applicationFromDb.Beneficiaries.Add(familyOrBeneficiary);
                        ctx.Add(applicationFromDb.Beneficiaries);
                      
                    }                  
                }

                ctx.SaveChanges();
              
                return applicationFromDb.Beneficiaries;
            
        }

        public async Task DeleteFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId)
        {
           
                var beneificairies = ctx.Application.Where(x => x.ApplicationId == applicationId)
                  .Include(e => e.Beneficiaries)
                  .ThenInclude(e => e.PersonalInfo)
                  .Select(x => x.Beneficiaries.Where(x => x.FamilyOrBeneficiaryId == familyOrBeneficiaryId)).FirstOrDefault();
                ctx.FamilyOrBeneficiary.RemoveRange(beneificairies);

            
       
        }

        public async Task<FamilyOrBeneficiary> GetFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId)
        {
         
                var beneificairies = ctx.Application.Where(x => x.ApplicationId == applicationId)
                  .Include(e => e.Beneficiaries)
                  .ThenInclude(e => e.PersonalInfo)
                  .Select(x => x.Beneficiaries.Where(x => x.FamilyOrBeneficiaryId == familyOrBeneficiaryId)).FirstOrDefault();
                return beneificairies.FirstOrDefault();
            
        }

        public async Task<List<FamilyOrBeneficiary>> GetFamilyOrBeneficiaries(Guid applicationId)
        {
           
                var beneificairies = ctx.Application.Where(x => x.ApplicationId == applicationId)
                  .Include(e => e.Beneficiaries)
                  .ThenInclude(e => e.PersonalInfo)
                  .Select(x => x.Beneficiaries);

                return (List<FamilyOrBeneficiary>) beneificairies;
            
        }


        public async Task<FamilyOrBeneficiary> GetFamilyOrBeneficiaryForSeparateOwner(Guid applicationId)
        {
           
                _logger.LogInformation($"Getting FamilyOrBeneficiaryForSeparateOwne {0}", applicationId);

                var beneificairies = ctx.Application.Where(x => x.ApplicationId == applicationId)
                    .Include(e => e.Beneficiaries)
                    .ThenInclude(e => e.PersonalInfo)
                    .Select(x => x.Beneficiaries.Where(x => Convert.ToInt32(x.PrimaryRelationship) >= 21 && Convert.ToInt32(x.PrimaryRelationship) <= 25)).FirstOrDefault();

                if (beneificairies is null)
                {
                    _logger.LogError($"FamilyOrBeneficiaryForSeparateOwne Does not exist in DB Application {0}", applicationId);
                    throw new RepoLayerException(ErrorCode.NotFound, "FamilyOrBeneficiaryForSeparateOwne Is NOt Found Not found");
                }

                _logger.LogInformation($"Successfully retrieved from Db FamilyOrBeneficiaryForSeparateOwne  {0}", applicationId);
                return beneificairies.FirstOrDefault(); 
            
        }

        public async Task UpdateFamilyOrBeneficiaryr(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId)
        {
           
                var currentBeneificary = ctx.FamilyOrBeneficiary.Where(x => x.FamilyOrBeneficiaryId == familyOrBeneficiary.FamilyOrBeneficiaryId).FirstOrDefault();

                currentBeneificary.Percentage = familyOrBeneficiary.Percentage;
                currentBeneificary.PrimaryRelationship = familyOrBeneficiary.PrimaryRelationship;
                currentBeneificary.Relationships = familyOrBeneficiary.Relationships;

                ctx.Entry(currentBeneificary).State = EntityState.Modified;

                if (currentBeneificary.PersonalInfo != null)
                {
                    currentBeneificary.PersonalInfo.Address1 = familyOrBeneficiary.PersonalInfo.Address1;
                    currentBeneificary.PersonalInfo.Address2 = familyOrBeneficiary.PersonalInfo.Address2;

                    currentBeneificary.PersonalInfo.City = familyOrBeneficiary.PersonalInfo.City;
                    currentBeneificary.PersonalInfo.DateOfBirth = familyOrBeneficiary.PersonalInfo.DateOfBirth;
                    currentBeneificary.PersonalInfo.FirstName = familyOrBeneficiary.PersonalInfo.FirstName;
                    currentBeneificary.PersonalInfo.HeightFt = familyOrBeneficiary.PersonalInfo.HeightFt;
                    currentBeneificary.PersonalInfo.HeightIn = familyOrBeneficiary.PersonalInfo.HeightIn;
                    currentBeneificary.PersonalInfo.LastName = familyOrBeneficiary.PersonalInfo.LastName;
                    currentBeneificary.PersonalInfo.LastName = familyOrBeneficiary.PersonalInfo.LastName;
                    currentBeneificary.PersonalInfo.SSN = familyOrBeneficiary.PersonalInfo.SSN;

                    currentBeneificary.PersonalInfo.State = familyOrBeneficiary.PersonalInfo.State;
                    currentBeneificary.PersonalInfo.StateOfBirth = familyOrBeneficiary.PersonalInfo.StateOfBirth;
                    currentBeneificary.PersonalInfo.Weight = familyOrBeneficiary.PersonalInfo.Weight;

                    ctx.Entry(currentBeneificary.PersonalInfo).State = EntityState.Modified;
                }
                ctx.SaveChanges();
           
        }
    }
}
