using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
    public class LeadSaleDto
    {
        public Guid LeadId { get; set; }
        public string ApiKey { get; set; }
        
    }


    public class BulkLeadSaleDto
    {
        public List<Guid> LeadId { get; set; }
        public string ApiKey { get; set; }

    }
}
