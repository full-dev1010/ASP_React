using ForSureLife.repo.Models.Quote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Interfaces
{
    public interface IHealthQuestionManager
    {
        Task<Guid> CreateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId);
        Task<HealthQuestion> GetHealthQuestion(int healthQuestionId, Guid applicationId, bool leadQuestion);
        Task UpdateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId);
        Task DeleteHealthQuestion(Guid healthQuestionId, Guid applicationId);
        Task<List<HealthQuestion>> GetHealthQuestions(Guid applicationId, bool leadQuestion);
        Task<List<HealthQuestion>> CreateHealthQuestions(List<HealthQuestion> healthQuestion, Guid applicationId);
    }
}
