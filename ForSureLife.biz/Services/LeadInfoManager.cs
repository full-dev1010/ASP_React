using ForSureLife.biz.Interfaces;
using ForSureLife.Models.DTO;
using ForSureLife.repo;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Quote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class LeadInfoManager : ILeadInfoManager
    {
        public ILeadRepository _leadRepo { get; set; }
        public LeadInfoManager(ILeadRepository leadRepo)
        {
            _leadRepo = leadRepo;
        }
        public async Task<Guid> CreateLead(Application application)
        {
            return await _leadRepo.CreateLead(application);
        }

        public async Task<Lead> GetLead(Guid leadId, Guid applicationId)
        {
            return await _leadRepo.GetLead(leadId, applicationId);
        }

        public async Task UpdateLead(Application application)
        {
            await _leadRepo.UpdateLead(application);
        }

        public async Task DeleteLead(Guid leadId, Guid applicationId)
        {
            await _leadRepo.DeleteLead(leadId, applicationId);
        }

        public async Task SaleOfLead(LeadSale leadSale)
        {
            await _leadRepo.CreateLeadSale(leadSale);
         
        }

        public async Task SaleOfLead(List<LeadSale> leadSales)
        {
            await _leadRepo.CreateLeadSale(leadSales);
        }
    }
}
