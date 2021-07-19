using ForSureLife.biz.Interfaces;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Quote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class HealthQuestionManager : IHealthQuestionManager
    {
        public IHealthQuestionsRepository _HealthQuestionRepo { get; set; }

        public HealthQuestionManager(IHealthQuestionsRepository HealthQuestionRepo)
        {
            _HealthQuestionRepo = HealthQuestionRepo;
        }
        public async Task<Guid> CreateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId)
        {
            return await _HealthQuestionRepo.CreateHealthQuestion(healthQuestion, applicationId);
        }

        public async Task DeleteHealthQuestion(Guid healthQuestionId, Guid applicationId)
        {
             await _HealthQuestionRepo.DeleteHealthQuestion(healthQuestionId, applicationId);
        }

        public async Task<HealthQuestion> GetHealthQuestion(int healthQuestionId, Guid applicationId, bool LeadQuestion)
        {
            return await _HealthQuestionRepo.GetHealthQuestion(healthQuestionId, applicationId, LeadQuestion);
        }

        public async Task UpdateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId)
        {
            await _HealthQuestionRepo.UpdateHealthQuestion(healthQuestion, applicationId);
        }

        public async Task<List<HealthQuestion>> GetHealthQuestions(Guid applicationId, bool LeadQuestion)
        {
            return await _HealthQuestionRepo.GetHealthQuestions(applicationId, LeadQuestion);
        }

        public async Task<List<HealthQuestion>> CreateHealthQuestions(List<HealthQuestion> healthQuestion, Guid applicationId)
        {
            return await _HealthQuestionRepo.CreateHealthQuestion(healthQuestion, applicationId);
        }

    }
}
