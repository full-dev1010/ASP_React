using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ForSureLife.repo.Models.Enroll
{
    public class AmAmApplicationAnswers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid AmAmApplicationAnswersId { get; set; }
        public AmAmApplicationQuestions Question { get; set; }
        public bool Answer { get; set; }
    }
}
