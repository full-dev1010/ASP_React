using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForSureLife.Models.DTO
{
    public class LeadHealthQuestionsDto
	{
		public Guid LeadHealthQuestionID { get; set; }
		public List<LeadHealthQuestionDto> HealthQuestions { get; set; }

    }
}
