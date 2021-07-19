using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.Models.DTO
{
   public class LoginModelDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid applicationId { get; set; }
    }
}
