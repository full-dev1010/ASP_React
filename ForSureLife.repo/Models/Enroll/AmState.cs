using ForSureLife.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo.Models.Enroll
{
    public class AmState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid AmStateId { get; set; }
        public States StateIdEnum { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public string LicenseNumber { get; set; }
    }
}