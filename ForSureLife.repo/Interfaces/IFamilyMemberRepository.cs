using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IFamilyMemberRepository
    {
        Task<Guid> CreateFamilyMember(FamilyMember familyMember, Guid applicationId);
        Task<FamilyMember> GetFamilyMember(Guid familyMemberId, Guid applicationId);
        Task UpdateFamilyMember(FamilyMember familyMember, Guid applicationId);
        Task DeleteFamilyMember(Guid familyMemberId, Guid applicationId);
    }
}
