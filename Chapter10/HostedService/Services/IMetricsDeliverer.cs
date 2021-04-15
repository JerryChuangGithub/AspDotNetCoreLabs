using System.Threading.Tasks;

namespace HostedService.Services
{
    public interface IMetricsDeliverer
    {
        Task DeliverAsync(PerformanceMetrics counter);
    }
}