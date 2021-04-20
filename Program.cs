using System;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;



namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            
                CreateHostBuilder(args).Build().Run();
            
        }

        /*
                public static IHost MigrateDbContext<AppDbContext>(this IHost host) where AppDbContext:DbContext{
                    using(var scope=host.Services.CreateScope()){
                        var services = scope.ServiceProvider;
                        var logger=services.GetRequiredService<ILogger<AppDbContext>>();
                        var context=services.GetService<AppDbContext>();
                        context.Database.EnsureCreated();
                    }
                    return host;
                }
        */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
                
                
                
    }
}
