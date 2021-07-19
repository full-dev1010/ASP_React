using ForSureLife.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo.Models.Quote
{
    public class HealthQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid HealthQuestionId { get; set; }
        public LeadHealthQuestions LeadHealthQuestion { get; set; }
        public ApplicationHealthQuestions ApplicationQuestion { get; set; }
        public string HealthQuestionName { get; set; }
        public bool HealthAnswer { get; set; }
        public Occurence Occurence { get; set; }
    }
}