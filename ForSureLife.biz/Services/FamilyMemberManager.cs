using ForSureLife.biz.Interfaces;
using ForSureLife.repo;
using ForSureLife.repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class FamilyMemberManager : IFamilyMemberManager
    {

        public IFamilyMemberRepository _familyRepo { get; set; }
        public FamilyMemberManager(IFamilyMemberRepository familyOrBeneRepo)
        {
            _familyRepo = familyOrBeneRepo;
        }

        public async Task<Guid> CreateFamilyMember(FamilyMember familyMember, Guid applicationId)
        {
            return await _familyRepo.CreateFamilyMember(familyMember, applicationId);
        }

        public async Task DeleteFamilyMember(Guid familyMemberId, Guid applicationId)
        {
             await _familyRepo.DeleteFamilyMember(familyMemberId, applicationId);
        }

        public async Task<FamilyMember> GetFamilyMember(Guid familyMemberId, Guid applicationId)
        {
            return await _familyRepo.GetFamilyMember(familyMemberId, applicationId);
        }

        public async Task UpdateFamilyMember(FamilyMember familyMember, Guid applicationId)
        {
             await _familyRepo.UpdateFamilyMember(familyMember, applicationId);
        }
    }
}
