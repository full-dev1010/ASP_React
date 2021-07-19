using ForSureLife.Models.DTO;
using ForSureLife.Models.Enums;
using ForSureLife.repo.Models.Enroll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface IAmAmQuoteRateManager
    {
        Task<QuoteDto> GetQuoteData(Guid applicationId);
        Task<AAFinalExpense> GetApplication(Guid applicationId);
        Task<AAFinalExpense> UpdateApplication(AAFinalExpense application);
        Task SubmitApplication(Guid guid);
        Task<string> GetApplicationPDF(Guid guid);
    }
}
