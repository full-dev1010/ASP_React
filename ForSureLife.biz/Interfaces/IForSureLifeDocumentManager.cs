using ForSureLife.repo.Models.Enroll;
using System;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface IForSureLifeDocumentManager
    {
        Task SubmitApplicationFiles(AAFinalExpense application);
        Task<string> GetApplicationPDF(Guid guid);
    }
}
