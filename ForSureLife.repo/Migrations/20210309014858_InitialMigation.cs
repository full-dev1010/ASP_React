using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class InitialMigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmAmApplicationQuestions",
                columns: table => new
                {
                    AmAmApplicationQuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionName = table.Column<int>(type: "int", nullable: false),
                    ApplicationSection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmAmApplicationQuestions", x => x.AmAmApplicationQuestionsId);
                });

            migrationBuilder.CreateTable(
                name: "AmState",
                columns: table => new
                {
                    AmStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    InsuranceCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmState", x => x.AmStateId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationInfo",
                columns: table => new
                {
                    ApplicationInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    SeparateOwner = table.Column<bool>(type: "bit", nullable: false),
                    LifePolicy = table.Column<bool>(type: "bit", nullable: false),
                    LifePolicyInsuranceCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifePolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifeCoverageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeightFt = table.Column<int>(type: "int", nullable: false),
                    HeightIn = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationInfo", x => x.ApplicationInfoId);
                });

            migrationBuilder.CreateTable(
                name: "CarrierDrug",
                columns: table => new
                {
                    CarrierDrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RXFrequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierDrug", x => x.CarrierDrugId);
                });

            migrationBuilder.CreateTable(
                name: "CarrierPlanBenefit",
                columns: table => new
                {
                    CarrierPlanBenefitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenefitAmount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierPlanBenefit", x => x.CarrierPlanBenefitId);
                });

            migrationBuilder.CreateTable(
                name: "CarrierPlanRate",
                columns: table => new
                {
                    CarrierPlanRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Tobacoo = table.Column<bool>(type: "bit", nullable: false),
                    PremiumType = table.Column<int>(type: "int", nullable: false),
                    AnnualRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierPlanRate", x => x.CarrierPlanRateId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                columns: table => new
                {
                    FamilyMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    HeightFt = table.Column<int>(type: "int", nullable: false),
                    HeightIn = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember", x => x.FamilyMemberId);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentCoverage = table.Column<bool>(type: "bit", nullable: false),
                    DesiredCoverageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hobby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.LeadId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfo",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankingInsitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    RoutingNumber = table.Column<int>(type: "int", nullable: false),
                    BankType = table.Column<int>(type: "int", nullable: false),
                    PaymentWithdrawlDate = table.Column<int>(type: "int", nullable: false),
                    SocialSecurityWithdrawDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfo", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "PlanBenefit",
                columns: table => new
                {
                    PlanBenefitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenefitAmount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanBenefit", x => x.PlanBenefitId);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetails",
                columns: table => new
                {
                    PlanDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetails", x => x.PlanDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "AmStateLookup",
                columns: table => new
                {
                    AmStateLookupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AmAmApplicationQuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmStateLookup", x => x.AmStateLookupId);
                    table.ForeignKey(
                        name: "FK_AmStateLookup_AmAmApplicationQuestions_AmAmApplicationQuestionsId",
                        column: x => x.AmAmApplicationQuestionsId,
                        principalTable: "AmAmApplicationQuestions",
                        principalColumn: "AmAmApplicationQuestionsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AmStateLookup_AmState_AmStateId",
                        column: x => x.AmStateId,
                        principalTable: "AmState",
                        principalColumn: "AmStateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrierPlanDetails",
                columns: table => new
                {
                    CarrierPlanDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rateCarrierPlanRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierPlanDetails", x => x.CarrierPlanDetailsId);
                    table.ForeignKey(
                        name: "FK_CarrierPlanDetails_CarrierPlanRate_rateCarrierPlanRateId",
                        column: x => x.rateCarrierPlanRateId,
                        principalTable: "CarrierPlanRate",
                        principalColumn: "CarrierPlanRateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_FamilyMember_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyMemeberFamilyMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RXFrequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                    table.ForeignKey(
                        name: "FK_Drugs_FamilyMember_FamilyMemeberFamilyMemberId",
                        column: x => x.FamilyMemeberFamilyMemberId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    PharmacyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyMemeberFamilyMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.PharmacyId);
                    table.ForeignKey(
                        name: "FK_Pharmacy_FamilyMember_FamilyMemeberFamilyMemberId",
                        column: x => x.FamilyMemeberFamilyMemberId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadInfoLeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentInfoPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signed = table.Column<bool>(type: "bit", nullable: false),
                    SignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application_ApplicationInfo_ApplicationInfoId",
                        column: x => x.ApplicationInfoId,
                        principalTable: "ApplicationInfo",
                        principalColumn: "ApplicationInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_Lead_LeadInfoLeadId",
                        column: x => x.LeadInfoLeadId,
                        principalTable: "Lead",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_PaymentInfo_PaymentInfoPaymentId",
                        column: x => x.PaymentInfoPaymentId,
                        principalTable: "PaymentInfo",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BenefitAmountPlanBenefitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Selected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plan_PlanBenefit_BenefitAmountPlanBenefitId",
                        column: x => x.BenefitAmountPlanBenefitId,
                        principalTable: "PlanBenefit",
                        principalColumn: "PlanBenefitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_PlanDetails_PlanDetailsId",
                        column: x => x.PlanDetailsId,
                        principalTable: "PlanDetails",
                        principalColumn: "PlanDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrierPlan",
                columns: table => new
                {
                    CarrierPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDetailsCarrierPlanDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BenefitAmountCarrierPlanBenefitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierPlan", x => x.CarrierPlanId);
                    table.ForeignKey(
                        name: "FK_CarrierPlan_CarrierPlanBenefit_BenefitAmountCarrierPlanBenefitId",
                        column: x => x.BenefitAmountCarrierPlanBenefitId,
                        principalTable: "CarrierPlanBenefit",
                        principalColumn: "CarrierPlanBenefitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarrierPlan_CarrierPlanDetails_PlanDetailsCarrierPlanDetailsId",
                        column: x => x.PlanDetailsCarrierPlanDetailsId,
                        principalTable: "CarrierPlanDetails",
                        principalColumn: "CarrierPlanDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AmAmFinalExpense",
                columns: table => new
                {
                    AAFinalExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MailPolicyTo = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmAmFinalExpense", x => x.AAFinalExpenseId);
                    table.ForeignKey(
                        name: "FK_AmAmFinalExpense_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyOrBeneficiary",
                columns: table => new
                {
                    FamilyOrBeneficiaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalInfoFamilyMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrimaryRelationship = table.Column<int>(type: "int", nullable: false),
                    Relationships = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyOrBeneficiary", x => x.FamilyOrBeneficiaryId);
                    table.ForeignKey(
                        name: "FK_FamilyOrBeneficiary_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyOrBeneficiary_FamilyMember_PersonalInfoFamilyMemberId",
                        column: x => x.PersonalInfoFamilyMemberId,
                        principalTable: "FamilyMember",
                        principalColumn: "FamilyMemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthQuestion",
                columns: table => new
                {
                    HealthQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadHealthQuestion = table.Column<int>(type: "int", nullable: false),
                    ApplicationQuestion = table.Column<int>(type: "int", nullable: false),
                    HealthQuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthAnswer = table.Column<bool>(type: "bit", nullable: false),
                    Occurence = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthQuestion", x => x.HealthQuestionId);
                    table.ForeignKey(
                        name: "FK_HealthQuestion_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AmAmApplicationAnswers",
                columns: table => new
                {
                    AmAmApplicationAnswersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionAmAmApplicationQuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Answer = table.Column<bool>(type: "bit", nullable: false),
                    AAFinalExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmAmApplicationAnswers", x => x.AmAmApplicationAnswersId);
                    table.ForeignKey(
                        name: "FK_AmAmApplicationAnswers_AmAmApplicationQuestions_QuestionAmAmApplicationQuestionsId",
                        column: x => x.QuestionAmAmApplicationQuestionsId,
                        principalTable: "AmAmApplicationQuestions",
                        principalColumn: "AmAmApplicationQuestionsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AmAmApplicationAnswers_AmAmFinalExpense_AAFinalExpenseId",
                        column: x => x.AAFinalExpenseId,
                        principalTable: "AmAmFinalExpense",
                        principalColumn: "AAFinalExpenseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanQuote",
                columns: table => new
                {
                    PlanQuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenefitLevelPlanBenefitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanQuote", x => x.PlanQuoteId);
                    table.ForeignKey(
                        name: "FK_PlanQuote_PlanBenefit_BenefitLevelPlanBenefitId",
                        column: x => x.BenefitLevelPlanBenefitId,
                        principalTable: "PlanBenefit",
                        principalColumn: "PlanBenefitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanQuote_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AmAmApplicationQuestions",
                columns: new[] { "AmAmApplicationQuestionsId", "ApplicationSection", "QuestionName" },
                values: new object[,]
                {
                    { new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), 0, 0 },
                    { new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), 1, 12 },
                    { new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), 1, 11 },
                    { new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), 2, 9 },
                    { new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), 2, 8 },
                    { new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), 2, 7 },
                    { new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), 1, 10 },
                    { new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), 2, 5 },
                    { new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), 0, 1 },
                    { new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), 2, 4 },
                    { new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), 2, 3 },
                    { new Guid("e494a4be-881a-376a-711e-757e27ce5369"), 0, 2 },
                    { new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "AmState",
                columns: new[] { "AmStateId", "InsuranceCompany", "State" },
                values: new object[,]
                {
                    { new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca"), 0, 38 },
                    { new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85"), 1, 31 },
                    { new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc"), 0, 29 },
                    { new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013"), 0, 32 },
                    { new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5"), 0, 33 },
                    { new Guid("078cc111-a264-7212-16cc-fba56d360f18"), 0, 35 },
                    { new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2"), 0, 36 },
                    { new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a"), 0, 37 },
                    { new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792"), 1, 39 },
                    { new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a"), 1, 46 },
                    { new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a"), 0, 42 },
                    { new Guid("0e2b7914-0408-5d00-761b-100167f6552c"), 0, 43 },
                    { new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a"), 0, 44 },
                    { new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990"), 0, 45 },
                    { new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84"), 0, 27 },
                    { new Guid("0be543f8-0209-9f39-753b-27eef29649f9"), 0, 47 },
                    { new Guid("25412f3a-5715-04d5-42a4-917306029a7a"), 0, 48 },
                    { new Guid("a207e798-6387-3fda-8e7f-d2559e4da433"), 0, 50 },
                    { new Guid("28f77124-2487-111b-24bb-108da88f3f9a"), 0, 40 },
                    { new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4"), 0, 25 },
                    { new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd"), 0, 49 },
                    { new Guid("906cb2cc-0d16-88fe-6b70-209075703618"), 0, 23 },
                    { new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0"), 0, 24 },
                    { new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333"), 0, 0 },
                    { new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282"), 0, 1 },
                    { new Guid("1df968a1-0835-9373-a47a-4390d91e1091"), 0, 2 },
                    { new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51"), 0, 3 },
                    { new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77"), 0, 6 },
                    { new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e"), 0, 10 }
                });

            migrationBuilder.InsertData(
                table: "AmState",
                columns: new[] { "AmStateId", "InsuranceCompany", "State" },
                values: new object[,]
                {
                    { new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8"), 0, 11 },
                    { new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a"), 1, 12 },
                    { new Guid("595994f6-6794-741a-4937-9cbdd3d18c20"), 0, 5 },
                    { new Guid("beaf6384-4747-8152-0887-fe19fe7157b1"), 0, 14 },
                    { new Guid("21de2f96-1774-9bef-934c-50a24aa4603d"), 0, 15 },
                    { new Guid("0536004d-a384-a7a7-04af-f73781164fa3"), 0, 16 },
                    { new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2"), 0, 17 },
                    { new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3"), 0, 18 },
                    { new Guid("c5c6c08a-2cca-321c-0918-08e84097547b"), 1, 19 },
                    { new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4"), 0, 20 },
                    { new Guid("9b376a45-1bc5-5961-6d11-4163679d674a"), 0, 21 },
                    { new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362"), 0, 13 },
                    { new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e"), 1, 22 }
                });

            migrationBuilder.InsertData(
                    table: "AmStateLookup",
                    columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                    values: new object[,]
                    {
                        { new Guid("5befcd2e-4ee3-5e82-47c4-dc577e145e85"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("058caf2a-605a-4d7c-329d-c1c6808f969a"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("87fb9543-3b31-5524-858e-26598a465604"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("29fa608f-6f05-9f37-0bbd-805c98869924"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("4cc65ead-2f78-7b13-8c07-d27e081c9d91"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("4b1da2c8-59af-1913-3849-7d8ace0d775a"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("55532698-7044-18f6-10af-fbd990214a30"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("f210b2b5-6beb-74be-09a8-0fc925741359"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("d0a96bd8-1cca-7323-07fe-cd12f378772d"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("80c2ac3a-a3f2-09fd-7e42-40b62e0d2f04"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("0c711cf5-6443-4c23-6e12-b71c59ec9582"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("0883e5da-19f7-a6a5-62f9-bf519b754a8e"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("f3f69b41-83c0-0c59-5515-317dfe825cda"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("73324760-995e-45ef-2d71-b85a1f602179"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("dd041073-3807-4bf9-4144-85c7834f29c4"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("727ecb43-a322-369d-2985-617627581bef"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("ed6a9c7d-7ebd-61b7-3c2c-e89f73ac678d"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("35017c69-2136-5c28-90dc-e2f107284122"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("4ebad4fe-5b46-3a29-17ad-0c89d43596ee"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("99bb59e9-3971-6dde-3d56-d9dea19f25ea"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("5926db46-748b-70c9-9cc4-1affdcdb3fc0"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("07849244-4958-5e3c-81cd-6e7b49fe4362"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("07a77ea9-5bd9-7937-00c5-2da034e505c7"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("e11bbbbd-3f7d-a48f-7c9d-a070153d8a46"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("d6896b5d-6bf6-140e-71e3-cc78f9149d49"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("845d6c6b-7330-a73e-1c0f-0da18ba7114d"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("9439f417-143a-5e5d-0c66-e823e72864e1"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("ecaa1fbd-7982-48f2-1069-a1bfb33d76f4"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("e2528246-8c67-6547-3aa6-0d91ad7f565a"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("0218e77c-0700-7d8e-5aa6-0128982974cc"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("754b9624-42a3-8fd1-2efd-cfa372de8b13"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("7354b113-1e4b-9ea2-a18b-87f1a3001cb8"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("3af58279-806d-609e-301a-d8fd368e8b96"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("8f600d6a-87b1-64fb-a727-3661f045a052"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("9c9a149a-0af9-9585-3482-cc4475874bb8"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("12a4cb1b-4c8a-8c5e-9e52-3048415d369d"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("bbd440dc-7efe-70b6-3fae-a9e1024c0224"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("34a8ddd6-33a1-6069-4b7d-897e4cd56275"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("7865a8e3-36c0-8e81-6d9f-da9feaab6e31"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("f34d2ff3-3baf-a3aa-0b79-857c4a767325"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("8bcafc3e-9034-9963-51bb-55094d0c012d"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("5663893f-6b53-133b-6a0a-f5c48926a14d"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
                    });

            migrationBuilder.InsertData(
                table: "AmStateLookup",
                columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                values: new object[,]
                {
                       { new Guid("a9530db6-1db1-4bcf-1016-bf38bd650bd2"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("f9632418-235b-39ad-a63f-3142b8e11674"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("01083537-1d54-9952-5965-8a73ca1e991b"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("a14b253a-16f9-39ff-688c-85304d845a9d"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("69cafe73-8c6b-3591-596c-821318416b6d"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("febdb058-9849-966f-23b9-54432c06a0ca"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("5dd107d0-1e19-0b56-6825-0332e8129318"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("f8065d47-0165-292e-4263-5ba8f8c67b8a"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("52839d03-2e7f-346b-a59c-abe26e790feb"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("dc1dbec8-8f2c-091b-2661-c79800e43457"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("66f1595a-0463-3036-7d2f-0f6fe28d65c6"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("3c21a60b-45c3-141f-8165-efb72c9b8a2f"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("1bdc73ce-9283-129c-7cc0-e09f38a139ff"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("8122e397-5825-75cb-10c2-940148ab8e91"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("2a67ba7c-0c3a-6141-0056-db62ef1531ad"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("323a1385-87a1-9a52-3121-560abbee8ffb"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("27e08914-a548-2883-8941-8259309179a8"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("62136571-2feb-0a9e-5196-281e023005ff"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("7acfe7d8-5b03-314e-401d-5e782af0a3ec"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("0795841f-7714-8bf3-70a1-f0bb78c34e43"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("94cf096f-0fe9-3a5d-8973-58c606a76868"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("84e95349-37bb-6321-1157-2e7b41208525"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("1a0a7be6-4e44-6ab7-168a-961fcc4c1698"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("069399cf-44d5-0a5e-1243-25f7c8962d3e"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("4a0244bf-4e8c-54cd-5639-b974bc7839f3"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("c6ca43a7-90e0-0090-8e70-ba17815453bb"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("9307c877-10ba-6e63-a0d6-e3f17f8588f3"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("c7800758-000a-7657-5ba4-edd424a51518"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("70468cab-393b-1b30-16c0-e48b81173bf1"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("77324032-17f5-527c-4f86-1a5006923680"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("bad85505-69bf-531e-11f6-e7dcd8021e45"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("7925d9e3-43a0-27b6-15c5-8bc929fc8d42"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("90bf6ad8-60fd-a70c-5086-29415c472f17"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("5eebaac6-8f08-70c8-07f6-93fb56c28d56"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("981d4888-5798-2b75-56d4-1e0a6ed85a49"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("19eff9e3-a4b6-29c4-3a55-3be8964758b2"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("d25a7ec1-049a-8120-a42b-9a31a50949fa"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("600f67a9-3059-796b-7d00-5629be938d22"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("402d1f1c-893c-57d9-0554-b04d28dd3593"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("ab037f3c-1c5e-9220-514b-3ac6532f35fd"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("028f82a9-7c20-80f2-04ed-465d7a2a966e"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("c2d034ba-2bbc-911c-8058-ca5f0ff9a10b"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
        });

            migrationBuilder.InsertData(
                    table: "AmStateLookup",
                    columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                    values: new object[,]
                    {
                        { new Guid("70daa5d5-6a36-4372-987b-48502dbf056d"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("087b08dc-9caa-28ff-7f6b-5654fb7ca1f6"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("e150b155-7b59-8e0a-84e7-84896692253f"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("944e1f52-486b-87e2-0e9f-00f95cf523e6"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("99915a3d-15a9-627b-25f0-7e7aabd86b1d"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("a0e62696-16fc-44f8-a293-9904345e0def"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("cb71378c-0da9-0cd9-5dfb-1d5304ec9700"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("3a0c965f-3cea-23b2-6ed4-40f6d290924b"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("af00cdac-0d24-13c1-908c-066aa56996c3"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("c04d5d57-47c9-8df1-1b4e-bb8924638142"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("01abf1a3-6e9c-7051-14ad-52766bbc5c63"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("7c78f3b7-333d-2298-9972-36a044ea1ac8"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("d6127cff-a630-32b3-5e80-78bc75212713"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("20fb7bb9-0e67-17d8-4bc6-9ae61e5a1d7e"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("da884acf-8963-64d7-309c-72192a1f30ed"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("3af15e81-5422-325e-499f-327addee81cd"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("10ddccc9-15bf-8907-2855-433a1a0a29e1"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("454c77c4-22fb-401d-1973-cfe649050edf"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("c50e80e0-016e-38a0-269f-506707f51e29"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("f8b8da62-9780-9809-5894-888561953d38"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("6b9fcb74-77d1-8a3e-6645-19ed4fff42d0"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("c1286289-53ef-6bd8-0781-6f2fb1e553a2"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("dd186ea6-0cf2-3a59-2271-d09d6e8e895b"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("218eaa12-1aba-3338-0d13-1f8101114747"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("cbddce6a-3925-9454-1a9a-857b77891f7f"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("a155c39e-55a3-55c0-070e-b2b126de560f"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("47be5509-34ad-68ab-2a0a-df14dd9c02e5"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("2b0473b6-94a6-9a5f-354e-0a2b39dd526e"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("89c3a742-01dc-9902-4126-8d7454909e74"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("cded6e23-a3bd-6657-006b-5a048bee1b1b"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("b52572a0-835d-60e3-0ab1-dce468e48e04"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("f6b080ff-6e77-6d18-06b7-eaa57e1515c1"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("92d3fe1e-2b8e-6f34-4519-05d1ea79843e"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("c5c47147-5978-74ca-1ab0-2d3318752586"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("656f2dc0-3879-81ab-2e7f-d1480bed7cb3"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("46be0841-2571-4e74-17fe-72284f0e941d"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("067dc0c4-00c5-85be-0942-01b37df393ca"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("2d9bf9ed-2317-1b74-740f-30e97de44c73"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("98188c38-3f7d-9011-5195-3d1e159f23b5"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("a34eba7e-87dd-29b9-8f1c-46d03a281224"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("7d14edf8-1aa5-71c2-3387-5cb4fd6c540f"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("9d29a5c0-2010-5bbd-099c-3a64e1ca88fa"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
                });

            migrationBuilder.InsertData(
            table: "AmStateLookup",
            columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
            values: new object[,]
            {
                { new Guid("ef088115-5759-36c8-5a53-88cde1ff604b"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                { new Guid("118de6ac-33dd-1da4-3e73-a6ab01138e2b"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                { new Guid("6b66797d-4c7b-757d-22a7-894f5a1551a3"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                { new Guid("af3c8f2b-5d78-3292-8b79-ee7741d7753e"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                { new Guid("b0487e24-8e69-7a63-5972-3d33a1f983d7"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                { new Guid("81ce1dbc-6d69-93f9-65cb-a5c9a3f70fb4"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                { new Guid("09a1c55e-49a1-1c37-3e58-ab54d1738dbd"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                { new Guid("98890010-1330-45ba-36da-6991c0974ab3"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                { new Guid("712309dd-6e04-95a9-6d32-a29849a230de"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                { new Guid("76878a13-127b-a597-44c6-dceedb3f61aa"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                { new Guid("e8c935ca-1ab1-145e-8965-5e411d02086f"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                { new Guid("747a6749-1d13-91ae-2f10-bc4fc1871edc"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                { new Guid("8b5ddbe4-474a-1cf3-8e3c-30ff75557d32"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                { new Guid("b317a5ec-88cd-2719-71a1-3da8677f7395"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                { new Guid("7110ae79-18c8-a245-a1ff-7990a94e50ab"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                { new Guid("406d11ae-9b19-35a1-89f1-a25659c71e34"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                { new Guid("608589c8-472e-834a-63b7-397fcffc4de9"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                { new Guid("c3007d34-64fb-49d5-486d-b21ed69f026f"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                { new Guid("d4cecca3-92d7-7795-31ab-ff28ac5c2681"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                { new Guid("52b41fc0-26d8-55d5-0cf0-e0a2c84f9fb5"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                { new Guid("6747b783-01a8-5520-3922-c676f7eb5558"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                { new Guid("f899d95d-2c50-9aaf-4f75-043976421a7d"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                { new Guid("f2591376-7432-03d7-0130-d78e2e864c52"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                { new Guid("2f324b21-1ea4-60c3-21e7-9f777b952a24"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                { new Guid("914e8cb8-8e82-48c6-0909-4f82c6b3241e"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                { new Guid("fcf8290c-9225-467d-3191-660931ca57a7"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                { new Guid("1df1fe61-a69d-4a11-4a54-c7affe3b7be7"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                { new Guid("a0ba9efd-2983-4deb-405c-ae347f980170"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                { new Guid("0a89e8d7-098a-52c3-3827-1166394f2782"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                { new Guid("c75a67ed-5540-01eb-3ad1-b83413a79a75"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                { new Guid("36aa2c0c-8cfa-2714-8ae4-2fd5becc1d11"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                { new Guid("2bee2c49-a34f-324f-785c-92fd1d076e13"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                { new Guid("e89322b3-a692-89c6-4300-676a94814b6f"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                { new Guid("53cd81b6-6149-2a13-0af3-4cbdb1b595f4"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                { new Guid("14a5361a-a4a2-95d6-7793-50177a2a9b35"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                { new Guid("39238fe9-725f-7709-2aed-bd8c06baa6ea"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                { new Guid("e7263ce0-0386-4971-18db-90ffefed5eb3"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                { new Guid("29bb3a97-4874-989c-52af-0d977f2c2396"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                { new Guid("f3e46ea2-5874-41c5-7634-d1f631fb5715"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                { new Guid("1b3306b0-7e60-6698-160d-321397d374d0"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                { new Guid("b122d9ee-6d7e-4fe2-6067-f7122ecd7279"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                { new Guid("9e141013-0814-902c-59e0-c114405452e1"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
             });

            migrationBuilder.InsertData(
            table: "AmStateLookup",
            columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
            values: new object[,]
            {
                    { new Guid("d5eb65b8-a745-0675-5833-8e9ef96996e1"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                    { new Guid("0b1c62d6-4f29-5c4c-131e-dd34f8502f26"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                    { new Guid("de63e8e9-62e6-4f53-61fd-237f7b1d8081"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                    { new Guid("4c20b05d-3399-6e87-8427-28cfb1f55ec3"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                    { new Guid("44537dd0-0673-9bb0-46fb-5b7ed4b20048"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                    { new Guid("aa19e595-3517-6ef1-6f90-ea22aa655645"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                    { new Guid("f468f35b-0b36-4cf5-5f4b-36e4606b1483"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                    { new Guid("804e2952-6f9e-03c7-23ee-9f30cf1152fb"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                    { new Guid("4534cc49-5396-3804-9fb7-b878e0c12d26"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                    { new Guid("39016454-2a3d-5011-2018-71e36121709e"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                    { new Guid("64bdca1c-0e67-2c61-4c6f-44bf8dfb4154"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                    { new Guid("f59dce7d-8781-9a1f-11f9-8bf9f56f3c69"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                    { new Guid("21ce931f-29ad-5122-3cb0-a33d64195d9e"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                    { new Guid("d14126e9-4827-4abd-50a3-ba6431105850"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                    { new Guid("2bef4c79-800d-0b45-6887-47c8b93d2876"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                    { new Guid("29ff48dd-7658-743c-1c39-ef1500915179"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                    { new Guid("b64568b5-8fe5-3255-5fe1-ad7d814f9d9e"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                    { new Guid("32a9a49a-6e1c-a640-0734-ab54206e3aa3"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                    { new Guid("fd43ef4d-9ffb-1bf1-9bac-711ae7b17a92"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                    { new Guid("13f10283-957e-0b19-2342-6d71e9cb4449"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                    { new Guid("b9dfe188-7c3c-0043-006b-bcb08fb73bf5"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                    { new Guid("ea05dbbd-1246-594a-68c9-373516616093"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                    { new Guid("d38fd200-7528-4ee8-3f43-7c4fde5d36ba"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                    { new Guid("045841eb-383c-0f4d-9148-535229ac0ac2"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                    { new Guid("f39f45f1-0e9a-0e30-9f66-e9082f0d5571"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                    { new Guid("b1c3d803-a6ae-1f43-056d-68ac302f9f03"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                    { new Guid("c4716a54-94ce-9500-5009-118dbc296b43"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                    { new Guid("9404caff-98df-881e-7cc0-fec12fb61d8a"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                    { new Guid("d91c6edf-1ad7-19b1-0f21-46b5a95f37ca"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                    { new Guid("2c6346d0-4b8a-9179-6d6c-a2256cbb74f2"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                    { new Guid("06ff3919-688e-6bf6-60df-6e4183b21d56"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                    { new Guid("128bbdd8-3afc-7821-494b-d36a94ef3eec"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                    { new Guid("cead467b-423a-805c-7e5b-de97dfcc5c96"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                    { new Guid("11d34558-1915-0434-02b4-60b1fa1a818f"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                    { new Guid("45ae553a-14ff-6793-999e-775f8ba11f54"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                    { new Guid("f62900f5-5dd1-8b6b-70fe-d85a8cae4cf9"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                    { new Guid("e3b2ff50-2334-5528-0e81-c9dab28d6049"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                    { new Guid("56b977c0-6eb7-06a2-93d0-b5df8d0b3add"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                    { new Guid("f7523e7b-3896-7e9f-2405-5404b5129725"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                    { new Guid("a6e58a4d-6d75-86c0-01ff-b03989900ead"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                    { new Guid("4f770132-16a6-648b-3c86-0487a67497cb"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                    { new Guid("0c7b4ca7-904f-924d-705b-97ad669f0e5f"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}

             });
            migrationBuilder.InsertData(
            table: "AmStateLookup",
            columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
            values: new object[,]
            {
                    { new Guid("3d85182a-8887-9a4a-36d6-67fabc058a54"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                    { new Guid("bd35af46-9224-4011-1a46-595caed69e6f"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                    { new Guid("1a33d76a-8812-319e-8143-9ebb4b636a32"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                    { new Guid("57109e12-3bd0-093b-2d8a-2d9c8f2f9057"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                    { new Guid("1a3d38f2-0afc-7784-27d3-381f64157789"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                    { new Guid("44bb1eea-06fa-a1a4-0c25-409792184c9d"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                    { new Guid("655f75e1-6b9f-58f7-70c5-b4527d0fa323"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                    { new Guid("38dd5af8-148a-405a-2ab7-3192b3df110f"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                    { new Guid("87230049-59f7-615d-2a99-7adf7e661d68"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                    { new Guid("e4bed8e6-1b88-192c-8c6b-72ec0c6a95ac"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                    { new Guid("f5cfdf94-079a-7166-234f-ba8c9fc14b0a"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                    { new Guid("41b26c9d-4dc8-2085-4a2c-7c946d945298"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                    { new Guid("f7e94c4d-1805-6493-0602-b452bafc7ccb"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                    { new Guid("d3bf5080-2741-1b1e-41cd-9456366b9eab"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                    { new Guid("46af0d21-8f2e-2af3-a1e3-010cdb3483d5"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                    { new Guid("0ccbb4c8-5819-649c-33ce-6b1f0baa3289"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                    { new Guid("994ff21f-31d3-219f-6bdd-12517b032b5f"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                    { new Guid("8a468157-0571-a532-83df-c0cc396c0b5c"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                    { new Guid("fc0d7700-8554-041b-850a-077399dc3b79"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                    { new Guid("722ce47f-a7b2-583a-0821-4889f70d96ec"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                    { new Guid("4f030017-17ec-69ce-41b3-cc9ee84474d9"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                    { new Guid("d5f937b0-94ed-0ca6-18e5-7b9f42167d02"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                    { new Guid("266b107d-06be-5ff8-60d9-53ffe9cf87ea"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                    { new Guid("e10de50c-8043-a6d7-9c15-d9061b36a740"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                    { new Guid("0920d2c4-3a88-92bf-5c0d-af3eba62744f"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                    { new Guid("06ff49d5-59ad-482d-5c76-9719c88e2eb0"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                    { new Guid("07c6d3a7-3d1c-90bc-754e-da45b2b47424"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                    { new Guid("930b195b-21c1-3bd6-716c-548efd5b6dad"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                    { new Guid("c0360527-1b21-3986-7391-999546455f63"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                    { new Guid("5dd34c15-1764-92e6-265f-134f0c7a6932"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                    { new Guid("ed84e5ce-383b-89d0-1890-42dd1c11151c"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                    { new Guid("b72dc9b8-4acd-0daf-2c5e-0a264baf4e2e"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                    { new Guid("7ce7a7b2-1e4e-4853-a016-a82f9ded4cb5"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                    { new Guid("14edeafb-1b57-1d31-83ba-eb7a71f70d22"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                    { new Guid("41832b5b-9636-6974-47b1-23e395eb5684"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                    { new Guid("6054e1c9-6e4c-20ae-3479-e9cb7ca531ab"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                    { new Guid("00f1dc33-57fc-3ebb-a3f8-50dbe5628d6d"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                    { new Guid("228d5832-9d9d-4882-7edc-3a750cfd77aa"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                    { new Guid("2cfbf772-0af7-7418-5c06-df986fb37790"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                    { new Guid("f888280a-92f9-30fc-4cfe-d1d51bfd4218"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                    { new Guid("35a7e954-9d29-8ef3-0874-f0d3a0d328d7"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                    { new Guid("edc2fdfa-1a85-919e-8039-113d28376aba"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}


             });

            migrationBuilder.InsertData(
            table: "AmStateLookup",
            columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
            values: new object[,]
            {
                    { new Guid("25ab9459-8820-37c8-544c-25a5a037a08a"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                    { new Guid("60207a4c-35ca-4bc7-9e7b-f7bd9650305e"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                    { new Guid("cb6483ff-8571-a59d-20ec-15d707a55d40"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                    { new Guid("6d59de96-3da2-5a3a-5611-282bf8921e64"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                    { new Guid("70f80ee1-73d6-30b7-2367-91a3c08921fe"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                    { new Guid("2a2ad67a-04b6-56e9-27ba-357ed2f2a412"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                    { new Guid("a7280b5e-a558-0973-890f-029e22dd36e3"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                    { new Guid("0bdb1595-a2a3-0e5b-4f6c-8e51e7874802"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                    { new Guid("38264a0b-9dd7-8a35-6a4d-3f624d7c0714"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                    { new Guid("2b3dac55-650b-07df-70a0-f2f4b38f8d68"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                    { new Guid("2c4c47f0-9872-7a59-9ac5-f94c2ab20731"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                    { new Guid("f7249031-4ac6-0edb-03c4-2b2ccdb25a00"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                    { new Guid("2ebee418-1803-9419-a571-4be639618bca"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                    { new Guid("f2271c93-9408-481a-645e-a67d3ad67659"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                    { new Guid("44573847-97fd-0f01-9222-c07387764470"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                    { new Guid("fb7286ce-8884-6898-0e81-4ba5507f759f"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                    { new Guid("8758f81d-9bb5-42b3-82af-13b5ff5e1cb8"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                    { new Guid("e2e8b027-216c-3b67-8e81-7f55ada26e8f"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                    { new Guid("02692376-64c7-a167-58e3-a8e7220a1ae7"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                    { new Guid("4e22ed0b-604d-2895-5274-03b9dbdc5c9f"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                    { new Guid("0f44474e-0a69-8c9a-1c58-6334239c4f43"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                    { new Guid("8d64c0f4-8e72-73a6-2c3f-f5df0e9c692d"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                    { new Guid("d2665f08-3625-25c6-232f-daf346965006"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                    { new Guid("cc8662f6-66e0-9a3a-0f37-1931bef6505b"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                    { new Guid("d9dc4813-2a44-4296-a296-c7675d33860b"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                    { new Guid("674d4c96-8810-1780-8002-b0bdc7e6356c"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                    { new Guid("b604041d-7e95-7fc4-0340-209f2c3e5845"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                    { new Guid("019a08c8-6bd9-3f99-8499-f14c3dc640a1"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                    { new Guid("b00fb452-a274-10ca-9c2d-210b4b8f9468"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                    { new Guid("bae7539b-46d5-66b6-4bc6-7e386d7e714b"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                    { new Guid("41b70673-5b9b-49c4-1428-9dad3bfd7139"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                    { new Guid("13e38426-2497-82ff-7b61-952c5de4a31a"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                    { new Guid("e722c696-16a4-1fca-8522-ad95415c48d9"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                    { new Guid("3c454879-36c2-67c4-6b00-537710d223c8"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                    { new Guid("5d494048-5c4e-4dcd-2bbe-0730ad1aa0e7"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                    { new Guid("d01e0d21-4494-59e4-7b07-1941d52c3bee"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                    { new Guid("f9cd44d2-3c68-7962-1fd7-5abff1935022"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                    { new Guid("aedb6069-39ab-93ce-4c27-5b46aa99a434"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                    { new Guid("ad4403ee-791c-4434-42dd-9f13a34d4e80"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                    { new Guid("980582da-0a8f-1d29-00f8-3d23ae9b76e7"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                    { new Guid("e5d55182-8033-53a5-81df-d608ea09a4a3"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                    { new Guid("2552ff07-26d0-7a9d-4aac-6649eda6959c"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
             });

            migrationBuilder.InsertData(
                table: "AmStateLookup",
                columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                values: new object[,]
                {
                        { new Guid("b20e52c9-183c-1df9-8e01-cdaacca18f77"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("d9f4f937-756f-2ff7-4340-647f59cf70c8"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("933d0d5a-2bdf-5f1d-42fe-7d3435c13c54"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("cab6b00e-26e5-471f-904d-0088ad4e701a"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("309f9818-165b-59b8-4be5-b99af49a405c"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("313a28b1-5e57-76a8-0951-230d3db8460b"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("8119a786-2bc6-9000-4eaa-09f3ab612ff2"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("b1f74f53-5f7e-4833-4abc-540118f532db"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("94217fc7-635e-9774-48e7-ca272de01092"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("a343d712-8cbf-0f2e-53d4-908f07083f52"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("e1ab085d-5397-5fe9-9552-da70032d0059"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("de673343-3b0a-3159-6052-b28463a868db"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("88086ed4-9136-51a0-6550-17080f807492"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("240894fa-7239-5bf8-1aaa-66c0a1780203"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("fc3021e0-775e-0c8a-1525-04ba99ec43c7"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("59855d05-a1fe-a44d-2ece-bbe72f8b28e3"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("74233080-4752-1ab8-2c69-783a80622981"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("a7bc5db9-21c2-4635-0d01-d6c2cbd670f2"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("771090cd-6b54-a365-68ed-50a4daa82a7f"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("19237007-7541-5264-8395-e756874c8a85"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("4144e892-1099-8cb2-2ce5-988b1be27d74"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("c1632c65-6209-3ce0-9f9e-be73beaa4095"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("f99f1863-2828-11d7-2b38-c7c7d8c27b41"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("070f8b00-518f-273e-7b56-750b4d244014"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("26eedcaa-88e2-3db3-6b50-455aa9b7260d"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("6a1c498c-7cc4-6670-8737-bf895e018176"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("7474f405-19b2-6a51-a619-2670d0f8502b"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("6c4f0843-a3fd-84ba-2af5-6b343e4388e3"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("11d859f6-4079-72f2-7c70-3f5e6c5b470e"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("a3e6b500-9db5-6b8a-5a85-70bf95199d9b"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("36e1ea04-3bc8-39fd-3f38-72eb6c0c479e"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("e4b30585-4514-3655-9db3-1c93d9ca5a54"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("488c1a2f-923e-2f2a-1914-d6e741f79c99"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("1c8842d2-4970-7b53-89d6-f1beb5209c09"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("b40f6f40-25df-49c9-301c-c5092f437645"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("bd62ac5c-559f-5ac1-7104-3fa55d480509"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("4dcd269f-6fef-a2c8-03e7-68c8eb82a733"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("3e299756-1dfa-8c2f-47ac-a7e9160c1833"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("88482dd6-6fa0-1f9f-9d90-cc09e73e3719"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("9930e494-35c0-7690-7175-2a6b39063400"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("5d15f884-6063-3170-66c1-2f51e98d7f4b"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("f2a07415-2062-38b0-07bd-de3087954458"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
                });


            migrationBuilder.InsertData(
                table: "AmStateLookup",
                columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                values: new object[,]
                {
                        { new Guid("7704afc2-a24a-a501-5161-9b908f0790aa"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("7c10237f-77a9-0f03-0f9c-b61daf1c04bc"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("6eecab0d-5578-253b-67cf-5aa37e150e16"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("771ba658-3f47-9c2b-6475-8dd692139b85"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("fb4eae05-a18a-4b23-5eef-c44efa89a5b3"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("2a3ed84a-79b4-1abb-a426-c1a06a0843ab"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("fb2aa7d3-9078-a61a-9b4d-459107580b80"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("66b22f0c-1460-9ad6-9d1d-823f67221f7d"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("a18ce909-a341-7995-10bd-88d105572ec0"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("a536a89b-7593-9961-a256-f3b87b192b34"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("7a6439ee-2b76-8ed1-470c-f91cd5333887"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("45da68d8-2b5b-40bc-1b4d-695543931fea"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("df5bc937-955f-0867-064a-83ba6a42338e"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("98f453fa-88b5-29f3-a3f5-38c7fa75651c"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("5624eff6-73c7-0845-097b-6ab3a2e9441d"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("d3144b44-3cae-01e5-5822-c5d502ef017c"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("70e718d5-4b52-63f1-8538-8e5135aa8f9f"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("67c6bed8-2904-9759-7529-0830ac9e54c2"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("167b5cfe-863c-7dd8-6408-5ee355e70bd6"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("29c7290b-6e4e-26f2-804e-d038ca8f2bd0"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("60cf5418-13dc-7fcc-87fa-c46fb64553d4"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("0f874f81-0f4b-7e27-8e1d-405f07811e17"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("c86b2202-4b39-8cfb-5ec7-8977beb777e6"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("e54ea9d7-88f1-1e17-61b9-4338f51e00f5"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("1488adc9-29bd-48ea-4997-645c8b2f803c"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("b437f09e-12d3-a1ac-9c70-b967add26897"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("a798de86-17f8-780e-674b-9d9e59ca6c34"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("d8fafe6e-5800-578f-a744-6a84f8aa0115"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("78947355-97c8-5a81-2da1-16e8da254cab"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("ded40b99-36fe-7730-7c62-417c773929d2"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("31a5e23c-12f6-9ac7-835c-c41755f575b5"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("0f0391da-3861-1f0a-8c4d-1f2c48784b61"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("ed34a23a-2ca3-3002-548f-336ac2db7149"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("e55f5a3e-5244-55de-3746-9d1ddffe1a90"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("a3cba2cc-6a6c-013e-6829-28acc04c8a4c"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("5abc8421-6923-0fdd-3ed6-8c513f577051"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("e4141dec-102c-a20b-121e-8ff9595710b9"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("3d5d0891-7a01-531f-978b-5dc8d84537fd"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("c54948b7-72fc-130d-865e-b82a16fa133f"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("41c050b1-2a91-0f12-3f55-b606b2442e35"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("607198e2-5115-1648-a4aa-c5d27f142111"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("1f5ccc3b-67bb-303e-5993-136404bf2e69"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
                });

            migrationBuilder.InsertData(
                table: "AmStateLookup",
                columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                values: new object[,]
                  {
                    { new Guid("3717c2fc-6edc-3e51-7caf-b7445d8667b0"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                    { new Guid("244cf811-1019-2193-6eb1-7b7a522708e9"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                    { new Guid("158c8b88-58d8-0b6a-62d5-fede226f122a"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                    { new Guid("17aff11d-9976-52d3-85af-cf0da7e91683"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                    { new Guid("64436640-39ff-8a67-9046-96a20ac98ce8"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                    { new Guid("08cd1620-77f8-6197-5156-a381b4774c0b"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                    { new Guid("165f2674-2336-01f7-5c95-16d9ddf64b44"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                    { new Guid("b377a704-320f-5afe-3158-dc78bcd75bfc"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                    { new Guid("a8e8d407-86a7-6d48-4c48-15cafe3a9606"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                    { new Guid("34d5dfbd-1a73-3dbc-6277-a4649da05b19"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                    { new Guid("34c93b69-7d5e-8e75-3bb1-958f6973972a"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                    { new Guid("6136976b-2e9c-4253-30a7-529bc434656d"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                    { new Guid("8862daad-8303-92ff-2a3b-fb948b554fbf"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                    { new Guid("5bd3036b-a0cc-a1ed-92d6-346222f34137"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                    { new Guid("1765f9fe-8e95-95de-9517-15d88fdb5dd1"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                    { new Guid("1dbdae92-7cfa-0ca4-253d-c50f3534980d"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                    { new Guid("c6a81c67-39ae-173c-38fd-922f5eea2023"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                    { new Guid("a59a4f6b-3d09-55e4-114c-12737ab31783"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                    { new Guid("bc8dc36d-1188-07c5-9ac6-ee7c7bce9d76"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                    { new Guid("c30d09a7-8464-3d03-1334-3f00bf3d6042"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                    { new Guid("3e01600c-5c43-28e3-7802-e64a35804b16"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                    { new Guid("687fedfe-0d9a-16b7-47d6-6bfb81f73ff5"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                    { new Guid("2efe9488-5202-2cdb-4646-9742141b4a70"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                    { new Guid("53d983ff-33cc-9ce8-32f9-cbef18307d36"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                    { new Guid("e044b960-0394-98da-36ae-f972d866676a"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                    { new Guid("db7745fb-8e05-281e-5b81-41dab63e130e"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                    { new Guid("3dde3b27-2829-73f6-7593-c0f33cd33007"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                    { new Guid("8d2dc07a-9769-88b5-3a68-0b572a9a1c31"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                    { new Guid("9ea98e42-41fd-a646-9005-e13a4b5b0722"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                    { new Guid("40063b6f-6480-1068-4d11-3c65cb8b4b33"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                    { new Guid("417f9eb5-1a6a-952b-3c1d-c83f9b1a88f9"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                    { new Guid("4e06d5fd-68c3-783a-6612-9984204187e8"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                    { new Guid("0fa352e6-05c8-8b4e-7332-d9cb9d527d5d"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                    { new Guid("072f7abc-0baf-6b26-2428-565e7d759f3a"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                    { new Guid("66167244-8c89-4d44-30ac-5ca3a3aa2609"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                    { new Guid("331d6eb2-47ce-738a-1804-b316ac0a1f66"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                    { new Guid("d5bd5e2c-72d9-1a95-0cad-f56e85ec81de"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                    { new Guid("5a01b1d2-2561-0f25-0510-2276a2ca21e8"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                    { new Guid("e5a844c1-1953-7854-540d-98647bb851e3"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                    { new Guid("74caa16d-91d3-5605-6287-6065c8550ba2"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                    { new Guid("9df65a42-24e2-8ae7-06e0-892ae0bf6bbe"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                    { new Guid("fec284ae-755a-150f-82b9-b149031666e8"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}

    });
            migrationBuilder.InsertData(
                table: "AmStateLookup",
                columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                values: new object[,]
                  {
                        { new Guid("63d267d7-7960-3aa7-4045-910b6adf08f4"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("869d39a9-0dbf-630f-9c2c-a94773843b26"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("c0d12870-8967-70c4-7f2e-5323704d7238"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("31fe98e6-545c-15c7-3403-104520b16b7c"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("bc908b01-46f6-6d5d-589f-d862166d8335"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("9015c109-16f3-a761-2602-4a084bf980d8"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("772802eb-44b2-07ea-62ba-5a05cf9a8fe2"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("b70acfda-969c-468e-5541-3f02a01a282f"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("087ef9cf-0945-6ea5-5f61-990dc35227d9"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("3dd414c9-5e3f-517e-6920-c215c6079347"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("d55abcfb-3d37-358e-7621-a768548e1555"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("0f6eb077-4054-8482-856d-07d5d2ce9aa3"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("9c88d7c4-1dd1-224c-4a85-c86773d6a594"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("4e6631b9-a512-680b-7ba3-e520f97f5cfe"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("d8e6d820-8402-0ef6-6432-2decfc0c6963"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("eedc1557-0951-4d43-9736-493f90da849b"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("8dde2f39-6476-a295-4b62-66771d2a757e"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("90fbee49-8819-1255-692d-54c051450269"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("7dc725f0-3735-2d35-1ec5-1ef05e8261c5"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("581a5e13-4713-a135-2596-ae315f3305aa"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("2408a408-38a0-7f5d-0d87-6751eaa41605"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("d97be13f-65b2-207d-56b7-f307d5727415"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("c1a523e4-0829-9d47-5944-a676cfa65476"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("1350c14c-1eac-03e4-7f72-b7374a987d9c"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("fbf54c2b-301f-0cab-9d3f-59916bfb8bde"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("f534b80f-8dba-966c-4917-4d81c7a30388"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("d3bfbeb4-3979-3d15-91ec-0dc49eefa2ff"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("5460691e-1c04-9fda-5d5d-4cc2f2707655"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("25eea804-899c-5a1c-7484-af376df099dc"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("79ecbe78-8dd0-7442-66fd-e8c193b85fa8"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("15b425b1-18b1-9866-60c9-372473e13cd2"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("6a355c7a-1b9e-81ae-0a33-24a154478c47"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("bdedb9c0-2e11-400f-8f90-4940cd7b139a"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("03c6ef08-3f20-1e0c-0574-68f2b4ad9b96"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("fa051948-2999-6f9e-a538-ca79e5994cf7"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("a141400a-2841-5d0e-20fd-8a1346a41e1b"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("499c3702-9b04-7a01-6441-9ce48c8b4a1c"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("94a60a9d-0fcb-36c6-9542-6efad94c1f6d"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("e649a5b6-5519-18de-25de-cc5cd28c5165"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("ac000a77-535b-7f44-90c5-2118bb443eb6"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("64ff3991-004b-8a1f-089f-542304106813"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("19c50cd2-5ad2-869e-2dd1-b8aa628c7ebf"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
                });

            migrationBuilder.InsertData(
                table: "AmStateLookup",
                columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                values: new object[,]
                 {
                     { new Guid("1607eafb-6bf5-8506-8256-72b608ec1498"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("75b94cea-7d1a-7f2d-9031-3f97111b0c36"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("cb55b5a3-510c-8f61-829d-bba067e7935f"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("ba292ad6-0ceb-782e-22b2-4c39422a4a80"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("9241349e-1e14-5789-7ca4-b4645097321d"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("4f29ebc6-41e6-a146-1547-8af3471e93df"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("303fa1aa-7284-0a53-525b-4be0f14f54b6"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("b445b131-9836-61d5-318f-6a759b4868cc"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("22c23af3-38db-014f-2cb3-edc66d968bca"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("a4295782-8b5c-6cfb-a55d-50b300ec3e04"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("3cd4b656-9eed-900e-2bb1-e4a953994326"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("097babcb-9d5a-6fb0-98cf-a86f4762660e"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("071753c1-9132-4cf6-8f31-18f0a57c7ab1"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("e286cafe-9a00-9f25-2c93-69019194094e"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("5486a9bd-8574-623b-478c-4fc7ef013a96"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("6455ffe1-03a5-928d-7913-42b582138947"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("c718faf9-1e30-9c50-0af5-f0d9eb887af1"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("913205ff-12f6-3eae-193c-f2c400ca6b61"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("4d172ac0-1d2d-0f4c-292e-86f8f73a4f5c"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("f70b5141-21b1-3ae5-3ec8-81f192305987"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("a7842475-6e2b-283e-2b04-70a0cc3a0b3c"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("294c4673-6f18-8b7e-39d4-a2e4c55281ce"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("2c1a9a25-6b2d-5119-5804-da286f8d639b"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("5f24bbe7-1523-2703-772e-c24bbfb02f50"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("8c5de456-9991-5589-0046-f23ac3c31799"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("956125cf-000e-20b4-3710-d5750d4b7628"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("6b3af8ea-2e7f-4fb3-465c-4c80a46b51f7"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("73ad7d5d-8cbc-212d-1278-ff1f58bd7a39"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("efa56eb4-9856-03b3-9202-e000e2273f25"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("c6519aa1-339b-4527-0899-42d9bbba7e66"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("7f626440-6b40-3e8f-5f26-d718b4ce4434"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("002f6bb8-622d-150e-280a-221a11216f4f"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("d5949101-3f45-8a87-1002-013bd40d17b0"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("5fd547e4-941d-5bec-10c9-21d67f971ebb"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("bf1d60a0-1fac-05c5-8798-5a1b3b9e4f9c"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("d87fd7e0-64fb-02fe-832d-9cf5220f5baa"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("95dd6aea-81e0-27bb-4868-0b689ca7a065"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("58602e74-8979-7da5-5e38-1269aeb9574c"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("f5d0e7c3-4e5a-80a1-0a18-32367b609e8e"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("d475e2fc-970d-6cb3-5ece-e9059ddd77d6"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("7d41e25e-402b-6573-80c5-07423daf4ef6"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("a88a7c32-1b20-3eb3-3bfe-dc57f0a42e31"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}

                });

            migrationBuilder.InsertData(
                table: "AmStateLookup",
                columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                values: new object[,]
                 {
                          { new Guid("92045262-6b12-4c84-a255-f6b7ee834893"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("146b0509-03cd-66ec-7a5c-5a14fdf910ca")},
                        { new Guid("c1cebfd2-467a-7280-26bc-74d640ca6f89"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f85")},
                        { new Guid("fa27f628-736b-1ce5-a6f0-bdb0af5c8a00"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("d340f944-5543-0825-a6fe-ffb33feba2dc")},
                        { new Guid("4601224a-7f77-7a64-4513-040017930056"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("414aec1d-2f1b-980a-7cef-dc2a74338013")},
                        { new Guid("a52aabb8-2703-7127-1f22-192191f37e80"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("6d6f453c-2ba5-3594-8ee8-dcb7545604e5")},
                        { new Guid("ad2ab953-a47b-162a-229a-ac87c55b8677"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("078cc111-a264-7212-16cc-fba56d360f18")},
                        { new Guid("40f90508-7800-662a-6828-628f3b1d384a"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("61b43371-6b2e-a3a0-9d83-643e397877c2")},
                        { new Guid("a5f9b831-80a2-6b49-04a6-4b34c4bd21ca"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("ebaeeabc-638d-9b52-2277-d2aca774019a")},
                        { new Guid("ca266e4d-3c43-0173-9ad9-5de5462164da"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("7b3f30e6-2fc0-00af-5463-d2cdb5371792")},
                        { new Guid("7c816477-1c38-a05e-9afa-64e1234513b6"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("1b7fb102-77b3-a1dd-574c-ac2c23bf5c7a")},
                        { new Guid("b30c81d2-2569-95c0-7688-6ee412d686cb"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("05a30bf4-6a99-479c-1b5a-9f196a6ba45a")},
                        { new Guid("a3888b02-9762-8106-27be-5c3e762f263f"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("0e2b7914-0408-5d00-761b-100167f6552c")},
                        { new Guid("94bccd7c-4423-9b80-45ae-38a0f53e9240"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("0eb8cf7c-1196-6e1f-1559-94e22813972a")},
                        { new Guid("9f450cbd-9550-0472-8fc8-17773ac11c7c"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("5a6be76d-67e9-5a2f-2d98-6b4f50ec3990")},
                        { new Guid("c2754ddf-0305-1606-839d-58b2f6af4cba"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("871d6482-4d46-0626-4bbd-18ebc7c89f84")},
                        { new Guid("874ede65-0144-7eb2-0a1e-41a42e9b96dc"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("0be543f8-0209-9f39-753b-27eef29649f9")},
                        { new Guid("6c925315-2760-6ffc-3ac1-20a5374d510e"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("25412f3a-5715-04d5-42a4-917306029a7a")},
                        { new Guid("6328d023-9df2-4731-884e-4cb814326b3a"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("a207e798-6387-3fda-8e7f-d2559e4da433")},
                        { new Guid("55285a72-57f3-527c-72fe-1d07e3324eaf"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("28f77124-2487-111b-24bb-108da88f3f9a")},
                        { new Guid("6bd0362d-8caf-47da-6016-f9112eb76bc0"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("3ad1b55c-0fab-3a58-7baa-310cf20b13d4")},
                        { new Guid("5563b6e8-a38c-86a2-6726-43ca9cfb37d2"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("f6a82da3-38cd-4d96-5b51-45abf82f07bd")},
                        { new Guid("a5b95b35-0ff0-21bd-8d93-bfac0c3e7338"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("906cb2cc-0d16-88fe-6b70-209075703618")},
                        { new Guid("94ff3dd1-78d0-497d-06d7-3124c5897cee"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("855e3657-1e75-4f1c-58ec-0f4ee28184a0")},
                        { new Guid("a60535b7-593a-2404-0d55-912414bc3436"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("ed16aae9-3cb2-a51b-90e0-82ec73738333")},
                        { new Guid("a217c471-5cbf-12e7-4255-1cbd0554898f"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("1d7e5762-7c92-9682-8267-e6b86c4e8282")},
                        { new Guid("60262baa-2aeb-9c05-5a76-c109340520a3"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("1df968a1-0835-9373-a47a-4390d91e1091")},
                        { new Guid("2dd40400-51cd-6a2d-2d1f-3d566c532307"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("5c24d582-0d75-8645-3618-68bb3c5f4c51")},
                        { new Guid("9caf2aef-06a7-8b79-8199-6996c4886382"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("0492e911-660f-3062-2ef3-2f178a9a7c77")},
                        { new Guid("4e759fce-4372-8263-2921-cb0d716f346f"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("37bb0cdb-04e8-7d90-035a-caf2f83e589e")},
                        { new Guid("92001de1-1333-a0db-a3fd-5b74932190db"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca8")},
                        { new Guid("61411d2a-4173-3187-02b9-0362f9a957b1"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("fc0bc2ff-2eef-4b97-9f8b-5ff3067d248a")},
                        { new Guid("7b5e1c03-757c-6860-6076-2f4733b69ca5"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("595994f6-6794-741a-4937-9cbdd3d18c20")},
                        { new Guid("b86b9b63-610d-3618-04f6-ee3794fca02e"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("beaf6384-4747-8152-0887-fe19fe7157b1")},
                        { new Guid("d3304ea2-65f3-1271-36c0-cdbbf33c81ee"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("21de2f96-1774-9bef-934c-50a24aa4603d")},
                        { new Guid("b45436a4-4a05-88ff-22b8-9ccd2d7150aa"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("0536004d-a384-a7a7-04af-f73781164fa3")},
                        { new Guid("9a2e64cc-55ee-422c-70dd-0186b28a6a45"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("c09f80e2-0733-8048-58e8-aeb887c313a2")},
                        { new Guid("16bef37c-9290-64e9-a702-0dc2534f1271"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("811edfe2-97a4-624f-9b8c-eb312da41ab3")},
                        { new Guid("10dd1487-4e65-7903-1ec2-f63ca7103f64"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("c5c6c08a-2cca-321c-0918-08e84097547b")},
                        { new Guid("1f42d0a8-9be8-7fe2-45f3-c06bd29f6a52"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("8d2c3d92-9a80-4f56-115d-cec7f9d07ad4")},
                        { new Guid("19608b1f-3767-396b-9984-cbdef1820576"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("9b376a45-1bc5-5961-6d11-4163679d674a")},
                        { new Guid("a76089cc-3740-62de-9510-68c38afe49b1"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("fbcf9730-480e-780e-17b2-edcbd13f8362")},
                        { new Guid("2f1a9c3d-10ff-1db6-0cf6-32137afa8372"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("40f57aa9-74f8-a654-54ea-d7bb796b8f9e")}
              });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("934f95f0-da30-45b8-9cb7-4d9c8ec0aa90"), 83, 278.28m, 1, 1, true },
                    { new Guid("3a9c24a0-9821-4c20-82eb-0c9d73d392cf"), 84, 301.39m, 1, 1, true },
                    { new Guid("7a6b4eb5-8ccf-462e-9154-a06f11f65277"), 85, 328.83m, 1, 1, true },
                    { new Guid("a02649ec-ddf1-4bb7-b6dc-fa13abb9193b"), 50, 47.26m, 0, 2, false },
                    { new Guid("2886e5f2-08d0-4ae1-89c3-4767e63057ec"), 54, 56.85m, 0, 2, false },
                    { new Guid("abb54fcc-48ba-4bbb-9ca8-eed85a46087b"), 52, 51.76m, 0, 2, false },
                    { new Guid("edc30be0-51d5-4295-8baa-81b5e378e49a"), 53, 54.3m, 0, 2, false },
                    { new Guid("d91abcf2-63c4-484d-b939-2117a42ef6b4"), 55, 59.1m, 0, 2, false },
                    { new Guid("5fc7bc77-2c8c-46ae-a49d-49aba8fb1c5a"), 82, 258.06m, 1, 1, true },
                    { new Guid("7a3cd74c-885d-40ca-ad5c-8ceca78fd99c"), 51, 49.51m, 0, 2, false },
                    { new Guid("85a5d7bf-1ffd-4a00-a2bf-566eb5d05100"), 81, 238.85m, 1, 1, true },
                    { new Guid("594b7040-c160-4456-b247-0f196dccb733"), 71, 127.72m, 1, 1, true },
                    { new Guid("89db2f6a-beb0-49a8-904b-5fdc68c2aefa"), 79, 207.22m, 1, 1, true },
                    { new Guid("b47393b9-2afc-4706-8822-be6ab5a562bf"), 78, 193.5m, 1, 1, true },
                    { new Guid("19f424ae-c597-42eb-aaa2-3dd01d437d79"), 77, 180.79m, 1, 1, true },
                    { new Guid("fe1751d7-b340-4e51-a0df-6ef432e614ec"), 76, 174.29m, 1, 1, true },
                    { new Guid("5295f376-33c3-4936-af2b-032d0f7c40ff"), 75, 164.03m, 1, 1, true },
                    { new Guid("94b98c11-91fb-478b-aa89-69bb70a7f382"), 74, 152.18m, 1, 1, true },
                    { new Guid("a57546c3-b0d4-489c-9a46-2e487d473057"), 73, 143.78m, 1, 1, true },
                    { new Guid("4dd3abcd-7544-4641-aa30-f5b645bfaa19"), 72, 134.86m, 1, 1, true },
                    { new Guid("dc2a3f93-b4a9-4ddd-a7c3-505242ac651b"), 56, 62.07m, 0, 2, false },
                    { new Guid("354d2455-b61d-44c5-afd4-4d285c54b2ba"), 70, 120.21m, 1, 1, true },
                    { new Guid("220d6473-f19a-4d6f-9642-0cfa528b89e6"), 69, 115.36m, 1, 1, true },
                    { new Guid("31e4ce1c-082c-44a9-b3c9-3eb910c49a70"), 80, 224.54m, 1, 1, true },
                    { new Guid("4c2bc4af-10a2-4c5c-8bc2-8aec36f3f56c"), 57, 65.21m, 0, 2, false },
                    { new Guid("46d173da-9a89-4779-82fb-c01f44d27784"), 67, 113.79m, 0, 2, false },
                    { new Guid("4e3b13af-069d-4cfa-99e4-4dec2f0811c1"), 59, 71.96m, 0, 2, false },
                    { new Guid("5ce2a104-161e-48c3-89eb-f9e98d1bf74b"), 68, 109.89m, 1, 1, true },
                    { new Guid("c3533fef-16c2-4e56-a280-b8d7a1e7cea2"), 82, 303.16m, 0, 2, false }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("db1f6859-4949-47e3-8ab4-d5066feefb94"), 81, 287.61m, 0, 2, false },
                    { new Guid("3f326ee0-4b70-4f17-919a-5dcd46d043fb"), 80, 271.98m, 0, 2, false },
                    { new Guid("8e50e7fe-7c5d-4d8a-82ad-dc1f3503b318"), 79, 253.37m, 0, 2, false },
                    { new Guid("1f23e786-0458-49c2-8c84-52f730bb7dcb"), 78, 234.14m, 0, 2, false },
                    { new Guid("5f8e6f53-ab9c-47f1-b17b-addad6c4444f"), 77, 215.62m, 0, 2, false },
                    { new Guid("dbcf2e52-1270-43e0-be22-c1af69822dbf"), 76, 197.86m, 0, 2, false },
                    { new Guid("6941a3c7-15f1-4837-bd15-c4397e38202c"), 75, 183.24m, 0, 2, false },
                    { new Guid("973c5292-4c4c-4f46-827e-265052256f58"), 74, 170.68m, 0, 2, false },
                    { new Guid("857824cf-1171-4c7c-981c-f27acad03791"), 73, 161.15m, 0, 2, false },
                    { new Guid("eb199709-64fe-46b4-a8bc-c4b04e5e4dc5"), 72, 151.05m, 0, 2, false },
                    { new Guid("d85a3a68-5224-4c68-8f49-66b623a36ae8"), 71, 141.58m, 0, 2, false },
                    { new Guid("2034ce92-163a-4257-96e9-0f5b63ee6b8c"), 70, 133.2m, 0, 2, false },
                    { new Guid("8a44979d-5311-431e-a61e-51505e9eedf2"), 69, 129.48m, 0, 2, false },
                    { new Guid("6c2b1989-2423-4406-ac80-921dce87b1a0"), 68, 121.62m, 0, 2, false },
                    { new Guid("dfc66759-74c3-4ee6-a4ea-d3815f778c13"), 66, 106.46m, 0, 2, false },
                    { new Guid("8f49f441-1612-439d-821d-eb97320186cf"), 65, 99.75m, 0, 2, false },
                    { new Guid("3ec5399e-251c-4f3f-917d-b3e00b5c2be7"), 64, 94.44m, 0, 2, false },
                    { new Guid("d06b0019-b677-4f14-ae4b-dd29214bc51e"), 63, 89.4m, 0, 2, false },
                    { new Guid("a12780a4-98b9-4af5-9365-bb9fa454f920"), 62, 84.22m, 0, 2, false },
                    { new Guid("57f67427-a358-45d8-9913-ed997f78319a"), 61, 79.19m, 0, 2, false },
                    { new Guid("5f63ce09-a396-4edf-8770-d82492dd573c"), 60, 74.63m, 0, 2, false },
                    { new Guid("ae768b03-90d0-46bb-a923-c3c51a19a105"), 58, 68.51m, 0, 2, false },
                    { new Guid("989f1c3e-2e9a-4c1a-8a5b-9494b87d63aa"), 67, 103.39m, 1, 1, true },
                    { new Guid("e0861750-7725-4966-bf6d-b9e7cb1ccbb6"), 76, 129.78m, 1, 1, false },
                    { new Guid("f1a422cd-2a89-4ed1-9edb-8b05a7362a8b"), 65, 91.67m, 1, 1, true },
                    { new Guid("922616ca-8b22-4280-87ff-880e6d4f328e"), 73, 104.83m, 1, 1, false },
                    { new Guid("42f72066-134f-49eb-967a-75059e9cfdb2"), 72, 97.82m, 1, 1, false },
                    { new Guid("7e38e364-66bf-47f7-b4ad-f3d538013c73"), 71, 91.71m, 1, 1, false },
                    { new Guid("33e961a3-e57c-45c3-8e5e-4dce2224b0b9"), 70, 86.3m, 1, 1, false },
                    { new Guid("e9340a71-01c0-481e-81d2-dca6082a83dc"), 69, 83.7m, 1, 1, false },
                    { new Guid("7aa9fe4a-f64b-4b21-8ab6-2d5419880856"), 68, 78.19m, 1, 1, false },
                    { new Guid("daa21e63-9cf5-46e1-83ef-9376c7e8dbc8"), 67, 73.08m, 1, 1, false },
                    { new Guid("1df78362-0554-4bcf-8e1f-a698649e881f"), 66, 68.27m, 1, 1, false },
                    { new Guid("227197f1-f097-4601-a719-bcd2bd06f9ea"), 65, 63.86m, 1, 1, false },
                    { new Guid("ec69ad99-1707-4576-ae9e-cb2d3a471be8"), 64, 60.58m, 1, 1, false },
                    { new Guid("8cbc3545-655f-4ea0-b2bc-9ad2a0642f0d"), 63, 57.49m, 1, 1, false },
                    { new Guid("a0dcfa3e-ab0a-4963-9b64-3aa4d51f55e4"), 62, 54.58m, 1, 1, false },
                    { new Guid("1f9d8d47-de1b-461c-9bb7-c05c623ac3a1"), 61, 51.75m, 1, 1, false },
                    { new Guid("7586b2f8-36ac-4c39-bb03-29d52ad9ad05"), 60, 49.18m, 1, 1, false },
                    { new Guid("c0c3c06d-0343-4c56-8eb6-5dfde5e7b84e"), 59, 47.68m, 1, 1, false },
                    { new Guid("6cd20c57-85d0-49ce-9781-930bbfb010b2"), 58, 45.73m, 1, 1, false },
                    { new Guid("08f7702c-7f21-4a30-bbc0-9c2ecc740710"), 57, 43.88m, 1, 1, false }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("b70dc708-77f0-4261-ac09-65079130a4ba"), 56, 42.11m, 1, 1, false },
                    { new Guid("0734ad2c-4f92-42a7-954e-a38797fcfa5b"), 55, 40.43m, 1, 1, false },
                    { new Guid("c099fe89-ec2e-4fde-80a9-90961ba196be"), 54, 38.58m, 1, 1, false },
                    { new Guid("88cb269c-dbab-41c5-b5b0-3af619ea88c2"), 53, 36.73m, 1, 1, false },
                    { new Guid("cc4541f7-a7eb-4b93-887f-25622600cbbd"), 52, 34.88m, 1, 1, false },
                    { new Guid("2fcbe02b-9a7e-43ea-b689-bd64b27f98c4"), 51, 33.24m, 1, 1, false },
                    { new Guid("df58b424-7e9d-4178-80fc-c4681977fc3e"), 74, 113.3m, 1, 1, false },
                    { new Guid("b85fcec0-912a-4ce1-a820-0791b17de085"), 66, 97.27m, 1, 1, true },
                    { new Guid("22632357-a5d8-44ae-8274-f49cbb75a937"), 75, 120.77m, 1, 1, false },
                    { new Guid("b4781237-596c-463f-828d-8af6a3cce556"), 77, 140.6m, 1, 1, false },
                    { new Guid("8d24eaa8-381b-4005-aa1c-dbfe8e4dd17e"), 64, 86.11m, 1, 1, true },
                    { new Guid("9c455c39-c55e-478c-b266-51735b9cb983"), 63, 80.83m, 1, 1, true },
                    { new Guid("6ce11b5e-1a05-4883-8ef0-bcd369077178"), 62, 75.86m, 1, 1, true },
                    { new Guid("1fd0018a-9c82-46e1-b5dc-b37abac5d570"), 61, 71.04m, 1, 1, true },
                    { new Guid("1c9b77bd-7ee1-4707-9cbc-ab78ebfdfa56"), 60, 66.67m, 1, 1, true },
                    { new Guid("dab05d69-55ab-49c5-b9be-c03663b8613c"), 59, 64.11m, 1, 1, true },
                    { new Guid("624900d4-5063-46a8-86f6-11f121ec0580"), 58, 60.79m, 1, 1, true },
                    { new Guid("178f7a90-285c-456b-aeef-1ec30778b2ac"), 57, 57.63m, 1, 1, true },
                    { new Guid("cb22e8d4-21aa-4540-8951-2e62377e1c63"), 56, 54.62m, 1, 1, true },
                    { new Guid("f53f225c-c72c-462d-9200-b0c98d630895"), 55, 51.76m, 1, 1, true },
                    { new Guid("3b7bf2d9-c590-4614-ba18-35a907889e7e"), 54, 49.16m, 1, 1, true },
                    { new Guid("2a30fdff-aba4-4ded-ad07-ba1c2b0d4b4a"), 53, 46.58m, 1, 1, true },
                    { new Guid("d961d5bf-f751-4df7-aba4-c9f8c55595db"), 52, 43.99m, 1, 1, true },
                    { new Guid("01ffbaaf-7785-4dba-8f6d-eadd9c3ce9eb"), 51, 41.7m, 1, 1, true },
                    { new Guid("30666273-e3e8-43e8-b7da-ff331d725e20"), 50, 39.42m, 1, 1, true },
                    { new Guid("540d078c-a6d6-4b87-8b82-abc53005ac87"), 85, 248.49m, 1, 1, false },
                    { new Guid("bb43a98d-d34a-42a6-abee-f24056514b56"), 84, 241.02m, 1, 1, false },
                    { new Guid("7c73f58b-82f4-4397-b7bf-b80076a53e56"), 83, 227.63m, 1, 1, false },
                    { new Guid("06417c20-bcf4-4acf-acd0-c700414ee383"), 82, 213.21m, 1, 1, false },
                    { new Guid("8470e5d0-f10e-4c54-9f3f-89a834367d8d"), 81, 197.76m, 1, 1, false },
                    { new Guid("0c08c550-1e84-4441-a52a-9aeb4d0f68bc"), 80, 182.31m, 1, 1, false },
                    { new Guid("d9848270-b589-453c-97be-483f850484a2"), 79, 167.38m, 1, 1, false },
                    { new Guid("8a261aa9-bc0b-44f6-9f59-4ce59e3642b1"), 78, 154.5m, 1, 1, false },
                    { new Guid("e93d3de7-c4f3-4c43-a3b3-603b17ac4ade"), 83, 319.58m, 0, 2, false },
                    { new Guid("14daedaf-7313-443f-a35c-bc75565e7fd1"), 84, 347.84m, 0, 2, false },
                    { new Guid("052edeeb-0750-4d53-a4c6-a87524bcfc72"), 76, 271.5m, 0, 2, true },
                    { new Guid("89c7d4fc-f6cc-4bb0-b036-f95767ccf15f"), 50, 71.47m, 0, 2, true },
                    { new Guid("f7df13b0-42ba-47d0-9e01-fff72ea79a2d"), 56, 62.21m, 1, 2, true },
                    { new Guid("efcea329-9639-4d00-947b-94e3d813847e"), 55, 58.59m, 1, 2, true },
                    { new Guid("d98532b4-1e18-4546-9c5c-146582da4be0"), 54, 55.9m, 1, 2, true },
                    { new Guid("03aa9613-6c6c-42b8-b53e-7a26e0137335"), 53, 52.94m, 1, 2, true },
                    { new Guid("1b603527-631e-4773-8064-a7f9c406bd9d"), 52, 49.99m, 1, 2, true }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("1711b760-2563-48c4-a4b5-ef011cf9ba8a"), 51, 47.38m, 1, 2, true },
                    { new Guid("55747c54-f3e5-4b6c-8c43-a8df0a292670"), 50, 44.57m, 1, 2, true },
                    { new Guid("bfeb136f-1a54-4e3a-a86a-32cdcaf56d5f"), 85, 295.31m, 1, 2, false },
                    { new Guid("1fcfa841-9cb1-477b-b890-48a2642ff938"), 84, 270.85m, 1, 2, false },
                    { new Guid("3228d802-5519-4d9c-a0b4-dc2acc5ec876"), 83, 250.24m, 1, 2, false },
                    { new Guid("20172c38-5da1-4f8e-a5e3-aa2d44de9caa"), 82, 234.41m, 1, 2, false },
                    { new Guid("3f4932f3-385a-4ed4-902f-4ca8d7930e2d"), 81, 219.16m, 1, 2, false },
                    { new Guid("4dd5f131-5f73-41ec-9007-92d5ed7e60c6"), 80, 203.79m, 1, 2, false },
                    { new Guid("24c3f876-9a93-4b09-b6e1-492b7c9d3d60"), 79, 190.4m, 1, 2, false },
                    { new Guid("28e15fb1-69fe-4fdb-8223-c68bd0233912"), 78, 177.92m, 1, 2, false },
                    { new Guid("f3a39de8-ef34-4325-8b57-a0ae6e2ba6f1"), 77, 166.36m, 1, 2, false },
                    { new Guid("0ef5ffb3-840b-46a4-8ad0-bafdc74cc25a"), 76, 160.46m, 1, 2, false },
                    { new Guid("70364abd-117c-4853-8968-0a4db1eed489"), 75, 149.73m, 1, 2, false },
                    { new Guid("deeab724-aaf5-4485-8f6b-20862c1bce3b"), 74, 139.52m, 1, 2, false },
                    { new Guid("52551a6f-1a7e-4bfd-a9a1-50f355b48b66"), 73, 131.78m, 1, 2, false },
                    { new Guid("5a70167a-8eee-4612-9f75-30a34f378834"), 72, 123.58m, 1, 2, false },
                    { new Guid("893a0bed-144b-4ec8-abd7-2732c1597a0e"), 71, 115.89m, 1, 2, false },
                    { new Guid("87e5f1af-7aa7-43be-be87-3e3d6d5468c9"), 70, 109.08m, 1, 2, false },
                    { new Guid("b71de4d6-41d0-4316-811d-ae024e504e09"), 57, 66.01m, 1, 2, true },
                    { new Guid("7a42bdda-9569-4534-bd56-c52a5f58cb14"), 69, 106.56m, 1, 2, false },
                    { new Guid("47cc55b9-b93f-4191-974d-d5f0eda498fa"), 58, 69.69m, 1, 2, true },
                    { new Guid("a07831eb-5453-4647-91a2-7f0ec411cede"), 60, 77.08m, 1, 2, true },
                    { new Guid("869985c0-0d1d-4ce6-a9a2-2c8fafecb75f"), 83, 372.16m, 1, 2, true },
                    { new Guid("d31145a3-cfce-4863-90ed-61a6ca7771ad"), 82, 341.67m, 1, 2, true },
                    { new Guid("1404510b-c747-46b3-ae3c-790b3f1587cd"), 81, 312.71m, 1, 2, true },
                    { new Guid("7e4df043-080a-440d-8b77-511624cebb4c"), 80, 287.23m, 1, 2, true },
                    { new Guid("c3aad756-6074-469e-b4b9-fd7ddbdcabdc"), 79, 268.69m, 1, 2, true },
                    { new Guid("295fa1b9-cc98-4043-8b97-1d7e44f4a612"), 78, 248.83m, 1, 2, true },
                    { new Guid("8d0faca0-85f2-459c-94d4-15c501da418a"), 77, 229.32m, 1, 2, true },
                    { new Guid("a2772d98-bc65-4f24-90f3-cdd5fda4daa7"), 76, 219.34m, 1, 2, true },
                    { new Guid("230c9e57-5439-42ee-a6d5-0c701d374940"), 75, 199.91m, 1, 2, true },
                    { new Guid("bfa9ab74-20e2-4bce-ae79-0550c279c381"), 74, 184.95m, 1, 2, true },
                    { new Guid("dbe831c7-a852-4dc9-a8cd-cb76937d011b"), 73, 173.52m, 1, 2, true },
                    { new Guid("e26f468d-89c5-46be-8199-39138f9e2849"), 72, 162.31m, 1, 2, true },
                    { new Guid("77e39903-6bf4-482c-9507-9696032ff269"), 71, 152.54m, 1, 2, true },
                    { new Guid("372c288b-5d5b-4e80-aee8-5257754212b7"), 70, 143.89m, 1, 2, true },
                    { new Guid("f8da6f97-9088-412a-948e-b7ba2040d9a6"), 69, 139.72m, 1, 2, true },
                    { new Guid("325827f6-a229-4318-a1e7-d6489276ccaf"), 68, 130.3m, 1, 2, true },
                    { new Guid("a9ada14e-6c48-4b48-8ac5-1ce6f7a42feb"), 67, 122.74m, 1, 2, true },
                    { new Guid("bcb385b1-38d5-403d-afa3-471dfbab7dbe"), 66, 115.05m, 1, 2, true },
                    { new Guid("f7acba80-dc95-402f-bf97-f2569a4217a3"), 65, 107.5m, 1, 2, true },
                    { new Guid("194dd86b-7dad-4bdb-b84a-2e4e07533313"), 64, 101.03m, 1, 2, true }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("563dd4ec-584b-4ae3-b057-b61403a75149"), 63, 94.87m, 1, 2, true },
                    { new Guid("41049635-c21e-4807-bcb7-009dece5d977"), 62, 88.62m, 1, 2, true },
                    { new Guid("b09b1356-5b93-402c-a7d7-6731398622ba"), 61, 82.57m, 1, 2, true },
                    { new Guid("1edcd608-21a4-44a3-bf13-cfb6d18490a4"), 59, 73.86m, 1, 2, true },
                    { new Guid("a94d677d-6e8e-497f-8fbd-8828921dc2e1"), 68, 100.62m, 1, 2, false },
                    { new Guid("b3732f8e-05c6-469b-b830-b11cdf212c2a"), 67, 94.65m, 1, 2, false },
                    { new Guid("aa79e021-b946-4818-9c7c-24415eef8a11"), 66, 88.61m, 1, 2, false },
                    { new Guid("8e104a46-0637-40ca-80fc-1ddd8f2ae7c4"), 73, 225.91m, 0, 2, true },
                    { new Guid("3b8582a1-857c-400b-a95d-25025fd942d8"), 72, 212.92m, 0, 2, true },
                    { new Guid("df9cd425-02d8-46e3-81b4-38d5adf31f9a"), 71, 201.14m, 0, 2, true },
                    { new Guid("18175ec1-c0f3-4937-b5ca-cf82e33ad2d4"), 70, 190.71m, 0, 2, true },
                    { new Guid("aa502dce-e9aa-4d41-8a4a-56d44e006916"), 69, 185.9m, 0, 2, true },
                    { new Guid("592f9ad7-e6ae-4497-8da3-f5cc1e1a62e8"), 68, 175.74m, 0, 2, true },
                    { new Guid("e0581487-7b7b-4726-a4a7-cc62bc850196"), 67, 165.56m, 0, 2, true },
                    { new Guid("c11c02d6-b2b3-4353-aed6-1f28a7ad71c0"), 66, 155.29m, 0, 2, true },
                    { new Guid("6e2a1c7a-39ad-453f-94e3-8e49266ff94e"), 65, 146.59m, 0, 2, true },
                    { new Guid("0c064930-68f4-400c-b6ff-41f3f6d09749"), 64, 139.29m, 0, 2, true },
                    { new Guid("805fd185-b5fe-469a-a0dd-a7cd40492980"), 63, 132.96m, 0, 2, true },
                    { new Guid("318cf873-1d86-461e-a0c8-ffb87e7fbfdc"), 62, 125.76m, 0, 2, true },
                    { new Guid("2fc62f9d-4523-464e-8dd0-090b0f820def"), 61, 118.79m, 0, 2, true },
                    { new Guid("ea76f515-bb40-45eb-9f57-a9d9839cae4e"), 60, 112.46m, 0, 2, true },
                    { new Guid("87c92768-120a-4d7b-a8ed-08a2b9c5c18e"), 59, 109.25m, 0, 2, true },
                    { new Guid("acdbfcaa-3205-4b76-a173-44740948f5b8"), 58, 104.43m, 0, 2, true },
                    { new Guid("17a830a8-6d25-4cc8-86e2-dc5c04b0fd12"), 57, 99.83m, 0, 2, true },
                    { new Guid("07a92714-2a55-49d6-9fa6-8f81d41790b3"), 56, 95.45m, 0, 2, true },
                    { new Guid("35976916-7fe5-4e85-b2d6-a27753d800d5"), 55, 90.87m, 0, 2, true },
                    { new Guid("414dad91-1e3f-4670-a626-355dca6e7c32"), 54, 87.95m, 0, 2, true },
                    { new Guid("85e1265a-05e2-4470-afb1-128a01ba8a60"), 53, 83.74m, 0, 2, true },
                    { new Guid("3a18ac09-af1c-4fbf-a25c-c6a835ff20f3"), 52, 79.54m, 0, 2, true },
                    { new Guid("9abadbc2-db20-4194-9f44-1ab2ad46480b"), 51, 75.83m, 0, 2, true },
                    { new Guid("3814bbfe-40b9-4ec0-b220-4437632f2e04"), 74, 238.15m, 0, 2, true },
                    { new Guid("0f37267a-787b-4488-a311-52763a8feff8"), 75, 255.41m, 0, 2, true },
                    { new Guid("eb5cf299-05a5-4136-889b-427d748d493e"), 50, 31.6m, 1, 1, false },
                    { new Guid("0b62532f-213b-44d9-829a-ff6269f8fa26"), 77, 280.96m, 0, 2, true },
                    { new Guid("7aecb8f8-b3de-4c09-8d2c-de61cbe95a53"), 65, 82.69m, 1, 2, false },
                    { new Guid("0c1ac175-4f92-4ef0-8249-ef95e7c1d5cd"), 64, 78.29m, 1, 2, false },
                    { new Guid("4c03c597-b822-4498-bd30-966820318317"), 63, 74.12m, 1, 2, false },
                    { new Guid("53b9c6e9-84aa-4e0d-8250-10a1dfc1bbd2"), 62, 69.82m, 1, 2, false },
                    { new Guid("f2632403-2b21-48e7-9227-9edda53ec51b"), 61, 65.67m, 1, 2, false },
                    { new Guid("58500232-c8ec-4bee-9c0f-d3339ed43c0b"), 60, 61.89m, 1, 2, false },
                    { new Guid("f18f2560-7362-475d-a344-3dffee992973"), 59, 59.69m, 1, 2, false },
                    { new Guid("241ccaa5-0e52-4e2b-a425-8929dd54ea88"), 58, 56.83m, 1, 2, false }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("d8d8c7f4-159a-4b9d-a19a-320fdf0ba3f1"), 57, 54.09m, 1, 2, false },
                    { new Guid("f1729f37-dc7b-4624-b308-dadc0e2a54f0"), 56, 51.49m, 1, 2, false },
                    { new Guid("80eca8fc-55f3-4c7c-a890-922313f3a348"), 55, 49.03m, 1, 2, false },
                    { new Guid("0015cac4-cd35-461f-b9f4-85b0b8480637"), 85, 381.41m, 0, 2, false },
                    { new Guid("81004b13-27fc-4983-8f58-8299b75808ae"), 54, 46.89m, 1, 2, false },
                    { new Guid("3227026e-1948-4630-88d8-7fae706f769c"), 52, 42.21m, 1, 2, false },
                    { new Guid("f8b5051c-f11b-4407-ab87-7d44b0ce193a"), 51, 40.14m, 1, 2, false },
                    { new Guid("d2aaf754-7620-46d1-928f-84e999eaafee"), 50, 38.07m, 1, 2, false },
                    { new Guid("d2d0f333-3faf-4563-9725-14ef36bb3e76"), 85, 487.35m, 0, 2, true },
                    { new Guid("1e814b9f-f34c-46a6-961d-de5cc02f4d50"), 84, 448.15m, 0, 2, true },
                    { new Guid("2fbc9172-0372-4f35-805f-6deceb34cca8"), 83, 415.13m, 0, 2, true },
                    { new Guid("7a4ed42e-94aa-4dfe-83f2-52d0083abc77"), 82, 389.82m, 0, 2, true },
                    { new Guid("1d013907-1115-4dfb-af0e-654a7d13b644"), 81, 362.12m, 0, 2, true },
                    { new Guid("d79e811c-7b31-4732-b42d-664869b2a969"), 80, 337.76m, 0, 2, true },
                    { new Guid("f3746920-daf5-408d-a2d0-1d4779e001b6"), 79, 319.42m, 0, 2, true },
                    { new Guid("8a72e534-de02-4eb2-85eb-949c89e3b7b6"), 78, 299.45m, 0, 2, true },
                    { new Guid("85f724fb-3111-456d-b06a-a26eba2e04aa"), 53, 44.55m, 1, 2, false },
                    { new Guid("8f696775-60d8-445d-8dac-ed6aa53e5e04"), 85, 359.73m, 0, 1, true },
                    { new Guid("67e80f68-ffb7-494f-93fd-ef6575e5705d"), 58, 86.73m, 0, 1, true },
                    { new Guid("139da654-05c1-4a2a-8496-aefb1e608edb"), 83, 325.48m, 0, 1, true },
                    { new Guid("03d5d296-6b53-4ba0-95be-35a854f74c27"), 54, 33.74m, 1, 0, false },
                    { new Guid("849f1be5-19b6-400e-b70a-1b8d1f944cf6"), 53, 32.21m, 1, 0, false },
                    { new Guid("b49f2f90-8376-4e61-ba40-70743c5d7504"), 52, 30.58m, 1, 0, false },
                    { new Guid("28b850db-ff01-4961-97c3-625023900a28"), 51, 29.36m, 1, 0, false },
                    { new Guid("1d81176b-f158-40f0-8208-350288f8f70c"), 50, 27.3m, 1, 0, false },
                    { new Guid("12bf7801-0b0a-4b5b-ae6a-8035000171a1"), 85, 289.69m, 0, 0, true },
                    { new Guid("731288bf-0ca8-4010-8a0a-50f617c6ca76"), 84, 266.64m, 0, 0, true },
                    { new Guid("eb4a4fda-af4c-42dc-88fc-6a16ebf56508"), 83, 246.08m, 0, 0, true },
                    { new Guid("4f602bbb-258b-4b48-82cb-2f38065c3548"), 82, 229.56m, 0, 0, true },
                    { new Guid("2e5193a8-a8e9-4267-be28-5019647e890f"), 81, 216.3m, 0, 0, true },
                    { new Guid("361e3804-373c-41e1-81bf-cc601e0de207"), 80, 203.53m, 0, 0, true },
                    { new Guid("ce686cc3-2438-4ca4-a72a-8bde2d9901cf"), 79, 191.58m, 0, 0, true },
                    { new Guid("1a9af841-08ff-4909-b9f1-64ae8f22f5e5"), 78, 180.87m, 0, 0, true },
                    { new Guid("1d9cb195-7f0a-41fe-8461-79a1b1f88db0"), 77, 168.1m, 0, 0, true },
                    { new Guid("4a3b39af-93eb-4b35-8e41-05d58c05bb18"), 76, 157.59m, 0, 0, true },
                    { new Guid("c1705222-0f23-4be4-95b5-d52c7d2f15ed"), 75, 147.55m, 0, 0, true },
                    { new Guid("073740c6-6785-4bf7-bfcd-f257b67ede88"), 74, 137.51m, 0, 0, true },
                    { new Guid("9ea323bb-18bd-4e21-8ae4-f9f4e599fef3"), 73, 129.6m, 0, 0, true },
                    { new Guid("c32d4dc6-487a-49be-a4fe-4824f7eddde6"), 72, 121.93m, 0, 0, true },
                    { new Guid("063fe479-7e79-4aad-9c97-1413c230f5a9"), 71, 115.15m, 0, 0, true },
                    { new Guid("cb98b4b0-f4e1-4753-aa05-e8fc68b00280"), 70, 108.72m, 0, 0, true },
                    { new Guid("e59fa575-7164-469d-9ff3-33268a0a18e8"), 69, 104.55m, 0, 0, true }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("1fb94a54-d2ce-4e1e-b7fc-0522c4296372"), 68, 98.88m, 0, 0, true },
                    { new Guid("66bc3e09-8d1a-4859-823c-6c3acfc9519b"), 55, 35.28m, 1, 0, false },
                    { new Guid("5f473778-be09-4f05-8baf-319ce3773202"), 67, 93.22m, 0, 0, true },
                    { new Guid("f3e47a63-6765-49d6-84ff-36cdb87e7c0a"), 56, 36.42m, 1, 0, false },
                    { new Guid("4c7edb52-58a6-4ab7-a421-4e980d056b2b"), 58, 38.77m, 1, 0, false },
                    { new Guid("c8b73692-2a15-4e27-b47d-e039783096cc"), 81, 135.75m, 1, 0, false },
                    { new Guid("93072a95-85da-4ec4-bbd9-343f6ddd143d"), 80, 126.18m, 1, 0, false },
                    { new Guid("8e571649-508b-4f85-80ca-39863d174040"), 79, 116.6m, 1, 0, false },
                    { new Guid("bc4c51e2-90ca-406b-8772-4089a9da0d4f"), 78, 108.15m, 1, 0, false },
                    { new Guid("d3ebb384-1bb1-4f63-bb12-1374a0c8569c"), 77, 101.29m, 1, 0, false },
                    { new Guid("007f84e0-9d7e-4f12-a69c-932c257108cb"), 76, 95.83m, 1, 0, false },
                    { new Guid("ecea317e-0708-4b10-9a83-52a5ca932b96"), 75, 89.87m, 1, 0, false },
                    { new Guid("6c4d0b7d-416c-48ef-8bd2-11b702183e45"), 74, 83.69m, 1, 0, false },
                    { new Guid("c727f718-01df-42ac-930a-872142cb6463"), 73, 78.84m, 1, 0, false },
                    { new Guid("2c1cfcd8-299e-4d4f-8d47-af51642a46f1"), 72, 73.65m, 1, 0, false },
                    { new Guid("7d607193-3849-46b5-b773-cfa5732ece1d"), 71, 69.53m, 1, 0, false },
                    { new Guid("9f878615-a54c-49ff-86ea-b30a89301245"), 70, 65.61m, 1, 0, false },
                    { new Guid("e530743c-313a-4e8a-90f6-9a34666b83b4"), 69, 62.52m, 1, 0, false },
                    { new Guid("421bcea6-a662-4e44-83f5-59162c241bf9"), 68, 59.45m, 1, 0, false },
                    { new Guid("58d05ab7-f809-41de-89f3-fe55b6e825d9"), 67, 56.34m, 1, 0, false },
                    { new Guid("83e87e4a-f234-461a-b366-e48612d2fa80"), 66, 53.59m, 1, 0, false },
                    { new Guid("37ca6e0f-da0f-45ef-9b8d-0bc93e6f27a8"), 65, 50.47m, 1, 0, false },
                    { new Guid("e433196d-6463-48c0-9fd7-9500035fdf2b"), 64, 48.5m, 1, 0, false },
                    { new Guid("3f54d585-88e2-40c9-8d64-1d20aa73a7b7"), 63, 46.44m, 1, 0, false },
                    { new Guid("c0edf7fe-3a8a-411f-a000-da33e2ba7081"), 62, 44.5m, 1, 0, false },
                    { new Guid("eb98e7d6-07f8-420f-90f7-cd3e3eb43334"), 61, 42.85m, 1, 0, false },
                    { new Guid("55ad4e56-d195-4d0d-93f3-7734e4e0b9f7"), 60, 40.48m, 1, 0, false },
                    { new Guid("2ecf03d3-5ddc-47c9-8546-29ab83a15a91"), 59, 40.17m, 1, 0, false },
                    { new Guid("6010f9fb-19a6-4c48-9724-f4bb46fa5c03"), 57, 37.7m, 1, 0, false },
                    { new Guid("5fe3bb61-2d3c-4a3a-ac0f-c55b8fddf2d4"), 82, 146.26m, 1, 0, false },
                    { new Guid("77d5d297-3d57-486d-95fa-c08a95965bd8"), 66, 88.51m, 0, 0, true },
                    { new Guid("a32141d5-5ee9-4db1-993f-57e61e1beaf4"), 64, 79.64m, 0, 0, true },
                    { new Guid("65dc7d1e-1d94-4191-8eb4-3e2b4583f4f4"), 72, 97.83m, 0, 0, false },
                    { new Guid("cb86b3de-add0-4bc5-bee2-a101c5278f9c"), 71, 92.03m, 0, 0, false },
                    { new Guid("8b7162b2-07c2-4322-96b5-25dd935eb672"), 70, 86.53m, 0, 0, false },
                    { new Guid("0c1feb39-c276-4294-b915-e307a2128c62"), 69, 83.12m, 0, 0, false },
                    { new Guid("2774422d-c9c0-4d19-a5d9-196e5171c4f9"), 68, 78.7m, 0, 0, false },
                    { new Guid("0ec4dfc6-b88a-4a70-a5c4-147e3158cb8b"), 67, 73.78m, 0, 0, false },
                    { new Guid("82cd61bd-0f7d-472d-8543-af3d9485f440"), 66, 69.24m, 0, 0, false },
                    { new Guid("1cf53645-6f1c-4ab3-9230-c5b41b7e8922"), 65, 64.89m, 0, 0, false },
                    { new Guid("73dad368-c5ad-4df9-8834-013027198a57"), 64, 61.8m, 0, 0, false },
                    { new Guid("3ec13158-34b8-4b61-8dec-d48e0ee7e1eb"), 63, 58.71m, 0, 0, false }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("b64249c8-b40c-4e4b-9625-430c88b57460"), 62, 56.09m, 0, 0, false },
                    { new Guid("499e848c-491b-466a-b114-918c6e74dee8"), 61, 53.38m, 0, 0, false },
                    { new Guid("8d9a57fa-5927-4f8f-804d-3f081e45886f"), 60, 50.47m, 0, 0, false },
                    { new Guid("80fb11af-ffd4-4b48-b504-49cc457a8be8"), 59, 49.5m, 0, 0, false },
                    { new Guid("89deaef5-5aab-409f-acc4-56a8ced235a5"), 58, 47.64m, 0, 0, false },
                    { new Guid("c868a642-b95e-49ed-ab2e-2d8c6efbc546"), 57, 45.32m, 0, 0, false },
                    { new Guid("ee832250-5501-4fae-a506-e0b3b8754fcd"), 56, 44.18m, 0, 0, false },
                    { new Guid("04facfd2-097f-4922-ab53-58811c26878c"), 55, 42.49m, 0, 0, false },
                    { new Guid("267f02ce-e50c-4ad1-86e4-94056012a2fb"), 54, 40.94m, 0, 0, false },
                    { new Guid("5bc920b2-daaa-4b85-8e5e-831dfcc96208"), 53, 39.14m, 0, 0, false },
                    { new Guid("5730bf6b-ff9e-47a1-a0bf-76629d318db1"), 52, 36.67m, 0, 0, false },
                    { new Guid("b8338faf-c896-42d7-8457-a30f98162f57"), 51, 34.9m, 0, 0, false },
                    { new Guid("8f43de65-5c39-47e6-bffe-e9340da4b36f"), 50, 32.96m, 0, 0, false },
                    { new Guid("ddd51610-b96e-4130-ab2c-9a3c40982b07"), 73, 104.4m, 0, 0, false },
                    { new Guid("55d6eaa3-25c0-4862-846d-64fd73a63205"), 65, 83.43m, 0, 0, true },
                    { new Guid("5f5b491a-7a54-40b0-ba6b-9fe4ceb63da0"), 74, 111.76m, 0, 0, false },
                    { new Guid("c44feb13-7ba3-4ad2-a6fe-382f2944bc09"), 76, 128.75m, 0, 0, false },
                    { new Guid("8ccc691f-21d9-46b1-80a6-335f8e7c8992"), 63, 76.01m, 0, 0, true },
                    { new Guid("c36a19b4-c595-4208-a26d-03e1da8566a7"), 62, 73.13m, 0, 0, true },
                    { new Guid("a5de4881-72b6-4558-b9bf-8cc382b37a13"), 61, 70.04m, 0, 0, true },
                    { new Guid("a8a4b2ee-71f2-468b-b33a-216b0b6d6f0e"), 60, 65.82m, 0, 0, true },
                    { new Guid("39e5380c-291f-469c-ba5b-2e3ed08e4d6b"), 59, 63.35m, 0, 0, true },
                    { new Guid("d1854491-91af-4b7b-84fc-46e94cd1e1a5"), 58, 61.08m, 0, 0, true },
                    { new Guid("66acbdc4-123c-4d80-b21c-09133cb7bb83"), 57, 58.29m, 0, 0, true },
                    { new Guid("254d75da-3417-424a-9f74-93b69785bfe9"), 56, 56.05m, 0, 0, true },
                    { new Guid("2f251c49-0669-46cf-88a3-47c38bd60797"), 55, 53.82m, 0, 0, true },
                    { new Guid("907be840-492c-404c-83ad-a97a3a3d011f"), 54, 51.61m, 0, 0, true },
                    { new Guid("b049aa10-dbb0-4507-8bf0-e63824959a3c"), 53, 49.42m, 0, 0, true },
                    { new Guid("c352af93-1d97-4db8-ae29-bfd1ad9acefb"), 52, 47.09m, 0, 0, true },
                    { new Guid("b401482b-3a9e-407f-8eb3-8d1f41e724a7"), 51, 45.03m, 0, 0, true },
                    { new Guid("f5c5e153-3e33-4588-9b5d-1c4934e992a6"), 50, 43.12m, 0, 0, true },
                    { new Guid("89b5ef11-b6e1-4238-bd76-419af98d40fc"), 85, 248.49m, 0, 0, false },
                    { new Guid("5fd3438a-677c-4341-8488-f5cfc22311c9"), 84, 232.78m, 0, 0, false },
                    { new Guid("c3289c43-4286-4a42-bf44-ffe0098d1495"), 83, 217.02m, 0, 0, false },
                    { new Guid("e285473d-1a88-4fe1-8eca-4283c4c8c38f"), 82, 202.91m, 0, 0, false },
                    { new Guid("0d44f7b2-896c-4610-9cd6-95f5f37e2f91"), 81, 187.87m, 0, 0, false },
                    { new Guid("fac6f210-ce0f-4ebd-b943-cac2fec15c90"), 80, 174.07m, 0, 0, false },
                    { new Guid("7e890687-e1ad-472b-886a-b66ca39d852b"), 79, 161.92m, 0, 0, false },
                    { new Guid("6f3f2c56-46db-495f-8830-b1027ad0d5bd"), 78, 150.28m, 0, 0, false },
                    { new Guid("64722a96-70d4-428a-906d-4092f2a9dcf1"), 77, 138.02m, 0, 0, false },
                    { new Guid("f56828d1-e4bb-4858-9add-5dd8bcb9f75a"), 75, 119.74m, 0, 0, false },
                    { new Guid("f05fc1b9-87e7-4506-b309-b66bf2740097"), 83, 158.11m, 1, 0, false }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("6f28d0fb-2abe-49c7-bdb0-c657a0265bcc"), 84, 170.98m, 1, 0, false },
                    { new Guid("e1518958-da57-48f6-a197-4c4721f31142"), 85, 185.66m, 1, 0, false },
                    { new Guid("8447e48c-5942-4938-ab79-ec51e4ebabf8"), 55, 76.99m, 0, 1, true },
                    { new Guid("76d2e7d0-ccf9-4634-b829-54907a1a598a"), 54, 73.54m, 0, 1, true },
                    { new Guid("58b3ff0d-2595-403c-ba51-462b4085bdd6"), 53, 70.09m, 0, 1, true },
                    { new Guid("34a63740-03b7-465b-9fb7-a94a523457f3"), 52, 66.64m, 0, 1, true },
                    { new Guid("272189f2-a219-4be8-81bb-2a395d0c24fe"), 51, 63.59m, 0, 1, true },
                    { new Guid("1b1da746-1aed-4b93-bad2-b53b8580b72f"), 50, 60.54m, 0, 1, true },
                    { new Guid("914909f8-1625-43e0-8163-9bbc33245b2b"), 85, 312.35m, 0, 1, false },
                    { new Guid("270b3bab-3a49-4b47-8516-affa71842e57"), 84, 307.97m, 0, 1, false },
                    { new Guid("0acd046e-7582-4790-acee-1347f72848d8"), 83, 296.64m, 0, 1, false },
                    { new Guid("31d5f0ed-cc3d-45a8-ab7a-ff8e7e3fe8e7"), 82, 283.87m, 0, 1, false },
                    { new Guid("0cbf4435-3acc-4935-bf24-775f6d5fd8fc"), 81, 269.86m, 0, 1, false },
                    { new Guid("4ee29921-c2cd-4f76-adc3-3808e9268529"), 80, 254.2m, 0, 1, false },
                    { new Guid("5ae6cbba-ce2a-41c3-99aa-6e3f5f92f316"), 79, 234.33m, 0, 1, false },
                    { new Guid("4d64baad-bf81-448a-b777-57066b9c3368"), 78, 215.27m, 0, 1, false },
                    { new Guid("8323a7f7-3b93-45d2-86fb-0f6eb3500223"), 77, 196.73m, 0, 1, false },
                    { new Guid("a146a345-ed97-47f6-980a-d2f3f92bf319"), 76, 179.53m, 0, 1, false },
                    { new Guid("55e94e5e-1a10-42d5-a37e-9820d69f49d8"), 75, 166.09m, 0, 1, false },
                    { new Guid("6bb04b4e-4d40-459d-bd9a-c02ee947af31"), 74, 155.02m, 0, 1, false },
                    { new Guid("609be677-8796-40d7-8014-a8aa3e1cf1b4"), 73, 144.2m, 0, 1, false },
                    { new Guid("9a7b1aec-d786-4a35-b74c-97e1a352b9b0"), 72, 133.9m, 0, 1, false },
                    { new Guid("ef7c83ce-c366-4baf-877b-dd8c082dd756"), 71, 123.89m, 0, 1, false },
                    { new Guid("89a26197-427a-4676-b4a2-70a957deb63d"), 70, 116.03m, 0, 1, false },
                    { new Guid("066ced1b-eaff-4519-9bed-c21910afc5f4"), 69, 112.25m, 0, 1, false },
                    { new Guid("8e7ea84d-256f-42d3-9a8b-abaab1be8e86"), 56, 80.07m, 0, 1, true },
                    { new Guid("3d9c6875-5930-48d1-967b-9b7a9d255969"), 68, 104.25m, 0, 1, false },
                    { new Guid("9fec37bc-4806-418b-8f64-ab3b971760f0"), 57, 83.32m, 0, 1, true },
                    { new Guid("00fce981-0e8e-4ca4-8f0d-d6df5646fe66"), 59, 90.3m, 0, 1, true },
                    { new Guid("58a8fbd8-c3d5-4d63-81dc-ef013c5b59b6"), 82, 320.54m, 0, 1, true },
                    { new Guid("9f1f3c3d-15e0-42e7-afd9-20e3d951822e"), 81, 316.15m, 0, 1, true },
                    { new Guid("7e9051df-7a30-4e82-a4c5-0fd7a3ef93ce"), 80, 313.12m, 0, 1, true },
                    { new Guid("58654298-6623-48c1-8a92-224b27b60e68"), 79, 295.71m, 0, 1, true },
                    { new Guid("c35db554-57d8-454b-bb1d-543949dbf7df"), 78, 274.12m, 0, 1, true },
                    { new Guid("a2396ee5-1375-45c2-8bda-9adb90035c7a"), 77, 255.76m, 0, 1, true },
                    { new Guid("5808ab76-77d0-48ea-b7d3-de86a9b53e91"), 76, 237.11m, 0, 1, true },
                    { new Guid("2c762f6f-14ca-445f-8246-953441d7dd54"), 75, 217.59m, 0, 1, true },
                    { new Guid("8f6bbe16-8b2c-4da3-aba0-7b0b2c56dd89"), 74, 204.35m, 0, 1, true },
                    { new Guid("c7e209a0-2c98-44a1-bca7-ade6f487fe0a"), 73, 190.28m, 0, 1, true },
                    { new Guid("763e8c10-d156-42d2-b9b3-ab5bbb06d5f6"), 72, 178.25m, 0, 1, true },
                    { new Guid("53cf19b9-3952-4e35-8d10-5927aaf228dc"), 71, 167.77m, 0, 1, true },
                    { new Guid("8ce94916-4451-4eb6-8b6e-13bda5100e0d"), 70, 158.49m, 0, 1, true }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("f443e620-48e9-4182-9e4b-3ac5f0d74a72"), 69, 154.02m, 0, 1, true },
                    { new Guid("b838d6c3-d390-4a25-9458-d97dbedcbbdf"), 68, 144.57m, 0, 1, true },
                    { new Guid("40927378-b120-45da-b93c-39173f410e58"), 67, 135.81m, 0, 1, true },
                    { new Guid("f9e83935-604b-4456-9413-b689a0e88eca"), 66, 127.56m, 0, 1, true },
                    { new Guid("87d8a3c7-4ac4-4b35-9057-10fbedae0190"), 65, 120m, 0, 1, true },
                    { new Guid("8dc26008-a543-44c5-bd82-b8bfbcb771fd"), 64, 113.99m, 0, 1, true },
                    { new Guid("a92dc8c6-747f-4699-a276-5817bb49346a"), 63, 108.31m, 0, 1, true },
                    { new Guid("4931439a-3d39-4717-807a-34cf20ab372f"), 62, 102.96m, 0, 1, true },
                    { new Guid("735b9d87-2c08-4b04-b49b-28ebf30361c0"), 61, 97.77m, 0, 1, true },
                    { new Guid("1a7928e5-7d22-421c-a569-fdb60f904a2d"), 60, 93.06m, 0, 1, true },
                    { new Guid("d894b042-34e0-4eb3-ae49-14e9c4ef4333"), 84, 406.99m, 1, 2, true },
                    { new Guid("896eaf12-6236-47a2-bf84-91fe76385b79"), 67, 96.82m, 0, 1, false },
                    { new Guid("aff87a7b-6466-48e6-bee7-8bcffc6775c4"), 66, 89.84m, 0, 1, false },
                    { new Guid("35d3b866-ac85-4c25-bbbc-bdad9375c52a"), 65, 83.43m, 0, 1, false },
                    { new Guid("3d74f90c-7089-4d59-a639-2b9599d6c6e7"), 72, 87.61m, 1, 0, true },
                    { new Guid("a1af41d8-4e1e-4536-b10a-d1a9cbbd99d0"), 71, 83.2m, 1, 0, true },
                    { new Guid("b092e53f-9e90-49f5-a686-d9636feea9b9"), 70, 79.02m, 1, 0, true },
                    { new Guid("5f97a648-2d88-4ce7-8a00-1bb762f41a27"), 69, 77.12m, 1, 0, true },
                    { new Guid("25fb90d3-083f-4b28-8b02-a11debf5fb5e"), 68, 72.1m, 1, 0, true },
                    { new Guid("a66bbf89-4fc7-425a-8416-ab666f64b9a3"), 67, 69.33m, 1, 0, true },
                    { new Guid("9a15992e-7c7c-48f8-805c-25aca1276d10"), 66, 65.88m, 1, 0, true },
                    { new Guid("a002a7dc-2369-4885-9799-a6507882186e"), 65, 62.57m, 1, 0, true },
                    { new Guid("56e541f8-5847-4052-9787-82f4a26e9707"), 64, 59.78m, 1, 0, true },
                    { new Guid("5609a5bf-2c4a-474e-b7d3-a76b48c10b1a"), 63, 56.85m, 1, 0, true },
                    { new Guid("73f94bcb-2d8c-4bbf-9937-6ad4fc44eb2b"), 62, 54.08m, 1, 0, true },
                    { new Guid("cc536d9c-aff0-48f2-b100-69180fdd66ee"), 61, 51.46m, 1, 0, true },
                    { new Guid("e296900e-400c-4684-b814-23ed09efcc78"), 60, 49.01m, 1, 0, true },
                    { new Guid("d8e48b3b-12d4-478a-ada2-0edb967ed951"), 59, 47.7m, 1, 0, true },
                    { new Guid("bca41367-cba1-407f-865c-499d1294301f"), 58, 45.91m, 1, 0, true },
                    { new Guid("12178f72-256a-452f-9134-288dad43d1e8"), 57, 44.2m, 1, 0, true },
                    { new Guid("6d5ad17c-f1a5-4f2c-a22a-834eec39c91f"), 56, 42.23m, 1, 0, true },
                    { new Guid("4ebd673f-fe9b-47d6-936f-01fee4691bb5"), 55, 40.94m, 1, 0, true },
                    { new Guid("b8d72061-1844-4346-88d5-da7cf7babfd2"), 54, 38.73m, 1, 0, true },
                    { new Guid("b9de4b3c-a7ce-4baa-b4fd-c185bf1b0740"), 53, 37.29m, 1, 0, true },
                    { new Guid("8f1af09f-5422-45d2-8ef6-68b46944bfcc"), 52, 35.34m, 1, 0, true },
                    { new Guid("ba86f3e9-d700-4675-8f4b-bce55543a374"), 51, 33.62m, 1, 0, true },
                    { new Guid("c3cd3278-04d5-4c7d-aa37-fc4e1ff0a075"), 50, 32.55m, 1, 0, true },
                    { new Guid("c323782b-8c29-481e-874c-ab1327622365"), 73, 92.61m, 1, 0, true },
                    { new Guid("f3df80d9-be95-4b12-8f06-5cf417d55853"), 74, 97.75m, 1, 0, true },
                    { new Guid("5efd0564-62c0-4397-83e5-a3d684df2769"), 75, 104.29m, 1, 0, true },
                    { new Guid("4228257a-3a9d-49e0-9af9-2a0827d657dc"), 76, 112.49m, 1, 0, true },
                    { new Guid("80758756-88ce-481b-9984-6272e0bf5ba9"), 64, 79.08m, 0, 1, false }
                });

            migrationBuilder.InsertData(
                table: "CarrierPlanRate",
                columns: new[] { "CarrierPlanRateId", "Age", "AnnualRate", "Gender", "PremiumType", "Tobacoo" },
                values: new object[,]
                {
                    { new Guid("bd702105-0098-412f-94ae-4aaab63a7615"), 63, 74.96m, 0, 1, false },
                    { new Guid("0f4eea52-8dd8-4f9b-9e8e-99ec25637d71"), 62, 71.08m, 0, 1, false },
                    { new Guid("2236b3c0-f24e-4f03-a727-d5932ac0e9bb"), 61, 67.32m, 0, 1, false },
                    { new Guid("4e36b36e-cd70-48c1-a891-79df58d245b5"), 60, 63.91m, 0, 1, false },
                    { new Guid("ec85f49a-34b8-4a67-9f07-58c156c5d26f"), 59, 61.91m, 0, 1, false },
                    { new Guid("27f681bd-fa0a-43a7-9f92-616dfb73f411"), 58, 59.33m, 0, 1, false },
                    { new Guid("1c1abe68-57dd-4c5f-92d4-a85afd46c782"), 57, 56.86m, 0, 1, false },
                    { new Guid("04ac845f-de90-465a-940c-3046e6ec84af"), 56, 54.51m, 0, 1, false },
                    { new Guid("c0cb3ea4-6e5e-4acf-895a-6440aa547cbe"), 55, 52.27m, 0, 1, false },
                    { new Guid("2f849df8-4313-4b75-926a-f2cbb984cff7"), 54, 49.72m, 0, 1, false },
                    { new Guid("c4b30fb5-4eea-468b-999f-942e068bb886"), 84, 336.06m, 0, 1, true },
                    { new Guid("fa2b5219-0a67-49a7-a926-22061b0448e6"), 53, 47.16m, 0, 1, false },
                    { new Guid("78372b58-2946-4d3b-a339-d683959b3ffa"), 51, 42.35m, 0, 1, false },
                    { new Guid("c1e43b35-b950-4840-969f-89afe74cd1de"), 50, 40.1m, 0, 1, false },
                    { new Guid("c48f06a7-9b6a-4473-a5cb-fbc5dddb194d"), 85, 236.13m, 1, 0, true },
                    { new Guid("b6fb81ad-da36-4fc6-be10-a70915fd2ef5"), 84, 214.76m, 1, 0, true },
                    { new Guid("5d6a8bfb-0ca2-4567-b7df-d6472f460c8a"), 83, 195.69m, 1, 0, true },
                    { new Guid("328b3f3f-cbbc-428d-9e7b-8300e11168ad"), 82, 179.51m, 1, 0, true },
                    { new Guid("b502b7b3-d715-45bb-ac2f-d21b572217bf"), 81, 164.14m, 1, 0, true },
                    { new Guid("3db4c6b5-f3f2-4cb3-9297-47bd14542d5f"), 80, 150.62m, 1, 0, true },
                    { new Guid("9ac74e4f-e4ab-4672-bee9-22bfa5cba1ee"), 79, 139.06m, 1, 0, true },
                    { new Guid("d127aaa9-76e5-4547-943d-e186373bb8c9"), 78, 127.85m, 1, 0, true },
                    { new Guid("4226f625-d51e-419c-bac4-6506d8be22ef"), 77, 120m, 1, 0, true },
                    { new Guid("da519860-4f45-47db-8efd-13cf4767f6c3"), 52, 44.61m, 0, 1, false },
                    { new Guid("0d8c152d-9006-4ee1-9dd1-35dad58f0a54"), 85, 448.38m, 1, 2, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmAmApplicationAnswers_AAFinalExpenseId",
                table: "AmAmApplicationAnswers",
                column: "AAFinalExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_AmAmApplicationAnswers_QuestionAmAmApplicationQuestionsId",
                table: "AmAmApplicationAnswers",
                column: "QuestionAmAmApplicationQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AmAmFinalExpense_ApplicationId",
                table: "AmAmFinalExpense",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AmStateLookup_AmAmApplicationQuestionsId",
                table: "AmStateLookup",
                column: "AmAmApplicationQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AmStateLookup_AmStateId",
                table: "AmStateLookup",
                column: "AmStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationInfoId",
                table: "Application",
                column: "ApplicationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_LeadInfoLeadId",
                table: "Application",
                column: "LeadInfoLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_PaymentInfoPaymentId",
                table: "Application",
                column: "PaymentInfoPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrierPlan_BenefitAmountCarrierPlanBenefitId",
                table: "CarrierPlan",
                column: "BenefitAmountCarrierPlanBenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrierPlan_PlanDetailsCarrierPlanDetailsId",
                table: "CarrierPlan",
                column: "PlanDetailsCarrierPlanDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrierPlanDetails_rateCarrierPlanRateId",
                table: "CarrierPlanDetails",
                column: "rateCarrierPlanRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_FamilyMemberId",
                table: "Doctors",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_FamilyMemeberFamilyMemberId",
                table: "Drugs",
                column: "FamilyMemeberFamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyOrBeneficiary_ApplicationId",
                table: "FamilyOrBeneficiary",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyOrBeneficiary_PersonalInfoFamilyMemberId",
                table: "FamilyOrBeneficiary",
                column: "PersonalInfoFamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthQuestion_ApplicationId",
                table: "HealthQuestion",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_FamilyMemeberFamilyMemberId",
                table: "Pharmacy",
                column: "FamilyMemeberFamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_BenefitAmountPlanBenefitId",
                table: "Plan",
                column: "BenefitAmountPlanBenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_PlanDetailsId",
                table: "Plan",
                column: "PlanDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanQuote_BenefitLevelPlanBenefitId",
                table: "PlanQuote",
                column: "BenefitLevelPlanBenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanQuote_QuoteId",
                table: "PlanQuote",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ApplicationId",
                table: "Quote",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmAmApplicationAnswers");

            migrationBuilder.DropTable(
                name: "AmStateLookup");

            migrationBuilder.DropTable(
                name: "CarrierDrug");

            migrationBuilder.DropTable(
                name: "CarrierPlan");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "FamilyOrBeneficiary");

            migrationBuilder.DropTable(
                name: "HealthQuestion");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "PlanQuote");

            migrationBuilder.DropTable(
                name: "AmAmFinalExpense");

            migrationBuilder.DropTable(
                name: "AmAmApplicationQuestions");

            migrationBuilder.DropTable(
                name: "AmState");

            migrationBuilder.DropTable(
                name: "CarrierPlanBenefit");

            migrationBuilder.DropTable(
                name: "CarrierPlanDetails");

            migrationBuilder.DropTable(
                name: "FamilyMember");

            migrationBuilder.DropTable(
                name: "PlanDetails");

            migrationBuilder.DropTable(
                name: "PlanBenefit");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "CarrierPlanRate");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "ApplicationInfo");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "PaymentInfo");
        }
    }
}
