using System;
using System.Threading.Tasks;
namespace HostedService.Services
{
    public class FakeMetricsDeliverer : IMetricsDeliverer
    {
        public Task DeliverAsync(PerformanceMetrics counter)
        {
            Console.WriteLine($"[{DateTimeOffset.Now}]{counter}");
            return Task.CompletedTask;
        }
    }
}