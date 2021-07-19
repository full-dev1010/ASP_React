using ForSureLife.Models.DTO;
using ForSureLife.repo;
using ForSureLife.repo.Models.Quote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface ILeadInfoManager
    {
        public Task<Guid> CreateLead(Application application);
        Task<Lead> GetLead(Guid leadId, Guid applicationId);
        Task UpdateLead(Application application);
        Task DeleteLead(Guid leadId, Guid guid);
        Task SaleOfLead(LeadSale leadSale);
        Task SaleOfLead(List<LeadSale> leadSales);
    }
}
