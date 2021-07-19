using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ForSureLife.repo
{
    public class Drug
    {
        public FamilyMember FamilyMemeber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid DrugId { get; set; }
        public string DrugName { get; set; }
        public string Reason { get; set; }
        public int RXFrequency { get; set; }
    }
}