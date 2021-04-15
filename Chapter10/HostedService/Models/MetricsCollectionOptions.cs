using System;
namespace HostedService.Models
{
    public class MetricsCollectionOptions
    {
        public TimeSpan CaptureInterval { get; set; }

        public TransportType TransportType { get; set; }

        public Endpoint DeliverTo { get; set; }
    }
}