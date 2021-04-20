using System;
using System.Threading.Tasks;
using HostedService.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HostedService.Services
{
    public class FakeMetricsDeliverer : IMetricsDeliverer
    {
        private readonly TransportType _transport;

        private readonly Endpoint _deliverTo;

        private readonly ILogger _logger;

        private readonly Action<ILogger, DateTimeOffset, PerformanceMetrics, Endpoint, TransportType, Exception> _logForDelivery;

        public FakeMetricsDeliverer(
            IOptions<MetricsCollectionOptions> optionsAccessor,
            ILogger<FakeMetricsDeliverer> logger)
        {
            var options = optionsAccessor.Value;
            _transport = options.TransportType;
            _deliverTo = options.DeliverTo;
            _logger = logger;
            _logForDelivery = LoggerMessage.Define<DateTimeOffset, PerformanceMetrics, Endpoint, TransportType>(
                LogLevel.Information,
                0,
                "[{0}] Deliver performance counter {1} to {2} via {3}");
        }

        public Task DeliverAsync(PerformanceMetrics counter)
        {
            _logForDelivery(_logger, DateTimeOffset.Now, counter, _deliverTo, _transport, null);
            return Task.CompletedTask;
        }
    }
}