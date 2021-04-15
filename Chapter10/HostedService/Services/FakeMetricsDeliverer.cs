using System;
using System.Threading.Tasks;
using HostedService.Models;
using Microsoft.Extensions.Options;

namespace HostedService.Services
{
    public class FakeMetricsDeliverer : IMetricsDeliverer
    {
        private readonly TransportType _transport;

        private readonly Endpoint _deliverTo;

        public FakeMetricsDeliverer(IOptions<MetricsCollectionOptions> optionsAccessor)
        {
            var options = optionsAccessor.Value;
            _transport = options.TransportType;
            _deliverTo = options.DeliverTo;
        }

        public Task DeliverAsync(PerformanceMetrics counter)
        {
            Console.WriteLine($"[{DateTimeOffset.Now}]{counter} to {_deliverTo} via {_transport}");
            return Task.CompletedTask;
        }
    }
}