using ForSureLife.Models.Enums;
using System;

namespace ForSureLife.Models.DTO
{
    public class LeadHealthQuestionDto
    {
        public Guid HealthQuestionId { get; set; }
        public LeadHealthQuestions LeadHealthQuestion { get; set; }
        public string HealthQuestionName { get; set; }
        public bool HealthAnswer { get; set; }
        public Occurence Occurence { get; set; }
    }
}