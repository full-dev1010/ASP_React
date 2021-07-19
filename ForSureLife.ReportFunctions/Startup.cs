using ForSureLife.repo;
using ForSureLife.repo._3rdPartyIntegrations;
using ForSureLife.repo.Interfaces;
using ForSureLife.repo.Services;
using ForSureLife.ReportFunctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ForSureLife.ReportFunctions
{
    // public class Startup : FunctionsStartup
    // {

    //     public override void Configure(IFunctionsHostBuilder builder)
    //     {
    //         System.Console.WriteLine();
    //         IConfiguration config = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("local.settings.json", true, true)
    //            .AddEnvironmentVariables()
    //            .Build();
    //         builder.Services.AddScoped<IAmAmApplicationRepository, AmAmApplicationRepository>();
    //         builder.Services.AddDbContext<ForSureLifeDBContext>(options => options.UseSqlServer(config["ConnectionStrings:Default"]));
    //         // builder.Services.AddDbContext<ChildForSureLifeDBContext>(options => options.UseSqlServer(config["ConnectionStrings:Default"]));

    //     }

    // }

    class Program
    {
        static async Task Main(string[] args)
        {
            // string sqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            // #if DEBUG
            //             Debugger.Launch();
            // #endif
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddScoped<IAmAmApplicationRepository, AmAmApplicationRepository>();
                    s.AddScoped<IOmniSendAPI, OmniSendAPI>();
                    s.AddDbContext<ForSureLifeDBContext>(options => options.UseSqlServer("Data Source=tcp:kalilifedb.database.windows.net,1433;Initial Catalog=KaliLifeDb;Persist Security Info=False;User ID=adminKaliLife;Password=KaliLife1!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=True"));
                })
                .Build();

            await host.RunAsync();
        }
    }
}
