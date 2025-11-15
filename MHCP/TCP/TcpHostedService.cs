using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP.TCP
{
    public sealed class TcpHostedService : BackgroundService
    {
        private readonly TCPListener _listener;
        private readonly Organizator _organizator;

        public TcpHostedService(TCPListener listener, Organizator organizator)
        {
            _listener = listener;
            _organizator = organizator;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return _listener.ExecuteAsync(_organizator.HandleClientAsync, stoppingToken);
        }
    }
}
