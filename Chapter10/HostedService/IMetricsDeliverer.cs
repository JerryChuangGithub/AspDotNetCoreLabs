using System.Threading.Tasks;

namespace HostedService
{
    public interface IMetricsDeliverer
    {
        Task DeliverAsync(PerformanceMetrics counter);
    }
}