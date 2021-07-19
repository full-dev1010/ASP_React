using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo
{
    public class FamilyOrBeneficiary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid FamilyOrBeneficiaryId { get; set; }
        public FamilyMember PersonalInfo { get; set; } 
        public Relationship PrimaryRelationship { get; set; }
        public string Relationships { get; set; } 
        public int Percentage { get; set; }

    }
}