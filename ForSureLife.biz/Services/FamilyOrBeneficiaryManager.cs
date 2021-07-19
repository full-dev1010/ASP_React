using ForSureLife.biz.Interfaces;
using ForSureLife.Models.DTO;
using ForSureLife.repo;
using ForSureLife.repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class FamilyOrBeneficiaryManager : IFamilyOrBeneficiaryManager
    {

        public IFamilyOrBeneficiaryRepository _familyOrBeneRepo {get; set;}
        public FamilyOrBeneficiaryManager(IFamilyOrBeneficiaryRepository familyOrBeneRepo)
        {
            _familyOrBeneRepo = familyOrBeneRepo;
        }
        public async Task<List<FamilyOrBeneficiary>> CreateOrUpdateFamilyOrBeneficiary(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId)
        {
            return await _familyOrBeneRepo.CreateFamilyOrBeneficiary(familyOrBeneficiary, applicationId);
        }

        public async Task DeleteFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId)
        {
            await _familyOrBeneRepo.DeleteFamilyOrBeneficiary(familyOrBeneficiaryId, applicationId);
        }

        public async Task<FamilyOrBeneficiary> GetFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId)
        {
            return await _familyOrBeneRepo.GetFamilyOrBeneficiary(familyOrBeneficiaryId, applicationId);
        }

        public async Task UpdateFamilyOrBeneficiaryr(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId)
        {
             await _familyOrBeneRepo.UpdateFamilyOrBeneficiaryr(familyOrBeneficiary, applicationId);
        }

        public async Task<FamilyOrBeneficiary> GetFamilyOrBeneficiaryForSeparateOwner(Guid applicationId)
        {
            return await _familyOrBeneRepo.GetFamilyOrBeneficiaryForSeparateOwner(applicationId);
        }

        public async Task<List<FamilyOrBeneficiary>> GetFamilyOrBeneficiaries(Guid applicationId)
        {
            return await _familyOrBeneRepo.GetFamilyOrBeneficiaries(applicationId);
        }

        public async Task<List<FamilyOrBeneficiary>> CreateOrUpdateFamilyOrBeneficiary(List<FamilyOrBeneficiary> familyOrBeneficiaries, Guid applicationId)
        {
            List<FamilyOrBeneficiary> familyList = null;
            foreach (var family in familyOrBeneficiaries)
            {
                familyList = await CreateOrUpdateFamilyOrBeneficiary(family, applicationId);
            }
            return familyList;
        }

        public async Task<FamilyOrBeneficiary> GetFamilyOrBeneficiaries(Guid familyOrMemberId, Guid applicationId)
        {
            return await _familyOrBeneRepo.GetFamilyOrBeneficiary(familyOrMemberId, applicationId);
        }
    }
}
