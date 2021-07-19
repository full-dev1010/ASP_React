using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
    public class DesigneeDto
    {
        public Guid DesigneeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
        public bool Signed { get; set; }
    }
}
