using System.IO;
using AirAstana.Auth.Service.OnStartup;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AirAstana.Auth.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
                    {
                        configurationBuilder.Build();
                    })
                           .UseKestrel()
                           .PreferHostingUrls(true)
                           .ConfigureServices(x => x.AddAutofac())
                           .UseContentRoot(Directory.GetCurrentDirectory())
                           .UseStartup<Startup>();

                });
    }
}
