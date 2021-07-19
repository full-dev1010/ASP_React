using ForSureLife.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo
{
    public class Doctor
    {
        public FamilyMember FamilyMember { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public States DoctorState { get; set; }
        public string DoctorCity { get; set; }
        public string DoctorPhone { get; set; }
    }
}