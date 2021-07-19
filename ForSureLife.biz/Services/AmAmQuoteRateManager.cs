using AutoMapper;
using ForSureLife.biz.Interfaces;
using ForSureLife.Models.DTO;
using ForSureLife.Models.Enums;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Models.Enroll;
using ForSureLife.repo.Models.Rate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.biz.Services
{
    public class AmAmQuoteRateManager : IAmAmQuoteRateManager
    {
        public IMapper _mapper { get; set; }
        public IApplicationRepository _applicationRepo { get; set; }
        public IAmAmApplicationRepository _amAmRepository { get; set; }
        public IForSureLifeDocumentManager forSureLifeDocumentManager { get; set; }
        public IRateAmAmRepository _rateRepo { get; set; }
        public AmAmQuoteRateManager(IRateAmAmRepository rateRepo, IApplicationRepository applicationRepo, IAmAmApplicationRepository amAmRepository, IMapper mapper, IForSureLifeDocumentManager forSureLifeDocumentManager)
        {
            _applicationRepo = applicationRepo;
            _rateRepo = rateRepo;
            _amAmRepository = amAmRepository;
            _mapper = mapper;
            this.forSureLifeDocumentManager = forSureLifeDocumentManager;
        }
        public async Task<QuoteDto> GetQuoteData(Guid applicationId)
        {
            var application = _applicationRepo.GetApplication(applicationId).Result;
            var QuoteDto = _mapper.Map<QuoteDto>(application.LeadInfo);


            var rate = GetRates(application, QuoteDto);
            var rateSusa = GetRates(application, QuoteDto, null, InsuranceCompanyRate.Susa);
            var rateForester = GetRates(application, QuoteDto, null, InsuranceCompanyRate.Foresters);
            var rateEagle = GetRates(application, QuoteDto, null, InsuranceCompanyRate.Eagle);

            SetAmAMRates(application, QuoteDto, rate);
            SetSusaRates(application, QuoteDto, rateSusa);
            SetForsesterRates(application, QuoteDto, rateForester);
            SetEagleRates(application, QuoteDto, rateEagle);

            //   await _applicationRepo.UpdateApplication(application);
            return QuoteDto;
        }

        private void SetSusaRates(repo.Application application, QuoteDto QuoteDto, CarrierPlanRate rate)
        {
            QuoteDto.SusaRates = new List<RateDto>();
            // QuoteDto.PremiumType = rate.PremiumType;
            if (rate != null)
            {
                var beneiftMaxLimit = 35000;

                for (var benefitAmount = 2500; benefitAmount <= beneiftMaxLimit; benefitAmount = benefitAmount + 500)
                {
                    //Premium per $1,000 is $92.03 x 35 = $3,221.05
                    //Adding the policy fee is $3,221.05 + 30 = $3,251.05
                    //Adding the modal factor is $3,251.05 x 0.088 = $286.0924(round it up to the $286.10)
                    var rateDto = new RateDto();
                    rateDto.SelectedCoverage = false;
                    //   rateDto.AnnualRate = ((benefitAmount / 1000m) + 30) * rate.AnnualRate;
                    rateDto.BenefitCoverage = benefitAmount;
                    rateDto.MonthlyRate = Math.Round((((benefitAmount / 1000m) * rate.AnnualRate) * Convert.ToDecimal(.09)) + 3.60m + 6.50m, 2, MidpointRounding.ToPositiveInfinity);
                    QuoteDto.SusaRates.Add(rateDto);
                }
            }

        }

        private void SetForsesterRates(repo.Application application, QuoteDto QuoteDto, CarrierPlanRate rate)
        {
            QuoteDto.ForesterRates = new List<RateDto>();
            // QuoteDto.PremiumType = rate.PremiumType;
            if (rate != null)
            {
                var beneiftMaxLimit = 35000;

                for (var benefitAmount = 2500; benefitAmount <= beneiftMaxLimit; benefitAmount = benefitAmount + 500)
                {
                    //Premium per $1,000 is $92.03 x 35 = $3,221.05
                    //Adding the policy fee is $3,221.05 + 30 = $3,251.05
                    //Adding the modal factor is $3,251.05 x 0.088 = $286.0924(round it up to the $286.10)
                    var rateDto = new RateDto();
                    rateDto.SelectedCoverage = false;
                    //   rateDto.AnnualRate = ((benefitAmount / 1000m) + 30) * rate.AnnualRate;
                    rateDto.BenefitCoverage = benefitAmount;
                    rateDto.MonthlyRate = Math.Round(((((benefitAmount / 1000m) * rate.AnnualRate) + 36) * Convert.ToDecimal(.0875) + 6.50m), 2, MidpointRounding.ToPositiveInfinity);
                    QuoteDto.ForesterRates.Add(rateDto);
                }
            }
        }

        private void SetEagleRates(repo.Application application, QuoteDto QuoteDto, CarrierPlanRate rate)
        {

            var tobaco = application.HealthQuestions.Where(x => x.LeadHealthQuestion == LeadHealthQuestions.TobaccoUse).FirstOrDefault().HealthAnswer;
            var eagleRates = _rateRepo.GetEagleRates(application.LeadInfo.Gender, application.LeadInfo.PremiumType, tobaco, QuoteDto.Age).Result;


            QuoteDto.EagleRates = new List<RateDto>();

            if (eagleRates != null)
            {
                // QuoteDto.PremiumType = rate.PremiumType;
                var beneiftMaxLimit = 35000;
                var benefitAmount = 2500;
                foreach (var eagleRate in eagleRates)
                {
                    for (var benefitAmounts = benefitAmount; benefitAmounts <= eagleRate.BenefitAmount; benefitAmounts = benefitAmounts + 500)
                    {
                        var rateDto = new RateDto();
                        rateDto.SelectedCoverage = false;
                        //   rateDto.AnnualRate = ((benefitAmount / 1000m) + 30) * rate.AnnualRate;
                        rateDto.BenefitCoverage = benefitAmounts;
                        rateDto.MonthlyRate = eagleRate.AnnualRate + 6.50m;
                        QuoteDto.EagleRates.Add(rateDto);
                        benefitAmount = benefitAmount + 500;
                    }
                }
            }
        }

        private void SetAmAMRates(repo.Application application, QuoteDto QuoteDto, CarrierPlanRate rate)
        {
            QuoteDto.Rates = new List<RateDto>();
            // QuoteDto.PremiumType = rate.PremiumType;
            if (QuoteDto.SelectedBenefitAmount == 0)
            {
                QuoteDto.SelectedBenefitAmount = 10000;
            }

            var beneiftMaxLimit = 20000;
            if (rate.PremiumType == SeniorChoicePremiumType.Immediate && rate.Age <= 75)
            {
                beneiftMaxLimit = 35000;
            }

            for (var benefitAmount = 3000; benefitAmount <= beneiftMaxLimit; benefitAmount = benefitAmount + 1000)
            {
                //Premium per $1,000 is $92.03 x 35 = $3,221.05
                //Adding the policy fee is $3,221.05 + 30 = $3,251.05
                //Adding the modal factor is $3,251.05 x 0.088 = $286.0924(round it up to the $286.10)
                var rateDto = new RateDto();
                rateDto.SelectedCoverage = false;
                rateDto.AnnualRate = ((benefitAmount / 1000m) + 30) * rate.AnnualRate;
                rateDto.BenefitCoverage = benefitAmount;
                rateDto.MonthlyRate = Math.Round(((((benefitAmount / 1000m) * rate.AnnualRate) + 30) * Convert.ToDecimal(.088)), 2, MidpointRounding.ToPositiveInfinity);
                QuoteDto.Rates.Add(rateDto);
            }

            if (QuoteDto.Rates.Select(x => x.BenefitCoverage).Max() < application.LeadInfo.DesiredCoverageAmount)
            {
                QuoteDto.SelectedBenefitAmount = QuoteDto.Rates.Select(x => x.BenefitCoverage).Max();
            }
            else
            {
                QuoteDto.SelectedBenefitAmount = application.LeadInfo.DesiredCoverageAmount;
            }

            QuoteDto.SelectedMonthlyRate = (QuoteDto.Rates.Where(x => x.BenefitCoverage == QuoteDto.SelectedBenefitAmount).FirstOrDefault().MonthlyRate);

            application.LeadInfo.SelectedBenefitAmount = QuoteDto.SelectedBenefitAmount;
            application.LeadInfo.SelectedMonthlyRate = QuoteDto.SelectedMonthlyRate;
            application.LeadInfo.PremiumType = QuoteDto.PremiumType;
        }

        public async Task<string> GetApplicationPDF(Guid guid)
        {
            return await forSureLifeDocumentManager.GetApplicationPDF(guid);
        }


        public async Task<AAFinalExpense> SubmitGetApplication(Guid applicationId)
        {
            var isFirstTime = false;
            var amAmApplication = await _amAmRepository.GetApplication(applicationId);

            amAmApplication.PremiumType = ChangePremiumType(amAmApplication);
            SetEffectiveDate(amAmApplication);
            SetPremiumTypeAndRates(amAmApplication);

            return amAmApplication;
        }

        public async Task<AAFinalExpense> GetApplication(Guid applicationId)
        {
            var isFirstTime = false;
            var amAmApplication = await _amAmRepository.GetApplication(applicationId);


            if (amAmApplication.ApplicationAnswers == null || !amAmApplication.ApplicationAnswers.Any())
            {
                var questions = await _amAmRepository.GetStateQuestions(amAmApplication.ApplicationState);
                amAmApplication.PremiumType = GetPremiumType(amAmApplication.Application, questions, amAmApplication);
                isFirstTime = true;
            }
            amAmApplication.PremiumType = ChangePremiumType(amAmApplication);
            SetEffectiveDate(amAmApplication);
            SetPremiumTypeAndRates(amAmApplication);
            if (isFirstTime)
            {
                amAmApplication.FileNumber = await _amAmRepository.GetApplicationNumber();
                await _amAmRepository.UpdateApplication(amAmApplication);
            }
            return amAmApplication;
        }

        public async Task<AAFinalExpense> UpdateApplication(AAFinalExpense application)
        {
            application.SignatureLocationState = await _amAmRepository.GetStateAbbreviation(application.SignatureLocationState);
            application.Application.LeadInfo.State = await _amAmRepository.GetStateAbbreviation(application.Application.LeadInfo.State);
            application.Application.ApplicationInfo.StateOfBirth = await _amAmRepository.GetStateAbbreviation(application.Application.ApplicationInfo.StateOfBirth);
            application.PremiumType = ChangePremiumType(application);
            var applicationId = application.Application.ApplicationId;
            SetPremiumTypeAndRates(application, application.PremiumType);
            SetEffectiveDate(application);
            await _amAmRepository.UpdateApplication(application);
            await _applicationRepo.UpdateApplication(application.Application);
            return application;
        }

        public async Task SubmitApplication(Guid guid)
        {
            var application = await SubmitGetApplication(guid);
            application.SignatureLocationState = await _amAmRepository.GetStateAbbreviation(application.SignatureLocationState);
            application.Application.LeadInfo.State = await _amAmRepository.GetStateAbbreviation(application.Application.LeadInfo.State);
            application.Application.ApplicationInfo.StateOfBirth = await _amAmRepository.GetStateAbbreviation(application.Application.ApplicationInfo.StateOfBirth);
            if (!application.Submitted)
            {
                application.Application.Signed = true;
                application.Application.SignedDate = DateTime.Now;
                application.Signed = true;
                application.SignedDate = DateTime.Now;
                application.Submitted = true;
                await forSureLifeDocumentManager.SubmitApplicationFiles(application);


                //try
                //{
                //   // UpdateApplication(application);
                //}catch (Exception ex)
                //{

                //}

            }
        }

        private void SetEffectiveDate(AAFinalExpense amAmApplication)
        {
            if (amAmApplication.Application.PaymentInfo.PaymentWithdrawlDate != 0)
            {

                if (DateTime.Now.Day >= amAmApplication.Application.PaymentInfo.PaymentWithdrawlDate)
                {
                    amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, amAmApplication.Application.PaymentInfo.PaymentWithdrawlDate);
                }
                else
                {
                    amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, amAmApplication.Application.PaymentInfo.PaymentWithdrawlDate);
                }
            }
            else
            {
                switch (amAmApplication.Application.PaymentInfo.SocialSecurityWithdrawDate)
                {
                    case SSDDate.FirststDOM:
                        if (DateTime.Now.Day > 1)
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
                        break;
                    case SSDDate.ThirdDOM:
                        if (DateTime.Now.Day > 3)
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 3);
                        }
                        else
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 3);
                        }
                        break;

                    case SSDDate.SecondW:
                        if (DateTime.Now.Day > 11)
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 11);
                        }
                        else
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 11);
                        }

                        break;
                    case SSDDate.ThirdW:
                        if (DateTime.Now.Day > 18)
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 18);
                        }
                        else
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 18);
                        }

                        break;
                    case SSDDate.ForthW:
                        if (DateTime.Now.Day > 24)
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 24);
                        }
                        else
                        {
                            amAmApplication.EffectiveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 24);
                        }

                        break;
                }


            }
        }

        private DateTime CheckMonthAndFindDate(int dayOfTheWeek)
        {
            var date = FindSocialSecurit(DayOfWeek.Wednesday, dayOfTheWeek);
            if (date <= DateTime.Now)
            {
                date = FindSocialSecurit(DayOfWeek.Wednesday, dayOfTheWeek, 1);
            }

            return date;
        }

        private static DateTime FindSocialSecurit(DayOfWeek dayOfWeek, int weekNumber, int monthAdd = 0)
        {
            var day = new DateTime(DateTime.Now.Year, DateTime.Now.Month + monthAdd, 1);
            var currentWeek = 0;
            while (currentWeek < weekNumber)
            {
                if (currentWeek > 0)
                {
                    day = day.AddDays(1);
                }
                while (day.DayOfWeek != dayOfWeek) day = day.AddDays(1);
                currentWeek++;
            }


            return day;
        }


        private SeniorChoicePremiumType ChangePremiumType(AAFinalExpense application)
        {
            var premiumType = SeniorChoicePremiumType.Immediate;
            premiumType = SetCovidPremiumType(application.Application, premiumType);
            foreach (var applicationQuestion in application.ApplicationAnswers)
            {
                var newPremiumType = SetPremiumForQuestion(applicationQuestion);
                if (newPremiumType != SeniorChoicePremiumType.Immediate && newPremiumType != premiumType)
                {
                    if (newPremiumType == SeniorChoicePremiumType.NotEligible)
                    {
                        return SeniorChoicePremiumType.NotEligible;
                    }

                    if (newPremiumType == SeniorChoicePremiumType.Premium && premiumType != SeniorChoicePremiumType.NotEligible)
                    {
                        premiumType = newPremiumType;
                    }

                    if (newPremiumType == SeniorChoicePremiumType.Graded && premiumType != SeniorChoicePremiumType.Premium && premiumType != SeniorChoicePremiumType.NotEligible)
                    {
                        premiumType = newPremiumType;
                    }
                }
            }


            return premiumType;
        }

        private SeniorChoicePremiumType SetPremiumForQuestion(AmAmApplicationAnswers applicationQuestion)
        {
            var questioName = applicationQuestion.Question.QuestionName;
            if ((questioName == AmAmApplicationQuestion.Question1 || questioName == AmAmApplicationQuestion.Question2 || questioName == AmAmApplicationQuestion.Question3) && applicationQuestion.Answer)
            {
                return SeniorChoicePremiumType.NotEligible;
            }
            else if ((questioName == AmAmApplicationQuestion.Question4
                || questioName == AmAmApplicationQuestion.Question5
                || questioName == AmAmApplicationQuestion.Question6
                || questioName == AmAmApplicationQuestion.Question7a
                || questioName == AmAmApplicationQuestion.Question7b
                || questioName == AmAmApplicationQuestion.Question7c
                || questioName == AmAmApplicationQuestion.Question7d
                ) && applicationQuestion.Answer)
            {

                return SeniorChoicePremiumType.Premium;
            }
            else if ((questioName == AmAmApplicationQuestion.Question8a
               || questioName == AmAmApplicationQuestion.Question8b
               || questioName == AmAmApplicationQuestion.Question8c
                ) && applicationQuestion.Answer)
            {
                return SeniorChoicePremiumType.Graded;
            }
            return SeniorChoicePremiumType.Immediate;
        }

        private void SetPremiumTypeAndRates(AAFinalExpense application, SeniorChoicePremiumType? premiumType = null)
        {
            var QuoteDto = _mapper.Map<QuoteDto>(application.Application.LeadInfo);
            if (premiumType == null)
            {
                premiumType = application.PremiumType;
            }
            var rate = GetRates(application.Application, QuoteDto, premiumType, InsuranceCompanyRate.AmAm);
            QuoteDto.PremiumType = premiumType.Value;
            var beneiftMaxLimit = 20000;
            if (rate.PremiumType == SeniorChoicePremiumType.Immediate && rate.Age <= 75)
            {
                beneiftMaxLimit = 35000;
            }


            if (beneiftMaxLimit < application.Application.LeadInfo.DesiredCoverageAmount)
            {
                //rateDto.MonthlyRate = Math.Round(((((benefitAmount / 1000m) * rate.AnnualRate) + 30) * Convert.ToDecimal(.088)), 2, MidpointRounding.ToPositiveInfinity);
                application.SelectedMonthlyRate = Math.Round((((beneiftMaxLimit / 1000m) * rate.AnnualRate + 30) * Convert.ToDecimal(.088)), 2, MidpointRounding.ToPositiveInfinity);
                QuoteDto.SelectedBenefitAmount = beneiftMaxLimit;
                application.SelectedBenefitAmount = beneiftMaxLimit;
            }
            else
            {
                application.SelectedMonthlyRate = Math.Round((((application.Application.LeadInfo.DesiredCoverageAmount / 1000m) * rate.AnnualRate + 30) * Convert.ToDecimal(.088)), 2, MidpointRounding.ToPositiveInfinity);
                QuoteDto.SelectedBenefitAmount = application.Application.LeadInfo.DesiredCoverageAmount;
                application.SelectedBenefitAmount = application.Application.LeadInfo.DesiredCoverageAmount;
            }
        }

        private CarrierPlanRate GetRates(repo.Application application, QuoteDto QuoteDto, SeniorChoicePremiumType? premiumTypeExisting = null, InsuranceCompanyRate insuranceCompany = InsuranceCompanyRate.AmAm)
        {

            QuoteDto.Age = DateTime.Today.Year - application.ApplicationInfo.DOB.Year;
            if (application.ApplicationInfo.DOB > DateTime.Today.AddYears(-QuoteDto.Age))
            {
                QuoteDto.Age--;
            }

            if (QuoteDto.Age < 50)
            {
                QuoteDto.Age = 50;
            }

            SeniorChoicePremiumType premiumType;
            if (premiumTypeExisting == null)
            {
                premiumType = GetPremiumType(application, null, null);

            }
            else
            {
                if (premiumTypeExisting.Value == SeniorChoicePremiumType.NotEligible)
                {
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else
                {
                    premiumType = premiumTypeExisting.Value;
                }
            }

            QuoteDto.PremiumType = premiumType;
            var tobaco = application.HealthQuestions.Where(x => x.LeadHealthQuestion == LeadHealthQuestions.TobaccoUse).FirstOrDefault().HealthAnswer;

            switch (insuranceCompany)
            {
                case InsuranceCompanyRate.AmAm:
                    return _rateRepo.GetRates(application.LeadInfo.Gender, premiumType, tobaco, QuoteDto.Age).Result;

                case InsuranceCompanyRate.Susa:
                    return _rateRepo.GetSusaRates(application.LeadInfo.Gender, premiumType, tobaco, QuoteDto.Age).Result;

                case InsuranceCompanyRate.Foresters:
                    return _rateRepo.GetForesterRates(application.LeadInfo.Gender, premiumType, tobaco, QuoteDto.Age).Result;

                default:
                    return _rateRepo.GetRates(application.LeadInfo.Gender, premiumType, tobaco, QuoteDto.Age).Result;
            }
        }

        private SeniorChoicePremiumType GetPremiumType(repo.Application application, List<AmAmApplicationQuestions>? applicationQuestions, AAFinalExpense? amamapplication)
        {

            //fill out questions 1 -3 if available
            if (applicationQuestions != null)
            {
                amamapplication.ApplicationAnswers = new List<AmAmApplicationAnswers>();

                foreach (var applicationQuestion in applicationQuestions)
                {
                    amamapplication.ApplicationAnswers.Add(new AmAmApplicationAnswers()
                    {
                        AmAmApplicationAnswersId = Guid.NewGuid(),
                        Answer = false,
                        Question = applicationQuestion
                    });

                }
            }

            var premiumType = SeniorChoicePremiumType.Immediate;

            //Add Cancer
            var cancerHealthQuestion = application.HealthQuestions.Where(x => x.LeadHealthQuestion == LeadHealthQuestions.Cancer).FirstOrDefault();

            if (cancerHealthQuestion != null && cancerHealthQuestion.HealthAnswer)
            {
                if (cancerHealthQuestion.Occurence == Occurence.Current)
                {
                    throw new Exception("Does not qualify");
                }
                else if (cancerHealthQuestion.Occurence == Occurence.Multiple)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question5);
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7c);
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else if (cancerHealthQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7c);
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else if (cancerHealthQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8b);
                    premiumType = SetGradedType(premiumType);
                }
            }


            var oxygenHealthQuestion = application.HealthQuestions.Where(x => x.LeadHealthQuestion == LeadHealthQuestions.Oxygen).FirstOrDefault();

            if (oxygenHealthQuestion != null && oxygenHealthQuestion.HealthAnswer)
            {
                if (oxygenHealthQuestion.Occurence == Occurence.Current)
                {
                    throw new Exception("Does not qualify");
                }
                else if (oxygenHealthQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7a);

                    premiumType = SeniorChoicePremiumType.Premium;
                }
            }

            //9 Heart Attack
            var heartAttackHealthQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.HeartAttack).FirstOrDefault();

            if (heartAttackHealthQuestion != null && heartAttackHealthQuestion.HealthAnswer)
            {
                if (heartAttackHealthQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7b);
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else if (heartAttackHealthQuestion.Occurence == Occurence.TwoToThreeYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8a);
                    premiumType = SetGradedType(premiumType);
                }
            }

            //10 Hepatits C
            var hepatitisCQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.HepatitisC).FirstOrDefault();

            if (hepatitisCQuestion != null && hepatitisCQuestion.HealthAnswer)
            {
                if (hepatitisCQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7a);
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else if (hepatitisCQuestion.Occurence == Occurence.TwoToThreeYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8b);
                    premiumType = SetGradedType(premiumType);
                }
            }


            //11 Kidney
            var renalQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.RenalInsufficiencey).FirstOrDefault();

            if (renalQuestion != null && renalQuestion.HealthAnswer)
            {
                SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question5);
                premiumType = SeniorChoicePremiumType.Premium;
            }

            //12 COPD
            var copdQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.COPD).FirstOrDefault();

            if (copdQuestion != null && copdQuestion.HealthAnswer)
            {
                if (copdQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7a);
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else if (copdQuestion.Occurence == Occurence.TwoToThreeYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8b);
                    premiumType = SetGradedType(premiumType);
                }
            }

            //13 Circulation
            var circulationQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Circulation).FirstOrDefault();

            if (circulationQuestion != null && circulationQuestion.HealthAnswer)
            {
                if (circulationQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7b);
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else if (circulationQuestion.Occurence == Occurence.TwoToThreeYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8a);
                    premiumType = SetGradedType(premiumType);
                }
            }

            //14 Outstanding Diagnostic
            var outstandingQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.OutstandingResults).FirstOrDefault();

            if (outstandingQuestion != null && outstandingQuestion.HealthAnswer)
            {
                SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question6);
                premiumType = SeniorChoicePremiumType.Premium;
            }

            //15 Related Diabetes

            var diabetesQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.DiabetesComplications).FirstOrDefault();

            if (diabetesQuestion != null && diabetesQuestion.HealthAnswer)
            {
                SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question4);
                premiumType = SeniorChoicePremiumType.Premium;
            }


            //16 illegal drugs
            var illegalDrugsQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.AbusedSubstances).FirstOrDefault();

            if (illegalDrugsQuestion != null && illegalDrugsQuestion.HealthAnswer)
            {
                SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7d);
                premiumType = SeniorChoicePremiumType.Premium;
            }

            //17 Cardiomyopathy
            var cardiomyopathyQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.cardiomyopathy).FirstOrDefault();

            if (cardiomyopathyQuestion != null && cardiomyopathyQuestion.HealthAnswer)
            {
                if (cardiomyopathyQuestion.Occurence == Occurence.TwoYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question7a);
                    premiumType = SeniorChoicePremiumType.Premium;
                }
                else if (cardiomyopathyQuestion.Occurence == Occurence.TwoToThreeYears)
                {
                    SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8b);
                    premiumType = SetGradedType(premiumType);
                }
            }

            //18 Liver Disease
            var ulcerativeQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.LiverDisease).FirstOrDefault();

            if (ulcerativeQuestion != null && ulcerativeQuestion.HealthAnswer)
            {
                SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8b);
                premiumType = SetGradedType(premiumType);
            }

            //19 Parkinsons Disease
            var parkinsonsQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Parkinsons).FirstOrDefault();

            if (parkinsonsQuestion != null && parkinsonsQuestion.HealthAnswer)
            {
                SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8c);
                premiumType = SetGradedType(premiumType);
            }


            //20 Parkinsons Disease
            var diagnosedParalysisQuestion = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Paralysis).FirstOrDefault();

            if (diagnosedParalysisQuestion != null && diagnosedParalysisQuestion.HealthAnswer)
            {
                SetApplicationQuestion(amamapplication, AmAmApplicationQuestion.Question8c);
                premiumType = SetGradedType(premiumType);
            }

            premiumType = SetCovidPremiumType(application, premiumType);

            return premiumType;
        }

        private SeniorChoicePremiumType SetCovidPremiumType(repo.Application application, SeniorChoicePremiumType premiumType)
        {
            var covid90days2 = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidWithin90DaysMain).FirstOrDefault();
            var covid90days3 = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Covid290Days).FirstOrDefault();

            var covidEffected2 = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidEffectsMain).FirstOrDefault();
            var covidEffected3 = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Covid2Effects).FirstOrDefault();

            var covidQuestion3 = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidQuestionThree).FirstOrDefault();
            var covidQuestion2 = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.Covid2).FirstOrDefault();
            var covidQuestion1 = application.HealthQuestions.Where(x => x.ApplicationQuestion == ApplicationHealthQuestions.CovidQuestionMain).FirstOrDefault();


            if ((covidQuestion1 != null && covidQuestion1.HealthAnswer)
                 || (covidQuestion2 != null && covidQuestion2.HealthAnswer)
                  || (covidQuestion3 != null && covidQuestion3.HealthAnswer))
            {
                if (
                    (covidQuestion1.HealthAnswer && covid90days2 != null && !covid90days2.HealthAnswer)
                    || (covidQuestion2.HealthAnswer && covid90days3 != null && !covid90days3.HealthAnswer)
                      || (covidEffected2 != null && covidEffected2.HealthAnswer)
                     || (covidEffected3 != null && covidEffected3.HealthAnswer)
                      || (covidQuestion3 != null && covidQuestion3.HealthAnswer))
                {
                    premiumType = SeniorChoicePremiumType.Premium;
                }
            }
            return premiumType;
        }

        private static void SetApplicationQuestion(AAFinalExpense amamapplication, AmAmApplicationQuestion question)
        {
            if (amamapplication != null)
            {
                var applicationQuestionCancer = amamapplication.ApplicationAnswers.Where(x => x.Question.QuestionName == question).FirstOrDefault();
                if (applicationQuestionCancer != null)
                {
                    applicationQuestionCancer.Answer = true;
                }
            }
        }

        private static SeniorChoicePremiumType SetGradedType(SeniorChoicePremiumType premiumType)
        {
            if (premiumType != SeniorChoicePremiumType.Premium)
            {
                premiumType = SeniorChoicePremiumType.Graded;
            }

            return premiumType;
        }

    }
}
