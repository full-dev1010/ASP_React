using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
    public class ApplicationHealthQuestionDto
    {
        public Guid HealthQuestionId { get; set; }
        public ApplicationHealthQuestions ApplicationQuestion { get; set; }
        public string HealthQuestionName { get; set; }
        public bool HealthAnswer { get; set; }
        public Occurence Occurence { get; set; }
    }
}
