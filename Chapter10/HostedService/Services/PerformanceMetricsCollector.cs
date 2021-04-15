using System;
using System.Threading;
using System.Threading.Tasks;
using HostedService.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace HostedService.Services
{
    public sealed class PerformanceMetricsCollector : IHostedService
    {
        private IDisposable _scheduler;
        private readonly IProcessorMetricsCollector _processorMetricsCollector;
        private readonly IMemoryMetricsCollector _memoryMetricsCollector;
        private readonly INetworkMetricsCollector _networkMetricsCollector;
        private readonly IMetricsDeliverer _metricsDeliverer;
        private readonly TimeSpan _captureInterval;

        public PerformanceMetricsCollector(
            IProcessorMetricsCollector processorMetricsCollector,
            IMemoryMetricsCollector memoryMetricsCollector,
            INetworkMetricsCollector networkMetricsCollector,
            IMetricsDeliverer metricsDeliverer,
            IOptions<MetricsCollectionOptions> optionsAccessor)
        {
            _processorMetricsCollector = processorMetricsCollector;
            _memoryMetricsCollector = memoryMetricsCollector;
            _networkMetricsCollector = networkMetricsCollector;
            _metricsDeliverer = metricsDeliverer;
            _captureInterval = optionsAccessor.Value.CaptureInterval;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = new Timer(Callback, null, _captureInterval, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;

            async void Callback(object state)
            {
                var counter = new PerformanceMetrics
                {
                    Processor = _processorMetricsCollector.GetUsage(),
                    Memory = _memoryMetricsCollector.GetUsage(),
                    Network = _networkMetricsCollector.GetThroughput()
                };
                await _metricsDeliverer.DeliverAsync(counter);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler?.Dispose();
            return Task.CompletedTask;
        }
    }
}