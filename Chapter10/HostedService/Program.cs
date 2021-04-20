using System.Collections.Immutable;
using System;
using HostedService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HostedService.Models;

namespace HostedService
{
    class Program
    {
        static void Main(string[] args)
        {
            var collector = new FakeMetricsCollector();

            new HostBuilder()
            .ConfigureHostConfiguration(builder => builder.AddCommandLine(args))
            .ConfigureAppConfiguration((context, builder) => 
                builder.AddJsonFile(path: "appsettings.json", optional: false)
                    .AddJsonFile(path: $"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true))
            .ConfigureServices((context, svcs) =>
                // svcs.AddSingleton<IHostedService, PerformanceMetricsCollector>())
                svcs.AddSingleton<IProcessorMetricsCollector>(collector)
                    .AddSingleton<IMemoryMetricsCollector>(collector)
                    .AddSingleton<INetworkMetricsCollector>(collector)
                    .AddSingleton<IMetricsDeliverer, FakeMetricsDeliverer>()
                    .AddHostedService<PerformanceMetricsCollector>()
                    .AddOptions()
                        .Configure<MetricsCollectionOptions>(context.Configuration.GetSection("MetricsCollection")))
            .ConfigureLogging(builder => builder.AddConsole())
            .Build()
            .Run();
        }
    }
}
