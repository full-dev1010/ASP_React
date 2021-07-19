using ForSureLife.Models.Enums;

namespace ForSureLife.Models.DTO
{
    public class RateDto
    {
        public bool SelectedCoverage { get; set; }
        public decimal BenefitCoverage { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal AnnualRate { get; set; }
    }
}