using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForSureLife.Models.DTO
{
    public class DemographicDto
    {
        public Guid DemographicDtoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string County { get; set; }

    }
}
