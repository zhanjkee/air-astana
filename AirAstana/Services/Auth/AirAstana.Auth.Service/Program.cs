using System;
using System.IO;
using System.Threading.Tasks;
using AirAstana.Auth.Options;
using AirAstana.Shared.Extensions;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AirAstana.Auth.Service
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

            var authOptions = configurationRoot.GetValidOptions<AuthOptions>(AuthOptions.SectionName);

            if (string.IsNullOrEmpty(authOptions.WebAddress))
            {
                throw new ArgumentNullException(nameof(authOptions.WebAddress));
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
                           .UseUrls(authOptions.WebAddress)
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
