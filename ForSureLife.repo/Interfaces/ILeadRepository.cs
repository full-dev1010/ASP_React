using ForSureLife.repo.Models.Enroll;
using ForSureLife.repo.Models.Quote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface ILeadRepository
    {
        Task<Guid> CreateLead(Application application);
        Task<Lead> GetLead(Guid leadId, Guid applicationId);
        Task UpdateLead(Application application);
        Task DeleteLead(Guid leadId, Guid applicationId);
        Task CreateLeadSale(LeadSale leadSale);
        Task CreateLeadSale(List<LeadSale> leadSale);
    }
}
