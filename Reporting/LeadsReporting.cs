using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Reporting
{
    public class LeadsReporting
    {
       // private ILeadRepository _leadRepo { get; set; }
        private ILogger _logger;

        //public LeadsReporting(ILeadRepository leadRepo)
        //{
        //    _leadRepo = leadRepo;
        //}

        [FunctionName("LeadsReporting")]
        public void Run(
               [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger logger)
        //[TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            var test = 1;
         //   _leadRepo.SendSalesToGoogleSheet();




        }

        [FunctionName("ManualLeadReporting")]
        public IActionResult SaveTransationId(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger logger)
        {
            var test = 1;
           // _leadRepo.SendSalesToGoogleSheet();
            return new OkResult();
        }
    }
}
