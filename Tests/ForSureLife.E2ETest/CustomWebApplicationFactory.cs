
#define MYTEST


using System;
using System.IO;
using System.Linq;
using ForSureLife.repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using System.Collections.Generic;
using ForSureLife.repo.Models.Enroll;
using ForSureLife.repo.Models.Rate;

namespace ForSureLife.E2ETest
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Initalization code goes here
            SetTheWorkingDirectoryForSureLife();
        }

        private static void SetTheWorkingDirectoryForSureLife()
        {
            var path = "../../../../../../ForSureLife/Assets";
            while (path.Length > "ForSureLife/Assets".Length)
            {
                if (Directory.Exists(path))
                {
                    Directory.SetCurrentDirectory(new DirectoryInfo(path).Parent.FullName);
                    break;
                }
                path = path.Substring(3);
            }
        }
    }
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {




        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ForSureLifeDBContext>));

                services.Remove(descriptor);

                services.AddDbContext<ForSureLifeDBContext>(options =>
                {
                    options.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=ProjectsV13Test;Trusted_Connection=True;MultipleActiveResultSets=true");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ForSureLifeDBContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();


                    using var cs = new Microsoft.Data.SqlClient.SqlConnection("Server=(localdb)\\ProjectsV13;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true");
                    cs.Execute("DROP DATABASE IF EXISTS ProjectsV13Test");                  
                    db.Database.Migrate();

                    // using (var cs = new Microsoft.Data.SqlClient.SqlConnection("Server=localhost\\SQLEXPRESS;Database=ProjectsV13;Trusted_Connection=True;MultipleActiveResultSets=true"))
                    // {
                    //     db.AmState.AddRange(cs.Query<AmState>("select * from AmState").ToList());
                    //     db.CarrierPlanRate.AddRange(cs.Query<CarrierPlanRate>("select * from CarrierPlanRate").ToList());
                    //     db.SaveChanges();
                    // }
                    try
                    {
                        // Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }
    }
}
