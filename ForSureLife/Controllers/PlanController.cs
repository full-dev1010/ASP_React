using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForSureLife.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/Quote/plan")]
    [ApiController]
    public class PlanController : BaseController
    {

    }
}
