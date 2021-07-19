using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo.Models.Enroll
{
    public class AmAmApplicationQuestions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid AmAmApplicationQuestionsId { get; set; }
        public AmAmApplicationQuestion QuestionName { get; set; }
        public ApplicationSection ApplicationSection {get; set; }
        public List<AmStateLookup> States { get; set; }


    }
}