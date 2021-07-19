using System;
using ForSureLife.repo;
using ForSureLife.repo._3rdPartyIntegrations;
using ForSureLife.repo.Interfaces;
using ForSureLife.ReportFunctions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ForSureLife.TimerTrigger
{
    public class TimerTriggerCSharp1
    {
        private IAmAmApplicationRepository _amAmRepo { get; set; }
        private IOmniSendAPI _omniSendApi {get; set;}
        private readonly ForSureLifeDBContext ctx;
        public TimerTriggerCSharp1(IAmAmApplicationRepository amAmRepo, IOmniSendAPI omnisend, ForSureLifeDBContext _ctx)
        {
            _amAmRepo = amAmRepo;
            ctx = _ctx;
            _omniSendApi = omnisend;
        }



        [Function("TimerTriggerCSharp1")]
        public void Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer, FunctionContext context)
        {
            var Function1Object = new Function1(_amAmRepo, _omniSendApi, ctx);
            Function1Object.ProcessLeadsAndSales();
            var logger = context.GetLogger("TimerTriggerCSharp1");
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
