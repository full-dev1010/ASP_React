using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
    public class ApplicationDto
    {
        public Guid? ApplicationId { get; set; }
        public LeadDTO LeadInfo { get; set; }
        public List<ApplicationHealthQuestionDto> HealthQuestions { get; set; }
        public ApplicationInfoDto ApplicationInfo { get; set; }
        public List<BeneficiaryDto> Beneficiaries { get; set; }
        public List<BeneficiaryDto> ContingentBeneficiaries { get; set; }
        public DesigneeDto Designee { get; set; }
        public PaymentInfoDto PaymentInfo { get; set; }
        public bool? Signed { get; set; }
        public DateTime? SignedDate { get; set; }
        public string OmniSendContactId {get; set;}
    }
}
