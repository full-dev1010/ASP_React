﻿// <auto-generated />
using System;
using ForSureLife.repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ForSureLife.repo.Migrations
{
    [DbContext(typeof(ForSureLifeDBContext))]
    [Migration("20210326162239_ContingentBenficiaries")]
    partial class ContingentBenficiaries
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ForSureLife.repo.Application", b =>
            {
                b.Property<Guid>("ApplicationId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ApplicationInfoId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Language")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid?>("LeadInfoLeadId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("PaymentInfoPaymentId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Signed")
                    .HasColumnType("bit");

                b.Property<DateTime>("SignedDate")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("UpdateDate")
                    .HasColumnType("datetime2");

                b.HasKey("ApplicationId");

                b.HasIndex("ApplicationInfoId");

                b.HasIndex("LeadInfoLeadId");

                b.HasIndex("PaymentInfoPaymentId");

                b.ToTable("Application");
            });

            modelBuilder.Entity("ForSureLife.repo.ApplicationInfo", b =>
            {
                b.Property<Guid>("ApplicationInfoId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("AcceptAnyPlan")
                    .HasColumnType("bit");

                b.Property<string>("BirthState")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("DOB")
                    .HasColumnType("datetime2");

                b.Property<string>("DoctorCity")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("DoctorName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("DoctorPhone")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("DoctorState")
                    .HasColumnType("int");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("HeightFt")
                    .HasColumnType("int");

                b.Property<int>("HeightIn")
                    .HasColumnType("int");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal>("LifeCoverageAmount")
                    .HasColumnType("decimal(18,2)");

                b.Property<bool>("LifePolicy")
                    .HasColumnType("bit");

                b.Property<string>("LifePolicyInsuranceCompany")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LifePolicyNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("MiddleName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("SSN")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("SeparateOwner")
                    .HasColumnType("bit");

                b.Property<string>("StateOfBirth")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal>("Weight")
                    .HasColumnType("decimal(18,2)");

                b.HasKey("ApplicationInfoId");

                b.ToTable("ApplicationInfo");
            });

            modelBuilder.Entity("ForSureLife.repo.Doctor", b =>
            {
                b.Property<Guid>("DoctorId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("DoctorCity")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("DoctorName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("DoctorPhone")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("DoctorState")
                    .HasColumnType("int");

                b.Property<Guid?>("FamilyMemberId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("DoctorId");

                b.HasIndex("FamilyMemberId");

                b.ToTable("Doctors");
            });

            modelBuilder.Entity("ForSureLife.repo.Drug", b =>
            {
                b.Property<Guid>("DrugId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("DrugName")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid?>("FamilyMemeberFamilyMemberId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("RXFrequency")
                    .HasColumnType("int");

                b.Property<string>("Reason")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("DrugId");

                b.HasIndex("FamilyMemeberFamilyMemberId");

                b.ToTable("Drugs");
            });

            modelBuilder.Entity("ForSureLife.repo.FamilyMember", b =>
            {
                b.Property<Guid>("FamilyMemberId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Address1")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Address2")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("City")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("DateOfBirth")
                    .HasColumnType("datetime2");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Gender")
                    .HasColumnType("int");

                b.Property<int>("HeightFt")
                    .HasColumnType("int");

                b.Property<int>("HeightIn")
                    .HasColumnType("int");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("MiddleName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("SSN")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("State")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("StateOfBirth")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal>("Weight")
                    .HasColumnType("decimal(18,2)");

                b.HasKey("FamilyMemberId");

                b.ToTable("FamilyMember");
            });

            modelBuilder.Entity("ForSureLife.repo.FamilyOrBeneficiary", b =>
            {
                b.Property<Guid>("FamilyOrBeneficiaryId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ApplicationId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ApplicationId1")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Percentage")
                    .HasColumnType("int");

                b.Property<Guid?>("PersonalInfoFamilyMemberId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("PrimaryRelationship")
                    .HasColumnType("int");

                b.Property<string>("Relationships")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("FamilyOrBeneficiaryId");

                b.HasIndex("ApplicationId");

                b.HasIndex("ApplicationId1");

                b.HasIndex("PersonalInfoFamilyMemberId");

                b.ToTable("FamilyOrBeneficiary");
            });

            modelBuilder.Entity("ForSureLife.repo.Lead", b =>
            {
                b.Property<Guid>("LeadId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Address1")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Address2")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("City")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("County")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("CurrentCoverage")
                    .HasColumnType("bit");

                b.Property<DateTime>("DOB")
                    .HasColumnType("datetime2");

                b.Property<decimal>("DesiredCoverageAmount")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Gender")
                    .HasColumnType("int");

                b.Property<string>("Hobby")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LeadSource")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("MiddleName")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal>("OriginalDesiredCoverageAmount")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("Phone")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("State")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("ZipCode")
                    .HasColumnType("int");

                b.HasKey("LeadId");

                b.ToTable("Lead");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AAFinalExpense", b =>
            {
                b.Property<Guid>("AAFinalExpenseId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ApplicationId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("ApplicationState")
                    .HasColumnType("int");

                b.Property<string>("ClientIPAddress")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("EffectiveDate")
                    .HasColumnType("datetime2");

                b.Property<int>("FileNumber")
                    .HasColumnType("int");

                b.Property<int>("InsuranceCompanyName")
                    .HasColumnType("int");

                b.Property<int>("MailPolicyTo")
                    .HasColumnType("int");

                b.Property<int>("PremiumType")
                    .HasColumnType("int");

                b.Property<decimal>("SelectedBenefitAmount")
                    .HasColumnType("decimal(18,2)");

                b.Property<decimal>("SelectedMonthlyRate")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("SignatureLocationCity")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("SignatureLocationState")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("Signed")
                    .HasColumnType("bit");

                b.Property<DateTime>("SignedDate")
                    .HasColumnType("datetime2");

                b.Property<bool>("Submitted")
                    .HasColumnType("bit");

                b.Property<int>("testChange")
                    .HasColumnType("int");

                b.HasKey("AAFinalExpenseId");

                b.HasIndex("ApplicationId");

                b.ToTable("AmAmFinalExpense");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AmAmApplicationAnswers", b =>
            {
                b.Property<Guid>("AmAmApplicationAnswersId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("AAFinalExpenseId")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Answer")
                    .HasColumnType("bit");

                b.Property<Guid?>("QuestionAmAmApplicationQuestionsId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("AmAmApplicationAnswersId");

                b.HasIndex("AAFinalExpenseId");

                b.HasIndex("QuestionAmAmApplicationQuestionsId");

                b.ToTable("AmAmApplicationAnswers");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AmAmApplicationQuestions", b =>
            {
                b.Property<Guid>("AmAmApplicationQuestionsId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("ApplicationSection")
                    .HasColumnType("int");

                b.Property<int>("QuestionName")
                    .HasColumnType("int");

                b.HasKey("AmAmApplicationQuestionsId");

                b.ToTable("AmAmApplicationQuestions");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AmState", b =>
            {
                b.Property<Guid>("AmStateId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("InsuranceCompany")
                    .HasColumnType("int");

                b.Property<int>("StateIdEnum")
                    .HasColumnType("int");

                b.HasKey("AmStateId");

                b.ToTable("AmState");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AmStateLookup", b =>
            {
                b.Property<Guid>("AmStateLookupId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("AmAmApplicationQuestionsId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("AmStateId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("AmStateLookupId");

                b.HasIndex("AmAmApplicationQuestionsId");

                b.HasIndex("AmStateId");

                b.ToTable("AmStateLookup");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.BankInfo", b =>
            {
                b.Property<Guid>("BankInfoId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Address1")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("BankName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("City")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("RoutingNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("State")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("BankInfoId");

                b.ToTable("BankInfo");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.HealthQuestion", b =>
            {
                b.Property<Guid>("HealthQuestionId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ApplicationId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("ApplicationQuestion")
                    .HasColumnType("int");

                b.Property<bool>("HealthAnswer")
                    .HasColumnType("bit");

                b.Property<string>("HealthQuestionName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("LeadHealthQuestion")
                    .HasColumnType("int");

                b.Property<int>("Occurence")
                    .HasColumnType("int");

                b.HasKey("HealthQuestionId");

                b.HasIndex("ApplicationId");

                b.ToTable("HealthQuestion");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.Plan", b =>
            {
                b.Property<Guid>("PlanId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("BenefitAmountPlanBenefitId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Carrier")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<Guid?>("PlanDetailsId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("PlanName")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("Selected")
                    .HasColumnType("bit");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("PlanId");

                b.HasIndex("BenefitAmountPlanBenefitId");

                b.HasIndex("PlanDetailsId");

                b.ToTable("Plan");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.PlanDetails", b =>
            {
                b.Property<Guid>("PlanDetailsId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("PlanName")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("PlanDetailsId");

                b.ToTable("PlanDetails");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.PlanQuote", b =>
            {
                b.Property<Guid>("PlanQuoteId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("BenefitLevelPlanBenefitId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Carrier")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("EffectiveDate")
                    .HasColumnType("datetime2");

                b.Property<string>("PlanId")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PlanName")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid?>("QuoteId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("PlanQuoteId");

                b.HasIndex("BenefitLevelPlanBenefitId");

                b.HasIndex("QuoteId");

                b.ToTable("PlanQuote");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.BirthPlaces", b =>
            {
                b.Property<Guid>("BirthPlacesId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Abbreviation")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("BirthPlacesId");

                b.ToTable("BirthPlaces");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.CarrierDrug", b =>
            {
                b.Property<Guid>("CarrierDrugId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("DrugName")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("RXFrequency")
                    .HasColumnType("int");

                b.Property<string>("Reason")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CarrierDrugId");

                b.ToTable("CarrierDrug");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.CarrierPlan", b =>
            {
                b.Property<Guid>("CarrierPlanId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("BenefitAmountCarrierPlanBenefitId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Carrier")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Language")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid?>("PlanDetailsCarrierPlanDetailsId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("PlanId")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PlanName")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CarrierPlanId");

                b.HasIndex("BenefitAmountCarrierPlanBenefitId");

                b.HasIndex("PlanDetailsCarrierPlanDetailsId");

                b.ToTable("CarrierPlan");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.CarrierPlanBenefit", b =>
            {
                b.Property<Guid>("CarrierPlanBenefitId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("BenefitAmount")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("BenefitName")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CarrierPlanBenefitId");

                b.ToTable("CarrierPlanBenefit");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.CarrierPlanDetails", b =>
            {
                b.Property<Guid>("CarrierPlanDetailsId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("rateCarrierPlanRateId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("CarrierPlanDetailsId");

                b.HasIndex("rateCarrierPlanRateId");

                b.ToTable("CarrierPlanDetails");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.CarrierPlanRate", b =>
            {
                b.Property<Guid>("CarrierPlanRateId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Age")
                    .HasColumnType("int");

                b.Property<decimal>("AnnualRate")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("Gender")
                    .HasColumnType("int");

                b.Property<int>("PremiumType")
                    .HasColumnType("int");

                b.Property<bool>("Tobacoo")
                    .HasColumnType("bit");

                b.HasKey("CarrierPlanRateId");

                b.ToTable("CarrierPlanRate");
            });

            modelBuilder.Entity("ForSureLife.repo.PaymentInfo", b =>
            {
                b.Property<Guid>("PaymentId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("AccountNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("BankAddress")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("BankType")
                    .HasColumnType("int");

                b.Property<string>("BankingInsitution")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("PaymentWithdrawlDate")
                    .HasColumnType("int");

                b.Property<string>("RoutingNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("SocialSecurityWithdrawDate")
                    .HasColumnType("int");

                b.HasKey("PaymentId");

                b.ToTable("PaymentInfo");
            });

            modelBuilder.Entity("ForSureLife.repo.Pharmacy", b =>
            {
                b.Property<Guid>("PharmacyId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("FamilyMemeberFamilyMemberId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("PharmacyId");

                b.HasIndex("FamilyMemeberFamilyMemberId");

                b.ToTable("Pharmacy");
            });

            modelBuilder.Entity("ForSureLife.repo.PlanBenefit", b =>
            {
                b.Property<Guid>("PlanBenefitId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("BenefitAmount")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("BenefitName")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("PlanBenefitId");

                b.ToTable("PlanBenefit");
            });

            modelBuilder.Entity("ForSureLife.repo.Quote", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ApplicationId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("ZipCode")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("ApplicationId");

                b.ToTable("Quote");
            });

            modelBuilder.Entity("ForSureLife.repo.Application", b =>
            {
                b.HasOne("ForSureLife.repo.ApplicationInfo", "ApplicationInfo")
                    .WithMany()
                    .HasForeignKey("ApplicationInfoId");

                b.HasOne("ForSureLife.repo.Lead", "LeadInfo")
                    .WithMany()
                    .HasForeignKey("LeadInfoLeadId");

                b.HasOne("ForSureLife.repo.PaymentInfo", "PaymentInfo")
                    .WithMany()
                    .HasForeignKey("PaymentInfoPaymentId");

                // b.Navigation("ApplicationInfo");

                // b.Navigation("LeadInfo");

                // b.Navigation("PaymentInfo");
            });

            modelBuilder.Entity("ForSureLife.repo.Doctor", b =>
            {
                b.HasOne("ForSureLife.repo.FamilyMember", "FamilyMember")
                    .WithMany()
                    .HasForeignKey("FamilyMemberId");

                // b.Navigation("FamilyMember");
            });

            modelBuilder.Entity("ForSureLife.repo.Drug", b =>
            {
                b.HasOne("ForSureLife.repo.FamilyMember", "FamilyMemeber")
                    .WithMany()
                    .HasForeignKey("FamilyMemeberFamilyMemberId");

                // b.Navigation("FamilyMemeber");
            });

            modelBuilder.Entity("ForSureLife.repo.FamilyOrBeneficiary", b =>
            {
                b.HasOne("ForSureLife.repo.Application", null)
                    .WithMany("Beneficiaries")
                    .HasForeignKey("ApplicationId");

                b.HasOne("ForSureLife.repo.Application", null)
                    .WithMany("ContingentBeneficiaries")
                    .HasForeignKey("ApplicationId1");

                b.HasOne("ForSureLife.repo.FamilyMember", "PersonalInfo")
                    .WithMany()
                    .HasForeignKey("PersonalInfoFamilyMemberId");

                // b.Navigation("PersonalInfo");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AAFinalExpense", b =>
            {
                b.HasOne("ForSureLife.repo.Application", "Application")
                    .WithMany()
                    .HasForeignKey("ApplicationId");

                // b.Navigation("Application");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AmAmApplicationAnswers", b =>
            {
                b.HasOne("ForSureLife.repo.Models.Enroll.AAFinalExpense", null)
                    .WithMany("ApplicationAnswers")
                    .HasForeignKey("AAFinalExpenseId");

                b.HasOne("ForSureLife.repo.Models.Enroll.AmAmApplicationQuestions", "Question")
                    .WithMany()
                    .HasForeignKey("QuestionAmAmApplicationQuestionsId");

                // b.Navigation("Question");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AmStateLookup", b =>
            {
                b.HasOne("ForSureLife.repo.Models.Enroll.AmAmApplicationQuestions", null)
                    .WithMany("States")
                    .HasForeignKey("AmAmApplicationQuestionsId");

                b.HasOne("ForSureLife.repo.Models.Enroll.AmState", "AmState")
                    .WithMany()
                    .HasForeignKey("AmStateId");

                // b.Navigation("AmState");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.HealthQuestion", b =>
            {
                b.HasOne("ForSureLife.repo.Application", null)
                    .WithMany("HealthQuestions")
                    .HasForeignKey("ApplicationId");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.Plan", b =>
            {
                b.HasOne("ForSureLife.repo.PlanBenefit", "BenefitAmount")
                    .WithMany()
                    .HasForeignKey("BenefitAmountPlanBenefitId");

                b.HasOne("ForSureLife.repo.Models.Quote.PlanDetails", "PlanDetails")
                    .WithMany()
                    .HasForeignKey("PlanDetailsId");

                // b.Navigation("BenefitAmount");

                // b.Navigation("PlanDetails");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Quote.PlanQuote", b =>
            {
                b.HasOne("ForSureLife.repo.PlanBenefit", "BenefitLevel")
                    .WithMany()
                    .HasForeignKey("BenefitLevelPlanBenefitId");

                b.HasOne("ForSureLife.repo.Quote", null)
                    .WithMany("Plans")
                    .HasForeignKey("QuoteId");

                // b.Navigation("BenefitLevel");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.CarrierPlan", b =>
            {
                b.HasOne("ForSureLife.repo.Models.Rate.CarrierPlanBenefit", "BenefitAmount")
                    .WithMany()
                    .HasForeignKey("BenefitAmountCarrierPlanBenefitId");

                b.HasOne("ForSureLife.repo.Models.Rate.CarrierPlanDetails", "PlanDetails")
                    .WithMany()
                    .HasForeignKey("PlanDetailsCarrierPlanDetailsId");

                // b.Navigation("BenefitAmount");

                // b.Navigation("PlanDetails");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Rate.CarrierPlanDetails", b =>
            {
                b.HasOne("ForSureLife.repo.Models.Rate.CarrierPlanRate", "rate")
                    .WithMany()
                    .HasForeignKey("rateCarrierPlanRateId");

                // b.Navigation("rate");
            });

            modelBuilder.Entity("ForSureLife.repo.Pharmacy", b =>
            {
                b.HasOne("ForSureLife.repo.FamilyMember", "FamilyMemeber")
                    .WithMany()
                    .HasForeignKey("FamilyMemeberFamilyMemberId");

                // b.Navigation("FamilyMemeber");
            });

            modelBuilder.Entity("ForSureLife.repo.Quote", b =>
            {
                b.HasOne("ForSureLife.repo.Application", null)
                    .WithMany("SelectedQuotes")
                    .HasForeignKey("ApplicationId");
            });

            modelBuilder.Entity("ForSureLife.repo.Application", b =>
            {
                // b.Navigation("Beneficiaries");

                // b.Navigation("ContingentBeneficiaries");

                // b.Navigation("HealthQuestions");

                // b.Navigation("SelectedQuotes");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AAFinalExpense", b =>
            {
                // b.Navigation("ApplicationAnswers");
            });

            modelBuilder.Entity("ForSureLife.repo.Models.Enroll.AmAmApplicationQuestions", b =>
            {
                // b.Navigation("States");
            });

            modelBuilder.Entity("ForSureLife.repo.Quote", b =>
            {
                // b.Navigation("Plans");
            });
#pragma warning restore 612, 618
        }
    }
}
