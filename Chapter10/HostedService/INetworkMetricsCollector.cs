namespace HostedService
{
    public interface INetworkMetricsCollector
    {
        long GetThroughput();
    }
}