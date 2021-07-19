using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
   public class ResumeDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class ResumeApplicationDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid ApplicationId { get; set; }
    }

    public class ResumeChallengeDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ChallengeCode { get; set; }
    }
}
