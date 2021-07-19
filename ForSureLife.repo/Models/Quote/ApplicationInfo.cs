using ForSureLife.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo
{
    public class ApplicationInfo
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid ApplicationInfoId { get; set; }
		public DateTime DOB { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string SSN { get; set; }
		public bool SeparateOwner { get; set; }
		public bool LifePolicy { get; set; }
		public string LifePolicyInsuranceCompany { get; set; }
		public string LifePolicyNumber { get; set; }
		public decimal LifeCoverageAmount { get; set; }
		public int? HeightFt { get; set; }
		public int? HeightIn { get; set; }
		public decimal Weight { get; set; }
		public string BirthState { get; set; }
		public string StateOfBirth { get; set; }
		public string DoctorName { get; set; }
		public States DoctorState { get; set; }
		public string DoctorCity { get; set; }
		public string DoctorPhone { get; set; }
		public bool AcceptAnyPlan { get; set; }
	}
}