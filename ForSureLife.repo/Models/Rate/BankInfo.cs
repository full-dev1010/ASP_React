using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.repo.Models.Quote
{
    public class BankInfo
    {
        public Guid BankInfoId { get; set; }
        public string RoutingNumber { get; set; }
        public string BankName { get; set; }
        public string Address1 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
