using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostedService
{
    class Program
    {
        static void Main(string[] args)
        {
            new HostBuilder()
            .ConfigureServices(svcs =>
                // svcs.AddSingleton<IHostedService, PerformanceMetricsCollector>())
                svcs.AddHostedService<PerformanceMetricsCollector>())
            .Build()
            .Run();
        }
    }
}
