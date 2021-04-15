namespace HostedService.Services
{
    public interface INetworkMetricsCollector
    {
        long GetThroughput();
    }
}