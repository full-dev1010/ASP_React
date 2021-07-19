using ForSureLife.Models.DTO;
using ForSureLife.repo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface IFamilyOrBeneficiaryManager
    {
        Task<List<FamilyOrBeneficiary>> CreateOrUpdateFamilyOrBeneficiary(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId);
        Task<List<FamilyOrBeneficiary>> CreateOrUpdateFamilyOrBeneficiary(List<FamilyOrBeneficiary> familyOrBeneficiaries, Guid applicationId);
        Task<FamilyOrBeneficiary> GetFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId);
        Task UpdateFamilyOrBeneficiaryr(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId);
        Task DeleteFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId);
        Task<FamilyOrBeneficiary> GetFamilyOrBeneficiaryForSeparateOwner(Guid guid);
        Task<List<FamilyOrBeneficiary>> GetFamilyOrBeneficiaries(Guid applicationId);
        Task<FamilyOrBeneficiary> GetFamilyOrBeneficiaries(Guid familyOrMemberId, Guid applicationId);
    }
}
