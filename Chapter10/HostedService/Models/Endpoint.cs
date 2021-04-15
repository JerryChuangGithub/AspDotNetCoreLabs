namespace HostedService.Models
{
    public class Endpoint
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public override string ToString() => $"{this.Host}:{this.Port}";
    }
}