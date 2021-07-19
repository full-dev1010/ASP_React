using ForSureLife.Models.Enums;
using System;

namespace ForSureLife.Models.DTO
{
    public class SeparatePolicyOwner
	{
        	public Guid SeparatePolicyOwnerId { get; set; }
			public Guid BeneficiaryId { get; set; }
			public string FirstName { get; set; }
			public string MiddleName { get; set; }
			public string LastName { get; set; }
			public string Relationship { get; set; }
			public string Address1 { get; set; }
			public string Address2 { get; set; }
			public string City { get; set; }
			public string State { get; set; }
			public string SSN { get; set; }
			public Relationship PolicyOwnerRelationship { get; set; }
	}
}