using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AirAstana.Auth.Service.OnStartup;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
