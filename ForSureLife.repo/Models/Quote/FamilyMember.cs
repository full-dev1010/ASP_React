using ForSureLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo
{
    public class FamilyMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid FamilyMemberId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string State { get; set; }
        public string StateOfBirth { get; set; }
        public string SSN { get; set; }
        public int HeightFt { get; set; }
        public int HeightIn { get; set; }
        public decimal Weight { get; set; } 
        public Gender Gender { get; set; }

    }
}