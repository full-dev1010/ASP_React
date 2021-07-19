using ForSureLife.Models.Enums;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Enroll;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Services
{
    public class AmAmApplicationRepository : IAmAmApplicationRepository
    {
        private readonly ForSureLifeDBContext ctx;
        public AmAmApplicationRepository(ForSureLifeDBContext _ctx)
        {
            ctx = _ctx;
        }
        public async Task<AAFinalExpense> GetApplication(Guid applicationId)
        {

            var application = ctx.Application.Where(x => x.ApplicationId == applicationId).Include(e => e.ApplicationInfo)
                .Include(e => e.Beneficiaries)
                    .ThenInclude(x => x.PersonalInfo)
                .Include(e => e.PaymentInfo)
                .Include(e => e.LeadInfo)
                .Include(e => e.Designee)
                .Include(e => e.ContingentBeneficiaries)
                    .ThenInclude(e => e.PersonalInfo)
                .Include(e => e.HealthQuestions).FirstOrDefault();

            var test = Enum.TryParse(application.LeadInfo.State, out States state);

            var amAmFinalExpense = ctx.AmAmFinalExpense.Where(x => x.Application.ApplicationId == applicationId)
                  .Include(x => x.ApplicationAnswers)
                  .ThenInclude(x => x.Question)
                        .Where(x => x.ApplicationAnswers
                        .Any(x => x.Question.States
                        .Any(x => x.AmState.StateIdEnum == state)))
                        .FirstOrDefault();



            if (amAmFinalExpense == null)
            {
                amAmFinalExpense = new AAFinalExpense();
                amAmFinalExpense.AAFinalExpenseId = Guid.NewGuid();



            }

            var amState = ctx.AmState.Where(x => x.StateIdEnum == state).FirstOrDefault();
            amAmFinalExpense.InsuranceCompanyName = amState.InsuranceCompany;
            amAmFinalExpense.LicenseNumber = amState.LicenseNumber;
            amAmFinalExpense.ApplicationState = state;
            amAmFinalExpense.Application = application;

            return amAmFinalExpense;

        }

        public async Task<int> GetApplicationNumber()
        {

            var p = new SqlParameter("@result", System.Data.SqlDbType.Int);
            p.Direction = System.Data.ParameterDirection.Output;
            ctx.Database.ExecuteSqlRaw("set @result = NEXT VALUE FOR app_file_counter", p);
            var nextVal = (int)p.Value;
            return nextVal;

        }

        public async Task<List<AAFinalExpense>> GetSalesLeads()
        {
            var completedSales = ctx.AmAmFinalExpense.Where(x => x.Signed == true && x.Application.LeadCaputred == false)
                .Include(e => e.Application)
                    .ThenInclude(e => e.ApplicationInfo)
                .Include(e => e.Application)
                    .ThenInclude(e => e.LeadInfo)
                .Include(e => e.Application)
                    .ThenInclude(e => e.HealthQuestions);

            return completedSales.ToList();
        }

        public async Task<List<AAFinalExpense>> GetLeads()
        {
            
            var completedSales = ctx.AmAmFinalExpense.Where(x => x.Signed == true && x.Application.LeadCaputred == false)
                .Include(e => e.Application)
                    .ThenInclude(e => e.ApplicationInfo)
                .Include(e => e.Application)
                    .ThenInclude(e => e.LeadInfo)
                .Include(e => e.Application)
                    .ThenInclude(e => e.HealthQuestions);

            return completedSales.ToList();
        }


        public async Task<string> GetStateAbbreviation(string applicationState)
        {
            var stateAbbreviation = ctx.BirthPlaces.Where(x => x.Name == applicationState).Select(x => x.Abbreviation).FirstOrDefault();
            if(stateAbbreviation == null)
            {
                return applicationState;
            }
            return stateAbbreviation;
        }

        //public async Task<List<AmAmApplicationQuestions>> GetStateQuestionsOnly(States? state)
        //{
        //    using (var ctx = new ForSureLifeDBContext())
        //    {

        //        var questions = ctx.AmAmApplicationQuestions
        //                 .Include(x => x.States)
        //                     .ThenInclude(x => x.AmState)
        //                          .Where(x => x.States
        //                          .Any(x => x.AmState.StateIdEnum == state))
        //                 .FirstOrDefault();

        //        return questions.ToList();

        //    }
        //}

        public async Task<List<AmAmApplicationQuestions>> GetStateQuestions(States? state)
        {


            var questions = ctx.AmAmApplicationQuestions.Where(x => x.States.Any(x => x.AmState.StateIdEnum == state));

            return questions.ToList();

        }

        public async Task SubmitApplication(Guid guid)
        {

            throw new NotImplementedException();
        }

        public async Task UpdateApplication(AAFinalExpense application)
        {
            try
            {
                ctx.Database.BeginTransaction();
                ctx.Entry(application.Application).State = EntityState.Unchanged;
                foreach (var question in application.ApplicationAnswers)
                {
                    ctx.Entry(question.Question).State = EntityState.Unchanged;
                }


                if (!ctx.AmAmFinalExpense.Where(x => x.AAFinalExpenseId == application.AAFinalExpenseId).Any())
                {

                    ctx.Add(application);
                }
                else
                {
                    ctx.Entry(application).State = EntityState.Modified;
                    foreach (var question in application.ApplicationAnswers)
                    {

                        ctx.Entry(question).State = EntityState.Modified;
                    }
                }
                ctx.SaveChanges();
                ctx.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                var test = ex;
            }
        }
    }
}
