using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
    public class BeneficiariesDto
    {
        public Guid BeneficiariesId { get; set; }
        public List<BeneficiaryDto> Beneficiaries { get; set; } 
    }
}
