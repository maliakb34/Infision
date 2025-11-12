using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Infision.MHCP.Core
{
    /// <summary>
    /// Background service that drives the TCP connection manager loop.
    /// </summary>
    public sealed class ConnectionHostedService : BackgroundService
    {
        private readonly ConnectionManager _manager;

        public ConnectionHostedService(ConnectionManager manager)
        {
            _manager = manager;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return _manager.RunAsync(stoppingToken);
        }
    }
}