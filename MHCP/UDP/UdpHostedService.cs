using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP.UDP
{
    public sealed class UdpHostedService : BackgroundService
    {
        private readonly UdpListener _listener;

        public UdpHostedService(UdpListener listener)
        {
            _listener = listener;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return _listener.RunAsync(stoppingToken);
        }
    }
}
