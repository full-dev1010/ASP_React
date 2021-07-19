using System.ComponentModel;

namespace ForSureLife.Models.Enums
{
    public enum LeadHealthQuestions
    {
        [Description("")]
        NotAvailable=0, //
        TobaccoUse = 1, //
        ChronicIllness = 2, //
        HospiceCare = 3, //
        SelfReliant = 4, //
        OtherDisease = 5,
        Cancer = 6, //
        MultipleCancer = 7,
        Oxygen = 8,//
        OrganDialysisDisease = 9,//
        LivePast12Months = 10,
        Hospitilized = 11
    }
}
