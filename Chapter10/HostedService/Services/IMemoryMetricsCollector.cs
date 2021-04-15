namespace HostedService.Services
{
    public interface IMemoryMetricsCollector
    {
        long GetUsage();
    }
}