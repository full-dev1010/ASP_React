using ForSureLife.repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class FamilyMemberRepository : BaseRepository, IFamilyMemberRepository
    {
        public Task<Guid> CreateFamilyMember(FamilyMember familyMember, Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFamilyMember(Guid familyMemberId, Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<FamilyMember> GetFamilyMember(Guid familyMemberId, Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFamilyMember(FamilyMember familyMember, Guid applicationId)
        {
            throw new NotImplementedException();
        }
    }
}
