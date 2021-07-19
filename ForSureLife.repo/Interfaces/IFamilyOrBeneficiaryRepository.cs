using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IFamilyOrBeneficiaryRepository
    {
        Task<List<FamilyOrBeneficiary>> CreateFamilyOrBeneficiary(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId);
        Task<FamilyOrBeneficiary> GetFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId);
        Task UpdateFamilyOrBeneficiaryr(FamilyOrBeneficiary familyOrBeneficiary, Guid applicationId);
        Task DeleteFamilyOrBeneficiary(Guid familyOrBeneficiaryId, Guid applicationId);
        Task<FamilyOrBeneficiary> GetFamilyOrBeneficiaryForSeparateOwner(Guid applicationId);
        Task<List<FamilyOrBeneficiary>> GetFamilyOrBeneficiaries(Guid applicationId);
    }
}
