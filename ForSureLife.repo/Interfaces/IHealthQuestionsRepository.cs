using ForSureLife.repo.Models.Quote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Interfaces
{
    public interface IHealthQuestionsRepository
    {
        Task<Guid> CreateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId);
        Task<HealthQuestion> GetHealthQuestion(int healthQuestionId, Guid applicationId,bool LeadQuestion);
        Task UpdateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId);
        Task DeleteHealthQuestion(Guid healthQuestionId, Guid applicationId);
        Task<List<HealthQuestion>> GetHealthQuestions(Guid applicationId, bool LeadQuestion);
        Task<List<HealthQuestion>> CreateHealthQuestion(List<HealthQuestion> healthQuestion, Guid applicationId);
    }
}
