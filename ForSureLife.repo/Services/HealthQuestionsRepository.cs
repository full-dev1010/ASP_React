using ForSureLife.Models.Enums;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Quote;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class HealthQuestionsRepository : BaseRepository, IHealthQuestionsRepository
    {
        private readonly ForSureLifeDBContext ctx;
        public HealthQuestionsRepository(ForSureLifeDBContext _ctx)
        {
            ctx = _ctx;
        }
        public async Task<Guid> CreateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId)
        {
          
                var application = GetApplicationFromDb(applicationId, ctx);
                application.HealthQuestions.Add(healthQuestion);
                ctx.SaveChanges();

                return healthQuestion.HealthQuestionId;
            
        }

        public async Task<List<HealthQuestion>> CreateHealthQuestion(List<HealthQuestion> healthQuestion, Guid applicationId)
        {
           
                var application = GetApplicationFromDb(applicationId, ctx);
                application.HealthQuestions.AddRange(healthQuestion);
                ctx.SaveChanges();

                return healthQuestion;
            
        }

        public async Task DeleteHealthQuestion(Guid healthQuestionId, Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public async Task<HealthQuestion> GetHealthQuestion(int healthQuestionId, Guid applicationId, bool LeadQuestion)
        {
           
                if (LeadQuestion)
                {
                    var question = ctx.Application.Where(x => x.ApplicationId == applicationId)
                         .Include(x => x.HealthQuestions).Select(x => x.HealthQuestions.Where(x => x.LeadHealthQuestion == (LeadHealthQuestions)healthQuestionId)).FirstOrDefault().FirstOrDefault();
                    return question;

                }
                else
                {
                    var question = ctx.Application.Where(x => x.ApplicationId == applicationId)
                         .Include(x => x.HealthQuestions).Select(x => x.HealthQuestions.Where(x => x.ApplicationQuestion == (ApplicationHealthQuestions)healthQuestionId)).FirstOrDefault().FirstOrDefault();
                    return question;
                }
            
            
        }

        public async Task<List<HealthQuestion>> GetHealthQuestions(Guid applicationId, bool LeadQuestion)
        {
           
                if (LeadQuestion)
                {

                    var question = ctx.Application.Where(x => x.ApplicationId == applicationId)
                                         .Include(x => x.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.NullValue)).Select(x => x.HealthQuestions).FirstOrDefault();
                    return question;
                }
                else
                {
                    var question = ctx.Application.Where(x => x.ApplicationId == applicationId)
                                         .Include(x => x.HealthQuestions.Where(x => x.LeadHealthQuestion == LeadHealthQuestions.NotAvailable)).Select(x => x.HealthQuestions).FirstOrDefault();
                    return question;
                }

            
        }

        public async Task UpdateHealthQuestion(HealthQuestion healthQuestion, Guid applicationId)
        {
            
                var question = ctx.Application.Where(x => x.ApplicationId == applicationId)
                     .Include(x => x.HealthQuestions).Select(x => x.HealthQuestions.Where(x => x.HealthQuestionId == healthQuestion.HealthQuestionId)).FirstOrDefault().FirstOrDefault();
                question.HealthAnswer = healthQuestion.HealthAnswer;
                question.HealthQuestionName = healthQuestion.HealthQuestionName;
                question.ApplicationQuestion = healthQuestion.ApplicationQuestion;
                question.LeadHealthQuestion = healthQuestion.LeadHealthQuestion;
                question.Occurence = healthQuestion.Occurence;
                ctx.Entry(question).State = EntityState.Modified;
                ctx.SaveChanges();
            
            
        }
    }
}
