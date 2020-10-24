using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AirAstana.Flights.Options;
using AirAstana.Flights.Service.OnStartup;
using AirAstana.Shared.Extensions;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AirAstana.Flights.Service
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Configure(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder Configure(string[] args)
        {
            // TODO: Get config file from environment variables.
            var configName = "appsettings.Development.json";
            var configurationRoot = GetConfigurationRoot(configName);

            var flightsOptions = configurationRoot.GetValidOptions<FlightsOptions>(FlightsOptions.SectionName);

            if (string.IsNullOrEmpty(flightsOptions.WebAddress))
            {
                throw new ArgumentNullException(nameof(flightsOptions.WebAddress));
            }

            return Host.CreateDefaultBuilder(args)
                       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                       .ConfigureWebHostDefaults(webHostBuilder =>
                       {
                           webHostBuilder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
                           {
                               configurationBuilder.AddJsonFile(configName, optional: false, reloadOnChange: false);
                               configurationBuilder.Build();
                           })
                           .UseKestrel()
                           .PreferHostingUrls(true)
                           .UseUrls(flightsOptions.WebAddress)
                           .ConfigureServices(x => x.AddAutofac())
                           .UseContentRoot(Directory.GetCurrentDirectory())
                           .UseStartup<Startup>();
                       });
        }

        private static IConfigurationRoot GetConfigurationRoot(string path)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path, optional: false, reloadOnChange: false)
                .Build();
        }
    }
}
