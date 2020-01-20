using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ovning17_v2.Data;

namespace Ovning17_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ////CreateHostBuilder(args).Build().Run();

            ////runs before the Startup.cs runs
            //var host = CreateHostBuilder(args).Build();

            ////using MS.Extensions.DependencyInjection
            //using(var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<ApplicationDbContext>();
            //    //using MS.EntityFrameworkCore
            //    context.Database.Migrate();

            //    var config = host.Services.GetRequiredService<IConfiguration>();

            //    //Behöver sättas via kommandotolken i projektkatalogen
            //    // dotnet user-secrets set "Gym:AdminPW" "LexiconNC19!"

            //    var adminPW = config["Gym:AdminPW"];

            //    try
            //    {
            //        SeedData.InitializeAsync(services, adminPW).Wait();
            //    }
            //    catch(Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex.Message, "Seed Fail");
            //    }

            //    host.Run();
            //}

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();

                var config = host.Services.GetRequiredService<IConfiguration>();


                //Behöver sättas via kommandotolken i projektkatalogen
                // dotnet user-secrets set "Gym:AdminPW" "LexiconNC19!"

                var adminPW = config["Gym:AdminPW"];

                try
                {
                    SeedData.InitializeAsync(services, adminPW).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex.Message, "Seed Fail");
                }
            }

            host.Run();
        }
    

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
