using ForSureLife.Models.Enums;
using System;

namespace ForSureLife.Models.DTO
{
    public class BeneficiaryDto
    {
        public Guid BeneficiaryId { get; set; }
		public Relationship PrimaryRelationship { get; set; }
        public FamilyMemberDto PersonalInfo { get; set; }
        public string Relationship { get; set; }
        public int Percentage { get; set; }
    }
}