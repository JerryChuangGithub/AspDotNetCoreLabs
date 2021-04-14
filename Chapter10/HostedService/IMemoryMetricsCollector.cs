namespace HostedService
{
    public interface IMemoryMetricsCollector
    {
        long GetUsage();
    }
}