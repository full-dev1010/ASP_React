using ForSureLife.Models.Enums;
using ForSureLife.repo.Models.Enroll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IAmAmApplicationRepository
    {
        Task<AAFinalExpense> GetApplication(Guid applicationId);
        Task<List<AmAmApplicationQuestions>> GetStateQuestions(States? state);
        Task UpdateApplication(AAFinalExpense application);
        Task SubmitApplication(Guid guid);
        Task<int> GetApplicationNumber();
        Task<string> GetStateAbbreviation(string applicationState);

        Task<List<AAFinalExpense>> GetSalesLeads();
    }
}
