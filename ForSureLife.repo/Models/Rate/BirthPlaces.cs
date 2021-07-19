using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForSureLife.repo.Models.Rate
{
    public class BirthPlaces
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid BirthPlacesId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
