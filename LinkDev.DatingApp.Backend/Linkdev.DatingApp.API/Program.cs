using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkDev.DatingApp.Presistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LinkDev.DatingApp.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var scope = host.Services.CreateScope();
            var services= scope.ServiceProvider;
            try{

                var context= services.GetRequiredService<DatingAppContext>();
                await context.Database.MigrateAsync();
                if(context?.Users?.Count() < 1)
                {
                var seed= services.GetRequiredService<Seed>();
                await seed.SeedUsers(context);
                }
                var logger =  services.GetRequiredService<ILogger<Program>>();
                logger.LogDebug("Hello i have passed here ! ... ");

            }catch (Exception ex)
            {
                var logger =  services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex,ex.Message);
            }

            await host.RunAsync();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
