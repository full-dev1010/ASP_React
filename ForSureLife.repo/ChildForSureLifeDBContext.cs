using ForSureLife.Models.Enums;
using ForSureLife.repo.Models.Enroll;
using ForSureLife.repo.Models.Quote;
using ForSureLife.repo.Models.Rate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.repo
{
    public class ChildForSureLifeDBContext : ForSureLifeDBContext 
    {
        public ChildForSureLifeDBContext()
        {

        }

        public ChildForSureLifeDBContext(DbContextOptions<ForSureLifeDBContext> options) : base(options)
        {
        }

    }
}
