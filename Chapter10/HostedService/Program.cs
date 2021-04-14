using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostedService
{
    class Program
    {
        static void Main(string[] args)
        {
            var collector = new FakeMetricsCollector();

            new HostBuilder()
            .ConfigureServices(svcs =>
                // svcs.AddSingleton<IHostedService, PerformanceMetricsCollector>())
                svcs.AddSingleton<IProcessorMetricsCollector>(collector)
                    .AddSingleton<IMemoryMetricsCollector>(collector)
                    .AddSingleton<INetworkMetricsCollector>(collector)
                    .AddSingleton<IMetricsDeliverer, FakeMetricsDeliverer>()
                    .AddHostedService<PerformanceMetricsCollector>())
            .Build()
            .Run();
        }
    }
}
