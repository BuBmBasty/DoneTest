using Note.Identity;
using Note.Identity.Data;
using System;

namespace Notes.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) 
            { 
                var serviseProvider = scope.ServiceProvider;
                try
                {
                    var context = serviseProvider.GetRequiredService<AuthDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex) 
                {
                    var logger = serviseProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured while app initialization");
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
